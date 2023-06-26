using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaToSecondMonitor
{
    public partial class ctlMovie : UserControl
    {
        public ctlMovie()
        {
            InitializeComponent();
        }
        private FormDispacher _dispacher = FormDispacher.Instance;


        private AxWMPLib.AxWindowsMediaPlayer player;

        private FileViewParam _fileViewParam;

        public void SetFileInfo(FileViewParam f)
        {
            this._fileViewParam = f;
            if (_fileViewParam == null)
                return;
            player = _dispacher.GetPlayer();

            player.URL = _fileViewParam.FileName;
            player.uiMode = "none";
            player.stretchToFit = true;
        }


        private bool inPlay = false;





        public void ControlEnabled()
        {
            this.Enabled = !(_fileViewParam == null);
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if(inPlay)
            {
                player.Ctlcontrols.pause(); 
            }
            else
            {
                player.Ctlcontrols.play();
            }
            inPlay = !inPlay;

        }



        private void btnFastReverse_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.fastReverse();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {

            player.Ctlcontrols.fastForward();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.stop();
            player.Ctlcontrols.play();
            player.Ctlcontrols.pause();
            inPlay = false;
        }
    }
}

