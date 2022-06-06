using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2ndLib
{
    public class FileViewParam
    {
        public string FileName { get; set; }

        public override string ToString()
        {
            return $"{System.IO.Path.GetFileName(FileName)}";
        }

        public FileViewParam(string filename)
        {
            this.FileName = filename;
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
            }}
    }
}
