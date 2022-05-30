using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaToSecondMonitor
{
    public class FileViewParam
    {
        public string FileName { get; set; }
        public decimal zoom { get; set; } = 100;
        public override string ToString()
        {
            return $"{System.IO.Path.GetFileName(FileName)}";
        }

    }
}
