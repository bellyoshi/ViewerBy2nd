using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace ViewerBy2nd.Behaviors
{
    internal class CloseViewerBehavior : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            Utils.WindowUtil.CloseWindow<ViewerWindow>();
        }
    
    }
}
