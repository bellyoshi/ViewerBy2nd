﻿namespace ViewerBy2nd
{
    partial class ViewerForm
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
            components=new System.ComponentModel.Container();
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            PictureBox1=new PictureBox();
            contextMenuStrip1=new ContextMenuStrip(components);
            フルスクリーンToolStripMenuItem=new ToolStripMenuItem();
            ウインドウモードToolStripMenuItem=new ToolStripMenuItem();
            表示終了ToolStripMenuItem=new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.Dock=DockStyle.Fill;
            videoView1.Location=new Point(0, 0);
            videoView1.Margin=new Padding(3, 4, 3, 4);
            videoView1.Name="videoView1";
            videoView1.Size=new Size(800, 600);
            videoView1.TabIndex=6;
            // 
            // PictureBox1
            // 
            PictureBox1.Dock=DockStyle.Fill;
            PictureBox1.Location=new Point(0, 0);
            PictureBox1.Name="PictureBox1";
            PictureBox1.Size=new Size(800, 600);
            PictureBox1.TabIndex=7;
            PictureBox1.TabStop=false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize=new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { フルスクリーンToolStripMenuItem, ウインドウモードToolStripMenuItem, 表示終了ToolStripMenuItem });
            contextMenuStrip1.Name="contextMenuStrip1";
            contextMenuStrip1.Size=new Size(211, 104);
            // 
            // フルスクリーンToolStripMenuItem
            // 
            フルスクリーンToolStripMenuItem.Name="フルスクリーンToolStripMenuItem";
            フルスクリーンToolStripMenuItem.Size=new Size(210, 24);
            フルスクリーンToolStripMenuItem.Text="フルスクリーン";
            フルスクリーンToolStripMenuItem.Click+=フルスクリーンToolStripMenuItem_Click;
            // 
            // ウインドウモードToolStripMenuItem
            // 
            ウインドウモードToolStripMenuItem.Name="ウインドウモードToolStripMenuItem";
            ウインドウモードToolStripMenuItem.Size=new Size(210, 24);
            ウインドウモードToolStripMenuItem.Text="ウインドウモード";
            ウインドウモードToolStripMenuItem.Click+=ウインドウモードToolStripMenuItem_Click;
            // 
            // 表示終了ToolStripMenuItem
            // 
            表示終了ToolStripMenuItem.Name="表示終了ToolStripMenuItem";
            表示終了ToolStripMenuItem.Size=new Size(210, 24);
            表示終了ToolStripMenuItem.Text="表示終了";
            表示終了ToolStripMenuItem.Click+=表示終了ToolStripMenuItem_Click;
            // 
            // ViewerForm
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 600);
            Controls.Add(videoView1);
            Controls.Add(PictureBox1);
            FormBorderStyle=FormBorderStyle.None;
            Margin=new Padding(3, 4, 3, 4);
            Name="ViewerForm";
            Text="Viewer Screen";
            Load+=ViewerForm_Load;
            VisibleChanged+=ViewerForm_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        internal LibVLCSharp.WinForms.VideoView videoView1;
        internal PictureBox PictureBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem フルスクリーンToolStripMenuItem;
        private ToolStripMenuItem ウインドウモードToolStripMenuItem;
        private ToolStripMenuItem 表示終了ToolStripMenuItem;
    }
}