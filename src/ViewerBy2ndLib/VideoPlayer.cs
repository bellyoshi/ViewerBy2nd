﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewerBy2ndLib
{
    public partial class VideoPlayer : UserControl
    {
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
        private float _rate;
        public float Rate
        {
            get { return vlcControl1?.Rate??_rate ; }
            set { if (vlcControl1 == null)
                    _rate = value;
                else
                    vlcControl1.Rate = value; }
        }
        public bool IsPlaying => vlcControl1.IsPlaying;

        private long _time;
        public long Time
        {
            get {
                if (vlcControl1.Time <= 0) return _time;
                return vlcControl1.Time; }
            set {
                _time = value;
                if (vlcControl1 == null) return;
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

        Timer loadTimer = new Timer();
        public VideoPlayer()
        {
            InitializeComponent();
            //InitializeVLCComponent();
            loadTimer.Tick += LoadTimer_Tick;
        }

        private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
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

        private void LoadTimer_Tick(Object sender ,EventArgs  e)
        {
            if (requirePause)
            {
                if(vlcControl1.Time != 0)
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
        private Vlc.DotNet.Forms.VlcControl vlcControl1;
        private void InitializeVLCComponent()
        {
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            this.SuspendLayout();
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl1.Location = new System.Drawing.Point(0, 0);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(452, 339);
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 0;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = null;
            this.vlcControl1.VlcMediaplayerOptions = null;
            this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);

        }

        private void VLCInitializeEnd()
        {
            this.Controls.Add(this.vlcControl1);
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();

            this.ResumeLayout(false);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeVLCComponent();
        }

        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            VLCInitializeEnd();
        }
    }
}
