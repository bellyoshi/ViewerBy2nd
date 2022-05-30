using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaToSecondMonitor
{
    public partial class frmImageViewer : frmViewer
    {
        public frmImageViewer()
        {
            InitializeComponent();
        }

        private void FrmImageViewer_Load(object sender, EventArgs e)
        {

        }

        public PictureBox PictureBox()
        {
            return pictureBox1;
        }

        public override void DoHide()
        {
            Hide();
        }

    }
}
