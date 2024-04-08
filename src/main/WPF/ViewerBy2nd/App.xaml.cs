using System.Configuration;
using System.Data;
using System.Windows;
using ViewerBy2nd.Utils;

namespace ViewerBy2nd
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static public DependencyContainer Container { get; } = new();


    }

}
