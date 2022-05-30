using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PictureBox PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            PictureBox1.Location = new System.Drawing.Point(260, 26);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new System.Drawing.Size(465, 332);
            PictureBox1.TabIndex = 29;
            PictureBox1.TabStop = false;
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();


            var sut = new ClassLibrary1.RubberBand(PictureBox1);
            var image = new System.Drawing.Bitmap(100,200);
            sut.setImage(image);
            Assert.AreEqual(PictureBox1.Size, sut.Size);
            Assert.AreEqual(new System.Drawing.Point(0,0), sut.Location);
            Assert.AreEqual(System.Drawing.Color.FromArgb(255, 0, 0), sut.Color);
        }
    }
}
