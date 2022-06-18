using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewerBy2nd
{
    public partial class frmViewer : Form
    {

        public frmViewer()
        {
            InitializeComponent();
        }
        private void frmMovieViewer_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                VideoPlayer1.Pause();
        }


        public void frmOperation_MouseWheel(object sender, MouseEventArgs e)
        {
            var dispacher = FormDispacher.GetInstance();
            dispacher.frmOperation_MouseWheel(sender, e);
        }
    }

}
