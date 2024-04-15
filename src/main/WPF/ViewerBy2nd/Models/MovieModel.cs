using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
                MediaPositionSubscrive();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MediaPosition)));
            }
        }

        void MediaPositionSubscrive()
        {
            //ViewerWindowのMediaElementのPositionを更新
            //差が0.1s以上ある場合のみ更新
            if ((ViewerMediaPostion - MediaPosition).Duration() >  TimeSpan.FromMilliseconds(1000))
            {

                Debug.WriteLine($"ViewerMediaPostion:{ViewerMediaPostion}");
                Debug.WriteLine($"MediaPosition:{MediaPosition}");
                ViewerMediaPostion = MediaPosition;
            }
            //todo: Viewerが開かれているときはMediaPositionを更新する
        }

        private TimeSpan _viewerMediaPostion;
        public TimeSpan ViewerMediaPostion
        { 
            get => _viewerMediaPostion;
            set
            {
                _viewerMediaPostion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ViewerMediaPostion)));
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
