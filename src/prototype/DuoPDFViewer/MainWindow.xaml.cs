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

        }
        private void Window_Closed(object sender, WindowEventArgs e)
        {
            NewWindow?.Close();
        }
    }
}

            
