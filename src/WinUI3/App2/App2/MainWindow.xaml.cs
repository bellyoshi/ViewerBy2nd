// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using AppUIBasics;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App2
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
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            //var newWindow = WindowHelper.CreateWindow();
            //var rootPage = new BlankPage1();
            //newWindow.Content = rootPage;
            //newWindow.Activate();

            //BlankWindow1‚ðŠJ‚­
            newWindow = new BlankWindow1();
            newWindow.Activate();
        }
        private void Window_Closed(object sender, WindowEventArgs e)
        {
            newWindow?.Close();
        }
    }
}
            
