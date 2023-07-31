using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    public class ViewerWindowMode
    {
        public event Action? FullScreenChanged;

        private bool isFullScreen = true;
        public bool IsFullScreen { get => isFullScreen; 
            set 
            {
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
