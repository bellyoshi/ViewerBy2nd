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
        public OperationForm()
        {
            model = new();
            model.FileListChanged += Model_FileListChanged;
            model.SelectedIndexChanged += Model_SelectedIndexChanged;
            InitializeComponent();
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
            FilesList.SelectedIndex = model.SelectedIndex;
        }

        private void ControlEnable()
        {
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
        }

        public bool IsMovie
            => (Document != null) && Document.FileType.IsMovieExt;



        private void CtlSecondEnabled()
        {
            DisplayButton.Enabled = !AutoDisplayCheckBox.Checked || !Dispacher.ViewerVisible || IsMovie;
            DisplayButton.Text = IsMovie ? "再生" : "表示";
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
            thumbnailMoviePlayer.Visible = IsMovie;
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
            操作中に自動表示ToolStripMenuItem.Visible =false;//todo 操作中に自動表示ToolStripMenuItem機能追加
            Dispacher.RegistrationfrmOperation(this);

            AppSettingLoad();
            ControlRelocation();
            ControlEnable();
            SeekTimer.Interval = 100;
            SeekTimer.Start();

            this.MouseWheel +=  new MouseEventHandler(this.OperationForm_MouseWheel);
        }

        private void AppSettingLoad()
        {
            AutoDisplayCheckBox.Checked = Default.AutoUpdate;

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
            thumbnailMoviePlayer.Height = GetThumnailWidth(thumbnailMoviePlayer.Width);
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

            var list = FilesList.SelectedItems.Cast<FileViewParam>().ToList();
            model.DeleteFiles(list);
            //foreach (var i in list)
            //    FilesList.Items.Remove(i);

            // todo: if (DispFile != null && list.Contains(DispFile))
            //{
            //    UpdateView();
            //    ControlEnable();
            //}
            //MenuListUpdate();
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
            int starttime = Convert.ToInt32(thumbnailMoviePlayer.Time / (double)1000);
            var op = new string[] { $"start-time={starttime}" };
            vlc.Volume = 100;
            vlc.Play(PreviewFile.FileName, op);
            player = vlc;
            player.Rate = 1.0f;
            DispFile = PreviewFile;
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
            model.AddFiles(
                GetAddFiles().Select(param => param.FileName)
                );

            ;
            return;
            try
            {
                AddFiles();
            }
            catch (OperationCanceledException)
            {
                //no operation
            }

        }
        private void AddFilesAndSelect()
        {
            AddFiles();
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

        private void EndOfDisplayAction()
        {
            Dispacher.CloseViewers();
            DispFile = null;
            thumbnailMoviePlayer.Pause();
            player?.Pause();
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
            DispFile = null;
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
            DispFile = PreviewFile;
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

        private FileViewParam? DispFile;

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

            if (Document?.FileType?.IsPDFExt??false)
            {
                PageNumberLabel.Visible = true;
                PageNumberLabel.Text = $"ページ{Document.PageVirtualIndex + 1}/{Document.PageCount}";
            }
            else
                PageNumberLabel.Visible = false;
            pbThumbnail.Visible = !IsMovie;
            thumbnailMoviePlayer.Visible = IsMovie;

            if (IsMovie)
            {
                var op = new string[] { "no-audio" };
                string filename = PreviewFile?.FileName??string.Empty;
                thumbnailMoviePlayer.LoadFile(filename, op);
                player?.LoadFile(filename, op);

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
            InPageScrollBar.Value = PreviewFile.ScrollBarValue;

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

        private bool trackBarSeek_Scrolled = false;

        private void SeekTimer_Tick(object sender, EventArgs e)
        {

            Trackbar_Seek();
            MovieTimeLabelUpdate();
            ControlEnable();
            SyncThumbnail();
            VScrollUpdateSync();

        }

        private void Trackbar_Seek()
        {
            if (PreviewFile == null)
                return;

            if (trackBarSeek_Scrolled)
            {
                var seek_time = Convert.ToInt32(SeekTrackBar.Value * 100);
                if (thumbnailMoviePlayer.RequiredReload)
                {
                    var op = new string[] { $"start-time={seek_time / 1000}" };
                    thumbnailMoviePlayer.Play(PreviewFile.FileName, op);
                }
                thumbnailMoviePlayer.Time = seek_time;
                if (player != null)
                    player.Time = thumbnailMoviePlayer.Time;
                trackBarSeek_Scrolled = false;
            }
            else
            {
                SeekTrackBar.Maximum = (int)thumbnailMoviePlayer.Length / 100;
                var value = (int)thumbnailMoviePlayer.Time / 100;
                if (0 <= value && value <= SeekTrackBar.Maximum)
                {
                    SeekTrackBar.Value = value;
                }


            }

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

        private void SeekTrackBar_Scroll(object sender, EventArgs e)
        {
            trackBarSeek_Scrolled = true;
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

        private void SeekTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            var TrackBar1 = SeekTrackBar;
            if (e.Button != MouseButtons.Left || e.X < 0 || e.X > TrackBar1.Width || e.Y < 0 || e.Y > TrackBar1.Height)
                return;

            if (e.X < 8)
                TrackBar1.Value = TrackBar1.Minimum;
            else if (e.X > TrackBar1.Width - 8)
                TrackBar1.Value = TrackBar1.Maximum;
            else
            {
                double seekWidth = TrackBar1.Width - 16;
                double ticWidth = seekWidth / (TrackBar1.Maximum - TrackBar1.Minimum);
                TrackBar1.Value = System.Convert.ToInt32((e.X - 8) / ticWidth) + TrackBar1.Minimum;
            }
            trackBarSeek_Scrolled = true;
            Trackbar_Seek();
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
                panel2.Location = new Point(270, 30);
                SecondGroup.Location = new Point(288, 550);
                thumbnailMoviePlayer.Bounds = thumbnailDefaultPanel.Bounds;
                pbThumbnail.Bounds = thumbnailDefaultPanel.Bounds;
            }
            else
            {

                panel2.Location = new Point(0, 30);
                thumbnailMoviePlayer.Bounds = ThumnailMovoToPanel.Bounds;
                pbThumbnail.Bounds = ThumnailMovoToPanel.Bounds;
                SecondGroup.Location = new Point(0, 550);
            }
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
            //todo: 大きく表示という名前のメニューがよいかもしれない
            FilesList.Visible = false;
            ControlRelocation();
            ControlEnable();
        }

        private void 標準ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //todo: たてに細長く表示という名前のメニューが良いかもしれない
            FilesList.Visible = true;
            ControlRelocation();
            ControlEnable();
        }
    }

}
