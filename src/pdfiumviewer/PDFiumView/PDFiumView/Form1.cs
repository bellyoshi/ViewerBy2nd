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
        private string m_strFile;  // PDF�t�@�C����
        private IntPtr m_pdfDoc = (IntPtr)0;
        private IntPtr m_pdfPage = (IntPtr)0;
        private double m_pageWidth = 0;
        private double m_pageHeight = 0;
        private double[] m_aryDispMag;  // �y�[�W���Ƃ̕\���{��
        private int m_iPageMax = 0;
        private int m_iPageAct = -1;

        private bool m_blCtrl = false;
        private Cursor m_preCursor;
        private Point m_dragStartPos = new Point(0, 0);  // �{�^���_�E�����̏ꏊ
        private Point m_dragMovePos = new Point(0, 0);  // �{�^���h���b�O���̍����i�{�^���_�E�����̏ꏊ�Ƃ́j
        private Point[] m_aryDragOffset;  // �h���b�O����ɂ��ݐϑ��΃|�W�V����

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);  // �z�C�[���C�x���g�̒ǉ�

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
                if (string.Compare(m_strFile, files[0], true) != 0)  // �����t�@�C���Ȃ牽�����Ȃ�
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
            // �g���q�`�F�b�N
            if (!IsPdfFile(file))
                return false;

            // �t�@�C�����[�h
            CloseFile();  // ���Ƀ��[�h�ς݂Ȃ����
            m_strFile = file;
            m_pdfDoc = Win32Api.FPDF_LoadDocument(file, null);
            if (m_pdfDoc == null)
                return false;
            m_iPageMax = Win32Api.FPDF_GetPageCount(m_pdfDoc);
            InitPageDispMag(m_iPageMax);  // �y�[�W���Ƃ̊g�嗦��������

            // �y�[�W���[�h
            if (!LoadPage(0))
                return false;
            // �L���v�V�����ύX
            ChangeCaption();
            return true;
        }

        private bool LoadPage(int page)
        {
            if (page < 0 || m_iPageMax <= page)  // �y�[�W�͈͊O
                return false;

            m_iPageAct = page;
            int iDispPage = page + 1;
            toolStripTextBox1.Text = iDispPage.ToString();  // ���݂̃y�[�W

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
        // OnPaint�ɂ��`��
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;  // �A���`�G�C���A�X�������ꂽ���^�����O
            g.Clear(Color.Gray);  // �S�̂��O���C�œh��
            if (string.IsNullOrWhiteSpace(m_strFile))
                return;

            // �t�H�[���̃N���C�A���g�̈�T�C�Y�i�c�[���̍����������j
            int toolh = toolStrip1.Height;
            Size clsize = ClientSize;
            clsize.Height -= toolh;
            double clHi = clsize.Width / clsize.Height;

            // �W���̕`��T�C�Y���擾�i�܂��́A�Œ�𑜓x��W���Ƃ���j
            int dpi = 100;
            double width1 = PointToPixel(dpi, m_pageWidth);
            double height1 = PointToPixel(dpi, m_pageHeight);
            Rectangle ra = new Rectangle(0, toolh, Marume(width1), Marume(height1));

            // �}�E�X���{�^���h���b�O�ɂ���ʈړ�
            Point offset = GetActPageOffset();
            ra.Offset(offset.X, offset.Y);
            ra.Offset(m_dragMovePos.X, m_dragMovePos.Y);

            // �g�嗦���l�������`��T�C�Y���擾
            double mag = GetActPageDispMag();
            double width2 = width1 * mag;
            double height2 = height1 * mag;
            double saw = (width2 - width1) / 2.0;  // ������
            double sah = (height2 - height1) / 2.0;  // ��������
            ra.Inflate(Marume(saw), Marume(sah));

            // DPI�l���X�e�[�^�X�̈�ɕ\��
            double dispDpi = ra.Width / m_pageWidth * 72;
            toolStripStatusLabel1.Text = string.Format("�𑜓x:{0}DPI", Marume(dispDpi));

            // PDF�̈�𔒂œh��
            g.FillRectangle(Brushes.White, ra);

            // PDF��`��
            IntPtr hDC = g.GetHdc();
            Win32Api.FPDF_RenderPage(hDC, m_pdfPage, ra.Left, ra.Top, ra.Width, ra.Height, 0, 0);
            g.ReleaseHdc();
        }
        // �l�̌ܓ����Đ�����
        private int Marume(double d)
        {
            return Convert.ToInt32(d);
        }
        // �|�C���g���s�N�Z�����Z
        private int PointToPixel(int Dpi, double value)
        {
            return (int)((value * Dpi) / 72);
        }

        private void toolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string strTxt = e.ClickedItem.Text;
            if (strTxt == "�J��")
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.InitialDirectory = m_strOpenPath;
                    ofd.Filter = "PDF�t�@�C��(*.pdf)|*.pdf";
                    ofd.Title = "���[�h����PDF�t�@�C����I��";
                    ofd.FileName = "";
                    ofd.RestoreDirectory = true;
                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;
                    m_strOpenPath = Path.GetDirectoryName(ofd.FileName);
                    LoadFile(ofd.FileName);
                    Invalidate();
                }
            }
            else if (strTxt == "����")
            {
                CloseFile();
                ChangeCaption();
                Invalidate();
            }
            else if (strTxt == "�I��")
            {
                Application.Exit();
            }
            else if (strTxt == "png�o��")
            {
                int dpi = 600;  // �𑜓x�i�Œ�j
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
            �J��ToolStripMenuItem.Enabled = true;
            ����ToolStripMenuItem.Enabled = blMenu;
            �I��ToolStripMenuItem.Enabled = true;
        }

        // �y�[�W�_�E��
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int page = m_iPageAct - 1;
            if (LoadPage(page))
                Invalidate();
        }
        // �y�[�W�A�b�v
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int page = m_iPageAct + 1;
            if (LoadPage(page))
                Invalidate();
        }
        // �\���y�[�W��ύX����
        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            int iDispPage = int.Parse(toolStripTextBox1.Text);
            int page = iDispPage - 1;
            if (LoadPage(page))
                Invalidate();
            else
            {
                int iDispPage2 = m_iPageAct + 1;
                toolStripTextBox1.Text = iDispPage2.ToString();  // ���̃y�[�W�ɖ߂�
            }
        }
        // �}�E�X�z�C�[���X�N���[��
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            int wcnt = e.Delta / 120;
            if (m_blCtrl)  // Ctrl�������Ă���̂ŁA��ʊg��k��
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
            else  // �y�[�W�A�b�v���_�E��
            {
                int page = m_iPageAct - wcnt;
                if (LoadPage(page))
                    Invalidate();
            }
        }
        // �y�[�W���Ƃ̕\���{����������
        private void InitPageDispMag(int iPageMax)
        {
            Array.Resize(ref m_aryDispMag, iPageMax);
            for (int i = 0; i < iPageMax; i++)
                m_aryDispMag[i] = 1.0;

            Array.Resize(ref m_aryDragOffset, iPageMax);
            for (int i = 0; i < iPageMax; i++)
                m_aryDragOffset[i] = new Point(0, 0);
        }
        // �y�[�W���Ƃ̕\���{���擾
        private double GetActPageDispMag()
        {
            return m_aryDispMag[m_iPageAct];
        }
        // �y�[�W���Ƃ̕\���{���ݒ�
        private void SetActPageDispMag(double mag)
        {
            m_aryDispMag[m_iPageAct] = mag;
        }
        // �y�[�W���Ƃ̃I�t�Z�b�g���擾
        private Point GetActPageOffset()
        {
            return m_aryDragOffset[m_iPageAct];
        }
        // �y�[�W���Ƃ̃I�t�Z�b�g��ݒ�i�������ށj
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

            // �}�E�X�ړ��̗ݐσ|�W�V����
            int posx = e.X - m_dragStartPos.X;
            int posy = e.Y - m_dragStartPos.Y;
            SetActPageOffset(posx, posy);
            // �|�W�V������������
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