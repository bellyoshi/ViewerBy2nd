using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoPDFViewer
{
    public delegate void MyEventHandler(BitmapImage bitmapImage);
    internal class Model
    {

        public event MyEventHandler MyEvent;
        static readonly Model _model = new();
        public static Model GetInstance()
        {
            return _model;
        }

        internal void SetSource(BitmapImage src)
        {
            MyEvent?.Invoke(src);
            
        }
    }
}
