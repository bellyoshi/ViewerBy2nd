﻿using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2nd.ViewModels
{
    interface ISliderViewModel
    {
        public ReactiveProperty<double> RequiredValue { get; }
    }
}
