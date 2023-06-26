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
    public partial class frmMovieViewer : frmViewer
    {
        public frmMovieViewer()
        {
            InitializeComponent();
        }

        public AxWMPLib.AxWindowsMediaPlayer GetPlayer()
        {
            return axWindowsMediaPlayer1;
        }


        public override void DoHide()
        {
            Hide();

            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }


    }
}
