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
            PageNumberLabel=new Label();
            PreviousHalfPageOfPDFButton=new Button();
            NextHalfPageOfPDFButton=new Button();
            NextPageOfPDFButton=new Button();
            PreviousPageOfPDFButton=new Button();
            FirstPageOfPDFButton=new Button();
            GotoFirstButton=new Button();
            PauseButton=new Button();
            FastReverseButton=new Button();
            FastForwardButton=new Button();
            PlayButton=new Button();
            Label2=new Label();
            InPageScrollBar=new VScrollBar();
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
            ファイルToolStripMenuItem=new ToolStripMenuItem();
            リストLToolStripMenuItem=new ToolStripMenuItem();
            開くOToolStripMenuItem=new ToolStripMenuItem();
            リストToolStripMenuItem=new ToolStripMenuItem();
            表示を回転ToolStripMenuItem=new ToolStripMenuItem();
            元の表示ToolStripMenuItem=new ToolStripMenuItem();
            右へ90回転ToolStripMenuItem=new ToolStripMenuItem();
            左へ90回転ToolStripMenuItem=new ToolStripMenuItem();
            回転ToolStripMenuItem=new ToolStripMenuItem();
            ページナビゲーションToolStripMenuItem=new ToolStripMenuItem();
            最初のページToolStripMenuItem=new ToolStripMenuItem();
            次へToolStripMenuItem1=new ToolStripMenuItem();
            前のページToolStripMenuItem=new ToolStripMenuItem();
            最後のページToolStripMenuItem=new ToolStripMenuItem();
            ページ指定ToolStripMenuItem=new ToolStripMenuItem();
            ズームToolStripMenuItem=new ToolStripMenuItem();
            ウィンドウ幅に合わせるToolStripMenuItem=new ToolStripMenuItem();
            全体を表示ToolStripMenuItem=new ToolStripMenuItem();
            拡大ToolStripMenuItem=new ToolStripMenuItem();
            縮小ToolStripMenuItem=new ToolStripMenuItem();
            再生ToolStripMenuItem=new ToolStripMenuItem();
            最初に移動ToolStripMenuItem=new ToolStripMenuItem();
            再生開始ToolStripMenuItem=new ToolStripMenuItem();
            再生停止ToolStripMenuItem=new ToolStripMenuItem();
            早送りToolStripMenuItem=new ToolStripMenuItem();
            巻き戻しToolStripMenuItem=new ToolStripMenuItem();
            セカンドモニター操作ToolStripMenuItem=new ToolStripMenuItem();
            表示ToolStripMenuItem=new ToolStripMenuItem();
            表示終了ToolStripMenuItem=new ToolStripMenuItem();
            背景表示ToolStripMenuItem=new ToolStripMenuItem();
            設定ToolStripMenuItem=new ToolStripMenuItem();
            ディスプレイと背景色ToolStripMenuItem=new ToolStripMenuItem();
            言語LToolStripMenuItem=new ToolStripMenuItem();
            操作中に自動表示ToolStripMenuItem=new ToolStripMenuItem();
            ウインドウサイズToolStripMenuItem=new ToolStripMenuItem();
            スリムToolStripMenuItem=new ToolStripMenuItem();
            標準ToolStripMenuItem=new ToolStripMenuItem();
            ヘルプToolStripMenuItem=new ToolStripMenuItem();
            このアプリについてToolStripMenuItem=new ToolStripMenuItem();
            panel2=new Panel();
            thumbnailDefaultPanel=new Panel();
            ThumnailMovoToPanel=new Panel();
            SecondGroup=new GroupBox();
            DisplayOfSmallButton=new Button();
            EndOfDisplayOfSmallButton=new Button();
            BackgroundDisplayOfSmallButton=new Button();
            SecondOfSmallPanel=new Panel();
            ((System.ComponentModel.ISupportInitialize)SeekTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbThumbnail).BeginInit();
            pnlMovie.SuspendLayout();
            pnlDispOption.SuspendLayout();
            pnlPage.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SecondGroup.SuspendLayout();
            SecondOfSmallPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DisplayButton
            // 
            DisplayButton.Location=new Point(11, 27);
            DisplayButton.Name="DisplayButton";
            DisplayButton.Size=new Size(97, 51);
            DisplayButton.TabIndex=20;
            DisplayButton.Text="表示";
            DisplayButton.UseVisualStyleBackColor=true;
            DisplayButton.Click+=DisplayButton_Click;
            // 
            // BackgroundDisplayButton
            // 
            BackgroundDisplayButton.Location=new Point(215, 27);
            BackgroundDisplayButton.Name="BackgroundDisplayButton";
            BackgroundDisplayButton.Size=new Size(115, 51);
            BackgroundDisplayButton.TabIndex=20;
            BackgroundDisplayButton.Text="背景表示";
            BackgroundDisplayButton.UseVisualStyleBackColor=true;
            BackgroundDisplayButton.Click+=BackgroundDisplay_Click;
            // 
            // EndOfDisplayButton
            // 
            EndOfDisplayButton.Location=new Point(118, 27);
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
            AllFilesSelectButton.Location=new Point(5, 608);
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
            // PageNumberLabel
            // 
            PageNumberLabel.Location=new Point(475, 460);
            PageNumberLabel.Name="PageNumberLabel";
            PageNumberLabel.Size=new Size(267, 20);
            PageNumberLabel.TabIndex=91;
            PageNumberLabel.Text="- page -";
            PageNumberLabel.Click+=PageNumberLabel_Click;
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
            // PlayButton
            // 
            PlayButton.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            PlayButton.Location=new Point(112, 19);
            PlayButton.Name="PlayButton";
            PlayButton.Size=new Size(51, 60);
            PlayButton.TabIndex=84;
            PlayButton.Text="▶";
            PlayButton.UseVisualStyleBackColor=true;
            PlayButton.Click+=PlayButton_Click;
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
            // InPageScrollBar
            // 
            InPageScrollBar.Location=new Point(816, 64);
            InPageScrollBar.Name="InPageScrollBar";
            InPageScrollBar.Size=new Size(23, 393);
            InPageScrollBar.TabIndex=78;
            InPageScrollBar.Scroll+=VScrollBar1_Scroll;
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
            AddFilesButton.Location=new Point(160, 608);
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
            FilesList.Location=new Point(5, 36);
            FilesList.Margin=new Padding(30, 29, 30, 29);
            FilesList.Name="FilesList";
            FilesList.SelectionMode=SelectionMode.MultiExtended;
            FilesList.Size=new Size(255, 564);
            FilesList.TabIndex=67;
            FilesList.Click+=FilesList_Click;
            FilesList.SelectedIndexChanged+=FilesList_SelectedIndexChanged;
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
            DeselectFilesButton.Location=new Point(80, 608);
            DeselectFilesButton.Name="DeselectFilesButton";
            DeselectFilesButton.Size=new Size(77, 40);
            DeselectFilesButton.TabIndex=68;
            DeselectFilesButton.Text="選択解除";
            DeselectFilesButton.UseVisualStyleBackColor=true;
            DeselectFilesButton.Click+=DeselectFiles_Click;
            // 
            // DeleteFilesFromListButton
            // 
            DeleteFilesFromListButton.Location=new Point(29, 653);
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
            pnlMovie.Controls.Add(PlayButton);
            pnlMovie.Location=new Point(7, 37);
            pnlMovie.Margin=new Padding(3, 4, 3, 4);
            pnlMovie.Name="pnlMovie";
            pnlMovie.Size=new Size(279, 100);
            pnlMovie.TabIndex=98;
            // 
            // pnlDispOption
            // 
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, リストToolStripMenuItem, 設定ToolStripMenuItem, ヘルプToolStripMenuItem });
            menuStrip1.Location=new Point(0, 0);
            menuStrip1.Name="menuStrip1";
            menuStrip1.Padding=new Padding(6, 3, 0, 3);
            menuStrip1.Size=new Size(1170, 30);
            menuStrip1.TabIndex=101;
            menuStrip1.Text="menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            ファイルToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { リストLToolStripMenuItem, 開くOToolStripMenuItem });
            ファイルToolStripMenuItem.Name="ファイルToolStripMenuItem";
            ファイルToolStripMenuItem.Size=new Size(82, 24);
            ファイルToolStripMenuItem.Text="ファイル(&F)";
            // 
            // リストLToolStripMenuItem
            // 
            リストLToolStripMenuItem.Name="リストLToolStripMenuItem";
            リストLToolStripMenuItem.Size=new Size(221, 26);
            リストLToolStripMenuItem.Text="リスト(&L)";
            // 
            // 開くOToolStripMenuItem
            // 
            開くOToolStripMenuItem.Name="開くOToolStripMenuItem";
            開くOToolStripMenuItem.Size=new Size(221, 26);
            開くOToolStripMenuItem.Text="開く(リストに追加)(&O)";
            開くOToolStripMenuItem.Click+=開くOToolStripMenuItem_Click;
            // 
            // リストToolStripMenuItem
            // 
            リストToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 表示を回転ToolStripMenuItem, ページナビゲーションToolStripMenuItem, ズームToolStripMenuItem, 再生ToolStripMenuItem, セカンドモニター操作ToolStripMenuItem });
            リストToolStripMenuItem.Name="リストToolStripMenuItem";
            リストToolStripMenuItem.Size=new Size(72, 24);
            リストToolStripMenuItem.Text="表示(&V)";
            // 
            // 表示を回転ToolStripMenuItem
            // 
            表示を回転ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 元の表示ToolStripMenuItem, 右へ90回転ToolStripMenuItem, 左へ90回転ToolStripMenuItem, 回転ToolStripMenuItem });
            表示を回転ToolStripMenuItem.Name="表示を回転ToolStripMenuItem";
            表示を回転ToolStripMenuItem.Size=new Size(210, 26);
            表示を回転ToolStripMenuItem.Text="表示を回転";
            表示を回転ToolStripMenuItem.Click+=次へToolStripMenuItem_Click;
            // 
            // 元の表示ToolStripMenuItem
            // 
            元の表示ToolStripMenuItem.Name="元の表示ToolStripMenuItem";
            元の表示ToolStripMenuItem.Size=new Size(171, 26);
            元の表示ToolStripMenuItem.Text="元の表示";
            元の表示ToolStripMenuItem.Click+=元の表示ToolStripMenuItem_Click;
            // 
            // 右へ90回転ToolStripMenuItem
            // 
            右へ90回転ToolStripMenuItem.Name="右へ90回転ToolStripMenuItem";
            右へ90回転ToolStripMenuItem.Size=new Size(171, 26);
            右へ90回転ToolStripMenuItem.Text="右へ90°回転";
            右へ90回転ToolStripMenuItem.Click+=右へ90回転ToolStripMenuItem_Click;
            // 
            // 左へ90回転ToolStripMenuItem
            // 
            左へ90回転ToolStripMenuItem.Name="左へ90回転ToolStripMenuItem";
            左へ90回転ToolStripMenuItem.Size=new Size(171, 26);
            左へ90回転ToolStripMenuItem.Text="左へ90°回転";
            左へ90回転ToolStripMenuItem.Click+=左へ90回転ToolStripMenuItem_Click;
            // 
            // 回転ToolStripMenuItem
            // 
            回転ToolStripMenuItem.Name="回転ToolStripMenuItem";
            回転ToolStripMenuItem.Size=new Size(171, 26);
            回転ToolStripMenuItem.Text="180°回転";
            回転ToolStripMenuItem.Click+=回転ToolStripMenuItem_Click;
            // 
            // ページナビゲーションToolStripMenuItem
            // 
            ページナビゲーションToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 最初のページToolStripMenuItem, 次へToolStripMenuItem1, 前のページToolStripMenuItem, 最後のページToolStripMenuItem, ページ指定ToolStripMenuItem });
            ページナビゲーションToolStripMenuItem.Name="ページナビゲーションToolStripMenuItem";
            ページナビゲーションToolStripMenuItem.Size=new Size(210, 26);
            ページナビゲーションToolStripMenuItem.Text="ページナビゲーション";
            // 
            // 最初のページToolStripMenuItem
            // 
            最初のページToolStripMenuItem.Name="最初のページToolStripMenuItem";
            最初のページToolStripMenuItem.Size=new Size(168, 26);
            最初のページToolStripMenuItem.Text="最初のページ";
            最初のページToolStripMenuItem.Click+=最初のページToolStripMenuItem_Click;
            // 
            // 次へToolStripMenuItem1
            // 
            次へToolStripMenuItem1.Name="次へToolStripMenuItem1";
            次へToolStripMenuItem1.Size=new Size(168, 26);
            次へToolStripMenuItem1.Text="次のページ";
            次へToolStripMenuItem1.Click+=次へToolStripMenuItem1_Click;
            // 
            // 前のページToolStripMenuItem
            // 
            前のページToolStripMenuItem.Name="前のページToolStripMenuItem";
            前のページToolStripMenuItem.Size=new Size(168, 26);
            前のページToolStripMenuItem.Text="前のページ";
            前のページToolStripMenuItem.Click+=前のページToolStripMenuItem_Click;
            // 
            // 最後のページToolStripMenuItem
            // 
            最後のページToolStripMenuItem.Name="最後のページToolStripMenuItem";
            最後のページToolStripMenuItem.Size=new Size(168, 26);
            最後のページToolStripMenuItem.Text="最後のページ";
            最後のページToolStripMenuItem.Click+=最後のページToolStripMenuItem_Click;
            // 
            // ページ指定ToolStripMenuItem
            // 
            ページ指定ToolStripMenuItem.Name="ページ指定ToolStripMenuItem";
            ページ指定ToolStripMenuItem.Size=new Size(168, 26);
            ページ指定ToolStripMenuItem.Text="ページ指定";
            ページ指定ToolStripMenuItem.Click+=ページ指定ToolStripMenuItem_Click;
            // 
            // ズームToolStripMenuItem
            // 
            ズームToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ウィンドウ幅に合わせるToolStripMenuItem, 全体を表示ToolStripMenuItem, 拡大ToolStripMenuItem, 縮小ToolStripMenuItem });
            ズームToolStripMenuItem.Name="ズームToolStripMenuItem";
            ズームToolStripMenuItem.Size=new Size(210, 26);
            ズームToolStripMenuItem.Text="ズーム";
            // 
            // ウィンドウ幅に合わせるToolStripMenuItem
            // 
            ウィンドウ幅に合わせるToolStripMenuItem.Name="ウィンドウ幅に合わせるToolStripMenuItem";
            ウィンドウ幅に合わせるToolStripMenuItem.Size=new Size(224, 26);
            ウィンドウ幅に合わせるToolStripMenuItem.Text="ウィンドウ幅に合わせる";
            ウィンドウ幅に合わせるToolStripMenuItem.Click+=ウィンドウ幅に合わせるToolStripMenuItem_Click;
            // 
            // 全体を表示ToolStripMenuItem
            // 
            全体を表示ToolStripMenuItem.Name="全体を表示ToolStripMenuItem";
            全体を表示ToolStripMenuItem.Size=new Size(224, 26);
            全体を表示ToolStripMenuItem.Text="全体を表示";
            全体を表示ToolStripMenuItem.Click+=全体を表示ToolStripMenuItem_Click;
            // 
            // 拡大ToolStripMenuItem
            // 
            拡大ToolStripMenuItem.Name="拡大ToolStripMenuItem";
            拡大ToolStripMenuItem.Size=new Size(224, 26);
            拡大ToolStripMenuItem.Text="拡大";
            拡大ToolStripMenuItem.Click+=拡大ToolStripMenuItem_Click;
            // 
            // 縮小ToolStripMenuItem
            // 
            縮小ToolStripMenuItem.Name="縮小ToolStripMenuItem";
            縮小ToolStripMenuItem.Size=new Size(224, 26);
            縮小ToolStripMenuItem.Text="縮小";
            縮小ToolStripMenuItem.Click+=縮小ToolStripMenuItem_Click;
            // 
            // 再生ToolStripMenuItem
            // 
            再生ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 最初に移動ToolStripMenuItem, 再生開始ToolStripMenuItem, 再生停止ToolStripMenuItem, 早送りToolStripMenuItem, 巻き戻しToolStripMenuItem });
            再生ToolStripMenuItem.Name="再生ToolStripMenuItem";
            再生ToolStripMenuItem.Size=new Size(210, 26);
            再生ToolStripMenuItem.Text="再生";
            // 
            // 最初に移動ToolStripMenuItem
            // 
            最初に移動ToolStripMenuItem.Name="最初に移動ToolStripMenuItem";
            最初に移動ToolStripMenuItem.Size=new Size(164, 26);
            最初に移動ToolStripMenuItem.Text="最初に移動";
            最初に移動ToolStripMenuItem.Click+=最初に移動ToolStripMenuItem_Click;
            // 
            // 再生開始ToolStripMenuItem
            // 
            再生開始ToolStripMenuItem.Name="再生開始ToolStripMenuItem";
            再生開始ToolStripMenuItem.Size=new Size(164, 26);
            再生開始ToolStripMenuItem.Text="再生開始";
            再生開始ToolStripMenuItem.Click+=再生開始ToolStripMenuItem_Click;
            // 
            // 再生停止ToolStripMenuItem
            // 
            再生停止ToolStripMenuItem.Name="再生停止ToolStripMenuItem";
            再生停止ToolStripMenuItem.Size=new Size(164, 26);
            再生停止ToolStripMenuItem.Text="一時停止";
            再生停止ToolStripMenuItem.Click+=再生停止ToolStripMenuItem_Click;
            // 
            // 早送りToolStripMenuItem
            // 
            早送りToolStripMenuItem.Name="早送りToolStripMenuItem";
            早送りToolStripMenuItem.Size=new Size(164, 26);
            早送りToolStripMenuItem.Text="早送り";
            早送りToolStripMenuItem.Click+=早送りToolStripMenuItem_Click;
            // 
            // 巻き戻しToolStripMenuItem
            // 
            巻き戻しToolStripMenuItem.Name="巻き戻しToolStripMenuItem";
            巻き戻しToolStripMenuItem.Size=new Size(164, 26);
            巻き戻しToolStripMenuItem.Text="巻き戻し";
            巻き戻しToolStripMenuItem.Click+=巻き戻しToolStripMenuItem_Click;
            // 
            // セカンドモニター操作ToolStripMenuItem
            // 
            セカンドモニター操作ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 表示ToolStripMenuItem, 表示終了ToolStripMenuItem, 背景表示ToolStripMenuItem });
            セカンドモニター操作ToolStripMenuItem.Name="セカンドモニター操作ToolStripMenuItem";
            セカンドモニター操作ToolStripMenuItem.Size=new Size(210, 26);
            セカンドモニター操作ToolStripMenuItem.Text="セカンドモニター操作";
            // 
            // 表示ToolStripMenuItem
            // 
            表示ToolStripMenuItem.Name="表示ToolStripMenuItem";
            表示ToolStripMenuItem.Size=new Size(152, 26);
            表示ToolStripMenuItem.Text="表示";
            表示ToolStripMenuItem.Click+=表示ToolStripMenuItem_Click;
            // 
            // 表示終了ToolStripMenuItem
            // 
            表示終了ToolStripMenuItem.Name="表示終了ToolStripMenuItem";
            表示終了ToolStripMenuItem.Size=new Size(152, 26);
            表示終了ToolStripMenuItem.Text="表示終了";
            表示終了ToolStripMenuItem.Click+=表示終了ToolStripMenuItem_Click;
            // 
            // 背景表示ToolStripMenuItem
            // 
            背景表示ToolStripMenuItem.Name="背景表示ToolStripMenuItem";
            背景表示ToolStripMenuItem.Size=new Size(152, 26);
            背景表示ToolStripMenuItem.Text="背景表示";
            背景表示ToolStripMenuItem.Click+=背景表示ToolStripMenuItem_Click;
            // 
            // 設定ToolStripMenuItem
            // 
            設定ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ディスプレイと背景色ToolStripMenuItem, 言語LToolStripMenuItem, 操作中に自動表示ToolStripMenuItem, ウインドウサイズToolStripMenuItem });
            設定ToolStripMenuItem.Name="設定ToolStripMenuItem";
            設定ToolStripMenuItem.Size=new Size(71, 24);
            設定ToolStripMenuItem.Text="設定(&S)";
            // 
            // ディスプレイと背景色ToolStripMenuItem
            // 
            ディスプレイと背景色ToolStripMenuItem.Name="ディスプレイと背景色ToolStripMenuItem";
            ディスプレイと背景色ToolStripMenuItem.Size=new Size(212, 26);
            ディスプレイと背景色ToolStripMenuItem.Text="ディスプレイと背景色";
            ディスプレイと背景色ToolStripMenuItem.Click+=ディスプレイと背景色ToolStripMenuItem_Click;
            // 
            // 言語LToolStripMenuItem
            // 
            言語LToolStripMenuItem.Name="言語LToolStripMenuItem";
            言語LToolStripMenuItem.Size=new Size(212, 26);
            言語LToolStripMenuItem.Text="言語(&L)";
            // 
            // 操作中に自動表示ToolStripMenuItem
            // 
            操作中に自動表示ToolStripMenuItem.Checked=true;
            操作中に自動表示ToolStripMenuItem.CheckState=CheckState.Checked;
            操作中に自動表示ToolStripMenuItem.Name="操作中に自動表示ToolStripMenuItem";
            操作中に自動表示ToolStripMenuItem.Size=new Size(212, 26);
            操作中に自動表示ToolStripMenuItem.Text="操作中に自動表示";
            操作中に自動表示ToolStripMenuItem.Click+=操作中に自動表示ToolStripMenuItem_Click;
            // 
            // ウインドウサイズToolStripMenuItem
            // 
            ウインドウサイズToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { スリムToolStripMenuItem, 標準ToolStripMenuItem });
            ウインドウサイズToolStripMenuItem.Name="ウインドウサイズToolStripMenuItem";
            ウインドウサイズToolStripMenuItem.Size=new Size(212, 26);
            ウインドウサイズToolStripMenuItem.Text="操作画面サイズ";
            ウインドウサイズToolStripMenuItem.Click+=ウインドウサイズToolStripMenuItem_Click;
            // 
            // スリムToolStripMenuItem
            // 
            スリムToolStripMenuItem.Name="スリムToolStripMenuItem";
            スリムToolStripMenuItem.Size=new Size(126, 26);
            スリムToolStripMenuItem.Text="スリム";
            スリムToolStripMenuItem.Click+=スリムToolStripMenuItem_Click;
            // 
            // 標準ToolStripMenuItem
            // 
            標準ToolStripMenuItem.Name="標準ToolStripMenuItem";
            標準ToolStripMenuItem.Size=new Size(126, 26);
            標準ToolStripMenuItem.Text="標準";
            標準ToolStripMenuItem.Click+=標準ToolStripMenuItem_Click;
            // 
            // ヘルプToolStripMenuItem
            // 
            ヘルプToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { このアプリについてToolStripMenuItem });
            ヘルプToolStripMenuItem.Name="ヘルプToolStripMenuItem";
            ヘルプToolStripMenuItem.Size=new Size(79, 24);
            ヘルプToolStripMenuItem.Text="ヘルプ(&H)";
            // 
            // このアプリについてToolStripMenuItem
            // 
            このアプリについてToolStripMenuItem.Name="このアプリについてToolStripMenuItem";
            このアプリについてToolStripMenuItem.Size=new Size(214, 26);
            このアプリについてToolStripMenuItem.Text="このアプリについて(&A)";
            このアプリについてToolStripMenuItem.Click+=このアプリについてToolStripMenuItem_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pnlMovie);
            panel2.Controls.Add(pbThumbnail);
            panel2.Controls.Add(thumbnailDefaultPanel);
            panel2.Controls.Add(ThumnailMovoToPanel);
            panel2.Controls.Add(PageNumberLabel);
            panel2.Controls.Add(MovieTimeLabel);
            panel2.Controls.Add(pnlPage);
            panel2.Controls.Add(Label6);
            panel2.Controls.Add(pnlDispOption);
            panel2.Controls.Add(txtPDFFileName);
            panel2.Controls.Add(InPageScrollBar);
            panel2.Controls.Add(Label2);
            panel2.Controls.Add(thumbnailMoviePlayer);
            panel2.Controls.Add(SeekTrackBar);
            panel2.Location=new Point(286, 36);
            panel2.Name="panel2";
            panel2.Size=new Size(851, 570);
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
            SecondGroup.Location=new Point(286, 693);
            SecondGroup.Name="SecondGroup";
            SecondGroup.Size=new Size(491, 92);
            SecondGroup.TabIndex=104;
            SecondGroup.TabStop=false;
            SecondGroup.Text="セカンドモニター操作";
            // 
            // DisplayOfSmallButton
            // 
            DisplayOfSmallButton.Location=new Point(8, 5);
            DisplayOfSmallButton.Name="DisplayOfSmallButton";
            DisplayOfSmallButton.Size=new Size(55, 51);
            DisplayOfSmallButton.TabIndex=26;
            DisplayOfSmallButton.Text="表示";
            DisplayOfSmallButton.UseVisualStyleBackColor=true;
            DisplayOfSmallButton.Click+=DisplayOfSmallButton_Click;
            // 
            // EndOfDisplayOfSmallButton
            // 
            EndOfDisplayOfSmallButton.Location=new Point(71, 5);
            EndOfDisplayOfSmallButton.Name="EndOfDisplayOfSmallButton";
            EndOfDisplayOfSmallButton.Size=new Size(49, 51);
            EndOfDisplayOfSmallButton.TabIndex=27;
            EndOfDisplayOfSmallButton.Text="表示\r\n終了";
            EndOfDisplayOfSmallButton.UseVisualStyleBackColor=true;
            EndOfDisplayOfSmallButton.Click+=EndOfDisplayOfSmallButton_Click;
            // 
            // BackgroundDisplayOfSmallButton
            // 
            BackgroundDisplayOfSmallButton.Location=new Point(126, 5);
            BackgroundDisplayOfSmallButton.Name="BackgroundDisplayOfSmallButton";
            BackgroundDisplayOfSmallButton.Size=new Size(51, 51);
            BackgroundDisplayOfSmallButton.TabIndex=28;
            BackgroundDisplayOfSmallButton.Text="背景\r\n表示";
            BackgroundDisplayOfSmallButton.UseVisualStyleBackColor=true;
            BackgroundDisplayOfSmallButton.Click+=BackgroundDisplayOfSmallButton_Click;
            // 
            // SecondOfSmallPanel
            // 
            SecondOfSmallPanel.Controls.Add(DisplayOfSmallButton);
            SecondOfSmallPanel.Controls.Add(EndOfDisplayOfSmallButton);
            SecondOfSmallPanel.Controls.Add(BackgroundDisplayOfSmallButton);
            SecondOfSmallPanel.Location=new Point(5, 608);
            SecondOfSmallPanel.Name="SecondOfSmallPanel";
            SecondOfSmallPanel.Size=new Size(186, 70);
            SecondOfSmallPanel.TabIndex=105;
            // 
            // OperationForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1170, 843);
            Controls.Add(SecondOfSmallPanel);
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
            SecondOfSmallPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        internal Button DisplayButton;
        internal Button BackgroundDisplayButton;
        internal Button EndOfDisplayButton;
        internal Label MovieTimeLabel;
        internal Button AllFilesSelectButton;
        internal Button LastPageOfPDFButton;
        internal Button ShowWholeButton;
        internal Label PageNumberLabel;
        internal Button PreviousHalfPageOfPDFButton;
        internal Button NextHalfPageOfPDFButton;
        internal Button NextPageOfPDFButton;
        internal Button PreviousPageOfPDFButton;
        internal Button FirstPageOfPDFButton;
        internal Button GotoFirstButton;
        internal Button PauseButton;
        internal Button FastReverseButton;
        internal Button FastForwardButton;
        internal Button PlayButton;
        internal Label Label2;
        internal VScrollBar InPageScrollBar;
        internal Button FitToWindowWidthButton;
        internal Button Rotate90Button;
        internal TrackBar SeekTrackBar;
        internal Button Rotate0Button;
        internal OpenFileDialog OpenFileDialog1;
        internal CheckBox AutoDisplayCheckBox;
        internal System.Windows.Forms.Timer SeekTimer;
        internal System.ComponentModel.BackgroundWorker BackgroundWorker1;
        internal Button Rotate270Button;
        internal Button Rotate180Button;
        internal Label Label6;
        internal Button AddFilesButton;
        internal ListBox FilesList;
        internal TextBox txtPDFFileName;
        internal PictureBox pbThumbnail;
        internal Button DeselectFilesButton;
        internal Button DeleteFilesFromListButton;
        internal ViewerBy2nd.WinFormsControlLibrary.VideoPlayer thumbnailMoviePlayer;
        private Panel pnlMovie;
        private Panel pnlDispOption;
        private Panel pnlPage;
        internal Button ZoomInButton;
        private Button ZoomOutButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private ToolStripMenuItem ディスプレイと背景色ToolStripMenuItem;
        private ToolStripMenuItem ヘルプToolStripMenuItem;
        private ToolStripMenuItem このアプリについてToolStripMenuItem;
        private Panel panel2;
        private ToolStripMenuItem リストToolStripMenuItem;
        private Panel ThumnailMovoToPanel;
        private Panel thumbnailDefaultPanel;
        private GroupBox SecondGroup;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private ToolStripMenuItem リストLToolStripMenuItem;
        private ToolStripMenuItem 開くOToolStripMenuItem;
        private ToolStripMenuItem 言語LToolStripMenuItem;
        private ToolStripMenuItem ページナビゲーションToolStripMenuItem;
        private ToolStripMenuItem 次へToolStripMenuItem1;
        private ToolStripMenuItem 前のページToolStripMenuItem;
        private ToolStripMenuItem 表示を回転ToolStripMenuItem;
        private ToolStripMenuItem 元の表示ToolStripMenuItem;
        private ToolStripMenuItem 右へ90回転ToolStripMenuItem;
        private ToolStripMenuItem 左へ90回転ToolStripMenuItem;
        private ToolStripMenuItem 回転ToolStripMenuItem;
        private ToolStripMenuItem 最初のページToolStripMenuItem;
        private ToolStripMenuItem 最後のページToolStripMenuItem;
        private ToolStripMenuItem ページ指定ToolStripMenuItem;
        private ToolStripMenuItem ズームToolStripMenuItem;
        private ToolStripMenuItem ウィンドウ幅に合わせるToolStripMenuItem;
        private ToolStripMenuItem 全体を表示ToolStripMenuItem;
        private ToolStripMenuItem 拡大ToolStripMenuItem;
        private ToolStripMenuItem 縮小ToolStripMenuItem;
        private ToolStripMenuItem 再生ToolStripMenuItem;
        private ToolStripMenuItem 最初に移動ToolStripMenuItem;
        private ToolStripMenuItem 再生開始ToolStripMenuItem;
        private ToolStripMenuItem 再生停止ToolStripMenuItem;
        private ToolStripMenuItem 早送りToolStripMenuItem;
        private ToolStripMenuItem 巻き戻しToolStripMenuItem;
        private ToolStripMenuItem セカンドモニター操作ToolStripMenuItem;
        private ToolStripMenuItem 表示ToolStripMenuItem;
        private ToolStripMenuItem 表示終了ToolStripMenuItem;
        private ToolStripMenuItem 背景表示ToolStripMenuItem;
        private ToolStripMenuItem 操作中に自動表示ToolStripMenuItem;
        private ToolStripMenuItem ウインドウサイズToolStripMenuItem;
        private ToolStripMenuItem スリムToolStripMenuItem;
        private ToolStripMenuItem 標準ToolStripMenuItem;
        internal Button DisplayOfSmallButton;
        internal Button EndOfDisplayOfSmallButton;
        internal Button BackgroundDisplayOfSmallButton;
        private Panel SecondOfSmallPanel;
    }
}

