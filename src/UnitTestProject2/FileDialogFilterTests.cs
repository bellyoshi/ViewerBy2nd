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
    public class FileDialogFilterTests
    {
        [TestMethod()]
        public void CreateFilterTest()
        {
            FileDialogFilter sut = new FileDialogFilter();
            Assert.AreEqual("すべてのファイル (*.*)|*.*", sut.CreateFilter());
        }
    }
}