using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace prototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var control = new VlcControl();


            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            control.BeginInit();
            control.VlcLibDirectory = libDirectory;
            control.Dock = DockStyle.Fill;
            control.EndInit();
            this.Controls.Add(control);

            control.Play(new Uri(@"file://C:\Users\catik\Videos\2021巡回大会\１支部代表\AM.mp4"));
        }

        private void vlcControl1_VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
        {

            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            e.VlcLibDirectory = libDirectory;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vlcControl1.Play(new Uri(@"file://C:\Users\catik\Videos\2021巡回大会\１支部代表\AM.mp4"));
        }
    }
}
