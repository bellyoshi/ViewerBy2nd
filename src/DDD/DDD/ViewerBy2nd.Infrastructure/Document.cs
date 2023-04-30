using System;
using Patagames;
using Patagames.Pdf;
using Patagames.Pdf.Net;

using System.Drawing;
using Patagames.Pdf.Enums;
using System.Drawing.Imaging;

namespace ViewerBy2ndLib
{
    public class Document
    {
        private ImageDisposer disposer = new ImageDisposer();
        private FileViewParam FileViewParam { get; }

        public FileTypes FileType { get; set; }
        public Document(FileViewParam fileViewParam) {
            this.FileViewParam = fileViewParam;
            this.FileType = new FileTypes(FileViewParam.FileName);
            if (FileType.IsPDFExt)
            {
                PdfCommon.Initialize();
                pdfDoc = PdfDocument.Load(FileViewParam.FileName);
            }
            if (!FileType.IsMovieExt )
                 UpdateImage();
        }

        
        PdfDocument? pdfDoc;

        public int PageCount => pdfDoc?.Pages?.Count??0;

        private float PageWidth => Page?.Width??0f;
        private float PageHeight => Page ?.Height??0f;

        private SizeF PageSize => new SizeF(PageWidth, PageHeight);

        private PdfPage? Page => pdfDoc?.Pages[PageIndex];

        public double PageVirtualIndex { get; set; }
        private Image? OpenImageFile(string filename)
        {
            if (filename == null) return null;

            if (FileType.IsImageExt)
            {
                return LoadImage(filename);

            }
            else if (FileType.IsSVGExt)
            {
                return LoadSVGImage(filename);
            }
            else
            {
                return null;
            }

        }
        public Image LoadSVGImage(string filename) {
            var doc = Svg.SvgDocument.Open(filename);
            var sc = FileViewParam.BoundsSize;
            return  doc.Draw(sc.Height, sc.Height);
        }

        bool requireInitZoomHeight = false;
        private void InitZoomHeight()
        {
            if (FileViewParam.IsZoom)
            {
                FileViewParam.ZoomHeight = GetZoomImageHeightMin();
            }
            else
            {
                FileViewParam.ZoomHeight = RotatedImage?.Height??0;
            }
            requireInitZoomHeight = false;
        }
        public void Rotate(RotateFlipType flip) {


            FileViewParam.rotateFlipType = flip;
            RotatedImage = null;
            requireInitZoomHeight = true;
            UpdateImage();
        }
        internal void CreateRotateImage()
        {
            Image? image;
            if (FileType.IsPDFExt)
            {
                image = RenderPDF();
            }
            else
            {
                image = OpenImageFile(FileViewParam.FileName);
            }
            image?.RotateFlip(FileViewParam.rotateFlipType);
            this.RotatedImage = image;
        }
        public void UpdateImage()
        {
            if (FileViewParam.IsZoom)
            {
                if (RotatedImage == null)
                {
                    CreateRotateImage();
                }
                if (requireInitZoomHeight)
                {
                    InitZoomHeight();
                }
                DispSetWindow();
            }
            else
            {
                CreateRotateImage();
                this.OutPutImage = RotatedImage;
            }

        }

        public Image LoadImage(string filename)
        {
            return new Bitmap(filename);
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

        Image RenderPDF()
        {
            if (PageVirtualIndex >= PageCount)
            {
                System.Diagnostics.Debug.Assert(false);
                return this.RotatedImage;
            }

            var sourceSize = PageSize;
            var renderSize = GetRenderSize(sourceSize);
            if (renderSize == null) {
                System.Diagnostics.Debug.Assert(false);
                return this.RotatedImage;
            }

            
            renderSize = GetWinWidthRenderSize(renderSize.Value, FileViewParam.BoundsSize);
            
            return  GetPdfImage(renderSize.Value);


        }

        public static Size GetWinWidthRenderSize(Size originalRendeSize, Size bound)
        {
            return new Size(bound.Width , bound.Width * originalRendeSize.Height / originalRendeSize.Width );
        }

        public void FirstPage() {


            PageVirtualIndex = 0.0;
            RotatedImage = null;
            UpdateImage();
        }


        public bool CanNextPage()
        => (pdfDoc != null && PageVirtualIndex<PageCount - 1);

        public void NextPage() {

            if (CanNextPage()) {
                RotatedImage = null;
                PageVirtualIndex += 1;
                UpdateImage();
            }
        }
        public bool CanPrePage()
            => 0 < PageVirtualIndex;
        public void PrePage() {
            if (CanPrePage()) {
                RotatedImage = null;
                PageVirtualIndex -= 1;
                UpdateImage();

            }
        }
        public void LastPage()
        {

            PageVirtualIndex = PageCount - 1;
            RotatedImage = null;             
            UpdateImage();

        }


        private decimal buttomInPage;

        public void NextHalfPage() {
            if ((buttomInPage == 1.0m) && (PageVirtualIndex == PageCount - 1)) {
                return;
            }


            buttomInPage += 0.5m;
            if (buttomInPage == 1.5m) {
                NextPage();
                buttomInPage = 0.5m;
            }


            DisplayHalfPage();
        }

        public void PreviousHalfPage() {

            if (PageVirtualIndex == 0 && buttomInPage <= 0.5m) {
                return;
            }
            buttomInPage -= 0.5m;
            if (buttomInPage <= 0.0m) {
                buttomInPage = 1m;
                PageVirtualIndex -= 1;

            }

            DisplayHalfPage();
        }

        private void DisplayHalfPage() {
            if (PageVirtualIndex >= PageCount || PageVirtualIndex< 0) {
                return;
            }
            var pdfSize = PageSize;
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
            this.RotatedImage = this.OutPutImage;
        }

        private int PageIndex =>
         Convert.ToInt32(PageVirtualIndex);
        

        private Image GetPdfImage(Size renderSize)
        {
            return RenderPage(PageIndex, renderSize.Width, renderSize.Height)??new Bitmap(1, 1);

        }

        Image? RenderPage(int pageIndex,int renderWidth, int renderHeight)
        {
            var page = pdfDoc?.Pages[pageIndex];

            int nw = renderWidth;
            int nh = renderHeight;

            var pdfbitmap = new PdfBitmap(nw, nh, true); // bitmap をつくる
            pdfbitmap.FillRect(0, 0, nw, nh, FS_COLOR.White); // 背景は白

            page?.Render(pdfbitmap, 0, 0, nw, nh,
                Patagames.Pdf.Enums.PageRotate.Normal,
                Patagames.Pdf.Enums.RenderFlags.FPDF_ANNOT);
            
            return pdfbitmap.Image;
        }



        public int OriginalImageHeight { get; private set; }
        
        public Image? OutPutImage {
            get => disposer.OutputImage;
            set => disposer.OutputImage = value;
        }

        private Image? RotatedImage
        {
            get => disposer.RotatedImage ;
            set => disposer.RotatedImage = value;
            
        }

        private int GetSetWinImageHeight()
        {
            return FileViewParam.ZoomHeight;
        }
        public int GetZoomImageHeightMin()
        {
            var pbSize = FileViewParam.BoundsSize;
            return Convert.ToInt32(pbSize.Height  * RotatedImage?.Width / pbSize.Width);
        }
        public void ZoomUp()
        {
            if (!FileViewParam.IsZoom)
            {
                FileViewParam.ZoomHeight = RotatedImage?.Height??0;
            }
            FileViewParam.IsZoom = true;


            var zoomDelta = (RotatedImage?.Height??0 - GetZoomImageHeightMin()) / 7;
            FileViewParam.ZoomHeight -= zoomDelta;

            if (FileViewParam.ZoomHeight <= GetZoomImageHeightMin())
            {
                FileViewParam.ZoomHeight = GetZoomImageHeightMin();
            }

        }
        public void ZoomDown()
        {

            var zoomDelta = (RotatedImage?.Height??0 - GetZoomImageHeightMin()) / 7;
            FileViewParam.ZoomHeight += zoomDelta;
            if ((RotatedImage?.Height??0) <= FileViewParam.ZoomHeight)
            {
                FileViewParam.ZoomHeight = RotatedImage?.Height??0;
                FileViewParam.IsZoom = false;
            }


        }
        private double GetAspectRatio(Size size) =>
            size.Width / size.Height;
        
        public bool CanSetWindowWidthRate() {
            var imageSize = RotatedImage?.Size??new Size(0,0);
            var pictureBoxSize = FileViewParam.BoundsSize;
            var imageRate = GetAspectRatio(imageSize);
            var pbRate = GetAspectRatio(pictureBoxSize);
            if (imageRate > pbRate) { 
                return false;
            }
            return true;
        }


        public void DispSetWindow() {

            if (RotatedImage == null)
            {
                CreateRotateImage();
            }

            


            OriginalImageHeight = RotatedImage?.Height??0;

            if (!CanSetWindowWidthRate()) return;


            int ImageY;
            if(FileViewParam.scrollBarValue + GetSetWinImageHeight() > (RotatedImage?.Height??0)) {
                ImageY = Convert.ToInt32(RotatedImage?.Height??0 - GetSetWinImageHeight());
            }
            else
            {
                ImageY = FileViewParam.scrollBarValue;
            }

            var rect = new Rectangle(0, ImageY, RotatedImage?.Width??0, GetSetWinImageHeight());
            this.OutPutImage = BitmapTool.ImageRoi(RotatedImage??new Bitmap(0,0), rect);
            
        }
    }
}
