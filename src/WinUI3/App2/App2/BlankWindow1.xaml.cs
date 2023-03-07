// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;



// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankWindow1 : Window
    {
        public BlankWindow1()
        {
            this.InitializeComponent();

            var appWindow = GetAppWindow();



            //セカンドモニターに移動する
            var d = DisplayArea.FindAll()[1];
            //var a = d.FirstOrDefault(c => c.IsPrimary);

            DisplayArea displayArea = d;

            RectInt32 rect = new RectInt32()
            {
                X = 0,
                Y = 0,
                Width = displayArea.WorkArea.Width,
                Height = displayArea.WorkArea.Height
            };
            appWindow.MoveAndResize(rect, displayArea);
            

            //最前面に表示する
            var olp = OverlappedPresenter.Create();
            olp.IsMaximizable = false;
            //最大化ボタン
            olp.IsMinimizable = false; //最小化ボタン
            olp.IsResizable = false; //サイズ変更
            olp.IsAlwaysOnTop = false; //常に最前面に表示
            olp.IsModal= false; //モーダル・モードレス
            appWindow.SetPresenter(olp);
            //フルスクリーンプレゼンターを挿入する
            var fp = FullScreenPresenter.Create();
            appWindow.SetPresenter(fp);

        }




        

        public AppWindow GetAppWindow()
        {
            
                // WinUI3のウインドウのハンドルを取得
                var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
                // そのウインドウのIDを取得
                Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
                // そこからAppWindowを取得する
                Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                return appWindow;
            
        }
    }

}

