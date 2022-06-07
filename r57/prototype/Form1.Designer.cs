namespace prototype
{
    partial class Form1
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
            this.vlcControlWrapper1 = new ViewerBy2ndLib.VLCControlWrapper();
            this.SuspendLayout();
            // 
            // vlcControlWrapper1
            // 
            this.vlcControlWrapper1.Location = new System.Drawing.Point(184, 60);
            this.vlcControlWrapper1.Name = "vlcControlWrapper1";
            this.vlcControlWrapper1.Size = new System.Drawing.Size(485, 288);
            this.vlcControlWrapper1.TabIndex = 0;
            this.vlcControlWrapper1.Resize += new System.EventHandler(this.vlcControlWrapper1_Resize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vlcControlWrapper1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ViewerBy2ndLib.VLCControlWrapper vlcControlWrapper1;
    }
}

