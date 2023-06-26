namespace ViewerBy2nd.WinFormsControlLibrary
{
    public partial class SettingForm : Form
    {

        private void ScreenDetect()
        {
            // デバイス名が表示されるようにする
            this.DisplayComboBox.DisplayMember = "DeviceName";
            this.DisplayComboBox.DataSource = Screen.AllScreens;
        }
        public SettingForm()
        {
            InitializeComponent();
        }
        private void AppSettingLoad()
        {
            DisplayComboBox.SelectedIndex =  ViewScreenRegister.GetInstance().Index;

            lblFormColor.BackColor = BackColorRegister.GetInstance().BackColor;


        }




        bool load = false;
        private void SettingForm_Load(object sender, EventArgs e)
        {
            ScreenDetect();
            AppSettingLoad();
            load = true;
        }
        private void ColorChangeButton_Click(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            this.lblFormColor.BackColor = ColorDialog1.Color;
            BackColorRegister.GetInstance().BackColor = ColorDialog1.Color;
        }

        private void DisplayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!load)
            {
                return;
            }
            if (DisplayComboBox.SelectedIndex < 0)
                return;
            if (DisplayComboBox.SelectedItem == null)
                return;


            ViewScreenRegister.GetInstance().ChangeScreen(DisplayComboBox.SelectedIndex);

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
