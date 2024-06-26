﻿using Reactive.Bindings.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewerBy2nd;

internal class FileOpenReactiveConverter : ReactiveConverter<RoutedEventArgs, string>
{

    protected override IObservable<string> OnConvert(IObservable<RoutedEventArgs?> source)
    {
        return source.Select(_ =>
        {
            // ファイルを開くダイアログを表示
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "Document", // Default file name
                DefaultExt = ".pdf", // Default file extension
                Filter = FileTypes.CreateFilter(), // Default file extension
            };

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                return dialog.FileName;
            }
            return string.Empty;
        });

    }

}
