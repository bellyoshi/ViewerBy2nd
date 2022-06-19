namespace ViewerBy2nd
{
    partial class frmViewer
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
            this.VideoPlayer1 = new ViewerBy2ndLib.VideoPlayer();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoPlayer1
            // 
            this.VideoPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoPlayer1.Location = new System.Drawing.Point(0, 0);
            this.VideoPlayer1.Name = "VideoPlayer1";
            this.VideoPlayer1.Rate = -1F;
            this.VideoPlayer1.Size = new System.Drawing.Size(800, 450);
            this.VideoPlayer1.TabIndex = 6;
            this.VideoPlayer1.Time = ((long)(-1));
            this.VideoPlayer1.Volume = -1;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(800, 450);
            this.PictureBox1.TabIndex = 7;
            this.PictureBox1.TabStop = false;
            // 
            // frmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VideoPlayer1);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewer";
            this.Text = "Viewer Screen";

            this.Load += new System.EventHandler(this.frmViewer_Load);
            this.VisibleChanged += new System.EventHandler(this.frmViewer_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ViewerBy2ndLib.VideoPlayer VideoPlayer1;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}