//todo: 原稿部分の背景色を設定できるようにする。現状背景色と同じになる。
//todo: パスワードつきpdfを開けるようにする。パスワードを入力するウインドウをつくる
//todo: 設定が保存されなくなっている？
namespace ViewerBy2nd
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
       
            ApplicationConfiguration.Initialize();
            Application.Run(new OperationForm());
            Infrastructure.ConfigurationReader.Save();
        }
    }
}