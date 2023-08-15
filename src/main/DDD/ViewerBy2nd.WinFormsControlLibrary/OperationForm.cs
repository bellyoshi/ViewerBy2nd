global using ViewerBy2nd.Infrastructure;
using System.Data;
using System.Diagnostics;
using ViewerBy2nd.WinFormsControlLibrary;
using ViewerBy2ndLib;

namespace ViewerBy2nd
{

    public partial class OperationForm : Form
    {
        static Settings Default => ConfigurationReader.Default;

        OperationViewModel model;

        TrackbarMouseDownScroller trackbarMouseDownScroller;

        private VideoPlayer thumbnailMoviePlayer;

        private bool initilizing;
        public OperationForm()
        {
            initilizing = true;

            InitializeComponent();

            thumbnailMoviePlayer = new(videoView1);

            trackbarMouseDownScroller = new(SeekTrackBar);
            trackbarMouseDownScroller.TrackBarScrollRequire += TrackbarMouseDownScroller_TrackBarScrollRequire;
            trackbarMouseDownScroller.TrackBarScrolled += TrackbarMouseDownScroller_TrackBarScrolled;

            model = new();
            model.FileListChanged += Model_FileListChanged;
            model.SelectedIndexChanged += Model_SelectedIndexChanged;

            initilizing = false;
        }



        private void TrackbarMouseDownScroller_TrackBarScrolled()
        {

            if (PreviewFile == null)
                return;
            PreviewFile.TrackBarValue = SeekTrackBar.Value;
            var seek_time = GetSeekTimeFromTrackBarValue(SeekTrackBar.Value);
            if (thumbnailMoviePlayer.RequiredReload)
            {
                thumbnailMoviePlayer.Play(PreviewFile.FileName, seek_time);
            }
            thumbnailMoviePlayer.Time = seek_time;
            if (player != null)
                player.Time = thumbnailMoviePlayer.Time;
            SeekAfterProcess();
        }

        private int GetSeekTimeFromTrackBarValue(int value)
        {
            return Convert.ToInt32(value * 100);
        }

        private void TrackbarMouseDownScroller_TrackBarScrollRequire()
        {

            if (PreviewFile == null)
                return;
            SeekTrackBar.Maximum = (int)thumbnailMoviePlayer.Length / 100;
            var value = (int)thumbnailMoviePlayer.Time / 100;
            if (0 <= value && value <= SeekTrackBar.Maximum)
            {
                SeekTrackBar.Value = value;
            }
            SeekAfterProcess();
        }

        private void Model_FileListChanged()
        {
            FilesListUpdate();

            MenuListUpdate();
        }

        private void Model_SelectedIndexChanged()
        {
            FilesListSelectedIndexUpdate();

            MenuListSlectedIndexUpdate();

            if (FilesList.SelectedItem == null)
            {
                player?.Stop();
            }
            ControlEnable();
            if (!IsMovie)
                Document?.UpdateImage();
            UpdateViewIfChecked();
            if (FitToWindowWidthButton.Enabled)
                VScrollBar1Init();
        }

        private void FilesListSelectedIndexUpdate()
        {
            if (model.MultiSelected) return;
            SelectedIndexChanged_ReasonIsMenu = true;
            FilesList.ClearSelected();
            FilesList.SelectedIndex = model.SelectedIndex;
            SelectedIndexChanged_ReasonIsMenu = false;
        }

        private void FilesListUpdate()
        {
            var items = FilesList.Items;
            items.Clear();
            foreach (var item in model.FileList)
            {
                items.Add(item);
            }
            if (items.Count > 0)
            {
                FilesList.SelectedIndex = Math.Min(model.SelectedIndex, items.Count - 1);
            }

        }

        private void ControlEnable()
        {
            if (initilizing) return;
            MenuControlEnabled();
            CtlPdf1ControlEnabled();
            CtlMovie1ControlEnabled();
            CtlImage1ControlEnabled();
            ListControlEnabled();
            CtlSecondEnabled();
        }

        private void MenuControlEnabled()
        {
            スリムToolStripMenuItem.Checked = !FilesList.Visible;
            標準ToolStripMenuItem.Checked = FilesList.Visible;
        }

        public void ListControlEnabled()
        {
            DeleteFilesFromListButton.Enabled = 0 < FilesList.SelectedItems.Count;
            DeselectFilesButton.Enabled = 0 < FilesList.SelectedItems.Count;
            DeleteFilesFromListButton.Visible = FilesList.Visible;
            AddFilesButton.Visible = FilesList.Visible;
            AllFilesSelectButton.Visible = FilesList.Visible;
            DeselectFilesButton.Visible = FilesList.Visible;
        }

        public bool IsMovie
            => (Document != null) && Document.FileType.IsMovieExt;



        private void CtlSecondEnabled()
        {
            DisplayButton.Enabled = !AutoDisplayCheckBox.Checked || !Dispacher.ViewerVisible || IsMovie;
            DisplayButton.Text = IsMovie ? "再生" : "表示";

            SecondGroup.Visible = FilesList.Visible;
            SecondOfSmallPanel.Visible = !FilesList.Visible;


        }

        public void CtlPdf1ControlEnabled()
        {

            var isPdf = (Document != null) && Document.FileType.IsPDFExt;
            FirstPageOfPDFButton.Enabled = isPdf;
            PreviousPageOfPDFButton.Enabled = isPdf;
            NextPageOfPDFButton.Enabled = isPdf;
            LastPageOfPDFButton.Enabled = isPdf;
            PreviousHalfPageOfPDFButton.Enabled = isPdf;
            NextHalfPageOfPDFButton.Enabled = isPdf;
            pnlPage.Visible = isPdf || Document == null;
            PageNumberLabel.Visible = isPdf;

            bool canSetWin = (Document != null) && (Document.FileType.IsPDFExt || Document.FileType.IsImageExt || Document.FileType.IsSVGExt);
            FitToWindowWidthButton.Enabled = canSetWin;
            ShowWholeButton.Enabled = canSetWin;
            ZoomOutButton.Enabled = canSetWin;
            ZoomInButton.Enabled = canSetWin;
            InPageScrollBar.Enabled = (PreviewFile != null) && PreviewFile.IsZoom;

            ページナビゲーションToolStripMenuItem.Enabled = isPdf;
        }

        public void CtlMovie1ControlEnabled()
        {
            pnlMovie.Visible = IsMovie;
            GotoFirstButton.Enabled = IsMovie;
            FastReverseButton.Enabled = IsMovie;
            PlayButton.Enabled = IsMovie;
            PauseButton.Enabled = IsMovie;
            FastForwardButton.Enabled = IsMovie;
            AutoDisplayCheckBox.Enabled = !IsMovie;
            videoView1.Visible = IsMovie;
            SeekTrackBar.Enabled = IsMovie;
            SeekTrackBar.Visible = IsMovie;
            if (!IsMovie)
                thumbnailMoviePlayer.Stop();
            MovieTimeLabel.Visible = IsMovie;

            再生ToolStripMenuItem.Enabled = IsMovie;
        }

        public void CtlImage1ControlEnabled()
        {
            var IsPdfOrImage = (Document != null) && (!Document.FileType.IsMovieExt);

            Rotate270Button.Enabled = IsPdfOrImage;
            Rotate90Button.Enabled = IsPdfOrImage;
            Rotate180Button.Enabled = IsPdfOrImage;
            Rotate0Button.Enabled = IsPdfOrImage;
            pnlDispOption.Visible = IsPdfOrImage || Document == null;
        }

        private void OperationForm_Load(object sender, EventArgs e)
        {
            言語LToolStripMenuItem.Visible = false;//todo 言語LToolStripMenuItem機能追加
            Dispacher.RegistrationfrmOperation(this);

            AppSettingLoad();
            ControlRelocation();
            ControlEnable();


            this.MouseWheel +=  new MouseEventHandler(this.OperationForm_MouseWheel);
        }

        private void AppSettingLoad()
        {
            AutoDisplayCheckBox.Checked = Default.AutoUpdate;
            操作中に自動表示ToolStripMenuItem.Checked = AutoDisplayCheckBox.Checked;

            NotifyBackColor();

            try
            {
                // XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer = new(typeof(List<FileViewParam>));
                // 読み込むファイルを開く
                var filename = "lstPDFFiles.xml";
                if (!File.Exists(filename))
                    return;
                using StreamReader sr = new(filename, new System.Text.UTF8Encoding(false));
                // XMLファイルから読み込み、逆シリアル化する
                var deserialize = serializer.Deserialize(sr);
                if (deserialize != null)
                {
                    List<FileViewParam> fvinfos = (List<FileViewParam>)deserialize;

                    model.Initialize(fvinfos);
                }
                Model_FileListChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void OperationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppSettingSave();
        }

        private void AppSettingSave()
        {
            Default.AutoUpdate = AutoDisplayCheckBox.Checked;

            List<FileViewParam> fvinfos = new();
            foreach (FileViewParam info in FilesList.Items)
                fvinfos.Add(info);
            System.Xml.Serialization.XmlSerializer serializer = new(typeof(List<FileViewParam>));
            // 書き込むファイルを開く（UTF-8 BOM無し）
            using StreamWriter sw = new("lstPDFFiles.xml", false, new System.Text.UTF8Encoding(false));
            // シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, fvinfos);
        }

        public void SetThumnailSize()
        {
            pbThumbnail.Height = GetThumnailWidth(pbThumbnail.Width);
            videoView1.Height = GetThumnailWidth(videoView1.Width);
        }
        private static int GetThumnailWidth(int thumWidth)
        {
            var viewerSize = ViewScreenRegister.GetInstance().Size;
            return thumWidth * viewerSize.Height / viewerSize.Width;
        }

        private FormDispacher Dispacher { get; } = FormDispacher.GetInstance();

        private void DeleteFilesFromListButton_Click(object sender, EventArgs e)
        {
            if (FilesList.SelectedItem == null)
                return;


            var deleteList = FilesList.SelectedItems.Cast<FileViewParam>().ToList();
            var isDeletePreview = DisplayFile != null && deleteList.Contains(DisplayFile) || PreviewFile != null && deleteList.Contains(PreviewFile);
            model.DeleteFiles(deleteList);


            //削除したときに残っていれば表示を消す。
            if (isDeletePreview)
            {
                pbThumbnail.Image = null;
                SetPreview();
                if (Dispacher.ViewerVisible)
                {
                    UpdateView();
                }

                ControlEnable();
            }

        }

        private void FilesList_Click(object sender, EventArgs e)
        {
            if (PreviewFile == null)
                return;
            var path = PreviewFile.FileName;
            if (!System.IO.File.Exists(path))
            {
                var ret = MessageBox.Show("ファイルが見つかりません。リストから削除しますか？", "ファイルがありません", MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                    FilesList.Items.Remove(PreviewFile);
                return;
            }

            UpdateViewIfChecked();

            ControlEnable();
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            DisplayButtonAction();
        }

        private void DisplayButtonAction()
        {
            if (IsMovie)
            {
                PlayPlayer();
            }
            else
            {
                UpdateView();
            }
            ControlEnable();
        }

        private void PlayMovie()
        {
            Debug.Assert(PreviewFile != null);
            var vlc = Dispacher.ShowMovie();
            int starttime = Convert.ToInt32(thumbnailMoviePlayer.Time);
            vlc.Volume = 100;
            vlc.Play(PreviewFile.FileName, starttime);
            player = vlc;
            player.Rate = 1.0f;
            DisplayFile = PreviewFile;
        }

        private VideoPlayer? player;

        private void PausePlayer()
        {
            player?.Pause();
            //todo : thumbnail 止まらないのでは？
        }

        private void PlayPlayer()
        {

            thumbnailMoviePlayer.Play();

            PlayMovie();
        }
        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            try
            {
                model.AddFiles(
                     GetAddFiles().Select(param => param.FileName)
                     );
            }
            catch (OperationCanceledException)
            {
                //no operaton
            }




        }
        private void AddFilesAndSelect()
        {
            model.AddFiles(
    GetAddFiles().Select(param => param.FileName)
    );

            FileViewParam? last = null;
            foreach (FileViewParam item in FilesList.Items)
            {
                last = item;
            }
            if (last != null)
            {
                model.SelectFileViewParam(last);
            }
        }




        private IEnumerable<FileViewParam> GetAddFiles()
        {
            OpenFileDialog1.Multiselect = true;
            OpenFileDialog1.Filter = FileTypes.CreateFilter();
            OpenFileDialog1.FileName = txtPDFFileName.Text;
            var ret = OpenFileDialog1.ShowDialog();
            if (ret == DialogResult.Cancel)
                throw new OperationCanceledException();

            return OpenFileDialog1.FileNames.Select(
                filename => new FileViewParam(filename, ViewScreenRegister.GetInstance().Size));
        }

        private void AddFiles()
        {
            var items = FilesList.Items;


            foreach (var param in GetAddFiles())
                items.Add(param);

        }

        private void DeselectFiles_Click(object sender, EventArgs e)
        {
            FilesList.SelectedItem = null;
            pbThumbnail.Image = null;
            ControlEnable();
        }

        private void EndOfDisplayButton_Click(object sender, EventArgs e)
        {
            EndOfDisplayAction();
        }

        public void EndOfDisplayAction()
        {
            Dispacher.CloseViewers();
        }

        public void CloseViewerAfterAction()
        {
            DisplayFile = null;
            thumbnailMoviePlayer.Pause();
            player?.Pause();
            player = null;
            ControlEnable();
        }

        private void BackgroundDisplay_Click(object sender, EventArgs e)
        {
            BackgroundDisplayAction();
        }

        private void BackgroundDisplayAction()
        {
            FilesList.SelectedItem = null;
            pbThumbnail.Image = null;
            SetPreview();
            UpdateView();
            ControlEnable();
            DisplayFile = null;
        }

        private void FilesList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null)
            {
                return;
            }
            // コントロール内にドラッグされたとき実行される
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                // ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
                e.Effect = DragDropEffects.Copy;
            else
                // ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
        }

        private void FilesList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null)
            {
                return;
            }
            var items = FilesList.Items;
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (var f in fileName)
                items.Add(new FileViewParam(f, ViewScreenRegister.GetInstance().Size));
        }

        private void AutoDisplayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            操作中に自動表示ToolStripMenuItem.Checked = AutoDisplayCheckBox.Checked;
            UpdateViewIfChecked();
            ControlEnable();
        }
        private void RotateAction_Click(RotateFlipType rotateFlipType)
        {
            Debug.Assert(Document != null);
            Document.Rotate(rotateFlipType);
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void Rotate180Button_Click(object sender, EventArgs e)
        {
            RotateAction_Click(RotateFlipType.Rotate180FlipNone);
        }

        private void Rotate90Button_Click(object sender, EventArgs e)
        {
            RotateAction_Click(RotateFlipType.Rotate90FlipNone);
        }

        private void Rotate0Button_Click(object sender, EventArgs e)
        {
            RotateAction_Click(RotateFlipType.RotateNoneFlipNone);
        }

        private void Rotate270Button_Click(object sender, EventArgs e)
        {
            RotateAction_Click(RotateFlipType.Rotate270FlipNone);
        }

        public void UpdateViewIfChecked()
        {
            SetPreview();
            if (AutoDisplayCheckBox.Checked && !(Document?.FileType?.IsMovieExt??false))
                UpdateView();
        }

        public void UpdateView()
        {
            ImageDisposer.DisplayImage = pbThumbnail.Image;
            Dispacher.ShowImage(ImageDisposer.DisplayImage);
            DisplayFile = PreviewFile;
        }

        private FileViewParam? PreviewFile
        {
            get
            {
                if (FilesList.SelectedItems.Count != 1)
                    return null;
                if (FilesList.SelectedItem == null)
                    return null;
                var p = (FileViewParam)FilesList.SelectedItem;
                p.BoundsSize = ViewScreenRegister.GetInstance().Size;
                return p;
            }
        }

        private FileViewParam? DisplayFile;

        private Document? Document
        {
            get
            {
                if (System.IO.File.Exists(PreviewFile?.FileName))
                {
                    var doc = PreviewFile?.Document;
                    if (doc != null)
                    {
                        return doc;
                    }
                }
                return null;
            }
        }



        private void FirstPageOfPDFButton_Click(object sender, EventArgs e)
        {
            FirstPageOfPDFAction();
        }

        private void FirstPageOfPDFAction()
        {
            Debug.Assert(Document != null);
            ScrollToFirst();
            Document.FirstPage();

            UpdateViewIfChecked();
        }

        private void NextPageOfPDF_Click(object sender, EventArgs e)
        {
            NextPageOfPDFAction();
        }

        private void NextPageOfPDFAction()
        {
            Debug.Assert(Document != null);
            if (!Document.CanNextPage()) return;
            ScrollToFirst();
            Document.NextPage();

            UpdateViewIfChecked();
        }

        private void ScrollToFirst()
        {
            Debug.Assert(PreviewFile != null);
            if (PreviewFile.IsZoom)
            {
                InPageScrollBar.Value = 0;
                PreviewFile.ScrollBarValue = 0;
            }
        }

        private void PreviousPageOfPDFButton_Click(object sender, EventArgs e)
        {
            PreviousPageOfPDFAction();
        }

        private void PreviousPageOfPDFAction()
        {
            Debug.Assert(Document != null);
            Document.PrePage();
            UpdateViewIfChecked();
        }

        private void LastPageOfPDF_Click(object sender, EventArgs e)
        {
            LastPageOfPDFAction();
        }

        private void LastPageOfPDFAction()
        {
            Debug.Assert(Document != null);
            Document.LastPage();
            UpdateViewIfChecked();
        }

        private void SetPreview()
        {
            txtPDFFileName.Text = "" + PreviewFile?.FileName;

            PageNumberLabel.Text = $"ページ{Document?.PageVirtualIndex + 1}/{Document?.PageCount}";



            pbThumbnail.Visible = !IsMovie;
            videoView1.Visible = IsMovie;

            if (IsMovie)
            {
                string filename = PreviewFile?.FileName??string.Empty;
                thumbnailMoviePlayer.LoadFile(filename,
                    GetSeekTimeFromTrackBarValue(PreviewFile?.TrackBarValue??0));
                player?.LoadFile(filename);



            }
            else
            {
                ImageDisposer.PrevieImage = Document?.OutPutImage;
                pbThumbnail.Image = ImageDisposer.PrevieImage;
                pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void NextHalfPageOfPDFButton_Click(object sender, EventArgs e)
        {
            Debug.Assert(Document != null);
            Document.NextHalfPage();
            UpdateViewIfChecked();
        }

        private void PreviousHalfPageOfPdfButton_Click(object sender, EventArgs e)
        {
            Debug.Assert(Document != null);
            Document.PreviousHalfPage();
            UpdateViewIfChecked();
        }

        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            requireVScrollUpdate = true;

        }
        private void VScrollUpdateSync()
        {
            if (requireVScrollUpdate)
            {
                VScrollUpdate();
                requireVScrollUpdate =false;
            }

        }
        bool requireVScrollUpdate = false;
        private void VScrollUpdate()
        {
            if (PreviewFile == null)
                return;
            Debug.Assert(Document != null);
            PreviewFile.ScrollBarValue = InPageScrollBar.Value;
            Document.UpdateImage();
            UpdateViewIfChecked();
        }

        private void VScrollBar1Init()
        {
            Debug.Assert(PreviewFile != null);
            Debug.Assert(Document != null);
            if (Document.OriginalImageHeight == 0)
            {
                return;
            }
            InPageScrollBar.Minimum = 0;
            var clientWidth = Document?.OutPutImage?.Height??0;
            InPageScrollBar.Maximum = Document?.OriginalImageHeight??0;
            var scrolbarValue = Math.Min(PreviewFile.ScrollBarValue, InPageScrollBar.Maximum);

            InPageScrollBar.Value = Math.Max(0, scrolbarValue);

            InPageScrollBar.LargeChange = clientWidth;
        }

        private void FitToWindowWidthButton_Click(object sender, EventArgs e)
        {
            FitToWindowWidthAction();
        }

        private void FitToWindowWidthAction()
        {
            Debug.Assert(PreviewFile != null);
            Debug.Assert(Document != null);
            PreviewFile.ScrollBarValue = 0;
            PreviewFile.IsZoom = true;
            PreviewFile.ZoomHeight = Document.GetZoomImageHeightMin();
            Document.UpdateImage();
            ControlEnable();
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            PlayAction();

        }

        private void PlayAction()
        {
            thumbnailMoviePlayer.Rate = 1;
            FastForwardButton.Text = "▶▶";
            thumbnailMoviePlayer.Play();
            if (Dispacher.ViewerVisible)
            {
                PlayPlayer();
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            PauseAction();

        }

        private void PauseAction()
        {
            thumbnailMoviePlayer.Pause();
            PausePlayer();
        }

        private void FastForwardButton_Click(object sender, EventArgs e)
        {
            FastForwardAction();

        }

        private void FastForwardAction()
        {
            FastForwardButton.Text = "▶▶▶";
            if (thumbnailMoviePlayer.Rate == 2.0)
            {
                thumbnailMoviePlayer.Rate = 4.0f;
                if (player != null)
                    player.Rate = 4.0f;
            }
            else
            {
                thumbnailMoviePlayer.Rate = 2.0f;
                if (player != null)
                    player.Rate = 2.0f;
            }
        }

        private void FastReverseButton_Click(object sender, EventArgs e)
        {
            FastReverseAction();
        }

        private void FastReverseAction()
        {
            if (thumbnailMoviePlayer.Time < 15000)
                thumbnailMoviePlayer.Time = 0;
            else
                thumbnailMoviePlayer.Time -= 15000;
            if (player != null)
            {
                player.Time = thumbnailMoviePlayer.Time;
            }
        }

        private void GotoFirstButton_Click(object sender, EventArgs e)
        {
            GoToFirstAction();

        }

        private void GoToFirstAction()
        {
            thumbnailMoviePlayer.Time = 0;
            if (player != null)
            {
                player.Time = 0;
            }
        }



        private void SeekAfterProcess()
        {
            MovieTimeLabelUpdate();
            ControlEnable();
            SyncThumbnail();
            VScrollUpdateSync();

        }



        private void SyncThumbnail()
        {
            if (player == null) return;
            if (!player.IsPlaying) return;
            if (player.Time < 1000) return;
            if (Math.Abs(thumbnailMoviePlayer.Time - player.Time) > 500)
            {
                thumbnailMoviePlayer.Time = player.Time;
            }

        }

        private void MovieTimeLabelUpdate()
        {
            TimeSpan ts = new(thumbnailMoviePlayer.Time * 10000);
            MovieTimeLabel.Text = ts.ToString(@"hh\:mm\:ss");
        }



        private void ShowWholeButton_Click(object sender, EventArgs e)
        {
            ShowWholeAction();
        }

        private void ShowWholeAction()
        {
            Debug.Assert(PreviewFile != null);
            PreviewFile.IsZoom = false;
            Document?.UpdateImage();
            ControlEnable();
            UpdateViewIfChecked();
        }



        private void AllFilesSelectButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= FilesList.Items.Count - 1; i++)

                FilesList.SetSelected(i, true);
        }



        private void MouseWheelScrollLine(int delta)
        {
            Debug.Assert(Document != null);
            var numberOfTextLinesToMove = delta * SystemInformation.MouseWheelScrollLines / (double)25;
            var maximum = InPageScrollBar.Maximum - InPageScrollBar.LargeChange + 1;
            int expect = -Convert.ToInt32(numberOfTextLinesToMove) + InPageScrollBar.Value;
            if (expect < 0)
            {
                expect = 0;
                if (Document.CanPrePage())
                {
                    expect = maximum;
                    Document.PrePage();
                }
            }

            if (maximum < expect)
            {
                expect = maximum;
                if (Document.CanNextPage())
                {
                    expect = 0;
                    Document.NextPage();
                }
            }
            InPageScrollBar.Value = expect;
            requireVScrollUpdate = true;
        }
        private void MouseWheelScrollPage(int delta)
        {
            if (Document is null)
            {
                return;
            }

            if (delta>0)
            {
                if (Document.CanPrePage())
                {
                    Document.PrePage();
                    UpdateViewIfChecked();
                }
            }
            else
            {
                if (Document.CanNextPage())
                {
                    Document.NextPage();
                    UpdateViewIfChecked();
                }
            }
            return;

        }
        public void OperationForm_MouseWheel(object? sender, MouseEventArgs e)
        {

            if (!InPageScrollBar.Enabled)
            {
                MouseWheelScrollPage(e.Delta);
            }
            else
            {
                MouseWheelScrollLine(e.Delta);
            }

        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            ZoomInAction();
        }

        private void ZoomInAction()
        {
            Debug.Assert(PreviewFile != null);
            Document?.ZoomUp();
            PreviewFile.ScrollBarValue = 0;
            Document?.UpdateImage();
            ControlEnable();
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            ZoomOutAction();
        }

        private void ZoomOutAction()
        {
            Debug.Assert(PreviewFile != null);
            Document?.ZoomDown();
            PreviewFile.ScrollBarValue = 0;
            Document?.UpdateImage();
            ControlEnable();
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void このアプリについてToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispacher.ShowVersion();
        }



        private void ディスプレイと背景色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispacher.ShowSetting();
        }

        internal void NotifyBackColor()
        {


            pbThumbnail.BackColor = BackColorRegister.GetInstance().BackColor;

        }

        private void OperationForm_Resize(object sender, EventArgs e)
        {
            FilesList.Visible = 600 < Width;
            ControlRelocation();
            ControlEnable();
        }


        private void ControlRelocation()
        {



            if (FilesList.Visible)
            {
                FilesList.Width = 260;
                MainPanel.Location = new Point(270, 30);
                videoView1.Bounds = thumbnailDefaultPanel.Bounds;
                pbThumbnail.Bounds = thumbnailDefaultPanel.Bounds;
            }
            else
            {

                MainPanel.Location = new Point(0, 30);
                videoView1.Bounds = ThumnailMovoToPanel.Bounds;
                pbThumbnail.Bounds = ThumnailMovoToPanel.Bounds;
            }

            //スクロールバーをサムネイルの右となりに配置
            InPageScrollBar.Top = pbThumbnail.Top - 20;
            InPageScrollBar.Left = pbThumbnail.Right + 5;
            InPageScrollBar.Height = pbThumbnail.Height + 40;

            //シークトラックバーをサムネイルの下に配置
            SeekTrackBar.Top = pbThumbnail.Bottom + 5;
            SeekTrackBar.Left = pbThumbnail.Left;
            SeekTrackBar.Width = pbThumbnail.Width;

            //時間をシークトラックの下に
            MovieTimeLabel.Top = SeekTrackBar.Bottom;
            var center = (SeekTrackBar.Left + SeekTrackBar.Right)/2;
            MovieTimeLabel.Left = center - (MovieTimeLabel.Width) / 2;

            //ページをシークトラックバーと同じ場所に
            PageNumberLabel.Left = center - PageNumberLabel.Width /2;
            PageNumberLabel.Top = SeekTrackBar.Top;

        }



        private void MenuListUpdate()
        {
            var listMenu = リストLToolStripMenuItem;
            listMenu.DropDownItems.Clear();
            foreach (var fileViewParam in model.FileList)
            {
                ToolStripMenuItem fileMenu = new(fileViewParam.FileName)
                {
                    Tag = fileViewParam
                };
                ;
                fileMenu.Click += FileMenu_Click;
                listMenu.DropDownItems.Add(fileMenu);

            }
        }
        private void MenuListSlectedIndexUpdate()
        {
            var listMenu = リストLToolStripMenuItem;
            int i = 0;
            foreach (ToolStripMenuItem fileMenu in listMenu.DropDownItems)
            {
                if (i == model.SelectedIndex && !model.MultiSelected)
                {
                    fileMenu.Checked = true;
                }
                else
                {
                    fileMenu.Checked = false;
                }
                i++;

            }
        }

        private void FileMenu_Click(object? sender, EventArgs e)

        {
            if (sender is not ToolStripMenuItem FileMenu) return;
            if (FileMenu.Tag is not FileViewParam FileViewParam) return;
            model.SelectFileViewParam(FileViewParam);
        }

        private void 次へToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddFilesAndSelect();
            }
            catch (OperationCanceledException)
            {
                //no operation
            }

        }

        private void リストの表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void リストの非表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 元の表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RotateAction_Click(RotateFlipType.RotateNoneFlipNone);

        }

        private void 右へ90回転ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateAction_Click(RotateFlipType.Rotate90FlipNone);
        }

        private void 左へ90回転ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateAction_Click(RotateFlipType.Rotate270FlipNone);
        }

        private void 回転ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateAction_Click(RotateFlipType.Rotate180FlipNone);
        }

        private void 最初のページToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirstPageOfPDFAction();
        }

        private void 次へToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NextPageOfPDFAction();
        }

        private void 前のページToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviousPageOfPDFAction();
        }

        private void 最後のページToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LastPageOfPDFAction();
        }

        private void ページ指定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageNumberAction();
        }

        void PageNumberAction()
        {
            if (Document == null)
            {
                return;
            }
            int max = Document.PageCount;

            var index = Convert.ToInt32(Document.PageVirtualIndex) + 1;
            ShowPageNumberForm(max, index);
        }

        private void ShowPageNumberForm(int max, int index)
        {
            Debug.Assert(Document != null);
            FormDispacher.ShowPageNumberForm(
                number =>
                {
                    Document.SetPage(number);
                    UpdateViewIfChecked();
                }

                , max, index);
        }

        private void PageNumberLabel_Click(object sender, EventArgs e)
        {
            PageNumberAction();
        }

        private void ウィンドウ幅に合わせるToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FitToWindowWidthAction();
        }

        private void 全体を表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWholeAction();
        }

        private void 拡大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomInAction();
        }

        private void 縮小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomOutAction();
        }

        private void 最初に移動ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToFirstAction();
        }

        private void 再生開始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseAction();
        }

        private void 再生停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseAction();
        }

        private void 早送りToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastForwardAction();
        }

        private void 巻き戻しToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastReverseAction();
        }

        private void FilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged_ReasonIsMenu)
            {
                return;
            }
            model.MultiSelected = FilesList.SelectedItems.Count > 1;

            model.SelectedIndex = FilesList.SelectedIndex;

        }
        bool SelectedIndexChanged_ReasonIsMenu = false;

        private void 表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayButtonAction();
        }

        private void 表示終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EndOfDisplayAction();
        }

        private void 背景表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundDisplayAction();
        }

        private void ウインドウサイズToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void スリムToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilesList.Visible = false;
            Width = 350;
            ControlRelocation();
            ControlEnable();
        }

        private void 標準ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilesList.Visible = true;
            Width = 1180;
            ControlRelocation();
            ControlEnable();
        }

        private void BackgroundDisplayOfSmallButton_Click(object sender, EventArgs e)
        {
            BackgroundDisplayAction();
        }

        private void EndOfDisplayOfSmallButton_Click(object sender, EventArgs e)
        {
            EndOfDisplayAction();
        }

        private void DisplayOfSmallButton_Click(object sender, EventArgs e)
        {
            DisplayButtonAction();
        }

        private void 操作中に自動表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoDisplayCheckBox.Checked = !AutoDisplayCheckBox.Checked;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

}
