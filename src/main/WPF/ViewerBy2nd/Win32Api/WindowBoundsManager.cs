using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;



namespace ViewerBy2nd.Win32Api
{
    public class WindowBoundsManager
    {
        public static class NativeMethods
        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
        }
        private Window _window;

        public WindowBoundsManager(Window window)
        {
            _window = window;
        }

        public void SetWindowBound(double top, double left, double height, double width)
        {
            var windowInteropHelper = new WindowInteropHelper(_window);
            NativeMethods.MoveWindow(windowInteropHelper.Handle, (int)left, (int)top, (int)width, (int)height, true);
        }

        public (double top, double left, double height, double width) GetWindowBound()
        {
            var windowInteropHelper = new WindowInteropHelper(_window);
            NativeMethods.RECT rect;
            NativeMethods.GetWindowRect(windowInteropHelper.Handle, out rect);
            return (rect.Top, rect.Left, rect.Bottom - rect.Top, rect.Right - rect.Left);
        }
    }

}
