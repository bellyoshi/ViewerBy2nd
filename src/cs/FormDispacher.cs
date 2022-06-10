using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace MediaToSecondMonitor
{
    class FormDispacher
    {
        #region "second screen"

        private Screen _secondScreen;
        public Screen SecondScreen
        {
            set {
                _secondScreen = value;
                foreach (var f in _livingViewer) {
                    SetViewerBounds(f);
                }
            }
        }

        private void SetViewerBounds(Form form)
        {
            if (_secondScreen == null)
            {
                return;
            }
            var bounds = _secondScreen.Bounds;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = bounds.Location;
            form.Size = bounds.Size;
        }

        private List<frmViewer> _livingViewer = new List<frmViewer>();
        private void registViewer(frmViewer form)
        {
            if (!_livingViewer.Contains(form))
            {
                _livingViewer.Add(form);
            }
            SetViewerBounds(form);
        }

        #endregion

        #region "singleton"
        public static FormDispacher Instance { get; } = new FormDispacher();
        private FormDispacher() { }
        #endregion

        #region "show"


        private frmViewer _frmImageViewer;
        public PictureBox GetPictureBox()
        {
            Show(ref _frmImageViewer, typeof(frmImageViewer));
            return ((frmImageViewer)_frmImageViewer).PictureBox();
        }

        private frmViewer _frmMovieViewer;
        public AxWMPLib.AxWindowsMediaPlayer GetPlayer(){
            Show(ref _frmMovieViewer, typeof(frmMovieViewer));
            return ((frmMovieViewer)_frmMovieViewer).GetPlayer();
        }
        

        #endregion

        #region "show frame work"

        public void Create(ref frmViewer  form,Type formType)
        {
            if (form == null || !_livingViewer.Contains(form))
            {
                form = (frmViewer)Activator.CreateInstance(formType);
                form.FormClosed += new FormClosedEventHandler(form_Closed);
            }
        }

        private void form_Closed(Object sender,EventArgs e)
        {
            var form = (frmViewer)sender;
            _livingViewer.Remove(form);
        }

        private void HideOther(frmViewer  targetForm)
        {
            foreach(var f in _livingViewer)
            {
                if(f == targetForm)
                {
                    continue;
                }
                f.DoHide();
            }
        }

        private void Show(ref frmViewer targetForm,Type formType)
        {
            Create(ref targetForm, formType);
            registViewer(targetForm);
            HideOther(targetForm);
            targetForm.Show();
        }

        public void CloseViewers()
        {
            var forms = new List<Form>(_livingViewer);//閉じていくうちに元が破壊されるのでコピーする
            foreach(var f in forms)
            {
                f.Close();
            }
        }
        #endregion

    }
}
