using ViewerBy2nd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using pdfiumWrapper2;


namespace ViewerBy2nd.FileViewParams
{
    public class PdfFileViewParam : DocuGraphFileViewParam
    {
        public override BitmapSource GetImageFromFile()
        {
            return ImageCreater.GetImageFromFile(this);
        }

        public pdfiumWrapper2.PDFDocument PDFDocument { get; }
        public int CurrentPage
        {
            get;
            set;
        } = 0;
        public int PageCount  => PDFDocument.PageCount;
        public PdfFileViewParam(string filename) : base(filename)
        {
            PDFDocument = new pdfiumWrapper2.PDFDocument(filename);
        }


        public bool CanNextPage => CurrentPage < PageCount - 1;
        public void NextPage()
        {
            if (!CanNextPage) return;
            CurrentPage++;
            ExecuteDisplay();
        }
        public bool CanPrevPage => CurrentPage > 0;

        public void PrevPage()
        {
            if (!CanPrevPage) return;
            CurrentPage--;
            ExecuteDisplay();
        }

        public void FirstPage()
        {
            CurrentPage = 0;
            ExecuteDisplay();
        }

        public void LastPage()
        {
            CurrentPage = PageCount - 1;
            ExecuteDisplay();
        }

        internal void GoToPage(int page)
        {
            if (page < 0 || page >= PageCount) return;
            CurrentPage = page;
            ExecuteDisplay();
        }
    }
}
