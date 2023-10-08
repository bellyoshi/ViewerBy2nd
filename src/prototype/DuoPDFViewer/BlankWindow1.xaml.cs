

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Windows.Graphics;




namespace DuoPDFViewer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankWindow1 : Window
    {
        public BlankWindow1()
        {
            this.InitializeComponent();

            var appWindow = GetAppWindow();



            //�Z�J���h���j�^�[�Ɉړ�����
            var d = DisplayArea.FindAll();
            
            //var a = d.FirstOrDefault(c => !c.IsPrimary);todo:���s���G���[
            DisplayArea displayArea = d[0];
            for(int i=0; i < d.Count; i++)
            {
                if (!d[i].IsPrimary)
                {
                    displayArea = d[i];
                    break;
                }
            }



            RectInt32 rect = new ()
            {
                X = 0,
                Y = 0,
                Width = displayArea.WorkArea.Width,
                Height = displayArea.WorkArea.Height
            };
            appWindow.MoveAndResize(rect, displayArea);
            

            //�őO�ʂɕ\������
            var olp = OverlappedPresenter.Create();
            olp.IsMaximizable = false;
            //�ő剻�{�^��
            olp.IsMinimizable = false; //�ŏ����{�^��
            olp.IsResizable = false; //�T�C�Y�ύX
            olp.IsAlwaysOnTop = false; //��ɍőO�ʂɕ\��
            olp.IsModal= false; //���[�_���E���[�h���X
            appWindow.SetPresenter(olp);
            //�t���X�N���[���v���[���^�[��}������
            var fp = FullScreenPresenter.Create();
            appWindow.SetPresenter(fp);

        }




        

        public AppWindow GetAppWindow()
        {
            
                // WinUI3�̃E�C���h�E�̃n���h�����擾
                var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
                // ���̃E�C���h�E��ID���擾
                Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
                // ��������AppWindow���擾����
                Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                return appWindow;
            
        }
    }

}

