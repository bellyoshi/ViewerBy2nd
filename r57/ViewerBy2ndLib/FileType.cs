using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2ndLib
{
    //public enum FileTypeEnum
    //{
    //    MOVIE = 1,
    //    IMAGE = 2,
    //    PDF = 3,
    //    SVG = 4,
    //}
    public class FileType
    {

        /// 開ける動画の拡張子
        static string[] movieExts = { "avi", "mpeg", "mp4", "wmv", "mov" };

        // 開ける画像の拡張子
        static string[] ImageExts = { "jpeg", "jpg", "bmp", "png", "gif", "tiff", "tif", "svg" };

        static string[] SVGExts = { "svg" };

        // PDFの拡張子
        static string[] PDFExts = { "pdf" };

        //FileTypeEnum fileType;

        public string extention;
        bool IsPDFExt(String ext)
        {
            return IsContain(PDFExts);
        }

        bool IsContain(string[] exts)
        {
            foreach (var target in exts)
            {
                if (String.Compare($".{target}", extention, true) == 0)
                    return true;
            }
            return false;
        }

        public bool IsImageExt()
             => IsContain(ImageExts);
        public bool IsMovieExt()
             => IsContain(movieExts);
        public bool IsSVGExt()
            => IsContain(SVGExts);
        public bool IsPDFExt()
            => IsContain(PDFExts);

        public FileType(string filename)
        {
            this.extention = System.IO.Path.GetExtension(filename);
        }
        static public string CreateFilter()
        {
            var buf = new System.Text.StringBuilder();
            buf.Append("画像、動画、PDFファイル");
            buf.Append("|");
            buf.Append(CreateExtsOfFilter(PDFExts));
            buf.Append(CreateExtsOfFilter(ImageExts));
            buf.Append(CreateExtsOfFilter(movieExts));
            buf.Append(CreateExtsOfFilter(SVGExts));
            buf.Append("|");
            buf.Append("All Files(*.*)");
            buf.Append("|");
            buf.Append("*.*");
        
        return buf.ToString();
    }

        static  string CreateExtsOfFilter(string[] exts) {
            var buf = new System.Text.StringBuilder();
            foreach(var ext in exts){
                buf.Append("*.");
                buf.Append(ext);
                buf.Append(";");
            }
            return buf.ToString();
        }
    }
}
