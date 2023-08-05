namespace ViewerBy2nd.WinFormsControlLibrary
{
    partial class VideoPlayer
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            videoView1=new LibVLCSharp.WinForms.VideoView();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.BackColor=Color.Black;
            videoView1.Dock=DockStyle.Fill;
            videoView1.Location=new Point(0, 0);
            videoView1.MediaPlayer=null;
            videoView1.Name="videoView1";
            videoView1.Size=new Size(150, 150);
            videoView1.TabIndex=0;
            videoView1.Text="videoView1";
            // 
            // VideoPlayer
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            Controls.Add(videoView1);
            Name="VideoPlayer";
            Load+=VideoPlayer_Load;
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
    }
}
