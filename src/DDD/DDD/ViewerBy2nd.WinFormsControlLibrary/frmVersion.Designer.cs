namespace ViewerBy2nd.WinFormsControlLibrary
{
    partial class frmVersion
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(12, 19);
            label1.Name="label1";
            label1.Size=new Size(217, 20);
            label1.TabIndex=0;
            label1.Text="このアプリはViewerBy2ndバージョン";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize=true;
            linkLabel1.Location=new Point(12, 78);
            linkLabel1.Name="linkLabel1";
            linkLabel1.Size=new Size(406, 20);
            linkLabel1.TabIndex=1;
            linkLabel1.TabStop=true;
            linkLabel1.Text="https://osdn.net/users/bellyoshi/pf/pdfSecondMonitor/files/";
            linkLabel1.LinkClicked+=linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(12, 49);
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
            VersionLabel.Size=new Size(50, 20);
            VersionLabel.TabIndex=2;
            VersionLabel.Text="label3";
            // 
            // frmVersion
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(711, 340);
            Controls.Add(VersionLabel);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
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
    }
}