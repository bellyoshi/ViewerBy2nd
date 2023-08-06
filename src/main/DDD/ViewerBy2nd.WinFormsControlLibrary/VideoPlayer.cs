using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    public partial class VideoPlayer : UserControl
    {
        public VideoView View => videoView1;
        private LibVLC libVLC;
        private MediaPlayer Player;

        public VideoPlayer()
        {
            if (!DesignMode)
            {
                Core.Initialize();
            }

            InitializeComponent();

            libVLC = new LibVLC();
            Player = new MediaPlayer(libVLC);

            Player.EnableKeyInput = false;
            Player.EnableMouseInput = false;

            videoView1.MediaPlayer = Player;

            loadTimer.Tick += LoadTimer_Tick;
        }
        int _volume;
        public int Volume
        {
            get { return Player.Volume; }
            set
            {
                _volume = value;
                loadTimer.Interval  = 20;
                loadTimer.Start();
            }
        }
        public float Rate
        {
            get { return Player.Rate; }
            set {
                Player.SetRate(value);
            } 
        }
        public bool IsPlaying => Player.IsPlaying;

        private long _time;
        public long Time
        {
            get
            {
                if (Player.Time <= 0) return _time;
                return Player.Time;
            }
            set
            {
                _time = value;

                if (0 > value)
                    Player.Time = 0;
                else if (value > Player.Length)
                {
                    Player.Time = Player.Length -1;
                }
                else
                    Player.Time = value;
            }
        }
        public long Length => Player.Length;

        public bool RequiredReload => Player.State == VLCState.Ended;

        readonly System.Windows.Forms.Timer loadTimer = new();




        public void Stop()
        {
            Player.Stop();
        }

        public void Pause()
        {
            if (Player.IsPlaying)
                Player.Pause();
        }

        public void Play()
        {
            if (!Player.IsPlaying)
                Player.Play();

        }
        public void Play(string filename, params string[] options)
        {
            var media = new Media(libVLC, new Uri(filename), options);
            Player.Play(media);

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
                if (Player.Time != 0)
                {
                    loadTimer.Stop();
                    Player.Pause();
                    requirePause = false;

                }
            }
            if (Volume != _volume)
            {
                if (Player == null) return;
                Player.Volume = _volume;
            }
        }

        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;


        }
    }
}
