using ViewerBy2nd.ViewModels;
using ViewerBy2nd.Windows;

namespace ViewerBy2nd.Utils;


internal class WindowDispacher
{
    public Utils.DependencyContainer Container;

    public WindowDispacher(DependencyContainer container)
    {
        Container = container;
    }

    public void ShowSettingWindow()
    {
        if (!WindowUtil.ExistsWindow<SettingWindow>())
        {
           InitializeSettingWindow();
        }
        WindowUtil.ShowWindow<SettingWindow>();
    }

    public void ShowViewerWindow()
    {
        if (!WindowUtil.ExistsWindow<ViewerWindow>())
        {
            InitializeViewerWindow();
        }
        WindowUtil.ShowWindow<ViewerWindow>();
    }

    public void InitializeViewerWindow()
    {
        //ViewerWindowの初期化
        var window = new ViewerWindow();
        WindowDragMover mover = new(window, 10, [window]);
        WindowDragResizer resize = new(window, 10);
        WindowFullScreenManager windowFullScreenManager = GetWindowFullScreenManager(window);

        var view = new ViewerViewModel();
        view.SetWindowFullScreenManager(windowFullScreenManager);
        window.DataContext = view;
    }

    private WindowFullScreenManager GetWindowFullScreenManager(ViewerWindow window)
    {
        if (Container.hasInstance<WindowFullScreenManager>())
        {
            var windowFullScreenManager = Container.GetInstance<WindowFullScreenManager>();
            windowFullScreenManager.Window = window;
            return windowFullScreenManager;
        }
        else
        {
            WindowFullScreenManager windowFullScreenManager = new(window);
            Container.RegisterInstance<WindowFullScreenManager>(windowFullScreenManager);
            return windowFullScreenManager;
        }

    }

     void InitializeSettingWindow()
    {
        if (!Container.hasInstance<WindowFullScreenManager>())
        {
            InitializeViewerWindow();
        }
        
        //SettingWindowの初期化
        var settingWindow = new SettingWindow();
        var settingViewModel = new SettingViewModel();
        var windowFullScreenManager = Container.GetInstance<WindowFullScreenManager>();
        settingViewModel.SetWindowFullScreenManager(windowFullScreenManager);
        settingWindow.DataContext = settingViewModel;

    }




}
