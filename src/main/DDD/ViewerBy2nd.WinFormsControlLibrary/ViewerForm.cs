using ViewerBy2nd.WinFormsControlLibrary;

namespace ViewerBy2nd
{
    public partial class ViewerForm : Form
    {
        private readonly FormDispacher dispacher = FormDispacher.GetInstance();
        public ViewerWindowMode WindowMode { get; set; } = new();

        private readonly VideoPlayer VideoPlayer1;
        public ViewerForm()
        {

            InitializeComponent();

            VideoPlayer1 = new(videoView1);

            Control[] controls = { this, PictureBox1,  videoView1 };
            foreach (Control control in controls)
            {
                control.ContextMenuStrip = contextMenuStrip1;
            }
            WindowMode.FullScreenChanged += WindowMode_FullScreenChanged;
            formResizer = new FormDragResizer(this, FormDragResizer.ResizeDirection.All, 8, controls);
            formMover = new FormDragMover(this, 8, controls);
            FormMoverResizeEnabledInitialize();
            WindowMode_FullScreenChanged();
        }

        void FormMoverResizeEnabledInitialize()
        {
            formResizer.Enabled = !WindowMode.IsFullScreen;
            formMover.Enabled = !WindowMode.IsFullScreen;
            ウインドウモードToolStripMenuItem.Enabled = WindowMode.IsFullScreen;
            フルスクリーンToolStripMenuItem.Enabled = !WindowMode.IsFullScreen;
        }

        private void WindowMode_FullScreenChanged()
        {
            FormMoverResizeEnabledInitialize();
            if (WindowMode.IsFullScreen)
            {
                SetViewerBoundsFullScreen();
            }
            else
            {
                SetViewerBoundsWindowScreen();
            }
        }

        public void OperationForm_MouseWheel(object? sender, MouseEventArgs e)
        {

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

        internal void SetViewerBoundsFullScreen()
        {
            var bounds = ViewScreenRegister.GetInstance().Bounds;
            StartPosition = FormStartPosition.Manual;
            Location = bounds.Location;
            Size = bounds.Size;

        }
        internal void SetViewerBoundsWindowScreen()
        {
            var bounds = ViewScreenRegister.GetInstance().Bounds;
            StartPosition = FormStartPosition.Manual;
            //todo:とりあえずの初期値(位置を覚えておくように要修正)
            Point point = bounds.Location;
            point.X += 100;
            point.Y += 50;
            Location = point;

            Size = bounds.Size / 2;

        }
        private readonly FormDragResizer formResizer;
        private readonly FormDragMover formMover;
        internal void ShowImage(Image image)
        {
            PictureBox1.Image = image;
            PictureBox1.Visible = true;
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            videoView1.Visible = false;
            VideoPlayer1.Stop();
        }

        internal VideoPlayer ShowVideo()
        {

            PictureBox1.Visible = false;
            videoView1.Visible = true;
            return VideoPlayer1;
        }

        internal void NotifyBackColor()
        {
            BackColor = BackColorRegister.GetInstance().BackColor;
        }

        private void ウインドウモードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowMode.IsFullScreen = false;

        }

        private void フルスクリーンToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowMode.IsFullScreen = true;
        }

        private void 表示終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dispacher.CloseViewers();
        }
    }
}
