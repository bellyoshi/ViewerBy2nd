﻿using System.Windows.Input;

namespace ViewerBy2nd.ViewModels
{
    public class MenuItemViewModel
    {
        public string? Header { get; set; }
        public ICommand? Command { get; set; }
        // 必要に応じて他のプロパティや子メニュー項目のコレクションも追加できます
    }
}
