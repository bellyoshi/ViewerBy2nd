using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewerBy2ndLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2ndLib.Tests
{
    [TestClass()]
    public class FileTypeTests
    {
        [TestMethod()]
        public void IsImageExtTest()
        {
            var bitmapExtention = new FileType(".bmp");
            Assert.IsTrue(bitmapExtention.IsImageExt());
            Assert.IsFalse(bitmapExtention.IsPDFExt());
        }

        [TestMethod()]
        public void CreateFilterTest()
        {
            Assert.AreEqual("画像、動画、PDFファイル|*.pdf;*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tiff;*.tif;*.svg;*.avi;*.mpeg;*.mp4;*.wmv;*.mov;*.svg;|All Files(*.*)|*.*", FileType.CreateFilter());
        }
    }
}