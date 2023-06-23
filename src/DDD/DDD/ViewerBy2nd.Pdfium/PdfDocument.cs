using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace ViewerBy2nd.Pdfium
{
    public class PdfDocument
    {
        static bool initialized = false;
        public string m_strOpenPath = @"C:\";
        public string m_strFile;  // PDFファイル名
        public IntPtr m_pdfDoc = (IntPtr)0;
        public IntPtr m_pdfPage = (IntPtr)0;
        public double m_pageWidth = 0;
        public double m_pageHeight = 0;

        public int m_iPageMax = 0;
        public int m_iPageAct = -1;
        private byte[] data = Array.Empty<byte>();
        public static PdfDocument Load(string filename)
        {
            return new PdfDocument(filename);
        }
        private PdfDocument(string file) {
            // ファイルロード
            CloseFile();  // 既にロード済みなら閉じる
            m_strFile = file;
            LoadFile();
        }
        public void End()
        {
            CloseFile();
            Win32Api.FPDF_DestroyLibrary();
        }
       
        private bool LoadFile()
        {
            Initialize();

            data = File.ReadAllBytes(m_strFile);

            m_pdfDoc = Win32Api.FPDF_LoadMemDocument(data, data.Length, String.Empty);
            if (m_pdfDoc == (IntPtr)0)
            {
                throw new Exception($"file open error code {Win32Api.FPDF_GetLastError()} code 2 is  file not found or could not be opened");
                {

                };



            }

            m_iPageMax = Win32Api.FPDF_GetPageCount(m_pdfDoc);


            // ページロード
            if (!LoadPage(0))
                return false;

            return true;
        }

        private static void Initialize()
        {
            if (!initialized)
            {
                Win32Api.FPDF_InitLibrary();
                initialized = true;
            }
        }

        private bool LoadPage(int page)
        {
            if (page < 0 || m_iPageMax <= page)  // ページ範囲外
                return false;

            m_iPageAct = page;

            ClosePage();
            m_pdfPage = Win32Api.FPDF_LoadPage(m_pdfDoc, m_iPageAct);
            m_pageWidth = Win32Api.FPDF_GetPageWidth(m_pdfPage);
            m_pageHeight = Win32Api.FPDF_GetPageHeight(m_pdfPage);
            return true;
        }
        private void ClosePage()
        {
            if (m_pdfPage != (IntPtr)0)
            {
                Win32Api.FPDF_ClosePage(m_pdfPage);
                m_pdfPage = (IntPtr)0;
            }
        }
        private void CloseFile()
        {
            ClosePage();
            if (m_pdfDoc != (IntPtr)0)
            {
                Win32Api.FPDF_CloseDocument(m_pdfDoc);
                m_pdfDoc = (IntPtr)0;
                m_strFile = "";
            }
        }



        public Image RenderPage(int pageIndex, int renderWidth, int renderHeight)
        {
            PDFRender pDFRender = new(this);
            return pDFRender.RenderPage(pageIndex, renderWidth, renderHeight);
        }



    }
}
