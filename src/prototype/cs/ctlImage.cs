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
    public partial class ctlImage : UserControl
    {
        public ctlImage()
        {
            InitializeComponent();
        }
        private PictureBox _pictureBox;

        private void Rotate(RotateFlipType flip)
        {
            Bitmap bmp = new Bitmap(_fileViewParam.FileName);
            bmp.RotateFlip(flip);
            _pictureBox.Image = bmp;
        }
        private void None()
        {
            _pictureBox.ImageLocation = _fileViewParam.FileName;
        }
        private void btnRotate_Click(object sender, EventArgs e)
        {
            Rotate(RotateFlipType.Rotate180FlipNone);
        }

        private void btnRotate90_Click(object sender, EventArgs e)
        {
            Rotate(RotateFlipType.Rotate90FlipNone);
        }

        private void btnRotate0_Click(object sender, EventArgs e)
        {
            None();
        }

        private void btnRotate270_Click(object sender, EventArgs e)
        {
            Rotate(RotateFlipType.Rotate270FlipNone);
        }

        private FormDispacher _dispacher = FormDispacher.Instance;
        private FileViewParam _fileViewParam;

        public void SetFileInfo(FileViewParam f)
        {
            this._fileViewParam = f;
            if (f == null)
                return;
            _pictureBox = _dispacher.GetPictureBox();
            None();
            _pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // サイズ調整
        }

        public void ControlEnabled()
        {
            this.Enabled = !(_fileViewParam == null);
        }
    }
}
