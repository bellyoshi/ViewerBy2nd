using LibVLCSharp.WinForms;

namespace LibVLCCSharp.Sample.net6
{
    partial class Form1
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
                this.Player?.Dispose();
                this._libVLC?.Dispose();
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
            videoView1=new VideoView();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.BackColor=Color.Black;
            videoView1.Dock=DockStyle.Fill;
            videoView1.Location=new Point(0, 0);
            videoView1.Margin=new Padding(4, 5, 4, 5);
            videoView1.MediaPlayer=null;
            videoView1.Name="videoView1";
            videoView1.Size=new Size(1067, 692);
            videoView1.TabIndex=0;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1067, 692);
            Controls.Add(videoView1);
            FormBorderStyle=FormBorderStyle.None;
            Margin=new Padding(4, 5, 4, 5);
            Name="Form1";
            Text="LibVLCSharp.WinForms";
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private VideoView videoView1;
    }
}