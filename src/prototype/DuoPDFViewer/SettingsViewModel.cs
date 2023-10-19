using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoPDFViewer
{
    internal class SettingsViewModel
    {
        ScreenModel screenModel = ScreenModel.GetInstance();
        public ReactivePropertySlim<bool> IsFullScreen { get; }//= new ReactivePropertySlim<bool>(false);

        public SettingsViewModel()
        {
            IsFullScreen = screenModel.ToReactivePropertySlimAsSynchronized(x => x.IsFullScreen);
            
            IsFullScreen.Subscribe(IsFullScreen =>
            {
                Debug.WriteLine(IsFullScreen);
            });
        }
    }
}
