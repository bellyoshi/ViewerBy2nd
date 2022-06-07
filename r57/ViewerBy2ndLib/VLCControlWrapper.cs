using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewerBy2ndLib
{
    public partial class VLCControlWrapper : UserControl
    {
        private Vlc.DotNet.Forms.VlcControl vlcControl1;
        public VLCControlWrapper()
        {
            InitializeComponent();
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Location = new System.Drawing.Point(0, 0);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = this.Size;
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 0;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = VLCLib.VLCDirectoryGetter.GetVlcLibDirectory();
            this.vlcControl1.VlcMediaplayerOptions = null;
            this.vlcControl1.Dock = DockStyle.Fill;
            this.Controls.Add(this.vlcControl1);
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
