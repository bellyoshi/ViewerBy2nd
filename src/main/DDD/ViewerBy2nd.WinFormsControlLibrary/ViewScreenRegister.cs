﻿namespace ViewerBy2nd.WinFormsControlLibrary
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
            var idx = Default.DisplaySelectedIndex;
            if(!IsValidValue())
            {
                idx = null;
            }
            Default.DisplaySelectedIndex = idx ?? getDefaultSecondMonitorIndex();
            index = Default.DisplaySelectedIndex.Value;
            _viewScreen = Screen.AllScreens[index];
        }
        private bool IsValidValue()
        {
            var idx = Default.DisplaySelectedIndex;
            return 0 <= idx && idx <= Screen.AllScreens.Length;
        }

        private int getDefaultSecondMonitorIndex()
        {
            if (Screen.AllScreens.Length == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
           
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
            index = idx;
            _viewScreen = Screen.AllScreens[idx];
            Default.DisplaySelectedIndex = idx;
            Notify();
        }

        void Notify()
        {
            if (isEmpty) return;
            FormDispacher.GetInstance().NotifyViewerBound();
        }
    }

    
}
