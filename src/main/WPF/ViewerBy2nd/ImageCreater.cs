using Svg;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using ViewerBy2nd.FileViewParams;

namespace ViewerBy2nd;

internal class ImageCreater
{
    public static BitmapSource GetImageFromFile(PdfFileViewParam pdfFileViewParam)
    {
        return pdfFileViewParam.PDFDocument.GetImage( 
            pdfFileViewParam.CurrentPage,
            pdfFileViewParam.Scale);
    }
    public static BitmapSource GetImageFromFile(SvgFileViewParam svgFileViewParam)
    {
        return pdfiumWrapper2.SVGRender.GetSVGImage(svgFileViewParam.filename);
    }
    public static BitmapSource GetImageFromFile(ImageFileViewParam viewParam)
    {
        return new BitmapImage(new Uri(viewParam.filename));
    }



}
