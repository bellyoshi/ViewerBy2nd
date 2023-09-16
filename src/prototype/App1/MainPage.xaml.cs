using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Pdf;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml.Hosting;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace App1
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {


        private ApplicationView _subWindowApplicationView;
        private ViewerPage _viewerPage = new ViewerPage();

        public MainPage()
        {
            this.InitializeComponent();
        }
        private PdfDocument doc;

        private uint pageIndex;



        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await GetFile();
            if (file == null) return;

            doc = await PdfDocument.LoadFromFileAsync(file);
            pageIndex = 0;

            DispPage();
        }

        private async void DispPage()
        {
            await _viewerPage.DispPage(doc,pageIndex);
        }
        private async void DispButton_Click(object sender, RoutedEventArgs e)
        {

            var frame = new Frame();
            frame.Navigate(typeof(ViewerPage));
            _viewerPage = frame.Content as ViewerPage;

            var appWindow = await AppWindow.TryCreateAsync();
            ElementCompositionPreview.SetAppWindowContent(appWindow, frame);

            await appWindow.TryShowAsync();


        }

        private static async Task<StorageFile> GetFile()
        {
            var openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            openPicker.FileTypeFilter.Add(".pdf");
            IAsyncOperation<StorageFile> asyncOp = openPicker.PickSingleFileAsync();
            StorageFile file = await asyncOp;
            return file;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (doc.PageCount <= pageIndex + 1)
                return;

            pageIndex++;
            DispPage();

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex <= 0) return;
            pageIndex--;
            DispPage();
        }
    }
    
}
