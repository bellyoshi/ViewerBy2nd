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
            components=new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperation));
            GroupBox2=new GroupBox();
            btnDisp=new Button();
            btnUnSelectUpdate=new Button();
            btnUnDisp=new Button();
            chkUpdate=new CheckBox();
            lblMovieTime=new Label();
            btnAllSelect=new Button();
            btnPDFLast=new Button();
            btnWhole=new Button();
            lblPageDisp=new Label();
            btnPreviousHalf=new Button();
            btnNextHalf=new Button();
            btnPDFNext=new Button();
            btnPDFBack=new Button();
            btnPDFFirst=new Button();
            GotoFirst=new Button();
            btnStop=new Button();
            btnFastReverse=new Button();
            btnFastForward=new Button();
            btnStart=new Button();
            Label2=new Label();
            VScrollBar1=new VScrollBar();
            btnSetWindow=new Button();
            btnRotate90=new Button();
            trackBarSeek=new TrackBar();
            btnRotate0=new Button();
            OpenFileDialog1=new OpenFileDialog();
            SeekTimer=new System.Windows.Forms.Timer(components);
            BackgroundWorker1=new System.ComponentModel.BackgroundWorker();
            btnRotate270=new Button();
            btnRotate180=new Button();
            Label6=new Label();
            btnFileAdd=new Button();
            lstFiles=new ListBox();
            txtPDFFileName=new TextBox();
            pbThumbnail=new PictureBox();
            btnUnSelect=new Button();
            btnDelete=new Button();
            pnlMovie=new Panel();
            pnlDispOption=new Panel();
            btnZoomDown=new Button();
            btnZoomUp=new Button();
            pnlPage=new Panel();
            thumbnailMoviePlayer=new WinFormsControlLibrary.VideoPlayer();
            menuStrip1=new MenuStrip();
            リストToolStripMenuItem=new ToolStripMenuItem();
            表示ToolStripMenuItem=new ToolStripMenuItem();
            非表示ToolStripMenuItem=new ToolStripMenuItem();
            設定ToolStripMenuItem=new ToolStripMenuItem();
            ディスプレイと背景色ToolStripMenuItem=new ToolStripMenuItem();
            ヘルプToolStripMenuItem=new ToolStripMenuItem();
            このアプリについてToolStripMenuItem=new ToolStripMenuItem();
            panel2=new Panel();
            ThumnailMovoToPanel=new Panel();
            ListPanel=new Panel();
            thumbnailDefaultPanel=new Panel();
            GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbThumbnail).BeginInit();
            pnlMovie.SuspendLayout();
            pnlDispOption.SuspendLayout();
            pnlPage.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ListPanel.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(btnDisp);
            GroupBox2.Controls.Add(btnUnSelectUpdate);
            GroupBox2.Controls.Add(btnUnDisp);
            GroupBox2.Controls.Add(chkUpdate);
            GroupBox2.Location=new Point(329, 573);
            GroupBox2.Margin=new Padding(3, 4, 3, 4);
            GroupBox2.Name="GroupBox2";
            GroupBox2.Padding=new Padding(3, 4, 3, 4);
            GroupBox2.Size=new Size(529, 123);
            GroupBox2.TabIndex=96;
            GroupBox2.TabStop=false;
            GroupBox2.Text="セカンドモニター操作";
            // 
            // btnDisp
            // 
            btnDisp.Location=new Point(9, 38);
            btnDisp.Name="btnDisp";
            btnDisp.Size=new Size(97, 50);
            btnDisp.TabIndex=20;
            btnDisp.Text="表示";
            btnDisp.UseVisualStyleBackColor=true;
            btnDisp.Click+=btnDisp_Click;
            // 
            // btnUnSelectUpdate
            // 
            btnUnSelectUpdate.Location=new Point(209, 41);
            btnUnSelectUpdate.Name="btnUnSelectUpdate";
            btnUnSelectUpdate.Size=new Size(115, 50);
            btnUnSelectUpdate.TabIndex=20;
            btnUnSelectUpdate.Text="背景表示";
            btnUnSelectUpdate.UseVisualStyleBackColor=true;
            btnUnSelectUpdate.Click+=btnUnSelectUpdate_Click;
            // 
            // btnUnDisp
            // 
            btnUnDisp.Location=new Point(112, 40);
            btnUnDisp.Name="btnUnDisp";
            btnUnDisp.Size=new Size(91, 50);
            btnUnDisp.TabIndex=20;
            btnUnDisp.Text="表示終了";
            btnUnDisp.UseVisualStyleBackColor=true;
            btnUnDisp.Click+=btnUnDisp_Click;
            // 
            // chkUpdate
            // 
            chkUpdate.AutoSize=true;
            chkUpdate.FlatStyle=FlatStyle.System;
            chkUpdate.Location=new Point(343, 61);
            chkUpdate.Name="chkUpdate";
            chkUpdate.Size=new Size(157, 25);
            chkUpdate.TabIndex=25;
            chkUpdate.Text="操作中に自動表示";
            chkUpdate.UseVisualStyleBackColor=true;
            chkUpdate.CheckedChanged+=chkUpdate_CheckedChanged;
            // 
            // lblMovieTime
            // 
            lblMovieTime.AutoSize=true;
            lblMovieTime.Location=new Point(571, 493);
            lblMovieTime.Name="lblMovieTime";
            lblMovieTime.Size=new Size(71, 20);
            lblMovieTime.TabIndex=95;
            lblMovieTime.Text="-- time --";
            // 
            // btnAllSelect
            // 
            btnAllSelect.Location=new Point(9, 580);
            btnAllSelect.Name="btnAllSelect";
            btnAllSelect.Size=new Size(88, 40);
            btnAllSelect.TabIndex=94;
            btnAllSelect.Text="全選択";
            btnAllSelect.UseVisualStyleBackColor=true;
            btnAllSelect.Click+=btnAllSelect_Click;
            // 
            // btnPDFLast
            // 
            btnPDFLast.Location=new Point(197, 3);
            btnPDFLast.Name="btnPDFLast";
            btnPDFLast.Size=new Size(61, 45);
            btnPDFLast.TabIndex=93;
            btnPDFLast.Text="最後へ";
            btnPDFLast.UseVisualStyleBackColor=true;
            btnPDFLast.Click+=btnLast_Click;
            // 
            // btnWhole
            // 
            btnWhole.Location=new Point(164, 122);
            btnWhole.Name="btnWhole";
            btnWhole.Size=new Size(91, 45);
            btnWhole.TabIndex=92;
            btnWhole.Text="全体を表示";
            btnWhole.UseVisualStyleBackColor=true;
            btnWhole.Click+=btnWhole_Click;
            // 
            // lblPageDisp
            // 
            lblPageDisp.Location=new Point(476, 460);
            lblPageDisp.Name="lblPageDisp";
            lblPageDisp.Size=new Size(267, 20);
            lblPageDisp.TabIndex=91;
            lblPageDisp.Text="- page -";
            // 
            // btnPreviousHalf
            // 
            btnPreviousHalf.Location=new Point(14, 52);
            btnPreviousHalf.Name="btnPreviousHalf";
            btnPreviousHalf.Size=new Size(120, 45);
            btnPreviousHalf.TabIndex=89;
            btnPreviousHalf.Text="0.5ページ前へ";
            btnPreviousHalf.UseVisualStyleBackColor=true;
            btnPreviousHalf.Click+=btnPreviousHalf_Click;
            // 
            // btnNextHalf
            // 
            btnNextHalf.Location=new Point(140, 52);
            btnNextHalf.Name="btnNextHalf";
            btnNextHalf.Size=new Size(120, 45);
            btnNextHalf.TabIndex=90;
            btnNextHalf.Text="0.5ページ先へ";
            btnNextHalf.UseVisualStyleBackColor=true;
            btnNextHalf.Click+=btnNextHalf_Click;
            // 
            // btnPDFNext
            // 
            btnPDFNext.Location=new Point(141, 3);
            btnPDFNext.Name="btnPDFNext";
            btnPDFNext.Size=new Size(50, 45);
            btnPDFNext.TabIndex=86;
            btnPDFNext.Text="次へ";
            btnPDFNext.UseVisualStyleBackColor=true;
            btnPDFNext.Click+=btnNext_Click;
            // 
            // btnPDFBack
            // 
            btnPDFBack.Location=new Point(85, 3);
            btnPDFBack.Name="btnPDFBack";
            btnPDFBack.Size=new Size(50, 45);
            btnPDFBack.TabIndex=87;
            btnPDFBack.Text="前へ";
            btnPDFBack.UseVisualStyleBackColor=true;
            btnPDFBack.Click+=btnBack_Click;
            // 
            // btnPDFFirst
            // 
            btnPDFFirst.Location=new Point(12, 3);
            btnPDFFirst.Name="btnPDFFirst";
            btnPDFFirst.Size=new Size(67, 45);
            btnPDFFirst.TabIndex=88;
            btnPDFFirst.Text="最初へ";
            btnPDFFirst.UseVisualStyleBackColor=true;
            btnPDFFirst.Click+=btnFirst_Click;
            // 
            // GotoFirst
            // 
            GotoFirst.Location=new Point(6, 19);
            GotoFirst.Name="GotoFirst";
            GotoFirst.Size=new Size(51, 67);
            GotoFirst.TabIndex=80;
            GotoFirst.Text="先頭";
            GotoFirst.UseVisualStyleBackColor=true;
            GotoFirst.Click+=GotoFirst_Click;
            // 
            // btnStop
            // 
            btnStop.Location=new Point(230, 19);
            btnStop.Name="btnStop";
            btnStop.Size=new Size(51, 67);
            btnStop.TabIndex=81;
            btnStop.Text="||";
            btnStop.UseVisualStyleBackColor=true;
            btnStop.Click+=btnPause_Click;
            // 
            // btnFastReverse
            // 
            btnFastReverse.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnFastReverse.Location=new Point(58, 19);
            btnFastReverse.Name="btnFastReverse";
            btnFastReverse.Size=new Size(51, 67);
            btnFastReverse.TabIndex=82;
            btnFastReverse.Text="◀";
            btnFastReverse.UseVisualStyleBackColor=true;
            btnFastReverse.Click+=btnFastReverse_Click;
            // 
            // btnFastForward
            // 
            btnFastForward.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnFastForward.Location=new Point(168, 19);
            btnFastForward.Name="btnFastForward";
            btnFastForward.Size=new Size(57, 67);
            btnFastForward.TabIndex=83;
            btnFastForward.Text="▶▶";
            btnFastForward.UseVisualStyleBackColor=true;
            btnFastForward.Click+=btnFastForward_Click;
            // 
            // btnStart
            // 
            btnStart.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location=new Point(112, 19);
            btnStart.Name="btnStart";
            btnStart.Size=new Size(51, 67);
            btnStart.TabIndex=84;
            btnStart.Text="▶";
            btnStart.UseVisualStyleBackColor=true;
            btnStart.Click+=btnStart_Click;
            // 
            // Label2
            // 
            Label2.AutoSize=true;
            Label2.Location=new Point(508, 41);
            Label2.Name="Label2";
            Label2.Size=new Size(90, 20);
            Label2.TabIndex=79;
            Label2.Text="表示プレビュー";
            // 
            // VScrollBar1
            // 
            VScrollBar1.Location=new Point(841, 41);
            VScrollBar1.Name="VScrollBar1";
            VScrollBar1.Size=new Size(23, 400);
            VScrollBar1.TabIndex=78;
            VScrollBar1.Scroll+=VScrollBar1_Scroll;
            // 
            // btnSetWindow
            // 
            btnSetWindow.Location=new Point(2, 122);
            btnSetWindow.Name="btnSetWindow";
            btnSetWindow.Size=new Size(156, 45);
            btnSetWindow.TabIndex=76;
            btnSetWindow.Text="ウィンドウ幅に合わせる";
            btnSetWindow.UseVisualStyleBackColor=true;
            btnSetWindow.Click+=btnSetWindow_Click;
            // 
            // btnRotate90
            // 
            btnRotate90.Location=new Point(149, 36);
            btnRotate90.Name="btnRotate90";
            btnRotate90.Size=new Size(70, 50);
            btnRotate90.TabIndex=72;
            btnRotate90.Text="右90度";
            btnRotate90.UseVisualStyleBackColor=true;
            btnRotate90.Click+=btnRotate90_Click;
            // 
            // trackBarSeek
            // 
            trackBarSeek.Location=new Point(447, 460);
            trackBarSeek.Name="trackBarSeek";
            trackBarSeek.Size=new Size(317, 56);
            trackBarSeek.TabIndex=85;
            trackBarSeek.Scroll+=trackBarSeek_Scroll;
            trackBarSeek.MouseDown+=trackBarSeek_MouseDown;
            // 
            // btnRotate0
            // 
            btnRotate0.Location=new Point(83, 0);
            btnRotate0.Name="btnRotate0";
            btnRotate0.Size=new Size(60, 50);
            btnRotate0.TabIndex=73;
            btnRotate0.Text="０度";
            btnRotate0.UseVisualStyleBackColor=true;
            btnRotate0.Click+=btnRotate0_Click;
            // 
            // OpenFileDialog1
            // 
            OpenFileDialog1.FileName="OpenFileDialog1";
            // 
            // SeekTimer
            // 
            SeekTimer.Tick+=SeekTimer_Tick;
            // 
            // btnRotate270
            // 
            btnRotate270.Location=new Point(7, 36);
            btnRotate270.Name="btnRotate270";
            btnRotate270.Size=new Size(70, 50);
            btnRotate270.TabIndex=74;
            btnRotate270.Text="左90度";
            btnRotate270.UseVisualStyleBackColor=true;
            btnRotate270.Click+=btnRotate270_Click;
            // 
            // btnRotate180
            // 
            btnRotate180.Location=new Point(83, 66);
            btnRotate180.Name="btnRotate180";
            btnRotate180.Size=new Size(60, 50);
            btnRotate180.TabIndex=75;
            btnRotate180.Text="180度回転";
            btnRotate180.UseVisualStyleBackColor=true;
            btnRotate180.Click+=btnRotate180_Click;
            // 
            // Label6
            // 
            Label6.AutoSize=true;
            Label6.Location=new Point(11, 13);
            Label6.Name="Label6";
            Label6.Size=new Size(81, 20);
            Label6.TabIndex=71;
            Label6.Text="ファイル情報";
            // 
            // btnFileAdd
            // 
            btnFileAdd.Location=new Point(196, 578);
            btnFileAdd.Name="btnFileAdd";
            btnFileAdd.Size=new Size(115, 40);
            btnFileAdd.TabIndex=70;
            btnFileAdd.Text="ファイルを追加";
            btnFileAdd.UseVisualStyleBackColor=true;
            btnFileAdd.Click+=btnFileAdd_Click;
            // 
            // lstFiles
            // 
            lstFiles.AllowDrop=true;
            lstFiles.FormattingEnabled=true;
            lstFiles.ItemHeight=20;
            lstFiles.Location=new Point(9, 6);
            lstFiles.Margin=new Padding(30);
            lstFiles.Name="lstFiles";
            lstFiles.SelectionMode=SelectionMode.MultiExtended;
            lstFiles.Size=new Size(296, 564);
            lstFiles.TabIndex=67;
            lstFiles.Click+=lstFiles_Click;
            lstFiles.SelectedValueChanged+=lstFiles_SelectedValueChanged;
            lstFiles.DragDrop+=lstFiles_DragDrop;
            lstFiles.DragEnter+=lstFiles_DragEnter;
            // 
            // txtPDFFileName
            // 
            txtPDFFileName.Location=new Point(91, 6);
            txtPDFFileName.Name="txtPDFFileName";
            txtPDFFileName.ReadOnly=true;
            txtPDFFileName.Size=new Size(655, 27);
            txtPDFFileName.TabIndex=65;
            // 
            // pbThumbnail
            // 
            pbThumbnail.BackColor=Color.Red;
            pbThumbnail.Location=new Point(277, 144);
            pbThumbnail.Name="pbThumbnail";
            pbThumbnail.Size=new Size(40, 46);
            pbThumbnail.TabIndex=77;
            pbThumbnail.TabStop=false;
            // 
            // btnUnSelect
            // 
            btnUnSelect.Location=new Point(103, 580);
            btnUnSelect.Name="btnUnSelect";
            btnUnSelect.Size=new Size(91, 40);
            btnUnSelect.TabIndex=68;
            btnUnSelect.Text="選択解除";
            btnUnSelect.UseVisualStyleBackColor=true;
            btnUnSelect.Click+=btnUnSelect_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location=new Point(9, 626);
            btnDelete.Name="btnDelete";
            btnDelete.Size=new Size(88, 40);
            btnDelete.TabIndex=69;
            btnDelete.Text="削除";
            btnDelete.UseVisualStyleBackColor=true;
            btnDelete.Click+=btnDelete_Click;
            // 
            // pnlMovie
            // 
            pnlMovie.Controls.Add(GotoFirst);
            pnlMovie.Controls.Add(btnStop);
            pnlMovie.Controls.Add(btnFastReverse);
            pnlMovie.Controls.Add(btnFastForward);
            pnlMovie.Controls.Add(btnStart);
            pnlMovie.Location=new Point(10, 37);
            pnlMovie.Margin=new Padding(3, 4, 3, 4);
            pnlMovie.Name="pnlMovie";
            pnlMovie.Size=new Size(289, 100);
            pnlMovie.TabIndex=98;
            // 
            // pnlDispOption
            // 
            pnlDispOption.Controls.Add(btnZoomDown);
            pnlDispOption.Controls.Add(btnWhole);
            pnlDispOption.Controls.Add(btnZoomUp);
            pnlDispOption.Controls.Add(btnSetWindow);
            pnlDispOption.Controls.Add(btnRotate90);
            pnlDispOption.Controls.Add(btnRotate0);
            pnlDispOption.Controls.Add(btnRotate270);
            pnlDispOption.Controls.Add(btnRotate180);
            pnlDispOption.Location=new Point(4, 45);
            pnlDispOption.Margin=new Padding(3, 4, 3, 4);
            pnlDispOption.Name="pnlDispOption";
            pnlDispOption.Size=new Size(267, 224);
            pnlDispOption.TabIndex=99;
            // 
            // btnZoomDown
            // 
            btnZoomDown.Location=new Point(126, 173);
            btnZoomDown.Margin=new Padding(3, 4, 3, 4);
            btnZoomDown.Name="btnZoomDown";
            btnZoomDown.Size=new Size(110, 45);
            btnZoomDown.TabIndex=93;
            btnZoomDown.Text="縮小";
            btnZoomDown.UseVisualStyleBackColor=true;
            btnZoomDown.Click+=btnZoomDown_Click;
            // 
            // btnZoomUp
            // 
            btnZoomUp.Location=new Point(3, 173);
            btnZoomUp.Name="btnZoomUp";
            btnZoomUp.Size=new Size(110, 45);
            btnZoomUp.TabIndex=76;
            btnZoomUp.Text="拡大";
            btnZoomUp.UseVisualStyleBackColor=true;
            btnZoomUp.Click+=btnZoomUp_Click;
            // 
            // pnlPage
            // 
            pnlPage.Controls.Add(btnPDFLast);
            pnlPage.Controls.Add(btnPreviousHalf);
            pnlPage.Controls.Add(btnNextHalf);
            pnlPage.Controls.Add(btnPDFNext);
            pnlPage.Controls.Add(btnPDFBack);
            pnlPage.Controls.Add(btnPDFFirst);
            pnlPage.Location=new Point(10, 271);
            pnlPage.Margin=new Padding(3, 4, 3, 4);
            pnlPage.Name="pnlPage";
            pnlPage.Size=new Size(274, 104);
            pnlPage.TabIndex=100;
            // 
            // thumbnailMoviePlayer
            // 
            thumbnailMoviePlayer.BackColor=Color.FromArgb(192, 0, 0);
            thumbnailMoviePlayer.Location=new Point(277, 205);
            thumbnailMoviePlayer.Margin=new Padding(3, 4, 3, 4);
            thumbnailMoviePlayer.Name="thumbnailMoviePlayer";
            thumbnailMoviePlayer.Rate=-1F;
            thumbnailMoviePlayer.Size=new Size(40, 58);
            thumbnailMoviePlayer.TabIndex=97;
            thumbnailMoviePlayer.Time=0L;
            thumbnailMoviePlayer.Volume=-1;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize=new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { リストToolStripMenuItem, 設定ToolStripMenuItem, ヘルプToolStripMenuItem });
            menuStrip1.Location=new Point(0, 0);
            menuStrip1.Name="menuStrip1";
            menuStrip1.Size=new Size(1215, 28);
            menuStrip1.TabIndex=101;
            menuStrip1.Text="menuStrip1";
            // 
            // リストToolStripMenuItem
            // 
            リストToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 表示ToolStripMenuItem, 非表示ToolStripMenuItem });
            リストToolStripMenuItem.Name="リストToolStripMenuItem";
            リストToolStripMenuItem.Size=new Size(55, 24);
            リストToolStripMenuItem.Text="リスト";
            // 
            // 表示ToolStripMenuItem
            // 
            表示ToolStripMenuItem.Name="表示ToolStripMenuItem";
            表示ToolStripMenuItem.Size=new Size(137, 26);
            表示ToolStripMenuItem.Text="表示";
            表示ToolStripMenuItem.Click+=表示ToolStripMenuItem_Click;
            // 
            // 非表示ToolStripMenuItem
            // 
            非表示ToolStripMenuItem.Name="非表示ToolStripMenuItem";
            非表示ToolStripMenuItem.Size=new Size(137, 26);
            非表示ToolStripMenuItem.Text="非表示";
            非表示ToolStripMenuItem.Click+=非表示ToolStripMenuItem_Click;
            // 
            // 設定ToolStripMenuItem
            // 
            設定ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ディスプレイと背景色ToolStripMenuItem });
            設定ToolStripMenuItem.Name="設定ToolStripMenuItem";
            設定ToolStripMenuItem.Size=new Size(53, 24);
            設定ToolStripMenuItem.Text="設定";
            // 
            // ディスプレイと背景色ToolStripMenuItem
            // 
            ディスプレイと背景色ToolStripMenuItem.Name="ディスプレイと背景色ToolStripMenuItem";
            ディスプレイと背景色ToolStripMenuItem.Size=new Size(212, 26);
            ディスプレイと背景色ToolStripMenuItem.Text="ディスプレイと背景色";
            ディスプレイと背景色ToolStripMenuItem.Click+=ディスプレイと背景色ToolStripMenuItem_Click;
            // 
            // ヘルプToolStripMenuItem
            // 
            ヘルプToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { このアプリについてToolStripMenuItem });
            ヘルプToolStripMenuItem.Name="ヘルプToolStripMenuItem";
            ヘルプToolStripMenuItem.Size=new Size(58, 24);
            ヘルプToolStripMenuItem.Text="ヘルプ";
            // 
            // このアプリについてToolStripMenuItem
            // 
            このアプリについてToolStripMenuItem.Name="このアプリについてToolStripMenuItem";
            このアプリについてToolStripMenuItem.Size=new Size(194, 26);
            このアプリについてToolStripMenuItem.Text="このアプリについて";
            このアプリについてToolStripMenuItem.Click+=このアプリについてToolStripMenuItem_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pbThumbnail);
            panel2.Controls.Add(thumbnailDefaultPanel);
            panel2.Controls.Add(ThumnailMovoToPanel);
            panel2.Controls.Add(lblPageDisp);
            panel2.Controls.Add(lblMovieTime);
            panel2.Controls.Add(pnlPage);
            panel2.Controls.Add(Label6);
            panel2.Controls.Add(pnlDispOption);
            panel2.Controls.Add(txtPDFFileName);
            panel2.Controls.Add(VScrollBar1);
            panel2.Controls.Add(Label2);
            panel2.Controls.Add(pnlMovie);
            panel2.Controls.Add(thumbnailMoviePlayer);
            panel2.Controls.Add(trackBarSeek);
            panel2.Location=new Point(320, 30);
            panel2.Name="panel2";
            panel2.Size=new Size(876, 523);
            panel2.TabIndex=103;
            // 
            // ThumnailMovoToPanel
            // 
            ThumnailMovoToPanel.BackColor=Color.FromArgb(0, 0, 192);
            ThumnailMovoToPanel.Location=new Point(16, 388);
            ThumnailMovoToPanel.Name="ThumnailMovoToPanel";
            ThumnailMovoToPanel.Size=new Size(250, 125);
            ThumnailMovoToPanel.TabIndex=101;
            ThumnailMovoToPanel.Visible=false;
            // 
            // ListPanel
            // 
            ListPanel.Controls.Add(btnUnSelect);
            ListPanel.Controls.Add(lstFiles);
            ListPanel.Controls.Add(btnAllSelect);
            ListPanel.Controls.Add(btnFileAdd);
            ListPanel.Controls.Add(btnDelete);
            ListPanel.Location=new Point(6, 31);
            ListPanel.Name="ListPanel";
            ListPanel.Size=new Size(318, 682);
            ListPanel.TabIndex=95;
            // 
            // thumbnailDefaultPanel
            // 
            thumbnailDefaultPanel.BackColor=Color.FromArgb(0, 0, 192);
            thumbnailDefaultPanel.Location=new Point(311, 64);
            thumbnailDefaultPanel.Name="thumbnailDefaultPanel";
            thumbnailDefaultPanel.Size=new Size(527, 393);
            thumbnailDefaultPanel.TabIndex=102;
            thumbnailDefaultPanel.Visible=false;
            // 
            // frmOperation
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1215, 713);
            Controls.Add(ListPanel);
            Controls.Add(panel2);
            Controls.Add(GroupBox2);
            Controls.Add(menuStrip1);
            Icon=(Icon)resources.GetObject("$this.Icon");
            MainMenuStrip=menuStrip1;
            Margin=new Padding(3, 4, 3, 4);
            Name="frmOperation";
            Text="ViewerBy2nd Monitor";
            FormClosed+=frmOperation_FormClosed;
            Load+=frmOperation_Load;
            Resize+=frmOperation_Resize;
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbThumbnail).EndInit();
            pnlMovie.ResumeLayout(false);
            pnlDispOption.ResumeLayout(false);
            pnlPage.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ListPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        internal System.Windows.Forms.CheckBox chkUpdate;
        internal System.Windows.Forms.Timer SeekTimer;
        internal System.ComponentModel.BackgroundWorker BackgroundWorker1;
        internal System.Windows.Forms.Button btnRotate270;
        internal System.Windows.Forms.Button btnRotate180;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnFileAdd;
        internal System.Windows.Forms.ListBox lstFiles;
        internal System.Windows.Forms.TextBox txtPDFFileName;
        internal System.Windows.Forms.PictureBox pbThumbnail;
        internal System.Windows.Forms.Button btnUnSelect;
        internal System.Windows.Forms.Button btnDelete;
        internal ViewerBy2nd.WinFormsControlLibrary.VideoPlayer thumbnailMoviePlayer;
        private System.Windows.Forms.Panel pnlMovie;
        private System.Windows.Forms.Panel pnlDispOption;
        private System.Windows.Forms.Panel pnlPage;
        internal System.Windows.Forms.Button btnZoomUp;
        private System.Windows.Forms.Button btnZoomDown;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private ToolStripMenuItem ディスプレイと背景色ToolStripMenuItem;
        private ToolStripMenuItem ヘルプToolStripMenuItem;
        private ToolStripMenuItem このアプリについてToolStripMenuItem;
        private Panel panel2;
        private Panel ListPanel;
        private ToolStripMenuItem リストToolStripMenuItem;
        private ToolStripMenuItem 表示ToolStripMenuItem;
        private ToolStripMenuItem 非表示ToolStripMenuItem;
        private Panel ThumnailMovoToPanel;
        private Panel thumbnailDefaultPanel;
    }
}

