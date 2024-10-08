﻿using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ViewerBy2nd.FileViewParams;
using ViewerBy2nd.Models;

namespace ViewerBy2nd.ViewModels;

internal class MainViewModel : ISliderViewModel
{

    private void UpdateMediaPosition()
    {
        // このメソッド内で、必要に応じてMediaPositionの更新ロジックを実装
    }

    public ReactiveProperty<Brush> ImageBackgroundColor { get; }
    public ReactiveCollection<SearchResultViewModel> FilesList { get; }

    public ObservableCollection<MenuItemViewModel> ListMenuItems { get; }

    public ReactiveProperty<string> VideoPath { get; } = new(); 

    public ReactiveProperty<FileViewParam> PreviewFile { get; } = new(EmptyFileViewParam.Instance);

    public ReactiveProperty<FileViewParam> DisplayFile { get; } = new();

    private readonly PdfCommands pdfCommands;

    private readonly FileListsCommands fileListsCommands;
    public ReactiveProperty<BitmapSource?> PreviewImage { get; } = new();
    public ReactiveProperty<BitmapSource?> DisplayImage { get; } = new();

    public ReactiveProperty<Visibility> IsPdf { get; } = new();

    public ReactiveProperty<Visibility> IsMovie { get; } = new();
    public ReactiveProperty<Visibility> IsImage { get; } = new();

    public ReactiveProperty<bool> IsAutoDisplayEnabled { get; }
    // ファイルメニュー
    public ReactiveCommand<string> AppendFile { get; }
    public ReactiveCommand<string> OpenCommand { get; } 

    //DeselectAllCommand
    public ReactiveCommand DeselectAllCommand { get; } 
    //SelectAllCommand
    public ReactiveCommand SelectAllCommand { get; } 
    public ReactiveCommand DeleteCommand { get; } 

    // 表示メニュー
    private RotateCommands RotateCommands { get; }
    public ReactiveCommand RotateOriginalCommand { get; } 
    public ReactiveCommand RotateRight90Command { get; } 
    public ReactiveCommand RotateLeft90Command { get; } 
    public ReactiveCommand Rotate180Command { get; } 

    // ページナビゲーション
    public ReactiveCommand FirstPageCommand { get; } 
    public ReactiveCommand NextPageCommand { get; }
    public ReactiveCommand PreviousPageCommand { get; } 
    public ReactiveCommand LastPageCommand { get; } 
    public ReactiveCommand SpecifyPageCommand { get; } 

    // ズーム
    private ZoomCommands ZoomCommands { get; }
    public ReactiveCommand FitWidthCommand { get; } = new ();
    public ReactiveCommand ShowAllCommand { get; } = new ();
    public ReactiveCommand ZoomInCommand { get; } = new ();
    public ReactiveCommand ZoomOutCommand { get; } = new ();

    private MovieCommands MovieCommands { get; }
    public ReactiveProperty<double> RequiredValue { get; } 
    public ReactiveProperty<bool> IsMediaPlaying { get; }
    public ReactiveProperty<TimeSpan> MediaPosition { get; } 
    public ReactiveProperty<TimeSpan> MediaLength { get; } 

    public ReactiveProperty<double> PositionValue { get; } 
    public ReactiveProperty<double> LengthValue { get; }

    // 再生
    public ReactiveCommand MoveToStartCommand { get; } 
    public ReactiveCommand StartPlayingCommand { get; } 
    public ReactiveCommand PausePlayingCommand { get; } 
    public ReactiveCommand FastForwardCommand { get; } 
    public ReactiveCommand RewindCommand { get; } 

    // セカンドモニター操作
    SecondMonitorCommands SecondMonitorCommands { get; }
    public ReactiveCommand ShowOnSecondMonitorCommand { get; }
    public ReactiveCommand EndShowOnSecondMonitorCommand { get; } 
    public ReactiveCommand ShowBackgroundOnSecondMonitorCommand { get; }

    // 設定メニュー
    public ReactiveCommand DisplaySettingsCommand { get; } = new ();
    public ReactiveCommand AutoShowCommand { get; } = new ();
    public ReactiveCommand SlimSizeCommand { get; } = new ();
    public ReactiveCommand StandardSizeCommand { get; } = new ();

    // ヘルプメニュー
    public ReactiveCommand AboutCommand { get; } = new ();

    public ReactiveProperty<int> PageCount { get; } = new();
    public ReactiveProperty<int> CurrentPage { get; } = new();

    public MainViewModel()
    {




        fileListsCommands = new(PreviewFile);
        FilesList = fileListsCommands.FilesList;
        ListMenuItems = fileListsCommands.ListMenuItems;
        AppendFile = fileListsCommands.CreateAppendFile();
        OpenCommand = fileListsCommands.CreateOpenCommand();
        DeselectAllCommand = fileListsCommands.CreateDeselectAllCommand();
        SelectAllCommand = fileListsCommands.CreateSelectAllCommand();
        DeleteCommand = fileListsCommands.CreateDeleteCommand();







        DisplayModel display = DisplayModel.GetInstance();
        ImageBackgroundColor = display.ToReactivePropertyAsSynchronized(x => x.BackColor);
        PreviewImage = display.ToReactivePropertyAsSynchronized(x => x.PreviewImage);
        DisplayImage = display.ToReactivePropertyAsSynchronized(x => x.DisplayImage);

        IsAutoDisplayEnabled = display.ToReactivePropertyAsSynchronized(x => x.IsAutoDisplayEnabled);
        SecondMonitorCommands = new( PreviewImage, DisplayImage);
        
        ShowOnSecondMonitorCommand = SecondMonitorCommands.CreateShowOnSecondMonitorCommand();
        EndShowOnSecondMonitorCommand = SecondMonitorCommands.CreateEndShowOnSecondMonitorCommand();
        ShowBackgroundOnSecondMonitorCommand = SecondMonitorCommands.CreateShowBackgroundOnSecondMonitorCommand();

        MovieModel movieModel = MovieModel.Instance;
        VideoPath = movieModel.ToReactivePropertyAsSynchronized(x => x.VideoPath);

        PreviewFile.Subscribe(file =>
        {
            if (file is ImageSetter imageSetter)
            {
                imageSetter.SetDisplay(DisplayModel.GetInstance());
            }
            if (file is MovieFileViewParam movieFileViewParam)
            {
                VideoPath.Value = movieFileViewParam.filename;
            }
            else
            {
                VideoPath.Value = String.Empty;     
            
            }
            bool visible = file is PdfFileViewParam or EmptyFileViewParam;
            IsPdf.Value = visible ? Visibility.Visible : Visibility.Collapsed;
            IsMovie.Value = file is MovieFileViewParam ? Visibility.Visible : Visibility.Collapsed;
            IsImage.Value = file is ImageSetter ? Visibility.Visible : Visibility.Collapsed;
        });

        // 各コマンドのアクションを設定
        RotateCommands = new(PreviewFile);
        RotateOriginalCommand = RotateCommands.CreateRotateOriginalCommand();
        RotateRight90Command = RotateCommands.CreateRotateRight90Command();
        RotateLeft90Command = RotateCommands.CreateRotateLeft90Command();
        Rotate180Command = RotateCommands.CreateRotate180Command();

        pdfCommands = new(PreviewFile, PageCount, CurrentPage);
        FirstPageCommand = pdfCommands.CreateFirstPageCommand();
        NextPageCommand = pdfCommands.CreateNextPageCommand();
        PreviousPageCommand = pdfCommands.CreatePreviousPageCommand();
        LastPageCommand = pdfCommands.CreateLastPageCommand();
        SpecifyPageCommand = pdfCommands.CreateSpecifyPageCommand();

        ZoomCommands = new(PreviewFile);
        FitWidthCommand = ZoomCommands.FitWidthCommand;
        ShowAllCommand = ZoomCommands.ShowAllCommand;
        ZoomInCommand = ZoomCommands.CreateZoomInCommand();
        ZoomOutCommand = ZoomCommands.CreateZoomOutCommand();

        MovieCommands = new(PreviewFile);


        MoveToStartCommand = MovieCommands.CreateMoveToStartCommand();
        StartPlayingCommand = MovieCommands.CreateStartPlayingCommand();
        PausePlayingCommand = MovieCommands.CreatePausePlayingCommand();
        FastForwardCommand = MovieCommands.CreateFastForwardCommand();
        RewindCommand = MovieCommands.CreateRewindCommand();

        IsMediaPlaying = MovieCommands.IsMediaPlaying;
        MediaPosition = MovieCommands.MediaPosition;
        MediaLength = MovieCommands.MediaLength;
        PositionValue = MovieCommands.PositionValue;
        LengthValue = MovieCommands.LengthValue;
        RequiredValue = MovieCommands.RequiredValue;




        DisplaySettingsCommand.Subscribe(_ => ExecuteDisplaySettings());
        SlimSizeCommand.Subscribe(_ => ExecuteSlimSize());
        StandardSizeCommand.Subscribe(_ => ExecuteStandardSize());

        AboutCommand.Subscribe(_ => ExecuteAbout());


    }





 



    




  



  

    private void ExecuteDisplaySettings()
    {
        // 「ディスプレイと背景色の設定」の処理

    }



    private void ExecuteSlimSize()
    {
        // 「スリムサイズ」の設定
    }

    private void ExecuteStandardSize()
    {
        // 「標準サイズ」の設定
    }

    private void ExecuteAbout()
    {
        // 「このアプリについて」の処理
    }



  



}
