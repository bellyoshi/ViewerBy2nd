﻿using Reactive.Bindings;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewerBy2nd.FileViewParams;

namespace ViewerBy2nd.ViewModels;


public class SearchResultViewModel
{
    private ReactiveProperty<bool> _isSelected = new ReactiveProperty<bool>();
    public ReactiveProperty<bool> IsSelected
    {
        get { return _isSelected; }
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    public FileViewParam FileViewParam { get; }

    public SearchResultViewModel(FileViewParam fileViewParam)
    {
        IsSelected = new ReactiveProperty<bool>(false);
        this.FileViewParam = fileViewParam;
    }


}
