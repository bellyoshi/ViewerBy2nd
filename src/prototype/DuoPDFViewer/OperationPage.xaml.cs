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
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DuoPDFViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OperationPage : Page
    {
        public OperationPage()
        {
            this.InitializeComponent();

        }

        private MainViewModel ViewModel { get; } = new();


        private void SecondButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NewWindow = new ViewerWindow();
            MainWindow.NewWindow.Activate();
        }




        private PdfDocument doc;
        private PdfPage page;
        private uint pageIndex;



        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await GetFile();
            if (file == null) return;



            ViewModel.Items.Add(file.Path);
 
        }

        private async Task DispPage()
        {
            page = doc.GetPage(pageIndex);
            // ビットマップイメージの作成
            var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
            await page.RenderToStreamAsync(stream);
            Microsoft.UI.Xaml.Media.Imaging.BitmapImage src = new();

            // Imageオブジェクトにsrcをセット
            //imgPdf.Source = src;
            Model.GetInstance().SetSource(src);

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

        private async void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filename = FileListBox.SelectedItem.ToString();
            //filename to IStorageFile
            var file = await StorageFile.GetFileFromPathAsync(filename);

            doc = await PdfDocument.LoadFromFileAsync(file);
            pageIndex = 0;
            await DispPage();
        }
    }
}
