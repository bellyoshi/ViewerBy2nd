using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace UnitTestProject1
{
    [TestClass]
    public class RubberBandTest
    {
        PictureBox pb;
        [TestInitialize]
        public void TestInitialize()
        {
            pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            pb.Location = new System.Drawing.Point(260, 26);
            pb.Name = "PictureBox1";
            pb.Size = new System.Drawing.Size(465, 332);
            pb.TabIndex = 29;
            pb.TabStop = false;
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var sut = new ClassLibrary1.RubberBand(pb);
            var image = new System.Drawing.Bitmap(100,200);
            sut.setImage(image);
            Assert.AreEqual(pb.Size, sut.Size);
            Assert.AreEqual(new System.Drawing.Point(0,0), sut.Location);
            Assert.AreEqual(System.Drawing.Color.FromArgb(255, 0, 0), sut.Color);
        }
    }
}
