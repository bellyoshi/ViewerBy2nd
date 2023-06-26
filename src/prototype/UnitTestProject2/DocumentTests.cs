using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewerBy2ndLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ViewerBy2ndLib.Tests
{
    [TestClass()]
    public class DocumentTests
    {
        [TestMethod()]
        public void GetWinWidthRenderSizeTest()
        {
            var original = new Size(1000, 2000);
            var disp = new Size(640, 480);
            var actual = Document.GetWinWidthRenderSize(original, disp);
            Assert.AreEqual(640, actual.Width);
            Assert.AreEqual(1280, actual.Height); 
            
        }
    }
}