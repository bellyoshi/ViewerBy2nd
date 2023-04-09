using System;
using System.Drawing;
using System.Windows.Forms;

namespace ViewerBy2nd
{
    public class FormDispacher
    {
#region "singlton"
        private static FormDispacher instance = new FormDispacher();
        public static FormDispacher GetInstance()
        {
            return instance;
        }
        private FormDispacher() { }
#endregion

        private frmOperation _frmOperation;
        private frmViewer _frmViewer;

        private Screen _viewScreen;
        public Screen ViewScreen
        {
            get { return _viewScreen; }
            set
            {
                _viewScreen = value;
                SetViewerBounds();
            }
        }
        public bool ViewerVisible => _frmViewer?.Visible??false;

        public void frmOperation_MouseWheel(object sender, MouseEventArgs e)
        {
            _frmOperation.frmOperation_MouseWheel(sender, e);
        }

        private void SetViewerBounds()
        {
            if (_viewScreen == null) return;
            if (_frmViewer == null) return;
            _frmViewer.SetViewerBounds(_viewScreen.Bounds);
        }

        public void ShowImage(Image image)
        {
            Show();
            _frmViewer.ShowImage(image);
        }

        public ViewerBy2nd.WinFormsControlLibrary.VideoPlayer ShowMovie()
        {
            Show();
            return _frmViewer.ShowVideo();
        }

        internal void RegistrationfrmOperation(frmOperation frmOperation)
        {
            _frmOperation = frmOperation;
        }

        private void from_Closed(object sender, EventArgs e)
        {
            _frmViewer = null;
        }

        public void Show()
        {
            if (_frmViewer == null)
            {
                CreateViewerForm();
            }
            _frmViewer.Show();
        }

        public void CreateViewerForm()
        {
            _frmViewer = new frmViewer();
            _frmViewer.BackColor = BackColor;
            SetViewerBounds();
            _frmViewer.FormClosed += new FormClosedEventHandler(this.from_Closed);
        }

        private Color _backColor = Color.Black  ;
        public Color BackColor {
            get { return _backColor; }
            set
            {
                this._backColor = value;
                if (_frmViewer != null)
                    _frmViewer.BackColor = BackColor;
            } 
        }

        public void CloseViewers()
        {
            if (_frmViewer == null) return;
            _frmViewer.Close();
        }
    }
}
