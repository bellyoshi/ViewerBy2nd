using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Reflection.Metadata;
using WinRT.Interop;
using Windows.Data.Pdf;
using Windows.Graphics.Imaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ViewerBy2nd.WinUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Handle = this;
        }
        public static MainWindow Handle { get; private set; }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.List;
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add(".pdf");
            InitializeWithWindow.Initialize(openPicker,
             WindowNative.GetWindowHandle(MainWindow.Handle));
            IAsyncOperation<StorageFile> asyncOp = openPicker.PickSingleFileAsync();
            StorageFile file = await asyncOp;
            if (file == null)
            {
                return;
            }
            var doc = await PdfDocument.LoadFromFileAsync(file);
            var page = doc.GetPage(0);
            // ビットマップイメージの作成
            var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
            await page.RenderToStreamAsync(stream);
            BitmapImage src = new BitmapImage();

            // Imageオブジェクトにsrcをセット
            imgPdf.Source = src;

            // srcに作成したビットマップイメージを流し込む
            await src.SetSourceAsync(stream);
        }


    }
}
