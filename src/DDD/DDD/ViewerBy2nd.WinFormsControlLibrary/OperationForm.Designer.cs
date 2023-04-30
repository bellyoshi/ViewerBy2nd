namespace ViewerBy2nd
{
    partial class OperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationForm));
            DisplayButton=new Button();
            BackgroundDisplayButton=new Button();
            EndOfDisplayButton=new Button();
            AutoDisplayCheckBox=new CheckBox();
            MovieTimeLabel=new Label();
            AllFilesSelectButton=new Button();
            LastPageOfPDFButton=new Button();
            ShowWholeButton=new Button();
            lblPageDisp=new Label();
            PreviousHalfPageOfPDFButton=new Button();
            NextHalfPageOfPDFButton=new Button();
            NextPageOfPDFButton=new Button();
            PreviousPageOfPDFButton=new Button();
            FirstPageOfPDFButton=new Button();
            GotoFirstButton=new Button();
            PauseButton=new Button();
            FastReverseButton=new Button();
            FastForwardButton=new Button();
            StartButton=new Button();
            Label2=new Label();
            VScrollBar1=new VScrollBar();
            FitToWindowWidthButton=new Button();
            Rotate90Button=new Button();
            SeekTrackBar=new TrackBar();
            Rotate0Button=new Button();
            OpenFileDialog1=new OpenFileDialog();
            SeekTimer=new System.Windows.Forms.Timer(components);
            BackgroundWorker1=new System.ComponentModel.BackgroundWorker();
            Rotate270Button=new Button();
            Rotate180Button=new Button();
            Label6=new Label();
            AddFilesButton=new Button();
            FilesList=new ListBox();
            txtPDFFileName=new TextBox();
            pbThumbnail=new PictureBox();
            DeselectFilesButton=new Button();
            DeleteFilesFromListButton=new Button();
            pnlMovie=new Panel();
            pnlDispOption=new Panel();
            ZoomOutButton=new Button();
            ZoomInButton=new Button();
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
            thumbnailDefaultPanel=new Panel();
            ThumnailMovoToPanel=new Panel();
            SecondGroup=new GroupBox();
            ((System.ComponentModel.ISupportInitialize)SeekTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbThumbnail).BeginInit();
            pnlMovie.SuspendLayout();
            pnlDispOption.SuspendLayout();
            pnlPage.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SecondGroup.SuspendLayout();
            SuspendLayout();
            // 
            // DisplayButton
            // 
            DisplayButton.Location=new Point(11, 26);
            DisplayButton.Name="DisplayButton";
            DisplayButton.Size=new Size(97, 51);
            DisplayButton.TabIndex=20;
            DisplayButton.Text="表示";
            DisplayButton.UseVisualStyleBackColor=true;
            DisplayButton.Click+=DisplayButton_Click;
            // 
            // BackgroundDisplayButton
            // 
            BackgroundDisplayButton.Location=new Point(215, 26);
            BackgroundDisplayButton.Name="BackgroundDisplayButton";
            BackgroundDisplayButton.Size=new Size(115, 51);
            BackgroundDisplayButton.TabIndex=20;
            BackgroundDisplayButton.Text="背景表示";
            BackgroundDisplayButton.UseVisualStyleBackColor=true;
            BackgroundDisplayButton.Click+=BackgroundDisplay_Click;
            // 
            // EndOfDisplayButton
            // 
            EndOfDisplayButton.Location=new Point(118, 26);
            EndOfDisplayButton.Name="EndOfDisplayButton";
            EndOfDisplayButton.Size=new Size(91, 51);
            EndOfDisplayButton.TabIndex=20;
            EndOfDisplayButton.Text="表示終了";
            EndOfDisplayButton.UseVisualStyleBackColor=true;
            EndOfDisplayButton.Click+=EndOfDisplayButton_Click;
            // 
            // AutoDisplayCheckBox
            // 
            AutoDisplayCheckBox.AutoSize=true;
            AutoDisplayCheckBox.FlatStyle=FlatStyle.System;
            AutoDisplayCheckBox.Location=new Point(336, 40);
            AutoDisplayCheckBox.Name="AutoDisplayCheckBox";
            AutoDisplayCheckBox.Size=new Size(157, 25);
            AutoDisplayCheckBox.TabIndex=25;
            AutoDisplayCheckBox.Text="操作中に自動表示";
            AutoDisplayCheckBox.UseVisualStyleBackColor=true;
            AutoDisplayCheckBox.CheckedChanged+=AutoDisplayCheckBox_CheckedChanged;
            // 
            // MovieTimeLabel
            // 
            MovieTimeLabel.AutoSize=true;
            MovieTimeLabel.Location=new Point(571, 493);
            MovieTimeLabel.Name="MovieTimeLabel";
            MovieTimeLabel.Size=new Size(71, 20);
            MovieTimeLabel.TabIndex=95;
            MovieTimeLabel.Text="-- time --";
            // 
            // AllFilesSelectButton
            // 
            AllFilesSelectButton.Location=new Point(2, 623);
            AllFilesSelectButton.Name="AllFilesSelectButton";
            AllFilesSelectButton.Size=new Size(69, 40);
            AllFilesSelectButton.TabIndex=94;
            AllFilesSelectButton.Text="全選択";
            AllFilesSelectButton.UseVisualStyleBackColor=true;
            AllFilesSelectButton.Click+=AllFilesSelectButton_Click;
            // 
            // LastPageOfPDFButton
            // 
            LastPageOfPDFButton.Location=new Point(197, 3);
            LastPageOfPDFButton.Name="LastPageOfPDFButton";
            LastPageOfPDFButton.Size=new Size(61, 45);
            LastPageOfPDFButton.TabIndex=93;
            LastPageOfPDFButton.Text="最後へ";
            LastPageOfPDFButton.UseVisualStyleBackColor=true;
            LastPageOfPDFButton.Click+=LastPageOfPDF_Click;
            // 
            // ShowWholeButton
            // 
            ShowWholeButton.Location=new Point(165, 123);
            ShowWholeButton.Name="ShowWholeButton";
            ShowWholeButton.Size=new Size(91, 45);
            ShowWholeButton.TabIndex=92;
            ShowWholeButton.Text="全体を表示";
            ShowWholeButton.UseVisualStyleBackColor=true;
            ShowWholeButton.Click+=ShowWholeButton_Click;
            // 
            // lblPageDisp
            // 
            lblPageDisp.Location=new Point(475, 460);
            lblPageDisp.Name="lblPageDisp";
            lblPageDisp.Size=new Size(267, 20);
            lblPageDisp.TabIndex=91;
            lblPageDisp.Text="- page -";
            // 
            // PreviousHalfPageOfPDFButton
            // 
            PreviousHalfPageOfPDFButton.Location=new Point(14, 52);
            PreviousHalfPageOfPDFButton.Name="PreviousHalfPageOfPDFButton";
            PreviousHalfPageOfPDFButton.Size=new Size(120, 45);
            PreviousHalfPageOfPDFButton.TabIndex=89;
            PreviousHalfPageOfPDFButton.Text="0.5ページ前へ";
            PreviousHalfPageOfPDFButton.UseVisualStyleBackColor=true;
            PreviousHalfPageOfPDFButton.Click+=PreviousHalfPageOfPdfButton_Click;
            // 
            // NextHalfPageOfPDFButton
            // 
            NextHalfPageOfPDFButton.Location=new Point(139, 52);
            NextHalfPageOfPDFButton.Name="NextHalfPageOfPDFButton";
            NextHalfPageOfPDFButton.Size=new Size(120, 45);
            NextHalfPageOfPDFButton.TabIndex=90;
            NextHalfPageOfPDFButton.Text="0.5ページ先へ";
            NextHalfPageOfPDFButton.UseVisualStyleBackColor=true;
            NextHalfPageOfPDFButton.Click+=NextHalfPageOfPDFButton_Click;
            // 
            // NextPageOfPDFButton
            // 
            NextPageOfPDFButton.Location=new Point(141, 3);
            NextPageOfPDFButton.Name="NextPageOfPDFButton";
            NextPageOfPDFButton.Size=new Size(50, 45);
            NextPageOfPDFButton.TabIndex=86;
            NextPageOfPDFButton.Text="次へ";
            NextPageOfPDFButton.UseVisualStyleBackColor=true;
            NextPageOfPDFButton.Click+=NextPageOfPDF_Click;
            // 
            // PreviousPageOfPDFButton
            // 
            PreviousPageOfPDFButton.Location=new Point(85, 3);
            PreviousPageOfPDFButton.Name="PreviousPageOfPDFButton";
            PreviousPageOfPDFButton.Size=new Size(50, 45);
            PreviousPageOfPDFButton.TabIndex=87;
            PreviousPageOfPDFButton.Text="前へ";
            PreviousPageOfPDFButton.UseVisualStyleBackColor=true;
            PreviousPageOfPDFButton.Click+=PreviousPageOfPDFButton_Click;
            // 
            // FirstPageOfPDFButton
            // 
            FirstPageOfPDFButton.Location=new Point(11, 3);
            FirstPageOfPDFButton.Name="FirstPageOfPDFButton";
            FirstPageOfPDFButton.Size=new Size(67, 45);
            FirstPageOfPDFButton.TabIndex=88;
            FirstPageOfPDFButton.Text="最初へ";
            FirstPageOfPDFButton.UseVisualStyleBackColor=true;
            FirstPageOfPDFButton.Click+=FirstPageOfPDFButton_Click;
            // 
            // GotoFirstButton
            // 
            GotoFirstButton.Location=new Point(6, 19);
            GotoFirstButton.Name="GotoFirstButton";
            GotoFirstButton.Size=new Size(51, 60);
            GotoFirstButton.TabIndex=80;
            GotoFirstButton.Text="先頭";
            GotoFirstButton.UseVisualStyleBackColor=true;
            GotoFirstButton.Click+=GotoFirstButton_Click;
            // 
            // PauseButton
            // 
            PauseButton.Location=new Point(222, 19);
            PauseButton.Name="PauseButton";
            PauseButton.Size=new Size(51, 60);
            PauseButton.TabIndex=81;
            PauseButton.Text="||";
            PauseButton.UseVisualStyleBackColor=true;
            PauseButton.Click+=PauseButton_Click;
            // 
            // FastReverseButton
            // 
            FastReverseButton.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            FastReverseButton.Location=new Point(58, 19);
            FastReverseButton.Name="FastReverseButton";
            FastReverseButton.Size=new Size(51, 60);
            FastReverseButton.TabIndex=82;
            FastReverseButton.Text="◀";
            FastReverseButton.UseVisualStyleBackColor=true;
            FastReverseButton.Click+=FastReverseButton_Click;
            // 
            // FastForwardButton
            // 
            FastForwardButton.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            FastForwardButton.Location=new Point(167, 19);
            FastForwardButton.Name="FastForwardButton";
            FastForwardButton.Size=new Size(51, 60);
            FastForwardButton.TabIndex=83;
            FastForwardButton.Text="▶▶";
            FastForwardButton.UseVisualStyleBackColor=true;
            FastForwardButton.Click+=FastForwardButton_Click;
            // 
            // StartButton
            // 
            StartButton.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            StartButton.Location=new Point(112, 19);
            StartButton.Name="StartButton";
            StartButton.Size=new Size(51, 60);
            StartButton.TabIndex=84;
            StartButton.Text="▶";
            StartButton.UseVisualStyleBackColor=true;
            StartButton.Click+=StartButton_Click;
            // 
            // Label2
            // 
            Label2.AutoSize=true;
            Label2.Location=new Point(507, 41);
            Label2.Name="Label2";
            Label2.Size=new Size(90, 20);
            Label2.TabIndex=79;
            Label2.Text="表示プレビュー";
            // 
            // VScrollBar1
            // 
            VScrollBar1.Location=new Point(818, 47);
            VScrollBar1.Name="VScrollBar1";
            VScrollBar1.Size=new Size(23, 400);
            VScrollBar1.TabIndex=78;
            VScrollBar1.Scroll+=VScrollBar1_Scroll;
            // 
            // FitToWindowWidthButton
            // 
            FitToWindowWidthButton.Location=new Point(2, 123);
            FitToWindowWidthButton.Name="FitToWindowWidthButton";
            FitToWindowWidthButton.Size=new Size(155, 45);
            FitToWindowWidthButton.TabIndex=76;
            FitToWindowWidthButton.Text="ウィンドウ幅に合わせる";
            FitToWindowWidthButton.UseVisualStyleBackColor=true;
            FitToWindowWidthButton.Click+=FitToWindowWidthButton_Click;
            // 
            // Rotate90Button
            // 
            Rotate90Button.Location=new Point(149, 36);
            Rotate90Button.Name="Rotate90Button";
            Rotate90Button.Size=new Size(70, 51);
            Rotate90Button.TabIndex=72;
            Rotate90Button.Text="右90度";
            Rotate90Button.UseVisualStyleBackColor=true;
            Rotate90Button.Click+=Rotate90Button_Click;
            // 
            // SeekTrackBar
            // 
            SeekTrackBar.Location=new Point(447, 460);
            SeekTrackBar.Name="SeekTrackBar";
            SeekTrackBar.Size=new Size(317, 56);
            SeekTrackBar.TabIndex=85;
            SeekTrackBar.Scroll+=SeekTrackBar_Scroll;
            SeekTrackBar.MouseDown+=SeekTrackBar_MouseDown;
            // 
            // Rotate0Button
            // 
            Rotate0Button.Location=new Point(83, 0);
            Rotate0Button.Name="Rotate0Button";
            Rotate0Button.Size=new Size(59, 51);
            Rotate0Button.TabIndex=73;
            Rotate0Button.Text="０度";
            Rotate0Button.UseVisualStyleBackColor=true;
            Rotate0Button.Click+=Rotate0Button_Click;
            // 
            // OpenFileDialog1
            // 
            OpenFileDialog1.FileName="OpenFileDialog1";
            // 
            // SeekTimer
            // 
            SeekTimer.Tick+=SeekTimer_Tick;
            // 
            // Rotate270Button
            // 
            Rotate270Button.Location=new Point(7, 36);
            Rotate270Button.Name="Rotate270Button";
            Rotate270Button.Size=new Size(70, 51);
            Rotate270Button.TabIndex=74;
            Rotate270Button.Text="左90度";
            Rotate270Button.UseVisualStyleBackColor=true;
            Rotate270Button.Click+=Rotate270Button_Click;
            // 
            // Rotate180Button
            // 
            Rotate180Button.Location=new Point(83, 67);
            Rotate180Button.Name="Rotate180Button";
            Rotate180Button.Size=new Size(59, 51);
            Rotate180Button.TabIndex=75;
            Rotate180Button.Text="180度回転";
            Rotate180Button.UseVisualStyleBackColor=true;
            Rotate180Button.Click+=Rotate180Button_Click;
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
            // AddFilesButton
            // 
            AddFilesButton.Location=new Point(157, 623);
            AddFilesButton.Name="AddFilesButton";
            AddFilesButton.Size=new Size(101, 40);
            AddFilesButton.TabIndex=70;
            AddFilesButton.Text="ファイルを追加";
            AddFilesButton.UseVisualStyleBackColor=true;
            AddFilesButton.Click+=AddFilesButton_Click;
            // 
            // FilesList
            // 
            FilesList.AllowDrop=true;
            FilesList.FormattingEnabled=true;
            FilesList.ItemHeight=20;
            FilesList.Location=new Point(2, 59);
            FilesList.Margin=new Padding(30, 29, 30, 29);
            FilesList.Name="FilesList";
            FilesList.SelectionMode=SelectionMode.MultiExtended;
            FilesList.Size=new Size(256, 564);
            FilesList.TabIndex=67;
            FilesList.Click+=FilesList_Click;
            FilesList.SelectedValueChanged+=FilesList_SelectedValueChanged;
            FilesList.DragDrop+=FilesList_DragDrop;
            FilesList.DragEnter+=FilesList_DragEnter;
            // 
            // txtPDFFileName
            // 
            txtPDFFileName.Location=new Point(91, 5);
            txtPDFFileName.Name="txtPDFFileName";
            txtPDFFileName.ReadOnly=true;
            txtPDFFileName.Size=new Size(655, 27);
            txtPDFFileName.TabIndex=65;
            // 
            // pbThumbnail
            // 
            pbThumbnail.BackColor=Color.Red;
            pbThumbnail.Location=new Point(801, 481);
            pbThumbnail.Name="pbThumbnail";
            pbThumbnail.Size=new Size(24, 32);
            pbThumbnail.TabIndex=77;
            pbThumbnail.TabStop=false;
            // 
            // DeselectFilesButton
            // 
            DeselectFilesButton.Location=new Point(77, 623);
            DeselectFilesButton.Name="DeselectFilesButton";
            DeselectFilesButton.Size=new Size(77, 40);
            DeselectFilesButton.TabIndex=68;
            DeselectFilesButton.Text="選択解除";
            DeselectFilesButton.UseVisualStyleBackColor=true;
            DeselectFilesButton.Click+=DeselectFiles_Click;
            // 
            // DeleteFilesFromListButton
            // 
            DeleteFilesFromListButton.Location=new Point(26, 669);
            DeleteFilesFromListButton.Name="DeleteFilesFromListButton";
            DeleteFilesFromListButton.Size=new Size(88, 40);
            DeleteFilesFromListButton.TabIndex=69;
            DeleteFilesFromListButton.Text="削除";
            DeleteFilesFromListButton.UseVisualStyleBackColor=true;
            DeleteFilesFromListButton.Click+=DeleteFilesFromListButton_Click;
            // 
            // pnlMovie
            // 
            pnlMovie.Controls.Add(GotoFirstButton);
            pnlMovie.Controls.Add(PauseButton);
            pnlMovie.Controls.Add(FastReverseButton);
            pnlMovie.Controls.Add(FastForwardButton);
            pnlMovie.Controls.Add(StartButton);
            pnlMovie.Location=new Point(6, 4);
            pnlMovie.Margin=new Padding(3, 4, 3, 4);
            pnlMovie.Name="pnlMovie";
            pnlMovie.Size=new Size(279, 100);
            pnlMovie.TabIndex=98;
            // 
            // pnlDispOption
            // 
            pnlDispOption.Controls.Add(pnlMovie);
            pnlDispOption.Controls.Add(ZoomOutButton);
            pnlDispOption.Controls.Add(ShowWholeButton);
            pnlDispOption.Controls.Add(ZoomInButton);
            pnlDispOption.Controls.Add(FitToWindowWidthButton);
            pnlDispOption.Controls.Add(Rotate90Button);
            pnlDispOption.Controls.Add(Rotate0Button);
            pnlDispOption.Controls.Add(Rotate270Button);
            pnlDispOption.Controls.Add(Rotate180Button);
            pnlDispOption.Location=new Point(5, 45);
            pnlDispOption.Margin=new Padding(3, 4, 3, 4);
            pnlDispOption.Name="pnlDispOption";
            pnlDispOption.Size=new Size(267, 224);
            pnlDispOption.TabIndex=99;
            // 
            // ZoomOutButton
            // 
            ZoomOutButton.Location=new Point(126, 173);
            ZoomOutButton.Margin=new Padding(3, 4, 3, 4);
            ZoomOutButton.Name="ZoomOutButton";
            ZoomOutButton.Size=new Size(110, 45);
            ZoomOutButton.TabIndex=93;
            ZoomOutButton.Text="縮小";
            ZoomOutButton.UseVisualStyleBackColor=true;
            ZoomOutButton.Click+=ZoomOutButton_Click;
            // 
            // ZoomInButton
            // 
            ZoomInButton.Location=new Point(3, 173);
            ZoomInButton.Name="ZoomInButton";
            ZoomInButton.Size=new Size(110, 45);
            ZoomInButton.TabIndex=76;
            ZoomInButton.Text="拡大";
            ZoomInButton.UseVisualStyleBackColor=true;
            ZoomInButton.Click+=ZoomInButton_Click;
            // 
            // pnlPage
            // 
            pnlPage.Controls.Add(LastPageOfPDFButton);
            pnlPage.Controls.Add(PreviousHalfPageOfPDFButton);
            pnlPage.Controls.Add(NextHalfPageOfPDFButton);
            pnlPage.Controls.Add(NextPageOfPDFButton);
            pnlPage.Controls.Add(PreviousPageOfPDFButton);
            pnlPage.Controls.Add(FirstPageOfPDFButton);
            pnlPage.Location=new Point(8, 271);
            pnlPage.Margin=new Padding(3, 4, 3, 4);
            pnlPage.Name="pnlPage";
            pnlPage.Size=new Size(262, 104);
            pnlPage.TabIndex=100;
            // 
            // thumbnailMoviePlayer
            // 
            thumbnailMoviePlayer.BackColor=Color.FromArgb(192, 0, 0);
            thumbnailMoviePlayer.Location=new Point(766, 481);
            thumbnailMoviePlayer.Name="thumbnailMoviePlayer";
            thumbnailMoviePlayer.Rate=-1F;
            thumbnailMoviePlayer.Size=new Size(29, 32);
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
            menuStrip1.Padding=new Padding(6, 3, 0, 3);
            menuStrip1.Size=new Size(1170, 30);
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
            panel2.Controls.Add(MovieTimeLabel);
            panel2.Controls.Add(pnlPage);
            panel2.Controls.Add(Label6);
            panel2.Controls.Add(pnlDispOption);
            panel2.Controls.Add(txtPDFFileName);
            panel2.Controls.Add(VScrollBar1);
            panel2.Controls.Add(Label2);
            panel2.Controls.Add(thumbnailMoviePlayer);
            panel2.Controls.Add(SeekTrackBar);
            panel2.Location=new Point(286, 36);
            panel2.Name="panel2";
            panel2.Size=new Size(851, 554);
            panel2.TabIndex=103;
            // 
            // thumbnailDefaultPanel
            // 
            thumbnailDefaultPanel.BackColor=Color.FromArgb(0, 0, 192);
            thumbnailDefaultPanel.Location=new Point(286, 64);
            thumbnailDefaultPanel.Name="thumbnailDefaultPanel";
            thumbnailDefaultPanel.Size=new Size(527, 393);
            thumbnailDefaultPanel.TabIndex=102;
            thumbnailDefaultPanel.Visible=false;
            // 
            // ThumnailMovoToPanel
            // 
            ThumnailMovoToPanel.BackColor=Color.FromArgb(0, 0, 192);
            ThumnailMovoToPanel.Location=new Point(16, 379);
            ThumnailMovoToPanel.Name="ThumnailMovoToPanel";
            ThumnailMovoToPanel.Size=new Size(250, 161);
            ThumnailMovoToPanel.TabIndex=101;
            ThumnailMovoToPanel.Visible=false;
            // 
            // SecondGroup
            // 
            SecondGroup.Controls.Add(DisplayButton);
            SecondGroup.Controls.Add(AutoDisplayCheckBox);
            SecondGroup.Controls.Add(EndOfDisplayButton);
            SecondGroup.Controls.Add(BackgroundDisplayButton);
            SecondGroup.Location=new Point(286, 694);
            SecondGroup.Name="SecondGroup";
            SecondGroup.Size=new Size(491, 92);
            SecondGroup.TabIndex=104;
            SecondGroup.TabStop=false;
            SecondGroup.Text="セカンドモニター操作";
            // 
            // OperationForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1170, 843);
            Controls.Add(SecondGroup);
            Controls.Add(DeleteFilesFromListButton);
            Controls.Add(AddFilesButton);
            Controls.Add(DeselectFilesButton);
            Controls.Add(AllFilesSelectButton);
            Controls.Add(FilesList);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            Icon=(Icon)resources.GetObject("$this.Icon");
            MainMenuStrip=menuStrip1;
            Margin=new Padding(3, 4, 3, 4);
            Name="OperationForm";
            Text="ViewerBy2nd Monitor";
            FormClosed+=OperationForm_FormClosed;
            Load+=OperationForm_Load;
            Resize+=OperationForm_Resize;
            ((System.ComponentModel.ISupportInitialize)SeekTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbThumbnail).EndInit();
            pnlMovie.ResumeLayout(false);
            pnlDispOption.ResumeLayout(false);
            pnlPage.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            SecondGroup.ResumeLayout(false);
            SecondGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        internal System.Windows.Forms.Button DisplayButton;
        internal System.Windows.Forms.Button BackgroundDisplayButton;
        internal System.Windows.Forms.Button EndOfDisplayButton;
        internal System.Windows.Forms.Label MovieTimeLabel;
        internal System.Windows.Forms.Button AllFilesSelectButton;
        internal System.Windows.Forms.Button LastPageOfPDFButton;
        internal System.Windows.Forms.Button ShowWholeButton;
        internal System.Windows.Forms.Label lblPageDisp;
        internal System.Windows.Forms.Button PreviousHalfPageOfPDFButton;
        internal System.Windows.Forms.Button NextHalfPageOfPDFButton;
        internal System.Windows.Forms.Button NextPageOfPDFButton;
        internal System.Windows.Forms.Button PreviousPageOfPDFButton;
        internal System.Windows.Forms.Button FirstPageOfPDFButton;
        internal System.Windows.Forms.Button GotoFirstButton;
        internal System.Windows.Forms.Button PauseButton;
        internal System.Windows.Forms.Button FastReverseButton;
        internal System.Windows.Forms.Button FastForwardButton;
        internal System.Windows.Forms.Button StartButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.VScrollBar VScrollBar1;
        internal System.Windows.Forms.Button FitToWindowWidthButton;
        internal System.Windows.Forms.Button Rotate90Button;
        internal System.Windows.Forms.TrackBar SeekTrackBar;
        internal System.Windows.Forms.Button Rotate0Button;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.CheckBox AutoDisplayCheckBox;
        internal System.Windows.Forms.Timer SeekTimer;
        internal System.ComponentModel.BackgroundWorker BackgroundWorker1;
        internal System.Windows.Forms.Button Rotate270Button;
        internal System.Windows.Forms.Button Rotate180Button;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button AddFilesButton;
        internal System.Windows.Forms.ListBox FilesList;
        internal System.Windows.Forms.TextBox txtPDFFileName;
        internal System.Windows.Forms.PictureBox pbThumbnail;
        internal System.Windows.Forms.Button DeselectFilesButton;
        internal System.Windows.Forms.Button DeleteFilesFromListButton;
        internal ViewerBy2nd.WinFormsControlLibrary.VideoPlayer thumbnailMoviePlayer;
        private System.Windows.Forms.Panel pnlMovie;
        private System.Windows.Forms.Panel pnlDispOption;
        private System.Windows.Forms.Panel pnlPage;
        internal System.Windows.Forms.Button ZoomInButton;
        private System.Windows.Forms.Button ZoomOutButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private ToolStripMenuItem ディスプレイと背景色ToolStripMenuItem;
        private ToolStripMenuItem ヘルプToolStripMenuItem;
        private ToolStripMenuItem このアプリについてToolStripMenuItem;
        private Panel panel2;
        private ToolStripMenuItem リストToolStripMenuItem;
        private ToolStripMenuItem 表示ToolStripMenuItem;
        private ToolStripMenuItem 非表示ToolStripMenuItem;
        private Panel ThumnailMovoToPanel;
        private Panel thumbnailDefaultPanel;
        private GroupBox SecondGroup;
    }
}

