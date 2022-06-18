using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;


namespace ViewerBy2nd
{
    public class FormDispacher
    {
        private frmOperation _frmOperation;
        private Screen _secondScreen;
        public Screen GetViewScreen => 
             _secondScreen;
        
        public void SetSecondScreen(Screen screen)
        {
            _secondScreen = screen;
            foreach (var frm in _secondMonitorWindows)
                SetViewerBounds(frm);
        }
        public void frmOperation_MouseWheel(object sender, MouseEventArgs e)
        {
            _frmOperation.frmOperation_MouseWheel(sender, e);
        }

        private void SetViewerBounds(Form frm)
        {
            if (_secondScreen == null)
                return;
            var bouds = _secondScreen.Bounds;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = bouds.Location;
            frm.Size = bouds.Size;
        }

        private List<Form> _secondMonitorWindows = new List<Form>();

        private void registViewer(Form frm)
        {
            if (!_secondMonitorWindows.Contains(frm))
                _secondMonitorWindows.Add(frm);
            SetViewerBounds(frm);
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
            _frmImageViewer = (frmViewer)Show(_frmImageViewer, typeof(frmViewer));
            _frmImageViewer.PictureBox1.Image = image;
            _frmImageViewer.PictureBox1.Visible = true;
            _frmImageViewer.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            _frmImageViewer.VideoPlayer1.Visible = false;
            _frmImageViewer.VideoPlayer1.Stop();
        }
        private frmViewer _frmImageViewer;


        public ViewerBy2ndLib.VideoPlayer ShowMovie()
        {
            _frmImageViewer = (frmViewer)Show(_frmImageViewer, typeof(frmViewer));
            _frmImageViewer.PictureBox1.Visible = false;
            _frmImageViewer.VideoPlayer1.Visible = true;
            return _frmImageViewer.VideoPlayer1;
        }

        public void Create(ref Form form, Type formType)
        {
            if (form == null || !_secondMonitorWindows.Contains(form))
            {
                form = (Form)Activator.CreateInstance(formType);
                form.BackColor = color;
                form.FormClosed += from_Closed;
            }
        }

        internal void RegistfrmOperation(frmOperation frmOperation)
        {
            _frmOperation = frmOperation;
        }

        private void from_Closed(object sender, EventArgs e)
        {
            var form = (Form)sender;
            _secondMonitorWindows.Remove(form);
        }

        private void HideOther(Form targetForm)
        {
            foreach (var frm in _secondMonitorWindows)
            {
                if (frm == targetForm)
                    continue;
                frm.Hide();
            }
        }

        public Form Show(Form targetForm, Type formType)
        {
            Create(ref targetForm, formType);
            registViewer(targetForm);
            HideOther(targetForm);
            targetForm.Show();
            return targetForm;
        }


        private Color color;
        public void SetColor(Color color)
        {
            this.color = color;
            foreach (var frm in _secondMonitorWindows)
                frm.BackColor = color;
        }

        public void CloseViewers()
        {
            var forms = new List<Form>(_secondMonitorWindows);
            foreach (var frm in forms)
                frm.Close();
        }
    }

}
