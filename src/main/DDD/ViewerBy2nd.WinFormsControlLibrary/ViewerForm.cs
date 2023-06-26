using ViewerBy2nd.WinFormsControlLibrary;

namespace ViewerBy2nd
{
    public partial class ViewerForm : Form
    {

        public ViewerForm()
        {
            InitializeComponent();
        }

        public void OperationForm_MouseWheel(object? sender, MouseEventArgs e)
        {
            var dispacher = FormDispacher.GetInstance();
            dispacher.OperationForm_MouseWheel(sender, e);
        }

        private void ViewerForm_Load(object sender, EventArgs e)
        {
            this.MouseWheel +=  new MouseEventHandler(this.OperationForm_MouseWheel);
        }

        private void ViewerForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                VideoPlayer1.Pause();
        }

        internal void SetViewerBounds()
        {
            var bounds = ViewScreenRegister.GetInstance().Bounds;
            StartPosition = FormStartPosition.Manual;
            Location = bounds.Location;
            Size = bounds.Size;

        }

        internal void ShowImage(Image image)
        {
            PictureBox1.Image = image;
            PictureBox1.Visible = true;
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            VideoPlayer1.Visible = false;
            VideoPlayer1.Stop();
        }

        internal VideoPlayer ShowVideo()
        {

            PictureBox1.Visible = false;
            VideoPlayer1.Visible = true;
            return VideoPlayer1;
        }

        internal void NotifyBackColor()
        {
            BackColor = BackColorRegister.GetInstance().BackColor;
        }
    }

}
