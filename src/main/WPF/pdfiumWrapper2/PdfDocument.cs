
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace pdfiumWrapper2
{
    public class PDFDocument
    {
        private readonly PdfDocumentWin32Api doc;
        public PDFDocument(string filename)
        {
            doc = PdfDocumentWin32Api.Load(filename);
            if (doc == null)
            {
                throw new Exception("PDFDocumentWrapper: PDFDocument.Load failed.");
            }
        }
        public int PageCount => doc.PagesCount;
        public BitmapSource GetImage(int page, double scale)
        {
            int sizeX = Convert.ToInt32( doc.PageWidth * scale / 100);
            int sizeY = Convert.ToInt32(doc.PageHeight * scale / 100);

            var image = doc.RenderPage(page, sizeX, sizeY);
            var rect = new Rectangle(0, 0, Convert.ToInt32(sizeX / scale * 100), Convert.ToInt32(sizeY / scale * 100));
            var trimimage = BitmapTool.ImageRoi(image, rect);

            return BitmapConverter.ToBitmapSource(trimimage);
        }
    }
}
