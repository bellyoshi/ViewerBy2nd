namespace ViewerBy2ndLib
{
    public class FileViewParam
    {
     
        public System.Drawing.Size BoundsSize { get; set; }
        public string FileName { get; set; } = String.Empty;

        public override string ToString()
        {
            return $"{System.IO.Path.GetFileName(FileName)}";
        }

        public FileViewParam(string filename, System.Drawing.Size bound)
        {
            this.FileName = filename;
            this.BoundsSize=bound;
        }
        public FileViewParam()
        {
            //シリアル化用
        }

        private Document? _document;
        public Document Document {
            get {
                _document ??= new Document(this);
                return _document;
            }
        }

        public int ZoomHeight { get; set; } = 1024;

        public bool IsZoom { get; set; }

        public int ScrollBarValue { get;  set; }

        public System.Drawing.RotateFlipType  RotateFlipType { get; set; }

        public int TrackBarValue { get; set; }
    }
}
