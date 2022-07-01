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
        public Image OpenFile(string filename)
        {
            if (filename == null) return null;
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
            return this.OutPutImage;
        }
        public void LoadSVGImage() {
            var doc = Svg.SvgDocument.Open(FileViewParam.FileName);
            var sc = FileViewParam.BoundsSize;
            this.OutPutImage = doc.Draw(sc.Height, sc.Height);
            this.OriginalRotateImage = OutPutImage;
        }

        public void Rotate(RotateFlipType flip) {


            FileViewParam.rotateFlipType = flip;
            CreateOriginaiImage();
            UpdateImage();
        }
        internal void CreateOriginaiImage()
        {
            Image image;
            if (FileType.IsPDFExt)
            {
                image = pdfRender();
            }
            else
            {
                image = OpenFile(FileViewParam.FileName);
            }
            image.RotateFlip(FileViewParam.rotateFlipType);
            this.OriginalRotateImage = image;
            this.OutPutImage = image;
        }
        internal void UpdateImage()
        {
            if (OriginalRotateImage == null)
            {
                CreateOriginaiImage();
            }
           
            if (FileViewParam.IsWidthEqualWin == true)
            {
                DispSetWindow();
            }
            else
            {
                CreateOriginaiImage();
            }

        }

        public void LoadImage()
        {
            this.OutPutImage = new Bitmap(FileViewParam.FileName);
            this.OriginalRotateImage = this.OutPutImage;
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

        Image pdfRender()
        {
            if (page >= pdfDoc.PageCount)
            {
                System.Diagnostics.Debug.Assert(false);
                return this.OriginalRotateImage;
            }

            var sourceSize = pdfDoc.PageSizes[Convert.ToInt32(page)];
            var renderSize = GetRenderSize(sourceSize);
            if (renderSize == null) {
                System.Diagnostics.Debug.Assert(false);
                return this.OriginalRotateImage;
            }

            
            renderSize = GetWinWidthRenderSize(renderSize.Value, FileViewParam.BoundsSize);
            
            return  GetPdfImage(renderSize.Value);


        }

        public static Size GetWinWidthRenderSize(Size originalRendeSize, Size bound)
        {
            return new Size(bound.Width , bound.Width * originalRendeSize.Height / originalRendeSize.Width );
        }

        public void FirstPage() {

            isHalf = false;
            page = 0.0;
            OriginalRotateImage = null;
            UpdateImage();
        }


        public bool CanNextPage()
        => (pdfDoc != null && page<pdfDoc.PageCount - 1);

        public void NextPage() {
            isHalf = false;

            if (CanNextPage()) {
                OriginalRotateImage = null;
                page += 1;
                UpdateImage();
            }
        }
        public bool CanPrePage()
            => 0 < page;
        public void PrePage() {
            isHalf = false;
            if (CanPrePage()) {
                OriginalRotateImage = null;
                page -= 1;
                UpdateImage();

            }
        }
        public void LastPage()
        {
            isHalf = false;
            page = PageCount - 1;
            OriginalRotateImage = null;             
            UpdateImage();

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
                var img = GetPdfImage(renderSize);
                var y = Convert.ToInt32(renderSize.Height * (buttomInPage - 0.5m));
                var srcRect = new Rectangle(0, y, width, height);
                var desRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
                g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel);
            }
            this.OutPutImage = canvas;
            this.OriginalRotateImage = this.OutPutImage;
        }
        private Image GetPdfImage(Size renderSize) {
            return pdfDoc.Render(Convert.ToInt32(page), renderSize.Width, renderSize.Height, 96, 96, false);
        }


        public int OriginalImageHeight { get; private set; }
        

        private Image _image;
        public Image OutPutImage { 
            get { return _image; }
            set {
                ImageDispose(value);
                _image = value; } }

        private void ImageDispose(Image value)
        {
            if (_image == null) return;
            if (_image == value) return;
            if(_image == OriginalRotateImage) return; 
            _image.Dispose();
            
        }


        private Image _originalRotateImage;
        private Image OriginalRotateImage
        {
            get { return _originalRotateImage; }
            set
            {
                if(_originalRotateImage == value) return;
                _originalRotateImage?.Dispose();
                _originalRotateImage = value;
            }
        }

        private int GetSetWinImageHeight()
        {
            var pbSize = FileViewParam.BoundsSize;
            return Convert.ToInt32(OutPutImage.Width * pbSize.Height/pbSize.Width );

        }
        private double GetWidthHeightRate(Size size) =>
            size.Width / size.Height;
        
        public bool CanSetWindowWidthRate() {
            var imageSize = OutPutImage.Size;
            var pictureBoxSize = FileViewParam.BoundsSize;
            var imageRate = GetWidthHeightRate(imageSize);
            var pbRate = GetWidthHeightRate(pictureBoxSize);
            if (imageRate > pbRate) { 
                return false;
            }
            return true;
        }


        public void DispSetWindow() {

            if (OriginalRotateImage == null)
            {
                CreateOriginaiImage();
            }

            


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
            this.OutPutImage = BitmapTool.ImageRoi(OriginalRotateImage, rect);
            
        }
    }
}
