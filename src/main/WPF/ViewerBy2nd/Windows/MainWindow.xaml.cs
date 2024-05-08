using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewerBy2nd.ViewModels;

namespace ViewerBy2nd.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool hasMediaLength = false;
    public MainWindow()
    {
        InitializeComponent();

        //メイン操作ウィンドウを閉じたらアプリケーションを終了する
        this.Closed += (s, e) => Application.Current.Shutdown();
        var _viewModel = DataContext as MainViewModel;
        System.Diagnostics.Debug.Assert(_viewModel != null);
        _viewModel.MediaPosition.Subscribe(position =>
        {
            if (mainMediaElement.NaturalDuration.HasTimeSpan && !hasMediaLength)
            {
                _viewModel.MediaLength.Value = mainMediaElement.NaturalDuration.TimeSpan;
                hasMediaLength = true;
            }


        });
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }
}