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
    public class FileTypesTests
    {
        [TestMethod()]
        public void CreateFilterTest()
        {
            string actual = FileTypes.CreateFilter();
            Assert.AreEqual("画像、動画、PDFファイル|*.pdf;*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tiff;*.tif;*.avi;*.mpeg;*.mp4;*.wmv;*.mov;*.svg;|All Files(*.*)|*.*", actual);
        }
    }
}