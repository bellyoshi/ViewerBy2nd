using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2nd.Models
{
    internal class MovieModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _isMediaPlaying;
        public bool IsMediaPlaying
        {
            get => _isMediaPlaying;
            set
            {
                _isMediaPlaying = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsMediaPlaying)));
            }
        }

        private TimeSpan _mediaPosition;
        public TimeSpan MediaPosition
        {
            get => _mediaPosition;
            set
            {
                _mediaPosition = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MediaPosition)));
            }
        }

        //singleton
        private static MovieModel _instance  = new MovieModel();
        public static MovieModel Instance
        {
            get
            {
                return _instance;
            }
        }

        private string _videoPath =String.Empty;
        public string VideoPath
        {
            get => _videoPath;
            set
            {
                _videoPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VideoPath)));
            }
        }
    }
}
