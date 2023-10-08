

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Windows.Graphics;




namespace DuoPDFViewer
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
            var d = DisplayArea.FindAll();
            
            //var a = d.FirstOrDefault(c => !c.IsPrimary);todo:実行時エラー
            DisplayArea displayArea = d[0];
            for(int i=0; i < d.Count; i++)
            {
                if (!d[i].IsPrimary)
                {
                    displayArea = d[i];
                    break;
                }
            }



            RectInt32 rect = new ()
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

