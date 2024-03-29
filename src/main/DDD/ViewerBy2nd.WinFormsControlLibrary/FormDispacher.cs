﻿using System.Diagnostics;
using ViewerBy2nd.WinFormsControlLibrary;

namespace ViewerBy2nd
{
    public class FormDispacher
    {
#region "singlton"
        private readonly static FormDispacher instance = new ();
        public static FormDispacher GetInstance()
        {
            return instance;
        }
        private FormDispacher() { }
#endregion

        private OperationForm? _frmOperation;
        private ViewerForm? _frmViewer;
        private SettingForm? _frmSetting;



        public bool ViewerVisible => _frmViewer?.Visible??false;

        public void OperationForm_MouseWheel(object? sender, MouseEventArgs e)
        {
            _frmOperation?.OperationForm_MouseWheel(sender, e);
        }

        public void NotifyViewerBound()
        {

            _frmViewer?.SetViewerBoundsFullScreen();
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

        internal void RegistrationfrmOperation(OperationForm frmOperation)
        {
            _frmOperation = frmOperation;
        }

        private void Form_Closed(object? sender, EventArgs e)
        {
            _frmViewer = null;
        }

        public void ShowViewer()
        {
            _frmViewer ??= CreateViewerForm();
            _frmViewer.Show();

        }

        public ViewerForm CreateViewerForm()
        {
            ViewerForm frm;
            frm = new ViewerForm();
            frm.NotifyBackColor();
            frm.FormClosed += new FormClosedEventHandler(this.Form_Closed);
            return frm;
        }




        public void CloseViewers()
        {
            if (_frmViewer == null) return;
            _frmViewer.Close();
            _frmOperation?.CloseViewerAfterAction();
        }

        internal void ShowSetting()
        {
            if (_frmSetting == null) CreateSettingForm();
            _frmSetting?.Show();   
        }

        private void CreateSettingForm()
        {
            _frmSetting = new SettingForm();
            _frmSetting.FormClosed += new FormClosedEventHandler(this.SettingForm_Closed);
        }

        private void SettingForm_Closed(object? sender, EventArgs e)
        {
            _frmSetting = null;
        }

        public static void ShowPageNumberForm(Action<int> setPageNumberAction, int pageNumberMax, int pageNumberIndex)
        {
            PageNumberForm frm = new (setPageNumberAction, pageNumberMax, pageNumberIndex);
            frm.Show();
        }

        internal void ShowVersion()
        {
            
            var frm = new VersionForm();
            frm.ShowDialog();
            
        }
    }
}
