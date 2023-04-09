using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    public partial class frmVersion : Form
    {
        public frmVersion()
        {
            InitializeComponent();
        }

        private void frmVersion_Load(object sender, EventArgs e)
        {
            //ラベルにバージョンを表示する。
            VersionLabel.Text = Application.ProductVersion;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = linkLabel1.Text;
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
