namespace PDFiumView
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1=new ToolStrip();
            toolStripDropDownButton1=new ToolStripDropDownButton();
            開くToolStripMenuItem=new ToolStripMenuItem();
            閉じるToolStripMenuItem=new ToolStripMenuItem();
            終了ToolStripMenuItem=new ToolStripMenuItem();
            toolStripTextBox1=new ToolStripTextBox();
            toolStripLabel1=new ToolStripLabel();
            toolStripStatusLabel1=new ToolStripLabel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize=new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripTextBox1, toolStripLabel1, toolStripStatusLabel1 });
            toolStrip1.Location=new Point(0, 0);
            toolStrip1.Name="toolStrip1";
            toolStrip1.Size=new Size(800, 27);
            toolStrip1.TabIndex=0;
            toolStrip1.Text="toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle=ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { 開くToolStripMenuItem, 閉じるToolStripMenuItem, 終了ToolStripMenuItem });
            toolStripDropDownButton1.Image=(Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor=Color.Magenta;
            toolStripDropDownButton1.Name="toolStripDropDownButton1";
            toolStripDropDownButton1.Size=new Size(34, 24);
            toolStripDropDownButton1.Text="toolStripDropDownButton1";
            toolStripDropDownButton1.DropDownItemClicked+=toolStripDropDownButton1_DropDownItemClicked;
            // 
            // 開くToolStripMenuItem
            // 
            開くToolStripMenuItem.Name="開くToolStripMenuItem";
            開くToolStripMenuItem.Size=new Size(129, 26);
            開くToolStripMenuItem.Text="開く";
            // 
            // 閉じるToolStripMenuItem
            // 
            閉じるToolStripMenuItem.Name="閉じるToolStripMenuItem";
            閉じるToolStripMenuItem.Size=new Size(129, 26);
            閉じるToolStripMenuItem.Text="閉じる";
            // 
            // 終了ToolStripMenuItem
            // 
            終了ToolStripMenuItem.Name="終了ToolStripMenuItem";
            終了ToolStripMenuItem.Size=new Size(129, 26);
            終了ToolStripMenuItem.Text="終了";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name="toolStripTextBox1";
            toolStripTextBox1.Size=new Size(100, 27);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name="toolStripLabel1";
            toolStripLabel1.Size=new Size(111, 24);
            toolStripLabel1.Text="toolStripLabel1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name="toolStripStatusLabel1";
            toolStripStatusLabel1.Size=new Size(111, 24);
            toolStripStatusLabel1.Text="toolStripLabel2";
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(toolStrip1);
            Name="Form1";
            Text="Form1";
            Paint+=Form1_Paint;
            Resize+=Form1_Resize;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem 閉じるToolStripMenuItem;
        private ToolStripMenuItem 開くToolStripMenuItem;
        private ToolStripMenuItem 終了ToolStripMenuItem;
        private ToolStripLabel toolStripStatusLabel1;
    }
}