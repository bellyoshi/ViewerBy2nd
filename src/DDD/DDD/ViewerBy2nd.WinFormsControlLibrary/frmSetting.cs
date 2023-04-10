using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewerBy2ndLib;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    public partial class frmSetting : Form
    {
        private FormDispacher Dispacher => FormDispacher.GetInstance();
        Settings Default => ConfigurationReader.Default;
        private void screenDetect()
        {
            // デバイス名が表示されるようにする
            this.cmbDisplay.DisplayMember = "DeviceName";
            this.cmbDisplay.DataSource = Screen.AllScreens;
        }
        public frmSetting()
        {
            InitializeComponent();
        }
        private void AppSettingLoad()
        {
            if (cmbDisplay.Items.Count > Default.cmbDisplaySelectedIndex)
            {
                cmbDisplay.SelectedIndex = Default.cmbDisplaySelectedIndex;
            }
            else
            {
                cmbDisplay.SelectedIndex = 0;
            }


            lblFormColor.BackColor = Default.formColor;


        }

        private void AppSettingSave()
        {
            Default.cmbDisplaySelectedIndex = cmbDisplay.SelectedIndex;





        }



        private void frmSetting_Load(object sender, EventArgs e)
        {
            screenDetect();
        }
        private void btnColorChange_Click_1(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            this.lblFormColor.BackColor = ColorDialog1.Color;
            Default.formColor = ColorDialog1.Color;
            Dispacher.BackColor = Default.formColor;

        }

        private void cmbDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisplay.SelectedIndex < 0)
                return;
            if (cmbDisplay.SelectedItem == null)
                return;
            // 'フォームを表示するディスプレイのScreenを取得する
            Screen s = (Screen)cmbDisplay.SelectedItem;

            Dispacher.ViewScreen = s;

        }


    }
}
