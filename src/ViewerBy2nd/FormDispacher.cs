using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;


namespace ViewerBy2nd
{
    public class FormDispacher
    {
        private frmOperation _frmOperation;
        private frmViewer _frmViewer;

        private Screen _viewScreen;
        public Screen GetViewScreen => 
             _viewScreen;

        public bool ViewerVisible => _frmViewer?.Visible??false;

        public void SetSecondScreen(Screen screen)
        {
            _viewScreen = screen;
            
            SetViewerBounds();
        }
        public void frmOperation_MouseWheel(object sender, MouseEventArgs e)
        {
            _frmOperation.frmOperation_MouseWheel(sender, e);
        }

        private void SetViewerBounds()
        {
            if (_viewScreen == null) return;

            if (_frmViewer == null) return;
            var bouds = _viewScreen.Bounds;
            _frmViewer.StartPosition = FormStartPosition.Manual;
            _frmViewer.Location = bouds.Location;
            _frmViewer.Size = bouds.Size;
        }





        private static FormDispacher instance;
        public static FormDispacher GetInstance()
        {
            if (instance == null)
                instance = new FormDispacher();
            return instance;
        }

        public void ShowImage(Image image)
        {
            Show();
            _frmViewer.PictureBox1.Image = image;
            _frmViewer.PictureBox1.Visible = true;
            _frmViewer.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            _frmViewer.VideoPlayer1.Visible = false;
            _frmViewer.VideoPlayer1.Stop();
        }



        public ViewerBy2ndLib.VideoPlayer ShowMovie()
        {
            Show();
            _frmViewer.PictureBox1.Visible = false;
            _frmViewer.VideoPlayer1.Visible = true;
            return _frmViewer.VideoPlayer1;
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
            _frmViewer.BackColor = color;
            SetViewerBounds();
            _frmViewer.FormClosed += new FormClosedEventHandler(this.from_Closed);
        }

        private Color color;
        public void SetColor(Color color)
        {
            this.color = color;

        }

        public void CloseViewers()
        {
            if (_frmViewer == null) return;
            _frmViewer.Close();
        }
    }

}
