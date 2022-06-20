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



        }



        private void Form1_Load(object sender, EventArgs e)
        {
            videoPlayer1.Play(@"C:\Users\catik\Videos\2021巡回大会\１支部代表\AM.mp4");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoPlayer1.Stop();
            videoPlayer1.Visible = false;
            videoPlayer1.Visible = true;
            videoPlayer1.Play(@"C:\Users\catik\Videos\2021巡回大会\１支部代表\AM.mp4");
        }
    }
}
