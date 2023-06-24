namespace ViewerBy2nd.WinFormsControlLibrary
{
    partial class SettingForm
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
            ColorChangeButton=new Button();
            Label1=new Label();
            DisplayComboBox=new ComboBox();
            ColorDialog1=new ColorDialog();
            OkButton=new Button();
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
            // ColorChangeButton
            // 
            ColorChangeButton.Location=new Point(420, 21);
            ColorChangeButton.Name="ColorChangeButton";
            ColorChangeButton.Size=new Size(93, 41);
            ColorChangeButton.TabIndex=8;
            ColorChangeButton.Text="背景色変更";
            ColorChangeButton.UseVisualStyleBackColor=true;
            ColorChangeButton.Click+=ColorChangeButton_Click;
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
            // DisplayComboBox
            // 
            DisplayComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            DisplayComboBox.FormattingEnabled=true;
            DisplayComboBox.Location=new Point(172, 22);
            DisplayComboBox.Name="DisplayComboBox";
            DisplayComboBox.Size=new Size(163, 28);
            DisplayComboBox.TabIndex=6;
            DisplayComboBox.SelectedIndexChanged+=DisplayComboBox_SelectedIndexChanged;
            // 
            // OkButton
            // 
            OkButton.Location=new Point(640, 83);
            OkButton.Name="OkButton";
            OkButton.Size=new Size(94, 29);
            OkButton.TabIndex=10;
            OkButton.Text="OK";
            OkButton.UseVisualStyleBackColor=true;
            OkButton.Click+=OkButton_Click;
            // 
            // SettingForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(790, 141);
            Controls.Add(OkButton);
            Controls.Add(lblFormColor);
            Controls.Add(ColorChangeButton);
            Controls.Add(Label1);
            Controls.Add(DisplayComboBox);
            Name="SettingForm";
            Text="設定";
            Load+=SettingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label lblFormColor;
        internal Button ColorChangeButton;
        internal Label Label1;
        internal ComboBox DisplayComboBox;
        internal ColorDialog ColorDialog1;
        private Button OkButton;
    }
}