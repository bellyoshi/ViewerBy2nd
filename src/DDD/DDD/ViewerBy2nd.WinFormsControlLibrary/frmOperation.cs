global using ViewerBy2nd.Infrastructure;
using System.Data;
using System.Diagnostics;
using ViewerBy2nd.WinFormsControlLibrary;
using ViewerBy2ndLib;

namespace ViewerBy2nd
{

    public partial class frmOperation : Form
    {
        Settings Default => ConfigurationReader.Default;
        public frmOperation()
        {
            InitializeComponent();
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

            表示ToolStripMenuItem.Enabled = !lstFiles.Visible;
            非表示ToolStripMenuItem.Enabled = lstFiles.Visible;

        }

        public void ListControlEnabled()
        {
            btnDelete.Enabled = 0 < lstFiles.SelectedItems.Count;
            btnUnSelect.Enabled = 0 < lstFiles.SelectedItems.Count;
        }

        public bool IsMovie
            => (document != null) && document.FileType.IsMovieExt;



        private void CtlSecondEnabled()
        {
            btnDisp.Enabled = !chkUpdate.Checked || !Dispacher.ViewerVisible || IsMovie;
            btnDisp.Text = IsMovie ? "再生" : "表示";
        }

        public void CtlPdf1ControlEnabled()
        {

            var isPdf = (document != null) && document.FileType.IsPDFExt;
            btnPDFFirst.Enabled = isPdf;
            btnPDFBack.Enabled = isPdf;
            btnPDFNext.Enabled = isPdf;
            btnPDFLast.Enabled = isPdf;
            btnPreviousHalf.Enabled = isPdf;
            btnNextHalf.Enabled = isPdf;
            pnlPage.Visible = isPdf || document == null;

            bool canSetWin = (document != null) && (document.FileType.IsPDFExt || document.FileType.IsImageExt || document.FileType.IsSVGExt);
            btnSetWindow.Enabled = canSetWin;
            btnWhole.Enabled = canSetWin;
            btnZoomDown.Enabled = canSetWin;
            btnZoomUp.Enabled = canSetWin;
            VScrollBar1.Enabled = (PreviewFile != null) && PreviewFile.IsZoom;
        }

        public void CtlMovie1ControlEnabled()
        {
            pnlMovie.Visible = IsMovie;
            GotoFirst.Enabled = IsMovie;
            btnFastReverse.Enabled = IsMovie;
            btnStart.Enabled = IsMovie;
            btnStop.Enabled = IsMovie;
            btnFastForward.Enabled = IsMovie;
            chkUpdate.Enabled = !IsMovie;
            thumbnailMoviePlayer.Visible = IsMovie;
            trackBarSeek.Enabled = IsMovie;
            trackBarSeek.Visible = IsMovie;
            if (!IsMovie)
                thumbnailMoviePlayer.Stop();
            lblMovieTime.Visible = IsMovie;
        }

        public void CtlImage1ControlEnabled()
        {
            var IsPdfOrImage = (document != null) && (!document.FileType.IsMovieExt);

            btnRotate270.Enabled = IsPdfOrImage;
            btnRotate90.Enabled = IsPdfOrImage;
            btnRotate180.Enabled = IsPdfOrImage;
            btnRotate0.Enabled = IsPdfOrImage;
            pnlDispOption.Visible = IsPdfOrImage || document == null;
        }

        private void frmOperation_Load(object sender, EventArgs e)
        {
            Dispacher.RegistrationfrmOperation(this);

            AppSettingLoad();
            ControlRelocation();
            ControlEnable();
            SeekTimer.Interval = 100;
            SeekTimer.Start();

            this.MouseWheel +=  new MouseEventHandler(this.frmOperation_MouseWheel);
        }

        private void AppSettingLoad()
        {
            chkUpdate.Checked = Default.chkUpdate;

            NotifyBackColor();

            try
            {
                // XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<FileViewParam>));
                // 読み込むファイルを開く
                var filename = "lstPDFFiles.xml";
                if (!System.IO.File.Exists(filename))
                    return;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filename, new System.Text.UTF8Encoding(false)))
                {
                    // XMLファイルから読み込み、逆シリアル化する
                    var deserialize = serializer.Deserialize(sr);
                    if (deserialize != null)
                    {
                        List<FileViewParam> fvinfos = (List<FileViewParam>)deserialize;
                        foreach (var info in fvinfos)
                            lstFiles.Items.Add(info);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        private void frmOperation_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppSettingSave();
        }

        private void AppSettingSave()
        {
            Default.chkUpdate = chkUpdate.Checked;


            List<FileViewParam> fvinfos = new List<FileViewParam>();
            foreach (FileViewParam info in lstFiles.Items)
                fvinfos.Add(info);
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<FileViewParam>));
            // 書き込むファイルを開く（UTF-8 BOM無し）
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("lstPDFFiles.xml", false, new System.Text.UTF8Encoding(false)))
            {
                // シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, fvinfos);
            }
        }

        public void SetThumnailSize()
        {
            pbThumbnail.Height = getThumnailWidth(pbThumbnail.Width);
            thumbnailMoviePlayer.Height = getThumnailWidth(thumbnailMoviePlayer.Width);
        }
        private int getThumnailWidth(int thumWidth)
        {
            var viewerSize = ViewScreenRegister.GetInstance().Size;
            return thumWidth * viewerSize.Height / viewerSize.Width;
        }

        private FormDispacher Dispacher { get; } = FormDispacher.GetInstance();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null)
                return;

            var list = lstFiles.SelectedItems.Cast<FileViewParam>().ToList();
            foreach (var i in list)
                lstFiles.Items.Remove(i);

            if (DispFile != null && list.Contains(DispFile))
            {
                UpdateView();
                ControlEnable();
            }
        }

        private void lstFiles_Click(object sender, EventArgs e)
        {
            if (PreviewFile == null)
                return;
            var path = PreviewFile.FileName;
            if (!System.IO.File.Exists(path))
            {
                var ret = MessageBox.Show("ファイルが見つかりません。リストから削除しますか？", "ファイルがありません", MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                    lstFiles.Items.Remove(PreviewFile);
                return;
            }

            UpdateViewIfChecked();

            ControlEnable();
        }

        private void btnDisp_Click(object sender, EventArgs e)
        {
            if (IsMovie)
            {
                player_Play();
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

        private void player_Pause()
        {
            player?.Pause();
        }

        private void player_Play()
        {

            thumbnailMoviePlayer.Play();

            PlayMovie();
        }
        private void btnFileAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Multiselect = true;
            OpenFileDialog1.Filter = FileTypes.CreateFilter();
            OpenFileDialog1.FileName = txtPDFFileName.Text;
            var ret = OpenFileDialog1.ShowDialog();
            if (ret == DialogResult.Cancel)
                return;

            var items = lstFiles.Items;

            foreach (var filename in OpenFileDialog1.FileNames)
                items.Add(new FileViewParam(filename, ViewScreenRegister.GetInstance().Size));
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            lstFiles.SelectedItem = null;
            pbThumbnail.Image = null;
            ControlEnable();
        }

        private void btnUnDisp_Click(object sender, EventArgs e)
        {
            Dispacher.CloseViewers();
            DispFile = null;
            thumbnailMoviePlayer.Pause();
            player?.Pause();
            ControlEnable();
        }

        private void btnUnSelectUpdate_Click(object sender, EventArgs e)
        {
            lstFiles.SelectedItem = null;
            pbThumbnail.Image = null;
            SetPreview();
            UpdateView();
            ControlEnable();
            DispFile = null;
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
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

        private void lstFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null)
            {
                return;
            }
            var items = lstFiles.Items;
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (var f in fileName)
                items.Add(new FileViewParam(f, ViewScreenRegister.GetInstance().Size));
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateViewIfChecked();
            ControlEnable();
        }

        private void btnRotate180_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            document.Rotate(RotateFlipType.Rotate180FlipNone);
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void btnRotate90_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            document.Rotate(RotateFlipType.Rotate90FlipNone);
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void btnRotate0_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            document.Rotate(RotateFlipType.RotateNoneFlipNone);
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void btnRotate270_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            document.Rotate(RotateFlipType.Rotate270FlipNone);
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        public void UpdateViewIfChecked()
        {
            SetPreview();
            if (chkUpdate.Checked && !(document?.FileType?.IsMovieExt??false))
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
                if (lstFiles.SelectedItems.Count != 1)
                    return null;
                if (lstFiles.SelectedItem == null)
                    return null;
                var p = (FileViewParam)lstFiles.SelectedItem;
                p.BoundsSize = ViewScreenRegister.GetInstance().Size;
                return p;
            }
        }

        private FileViewParam? DispFile;

        private Document? document
        {
            get
            {
                if (System.IO.File.Exists(PreviewFile?.FileName))
                {
                    var doc = PreviewFile?.document;
                    if (doc != null)
                    {
                        return doc;
                    }
                }
                return null;
            }
        }



        private void btnFirst_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            scrollToFirst();
            document.FirstPage();

            UpdateViewIfChecked();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            if (!document.CanNextPage()) return;
            scrollToFirst();
            document.NextPage();

            UpdateViewIfChecked();
        }

        private void scrollToFirst()
        {
            Debug.Assert(PreviewFile != null);
            if (PreviewFile.IsZoom)
            {
                VScrollBar1.Value = 0;
                PreviewFile.scrollBarValue = 0;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            document.PrePage();
            UpdateViewIfChecked();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            document.LastPage();
            UpdateViewIfChecked();
        }

        private void SetPreview()
        {
            txtPDFFileName.Text = "" + PreviewFile?.FileName;

            if (document?.FileType?.IsPDFExt??false)
            {
                lblPageDisp.Visible = true;
                lblPageDisp.Text = $"ページ{document.PageVirtualIndex + 1}/{document.PageCount}";
            }
            else
                lblPageDisp.Visible = false;
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
                ImageDisposer.PrevieImage = document?.OutPutImage;
                pbThumbnail.Image = ImageDisposer.PrevieImage;
                pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnNextHalf_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            document.NextHalfPage();
            UpdateViewIfChecked();
        }

        private void btnPreviousHalf_Click(object sender, EventArgs e)
        {
            Debug.Assert(document != null);
            document.PreviousHalfPage();
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
            Debug.Assert(document != null);
            PreviewFile.scrollBarValue = VScrollBar1.Value;
            document.UpdateImage();
            UpdateViewIfChecked();
        }

        private void VScrollBar1Init()
        {
            Debug.Assert(PreviewFile != null);
            Debug.Assert(document != null);
            if (document.OriginalImageHeight == 0)
            {
                return;
            }
            VScrollBar1.Minimum = 0;
            var clientWidth = document?.OutPutImage?.Height??0;
            VScrollBar1.Maximum = document?.OriginalImageHeight??0;
            VScrollBar1.Value = PreviewFile.scrollBarValue;

            VScrollBar1.LargeChange = clientWidth;
        }

        private void btnSetWindow_Click(object sender, EventArgs e)
        {
            Debug.Assert(PreviewFile != null);
            Debug.Assert(document != null);
            PreviewFile.scrollBarValue = 0;
            PreviewFile.IsZoom = true;
            PreviewFile.ZoomHeight = document.GetZoomImageHeightMin();
            document.UpdateImage();
            ControlEnable();
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            thumbnailMoviePlayer.Rate = 1;
            btnFastForward.Text = "▶▶";
            thumbnailMoviePlayer.Play();
            if (Dispacher.ViewerVisible)
            {
                player_Play();
            }

        }

        private void btnPause_Click(object sender, EventArgs e)
        {

            thumbnailMoviePlayer.Pause();
            player_Pause();


        }

        private void btnFastForward_Click(object sender, EventArgs e)
        {
            btnFastForward.Text = "▶▶▶";
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

        private void btnFastReverse_Click(object sender, EventArgs e)
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

        private void GotoFirst_Click(object sender, EventArgs e)
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
            lbl_Update();
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
                var seek_time = Convert.ToInt32(trackBarSeek.Value * 100);
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
                trackBarSeek.Maximum = (int)thumbnailMoviePlayer.Length / 100;
                var value = (int)thumbnailMoviePlayer.Time / 100;
                if (0 <= value && value <= trackBarSeek.Maximum)
                {
                    trackBarSeek.Value = value;
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

        private void lbl_Update()
        {
            TimeSpan ts = new TimeSpan(thumbnailMoviePlayer.Time * 10000);
            lblMovieTime.Text = ts.ToString(@"hh\:mm\:ss");
        }

        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            trackBarSeek_Scrolled = true;
        }

        private void btnWhole_Click(object sender, EventArgs e)
        {
            Debug.Assert(PreviewFile != null);
            PreviewFile.IsZoom = false;
            document?.UpdateImage();
            ControlEnable();
            UpdateViewIfChecked();
        }

        private void lstFiles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null)
            {
                if (player != null)
                {
                    player.Stop();
                }
            }
            ControlEnable();
            if (!IsMovie)
                document?.UpdateImage();
            UpdateViewIfChecked();
            if (btnSetWindow.Enabled)
                VScrollBar1Init();
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= lstFiles.Items.Count - 1; i++)

                lstFiles.SetSelected(i, true);
        }

        private void trackBarSeek_MouseDown(object sender, MouseEventArgs e)
        {
            var TrackBar1 = trackBarSeek;
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
            Debug.Assert(document != null);
            var numberOfTextLinesToMove = delta * SystemInformation.MouseWheelScrollLines / (double)25;
            var maximum = VScrollBar1.Maximum - VScrollBar1.LargeChange + 1;
            int expect = -Convert.ToInt32(numberOfTextLinesToMove) + VScrollBar1.Value;
            if (expect < 0)
            {
                expect = 0;
                if (document.CanPrePage())
                {
                    expect = maximum;
                    document.PrePage();
                }
            }

            if (maximum < expect)
            {
                expect = maximum;
                if (document.CanNextPage())
                {
                    expect = 0;
                    document.NextPage();
                }
            }
            VScrollBar1.Value = expect;
            requireVScrollUpdate = true;
        }
        private void MouseWheelScrollPage(int delta)
        {
            if (document is null)
            {
                return;
            }

            if (delta>0)
            {
                if (document.CanPrePage())
                {
                    document.PrePage();
                    UpdateViewIfChecked();
                }
            }
            else
            {
                if (document.CanNextPage())
                {
                    document.NextPage();
                    UpdateViewIfChecked();
                }
            }
            return;

        }
        public void frmOperation_MouseWheel(object? sender, MouseEventArgs e)
        {

            if (!VScrollBar1.Enabled)
            {
                MouseWheelScrollPage(e.Delta);
            }
            else
            {
                MouseWheelScrollLine(e.Delta);
            }

        }

        private void btnZoomUp_Click(object sender, EventArgs e)
        {
            Debug.Assert(PreviewFile != null);
            document?.ZoomUp();
            PreviewFile.scrollBarValue = 0;
            document?.UpdateImage();
            ControlEnable();
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void btnZoomDown_Click(object sender, EventArgs e)
        {
            Debug.Assert(PreviewFile != null);
            document?.ZoomDown();
            PreviewFile.scrollBarValue = 0;
            document?.UpdateImage();
            ControlEnable();
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void このアプリについてToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmVersion();
            frm.ShowDialog();
        }

        private void ディスプレイと背景色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispacher.ShowSetting();
        }

        internal void NotifyBackColor()
        {


            pbThumbnail.BackColor = BackColorRegister.GetInstance().BackColor;

        }

        private void frmOperation_Resize(object sender, EventArgs e)
        {
            lstFiles.Visible = 600 < Width;
            ControlRelocation();
            ControlEnable();
        }

        private void 非表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstFiles.Visible = false;
            ControlRelocation();
            ControlEnable();


        }

        private void ControlRelocation()
        {



            if (lstFiles.Visible)
            {
                lstFiles.Width = 260;
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

        private void 表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstFiles.Visible = true;
            ControlRelocation();
            ControlEnable();
        }
    }

}
