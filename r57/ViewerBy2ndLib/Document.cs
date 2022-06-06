using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewerBy2ndLib
{
    public class Document
    {
        public int page { get; set; } = 0;

        private FileViewParam FileViewParam;
        public Document(FileViewParam fileViewParam) {
            this.FileViewParam = fileViewParam;
        }

        public System.Drawing.Image Image { get; set; }

    }
}
