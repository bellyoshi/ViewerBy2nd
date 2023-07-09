using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibVLCSharp.WinForms.Sample
{
    public partial class Form2 : Form
    {
        public VideoView VideoView => videoView1;
        public Form2()
        {
            InitializeComponent();
        }
    }
}
