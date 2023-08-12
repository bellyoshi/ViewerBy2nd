namespace ViewerBy2nd.WinFormsControlLibrary
{
    partial class VersionForm
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
            label1=new Label();
            ReleasesLinkLabel=new LinkLabel();
            label2=new Label();
            VersionLabel=new Label();
            OkButton=new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(11, 19);
            label1.Name="label1";
            label1.Size=new Size(217, 20);
            label1.TabIndex=0;
            label1.Text="このアプリはViewerBy2ndバージョン";
            // 
            // ReleasesLinkLabel
            // 
            ReleasesLinkLabel.AutoSize=true;
            ReleasesLinkLabel.Location=new Point(11, 77);
            ReleasesLinkLabel.Name="ReleasesLinkLabel";
            ReleasesLinkLabel.Size=new Size(348, 20);
            ReleasesLinkLabel.TabIndex=1;
            ReleasesLinkLabel.TabStop=true;
            ReleasesLinkLabel.Text="https://github.com/bellyoshi/ViewerBy2nd/releases";
            ReleasesLinkLabel.LinkClicked+=ReleasesLinkLabel_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(11, 49);
            label2.Name="label2";
            label2.Size=new Size(307, 20);
            label2.TabIndex=0;
            label2.Text="更新はお手数ですが以下のリンクを確認願います。";
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize=true;
            VersionLabel.Location=new Point(235, 19);
            VersionLabel.Name="VersionLabel";
            VersionLabel.Size=new Size(80, 20);
            VersionLabel.TabIndex=2;
            VersionLabel.Text="--Version--";
            // 
            // OkButton
            // 
            OkButton.Location=new Point(375, 120);
            OkButton.Name="OkButton";
            OkButton.Size=new Size(94, 29);
            OkButton.TabIndex=3;
            OkButton.Text="OK";
            OkButton.UseVisualStyleBackColor=true;
            OkButton.Click+=OkButton_Click;
            // 
            // VersionForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(491, 161);
            Controls.Add(OkButton);
            Controls.Add(VersionLabel);
            Controls.Add(ReleasesLinkLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Name="VersionForm";
            Text="このアプリについて";
            Load+=VersionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel ReleasesLinkLabel;
        private Label label2;
        private Label VersionLabel;
        private Button OkButton;
    }
}