using ViewerBy2nd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ViewerBy2nd.FileViewParams
{
    public class SvgFileViewParam(string filename) : DocuGraphFileViewParam(filename)
    {
        public override BitmapSource GetImageFromFile()
        {
            return ImageCreater.GetImageFromFile(this);
        }
    }
}


