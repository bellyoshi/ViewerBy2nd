using System;
using PdfiumViewer;
using System.Drawing;

namespace ViewerBy2ndLib
{
    public class Document
    {

        private FileViewParam FileViewParam;

        public FileType FileType { get; set; }
        public Document(FileViewParam fileViewParam) {
            this.FileViewParam = fileViewParam;
            this.FileType = new FileType(FileViewParam.FileName);
            OpenFile(fileViewParam.FileName);
        }
        PdfiumViewer.PdfDocument pdfDoc;

        public int PageCount => pdfDoc.PageCount;
        private bool isHalf { get; set; }
        public double page { get; set; }
        public void OpenFile(string filename)
        {
            if (filename == null) return;
            isHalf = false;
            pdfDoc = PdfDocument.Load(filename);
            FirstPage();
        }
        System.Drawing.Size? GetRenderSize(SizeF pdfSize) {
            var bound = this.FileViewParam.Bound;
            if (bound.Width == 0 || bound.Height == 0)
            {
                return null;
            }
            var renderSize = new Size(bound.Width, bound.Height);
            var pdfWdivH = pdfSize.Width / pdfSize.Height;
            var boxWdivH = bound.Width / bound.Height;
            if(boxWdivH > 10) { 
            return null;
        }
        if(pdfWdivH<boxWdivH) {
                renderSize.Width = Convert.ToInt32(bound.Height* pdfWdivH);
            }else
            {
                renderSize.Height = Convert.ToInt32(bound.Width / pdfWdivH);
            }
        return renderSize;
    }

        void Render()
        {
            if(page >= pdfDoc.PageCount)
            {
                return;
            }
            var sourceSize = pdfDoc.PageSizes[Convert.ToInt32(page)];
            var renderSize = GetRenderSize(sourceSize);
        if(renderSize == null) {
                return;
        }
            this.Image = GetImage(renderSize.Value);
  }

        public void FirstPage() {

            isHalf = false;
            page = 0.0;
            Render();
        }

        public void NextPage() {
        isHalf = false;

        if(page<pdfDoc.PageCount - 1) {
                page += 1;
                Render();
         }
    }

        public void PrePage() {
            isHalf = false;
        if(0 < page) {
                page -= 1;
                Render();
        }
    }


        private decimal buttomInPage;  

        public void NextHalfPage() { 
        if((buttomInPage == 1.0m) && (page == pdfDoc.PageCount - 1)) {
                return;
        }


        buttomInPage += 0.5m;
                if(buttomInPage == 1.5m) {
            NextPage();
            buttomInPage = 0.5m;
                }

            isHalf = true;
            DisplayHalfPage();
     }

    public void PreviousHalfPage() {

        if(page == 0 && buttomInPage <= 0.5m) {
            return;
        }
            buttomInPage -= 0.5m;
        if(buttomInPage <= 0.0m) {
                buttomInPage = 1m;
                page -= 1;

        }
            isHalf = true;
            DisplayHalfPage();
    }

    private void DisplayHalfPage() { 
        if(page >= pdfDoc.PageCount || page< 0) {
                return;
        }
            var pdfSize = pdfDoc.PageSizes[Convert.ToInt32(page)];
            SizeF sourceSize = new SizeF(pdfSize.Width, pdfSize.Height / 2);
            Size? renderSize = GetRenderSize(sourceSize);
        if(renderSize == null) {
                return;
        }
            var r = renderSize.Value;
        r.Height *= 2;
            RenderHalf(r);
     }

    private void RenderHalf(Size renderSize) {
        int height = renderSize.Height / 2;
            var width = renderSize.Width;
        var canvas = new Bitmap(width, height);
        using(var g  = Graphics.FromImage(canvas)){
                var img = GetImage(renderSize);
                var y = Convert.ToInt32(renderSize.Height * (buttomInPage - 0.5m));
                var srcRect = new Rectangle(0, y, width, height);
                var desRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
                g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel);
         }
            this.Image = canvas;
     }
        private Image GetImage(Size renderSize) {
            return pdfDoc.Render(Convert.ToInt32(page), renderSize.Width , renderSize.Height, 96, 96, false);
    }
        public System.Drawing.Image Image { get; set; }

    }
}
