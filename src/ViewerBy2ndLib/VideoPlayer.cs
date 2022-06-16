using System;
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
        public float Rate
        {
            get { return vlcControl1.Rate; }
            set { vlcControl1.Rate = value; }
        }
        public bool IsPlaying => vlcControl1.IsPlaying;
        public long Time
        {
            get { return vlcControl1.Time; }
            set { vlcControl1.Time = value; }
        }

        public long Length => vlcControl1.Length;


        Timer loadTimer = new Timer();
        public VideoPlayer()
        {
            InitializeComponent();
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
        }
    

    }
}
