//todo: 原稿部分の背景色を設定できるようにする。現状背景色と同じになる。
//todo: パスワードつきpdfを開けるようにする。パスワードを入力するウインドウをつくる
//todo: 操作ウインドウのサイズ最小を用意する。
//todo: ウインドウモード、フルスクリーンモードの切り替えを操作画面から可能とする

//todo: 動画を選びなおすと、時間が0に戻る。
//todo: 動画を再生中に再生ボタンを押すと微妙に時間が変わる→押せなくする？再生終了ボタン必要？
//todo: 背景の画像を選べるように
//todo: 動画の巻き戻しと15秒戻し、停止と一時停止

//todo: 赤くちらつく問題→解決した？
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