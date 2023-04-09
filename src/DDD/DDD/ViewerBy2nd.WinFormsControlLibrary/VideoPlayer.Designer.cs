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
            vlcControl1=new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)vlcControl1).BeginInit();
            SuspendLayout();
            // 
            // vlcControl1
            // 
            vlcControl1.BackColor=Color.Black;
            vlcControl1.Dock=DockStyle.Fill;
            vlcControl1.Location=new Point(0, 0);
            vlcControl1.Name="vlcControl1";
            vlcControl1.Size=new Size(150, 150);
            vlcControl1.Spu=-1;
            vlcControl1.TabIndex=0;
            vlcControl1.Text="vlcControl1";
            vlcControl1.VlcLibDirectory=null;
            vlcControl1.VlcMediaplayerOptions=null;
            vlcControl1.VlcLibDirectoryNeeded+=vlcControl1_VlcLibDirectoryNeeded;
            // 
            // VideoPlayer2
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            Controls.Add(vlcControl1);
            Name="VideoPlayer2";
            ((System.ComponentModel.ISupportInitialize)vlcControl1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl vlcControl1;
    }
}
