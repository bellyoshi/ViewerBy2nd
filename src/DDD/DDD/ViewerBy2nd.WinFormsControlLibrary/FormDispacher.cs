using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ViewerBy2nd.WinFormsControlLibrary;

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

        private frmOperation? _frmOperation;
        private frmViewer? _frmViewer;
        private frmSetting? _frmSetting;



        public bool ViewerVisible => _frmViewer?.Visible??false;

        public void frmOperation_MouseWheel(object? sender, MouseEventArgs e)
        {
            _frmOperation?.frmOperation_MouseWheel(sender, e);
        }

        public void NotifyViewerBound()
        {

            _frmViewer?.SetViewerBounds();
            _frmOperation?.SetThumnailSize();
        }

        public void NotifyBackColor()
        {

            _frmViewer?.NotifyBackColor();
            _frmOperation?.NotifyBackColor();
        }
        public void ShowImage(Image image)
        {
            ShowViewer();
            _frmViewer?.ShowImage(image);
        }

        public ViewerBy2nd.WinFormsControlLibrary.VideoPlayer ShowMovie()
        {
            ShowViewer();
            Debug.Assert(_frmViewer != null);
            return _frmViewer.ShowVideo();
        }

        internal void RegistrationfrmOperation(frmOperation frmOperation)
        {
            _frmOperation = frmOperation;
        }

        private void from_Closed(object? sender, EventArgs e)
        {
            _frmViewer = null;
        }

        public void ShowViewer()
        {
            if (_frmViewer == null)
            {
                _frmViewer = CreateViewerForm();
            }
            _frmViewer.Show();

        }

        public frmViewer CreateViewerForm()
        {
            frmViewer frm;
            frm = new frmViewer();
            frm.NotifyBackColor();
            frm.SetViewerBounds();
            frm.FormClosed += new FormClosedEventHandler(this.from_Closed);
            return frm;
        }




        public void CloseViewers()
        {
            if (_frmViewer == null) return;
            _frmViewer.Close();
        }

        internal void ShowSetting()
        {
            if (_frmSetting == null) CreateSettingForm();
            _frmSetting?.Show();   
        }

        private void CreateSettingForm()
        {
            _frmSetting = new frmSetting();
            _frmSetting.FormClosed += new FormClosedEventHandler(this.fromSetting_Closed);
        }

        private void fromSetting_Closed(object? sender, EventArgs e)
        {
            _frmSetting = null;
        }

    }
}
