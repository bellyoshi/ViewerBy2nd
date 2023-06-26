using System.Diagnostics;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    public partial class VersionForm : Form
    {
        public VersionForm()
        {
            InitializeComponent();
        }

        private void VersionForm_Load(object sender, EventArgs e)
        {
            //ラベルにバージョンを表示する。
            VersionLabel.Text = Application.ProductVersion;
        }

        private void ReleasesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = ReleasesLinkLabel.Text;
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
