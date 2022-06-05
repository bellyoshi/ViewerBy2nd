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
    public class FileViewParamTests
    {
        [TestMethod()]
        public void ToStringTest()
        { 
             var sut = new FileViewParam(@"c:\test.txt");
            Assert.AreEqual("test.txt",sut.ToString());
        }
    }
}