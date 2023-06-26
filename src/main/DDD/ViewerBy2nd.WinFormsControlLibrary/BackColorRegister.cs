namespace ViewerBy2nd.WinFormsControlLibrary
{
    internal class BackColorRegister
    {
        static Settings Default => ConfigurationReader.Default;

        //singlton
        private readonly static BackColorRegister instance = new();
        static public BackColorRegister GetInstance()
        {
            return instance;
        }

        private BackColorRegister()
        {
            _backColor = Default.BackColor ?? System.Drawing.Color.Black;
        }

        private System.Drawing.Color _backColor;
        public System.Drawing.Color BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                Default.BackColor = value;
                Notify();
            }
        }


        private static void Notify()
        {
            FormDispacher.GetInstance().NotifyBackColor();
        }
    }
}
