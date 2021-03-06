using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ViewerBy2ndLib.Tests
{
    [TestClass()]
    public class FileTypeTests
    {
        [TestMethod()]
        public void IsImageExtTest()
        {
            var bitmapExtention = new FileTypes(".bmp");
            Assert.IsTrue(bitmapExtention.IsImageExt);
            Assert.IsFalse(bitmapExtention.IsPDFExt);
        }

        [TestMethod()]
        public void CreateFilterTest()
        {
            Assert.AreEqual("画像、動画、PDFファイル|*.pdf;*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tiff;*.tif;*.avi;*.mpeg;*.mp4;*.wmv;*.mov;*.svg;|All Files(*.*)|*.*", FileTypes.CreateFilter());
        }
    }
}
