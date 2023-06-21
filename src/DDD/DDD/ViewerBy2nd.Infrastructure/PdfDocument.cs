using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ViewerBy2nd.Infrastructure
{
    internal class PdfDocument
    {
        static bool initialized = false;
        public string m_strOpenPath = @"C:\";
        public string m_strFile;  // PDFファイル名
        public IntPtr m_pdfDoc = (IntPtr)0;
        public IntPtr m_pdfPage = (IntPtr)0;
        public double m_pageWidth = 0;
        public double m_pageHeight = 0;
        public double[] m_aryDispMag;  // ページごとの表示倍率
        public int m_iPageMax = 0;
        public int m_iPageAct = -1;
        private byte[] data;
        public static PdfDocument Load(string filename)
        {
            return new PdfDocument(filename);
        }
        private PdfDocument(string file) {
            LoadFile(file);
        }
        public void End()
        {
            CloseFile();
            Win32Api.FPDF_DestroyLibrary();
        }
       
        private bool LoadFile(string file)
        {
            // 拡張子チェック
            if (!IsPdfFile(file))
                return false;

            // ファイルロード
            CloseFile();  // 既にロード済みなら閉じる
            m_strFile = file;
            if (!initialized)
                Win32Api.FPDF_InitLibrary();

             data = File.ReadAllBytes(file);

            m_pdfDoc = Win32Api.FPDF_LoadMemDocument(data,data.Length, null);
            if (m_pdfDoc == (IntPtr)0)
            {
                throw new Exception($"file open error code {Win32Api.FPDF_GetLastError()} code 2 is  file not found or could not be opened");
                {

                };
                
                System.Diagnostics.Debug.Assert(false);
                return false;
            }

            m_iPageMax = Win32Api.FPDF_GetPageCount(m_pdfDoc);
            InitPageDispMag(m_iPageMax);  // ページごとの拡大率を初期化

            // ページロード
            if (!LoadPage(0))
                return false;

            return true;
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
        private bool IsPdfFile(string file)
        {
            int pos = file.LastIndexOf('.');
            string strExt = file.Substring(pos + 1);
            if (strExt.ToLower() == "pdf")
                return true;
            return false;
        }

        
        // 四捨五入して整数化
        private int Marume(double d)
        {
            return Convert.ToInt32(d);
        }
        // ポイントをピクセル換算
        private int PointToPixel(int Dpi, double value)
        {
            return (int)((value * Dpi) / 72);
        }


        // ページごとの表示倍率を初期化
        private void InitPageDispMag(int iPageMax)
        {
            Array.Resize(ref m_aryDispMag, iPageMax);
            for (int i = 0; i < iPageMax; i++)
                m_aryDispMag[i] = 1.0;


        }
        // ページごとの表示倍率取得
        private double GetActPageDispMag()
        {
            return m_aryDispMag[m_iPageAct];
        }
        // ページごとの表示倍率設定
        private void SetActPageDispMag(double mag)
        {
            m_aryDispMag[m_iPageAct] = mag;
        }






    }
}
