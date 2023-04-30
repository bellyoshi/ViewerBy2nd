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
            linkLabel1=new LinkLabel();
            label2=new Label();
            VersionLabel=new Label();
            okButton=new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(10, 14);
            label1.Name="label1";
            label1.Size=new Size(173, 15);
            label1.TabIndex=0;
            label1.Text="このアプリはViewerBy2ndバージョン";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize=true;
            linkLabel1.Location=new Point(10, 58);
            linkLabel1.Name="linkLabel1";
            linkLabel1.Size=new Size(275, 15);
            linkLabel1.TabIndex=1;
            linkLabel1.TabStop=true;
            linkLabel1.Text="https://ja.osdn.net/projects/viewerby2nd/releases/";
            linkLabel1.LinkClicked+=linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(10, 37);
            label2.Name="label2";
            label2.Size=new Size(247, 15);
            label2.TabIndex=0;
            label2.Text="更新はお手数ですが以下のリンクを確認願います。";
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize=true;
            VersionLabel.Location=new Point(206, 14);
            VersionLabel.Name="VersionLabel";
            VersionLabel.Size=new Size(38, 15);
            VersionLabel.TabIndex=2;
            VersionLabel.Text="label3";
            // 
            // okButton
            // 
            okButton.Location=new Point(328, 90);
            okButton.Margin=new Padding(3, 2, 3, 2);
            okButton.Name="okButton";
            okButton.Size=new Size(82, 22);
            okButton.TabIndex=3;
            okButton.Text="OK";
            okButton.UseVisualStyleBackColor=true;
            okButton.Click+=okButton_Click;
            // 
            // frmVersion
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(430, 121);
            Controls.Add(okButton);
            Controls.Add(VersionLabel);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin=new Padding(3, 2, 3, 2);
            Name="frmVersion";
            Text="このアプリについて";
            Load+=frmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel linkLabel1;
        private Label label2;
        private Label VersionLabel;
        private Button okButton;
    }
}