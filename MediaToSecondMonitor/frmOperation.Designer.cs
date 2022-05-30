namespace MediaToSecondMonitor
{
    partial class frmOperation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDisplay = new System.Windows.Forms.ComboBox();
            this.lstPDFFiles = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFileAdd = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbcFileOpes = new System.Windows.Forms.TabControl();
            this.tpAdobePDF = new System.Windows.Forms.TabPage();
            this.ctlPDF2 = new MediaToSecondMonitor.ctlPDF();
            this.tpImage = new System.Windows.Forms.TabPage();
            this.ctlImage2 = new MediaToSecondMonitor.ctlImage();
            this.tpMediaPlayer = new System.Windows.Forms.TabPage();
            this.ctlMovie2 = new MediaToSecondMonitor.ctlMovie();
            this.btnUnSelect = new System.Windows.Forms.Button();
            this.txtPDFFileName = new System.Windows.Forms.TextBox();
            this.ファイル情報 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tbcFileOpes.SuspendLayout();
            this.tpAdobePDF.SuspendLayout();
            this.tpImage.SuspendLayout();
            this.tpMediaPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDisplay);
            this.groupBox1.Location = new System.Drawing.Point(31, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(916, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "表示するディスプレイ";
            // 
            // cmbDisplay
            // 
            this.cmbDisplay.AllowDrop = true;
            this.cmbDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisplay.FormattingEnabled = true;
            this.cmbDisplay.Location = new System.Drawing.Point(202, 25);
            this.cmbDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDisplay.Name = "cmbDisplay";
            this.cmbDisplay.Size = new System.Drawing.Size(150, 26);
            this.cmbDisplay.TabIndex = 0;
            this.cmbDisplay.SelectedIndexChanged += new System.EventHandler(this.cmbDisplay_SelectedIndexChanged);
            // 
            // lstPDFFiles
            // 
            this.lstPDFFiles.FormattingEnabled = true;
            this.lstPDFFiles.ItemHeight = 18;
            this.lstPDFFiles.Location = new System.Drawing.Point(74, 186);
            this.lstPDFFiles.Margin = new System.Windows.Forms.Padding(4);
            this.lstPDFFiles.Name = "lstPDFFiles";
            this.lstPDFFiles.Size = new System.Drawing.Size(149, 148);
            this.lstPDFFiles.TabIndex = 1;
            this.lstPDFFiles.Click += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstPDFFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstPDFFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstPDFFiles_DragDrop);
            this.lstPDFFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstPDFFiles_DragEnter);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(56, 365);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFileAdd
            // 
            this.btnFileAdd.Location = new System.Drawing.Point(158, 365);
            this.btnFileAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnFileAdd.Name = "btnFileAdd";
            this.btnFileAdd.Size = new System.Drawing.Size(126, 28);
            this.btnFileAdd.TabIndex = 2;
            this.btnFileAdd.Text = "ファイルを追加";
            this.btnFileAdd.UseVisualStyleBackColor = true;
            this.btnFileAdd.Click += new System.EventHandler(this.btnFileAdd_Click);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "openFileDialog1";
            // 
            // tbcFileOpes
            // 
            this.tbcFileOpes.Controls.Add(this.tpAdobePDF);
            this.tbcFileOpes.Controls.Add(this.tpImage);
            this.tbcFileOpes.Controls.Add(this.tpMediaPlayer);
            this.tbcFileOpes.Location = new System.Drawing.Point(342, 148);
            this.tbcFileOpes.Margin = new System.Windows.Forms.Padding(4);
            this.tbcFileOpes.Name = "tbcFileOpes";
            this.tbcFileOpes.SelectedIndex = 0;
            this.tbcFileOpes.Size = new System.Drawing.Size(642, 313);
            this.tbcFileOpes.TabIndex = 3;
            // 
            // tpAdobePDF
            // 
            this.tpAdobePDF.Controls.Add(this.ctlPDF2);
            this.tpAdobePDF.Location = new System.Drawing.Point(4, 28);
            this.tpAdobePDF.Margin = new System.Windows.Forms.Padding(4);
            this.tpAdobePDF.Name = "tpAdobePDF";
            this.tpAdobePDF.Padding = new System.Windows.Forms.Padding(4);
            this.tpAdobePDF.Size = new System.Drawing.Size(634, 281);
            this.tpAdobePDF.TabIndex = 0;
            this.tpAdobePDF.Text = "PDFの操作";
            this.tpAdobePDF.UseVisualStyleBackColor = true;
            // 
            // ctlPDF2
            // 
            this.ctlPDF2.IsHalf = false;
            this.ctlPDF2.Location = new System.Drawing.Point(32, 44);
            this.ctlPDF2.Margin = new System.Windows.Forms.Padding(5);
            this.ctlPDF2.Name = "ctlPDF2";
            this.ctlPDF2.Size = new System.Drawing.Size(675, 180);
            this.ctlPDF2.TabIndex = 0;
            // 
            // tpImage
            // 
            this.tpImage.Controls.Add(this.ctlImage2);
            this.tpImage.Location = new System.Drawing.Point(4, 28);
            this.tpImage.Margin = new System.Windows.Forms.Padding(4);
            this.tpImage.Name = "tpImage";
            this.tpImage.Padding = new System.Windows.Forms.Padding(4);
            this.tpImage.Size = new System.Drawing.Size(634, 281);
            this.tpImage.TabIndex = 1;
            this.tpImage.Text = "画像の操作";
            this.tpImage.UseVisualStyleBackColor = true;
            // 
            // ctlImage2
            // 
            this.ctlImage2.Location = new System.Drawing.Point(64, 44);
            this.ctlImage2.Margin = new System.Windows.Forms.Padding(4);
            this.ctlImage2.Name = "ctlImage2";
            this.ctlImage2.Size = new System.Drawing.Size(188, 180);
            this.ctlImage2.TabIndex = 0;
            // 
            // tpMediaPlayer
            // 
            this.tpMediaPlayer.Controls.Add(this.ctlMovie2);
            this.tpMediaPlayer.Location = new System.Drawing.Point(4, 28);
            this.tpMediaPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.tpMediaPlayer.Name = "tpMediaPlayer";
            this.tpMediaPlayer.Padding = new System.Windows.Forms.Padding(4);
            this.tpMediaPlayer.Size = new System.Drawing.Size(634, 281);
            this.tpMediaPlayer.TabIndex = 2;
            this.tpMediaPlayer.Text = "動画の操作";
            this.tpMediaPlayer.UseVisualStyleBackColor = true;
            // 
            // ctlMovie2
            // 
            this.ctlMovie2.Location = new System.Drawing.Point(44, 37);
            this.ctlMovie2.Margin = new System.Windows.Forms.Padding(5);
            this.ctlMovie2.Name = "ctlMovie2";
            this.ctlMovie2.Size = new System.Drawing.Size(557, 150);
            this.ctlMovie2.TabIndex = 0;
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Location = new System.Drawing.Point(74, 148);
            this.btnUnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(134, 28);
            this.btnUnSelect.TabIndex = 2;
            this.btnUnSelect.Text = "背景を表示";
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // txtPDFFileName
            // 
            this.txtPDFFileName.Location = new System.Drawing.Point(380, 121);
            this.txtPDFFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPDFFileName.Name = "txtPDFFileName";
            this.txtPDFFileName.ReadOnly = true;
            this.txtPDFFileName.Size = new System.Drawing.Size(566, 25);
            this.txtPDFFileName.TabIndex = 4;
            // 
            // ファイル情報
            // 
            this.ファイル情報.AutoSize = true;
            this.ファイル情報.Location = new System.Drawing.Point(274, 124);
            this.ファイル情報.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ファイル情報.Name = "ファイル情報";
            this.ファイル情報.Size = new System.Drawing.Size(59, 18);
            this.ファイル情報.TabIndex = 5;
            this.ファイル情報.Text = "ファイル";
            // 
            // frmOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.ファイル情報);
            this.Controls.Add(this.txtPDFFileName);
            this.Controls.Add(this.tbcFileOpes);
            this.Controls.Add(this.btnFileAdd);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lstPDFFiles);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOperation";
            this.Text = "frmOperation";
            this.Load += new System.EventHandler(this.frmOperation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbcFileOpes.ResumeLayout(false);
            this.tpAdobePDF.ResumeLayout(false);
            this.tpImage.ResumeLayout(false);
            this.tpMediaPlayer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDisplay;
        private System.Windows.Forms.ListBox lstPDFFiles;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFileAdd;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.TabControl tbcFileOpes;
        private System.Windows.Forms.TabPage tpAdobePDF;
        private System.Windows.Forms.TabPage tpImage;
        private System.Windows.Forms.TabPage tpMediaPlayer;
        private System.Windows.Forms.Button btnUnSelect;
        private System.Windows.Forms.TextBox txtPDFFileName;
        private System.Windows.Forms.Label ファイル情報;
        private ctlPDF ctlPDF2;
        private ctlImage ctlImage2;
        private ctlMovie ctlMovie2;
    }
}