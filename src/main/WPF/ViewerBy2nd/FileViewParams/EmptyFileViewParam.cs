﻿using ViewerBy2nd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewerBy2nd.FileViewParams
{
    public class EmptyFileViewParam : FileViewParam, ImageSetter
    {
        public static EmptyFileViewParam Instance { get; } = new EmptyFileViewParam();

        public EmptyFileViewParam()
            : base(String.Empty) { }

        private IDisplay? _display;
        public void SetDisplay(IDisplay display)
        {
            this._display = display;
            ExecuteDisplay();
        }

        public void ExecuteDisplay()
        {
            if (this._display == null) return;
            _display.SetImageSource(null);
        }
    }   
    
}
