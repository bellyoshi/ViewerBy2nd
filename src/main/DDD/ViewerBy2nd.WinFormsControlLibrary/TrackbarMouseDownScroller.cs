using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    internal class TrackbarMouseDownScroller
    {
        private TrackBar trackBar;
        private bool trackBarSeek_Scrolled = false;

        public event Action? TrackBarScrolled;
        public event Action? TrackBarScrollRequire;
        System.Windows.Forms.Timer SeekTimer;

        public TrackbarMouseDownScroller(TrackBar trackBar)
        {
            this.trackBar = trackBar;
            trackBar.MouseDown += SeekTrackBar_MouseDown;
            trackBar.Scroll+=SeekTrackBar_Scroll;
            SeekTimer = new System.Windows.Forms.Timer();
            SeekTimer.Interval = 100;
            SeekTimer.Start();
            // 
            // SeekTimer
            // 
            SeekTimer.Tick+=SeekTimer_Tick;
        }
        void SeekTimer_Tick(object? sender, EventArgs e)
        {
            Trackbar_Seek();
        }

        void SeekTrackBar_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.X < 0 || e.X > trackBar.Width || e.Y < 0 || e.Y > trackBar.Height)
                return;

            var value = GetTrackBarValueOfMouse(e);
            SetValue(value);
            trackBarSeek_Scrolled = true;
            Trackbar_Seek();
        }

        private int GetTrackBarValueOfMouse(MouseEventArgs e)
        {
            if (e.X < 8)
                return trackBar.Minimum;
            if (e.X > trackBar.Width - 8)
                return trackBar.Maximum;
            double seekWidth = trackBar.Width - 16;
            double ticWidth = seekWidth / (trackBar.Maximum - trackBar.Minimum);
            return System.Convert.ToInt32((e.X - 8) / ticWidth) + trackBar.Minimum;   
        }

        public void SetValue(int value)
        {
            trackBar.Value = value;
            trackBarSeek_Scrolled = true;
            Trackbar_Seek();
        }

        private void Trackbar_Seek()
        {
            if (trackBarSeek_Scrolled)
            {
                TrackBarScrolled?.Invoke();
                trackBarSeek_Scrolled = false;
            }
            else
            {
                TrackBarScrollRequire?.Invoke();
            }

        }

        private void SeekTrackBar_Scroll(object? sender, EventArgs e)
        {
            trackBarSeek_Scrolled = true;
        }
    }
}
