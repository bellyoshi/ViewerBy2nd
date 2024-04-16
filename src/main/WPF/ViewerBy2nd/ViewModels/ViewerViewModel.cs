using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Media;
using ViewerBy2nd.Models;
using ViewerBy2nd.Utils;

namespace ViewerBy2nd.ViewModels
{
    internal class ViewerViewModel
    {
        public ReactiveProperty<System.Windows.Media.Imaging.BitmapSource?> ImageSource { get; }


        public ReactiveProperty<TimeSpan> MediaPosition { get; } = new ReactiveProperty<TimeSpan>();
        public ReactiveProperty<TimeSpan> MediaLength { get; } = new ReactiveProperty<TimeSpan>();

        public ReactiveProperty<bool> IsMediaPlaying { get; } = new ReactiveProperty<bool>();

        public ReactiveProperty<string> VideoPath { get; } = new ReactiveProperty<string>();

        public ReactiveProperty<Visibility> IsMovie { get; } = new();
        public ReactiveProperty<Visibility> IsImage { get; } = new();
        public ReactiveCommand FullScreenCommand { get;  } = new();
        public ReactiveCommand WindowModeCommand { get; } = new();
        public ReactiveCommand CloseDisplayCommand { get; } = new();

        public ReactiveProperty<Brush> Background { get; } = new();



        public ReactiveProperty<string> Text { get; } = new();

        public void SetWindowFullScreenManager(IWindowFullScreenManager value) { 
                // コマンドの初期化
            FullScreenCommand.Subscribe(_ => value.IsFullScreen = true);
            WindowModeCommand.Subscribe(_ => value.IsFullScreen = false);
            
        }

        public ViewerViewModel()
        {


        
            var displayModel = DisplayModel.GetInstance();
            ImageSource = displayModel.ToReactivePropertyAsSynchronized(x => x.DisplayImage);
            Background = displayModel.ToReactivePropertyAsSynchronized(x => x.BackColor);





            CloseDisplayCommand.Subscribe(_ => ExecuteCloseDisplay());

            MovieModel movieModel = MovieModel.Instance;

            MediaPosition = movieModel.ToReactivePropertyAsSynchronized(
                               x => x.ViewerMediaPostion
                                              );

            VideoPath = movieModel.ToReactivePropertyAsSynchronized(
                x => x.VideoPath
                );
            IsMediaPlaying = movieModel.ToReactivePropertyAsSynchronized(x => x.IsMediaPlaying);

            IsMediaPlaying.Subscribe(x =>
            {
                SetVisibility();
            });

        }

        void SetVisibility()
        {
            if (!IsMediaPlaying.Value)
            {
                IsMovie.Value = Visibility.Collapsed;
                IsImage.Value = Visibility.Visible;
            }
            else
            {
                IsMovie.Value = Visibility.Visible;
                IsImage.Value = Visibility.Collapsed;

            }

        }


        private void ExecuteCloseDisplay()
        {


        }
    }
}
