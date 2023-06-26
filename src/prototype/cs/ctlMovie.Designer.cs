namespace MediaToSecondMonitor
{
    partial class ctlMovie
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
            this.btn = new System.Windows.Forms.Button();
            this.btnFastReverse = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(61, 47);
            this.btn.Margin = new System.Windows.Forms.Padding(4);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(94, 40);
            this.btn.TabIndex = 0;
            this.btn.Text = "先頭";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnFastReverse
            // 
            this.btnFastReverse.Location = new System.Drawing.Point(162, 47);
            this.btnFastReverse.Margin = new System.Windows.Forms.Padding(4);
            this.btnFastReverse.Name = "btnFastReverse";
            this.btnFastReverse.Size = new System.Drawing.Size(94, 40);
            this.btnFastReverse.TabIndex = 0;
            this.btnFastReverse.Text = "巻き戻し";
            this.btnFastReverse.UseVisualStyleBackColor = true;
            this.btnFastReverse.Click += new System.EventHandler(this.btnFastReverse_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPlay.Location = new System.Drawing.Point(264, 47);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(94, 40);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "▶";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(365, 47);
            this.btnForward.Margin = new System.Windows.Forms.Padding(4);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(98, 40);
            this.btnForward.TabIndex = 0;
            this.btnForward.Text = "先送り";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // ctlMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnFastReverse);
            this.Controls.Add(this.btn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctlMovie";
            this.Size = new System.Drawing.Size(628, 152);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnFastReverse;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnForward;
    }
}
