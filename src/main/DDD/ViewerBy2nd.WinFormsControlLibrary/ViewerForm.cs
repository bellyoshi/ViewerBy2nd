using System.Runtime.CompilerServices;
using ViewerBy2nd.WinFormsControlLibrary;

namespace ViewerBy2nd
{
    public partial class ViewerForm : Form
    {
        public ViewerWindowMode WindowMode { get; set; } = new();

        public ViewerForm()
        {
            InitializeComponent();
            WindowMode.FullScreenChanged += WindowMode_FullScreenChanged;
        }

        private void WindowMode_FullScreenChanged()
        {
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

        internal void SetViewerBoundsFullScreen()
        {
            var bounds = ViewScreenRegister.GetInstance().Bounds;
            StartPosition = FormStartPosition.Manual;
            Location = bounds.Location;

            this.FormBorderStyle = FormBorderStyle.None;
            Size = bounds.Size;//FormBorderStyleを変更してからsize変更する順番大事
            ControlBox = true;
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
            ControlBox = false;
            Text = "";
            this.FormBorderStyle = FormBorderStyle.Sizable;
            SizeGripStyle = SizeGripStyle.Hide;

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

        private bool mouseDoubleClicked = false;
        private void VideoPlayer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mouseDoubleClicked = true;
            WindowMode.IsFullScreen = !WindowMode.IsFullScreen;
        }

        private void VideoPlayer1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDoubleClicked = false;
            Task doNclButtonDown = DoNclButtonDown();
        }
        async Task DoNclButtonDown()
        {
            //マウスのダブルクリックを有効にするため少し時間を置く
            await Task.Delay(250);

            if (mouseDoubleClicked)
            {
                return;
            }
            if ((Control.MouseButtons & MouseButtons.Left) != MouseButtons.Left)
            {
                return;
            }
            //タイトルバーをクリックしたことにすることによって
            //ウインドウ内のどこをクリックしてもマウスでウインドウを動かせるようにする。
            TitleBarClick.DoNclButtonDown(this.Handle);
        }
    }
}
