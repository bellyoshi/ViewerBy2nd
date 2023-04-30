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
    public partial class SettingForm : Form
    {
        private FormDispacher Dispacher => FormDispacher.GetInstance();

        private void screenDetect()
        {
            // デバイス名が表示されるようにする
            this.cmbDisplay.DisplayMember = "DeviceName";
            this.cmbDisplay.DataSource = Screen.AllScreens;
        }
        public SettingForm()
        {
            InitializeComponent();
        }
        private void AppSettingLoad()
        {
            cmbDisplay.SelectedIndex =  ViewScreenRegister.GetInstance().Index;

            lblFormColor.BackColor = BackColorRegister.GetInstance().BackColor;
            

        }




        bool load = false;
        private void frmSetting_Load(object sender, EventArgs e)
        {
            screenDetect();
            AppSettingLoad();
            load = true;
        }
        private void btnColorChange_Click_1(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            this.lblFormColor.BackColor = ColorDialog1.Color;
            BackColorRegister.GetInstance().BackColor = ColorDialog1.Color;
        }

        private void cmbDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!load)
            {
                return;
            }
            if (cmbDisplay.SelectedIndex < 0)
                return;
            if (cmbDisplay.SelectedItem == null)
                return;


            ViewScreenRegister.GetInstance().ChangeScreen(cmbDisplay.SelectedIndex);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
