using System.Windows;

namespace ViewerBy2nd.Utils;

internal static class WindowUtil
{


    //特定の型のウィンドウを閉じる
    static internal void CloseWindow<T>() where T : Window
    {
        var windows = Application.Current.Windows.OfType<T>();
        windows.ToList().ForEach(w => w.Close());
    }


    static internal T GetWindow<T>() where T : Window, new()
    {
        var windows = Application.Current.Windows.OfType<T>();
        return windows.FirstOrDefault() ?? new T();
    }

    static internal bool ExistsWindow<T>() where T : Window
    {
        var windows = Application.Current.Windows.OfType<T>();
        return windows.Any();
    }





    static internal void ShowWindow<T>() where T : Window, new()
    {
        var window = GetWindow<T>();
        window.Show();
    }
}
