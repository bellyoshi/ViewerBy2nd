using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2ndLib
{
    public class FileDialogFilter
    {

        public void AddType(string FileTypeText, params string[] extentions)
        {

        }
        public string CreateFilter()
        {
            return "すべての対応ファイル(*.*)|*.*";
        }


    }
}
