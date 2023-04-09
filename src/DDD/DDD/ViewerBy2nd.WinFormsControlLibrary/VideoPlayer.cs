using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewerBy2ndLib;
using Vlc.DotNet.Forms;

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
            get { return vlcControl1?.VlcMediaPlayer?.Audio?.Volume??-1; }
            set
            {
                _volume = value;
                loadTimer.Interval  = 20;
                loadTimer.Start();
            }
        }
        public float Rate
        {
            get { return vlcControl1.Rate; }
            set { vlcControl1.Rate = value; }
        }
        public bool IsPlaying => vlcControl1.IsPlaying;

        private long _time;
        public long Time
        {
            get
            {
                if (vlcControl1.Time <= 0) return _time;
                return vlcControl1.Time;
            }
            set
            {
                _time = value;

                if (0 > value)
                    vlcControl1.Time = 0;
                else if (value > vlcControl1.Length)
                {
                    vlcControl1.Time = vlcControl1.Length -1;
                }
                else
                    vlcControl1.Time = value;
            }
        }
        public long Length => vlcControl1.Length;

        public bool RequiredReload => vlcControl1.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended;

        System.Windows.Forms.Timer loadTimer = new();


        private void vlcControl1_VlcLibDirectoryNeeded(object? sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = VLCDirectoryGetter.GetVlcLibDirectory();
        }

        public void Stop()
        {
            vlcControl1.Stop();
        }

        public void Pause()
        {
            if (vlcControl1.IsPlaying)
                vlcControl1.Pause();
        }

        public void Play()
        {
            if (!vlcControl1.IsPlaying)
                vlcControl1.Play();

        }
        public void Play(string filename, params string[] options)
        {
            vlcControl1.Play(new Uri($"file://{filename}"), options);

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
                if (vlcControl1.Time != 0)
                {
                    loadTimer.Stop();
                    vlcControl1.Pause();
                    requirePause = false;

                }
            }
            if (Volume != _volume)
            {
                if (vlcControl1.VlcMediaPlayer == null) return;
                vlcControl1.VlcMediaPlayer.Audio.Volume = _volume;
            }
        }
        Vlc.DotNet.Forms.VlcControl vlcControl1;
        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            Debug.Assert(false);
            vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            vlcControl1.BeginInit();
            vlcControl1.VlcLibDirectoryNeeded += vlcControl1_VlcLibDirectoryNeeded;
            vlcControl1.Dock = DockStyle.Fill;
            vlcControl1.EndInit();

            Controls.Add(vlcControl1);

        }
    }
}
