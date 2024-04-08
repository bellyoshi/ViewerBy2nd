using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewerBy2nd.FileViewParams;

namespace ViewerBy2nd.Tests
{
    [TestFixture()]
    public class FileTypesTests
    {
        [Test()]
        public void CreateFilterTest()
        {
            var expected = "画像ファイル|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.tif;*.cr2|"
                +"動画ファイル|*.mp4;*.wmv;*.avi;*.mpg;*.mpeg;*.mov|"
                +"SVGファイル|*.svg|"
                +"PDFファイル|*.pdf|"
                +"All Supported Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.tif;*.cr2;"
                +"*.mp4;*.wmv;*.avi;*.mpg;*.mpeg;*.mov;"
                +"*.svg;*.pdf|"
                +"All Files(*.*)|*.*";
            var actual = ViewerBy2nd.FileTypes.CreateFilter();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test()]
        public void GetFileViewParamTest()
        {
            var actual = ViewerBy2nd.FileTypes.GetFileViewParam("sample.pdf");
            Assert.IsTrue(actual is PdfFileViewParam);
            actual = ViewerBy2nd.FileTypes.GetFileViewParam("sample.jpg");
            Assert.IsTrue(actual is ImageFileViewParam);
            actual = ViewerBy2nd.FileTypes.GetFileViewParam("sample.svg");
            Assert.IsTrue(actual is SvgFileViewParam);
            actual = ViewerBy2nd.FileTypes.GetFileViewParam("sample.mp4");
            Assert.IsTrue(actual is MovieFileViewParam);
        }
    }
}