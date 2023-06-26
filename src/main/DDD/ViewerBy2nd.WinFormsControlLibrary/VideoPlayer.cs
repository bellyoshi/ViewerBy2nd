using ViewerBy2ndLib;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    public partial class VideoPlayer : UserControl
    {
        public VideoPlayer()
        {
            InitializeComponent();
            loadTimer.Tick += LoadTimer_Tick;
        }
        int _volume;
        public int Volume
        {
            get { return VlcControl?.VlcMediaPlayer?.Audio?.Volume??-1; }
            set
            {
                _volume = value;
                loadTimer.Interval  = 20;
                loadTimer.Start();
            }
        }
        public float Rate
        {
            get { return VlcControl.Rate; }
            set { VlcControl.Rate = value; }
        }
        public bool IsPlaying => VlcControl.IsPlaying;

        private long _time;
        public long Time
        {
            get
            {
                if (VlcControl.Time <= 0) return _time;
                return VlcControl.Time;
            }
            set
            {
                _time = value;

                if (0 > value)
                    VlcControl.Time = 0;
                else if (value > VlcControl.Length)
                {
                    VlcControl.Time = VlcControl.Length -1;
                }
                else
                    VlcControl.Time = value;
            }
        }
        public long Length => VlcControl.Length;

        public bool RequiredReload => VlcControl.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended;

        readonly System.Windows.Forms.Timer loadTimer = new();


        private void VlcControl1_VlcLibDirectoryNeeded(object? sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = VLCDirectoryGetter.GetVlcLibDirectory();
        }

        public void Stop()
        {
            VlcControl.Stop();
        }

        public void Pause()
        {
            if (VlcControl.IsPlaying)
                VlcControl.Pause();
        }

        public void Play()
        {
            if (!VlcControl.IsPlaying)
                VlcControl.Play();

        }
        public void Play(string filename, params string[] options)
        {
            VlcControl.Play(new Uri($"file://{filename}"), options);

        }
        bool requirePause;
        public void LoadFile(string filename, params string[] options)
        {
            Play(filename, options);
            loadTimer.Interval = 10;
            loadTimer.Start();

            requirePause = true;
        }

        private void LoadTimer_Tick(Object? sender, EventArgs e)
        {
            if (requirePause)
            {
                if (VlcControl.Time != 0)
                {
                    loadTimer.Stop();
                    VlcControl.Pause();
                    requirePause = false;

                }
            }
            if (Volume != _volume)
            {
                if (VlcControl.VlcMediaPlayer == null) return;
                VlcControl.VlcMediaPlayer.Audio.Volume = _volume;
            }
        }
        readonly Vlc.DotNet.Forms.VlcControl VlcControl = new();
        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;


            VlcControl.BeginInit();
            VlcControl.VlcLibDirectoryNeeded += VlcControl1_VlcLibDirectoryNeeded;
            VlcControl.Dock = DockStyle.Fill;
            VlcControl.EndInit();

            Controls.Add(VlcControl);

        }
    }
}
