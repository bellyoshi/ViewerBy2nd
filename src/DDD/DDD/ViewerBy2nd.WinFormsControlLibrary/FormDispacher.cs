﻿using System;
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

        private frmOperation _frmOperation;
        private frmViewer _frmViewer;



        public bool ViewerVisible => _frmViewer?.Visible??false;

        public void frmOperation_MouseWheel(object sender, MouseEventArgs e)
        {
            _frmOperation.frmOperation_MouseWheel(sender, e);
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
            _frmViewer.NotifyBackColor();
            _frmViewer.SetViewerBounds();
            _frmViewer.FormClosed += new FormClosedEventHandler(this.from_Closed);
        }




        public void CloseViewers()
        {
            if (_frmViewer == null) return;
            _frmViewer.Close();
        }

        internal void ShowSetting()
        {
            frmSetting frm = new();
            frm.Show();
                
        }
    }
}
