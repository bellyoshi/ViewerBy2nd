using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class RubberBand
    {
        public readonly System.Drawing.Size Size;
        public readonly Point Location;
        public readonly Color Color;
        private System.Windows.Forms.PictureBox pictureBox1;

        public RubberBand(System.Windows.Forms.PictureBox pictureBox1)
        {
            this.pictureBox1=pictureBox1;
        }

        public void setImage(System.Drawing.Bitmap image)
        {
            throw new NotImplementedException();
        }
    }
}
