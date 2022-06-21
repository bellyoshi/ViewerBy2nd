using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ViewerBy2ndLib;

namespace ViewerBy2nd
{

    public partial class frmOperation : Form
    {
        public frmOperation()
        {
            InitializeComponent();
        }

        private void ControlEnable()
        {
            CtlPdf1ControlEnabled();
            CtlMovie1ControlEnabled();
            CtlImage1ControlEnabled();
            ListControlEnabled();
            CtlSecondEnabled();
        }

        public void ListControlEnabled()
        {
            btnDelete.Enabled = 0 < lstFiles.SelectedItems.Count;
            btnUnSelect.Enabled = 0 < lstFiles.SelectedItems.Count;
        }

        public bool isMovie
        {
            get
            {
                return (document != null) && document.FileType.IsMovieExt;
            }
        }

        private void CtlSecondEnabled()
        {
            btnDisp.Enabled = !chkUpdate.Checked || !_dispacher.ViewerVisible || isMovie ;
            btnDisp.Text = isMovie ? "再生" : "表示";
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
            VScrollBar1.Enabled = (fileViewParam != null) && fileViewParam.IsWidthEqualWin;
        }

        public void CtlMovie1ControlEnabled()
        {
            pnlMovie.Visible = isMovie;
            GotoFirst.Enabled = isMovie;
            btnFastReverse.Enabled = isMovie;
            btnStart.Enabled = isMovie;
            btnStop.Enabled = isMovie;
            btnFastForward.Enabled = isMovie;
            chkUpdate.Enabled = !isMovie;
            thumbnailPlayer.Visible = isMovie;
            trackBarSeek.Enabled = isMovie;
            trackBarSeek.Visible = isMovie;
            if (!isMovie)
                thumbnailPlayer.Stop();
            lblMovieTime.Visible = isMovie;
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
            _dispacher.RegistrationfrmOperation(this);
            screenDetect();
            AppSettingLoad();
            ControlEnable();
            SeekTimer.Interval = 100;
            SeekTimer.Start();

            this.MouseWheel +=  new MouseEventHandler(this.frmOperation_MouseWheel);
        }

        private void AppSettingLoad()
        {
            if (cmbDisplay.Items.Count > Properties.Settings.Default.cmbDisplaySelectedIndex)
                cmbDisplay.SelectedIndex = Properties.Settings.Default.cmbDisplaySelectedIndex;
            else
                cmbDisplay.SelectedIndex = 0;

            lblFormColor.BackColor = Properties.Settings.Default.formColor;
            chkUpdate.Checked = Properties.Settings.Default.chkUpdate;

            SetBackColor();
            try
            {
                List<FileViewParam> fvinfos = new List<FileViewParam>();

                // XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<FileViewParam>));
                // 読み込むファイルを開く
                var filename = "lstPDFFiles.xml";
                if (!System.IO.File.Exists(filename))
                    return;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filename, new System.Text.UTF8Encoding(false)))
                {
                    // XMLファイルから読み込み、逆シリアル化する
                    fvinfos = (List<FileViewParam>)serializer.Deserialize(sr);
                }
                foreach (var info in fvinfos)
                    lstFiles.Items.Add(info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AppSettingSave()
        {
            Properties.Settings.Default.cmbDisplaySelectedIndex = cmbDisplay.SelectedIndex;
            Properties.Settings.Default.formColor = lblFormColor.BackColor;
            Properties.Settings.Default.chkUpdate = chkUpdate.Checked;
            Properties.Settings.Default.Save();

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

        private void screenDetect()
        {
            // デバイス名が表示されるようにする
            this.cmbDisplay.DisplayMember = "DeviceName";
            this.cmbDisplay.DataSource = Screen.AllScreens;
        }

        private void btnColorChange_Click(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            this.lblFormColor.BackColor = ColorDialog1.Color;
            Properties.Settings.Default.formColor = ColorDialog1.Color;
            SetBackColor();

        }

        private void frmOperation_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppSettingSave();
        }

        private void cmbDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisplay.SelectedIndex < 0)
                return;
            if (cmbDisplay.SelectedItem == null)
                return;
            // 'フォームを表示するディスプレイのScreenを取得する
            Screen s = (Screen)this.cmbDisplay.SelectedItem;
            // 'フォームの開始位置をディスプレイの左上座標に設定する
            _dispacher.ViewScreen = s;

            SetThumnailSize();
        }

        private void SetThumnailSize()
        {
            pbThumbnail.Height = getThumnailWidth(pbThumbnail.Width);
            thumbnailPlayer.Height = getThumnailWidth(thumbnailPlayer.Width);
        }
        private int getThumnailWidth(int thumWidth)
        {
            var viewerSize = _dispacher.ViewScreen.Bounds.Size;
            return thumWidth * viewerSize.Height / viewerSize.Width;
        }

        private FormDispacher _dispacher = FormDispacher.GetInstance();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null)
                return;

            var list =lstFiles.SelectedItems.Cast<FileViewParam>().ToList();
            foreach (var i in list)
                lstFiles.Items.Remove(i);
            if (list.Contains(DispFileViewParam))
            {
                UpdateView();
                ControlEnable();
            }
        }

        private void lstFiles_Click(object sender, EventArgs e)
        {
            if (fileViewParam == null)
                return;
            var path = fileViewParam.FileName;
            if (!System.IO.File.Exists(path))
            {
                var ret = MessageBox.Show("ファイルが見つかりません。リストから削除しますか？", "ファイルがありません", MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                    lstFiles.Items.Remove(fileViewParam);
                return;
            }

            UpdateViewIfChecked();

            ControlEnable();
        }

        private void btnDisp_Click(object sender, EventArgs e)
        {
            if(isMovie)
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
            var vlc = _dispacher.ShowMovie();
            int starttime = Convert.ToInt32(thumbnailPlayer.Time / (double)1000);
            var op = new string[] { $"start-time={starttime}" };
            vlc.Volume = 100;
            vlc.Play(fileViewParam.FileName, op);
            player = vlc;
            player.Rate = 1.0f;
            DispFileViewParam = fileViewParam;
        }

        private VideoPlayer player;

        private void player_Pause()
        {
            player?.Pause();
        }

        private void player_Play()
        {
            if (!thumbnailPlayer.IsPlaying)
            {
                thumbnailPlayer.Play();
            }
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
                items.Add(new FileViewParam(filename, _dispacher.ViewScreen.Bounds.Size));
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            lstFiles.SelectedItem = null;
            pbThumbnail.Image = null;
            ControlEnable();
        }

        private void btnUnDisp_Click(object sender, EventArgs e)
        {
            _dispacher.CloseViewers();
            DispFileViewParam = null;
            thumbnailPlayer .Pause();
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
            DispFileViewParam = null;
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
        {
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
            var items = lstFiles.Items;
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (var f in fileName)
                items.Add(new FileViewParam(f, _dispacher.ViewScreen.Bounds.Size));
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateViewIfChecked();
            ControlEnable();
        }

        private void btnRotate180_Click(object sender, EventArgs e)
        {
            document.Rotate(RotateFlipType.Rotate180FlipNone);
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void btnRotate90_Click(object sender, EventArgs e)
        {
            document.Rotate(RotateFlipType.Rotate90FlipNone);
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void btnRotate0_Click(object sender, EventArgs e)
        {
            document.Rotate(RotateFlipType.RotateNoneFlipNone);
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void btnRotate270_Click(object sender, EventArgs e)
        {
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
            _dispacher.ShowImage(pbThumbnail.Image);
            DispFileViewParam = fileViewParam;
        }

        private FileViewParam fileViewParam
        {
            get
            {
                if (lstFiles.SelectedItems.Count != 1)
                    return null/* TODO Change to default(_) if this is not a reference type */;
                if (lstFiles.SelectedItem == null)
                    return null/* TODO Change to default(_) if this is not a reference type */;
                var p = (FileViewParam)lstFiles.SelectedItem;
                p.Bound = _dispacher.ViewScreen.Bounds.Size;
                return p;
            }
        }

        private Document document
        {
            get
            {
                if (System.IO.File.Exists(fileViewParam?.FileName))
                    return fileViewParam?.document;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        public void SetBackColor()
        {
            _dispacher.BackColor = Properties.Settings.Default.formColor;
            pbThumbnail.BackColor = Properties.Settings.Default.formColor;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            scrollToFirst();
            document.FirstPage();

            UpdateViewIfChecked();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!document.CanNextPage()) return;
            scrollToFirst();
            document.NextPage();

            UpdateViewIfChecked();
        }

        private void scrollToFirst()
        {
            if (fileViewParam.IsWidthEqualWin)
            {
                VScrollBar1.Value = 0;
                fileViewParam.scrollBarValue = 0;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            document.PrePage();
            UpdateViewIfChecked();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            document.LastPage();
            UpdateViewIfChecked();
        }

        private void SetPreview()
        {
            txtPDFFileName.Text = "" + fileViewParam?.FileName;
            pbThumbnail.Image = document?.Image;
            pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            if (document?.FileType?.IsPDFExt??false)
            {
                lblPageDisp.Visible = true;
                lblPageDisp.Text = $"ページ{document.page + 1}/{document.PageCount}";
            }
            else
                lblPageDisp.Visible = false;
            pbThumbnail.Visible = (document == null) || (!document.FileType.IsMovieExt);
            thumbnailPlayer.Visible = (document != null) && document.FileType.IsMovieExt;

            if (document != null && document.FileType.IsMovieExt)
            {
                var op = new string[] { "no-audio" };
                thumbnailPlayer.LoadFile(fileViewParam.FileName, op);
                if(player != null)
                {
                    player.LoadFile(fileViewParam.FileName, op);
                }
            }
        }

        private void btnNextHalf_Click(object sender, EventArgs e)
        {
            document.NextHalfPage();
            UpdateViewIfChecked();
        }

        private void btnPreviousHalf_Click(object sender, EventArgs e)
        {
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
            if (fileViewParam == null)
                return;
            fileViewParam.scrollBarValue = VScrollBar1.Value;
            document.DispSetWindow();
            UpdateViewIfChecked();
        }

        private void VScrollBar1Init()
        {
            if(document.OriginalImageHeight == 0)
            {
                return;
            }
            VScrollBar1.Minimum = 0;
            var clientWidth = document.Image.Height;
            VScrollBar1.Maximum = document.OriginalImageHeight;
            VScrollBar1.Value = fileViewParam.scrollBarValue;

            VScrollBar1.LargeChange = clientWidth;
        }

        private void btnSetWindow_Click(object sender, EventArgs e)
        {
            fileViewParam.scrollBarValue = 0;
            fileViewParam.IsWidthEqualWin = true;
            ControlEnable();
            VScrollBar1Init();
            UpdateViewIfChecked();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            thumbnailPlayer.Rate = 1;
            btnFastForward.Text = "▶▶";
            thumbnailPlayer.Play();
            if (_dispacher.ViewerVisible)
            {
                player_Play();
            }

        }

        private void btnPause_Click(object sender, EventArgs e)
        {

            thumbnailPlayer.Pause();
            player_Pause();
            

        }

        private void btnFastForward_Click(object sender, EventArgs e)
        {
            btnFastForward.Text = "▶▶▶";
            if (thumbnailPlayer.Rate == 2.0) { 
                thumbnailPlayer.Rate = 4.0f;
                if (player != null)
                    player.Rate = 4.0f;
            }
            else
            {
                thumbnailPlayer.Rate = 2.0f;
                if(player != null)
                    player.Rate = 2.0f;
            }
             
        }

        private void btnFastReverse_Click(object sender, EventArgs e)
        {
            if (thumbnailPlayer.Time < 15000)
                thumbnailPlayer.Time = 0;
            else
                thumbnailPlayer.Time = thumbnailPlayer.Time - 15000;
            if(player != null)
            {
                player.Time = thumbnailPlayer.Time;
            }
        }

        private void GotoFirst_Click(object sender, EventArgs e)
        {
            thumbnailPlayer.Time = 0;
            if(player != null)
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
            try
            {
                if (trackBarSeek_Scrolled)
                {
                    var seek_time = Convert.ToInt32(trackBarSeek.Value * 100);
                    if (thumbnailPlayer.RequiredReload)
                    {
                        var op = new string[] { $"start-time={seek_time / 1000}" };
                        thumbnailPlayer.Play(fileViewParam.FileName, op);
                    }
                    thumbnailPlayer.Time = seek_time;
                    if (player != null)
                        player.Time = thumbnailPlayer.Time;
                    trackBarSeek_Scrolled = false;
                }
                else
                {
                    trackBarSeek.Maximum = (int)thumbnailPlayer.Length / 100;
                    trackBarSeek.Value = (int)thumbnailPlayer.Time / 100;

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SyncThumbnail()
        {
            if (player == null) return;
            if (!player.IsPlaying) return;
            if (player.Time < 1000) return;
            if(Math.Abs( thumbnailPlayer.Time - player.Time) > 500)
            {
                thumbnailPlayer.Time = player.Time;
            }

        }

        private void lbl_Update()
        {
            TimeSpan ts = new TimeSpan(thumbnailPlayer.Time * 10000);
            lblMovieTime.Text = ts.ToString(@"hh\:mm\:ss");
        }

        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            trackBarSeek_Scrolled = true;
        }

        private void btnWhole_Click(object sender, EventArgs e)
        {
            fileViewParam.IsWidthEqualWin = false;
            ControlEnable();
            UpdateViewIfChecked();
        }

        private void lstFiles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null)
            {
                if(player != null)
                {
                    player.Stop();
                }
            }
            ControlEnable();
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

        public void frmOperation_MouseWheel(object sender, MouseEventArgs e)
        {
            var numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / (double)25;
            if (!VScrollBar1.Enabled)
            {
                if (numberOfTextLinesToMove>0)
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
            requireVScrollUpdate = true ;
        }

        private FileViewParam DispFileViewParam;

    }

}
