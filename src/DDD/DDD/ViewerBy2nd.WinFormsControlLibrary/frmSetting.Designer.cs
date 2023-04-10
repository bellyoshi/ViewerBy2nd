namespace ViewerBy2nd.WinFormsControlLibrary
{
    partial class frmSetting
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
            lblFormColor=new Label();
            btnColorChange=new Button();
            Label1=new Label();
            cmbDisplay=new ComboBox();
            ColorDialog1=new ColorDialog();
            button1=new Button();
            SuspendLayout();
            // 
            // lblFormColor
            // 
            lblFormColor.AutoSize=true;
            lblFormColor.BackColor=Color.Black;
            lblFormColor.Location=new Point(542, 30);
            lblFormColor.Name="lblFormColor";
            lblFormColor.Size=new Size(39, 20);
            lblFormColor.TabIndex=9;
            lblFormColor.Text="　　";
            // 
            // btnColorChange
            // 
            btnColorChange.Location=new Point(420, 21);
            btnColorChange.Name="btnColorChange";
            btnColorChange.Size=new Size(93, 41);
            btnColorChange.TabIndex=8;
            btnColorChange.Text="背景色変更";
            btnColorChange.UseVisualStyleBackColor=true;
            btnColorChange.Click+=btnColorChange_Click_1;
            // 
            // Label1
            // 
            Label1.AutoSize=true;
            Label1.Location=new Point(12, 29);
            Label1.Name="Label1";
            Label1.Size=new Size(126, 20);
            Label1.TabIndex=7;
            Label1.Text="表示するディスプレイ";
            // 
            // cmbDisplay
            // 
            cmbDisplay.DropDownStyle=ComboBoxStyle.DropDownList;
            cmbDisplay.FormattingEnabled=true;
            cmbDisplay.Location=new Point(172, 22);
            cmbDisplay.Name="cmbDisplay";
            cmbDisplay.Size=new Size(163, 28);
            cmbDisplay.TabIndex=6;
            cmbDisplay.SelectedIndexChanged+=cmbDisplay_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location=new Point(640, 83);
            button1.Name="button1";
            button1.Size=new Size(94, 29);
            button1.TabIndex=10;
            button1.Text="OK";
            button1.UseVisualStyleBackColor=true;
            button1.Click+=button1_Click;
            // 
            // frmSetting
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(790, 141);
            Controls.Add(button1);
            Controls.Add(lblFormColor);
            Controls.Add(btnColorChange);
            Controls.Add(Label1);
            Controls.Add(cmbDisplay);
            Name="frmSetting";
            Text="設定";
            Load+=frmSetting_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label lblFormColor;
        internal Button btnColorChange;
        internal Label Label1;
        internal ComboBox cmbDisplay;
        internal ColorDialog ColorDialog1;
        private Button button1;
    }
}