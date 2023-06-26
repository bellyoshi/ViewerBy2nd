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
            Assert.AreEqual("すべての対応ファイル(*.*)|*.*", sut.CreateFilter());
        }

        //[TestMethod()]
        //public void AddTypeTest()
        //{
        //    //FileDialogFilter sut = new FileDialogFilter();
        //    //sut.AddType("スケーラブル ベクター ", "svg");
        //    //Assert.AreEqual("すべての対応ファイル  (*.*)|*.svg", sut.CreateFilter());
        //}
    }
}