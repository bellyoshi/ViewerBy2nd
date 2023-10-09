using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using Windows.Graphics;




namespace DuoPDFViewer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewerWindow : Window
    {
        public ViewerWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(typeof(BlankPage1));

            var appWindow = GetAppWindow();

            RectInt32 rect = GetRect();
            appWindow.MoveAndResize(rect);

            OverlappedPresenter olp = OverlappedPresenterCreate();
            appWindow.SetPresenter(olp);

            //�t���X�N���[���v���[���^�[��}������
            var fp = FullScreenPresenter.Create();
            appWindow.SetPresenter(fp);

        }

        private static RectInt32 GetRect()
        {
            DisplayArea displayArea = GetSecondDisplayArea();
            var rect = CreateDisplayRect(displayArea);
            return rect;
        }

        private static OverlappedPresenter OverlappedPresenterCreate()
        {
            //�őO�ʂɕ\������
            var olp = OverlappedPresenter.Create();
            olp.IsMaximizable = false; //�ő剻�{�^��
            olp.IsMinimizable = false; //�ŏ����{�^��
            olp.IsResizable = false; //�T�C�Y�ύX
            olp.IsAlwaysOnTop = false; //��ɍőO�ʂɕ\��
            olp.IsModal= false; //���[�_���E���[�h���X
            return olp;
        }

        private static RectInt32 CreateDisplayRect( DisplayArea displayArea)
            => new RectInt32()
        {
            X = 0,
            Y = 0,
            Width = displayArea.WorkArea.Width,
            Height = displayArea.WorkArea.Height
        };


        private static DisplayArea GetSecondDisplayArea()
        {
            //�Z�J���h���j�^�[�Ɉړ�����
            var displayAreaList = DisplayArea.FindAll();

            //var a = d.First(c => !c.IsPrimary);//Specified cast is not valid ���s���G���[
            for (int i = 0; i < displayAreaList.Count; i++)
            {
                if (!displayAreaList[i].IsPrimary)
                {
                    return displayAreaList[i];
                }
            }

            return displayAreaList[0];
        }





        public AppWindow GetAppWindow()
        {
            
            // WinUI3�̃E�C���h�E�̃n���h�����擾
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            // ���̃E�C���h�E��ID���擾
            Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            // ��������AppWindow���擾����
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
                return appWindow;
            
        }


    }

}

