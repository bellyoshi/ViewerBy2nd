using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Reactive.Bindings;
using System.Windows;
using System.Diagnostics;
using System.Configuration;
using ViewerBy2nd.Windows;



namespace ViewerBy2nd.Utils;

interface IWindowFullScreenManager
{
    public int ScreenIndex { get; set; }
    public bool IsFullScreen { get; set; }
}
internal class WindowFullScreenManager: IWindowFullScreenManager
{
    private Win32Api.WindowBoundsManager _windowBoundsManager;

    public WindowFullScreenManager(Window window)
    {
        _windowBoundsManager = new(window);
        _window = window;
        SetEvents();

    }

    public Rectangle FullScreenWindowLayout => System.Windows.Forms.Screen.AllScreens[ScreenIndex].Bounds;

    private int _screenIndex = 0;
    public int ScreenIndex { 
        get => _screenIndex;
        set { 
            _screenIndex = value;
            IsFullScreen = true;
        }
    }

    private Window _window;
    public Window Window { 
        get => _window;
        set => SetWindow(value);
    }

    private void SetWindow(Window value)
    {
        DeleteEvents();
        _windowBoundsManager = new(value);
        _window = value;
        SetEvents();
    }

    private void SetEvents()
    {
        _window.Closing += Window_Closed;
        _window.Loaded += Window_Loaded;
    }

    private void DeleteEvents()
    {
        _window.Closed -= Window_Closed;
        _window.Loaded -= Window_Loaded;
    }

    private double top;
    private double left;
    private double height;
    private double width;


    private bool _IsFullScreen;
    public bool IsFullScreen
    {
        get => _IsFullScreen;
        set => SetIsFullScreen(value);
    }

    private void SetIsFullScreen(bool value)
    {
        if(value && !_IsFullScreen)
        {
            //windowモードからフルスクリーンに切り替えられたときに前の状態保持
            BackupWindowBound();
        }
        if (value)
        {
            _IsFullScreen = true;
            SetFullScreenBound();
        }
        else
        {
            _IsFullScreen = false;
            SetWindowBound();
        }
    }

    private void BackupWindowBound()
    {
        (top, left, height, width) = _windowBoundsManager.GetWindowBound();
    }
    
    private void SetWindowBound()
    {

        _windowBoundsManager.SetWindowBound(top, left, height, width);
        
    }
    private void SetFullScreenBound()
    {
        _windowBoundsManager.SetWindowBound(
            FullScreenWindowLayout.Top,
            FullScreenWindowLayout.Left,
            FullScreenWindowLayout.Height,
            FullScreenWindowLayout.Width
        );
    }



    private void Window_Closed(object? sender, EventArgs e)
    {
        if (_IsFullScreen) return;
        BackupWindowBound();
    }

    //Window Load イベント
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        if (_IsFullScreen)
        {
            SetFullScreenBound();
            return;
        }
        if (hasBoundBackup())
        {
            SetWindowBound();
        }
        else
        {
            BackupWindowBound();
        }
    }

    private bool hasBoundBackup()
    {
        return top != 0 || left != 0 || height != 0 || width != 0;
    }
}
