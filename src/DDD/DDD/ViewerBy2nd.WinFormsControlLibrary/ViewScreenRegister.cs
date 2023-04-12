using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    internal class ViewScreenRegister
    {
        private static ViewScreenRegister instance = new();
        static public ViewScreenRegister GetInstance()
        {
            return instance;
        }
        
        Settings Default => ConfigurationReader.Default;
        
        private Screen _viewScreen;
        bool isEmpty => _viewScreen == null;
        private ViewScreenRegister()
        {
            index = Default.cmbDisplaySelectedIndex;
            _viewScreen = Screen.AllScreens[index];
        }
        private int index;
        public int Index => index;
        public Rectangle Bounds
        {
            get
            {
                if (isEmpty)
                {
                    return new Rectangle();
                }
                else
                {
                    return _viewScreen.Bounds;
                }
            }
        }

        public Size Size => Bounds.Size;

        public void ChangeScreen(int idx)
        {
            _viewScreen = Screen.AllScreens[idx];
            Default.cmbDisplaySelectedIndex = idx;
            Notify();
        }

        void Notify()
        {
            if (isEmpty) return;
            FormDispacher.GetInstance().NotifyViewerBound();
        }
    }

    
}
