using Patagames;
using Patagames.Pdf;
using Patagames.Pdf.Net;
using System.Drawing.Imaging;

namespace App2
{
    internal class RenderPager
    {
        public void RenderPage()
        {
            //Initialize the SDK library
            //You have to call this function before you can call any PDF processing functions.
            PdfCommon.Initialize();

            //Open and load a PDF document from a file.
            using (var doc = PdfDocument.Load(@"d:\test\001.pdf"))
            {
                int i = 0;
                //Iterate all pages;
                foreach (var page in doc.Pages)
                {
                    //Gets page width and height measured in points. One point is 1/72 inch (around 0.3528 mm)
                    int width = (int)page.Width;
                    int height = (int)page.Height;

                    //Create a bitmap
                    using (var bmp = new PdfBitmap(width, height, true))
                    {
                        //Fill background
                        bmp.FillRect(0, 0, width, height, FS_COLOR.White);
                        //Render contents in a page to a drawing surface specified by a coordinate pair, a width, and a height.
                        page.Render(bmp, 0, 0, width, height,
                            Patagames.Pdf.Enums.PageRotate.Normal,
                            Patagames.Pdf.Enums.RenderFlags.FPDF_ANNOT);
                        //Get .Net image and save it into file
                        bmp.Image.Save(string.Format(@"d:\test\page_{0}.png", i++), ImageFormat.Png);
                    }
                }
            }
        }
    }
}
