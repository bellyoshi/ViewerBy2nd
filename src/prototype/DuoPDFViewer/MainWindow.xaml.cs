//todo viewmodel
//todo model

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public static MainWindow Handle { get; private set; }

        public static ViewerWindow NewWindow { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();
            Handle = this;
            ContentFrame.Navigate(typeof(OperationPage));

        }
        private void Window_Closed(object sender, WindowEventArgs e)
        {
            NewWindow?.Close();
        }

        private void NavigationView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var navItemTag = args.InvokedItemContainer.Tag.ToString();
            if(args.IsSettingsInvoked)
            {
                navItemTag = "SettingsPage";
            }
            Navigate(navItemTag);
        }
        private void Navigate(string navItemTag)
        {
            Type _pageType = null;

            switch (navItemTag)
            {
                case "Operaton":
                    _pageType = typeof(OperationPage);
                    break;

                case "SettingsPage":
                    _pageType = typeof(SettingsPage);
                    break;
            }

            if (_pageType != null && ContentFrame.CurrentSourcePageType != _pageType)
            {
                ContentFrame.Navigate(_pageType);
            }
        }
    }
}

            
