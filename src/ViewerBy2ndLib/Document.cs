using System;
using PdfiumViewer;
using System.Drawing;

namespace ViewerBy2ndLib
{
    public class Document
    {

        private FileViewParam FileViewParam;

        public FileTypes FileType { get; set; }
        public Document(FileViewParam fileViewParam) {
            this.FileViewParam = fileViewParam;
            this.FileType = new FileTypes(FileViewParam.FileName);
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
            if (FileType.IsPDFExt)
            {
                pdfDoc = PdfDocument.Load(filename);
                FirstPage();
            }
            else if (FileType.IsImageExt)
            {
                LoadImage();

            }
            else if (FileType.IsSVGExt)
            {
                LoadSVGImage();
            }

        }
        public void LoadSVGImage() {
            var doc = Svg.SvgDocument.Open(FileViewParam.FileName);
            var sc = FileViewParam.BoundsSize;
            this.Image = doc.Draw(sc.Height, sc.Height);
            this.OriginalRotateImage = Image;
        }
        private RotateFlipType flip;
        public void Rotate(RotateFlipType flip) {
            if (FileType.IsPDFExt)
            {
                Render();
            }
            else
            {
                OpenFile(FileViewParam.FileName);
            }

            this.flip = flip;
            this.Image.RotateFlip(flip);
            this.OriginalRotateImage = this.Image;
        }
        public void LoadImage()
        {
            this.Image = new Bitmap(FileViewParam.FileName);
            this.OriginalRotateImage = this.Image;
        }

        public void Disp()
        {
            if (FileType.IsPDFExt)
            {
                Render();
            }
            else if (FileType.IsImageExt)
            {
                LoadImage();

            }
            else if (FileType.IsSVGExt)
            {
                LoadSVGImage();
            }
        }

        System.Drawing.Size? GetRenderSize(SizeF pdfSize) {
            var bound = this.FileViewParam.BoundsSize;
            if (bound.Width == 0 || bound.Height == 0)
            {
                return null;
            }
            var renderSize = new Size(bound.Width, bound.Height);
            var pdfWdivH = pdfSize.Width / pdfSize.Height;
            var boxWdivH = bound.Width / bound.Height;
            if (boxWdivH > 10) {
                return null;
            }
            if (pdfWdivH<boxWdivH) {
                renderSize.Width = Convert.ToInt32(bound.Height* pdfWdivH);
            } else
            {
                renderSize.Height = Convert.ToInt32(bound.Width / pdfWdivH);
            }
            return renderSize;
        }

        void Render()
        {
            if (page >= pdfDoc.PageCount)
            {
                return;
            }

            var sourceSize = pdfDoc.PageSizes[Convert.ToInt32(page)];
            var renderSize = GetRenderSize(sourceSize);
            if (renderSize == null) {
                return;
            }
            //if (FileViewParam.IsWidthEqualWin)
            
            renderSize = GetWinWidthRenderSize(renderSize.Value, FileViewParam.BoundsSize);
            
            this.Image = GetImage(renderSize.Value);
            this.OriginalRotateImage  = this.Image;



        }

        public static Size GetWinWidthRenderSize(Size originalRendeSize, Size bound)
        {
            return new Size(bound.Width , bound.Width * originalRendeSize.Height / originalRendeSize.Width );
        }

        public void FirstPage() {

            isHalf = false;
            page = 0.0;
            docRender();
        }
        public void docRender()
        {
            Render();
            if (FileViewParam.IsWidthEqualWin)
            {
                DispSetWindow();
            }
            
        }

        public bool CanNextPage()
        => (pdfDoc != null && page<pdfDoc.PageCount - 1);

        public void NextPage() {
            isHalf = false;

            if (CanNextPage()) {
                page += 1;
                docRender();
            }
        }
        public bool CanPrePage()
            => 0 < page;
        public void PrePage() {
            isHalf = false;
            if (CanPrePage()) {
                page -= 1;
                docRender();
            }
        }
        public void LastPage()
        {
            isHalf = false;
            page = PageCount - 1;
            docRender();

        }


        private decimal buttomInPage;

        public void NextHalfPage() {
            if ((buttomInPage == 1.0m) && (page == pdfDoc.PageCount - 1)) {
                return;
            }


            buttomInPage += 0.5m;
            if (buttomInPage == 1.5m) {
                NextPage();
                buttomInPage = 0.5m;
            }

            isHalf = true;
            DisplayHalfPage();
        }

        public void PreviousHalfPage() {

            if (page == 0 && buttomInPage <= 0.5m) {
                return;
            }
            buttomInPage -= 0.5m;
            if (buttomInPage <= 0.0m) {
                buttomInPage = 1m;
                page -= 1;

            }
            isHalf = true;
            DisplayHalfPage();
        }

        private void DisplayHalfPage() {
            if (page >= pdfDoc.PageCount || page< 0) {
                return;
            }
            var pdfSize = pdfDoc.PageSizes[Convert.ToInt32(page)];
            SizeF sourceSize = new SizeF(pdfSize.Width, pdfSize.Height / 2);
            Size? renderSize = GetRenderSize(sourceSize);
            if (renderSize == null) {
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
            using (var g = Graphics.FromImage(canvas)) {
                var img = GetImage(renderSize);
                var y = Convert.ToInt32(renderSize.Height * (buttomInPage - 0.5m));
                var srcRect = new Rectangle(0, y, width, height);
                var desRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
                g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel);
            }
            this.Image = canvas;
            this.OriginalRotateImage = this.Image;
        }
        private Image GetImage(Size renderSize) {
            return pdfDoc.Render(Convert.ToInt32(page), renderSize.Width, renderSize.Height, 96, 96, false);
        }


        public int OriginalImageHeight { get; private set; }
        

        private Image _image;
        public Image Image { 
            get { return _image; }
            set {
                ImageDispose(value);
                _image = value; } }

        private void ImageDispose(Image value)
        {
            if (_image == null) return;
            if (_image == value) return;
            if(_image == _orignailImage) return; 
            _image.Dispose();
            
        }


        private Image _orignailImage;
        private Image OriginalRotateImage
        {
            get { return _orignailImage; }
            set
            {
                if(_orignailImage == value) return;
                _orignailImage?.Dispose();
                _orignailImage = value;
            }
        }

        private int GetSetWinImageHeight()
        {
            var pbSize = FileViewParam.BoundsSize;
            return Convert.ToInt32(Image.Width * pbSize.Height/pbSize.Width );

        }
        private double GetWidthHeightRate(Size size) =>
            size.Width / size.Height;
        
        public bool CanSetWindowWidthRate() {
            var imageSize = Image.Size;
            var pictureBoxSize = FileViewParam.BoundsSize;
            var imageRate = GetWidthHeightRate(imageSize);
            var pbRate = GetWidthHeightRate(pictureBoxSize);
            if (imageRate > pbRate) { 
                return false;
            }
            return true;
        }


        public void DispSetWindow() {

            if (_orignailImage == null)
            {
                Rotate(flip);
            }

            
            if (OriginalRotateImage == null) return;

            OriginalImageHeight = this.OriginalRotateImage.Height;

            if (!CanSetWindowWidthRate()) return;


            int ImageY;
            if(FileViewParam.scrollBarValue + GetSetWinImageHeight() > OriginalRotateImage.Height) {
                ImageY = Convert.ToInt32(OriginalRotateImage.Height - GetSetWinImageHeight());
            }
            else
            {
                ImageY = FileViewParam.scrollBarValue;
            }

            var rect = new Rectangle(0, ImageY, OriginalRotateImage.Width, GetSetWinImageHeight());
            this.Image = BitmapTool.ImageRoi(OriginalRotateImage, rect);
            
        }
    }
}
