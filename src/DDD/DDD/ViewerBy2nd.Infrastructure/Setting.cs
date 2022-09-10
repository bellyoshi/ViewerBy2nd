using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewerBy2ndLib
{
    public  class Settings
    {
        public static Settings Default = new Settings();
        public void Save() { }

        //cmbDisplaySelectedIndex
        public int cmbDisplaySelectedIndex { get; set; }
        //formColor
        public System.Drawing.Color formColor { get; set; }
        //chkUpdate
        public bool chkUpdate { get; set; }

    }
}
