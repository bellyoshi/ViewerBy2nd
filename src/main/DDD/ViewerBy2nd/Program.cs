//todo: ���e�����̔w�i�F��ݒ�ł���悤�ɂ���B����w�i�F�Ɠ����ɂȂ�B
//todo: �p�X���[�h��pdf���J����悤�ɂ���B�p�X���[�h����͂���E�C���h�E������
//todo: ����E�C���h�E�̃T�C�Y�ŏ���p�ӂ���B
//todo: �E�C���h�E���[�h�A�t���X�N���[�����[�h�̐؂�ւ��𑀍��ʂ���\�Ƃ���

//todo: �����I�тȂ����ƁA���Ԃ�0�ɖ߂�B
//todo: ������Đ����ɍĐ��{�^���������Ɣ����Ɏ��Ԃ��ς�遨�����Ȃ�����H�Đ��I���{�^���K�v�H
//todo: �w�i�̉摜��I�ׂ�悤��
//todo: ����̊����߂���15�b�߂��A��~�ƈꎞ��~

//todo: �Ԃ��������聨���������H
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