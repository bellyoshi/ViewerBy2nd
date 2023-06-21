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
        internal PDFRender(PdfDocument pdfDoc)
        {
            this.pdfDoc = pdfDoc;
        }
        public Image RenderPage(int pageIndex, int renderWidth, int renderHeight)
        {

            IntPtr m_pdfDoc = pdfDoc.m_pdfDoc;
            IntPtr m_pdfPage = m_pdfPage = Win32Api.FPDF_LoadPage(m_pdfDoc, pageIndex);
            System.Drawing.Image image = new Bitmap(renderWidth, renderHeight);
            Graphics g = Graphics.FromImage(image);
            IntPtr hDC = g.GetHdc();
            Win32Api.FPDF_RenderPage(hDC, m_pdfPage, 0, 0, renderWidth, renderHeight, 0, 0);
            g.ReleaseHdc();
            g.Dispose();
            return image;
        }
        // ポイントをピクセル換算
        private int PointToPixel(int Dpi, double value)
        {
            return (int)((value * Dpi) / 72);
        }
    }
}
