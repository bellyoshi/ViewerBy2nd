using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2ndLib
{
    public class VideoPlayerPair
    {
        public IVideoPlayer ThumbnailPlayer { get; set; }
        public IVideoPlayer ViewerPlayer { get; set; }

        public void Play()
        {
            if(ViewerPlayer == null)
                ThumbnailPlayer.Play();
            else
                ViewerPlayer.Play();
        }
    }
}
