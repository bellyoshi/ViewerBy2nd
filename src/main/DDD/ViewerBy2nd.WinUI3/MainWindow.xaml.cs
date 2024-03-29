using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using WinRT.Interop;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ViewerBy2nd.WinUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private PdfDocument doc;
        private PdfPage page;
        private uint pageIndex;
        public MainWindow()
        {
            this.InitializeComponent();
            Handle = this;
            
        }
        public static MainWindow Handle { get; private set; }

        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await GetFile();
            if (file == null) return;

            doc = await PdfDocument.LoadFromFileAsync(file);
            pageIndex = 0;

            await DispPage();
        }

        private async Task DispPage()
        {
            page = doc.GetPage(pageIndex);
            // ビットマップイメージの作成
            var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
            await page.RenderToStreamAsync(stream);
            BitmapImage src = new ();

            // Imageオブジェクトにsrcをセット
            imgPdf.Source = src;

            // srcに作成したビットマップイメージを流し込む
            await src.SetSourceAsync(stream);
        }

        private static async Task<StorageFile> GetFile()
        {
            var openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            openPicker.FileTypeFilter.Add(".pdf");
            InitializeWithWindow.Initialize(openPicker,
             WindowNative.GetWindowHandle(MainWindow.Handle));
            IAsyncOperation<StorageFile> asyncOp = openPicker.PickSingleFileAsync();
            StorageFile file = await asyncOp;
            return file;
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (doc.PageCount <= pageIndex + 1)
                return;
            
                pageIndex++;
                await DispPage();
            
        }

        private async void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if(pageIndex <= 0) return;
            pageIndex--;
            await DispPage();
        }

    }
}
