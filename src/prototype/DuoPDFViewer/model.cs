using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoPDFViewer
{
    public delegate void MyEventHandler(BitmapImage bitmapImage);
    internal class model
    {

        public event MyEventHandler MyEvent;
        static model _model = new model();
        public static model getInstance()
        {
            return _model;
        }

        internal void SetSource(BitmapImage src)
        {
            MyEvent?.Invoke(src);
            
        }
    }
}
