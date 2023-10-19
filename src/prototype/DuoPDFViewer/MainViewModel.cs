using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
//todo: this is a sample, not a real implementation
namespace DuoPDFViewer
{
    internal class MainViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        public ReactiveProperty<string> Input { get; }
        public ReadOnlyReactiveProperty<string> InputErrorMessage { get; }
        public ReadOnlyReactiveProperty<string> Output { get; }

        public ReactiveCommand ResetCommand { get; }

        public MainViewModel()
        {
            Input = new ReactiveProperty<string>("",
                ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError)
                .SetValidateAttribute(() => Input);
            InputErrorMessage = Input.ObserveValidationErrorMessage()
                .ToReadOnlyReactiveProperty();

            Output = Input.Delay(TimeSpan.FromSeconds(2))
                .Select(x => x.ToUpper())
                .ToReadOnlyReactiveProperty();

            ResetCommand = Input.Select(x => !string.IsNullOrEmpty(x))
                .ToReactiveCommand()
                .WithSubscribe(() => Input.Value = "");
        }
    }
}
