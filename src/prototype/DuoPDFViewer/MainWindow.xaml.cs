// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.


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

namespace DuoPDFViewer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        BlankWindow1 newWindow;
        public MainWindow()
        {
            this.InitializeComponent();
            Handle = this;
        }

        private void SecondButton_Click(object sender, RoutedEventArgs e)
        {
            //var newWindow = WindowHelper.CreateWindow();
            //var rootPage = new BlankPage1();
            //newWindow.Content = rootPage;
            //newWindow.Activate();

            //BlankWindow1を開く
            newWindow = new BlankWindow1();
            newWindow.Activate();
        }
        private void Window_Closed(object sender, WindowEventArgs e)
        {
            newWindow?.Close();
        }



        private PdfDocument doc;
        private PdfPage page;
        private uint pageIndex;

        public static MainWindow Handle { get; private set; }

        private async void OpenButton_Click(object sender, RoutedEventArgs e)
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
            BitmapImage src = new();

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
            if (pageIndex <= 0) return;
            pageIndex--;
            await DispPage();
        }

    }
}

            
