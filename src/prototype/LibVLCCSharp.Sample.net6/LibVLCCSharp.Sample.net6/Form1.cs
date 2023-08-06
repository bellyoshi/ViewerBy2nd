using System;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using ViewerBy2nd.WinFormsControlLibrary;

namespace LibVLCCSharp.Sample.net6
{
    public partial class Form1 : Form
    {
        public LibVLC _libVLC;
        public MediaPlayer Player;

        public Form1()
        {
            if (!DesignMode)
            {
                Core.Initialize();
            }

            InitializeComponent();

            _libVLC = new LibVLC();
            Player = new MediaPlayer(_libVLC);

            Player.EnableKeyInput = false;
            Player.EnableMouseInput = false;

            videoView1.MediaPlayer = Player;

            Load += Form1_Load;

            var controls = new Control[] { this ,videoView1};
            new FormDragMover(this, 8, controls);
            new FormDragResizer(this, FormDragResizer.ResizeDirection.All, 8, controls);

        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            Player.Play(
                new Media(_libVLC, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", FromType.FromLocation));

        }


    }
}
