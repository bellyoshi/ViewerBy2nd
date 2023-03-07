// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;



// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App2
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
            var d = DisplayArea.FindAll()[1];
            //var a = d.FirstOrDefault(c => c.IsPrimary);

            DisplayArea displayArea = d;

            RectInt32 rect = new RectInt32()
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

