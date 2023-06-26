using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;

namespace MediaToSecondMonitor
{
    public partial class ctlPDF : UserControl
    {
        public ctlPDF()
        {
            InitializeComponent();
        }
        private FormDispacher _dispacher = FormDispacher.Instance;

        private PictureBox _pictureBox;



        #region "ページ移動"

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            FirstPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PrePage();
        }
        private void btnNextHalf_Click(object sender, EventArgs e)
        {
            NextHalfPage();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //todo なにもしていない
        }
        #endregion

        public void ControlEnabled()
        {
            this.Enabled = !(_fileViewParam == null);

        }


        private FileViewParam _fileViewParam = null;
        public FileViewParam FileInfo
        {
            set
            {
                this._fileViewParam = value;
                if (_fileViewParam == null)
                {
                    return;
                }
                _pictureBox = _dispacher.GetPictureBox();
                OpenFile(_fileViewParam.FileName);
            }
        }

        private PdfDocument _pdfDoc;
        private int page = 0;
        public void OpenFile(string fileName)
        {
            IsHalf = false;
            _pdfDoc = PdfDocument.Load(fileName);
            FirstPage();
        }

        public void FirstPage()
        {

            IsHalf = false;
            page = 0;
            DisplayPage();
        }

        public void NextPage()
        {
            IsHalf = false;
            if (page < _pdfDoc.PageCount)
            {
                page += 1;
                DisplayPage();
            }
        }

        public void PrePage()
        {
            IsHalf = false;
            if (0 < page)
            {
                page -= 1;
                DisplayPage();
            }
        }

        private decimal buttomInPage;
        private bool _isHalf;
        public bool IsHalf
        {
            get
            {
                return _isHalf;
            }
            set
            {
                _isHalf = value;
                if (!_isHalf)
                {
                    buttomInPage = 0.0M;
                }
            }

        }
        public void NextHalfPage()
        {

            if (!IsHalf)
            {
                page += 1;
            }

            buttomInPage += 0.5M;
            if (buttomInPage == 1.5M)
            {
                page += 1;
                buttomInPage = 0.5M;
            }
            IsHalf = true;
            DisplayHalfPage();
        }

        private void DisplayHalfPage()
        {
            if (page >= _pdfDoc.PageCount)
            {
                return;
            }
            var pdfSize = _pdfDoc.PageSizes[page];
            SizeF sourceSize = new SizeF
            (
                pdfSize.Height / 2,
                pdfSize.Width
            );
            Size? renderSize = GetRenderSize(sourceSize);
            if (renderSize == null)
            {
                return;
            }
            var r = renderSize.Value;
            r.Height *= 2;
            RenderHalf(r);
        }

        private void RenderHalf(Size renderSize)
        {
            var height = renderSize.Height / 2;
            var width = renderSize.Width;
            var canvas = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(canvas))
            {
                var img = GetImage(renderSize);
                var y = (int)(renderSize.Height * (buttomInPage - 0.5M));
                var srcRect = new Rectangle(0, y, width, height);
                var desRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
                g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel);
            }
            DispImage(canvas);
        }
        private Image GetImage(Size renderSize)
        {
            return _pdfDoc.Render(page, renderSize.Width, renderSize.Height, 96, 96, false);
        }
        private void DisplayPage()
        {
            if (page >= _pdfDoc.PageCount)
            {
                return;
            }
            var sourceSize = _pdfDoc.PageSizes[page];
            var renderSize = GetRenderSize(sourceSize);
            if (renderSize == null)
            {
                return;
            }
            Render(renderSize.Value);
        }

        private Size? GetRenderSize(SizeF pdfSize)
        {
            var renderSize = _pictureBox.Size;
            var pdfWdivH = pdfSize.Width / pdfSize.Height;  // pdfの縦横比
            var boxWdivH = _pictureBox.Width / _pictureBox.Height;   // コントロールの縦横比
            if (boxWdivH > 10)
            { // 落ちないよう
                return null;
            }
            if (pdfWdivH < boxWdivH)
            {
                // フォーム内にImageを..当てはめる判定                    {
                renderSize.Width = (int)(_pictureBox.Height * pdfWdivH);
            }
            else
            {
                renderSize.Height = (int)(_pictureBox.Width / pdfWdivH);
            }
            return renderSize;
        }

        private void Render(Size renderSize)
        {
            var img = GetImage(renderSize);
            DispImage(img);
        }

        private void DispImage(Image img)
        {
            var oldImage = _pictureBox.Image;
            _pictureBox.Image = img;
            if (oldImage != null)
            {
                oldImage.Dispose();   // メモリー節約
            }
        }
    }
}
