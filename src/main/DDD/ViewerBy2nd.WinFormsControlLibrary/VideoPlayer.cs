using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System.ComponentModel;
using System.Diagnostics;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    public partial class VideoPlayer 
    {
        private VideoView VideoView1 { get; set; }
        private LibVLC? libVLC;
        private MediaPlayer? Player;

        public VideoPlayer(VideoView videoView)
        {
            VideoView1 = videoView;
            Init();
            loadTimer.Tick += LoadTimer_Tick;
        }

        async void Init()
        {
            await Task.Run(() => InitializeLibVLC());
            VideoView1.MediaPlayer = Player;
        }
        private bool IsInitilaized = false;
        void InitializeLibVLC()
        {
            if(IsInitilaized)
            {
                return;
            }
            IsInitilaized = true;
            Core.Initialize();


            libVLC = new();
            Player = new(libVLC)
            {
                EnableKeyInput = false,
                EnableMouseInput = false
            };


        }

        int _volume;
        public int Volume
        {
            get { return Player?.Volume??0; }
            set
            {
                _volume = value;
                loadTimer.Interval  = 20;
                loadTimer.Start();
            }
        }
        public float Rate
        {
            get { return Player?.Rate ?? 0; }
            set {
                Player?.SetRate(value);
            } 
        }
        public bool IsPlaying => Player?.IsPlaying??false;

        private long _time;
        public long Time
        {
            get
            {
                if (Player?.Time <= 0) return _time;
                return Player?.Time ?? 0;
            }
            set
            {
                _time = value;

                if (0 > value)
                {
                    if(Player != null)
                        Player.Time = 0;
                }

                else if (value > Player.Length)
                {
                    Player.Time = Player.Length -1;
                }
                else
                    Player.Time = value;
            }
        }
        public long Length => Player?.Length ?? 0;

        public bool RequiredReload => Player?.State == VLCState.Ended;

        readonly System.Windows.Forms.Timer loadTimer = new();




        public void Stop()
        {
            Player?.Stop();
        }

        public void Pause()
        {
            if (Player?.IsPlaying == true)
                Player.Pause();
        }

        public void Play()
        {
            if (Player?.IsPlaying == false)
                Player.Play();

        }
        public void Play(string filename, params string[] options)
        {
            Debug.Assert(libVLC != null);
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
                if (Player?.Time != 0)
                {
                    loadTimer.Stop();
                    Player?.Pause();
                    requirePause = false;

                }
            }
            if (Volume != _volume)
            {
                if (Player == null) return;
                Player.Volume = _volume;
            }
        }


    }
}
