using System;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace App1
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class ViewerPage : Page
    {
        public ViewerPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView
  .GetForCurrentView().TryEnterFullScreenMode();
        }


        public async Task DispPage(PdfDocument doc, uint pageIndex)
        {    
            PdfPage page = doc.GetPage(pageIndex);
            // ビットマップイメージの作成
            var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
            await page.RenderToStreamAsync(stream);
            BitmapImage src = new BitmapImage();
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {                // Imageオブジェクトにsrcをセット
                imgPdf.Source = src;
            });


            // srcに作成したビットマップイメージを流し込む
            await src.SetSourceAsync(stream);
        }


    }
}
