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
            SetFullScreen();
        }
    }

    private Window _window;
    public Window Window { get => _window;
        set
        {
            DeleteEvents();
            _windowBoundsManager = new(value);
            _window = value;
            SetEvents();
        }
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

    private double BakupHeight { get; set; }
    private double BakupWidth { get; set; }

    private double BackupTop { get; set; }
    private double BackupLeft { get; set; }

    private bool _IsFullScreen;
    public bool IsFullScreen
    {
        get => _IsFullScreen;
        set
        {
            if (value)
                SetFullScreen();
            else
                SetNormalScreen();

        }
    }

    private void SetFullScreen()
    {
        // Set the window to full screen
        if (!_IsFullScreen)
        {
            (BackupTop, BackupLeft, BakupHeight, BakupWidth) = _windowBoundsManager.GetWindowBound();

        }

        SetWindowBound(
            FullScreenWindowLayout.Top,
            FullScreenWindowLayout.Left,
            FullScreenWindowLayout.Height,
            FullScreenWindowLayout.Width);
        

        _IsFullScreen = true;
    }

    private void SetWindowBound(double top, double left, double height, double width)
    {
        this.top = top;
        this.left = left;
        this.height = height;
        this.width =  width;

        _windowBoundsManager.SetWindowBound(top, left, height, width);
        
    }

    private void SetNormalScreen()
    {
        if (_IsFullScreen)
        {
            SetWindowBound(BackupTop, BackupLeft, BakupHeight, BakupWidth);
        }

        // Set the window to normal screen
        _IsFullScreen = false;
    }

    private void Window_Closed(object? sender, EventArgs e)
    {
        // Windowが閉じたときに行いたい処理をここに実装
        if (_window != null)
        {
            (top, left, height, width) = _windowBoundsManager.GetWindowBound();
        }
    }

    //Window Load イベント
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Windowがロードされたときに行いたい処理をここに実装
        if (_window == null) return;
        if (IsPreinitialization())
        {

            (top, left, height, width) = _windowBoundsManager.GetWindowBound();


        }
        else
        {
            SetWindowBound(top, left, height, width);
        }
    }

    private bool IsPreinitialization()
    {
        return top == 0 && left == 0 && height == 0 && width == 0;
    }
}
