using System.Drawing;

namespace ViewerBy2ndLib
{
    public  class BitmapTool
    {
        public static Bitmap ImageRoi(Image src, Rectangle roi)
        {
            //////////////////////////////////////////////////////////////////////
            // srcRectとroiの重なった領域を取得（画像をはみ出した領域を切り取る）

            // 画像の領域
            var imgRect = new Rectangle(0, 0, src.Width, src.Height);
            // はみ出した部分を切り取る(重なった領域を取得)
            var roiTrim = Rectangle.Intersect(imgRect, roi);
            // 画像の外の領域を指定した場合
            if (roiTrim.IsEmpty == true) return null;

            //////////////////////////////////////////////////////////////////////
            // 画像の切り出し

            // 切り出す大きさと同じサイズのBitmapオブジェクトを作成
            var dst = new Bitmap(roiTrim.Width, roiTrim.Height, src.PixelFormat);
            // BitmapオブジェクトからGraphicsオブジェクトの作成
            var g = Graphics.FromImage(dst);
            // 描画先
            var dstRect = new Rectangle(0, 0, roiTrim.Width, roiTrim.Height);
            // 描画
            g.DrawImage(src, dstRect, roiTrim, GraphicsUnit.Pixel);
            // 解放
            g.Dispose();

            return dst;
        }
    }
}
