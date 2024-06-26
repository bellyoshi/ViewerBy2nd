﻿using ViewerBy2nd.ViewModels;
using Reactive.Bindings;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using ViewerBy2nd.Utils;

namespace ViewerBy2nd
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class ViewerWindow : Window
    {

        public ViewerWindow()
        {

            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);

            this.WindowStyle = WindowStyle.None;

            this.ResizeMode = ResizeMode.NoResize;


            SecondMonitorCommands.SetIsOpenSecondMonitor(true);

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var _viewModel = DataContext as ViewerViewModel;
            Debug.Assert(_viewModel != null);
            // このウィンドウに対応するDPI情報を取得
            //var dpiInfo = VisualTreeHelper.GetDpi(this);

            //_viewModel.SetDpiScale(dpiInfo.DpiScaleX, dpiInfo.DpiScale
            //ウインドウがDPIの違うモニタ―を移動することは考慮していない。

            _viewModel.MediaPosition.Subscribe(position =>
            {

                // UIスレッドでMediaElementのPositionを更新する必要があります。
                Dispatcher.Invoke(() =>
                {
                    viewerMediaElement.Position = position; ;
                });
            });

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SecondMonitorCommands.SetIsOpenSecondMonitor(false);
        }
    }


}

