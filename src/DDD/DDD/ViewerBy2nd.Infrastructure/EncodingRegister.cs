using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2nd.Infrastructure
{
    internal class EncodingRegister
    {
        public static Encoding ShiftJisEncording
        {
            get
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                return Encoding.GetEncoding("shift_jis");
            }
        }
    }
}
