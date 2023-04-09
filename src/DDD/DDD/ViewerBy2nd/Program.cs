using ViewerBy2nd;

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
            ViewerBy2nd.Infrastructure.ConfigurationReader.Initialize();
            Application.Run(new frmOperation());
            ViewerBy2nd.Infrastructure.ConfigurationReader.Save();
        }
    }
}