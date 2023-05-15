namespace ViewerBy2nd.WinFormsControlLibrary
{
    partial class PageNumberForm
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
            PageNumberTextBox=new TextBox();
            PageCountLabel=new Label();
            OkButton=new Button();
            CancelCommandButton=new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(30, 47);
            label1.Name="label1";
            label1.Size=new Size(43, 20);
            label1.TabIndex=0;
            label1.Text="ページ";
            // 
            // PageNumberTextBox
            // 
            PageNumberTextBox.Location=new Point(79, 47);
            PageNumberTextBox.Name="PageNumberTextBox";
            PageNumberTextBox.Size=new Size(94, 27);
            PageNumberTextBox.TabIndex=1;
            PageNumberTextBox.KeyPress+=PageNumberTextBox_KeyPress;
            // 
            // PageCountLabel
            // 
            PageCountLabel.AutoSize=true;
            PageCountLabel.Location=new Point(179, 50);
            PageCountLabel.Name="PageCountLabel";
            PageCountLabel.Size=new Size(65, 20);
            PageCountLabel.TabIndex=2;
            PageCountLabel.Text="/ -page-";
            // 
            // OkButton
            // 
            OkButton.Location=new Point(70, 86);
            OkButton.Name="OkButton";
            OkButton.Size=new Size(94, 29);
            OkButton.TabIndex=3;
            OkButton.Text="OK";
            OkButton.UseVisualStyleBackColor=true;
            OkButton.Click+=OkButton_Click;
            // 
            // CancelCommandButton
            // 
            CancelCommandButton.Location=new Point(179, 87);
            CancelCommandButton.Name="CancelCommandButton";
            CancelCommandButton.Size=new Size(94, 29);
            CancelCommandButton.TabIndex=3;
            CancelCommandButton.Text="キャンセル";
            CancelCommandButton.UseVisualStyleBackColor=true;
            CancelCommandButton.Click+=CancelCommandButton_Click;
            // 
            // PageNumberForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(338, 128);
            Controls.Add(CancelCommandButton);
            Controls.Add(OkButton);
            Controls.Add(PageCountLabel);
            Controls.Add(PageNumberTextBox);
            Controls.Add(label1);
            Name="PageNumberForm";
            Text="ページ指定";
            Load+=PageNumberForm_Load;
            Leave+=PageNumberForm_Leave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox PageNumberTextBox;
        private Label PageCountLabel;
        private Button OkButton;
        private Button CancelCommandButton;
    }
}