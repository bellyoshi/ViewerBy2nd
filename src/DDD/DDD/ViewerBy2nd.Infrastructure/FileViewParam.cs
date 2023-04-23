using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2ndLib
{
    public class FileViewParam
    {
     
        public System.Drawing.Size BoundsSize { get; set; }
        public string FileName { get; set; } = String.Empty;

        public override string ToString()
        {
            return $"{System.IO.Path.GetFileName(FileName)}";
        }

        public FileViewParam(string filename, System.Drawing.Size bound)
        {
            this.FileName = filename;
            this.BoundsSize=bound;
        }
        public FileViewParam()
        {
            //シリアル化用
        }

        private Document? _document;
        public Document document {
            get {
                if (_document == null)
                {
                    _document = new Document(this);
                }
                return _document;
            }
        }

        public int ZoomHeight { get; set; } = 1024;

        public bool IsZoom { get; set; }

        public int scrollBarValue { get;  set; }

        public System.Drawing.RotateFlipType  rotateFlipType { get; set; }
    }
}
