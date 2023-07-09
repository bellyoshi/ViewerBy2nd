using System;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms.Sample;

namespace LibVLCSharpSample
{
    public partial class Form1 : Form
    {
        public LibVLC _libVLC;
        public MediaPlayer _mp;
        public Form2 form2 = new();

        public Form1()
        {
            if (!DesignMode)
            {
                Core.Initialize();
            }

            InitializeComponent();
            _libVLC = new LibVLC();
            _mp = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mp;
           form2.VideoView.MediaPlayer = _mp;
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2.Show();
            _mp.Play(new Media(_libVLC, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", FromType.FromLocation));
        }
    }
}
