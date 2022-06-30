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
        public string FileName { get; set; }

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

        private Document _document;
        public Document document {
            get {
                if (_document == null)
                {
                    _document = new Document(this);
                }
                return _document;
            }
        }

        bool _isWidthEqualWin;
        public bool IsWidthEqualWin { 
            get {
                return _isWidthEqualWin;
            }
            set
            {
                _isWidthEqualWin = value;
                if (IsWidthEqualWin == true)
                {
                    _document?.DispSetWindow();
                }
                else
                {
                    _document?.Disp();
                }
                
            }
        }
        public int scrollBarValue { get;  set; }
    }
}
