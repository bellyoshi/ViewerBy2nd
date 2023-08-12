using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    public class ViewerWindowMode
    {
        static Settings Default => ConfigurationReader.Default;
        public event Action? FullScreenChanged;

        public ViewerWindowMode()
        {
            isFullScreen = Default.IsFullScreen??true;

        }
        private bool isFullScreen;
        public bool IsFullScreen { get => isFullScreen; 
            set 
            {
                Default.IsFullScreen = value;
                if (isFullScreen != value)
                {
                    isFullScreen = value;
                    FullScreenChanged?.Invoke();
                }

            }
        }

        public int Height { get; set; }
        public int Width { get; set; }
    }
}
