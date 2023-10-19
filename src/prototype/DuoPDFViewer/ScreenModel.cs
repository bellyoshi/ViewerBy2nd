using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DuoPDFViewer
{
    internal class ScreenModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static readonly ScreenModel _model = new();
        public static ScreenModel GetInstance()
        {
            return _model;
        }

        public bool isFullScreen = false;
        public bool IsFullScreen
        {
            get { return isFullScreen; }
            set
            {
                isFullScreen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFullScreen))); 
            }
        }
    }
}
