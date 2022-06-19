namespace ViewerBy2nd
{
    partial class frmOperation
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperation));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDisp = new System.Windows.Forms.Button();
            this.btnUnSelectUpdate = new System.Windows.Forms.Button();
            this.btnUnDisp = new System.Windows.Forms.Button();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.lblMovieTime = new System.Windows.Forms.Label();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.btnPDFLast = new System.Windows.Forms.Button();
            this.btnWhole = new System.Windows.Forms.Button();
            this.lblPageDisp = new System.Windows.Forms.Label();
            this.btnPreviousHalf = new System.Windows.Forms.Button();
            this.btnNextHalf = new System.Windows.Forms.Button();
            this.btnPDFNext = new System.Windows.Forms.Button();
            this.btnPDFBack = new System.Windows.Forms.Button();
            this.btnPDFFirst = new System.Windows.Forms.Button();
            this.GotoFirst = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnFastReverse = new System.Windows.Forms.Button();
            this.btnFastForward = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.VScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.btnSetWindow = new System.Windows.Forms.Button();
            this.btnRotate90 = new System.Windows.Forms.Button();
            this.trackBarSeek = new System.Windows.Forms.TrackBar();
            this.btnRotate0 = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblFormColor = new System.Windows.Forms.Label();
            this.btnColorChange = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbDisplay = new System.Windows.Forms.ComboBox();
            this.SeekTimer = new System.Windows.Forms.Timer(this.components);
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnRotate270 = new System.Windows.Forms.Button();
            this.btnRotate180 = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnFileAdd = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.txtPDFFileName = new System.Windows.Forms.TextBox();
            this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.pbThumbnail = new System.Windows.Forms.PictureBox();
            this.btnUnSelect = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.thumbnailPlayer = new ViewerBy2ndLib.VideoPlayer();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnDisp);
            this.GroupBox2.Controls.Add(this.btnUnSelectUpdate);
            this.GroupBox2.Controls.Add(this.btnUnDisp);
            this.GroupBox2.Controls.Add(this.chkUpdate);
            this.GroupBox2.Location = new System.Drawing.Point(367, 550);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(794, 92);
            this.GroupBox2.TabIndex = 96;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "セカンドモニター操作";
            // 
            // btnDisp
            // 
            this.btnDisp.Location = new System.Drawing.Point(9, 30);
            this.btnDisp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDisp.Name = "btnDisp";
            this.btnDisp.Size = new System.Drawing.Size(97, 53);
            this.btnDisp.TabIndex = 20;
            this.btnDisp.Text = "表示";
            this.btnDisp.UseVisualStyleBackColor = true;
            this.btnDisp.Click += new System.EventHandler(this.btnDisp_Click);
            // 
            // btnUnSelectUpdate
            // 
            this.btnUnSelectUpdate.Location = new System.Drawing.Point(209, 31);
            this.btnUnSelectUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnSelectUpdate.Name = "btnUnSelectUpdate";
            this.btnUnSelectUpdate.Size = new System.Drawing.Size(115, 49);
            this.btnUnSelectUpdate.TabIndex = 20;
            this.btnUnSelectUpdate.Text = "背景表示";
            this.btnUnSelectUpdate.UseVisualStyleBackColor = true;
            this.btnUnSelectUpdate.Click += new System.EventHandler(this.btnUnSelectUpdate_Click);
            // 
            // btnUnDisp
            // 
            this.btnUnDisp.Location = new System.Drawing.Point(112, 30);
            this.btnUnDisp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnDisp.Name = "btnUnDisp";
            this.btnUnDisp.Size = new System.Drawing.Size(91, 51);
            this.btnUnDisp.TabIndex = 20;
            this.btnUnDisp.Text = "表示終了";
            this.btnUnDisp.UseVisualStyleBackColor = true;
            this.btnUnDisp.Click += new System.EventHandler(this.btnUnDisp_Click);
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUpdate.Location = new System.Drawing.Point(343, 46);
            this.chkUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(155, 20);
            this.chkUpdate.TabIndex = 25;
            this.chkUpdate.Text = "操作中に自動表示";
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.chkUpdate_CheckedChanged);
            // 
            // lblMovieTime
            // 
            this.lblMovieTime.AutoSize = true;
            this.lblMovieTime.Location = new System.Drawing.Point(890, 504);
            this.lblMovieTime.Name = "lblMovieTime";
            this.lblMovieTime.Size = new System.Drawing.Size(76, 15);
            this.lblMovieTime.TabIndex = 95;
            this.lblMovieTime.Text = "-- time --";
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Location = new System.Drawing.Point(19, 557);
            this.btnAllSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(88, 40);
            this.btnAllSelect.TabIndex = 94;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = true;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnPDFLast
            // 
            this.btnPDFLast.Location = new System.Drawing.Point(546, 175);
            this.btnPDFLast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPDFLast.Name = "btnPDFLast";
            this.btnPDFLast.Size = new System.Drawing.Size(67, 41);
            this.btnPDFLast.TabIndex = 93;
            this.btnPDFLast.Text = "最後へ";
            this.btnPDFLast.UseVisualStyleBackColor = true;
            this.btnPDFLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnWhole
            // 
            this.btnWhole.Location = new System.Drawing.Point(514, 378);
            this.btnWhole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWhole.Name = "btnWhole";
            this.btnWhole.Size = new System.Drawing.Size(140, 31);
            this.btnWhole.TabIndex = 92;
            this.btnWhole.Text = "全体を表示";
            this.btnWhole.UseVisualStyleBackColor = true;
            this.btnWhole.Click += new System.EventHandler(this.btnWhole_Click);
            // 
            // lblPageDisp
            // 
            this.lblPageDisp.Location = new System.Drawing.Point(837, 462);
            this.lblPageDisp.Name = "lblPageDisp";
            this.lblPageDisp.Size = new System.Drawing.Size(267, 15);
            this.lblPageDisp.TabIndex = 91;
            this.lblPageDisp.Text = "- page -";
            // 
            // btnPreviousHalf
            // 
            this.btnPreviousHalf.Location = new System.Drawing.Point(357, 219);
            this.btnPreviousHalf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreviousHalf.Name = "btnPreviousHalf";
            this.btnPreviousHalf.Size = new System.Drawing.Size(124, 39);
            this.btnPreviousHalf.TabIndex = 89;
            this.btnPreviousHalf.Text = "0.5ページ前へ";
            this.btnPreviousHalf.UseVisualStyleBackColor = true;
            this.btnPreviousHalf.Click += new System.EventHandler(this.btnPreviousHalf_Click);
            // 
            // btnNextHalf
            // 
            this.btnNextHalf.Location = new System.Drawing.Point(486, 219);
            this.btnNextHalf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNextHalf.Name = "btnNextHalf";
            this.btnNextHalf.Size = new System.Drawing.Size(123, 39);
            this.btnNextHalf.TabIndex = 90;
            this.btnNextHalf.Text = "0.5ページ先へ";
            this.btnNextHalf.UseVisualStyleBackColor = true;
            this.btnNextHalf.Click += new System.EventHandler(this.btnNextHalf_Click);
            // 
            // btnPDFNext
            // 
            this.btnPDFNext.Location = new System.Drawing.Point(488, 175);
            this.btnPDFNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPDFNext.Name = "btnPDFNext";
            this.btnPDFNext.Size = new System.Drawing.Size(53, 41);
            this.btnPDFNext.TabIndex = 86;
            this.btnPDFNext.Text = "次へ";
            this.btnPDFNext.UseVisualStyleBackColor = true;
            this.btnPDFNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPDFBack
            // 
            this.btnPDFBack.Location = new System.Drawing.Point(425, 175);
            this.btnPDFBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPDFBack.Name = "btnPDFBack";
            this.btnPDFBack.Size = new System.Drawing.Size(56, 41);
            this.btnPDFBack.TabIndex = 87;
            this.btnPDFBack.Text = "前へ";
            this.btnPDFBack.UseVisualStyleBackColor = true;
            this.btnPDFBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPDFFirst
            // 
            this.btnPDFFirst.Location = new System.Drawing.Point(354, 175);
            this.btnPDFFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPDFFirst.Name = "btnPDFFirst";
            this.btnPDFFirst.Size = new System.Drawing.Size(65, 41);
            this.btnPDFFirst.TabIndex = 88;
            this.btnPDFFirst.Text = "最初へ";
            this.btnPDFFirst.UseVisualStyleBackColor = true;
            this.btnPDFFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // GotoFirst
            // 
            this.GotoFirst.Location = new System.Drawing.Point(338, 424);
            this.GotoFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GotoFirst.Name = "GotoFirst";
            this.GotoFirst.Size = new System.Drawing.Size(51, 50);
            this.GotoFirst.TabIndex = 80;
            this.GotoFirst.Text = "先頭";
            this.GotoFirst.UseVisualStyleBackColor = true;
            this.GotoFirst.Click += new System.EventHandler(this.GotoFirst_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(603, 424);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(51, 50);
            this.btnStop.TabIndex = 81;
            this.btnStop.Text = "||";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnFastReverse
            // 
            this.btnFastReverse.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFastReverse.Location = new System.Drawing.Point(400, 424);
            this.btnFastReverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFastReverse.Name = "btnFastReverse";
            this.btnFastReverse.Size = new System.Drawing.Size(51, 50);
            this.btnFastReverse.TabIndex = 82;
            this.btnFastReverse.Text = "◀";
            this.btnFastReverse.UseVisualStyleBackColor = true;
            this.btnFastReverse.Click += new System.EventHandler(this.btnFastReverse_Click);
            // 
            // btnFastForward
            // 
            this.btnFastForward.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFastForward.Location = new System.Drawing.Point(514, 424);
            this.btnFastForward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFastForward.Name = "btnFastForward";
            this.btnFastForward.Size = new System.Drawing.Size(74, 50);
            this.btnFastForward.TabIndex = 83;
            this.btnFastForward.Text = "▶▶";
            this.btnFastForward.UseVisualStyleBackColor = true;
            this.btnFastForward.Click += new System.EventHandler(this.btnFastForward_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStart.Location = new System.Drawing.Point(456, 424);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(51, 50);
            this.btnStart.TabIndex = 84;
            this.btnStart.Text = "▶";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(848, 135);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(92, 15);
            this.Label2.TabIndex = 79;
            this.Label2.Text = "表示プレビュー";
            // 
            // VScrollBar1
            // 
            this.VScrollBar1.Location = new System.Drawing.Point(1175, 152);
            this.VScrollBar1.Name = "VScrollBar1";
            this.VScrollBar1.Size = new System.Drawing.Size(23, 300);
            this.VScrollBar1.TabIndex = 78;
            this.VScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBar1_Scroll);
            // 
            // btnSetWindow
            // 
            this.btnSetWindow.Location = new System.Drawing.Point(340, 375);
            this.btnSetWindow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetWindow.Name = "btnSetWindow";
            this.btnSetWindow.Size = new System.Drawing.Size(167, 36);
            this.btnSetWindow.TabIndex = 76;
            this.btnSetWindow.Text = "ウィンドウ幅に合わせる";
            this.btnSetWindow.UseVisualStyleBackColor = true;
            this.btnSetWindow.Click += new System.EventHandler(this.btnSetWindow_Click);
            // 
            // btnRotate90
            // 
            this.btnRotate90.Location = new System.Drawing.Point(531, 297);
            this.btnRotate90.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRotate90.Name = "btnRotate90";
            this.btnRotate90.Size = new System.Drawing.Size(80, 51);
            this.btnRotate90.TabIndex = 72;
            this.btnRotate90.Text = "右90度";
            this.btnRotate90.UseVisualStyleBackColor = true;
            this.btnRotate90.Click += new System.EventHandler(this.btnRotate90_Click);
            // 
            // trackBarSeek
            // 
            this.trackBarSeek.Location = new System.Drawing.Point(766, 458);
            this.trackBarSeek.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarSeek.Name = "trackBarSeek";
            this.trackBarSeek.Size = new System.Drawing.Size(317, 56);
            this.trackBarSeek.TabIndex = 85;
            this.trackBarSeek.Scroll += new System.EventHandler(this.trackBarSeek_Scroll);
            this.trackBarSeek.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSeek_MouseDown);
            // 
            // btnRotate0
            // 
            this.btnRotate0.Location = new System.Drawing.Point(435, 262);
            this.btnRotate0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRotate0.Name = "btnRotate0";
            this.btnRotate0.Size = new System.Drawing.Size(91, 51);
            this.btnRotate0.TabIndex = 73;
            this.btnRotate0.Text = "０度";
            this.btnRotate0.UseVisualStyleBackColor = true;
            this.btnRotate0.Click += new System.EventHandler(this.btnRotate0_Click);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // lblFormColor
            // 
            this.lblFormColor.AutoSize = true;
            this.lblFormColor.Location = new System.Drawing.Point(567, 25);
            this.lblFormColor.Name = "lblFormColor";
            this.lblFormColor.Size = new System.Drawing.Size(27, 15);
            this.lblFormColor.TabIndex = 9;
            this.lblFormColor.Text = "　　";
            // 
            // btnColorChange
            // 
            this.btnColorChange.Location = new System.Drawing.Point(445, 18);
            this.btnColorChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnColorChange.Name = "btnColorChange";
            this.btnColorChange.Size = new System.Drawing.Size(93, 31);
            this.btnColorChange.TabIndex = 8;
            this.btnColorChange.Text = "背景色変更";
            this.btnColorChange.UseVisualStyleBackColor = true;
            this.btnColorChange.Click += new System.EventHandler(this.btnColorChange_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(37, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(125, 15);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "表示するディスプレイ";
            // 
            // cmbDisplay
            // 
            this.cmbDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisplay.FormattingEnabled = true;
            this.cmbDisplay.Location = new System.Drawing.Point(197, 19);
            this.cmbDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDisplay.Name = "cmbDisplay";
            this.cmbDisplay.Size = new System.Drawing.Size(163, 23);
            this.cmbDisplay.TabIndex = 6;
            this.cmbDisplay.SelectedIndexChanged += new System.EventHandler(this.cmbDisplay_SelectedIndexChanged);
            // 
            // SeekTimer
            // 
            this.SeekTimer.Tick += new System.EventHandler(this.SeekTimer_Tick);
            // 
            // btnRotate270
            // 
            this.btnRotate270.Location = new System.Drawing.Point(351, 297);
            this.btnRotate270.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRotate270.Name = "btnRotate270";
            this.btnRotate270.Size = new System.Drawing.Size(79, 51);
            this.btnRotate270.TabIndex = 74;
            this.btnRotate270.Text = "左90度";
            this.btnRotate270.UseVisualStyleBackColor = true;
            this.btnRotate270.Click += new System.EventHandler(this.btnRotate270_Click);
            // 
            // btnRotate180
            // 
            this.btnRotate180.Location = new System.Drawing.Point(435, 319);
            this.btnRotate180.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRotate180.Name = "btnRotate180";
            this.btnRotate180.Size = new System.Drawing.Size(91, 51);
            this.btnRotate180.TabIndex = 75;
            this.btnRotate180.Text = "180度回転";
            this.btnRotate180.UseVisualStyleBackColor = true;
            this.btnRotate180.Click += new System.EventHandler(this.btnRotate180_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(352, 92);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(79, 15);
            this.Label6.TabIndex = 71;
            this.Label6.Text = "ファイル情報";
            // 
            // btnFileAdd
            // 
            this.btnFileAdd.Location = new System.Drawing.Point(208, 555);
            this.btnFileAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFileAdd.Name = "btnFileAdd";
            this.btnFileAdd.Size = new System.Drawing.Size(125, 41);
            this.btnFileAdd.TabIndex = 70;
            this.btnFileAdd.Text = "ファイルを追加";
            this.btnFileAdd.UseVisualStyleBackColor = true;
            this.btnFileAdd.Click += new System.EventHandler(this.btnFileAdd_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 15;
            this.lstFiles.Location = new System.Drawing.Point(19, 118);
            this.lstFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiles.Size = new System.Drawing.Size(308, 424);
            this.lstFiles.TabIndex = 67;
            this.lstFiles.Click += new System.EventHandler(this.lstFiles_Click);
            this.lstFiles.SelectedValueChanged += new System.EventHandler(this.lstFiles_SelectedValueChanged);
            this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragDrop);
            this.lstFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragEnter);
            // 
            // txtPDFFileName
            // 
            this.txtPDFFileName.Location = new System.Drawing.Point(347, 109);
            this.txtPDFFileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPDFFileName.Name = "txtPDFFileName";
            this.txtPDFFileName.ReadOnly = true;
            this.txtPDFFileName.Size = new System.Drawing.Size(655, 22);
            this.txtPDFFileName.TabIndex = 65;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblFormColor);
            this.GroupBox1.Controls.Add(this.btnColorChange);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cmbDisplay);
            this.GroupBox1.Location = new System.Drawing.Point(1, 12);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupBox1.Size = new System.Drawing.Size(1037, 63);
            this.GroupBox1.TabIndex = 66;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "設定";
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.Location = new System.Drawing.Point(666, 152);
            this.pbThumbnail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.Size = new System.Drawing.Size(495, 300);
            this.pbThumbnail.TabIndex = 77;
            this.pbThumbnail.TabStop = false;
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Location = new System.Drawing.Point(112, 557);
            this.btnUnSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(91, 40);
            this.btnUnSelect.TabIndex = 68;
            this.btnUnSelect.Text = "選択解除";
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(19, 602);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 40);
            this.btnDelete.TabIndex = 69;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // thumbnailPlayer
            // 
            this.thumbnailPlayer.Location = new System.Drawing.Point(666, 153);
            this.thumbnailPlayer.Name = "thumbnailPlayer";
            this.thumbnailPlayer.Rate = -1F;
            this.thumbnailPlayer.Size = new System.Drawing.Size(495, 298);
            this.thumbnailPlayer.TabIndex = 97;
            this.thumbnailPlayer.Time = ((long)(-1));
            this.thumbnailPlayer.Volume = -1;
            // 
            // frmOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 668);
            this.Controls.Add(this.thumbnailPlayer);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.lblMovieTime);
            this.Controls.Add(this.btnAllSelect);
            this.Controls.Add(this.btnPDFLast);
            this.Controls.Add(this.btnWhole);
            this.Controls.Add(this.lblPageDisp);
            this.Controls.Add(this.btnPreviousHalf);
            this.Controls.Add(this.btnNextHalf);
            this.Controls.Add(this.btnPDFNext);
            this.Controls.Add(this.btnPDFBack);
            this.Controls.Add(this.btnPDFFirst);
            this.Controls.Add(this.GotoFirst);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnFastReverse);
            this.Controls.Add(this.btnFastForward);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.VScrollBar1);
            this.Controls.Add(this.btnSetWindow);
            this.Controls.Add(this.btnRotate90);
            this.Controls.Add(this.trackBarSeek);
            this.Controls.Add(this.btnRotate0);
            this.Controls.Add(this.btnRotate270);
            this.Controls.Add(this.btnRotate180);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.btnFileAdd);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.txtPDFFileName);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.pbThumbnail);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.btnDelete);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOperation";
            this.Text = "ViewerBy2nd Monitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOperation_FormClosed);
            this.Load += new System.EventHandler(this.frmOperation_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnDisp;
        internal System.Windows.Forms.Button btnUnSelectUpdate;
        internal System.Windows.Forms.Button btnUnDisp;
        internal System.Windows.Forms.Label lblMovieTime;
        internal System.Windows.Forms.Button btnAllSelect;
        internal System.Windows.Forms.Button btnPDFLast;
        internal System.Windows.Forms.Button btnWhole;
        internal System.Windows.Forms.Label lblPageDisp;
        internal System.Windows.Forms.Button btnPreviousHalf;
        internal System.Windows.Forms.Button btnNextHalf;
        internal System.Windows.Forms.Button btnPDFNext;
        internal System.Windows.Forms.Button btnPDFBack;
        internal System.Windows.Forms.Button btnPDFFirst;
        internal System.Windows.Forms.Button GotoFirst;
        internal System.Windows.Forms.Button btnStop;
        internal System.Windows.Forms.Button btnFastReverse;
        internal System.Windows.Forms.Button btnFastForward;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.VScrollBar VScrollBar1;
        internal System.Windows.Forms.Button btnSetWindow;
        internal System.Windows.Forms.Button btnRotate90;
        internal System.Windows.Forms.TrackBar trackBarSeek;
        internal System.Windows.Forms.Button btnRotate0;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.Label lblFormColor;
        internal System.Windows.Forms.Button btnColorChange;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbDisplay;
        internal System.Windows.Forms.CheckBox chkUpdate;
        internal System.Windows.Forms.Timer SeekTimer;
        internal System.ComponentModel.BackgroundWorker BackgroundWorker1;
        internal System.Windows.Forms.Button btnRotate270;
        internal System.Windows.Forms.Button btnRotate180;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnFileAdd;
        internal System.Windows.Forms.ListBox lstFiles;
        internal System.Windows.Forms.TextBox txtPDFFileName;
        internal System.Windows.Forms.ColorDialog ColorDialog1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.PictureBox pbThumbnail;
        internal System.Windows.Forms.Button btnUnSelect;
        internal System.Windows.Forms.Button btnDelete;
        internal ViewerBy2ndLib.VideoPlayer thumbnailPlayer;
    }
}

