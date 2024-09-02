using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2nd.Tests.Utils
{
    [TestFixture()]
    class BitmapTests
    {
        [Test()]
        public void 大きなイメージを作成するテスト()
        {
            for (int i = 1; i < 1000; i+=2)
            {
                int size = i * i;
                var image = new Bitmap(size,size);

            }
        }


    }
}
