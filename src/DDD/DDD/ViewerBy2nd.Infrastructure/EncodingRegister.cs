using System.Text;

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
