using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace PDFiumView
{
    public partial class Form1 : Form
    {
        private string m_strOpenPath = @"C:\";
        private string m_strFile;  // PDFファイル名
        private IntPtr m_pdfDoc = (IntPtr)0;
        private IntPtr m_pdfPage = (IntPtr)0;
        private double m_pageWidth = 0;
        private double m_pageHeight = 0;
        private double[] m_aryDispMag;  // ページごとの表示倍率
        private int m_iPageMax = 0;
        private int m_iPageAct = -1;

        private bool m_blCtrl = false;
        private Cursor m_preCursor;
        private Point m_dragStartPos = new Point(0, 0);  // ボタンダウン時の場所
        private Point m_dragMovePos = new Point(0, 0);  // ボタンドラッグ中の差分（ボタンダウン時の場所との）
        private Point[] m_aryDragOffset;  // ドラッグ操作による累積相対ポジション

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);  // ホイールイベントの追加

            Win32Api.FPDF_InitLibrary();
            string[] cmds = System.Environment.GetCommandLineArgs();
            if (cmds.Length > 1)
            {
                string cmd = cmds[1];
                if (System.IO.File.Exists(cmd))
                    LoadFile(cmd);
            }
        }
        public void End()
        {
            CloseFile();
            Win32Api.FPDF_DestroyLibrary();
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length > 0)
            {
                if (string.Compare(m_strFile, files[0], true) != 0)  // 同じファイルなら何もしない
                {
                    LoadFile(files[0]);
                    Invalidate();
                }
            }
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private bool LoadFile(string file)
        {
            // 拡張子チェック
            if (!IsPdfFile(file))
                return false;

            // ファイルロード
            CloseFile();  // 既にロード済みなら閉じる
            m_strFile = file;
            m_pdfDoc = Win32Api.FPDF_LoadDocument(file, null);
            if (m_pdfDoc == null)
                return false;
            m_iPageMax = Win32Api.FPDF_GetPageCount(m_pdfDoc);
            InitPageDispMag(m_iPageMax);  // ページごとの拡大率を初期化

            // ページロード
            if (!LoadPage(0))
                return false;
            // キャプション変更
            ChangeCaption();
            return true;
        }

        private bool LoadPage(int page)
        {
            if (page < 0 || m_iPageMax <= page)  // ページ範囲外
                return false;

            m_iPageAct = page;
            int iDispPage = page + 1;
            toolStripTextBox1.Text = iDispPage.ToString();  // 現在のページ

            ClosePage();
            m_pdfPage = Win32Api.FPDF_LoadPage(m_pdfDoc, m_iPageAct);
            m_pageWidth = Win32Api.FPDF_GetPageWidth(m_pdfPage);
            m_pageHeight = Win32Api.FPDF_GetPageHeight(m_pdfPage);
            return true;
        }
        private void ClosePage()
        {
            if (m_pdfPage != (IntPtr)0)
            {
                Win32Api.FPDF_ClosePage(m_pdfPage);
                m_pdfPage = (IntPtr)0;
            }
        }
        private void CloseFile()
        {
            ClosePage();
            if (m_pdfDoc != (IntPtr)0)
            {
                Win32Api.FPDF_CloseDocument(m_pdfDoc);
                m_pdfDoc = (IntPtr)0;
                m_strFile = "";
            }
        }
        private bool IsPdfFile(string file)
        {
            int pos = file.LastIndexOf('.');
            string strExt = file.Substring(pos + 1);
            if (strExt.ToLower() == "pdf")
                return true;
            return false;
        }
        private void ChangeCaption()
        {
            if (string.IsNullOrWhiteSpace(m_strFile))
                this.Text = "PDFiumView ";
            else
                this.Text = "PDFiumView " + "[" + m_strFile + "]";
            toolStripLabel1.Text = "/ " + m_iPageMax.ToString();
        }
        // OnPaintによる描画
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;  // アンチエイリアス処理されたレタリング
            g.Clear(Color.Gray);  // 全体をグレイで塗る
            if (string.IsNullOrWhiteSpace(m_strFile))
                return;

            // フォームのクライアント領域サイズ（ツールの高さを除く）
            int toolh = toolStrip1.Height;
            Size clsize = ClientSize;
            clsize.Height -= toolh;
            double clHi = clsize.Width / clsize.Height;

            // 標準の描画サイズを取得（まずは、固定解像度を標準とする）
            int dpi = 100;
            double width1 = PointToPixel(dpi, m_pageWidth);
            double height1 = PointToPixel(dpi, m_pageHeight);
            Rectangle ra = new Rectangle(0, toolh, Marume(width1), Marume(height1));

            // マウス中ボタンドラッグによる画面移動
            Point offset = GetActPageOffset();
            ra.Offset(offset.X, offset.Y);
            ra.Offset(m_dragMovePos.X, m_dragMovePos.Y);

            // 拡大率を考慮した描画サイズを取得
            double mag = GetActPageDispMag();
            double width2 = width1 * mag;
            double height2 = height1 * mag;
            double saw = (width2 - width1) / 2.0;  // 差分幅
            double sah = (height2 - height1) / 2.0;  // 差分高さ
            ra.Inflate(Marume(saw), Marume(sah));

            // DPI値をステータス領域に表示
            double dispDpi = ra.Width / m_pageWidth * 72;
            toolStripStatusLabel1.Text = string.Format("解像度:{0}DPI", Marume(dispDpi));

            // PDF領域を白で塗る
            g.FillRectangle(Brushes.White, ra);

            // PDFを描画
            IntPtr hDC = g.GetHdc();
            Win32Api.FPDF_RenderPage(hDC, m_pdfPage, ra.Left, ra.Top, ra.Width, ra.Height, 0, 0);
            g.ReleaseHdc();
        }
        // 四捨五入して整数化
        private int Marume(double d)
        {
            return Convert.ToInt32(d);
        }
        // ポイントをピクセル換算
        private int PointToPixel(int Dpi, double value)
        {
            return (int)((value * Dpi) / 72);
        }

        private void toolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string strTxt = e.ClickedItem.Text;
            if (strTxt == "開く")
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.InitialDirectory = m_strOpenPath;
                    ofd.Filter = "PDFファイル(*.pdf)|*.pdf";
                    ofd.Title = "ロードするPDFファイルを選択";
                    ofd.FileName = "";
                    ofd.RestoreDirectory = true;
                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;
                    m_strOpenPath = Path.GetDirectoryName(ofd.FileName);
                    LoadFile(ofd.FileName);
                    Invalidate();
                }
            }
            else if (strTxt == "閉じる")
            {
                CloseFile();
                ChangeCaption();
                Invalidate();
            }
            else if (strTxt == "終了")
            {
                Application.Exit();
            }
            else if (strTxt == "png出力")
            {
                int dpi = 600;  // 解像度（固定）
                int w = PointToPixel(dpi, m_pageWidth);
                int h = PointToPixel(dpi, m_pageHeight);
                System.Drawing.Image image = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(image);
                IntPtr hDC = g.GetHdc();
                Win32Api.FPDF_RenderPage(hDC, m_pdfPage, 0, 0, w, h, 0, 0);
                g.ReleaseHdc();
                g.Dispose();
                int pos = m_strFile.LastIndexOf('.');
                string strPng = m_strFile.Substring(0, pos+1) + "png";
                image.Save(strPng);
                image.Dispose();
            }
        }
        private void toolStripDropDownButton1_DropDownOpening(object sender, EventArgs e)
        {
            bool blMenu = true;
            if (string.IsNullOrWhiteSpace(m_strFile))
                blMenu = false;
            開くToolStripMenuItem.Enabled = true;
            閉じるToolStripMenuItem.Enabled = blMenu;
            終了ToolStripMenuItem.Enabled = true;
        }

        // ページダウン
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int page = m_iPageAct - 1;
            if (LoadPage(page))
                Invalidate();
        }
        // ページアップ
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int page = m_iPageAct + 1;
            if (LoadPage(page))
                Invalidate();
        }
        // 表示ページを変更した
        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            int iDispPage = int.Parse(toolStripTextBox1.Text);
            int page = iDispPage - 1;
            if (LoadPage(page))
                Invalidate();
            else
            {
                int iDispPage2 = m_iPageAct + 1;
                toolStripTextBox1.Text = iDispPage2.ToString();  // 元のページに戻す
            }
        }
        // マウスホイールスクロール
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            int wcnt = e.Delta / 120;
            if (m_blCtrl)  // Ctrlを押しているので、画面拡大縮小
            {
                double mag = 0;
                if (wcnt > 0)
                    mag = GetActPageDispMag() * 1.1;
                else
                    mag = GetActPageDispMag() / 1.1;
                if (mag < 0.05 || 12.0 < mag)
                    return;
                SetActPageDispMag(mag);
                Invalidate();
            }
            else  // ページアップ＆ダウン
            {
                int page = m_iPageAct - wcnt;
                if (LoadPage(page))
                    Invalidate();
            }
        }
        // ページごとの表示倍率を初期化
        private void InitPageDispMag(int iPageMax)
        {
            Array.Resize(ref m_aryDispMag, iPageMax);
            for (int i = 0; i < iPageMax; i++)
                m_aryDispMag[i] = 1.0;

            Array.Resize(ref m_aryDragOffset, iPageMax);
            for (int i = 0; i < iPageMax; i++)
                m_aryDragOffset[i] = new Point(0, 0);
        }
        // ページごとの表示倍率取得
        private double GetActPageDispMag()
        {
            return m_aryDispMag[m_iPageAct];
        }
        // ページごとの表示倍率設定
        private void SetActPageDispMag(double mag)
        {
            m_aryDispMag[m_iPageAct] = mag;
        }
        // ページごとのオフセットを取得
        private Point GetActPageOffset()
        {
            return m_aryDragOffset[m_iPageAct];
        }
        // ページごとのオフセットを設定（足し込む）
        private void SetActPageOffset(int x, int y)
        {
            m_aryDragOffset[m_iPageAct].Offset(x, y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData & Keys.KeyCode) == Keys.ControlKey)
                m_blCtrl = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyData & Keys.KeyCode) == Keys.ControlKey)
                m_blCtrl = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_blCtrl == false || e.Button != MouseButtons.Middle)
                return;
            m_preCursor = Cursor.Current;
            Cursor.Current = Cursors.NoMove2D;
            m_dragStartPos.X = e.X;
            m_dragStartPos.Y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_blCtrl == false || e.Button != MouseButtons.Middle)
                return;
            Cursor.Current = m_preCursor;

            // マウス移動の累積ポジション
            int posx = e.X - m_dragStartPos.X;
            int posy = e.Y - m_dragStartPos.Y;
            SetActPageOffset(posx, posy);
            // ポジションを初期化
            m_dragStartPos.X = m_dragStartPos.Y = 0;
            m_dragMovePos.X = m_dragMovePos.Y = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_blCtrl == false || e.Button != MouseButtons.Middle)
                return;
            m_dragMovePos.X = e.X - m_dragStartPos.X;
            m_dragMovePos.Y = e.Y - m_dragStartPos.Y;
            Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string txt = Application.StartupPath + "\\help.txt";
            System.Diagnostics.Process.Start(txt);
        }




    }
    class Win32Api
    {
        [DllImport("pdfium.dll", EntryPoint = "FPDF_InitLibrary", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FPDF_InitLibrary();

        [StructLayout(LayoutKind.Sequential)]
        public struct FPDF_LIBRARY_CONFIG
        {
            public int version;
            public IntPtr m_pUserFontPaths;
            public IntPtr m_pIsolate;
            public uint m_v8EmbedderSlot;
        }

        [DllImport("pdfium.dll", EntryPoint = "FPDF_InitLibraryWithConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FPDF_InitLibraryWithConfig(ref FPDF_LIBRARY_CONFIG config);

        [DllImport("pdfium.dll", EntryPoint = "FPDF_DestroyLibrary", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FPDF_DestroyLibrary();

        [DllImport("pdfium.dll", EntryPoint = "FPDF_LoadDocument", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FPDF_LoadDocument(string file_path, string password);

        [DllImport("pdfium.dll", EntryPoint = "FPDF_CloseDocument", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FPDF_CloseDocument(IntPtr document);

        [DllImport("pdfium.dll", EntryPoint = "FPDF_GetPageCount", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FPDF_GetPageCount(IntPtr document);

        [DllImport("pdfium.dll", EntryPoint = "FPDF_LoadPage", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FPDF_LoadPage(IntPtr document, int page_index);

        [DllImport("pdfium.dll", EntryPoint = "FPDF_ClosePage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FPDF_ClosePage(IntPtr page);

        [DllImport("pdfium.dll", EntryPoint = "FPDF_GetPageWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern double FPDF_GetPageWidth(IntPtr page);

        [DllImport("pdfium.dll", EntryPoint = "FPDF_GetPageHeight", CallingConvention = CallingConvention.Cdecl)]
        public static extern double FPDF_GetPageHeight(IntPtr page);

        [DllImport("pdfium.dll", EntryPoint = "FPDF_RenderPage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FPDF_RenderPage(IntPtr hDC, IntPtr page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);

        [DllImport("pdfium.dll", EntryPoint = "FPDF_RenderPageBitmap", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FPDF_RenderPageBitmap(IntPtr bitmap, IntPtr page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);

        [DllImport("pdfium.dll", EntryPoint = "FPDFBitmap_Create", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FPDFBitmap_Create(int width, int height, bool isUseAlpha);
    }
}