using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using Windows.Graphics;




namespace DuoPDFViewer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewerWindow : Window
    {
        public ViewerWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(typeof(BlankPage1));

            var appWindow = GetAppWindow();

            RectInt32 rect = GetRect();
            appWindow.MoveAndResize(rect);

            OverlappedPresenter olp = OverlappedPresenterCreate();
            appWindow.SetPresenter(olp);

            //フルスクリーンプレゼンターを挿入する
            var fp = FullScreenPresenter.Create();
            appWindow.SetPresenter(fp);

        }

        private static RectInt32 GetRect()
        {
            DisplayArea displayArea = GetSecondDisplayArea();
            var rect = CreateDisplayRect(displayArea);
            return rect;
        }

        private static OverlappedPresenter OverlappedPresenterCreate()
        {
            //最前面に表示する
            var olp = OverlappedPresenter.Create();
            olp.IsMaximizable = false; //最大化ボタン
            olp.IsMinimizable = false; //最小化ボタン
            olp.IsResizable = false; //サイズ変更
            olp.IsAlwaysOnTop = false; //常に最前面に表示
            olp.IsModal= false; //モーダル・モードレス
            return olp;
        }

        private static RectInt32 CreateDisplayRect( DisplayArea displayArea)
            => new RectInt32()
        {
            X = 0,
            Y = 0,
            Width = displayArea.WorkArea.Width,
            Height = displayArea.WorkArea.Height
        };


        private static DisplayArea GetSecondDisplayArea()
        {
            //セカンドモニターに移動する
            var displayAreaList = DisplayArea.FindAll();

            //var a = d.First(c => !c.IsPrimary);//Specified cast is not valid 実行時エラー
            for (int i = 0; i < displayAreaList.Count; i++)
            {
                if (!displayAreaList[i].IsPrimary)
                {
                    return displayAreaList[i];
                }
            }

            return displayAreaList[0];
        }





        public AppWindow GetAppWindow()
        {
            
            // WinUI3のウインドウのハンドルを取得
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            // そのウインドウのIDを取得
            Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            // そこからAppWindowを取得する
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
                return appWindow;
            
        }


    }

}

