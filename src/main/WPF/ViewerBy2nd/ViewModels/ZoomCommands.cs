using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewerBy2nd.FileViewParams;

namespace ViewerBy2nd.ViewModels
{
    public class ZoomCommands
    {
        private readonly List<double> Scales = new List<double> { 1.29 , 8.33, 25, 33.3, 50, 66.7, 75, 100,
            125, 150, 200, 250, 300, 400, 600, 800, 1200, 1600, 2400, 3200, 6400};//%表示

        public ZoomCommands(ReactiveProperty<FileViewParam> selectedFile)
        {
            this.SelectedFile = selectedFile;

            FitWidthCommand.Subscribe(_ => ExecuteFitWidth());
            ShowAllCommand.Subscribe(_ => ExecuteShowAll());
            selectedFile.Subscribe(_ => SetFlag());
        }

        private ReactiveProperty<bool> CanZoomIn { get; } = new ReactiveProperty<bool>(false);
        private ReactiveProperty<bool> CanZoomOut { get; } = new ReactiveProperty<bool>(false);
        private DocuGraphFileViewParam? docuGraphFileViewParam => SelectedFile.Value as DocuGraphFileViewParam;
        private ReactiveProperty<FileViewParam> SelectedFile { get; }

        public ReactiveCommand CreateZoomInCommand()
        {
            var command = CanZoomIn.ToReactiveCommand();
            command.Subscribe(_ => ExecuteZoomIn());
            return command;
        }

        private void ExecuteZoomIn()
        {
            if (docuGraphFileViewParam == null) return;
            docuGraphFileViewParam.Scale = Scales.SkipWhile(x => x <= docuGraphFileViewParam?.Scale).First();
            SetFlag();
        }

        public ReactiveCommand CreateZoomOutCommand()
        {
            var command = CanZoomOut.ToReactiveCommand();
            command.Subscribe(_ => ExecuteZoomOut());
            return command;
        }

        private void ExecuteZoomOut()
        {
            if (docuGraphFileViewParam == null) return;
            docuGraphFileViewParam.Scale = Scales.TakeWhile(x => x < docuGraphFileViewParam?.Scale).Last();
            SetFlag();
        }

        public ReactiveCommand FitWidthCommand { get; private set; } = new();

        public ReactiveCommand ShowAllCommand { get; private set; } = new();


        private void ExecuteFitWidth()
        {
            // 「ウィンドウ幅に合わせる」のズーム処理
            if( docuGraphFileViewParam == null) return;
            docuGraphFileViewParam.Scale = 100; //todo:適切な値を設定
            SetFlag();
        }

        private void ExecuteShowAll()
        {

            // 「全体を表示」のズーム処理
            if (docuGraphFileViewParam == null) return;
            docuGraphFileViewParam.Scale = 100; //todo:適切な値を設定
            SetFlag();
        }

        private void SetFlag()
        {
            CanZoomIn.Value = docuGraphFileViewParam?.Scale < Scales.Last();
            CanZoomOut.Value = docuGraphFileViewParam?.Scale > Scales.First();
        }
    }
}
