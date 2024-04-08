using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2nd.Models
{
    public interface IDisplay
    {
        void SetImageSource(System.Windows.Media.Imaging.BitmapSource? ImageSource); 
    }
    public interface ImageSetter
    {
        void SetDisplay(IDisplay display);
    }
}
