namespace ViewerBy2nd
{
    partial class ViewerForm
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
            VideoPlayer1=new WinFormsControlLibrary.VideoPlayer();
            PictureBox1=new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // VideoPlayer1
            // 
            VideoPlayer1.Dock=DockStyle.Fill;
            VideoPlayer1.Location=new Point(0, 0);
            VideoPlayer1.Margin=new Padding(3, 4, 3, 4);
            VideoPlayer1.Name="VideoPlayer1";
            VideoPlayer1.Rate=-1F;
            VideoPlayer1.Size=new Size(800, 600);
            VideoPlayer1.TabIndex=6;
            VideoPlayer1.Time=-1L;
            VideoPlayer1.Volume=-1;
            VideoPlayer1.MouseDoubleClick+=VideoPlayer1_MouseDoubleClick;
            VideoPlayer1.MouseDown+=VideoPlayer1_MouseDown;
            // 
            // PictureBox1
            // 
            PictureBox1.Dock=DockStyle.Fill;
            PictureBox1.Location=new Point(0, 0);
            PictureBox1.Name="PictureBox1";
            PictureBox1.Size=new Size(800, 600);
            PictureBox1.TabIndex=7;
            PictureBox1.TabStop=false;
            PictureBox1.MouseDoubleClick+=VideoPlayer1_MouseDoubleClick;
            PictureBox1.MouseDown+=VideoPlayer1_MouseDown;
            // 
            // ViewerForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 600);
            Controls.Add(VideoPlayer1);
            Controls.Add(PictureBox1);
            FormBorderStyle=FormBorderStyle.None;
            Margin=new Padding(3, 4, 3, 4);
            Name="ViewerForm";
            Text="Viewer Screen";
            Load+=ViewerForm_Load;
            VisibleChanged+=ViewerForm_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        internal ViewerBy2nd.WinFormsControlLibrary.VideoPlayer VideoPlayer1;
        internal PictureBox PictureBox1;
    }
}