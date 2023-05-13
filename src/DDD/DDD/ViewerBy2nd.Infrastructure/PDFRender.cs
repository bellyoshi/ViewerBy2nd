using Patagames.Pdf.Net.Wrappers;
using Patagames.Pdf.Net;
using Patagames.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ViewerBy2nd.Infrastructure
{
    internal class PDFRender
    {
        readonly PdfDocument pdfDoc;
        internal PDFRender(PdfDocument pdfDocument)
        {
            pdfDoc = pdfDocument;
        }
        public Image RenderPage(int pageIndex, int renderWidth, int renderHeight)
        {
            var page = pdfDoc.Pages[pageIndex];

            int nw = renderWidth;
            int nh = renderHeight;

            var pdfbitmap = new PdfBitmap(nw, nh, true); // bitmap をつくる
            pdfbitmap.FillRect(0, 0, nw, nh, FS_COLOR.White); // 背景は白

            page?.Render(pdfbitmap, 0, 0, nw, nh,
                Patagames.Pdf.Enums.PageRotate.Normal,
                Patagames.Pdf.Enums.RenderFlags.FPDF_ANNOT);

            return pdfbitmap.Image;
        }
    }
}
