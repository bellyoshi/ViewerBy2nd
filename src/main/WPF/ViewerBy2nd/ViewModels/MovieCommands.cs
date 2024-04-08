using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using ViewerBy2nd.Models;
using Reactive.Bindings.Extensions;

namespace ViewerBy2nd.ViewModels
{
    public class MovieCommands
    {
        public ReactiveProperty<bool> IsMediaPlaying { get; }
        public ReactiveProperty<TimeSpan> MediaPosition { get; } 
        public ReactiveProperty<double> RequiredValue { get; } = new();
        public ReactiveProperty<TimeSpan> MediaLength { get; } = new ();

        public ReactiveProperty<double> PositionValue { get; } = new ReactiveProperty<double>(500);
        public ReactiveProperty<double> LengthValue { get; } = new ReactiveProperty<double>(1000);
        // 再生
        public ReactiveCommand CreateMoveToStartCommand() { 
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecuteMoveToStart());
            return command;
        } 
        public ReactiveCommand CreateStartPlayingCommand() {
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecuteStartPlaying());
            return command;
        
        } 
        public ReactiveCommand CreatePausePlayingCommand() {
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecutePausePlaying());
            return command;
        } 
        public ReactiveCommand CreateFastForwardCommand() { 
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecuteFastForward());
            return command;
        } 
        public ReactiveCommand CreateRewindCommand() {
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecuteRewind());
            return command;
        } 

        public MovieCommands(ReactiveProperty<FileViewParams.FileViewParam> file)
        {

            var model = MovieModel.Instance;
            MediaPosition = model.ToReactivePropertyAsSynchronized(x => x.MediaPosition);
            IsMediaPlaying = model.ToReactivePropertyAsSynchronized(x => x.IsMediaPlaying);
            IsMediaPlaying.Value = false;


            MediaPosition.Subscribe(position =>
            {
                PositionValue.Value = position.TotalMilliseconds;
            });
            MediaLength.Subscribe(length =>
            {
                LengthValue.Value = length.TotalMilliseconds;
            });

            RequiredValue.Subscribe(value =>
            {
                MediaPosition.Value = TimeSpan.FromMilliseconds(value);

            });
        }

        private void ExecuteMoveToStart()
        {
            // 「最初に移動」の処理
            MediaPosition.Value = TimeSpan.Zero;

        }

        private void ExecuteStartPlaying()
        {
            // 「再生開始」の処理
            IsMediaPlaying.Value = true;
        }

        private void ExecutePausePlaying()
        {
            // 「一時停止」の処理
            IsMediaPlaying.Value = false;
        }

        private void ExecuteFastForward()
        {
            // 「早送り」の処理
        }

        private void ExecuteRewind()
        {
            // 「巻き戻し」の処理
        }
    }
}
