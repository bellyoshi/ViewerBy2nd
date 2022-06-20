using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewerBy2ndLib;

namespace ViewerBy2nd
{
    public partial class frmViewer : Form
    {

        public frmViewer()
        {
            InitializeComponent();
        }

        public void frmOperation_MouseWheel(object sender, MouseEventArgs e)
        {
            var dispacher = FormDispacher.GetInstance();
            dispacher.frmOperation_MouseWheel(sender, e);
        }

        private void frmViewer_Load(object sender, EventArgs e)
        {
            this.MouseWheel +=  new MouseEventHandler(this.frmOperation_MouseWheel);
        }

        private void frmViewer_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                VideoPlayer1.Pause();
        }

        internal void SetViewerBounds(Rectangle bounds)
        {
            StartPosition = FormStartPosition.Manual;
            Location = bounds.Location;
            Size = bounds.Size;
            
        }

        internal void ShowImage(Image image)
        {
            PictureBox1.Image = image;
            PictureBox1.Visible = true;
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            VideoPlayer1.Visible = false;
            VideoPlayer1.Stop();
        }

        internal VideoPlayer ShowVideo()
        {

            PictureBox1.Visible = false;
            VideoPlayer1.Visible = true;
            return VideoPlayer1;
        }
    }

}
