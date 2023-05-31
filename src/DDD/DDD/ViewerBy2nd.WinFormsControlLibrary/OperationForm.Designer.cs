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
            設定ToolStripMenuItem=new ToolStripMenuItem();
            ディスプレイと背景色ToolStripMenuItem=new ToolStripMenuItem();
            言語LToolStripMenuItem=new ToolStripMenuItem();
            リストの表示ToolStripMenuItem=new ToolStripMenuItem();
            リストの非表示ToolStripMenuItem=new ToolStripMenuItem();
            ヘルプToolStripMenuItem=new ToolStripMenuItem();
            このアプリについてToolStripMenuItem=new ToolStripMenuItem();
            panel2=new Panel();
            thumbnailDefaultPanel=new Panel();
            ThumnailMovoToPanel=new Panel();
            SecondGroup=new GroupBox();
            セカンドモニター操作ToolStripMenuItem=new ToolStripMenuItem();
            表示ToolStripMenuItem=new ToolStripMenuItem();
            表示終了ToolStripMenuItem=new ToolStripMenuItem();
            背景表示ToolStripMenuItem=new ToolStripMenuItem();
            操作中に自動表示ToolStripMenuItem=new ToolStripMenuItem();
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
            DisplayButton.Location=new Point(10, 20);
            DisplayButton.Margin=new Padding(3, 2, 3, 2);
            DisplayButton.Name="DisplayButton";
            DisplayButton.Size=new Size(85, 38);
            DisplayButton.TabIndex=20;
            DisplayButton.Text="表示";
            DisplayButton.UseVisualStyleBackColor=true;
            DisplayButton.Click+=DisplayButton_Click;
            // 
            // BackgroundDisplayButton
            // 
            BackgroundDisplayButton.Location=new Point(188, 20);
            BackgroundDisplayButton.Margin=new Padding(3, 2, 3, 2);
            BackgroundDisplayButton.Name="BackgroundDisplayButton";
            BackgroundDisplayButton.Size=new Size(101, 38);
            BackgroundDisplayButton.TabIndex=20;
            BackgroundDisplayButton.Text="背景表示";
            BackgroundDisplayButton.UseVisualStyleBackColor=true;
            BackgroundDisplayButton.Click+=BackgroundDisplay_Click;
            // 
            // EndOfDisplayButton
            // 
            EndOfDisplayButton.Location=new Point(103, 20);
            EndOfDisplayButton.Margin=new Padding(3, 2, 3, 2);
            EndOfDisplayButton.Name="EndOfDisplayButton";
            EndOfDisplayButton.Size=new Size(80, 38);
            EndOfDisplayButton.TabIndex=20;
            EndOfDisplayButton.Text="表示終了";
            EndOfDisplayButton.UseVisualStyleBackColor=true;
            EndOfDisplayButton.Click+=EndOfDisplayButton_Click;
            // 
            // AutoDisplayCheckBox
            // 
            AutoDisplayCheckBox.AutoSize=true;
            AutoDisplayCheckBox.FlatStyle=FlatStyle.System;
            AutoDisplayCheckBox.Location=new Point(294, 30);
            AutoDisplayCheckBox.Margin=new Padding(3, 2, 3, 2);
            AutoDisplayCheckBox.Name="AutoDisplayCheckBox";
            AutoDisplayCheckBox.Size=new Size(125, 20);
            AutoDisplayCheckBox.TabIndex=25;
            AutoDisplayCheckBox.Text="操作中に自動表示";
            AutoDisplayCheckBox.UseVisualStyleBackColor=true;
            AutoDisplayCheckBox.CheckedChanged+=AutoDisplayCheckBox_CheckedChanged;
            // 
            // MovieTimeLabel
            // 
            MovieTimeLabel.AutoSize=true;
            MovieTimeLabel.Location=new Point(500, 370);
            MovieTimeLabel.Name="MovieTimeLabel";
            MovieTimeLabel.Size=new Size(56, 15);
            MovieTimeLabel.TabIndex=95;
            MovieTimeLabel.Text="-- time --";
            // 
            // AllFilesSelectButton
            // 
            AllFilesSelectButton.Location=new Point(4, 456);
            AllFilesSelectButton.Margin=new Padding(3, 2, 3, 2);
            AllFilesSelectButton.Name="AllFilesSelectButton";
            AllFilesSelectButton.Size=new Size(60, 30);
            AllFilesSelectButton.TabIndex=94;
            AllFilesSelectButton.Text="全選択";
            AllFilesSelectButton.UseVisualStyleBackColor=true;
            AllFilesSelectButton.Click+=AllFilesSelectButton_Click;
            // 
            // LastPageOfPDFButton
            // 
            LastPageOfPDFButton.Location=new Point(172, 2);
            LastPageOfPDFButton.Margin=new Padding(3, 2, 3, 2);
            LastPageOfPDFButton.Name="LastPageOfPDFButton";
            LastPageOfPDFButton.Size=new Size(53, 34);
            LastPageOfPDFButton.TabIndex=93;
            LastPageOfPDFButton.Text="最後へ";
            LastPageOfPDFButton.UseVisualStyleBackColor=true;
            LastPageOfPDFButton.Click+=LastPageOfPDF_Click;
            // 
            // ShowWholeButton
            // 
            ShowWholeButton.Location=new Point(144, 92);
            ShowWholeButton.Margin=new Padding(3, 2, 3, 2);
            ShowWholeButton.Name="ShowWholeButton";
            ShowWholeButton.Size=new Size(80, 34);
            ShowWholeButton.TabIndex=92;
            ShowWholeButton.Text="全体を表示";
            ShowWholeButton.UseVisualStyleBackColor=true;
            ShowWholeButton.Click+=ShowWholeButton_Click;
            // 
            // PageNumberLabel
            // 
            PageNumberLabel.Location=new Point(416, 345);
            PageNumberLabel.Name="PageNumberLabel";
            PageNumberLabel.Size=new Size(234, 15);
            PageNumberLabel.TabIndex=91;
            PageNumberLabel.Text="- page -";
            PageNumberLabel.Click+=PageNumberLabel_Click;
            // 
            // PreviousHalfPageOfPDFButton
            // 
            PreviousHalfPageOfPDFButton.Location=new Point(12, 39);
            PreviousHalfPageOfPDFButton.Margin=new Padding(3, 2, 3, 2);
            PreviousHalfPageOfPDFButton.Name="PreviousHalfPageOfPDFButton";
            PreviousHalfPageOfPDFButton.Size=new Size(105, 34);
            PreviousHalfPageOfPDFButton.TabIndex=89;
            PreviousHalfPageOfPDFButton.Text="0.5ページ前へ";
            PreviousHalfPageOfPDFButton.UseVisualStyleBackColor=true;
            PreviousHalfPageOfPDFButton.Click+=PreviousHalfPageOfPdfButton_Click;
            // 
            // NextHalfPageOfPDFButton
            // 
            NextHalfPageOfPDFButton.Location=new Point(122, 39);
            NextHalfPageOfPDFButton.Margin=new Padding(3, 2, 3, 2);
            NextHalfPageOfPDFButton.Name="NextHalfPageOfPDFButton";
            NextHalfPageOfPDFButton.Size=new Size(105, 34);
            NextHalfPageOfPDFButton.TabIndex=90;
            NextHalfPageOfPDFButton.Text="0.5ページ先へ";
            NextHalfPageOfPDFButton.UseVisualStyleBackColor=true;
            NextHalfPageOfPDFButton.Click+=NextHalfPageOfPDFButton_Click;
            // 
            // NextPageOfPDFButton
            // 
            NextPageOfPDFButton.Location=new Point(123, 2);
            NextPageOfPDFButton.Margin=new Padding(3, 2, 3, 2);
            NextPageOfPDFButton.Name="NextPageOfPDFButton";
            NextPageOfPDFButton.Size=new Size(44, 34);
            NextPageOfPDFButton.TabIndex=86;
            NextPageOfPDFButton.Text="次へ";
            NextPageOfPDFButton.UseVisualStyleBackColor=true;
            NextPageOfPDFButton.Click+=NextPageOfPDF_Click;
            // 
            // PreviousPageOfPDFButton
            // 
            PreviousPageOfPDFButton.Location=new Point(74, 2);
            PreviousPageOfPDFButton.Margin=new Padding(3, 2, 3, 2);
            PreviousPageOfPDFButton.Name="PreviousPageOfPDFButton";
            PreviousPageOfPDFButton.Size=new Size(44, 34);
            PreviousPageOfPDFButton.TabIndex=87;
            PreviousPageOfPDFButton.Text="前へ";
            PreviousPageOfPDFButton.UseVisualStyleBackColor=true;
            PreviousPageOfPDFButton.Click+=PreviousPageOfPDFButton_Click;
            // 
            // FirstPageOfPDFButton
            // 
            FirstPageOfPDFButton.Location=new Point(10, 2);
            FirstPageOfPDFButton.Margin=new Padding(3, 2, 3, 2);
            FirstPageOfPDFButton.Name="FirstPageOfPDFButton";
            FirstPageOfPDFButton.Size=new Size(59, 34);
            FirstPageOfPDFButton.TabIndex=88;
            FirstPageOfPDFButton.Text="最初へ";
            FirstPageOfPDFButton.UseVisualStyleBackColor=true;
            FirstPageOfPDFButton.Click+=FirstPageOfPDFButton_Click;
            // 
            // GotoFirstButton
            // 
            GotoFirstButton.Location=new Point(5, 14);
            GotoFirstButton.Margin=new Padding(3, 2, 3, 2);
            GotoFirstButton.Name="GotoFirstButton";
            GotoFirstButton.Size=new Size(45, 45);
            GotoFirstButton.TabIndex=80;
            GotoFirstButton.Text="先頭";
            GotoFirstButton.UseVisualStyleBackColor=true;
            GotoFirstButton.Click+=GotoFirstButton_Click;
            // 
            // PauseButton
            // 
            PauseButton.Location=new Point(194, 14);
            PauseButton.Margin=new Padding(3, 2, 3, 2);
            PauseButton.Name="PauseButton";
            PauseButton.Size=new Size(45, 45);
            PauseButton.TabIndex=81;
            PauseButton.Text="||";
            PauseButton.UseVisualStyleBackColor=true;
            PauseButton.Click+=PauseButton_Click;
            // 
            // FastReverseButton
            // 
            FastReverseButton.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            FastReverseButton.Location=new Point(51, 14);
            FastReverseButton.Margin=new Padding(3, 2, 3, 2);
            FastReverseButton.Name="FastReverseButton";
            FastReverseButton.Size=new Size(45, 45);
            FastReverseButton.TabIndex=82;
            FastReverseButton.Text="◀";
            FastReverseButton.UseVisualStyleBackColor=true;
            FastReverseButton.Click+=FastReverseButton_Click;
            // 
            // FastForwardButton
            // 
            FastForwardButton.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            FastForwardButton.Location=new Point(146, 14);
            FastForwardButton.Margin=new Padding(3, 2, 3, 2);
            FastForwardButton.Name="FastForwardButton";
            FastForwardButton.Size=new Size(45, 45);
            FastForwardButton.TabIndex=83;
            FastForwardButton.Text="▶▶";
            FastForwardButton.UseVisualStyleBackColor=true;
            FastForwardButton.Click+=FastForwardButton_Click;
            // 
            // PlayButton
            // 
            PlayButton.Font=new Font("MS UI Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            PlayButton.Location=new Point(98, 14);
            PlayButton.Margin=new Padding(3, 2, 3, 2);
            PlayButton.Name="PlayButton";
            PlayButton.Size=new Size(45, 45);
            PlayButton.TabIndex=84;
            PlayButton.Text="▶";
            PlayButton.UseVisualStyleBackColor=true;
            PlayButton.Click+=PlayButton_Click;
            // 
            // Label2
            // 
            Label2.AutoSize=true;
            Label2.Location=new Point(444, 31);
            Label2.Name="Label2";
            Label2.Size=new Size(72, 15);
            Label2.TabIndex=79;
            Label2.Text="表示プレビュー";
            // 
            // InPageScrollBar
            // 
            InPageScrollBar.Location=new Point(716, 35);
            InPageScrollBar.Name="InPageScrollBar";
            InPageScrollBar.Size=new Size(23, 300);
            InPageScrollBar.TabIndex=78;
            InPageScrollBar.Scroll+=VScrollBar1_Scroll;
            // 
            // FitToWindowWidthButton
            // 
            FitToWindowWidthButton.Location=new Point(2, 92);
            FitToWindowWidthButton.Margin=new Padding(3, 2, 3, 2);
            FitToWindowWidthButton.Name="FitToWindowWidthButton";
            FitToWindowWidthButton.Size=new Size(136, 34);
            FitToWindowWidthButton.TabIndex=76;
            FitToWindowWidthButton.Text="ウィンドウ幅に合わせる";
            FitToWindowWidthButton.UseVisualStyleBackColor=true;
            FitToWindowWidthButton.Click+=FitToWindowWidthButton_Click;
            // 
            // Rotate90Button
            // 
            Rotate90Button.Location=new Point(130, 27);
            Rotate90Button.Margin=new Padding(3, 2, 3, 2);
            Rotate90Button.Name="Rotate90Button";
            Rotate90Button.Size=new Size(61, 38);
            Rotate90Button.TabIndex=72;
            Rotate90Button.Text="右90度";
            Rotate90Button.UseVisualStyleBackColor=true;
            Rotate90Button.Click+=Rotate90Button_Click;
            // 
            // SeekTrackBar
            // 
            SeekTrackBar.Location=new Point(391, 345);
            SeekTrackBar.Margin=new Padding(3, 2, 3, 2);
            SeekTrackBar.Name="SeekTrackBar";
            SeekTrackBar.Size=new Size(277, 45);
            SeekTrackBar.TabIndex=85;
            SeekTrackBar.Scroll+=SeekTrackBar_Scroll;
            SeekTrackBar.MouseDown+=SeekTrackBar_MouseDown;
            // 
            // Rotate0Button
            // 
            Rotate0Button.Location=new Point(73, 0);
            Rotate0Button.Margin=new Padding(3, 2, 3, 2);
            Rotate0Button.Name="Rotate0Button";
            Rotate0Button.Size=new Size(52, 38);
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
            Rotate270Button.Location=new Point(6, 27);
            Rotate270Button.Margin=new Padding(3, 2, 3, 2);
            Rotate270Button.Name="Rotate270Button";
            Rotate270Button.Size=new Size(61, 38);
            Rotate270Button.TabIndex=74;
            Rotate270Button.Text="左90度";
            Rotate270Button.UseVisualStyleBackColor=true;
            Rotate270Button.Click+=Rotate270Button_Click;
            // 
            // Rotate180Button
            // 
            Rotate180Button.Location=new Point(73, 50);
            Rotate180Button.Margin=new Padding(3, 2, 3, 2);
            Rotate180Button.Name="Rotate180Button";
            Rotate180Button.Size=new Size(52, 38);
            Rotate180Button.TabIndex=75;
            Rotate180Button.Text="180度回転";
            Rotate180Button.UseVisualStyleBackColor=true;
            Rotate180Button.Click+=Rotate180Button_Click;
            // 
            // Label6
            // 
            Label6.AutoSize=true;
            Label6.Location=new Point(10, 10);
            Label6.Name="Label6";
            Label6.Size=new Size(65, 15);
            Label6.TabIndex=71;
            Label6.Text="ファイル情報";
            // 
            // AddFilesButton
            // 
            AddFilesButton.Location=new Point(140, 456);
            AddFilesButton.Margin=new Padding(3, 2, 3, 2);
            AddFilesButton.Name="AddFilesButton";
            AddFilesButton.Size=new Size(88, 30);
            AddFilesButton.TabIndex=70;
            AddFilesButton.Text="ファイルを追加";
            AddFilesButton.UseVisualStyleBackColor=true;
            AddFilesButton.Click+=AddFilesButton_Click;
            // 
            // FilesList
            // 
            FilesList.AllowDrop=true;
            FilesList.FormattingEnabled=true;
            FilesList.ItemHeight=15;
            FilesList.Location=new Point(4, 27);
            FilesList.Margin=new Padding(26, 22, 26, 22);
            FilesList.Name="FilesList";
            FilesList.SelectionMode=SelectionMode.MultiExtended;
            FilesList.Size=new Size(224, 424);
            FilesList.TabIndex=67;
            FilesList.Click+=FilesList_Click;
            FilesList.SelectedValueChanged+=FilesList_SelectedValueChanged;
            FilesList.DragDrop+=FilesList_DragDrop;
            FilesList.DragEnter+=FilesList_DragEnter;
            // 
            // txtPDFFileName
            // 
            txtPDFFileName.Location=new Point(80, 4);
            txtPDFFileName.Margin=new Padding(3, 2, 3, 2);
            txtPDFFileName.Name="txtPDFFileName";
            txtPDFFileName.ReadOnly=true;
            txtPDFFileName.Size=new Size(574, 23);
            txtPDFFileName.TabIndex=65;
            // 
            // pbThumbnail
            // 
            pbThumbnail.BackColor=Color.Red;
            pbThumbnail.Location=new Point(701, 361);
            pbThumbnail.Margin=new Padding(3, 2, 3, 2);
            pbThumbnail.Name="pbThumbnail";
            pbThumbnail.Size=new Size(21, 24);
            pbThumbnail.TabIndex=77;
            pbThumbnail.TabStop=false;
            // 
            // DeselectFilesButton
            // 
            DeselectFilesButton.Location=new Point(70, 456);
            DeselectFilesButton.Margin=new Padding(3, 2, 3, 2);
            DeselectFilesButton.Name="DeselectFilesButton";
            DeselectFilesButton.Size=new Size(67, 30);
            DeselectFilesButton.TabIndex=68;
            DeselectFilesButton.Text="選択解除";
            DeselectFilesButton.UseVisualStyleBackColor=true;
            DeselectFilesButton.Click+=DeselectFiles_Click;
            // 
            // DeleteFilesFromListButton
            // 
            DeleteFilesFromListButton.Location=new Point(25, 490);
            DeleteFilesFromListButton.Margin=new Padding(3, 2, 3, 2);
            DeleteFilesFromListButton.Name="DeleteFilesFromListButton";
            DeleteFilesFromListButton.Size=new Size(77, 30);
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
            pnlMovie.Location=new Point(6, 28);
            pnlMovie.Name="pnlMovie";
            pnlMovie.Size=new Size(244, 75);
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
            pnlDispOption.Location=new Point(4, 34);
            pnlDispOption.Name="pnlDispOption";
            pnlDispOption.Size=new Size(234, 168);
            pnlDispOption.TabIndex=99;
            // 
            // ZoomOutButton
            // 
            ZoomOutButton.Location=new Point(110, 130);
            ZoomOutButton.Name="ZoomOutButton";
            ZoomOutButton.Size=new Size(96, 34);
            ZoomOutButton.TabIndex=93;
            ZoomOutButton.Text="縮小";
            ZoomOutButton.UseVisualStyleBackColor=true;
            ZoomOutButton.Click+=ZoomOutButton_Click;
            // 
            // ZoomInButton
            // 
            ZoomInButton.Location=new Point(3, 130);
            ZoomInButton.Margin=new Padding(3, 2, 3, 2);
            ZoomInButton.Name="ZoomInButton";
            ZoomInButton.Size=new Size(96, 34);
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
            pnlPage.Location=new Point(7, 203);
            pnlPage.Name="pnlPage";
            pnlPage.Size=new Size(229, 78);
            pnlPage.TabIndex=100;
            // 
            // thumbnailMoviePlayer
            // 
            thumbnailMoviePlayer.BackColor=Color.FromArgb(192, 0, 0);
            thumbnailMoviePlayer.Location=new Point(670, 361);
            thumbnailMoviePlayer.Margin=new Padding(3, 2, 3, 2);
            thumbnailMoviePlayer.Name="thumbnailMoviePlayer";
            thumbnailMoviePlayer.Rate=-1F;
            thumbnailMoviePlayer.Size=new Size(25, 24);
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
            menuStrip1.Padding=new Padding(5, 2, 0, 2);
            menuStrip1.Size=new Size(1024, 24);
            menuStrip1.TabIndex=101;
            menuStrip1.Text="menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            ファイルToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { リストLToolStripMenuItem, 開くOToolStripMenuItem });
            ファイルToolStripMenuItem.Name="ファイルToolStripMenuItem";
            ファイルToolStripMenuItem.Size=new Size(67, 20);
            ファイルToolStripMenuItem.Text="ファイル(&F)";
            // 
            // リストLToolStripMenuItem
            // 
            リストLToolStripMenuItem.Name="リストLToolStripMenuItem";
            リストLToolStripMenuItem.Size=new Size(176, 22);
            リストLToolStripMenuItem.Text="リスト(&L)";
            // 
            // 開くOToolStripMenuItem
            // 
            開くOToolStripMenuItem.Name="開くOToolStripMenuItem";
            開くOToolStripMenuItem.Size=new Size(176, 22);
            開くOToolStripMenuItem.Text="開く(リストに追加)(&O)";
            開くOToolStripMenuItem.Click+=開くOToolStripMenuItem_Click;
            // 
            // リストToolStripMenuItem
            // 
            リストToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 表示を回転ToolStripMenuItem, ページナビゲーションToolStripMenuItem, ズームToolStripMenuItem, 再生ToolStripMenuItem, セカンドモニター操作ToolStripMenuItem });
            リストToolStripMenuItem.Name="リストToolStripMenuItem";
            リストToolStripMenuItem.Size=new Size(58, 20);
            リストToolStripMenuItem.Text="表示(&V)";
            // 
            // 表示を回転ToolStripMenuItem
            // 
            表示を回転ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 元の表示ToolStripMenuItem, 右へ90回転ToolStripMenuItem, 左へ90回転ToolStripMenuItem, 回転ToolStripMenuItem });
            表示を回転ToolStripMenuItem.Name="表示を回転ToolStripMenuItem";
            表示を回転ToolStripMenuItem.Size=new Size(180, 22);
            表示を回転ToolStripMenuItem.Text="表示を回転";
            表示を回転ToolStripMenuItem.Click+=次へToolStripMenuItem_Click;
            // 
            // 元の表示ToolStripMenuItem
            // 
            元の表示ToolStripMenuItem.Name="元の表示ToolStripMenuItem";
            元の表示ToolStripMenuItem.Size=new Size(137, 22);
            元の表示ToolStripMenuItem.Text="元の表示";
            元の表示ToolStripMenuItem.Click+=元の表示ToolStripMenuItem_Click;
            // 
            // 右へ90回転ToolStripMenuItem
            // 
            右へ90回転ToolStripMenuItem.Name="右へ90回転ToolStripMenuItem";
            右へ90回転ToolStripMenuItem.Size=new Size(137, 22);
            右へ90回転ToolStripMenuItem.Text="右へ90°回転";
            右へ90回転ToolStripMenuItem.Click+=右へ90回転ToolStripMenuItem_Click;
            // 
            // 左へ90回転ToolStripMenuItem
            // 
            左へ90回転ToolStripMenuItem.Name="左へ90回転ToolStripMenuItem";
            左へ90回転ToolStripMenuItem.Size=new Size(137, 22);
            左へ90回転ToolStripMenuItem.Text="左へ90°回転";
            左へ90回転ToolStripMenuItem.Click+=左へ90回転ToolStripMenuItem_Click;
            // 
            // 回転ToolStripMenuItem
            // 
            回転ToolStripMenuItem.Name="回転ToolStripMenuItem";
            回転ToolStripMenuItem.Size=new Size(137, 22);
            回転ToolStripMenuItem.Text="180°回転";
            回転ToolStripMenuItem.Click+=回転ToolStripMenuItem_Click;
            // 
            // ページナビゲーションToolStripMenuItem
            // 
            ページナビゲーションToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 最初のページToolStripMenuItem, 次へToolStripMenuItem1, 前のページToolStripMenuItem, 最後のページToolStripMenuItem, ページ指定ToolStripMenuItem });
            ページナビゲーションToolStripMenuItem.Name="ページナビゲーションToolStripMenuItem";
            ページナビゲーションToolStripMenuItem.Size=new Size(180, 22);
            ページナビゲーションToolStripMenuItem.Text="ページナビゲーション";
            // 
            // 最初のページToolStripMenuItem
            // 
            最初のページToolStripMenuItem.Name="最初のページToolStripMenuItem";
            最初のページToolStripMenuItem.Size=new Size(136, 22);
            最初のページToolStripMenuItem.Text="最初のページ";
            最初のページToolStripMenuItem.Click+=最初のページToolStripMenuItem_Click;
            // 
            // 次へToolStripMenuItem1
            // 
            次へToolStripMenuItem1.Name="次へToolStripMenuItem1";
            次へToolStripMenuItem1.Size=new Size(136, 22);
            次へToolStripMenuItem1.Text="次のページ";
            次へToolStripMenuItem1.Click+=次へToolStripMenuItem1_Click;
            // 
            // 前のページToolStripMenuItem
            // 
            前のページToolStripMenuItem.Name="前のページToolStripMenuItem";
            前のページToolStripMenuItem.Size=new Size(136, 22);
            前のページToolStripMenuItem.Text="前のページ";
            前のページToolStripMenuItem.Click+=前のページToolStripMenuItem_Click;
            // 
            // 最後のページToolStripMenuItem
            // 
            最後のページToolStripMenuItem.Name="最後のページToolStripMenuItem";
            最後のページToolStripMenuItem.Size=new Size(136, 22);
            最後のページToolStripMenuItem.Text="最後のページ";
            最後のページToolStripMenuItem.Click+=最後のページToolStripMenuItem_Click;
            // 
            // ページ指定ToolStripMenuItem
            // 
            ページ指定ToolStripMenuItem.Name="ページ指定ToolStripMenuItem";
            ページ指定ToolStripMenuItem.Size=new Size(136, 22);
            ページ指定ToolStripMenuItem.Text="ページ指定";
            ページ指定ToolStripMenuItem.Click+=ページ指定ToolStripMenuItem_Click;
            // 
            // ズームToolStripMenuItem
            // 
            ズームToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ウィンドウ幅に合わせるToolStripMenuItem, 全体を表示ToolStripMenuItem, 拡大ToolStripMenuItem, 縮小ToolStripMenuItem });
            ズームToolStripMenuItem.Name="ズームToolStripMenuItem";
            ズームToolStripMenuItem.Size=new Size(180, 22);
            ズームToolStripMenuItem.Text="ズーム";
            // 
            // ウィンドウ幅に合わせるToolStripMenuItem
            // 
            ウィンドウ幅に合わせるToolStripMenuItem.Name="ウィンドウ幅に合わせるToolStripMenuItem";
            ウィンドウ幅に合わせるToolStripMenuItem.Size=new Size(178, 22);
            ウィンドウ幅に合わせるToolStripMenuItem.Text="ウィンドウ幅に合わせる";
            ウィンドウ幅に合わせるToolStripMenuItem.Click+=ウィンドウ幅に合わせるToolStripMenuItem_Click;
            // 
            // 全体を表示ToolStripMenuItem
            // 
            全体を表示ToolStripMenuItem.Name="全体を表示ToolStripMenuItem";
            全体を表示ToolStripMenuItem.Size=new Size(178, 22);
            全体を表示ToolStripMenuItem.Text="全体を表示";
            全体を表示ToolStripMenuItem.Click+=全体を表示ToolStripMenuItem_Click;
            // 
            // 拡大ToolStripMenuItem
            // 
            拡大ToolStripMenuItem.Name="拡大ToolStripMenuItem";
            拡大ToolStripMenuItem.Size=new Size(178, 22);
            拡大ToolStripMenuItem.Text="拡大";
            拡大ToolStripMenuItem.Click+=拡大ToolStripMenuItem_Click;
            // 
            // 縮小ToolStripMenuItem
            // 
            縮小ToolStripMenuItem.Name="縮小ToolStripMenuItem";
            縮小ToolStripMenuItem.Size=new Size(178, 22);
            縮小ToolStripMenuItem.Text="縮小";
            縮小ToolStripMenuItem.Click+=縮小ToolStripMenuItem_Click;
            // 
            // 再生ToolStripMenuItem
            // 
            再生ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 最初に移動ToolStripMenuItem, 再生開始ToolStripMenuItem, 再生停止ToolStripMenuItem, 早送りToolStripMenuItem, 巻き戻しToolStripMenuItem });
            再生ToolStripMenuItem.Name="再生ToolStripMenuItem";
            再生ToolStripMenuItem.Size=new Size(180, 22);
            再生ToolStripMenuItem.Text="再生";
            // 
            // 最初に移動ToolStripMenuItem
            // 
            最初に移動ToolStripMenuItem.Name="最初に移動ToolStripMenuItem";
            最初に移動ToolStripMenuItem.Size=new Size(131, 22);
            最初に移動ToolStripMenuItem.Text="最初に移動";
            最初に移動ToolStripMenuItem.Click+=最初に移動ToolStripMenuItem_Click;
            // 
            // 再生開始ToolStripMenuItem
            // 
            再生開始ToolStripMenuItem.Name="再生開始ToolStripMenuItem";
            再生開始ToolStripMenuItem.Size=new Size(131, 22);
            再生開始ToolStripMenuItem.Text="再生開始";
            再生開始ToolStripMenuItem.Click+=再生開始ToolStripMenuItem_Click;
            // 
            // 再生停止ToolStripMenuItem
            // 
            再生停止ToolStripMenuItem.Name="再生停止ToolStripMenuItem";
            再生停止ToolStripMenuItem.Size=new Size(131, 22);
            再生停止ToolStripMenuItem.Text="一時停止";
            再生停止ToolStripMenuItem.Click+=再生停止ToolStripMenuItem_Click;
            // 
            // 早送りToolStripMenuItem
            // 
            早送りToolStripMenuItem.Name="早送りToolStripMenuItem";
            早送りToolStripMenuItem.Size=new Size(131, 22);
            早送りToolStripMenuItem.Text="早送り";
            早送りToolStripMenuItem.Click+=早送りToolStripMenuItem_Click;
            // 
            // 巻き戻しToolStripMenuItem
            // 
            巻き戻しToolStripMenuItem.Name="巻き戻しToolStripMenuItem";
            巻き戻しToolStripMenuItem.Size=new Size(131, 22);
            巻き戻しToolStripMenuItem.Text="巻き戻し";
            巻き戻しToolStripMenuItem.Click+=巻き戻しToolStripMenuItem_Click;
            // 
            // 設定ToolStripMenuItem
            // 
            設定ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ディスプレイと背景色ToolStripMenuItem, 言語LToolStripMenuItem, リストの表示ToolStripMenuItem, リストの非表示ToolStripMenuItem });
            設定ToolStripMenuItem.Name="設定ToolStripMenuItem";
            設定ToolStripMenuItem.Size=new Size(57, 20);
            設定ToolStripMenuItem.Text="設定(&S)";
            // 
            // ディスプレイと背景色ToolStripMenuItem
            // 
            ディスプレイと背景色ToolStripMenuItem.Name="ディスプレイと背景色ToolStripMenuItem";
            ディスプレイと背景色ToolStripMenuItem.Size=new Size(171, 22);
            ディスプレイと背景色ToolStripMenuItem.Text="ディスプレイと背景色";
            ディスプレイと背景色ToolStripMenuItem.Click+=ディスプレイと背景色ToolStripMenuItem_Click;
            // 
            // 言語LToolStripMenuItem
            // 
            言語LToolStripMenuItem.Name="言語LToolStripMenuItem";
            言語LToolStripMenuItem.Size=new Size(171, 22);
            言語LToolStripMenuItem.Text="言語(&L)";
            // 
            // リストの表示ToolStripMenuItem
            // 
            リストの表示ToolStripMenuItem.Name="リストの表示ToolStripMenuItem";
            リストの表示ToolStripMenuItem.Size=new Size(171, 22);
            リストの表示ToolStripMenuItem.Text="リストの表示";
            リストの表示ToolStripMenuItem.Click+=リストの表示ToolStripMenuItem_Click;
            // 
            // リストの非表示ToolStripMenuItem
            // 
            リストの非表示ToolStripMenuItem.Name="リストの非表示ToolStripMenuItem";
            リストの非表示ToolStripMenuItem.Size=new Size(171, 22);
            リストの非表示ToolStripMenuItem.Text="リストの非表示";
            リストの非表示ToolStripMenuItem.Click+=リストの非表示ToolStripMenuItem_Click;
            // 
            // ヘルプToolStripMenuItem
            // 
            ヘルプToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { このアプリについてToolStripMenuItem });
            ヘルプToolStripMenuItem.Name="ヘルプToolStripMenuItem";
            ヘルプToolStripMenuItem.Size=new Size(65, 20);
            ヘルプToolStripMenuItem.Text="ヘルプ(&H)";
            // 
            // このアプリについてToolStripMenuItem
            // 
            このアプリについてToolStripMenuItem.Name="このアプリについてToolStripMenuItem";
            このアプリについてToolStripMenuItem.Size=new Size(171, 22);
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
            panel2.Location=new Point(250, 27);
            panel2.Margin=new Padding(3, 2, 3, 2);
            panel2.Name="panel2";
            panel2.Size=new Size(745, 416);
            panel2.TabIndex=103;
            // 
            // thumbnailDefaultPanel
            // 
            thumbnailDefaultPanel.BackColor=Color.FromArgb(0, 0, 192);
            thumbnailDefaultPanel.Location=new Point(250, 48);
            thumbnailDefaultPanel.Margin=new Padding(3, 2, 3, 2);
            thumbnailDefaultPanel.Name="thumbnailDefaultPanel";
            thumbnailDefaultPanel.Size=new Size(461, 295);
            thumbnailDefaultPanel.TabIndex=102;
            thumbnailDefaultPanel.Visible=false;
            // 
            // ThumnailMovoToPanel
            // 
            ThumnailMovoToPanel.BackColor=Color.FromArgb(0, 0, 192);
            ThumnailMovoToPanel.Location=new Point(14, 284);
            ThumnailMovoToPanel.Margin=new Padding(3, 2, 3, 2);
            ThumnailMovoToPanel.Name="ThumnailMovoToPanel";
            ThumnailMovoToPanel.Size=new Size(219, 121);
            ThumnailMovoToPanel.TabIndex=101;
            ThumnailMovoToPanel.Visible=false;
            // 
            // SecondGroup
            // 
            SecondGroup.Controls.Add(DisplayButton);
            SecondGroup.Controls.Add(AutoDisplayCheckBox);
            SecondGroup.Controls.Add(EndOfDisplayButton);
            SecondGroup.Controls.Add(BackgroundDisplayButton);
            SecondGroup.Location=new Point(250, 520);
            SecondGroup.Margin=new Padding(3, 2, 3, 2);
            SecondGroup.Name="SecondGroup";
            SecondGroup.Padding=new Padding(3, 2, 3, 2);
            SecondGroup.Size=new Size(430, 69);
            SecondGroup.TabIndex=104;
            SecondGroup.TabStop=false;
            SecondGroup.Text="セカンドモニター操作";
            // 
            // セカンドモニター操作ToolStripMenuItem
            // 
            セカンドモニター操作ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 表示ToolStripMenuItem, 表示終了ToolStripMenuItem, 背景表示ToolStripMenuItem, 操作中に自動表示ToolStripMenuItem });
            セカンドモニター操作ToolStripMenuItem.Name="セカンドモニター操作ToolStripMenuItem";
            セカンドモニター操作ToolStripMenuItem.Size=new Size(180, 22);
            セカンドモニター操作ToolStripMenuItem.Text="セカンドモニター操作";
            // 
            // 表示ToolStripMenuItem
            // 
            表示ToolStripMenuItem.Name="表示ToolStripMenuItem";
            表示ToolStripMenuItem.Size=new Size(180, 22);
            表示ToolStripMenuItem.Text="表示";
            // 
            // 表示終了ToolStripMenuItem
            // 
            表示終了ToolStripMenuItem.Name="表示終了ToolStripMenuItem";
            表示終了ToolStripMenuItem.Size=new Size(180, 22);
            表示終了ToolStripMenuItem.Text="表示終了";
            // 
            // 背景表示ToolStripMenuItem
            // 
            背景表示ToolStripMenuItem.Name="背景表示ToolStripMenuItem";
            背景表示ToolStripMenuItem.Size=new Size(180, 22);
            背景表示ToolStripMenuItem.Text="背景表示";
            // 
            // 操作中に自動表示ToolStripMenuItem
            // 
            操作中に自動表示ToolStripMenuItem.Name="操作中に自動表示ToolStripMenuItem";
            操作中に自動表示ToolStripMenuItem.Size=new Size(180, 22);
            操作中に自動表示ToolStripMenuItem.Text="操作中に自動表示";
            // 
            // OperationForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1024, 632);
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
        private ToolStripMenuItem リストの表示ToolStripMenuItem;
        private ToolStripMenuItem リストの非表示ToolStripMenuItem;
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
    }
}

