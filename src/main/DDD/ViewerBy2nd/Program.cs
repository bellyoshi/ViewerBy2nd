//todo: ���e�����̔w�i�F��ݒ�ł���悤�ɂ���B����w�i�F�Ɠ����ɂȂ�B
//todo: �p�X���[�h��pdf���J����悤�ɂ���B�p�X���[�h����͂���E�C���h�E������
//todo: ����E�C���h�E�̃T�C�Y�A�W���A���A�ŏ���p�ӂ���B


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