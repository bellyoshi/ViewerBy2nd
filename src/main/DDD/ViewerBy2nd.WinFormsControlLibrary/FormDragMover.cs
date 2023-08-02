using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    /// <summary>
    /// フォームをドラッグして移動するクラス
    /// </summary>
    class FormDragMover
    {
        // 移動の対象となるフォーム
        Form moveForm;

        // 移動中を表す状態
        bool moveStatus;

        // ドラッグを無効とする幅（フォームの端をサイズ変更に使うときなど）
        int noDragAreaWidth;

        // 標準のカーソル
        Cursor defaultCursor;

        // マウスをクリックした位置
        Point lastMouseDownPoint;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="moveForm">移動の対象となるフォーム</param>
        /// <param name="noDragAreaWidth">ドラッグを無効とする幅</param>
        public FormDragMover(Form moveForm, int noDragAreaWidth, Control[] controls)
        {
            this.moveForm = moveForm;
            this.noDragAreaWidth = noDragAreaWidth;

            // 現時点でのカーソルを保存しておく
            defaultCursor = moveForm.Cursor;

            foreach (Control control in controls)
            {
                // イベントハンドラを追加
                control.MouseDown += new MouseEventHandler(moveForm_MouseDown);
                control.MouseMove += new MouseEventHandler(moveForm_MouseMove);
                control.MouseUp += new MouseEventHandler(moveForm_MouseUp);
            }

        }

        /// <summary>
        /// マウスボタン押下イベントハンドラ
        /// </summary>
        void moveForm_MouseDown(object sender, MouseEventArgs e)
        {
            // 左クリック時のみ処理する。左クリックでなければ何もしない
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;

            // 移動が有効になる範囲
            // 例えばフォームの端から何ドットかをサイズ変更用の領域として使用する場合、
            // そこを避けるために使う。
            Rectangle moveArea = new Rectangle(
                noDragAreaWidth, noDragAreaWidth,
                moveForm.Width - (noDragAreaWidth * 2), moveForm.Height - (noDragAreaWidth * 2));

            // クリックした位置が移動が有効になる範囲であれば、移動中にする
            if (moveArea.Contains(e.Location))
            {
                // 移動中にする
                moveStatus = true;

                // クリックしたポイントを保存する
                lastMouseDownPoint = e.Location;

                // マウスキャプチャー
                moveForm.Capture = true;
            }
            else
            {
                moveStatus = false;
            }
        }

        /// <summary>
        /// マウス移動イベントハンドラ
        /// </summary>
        void moveForm_MouseMove(object sender, MouseEventArgs e)
        {
            // 移動中の場合のみ処理。移動中でなければ何もせず終わる
            if (moveStatus == false) return;

            // 左ボタン押下中のみ処理する。押下中ではないときは何もしない。
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;

            // マウスカーソルの変更
            moveForm.Cursor = Cursors.SizeAll;

            // フォームの移動
            //*//通常の場合
            moveForm.Left += e.X - lastMouseDownPoint.X;
            moveForm.Top += e.Y - lastMouseDownPoint.Y;
            //*/

            // 吸着の処理は後回し、かなこのことは好き。
        }

        /// <summary>
        /// マウスボタン押上イベントハンドラ
        /// </summary>
        void moveForm_MouseUp(object sender, MouseEventArgs e)
        {
            // 左ボタンのみ処理する。左ボタンではないときは何もしない。
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;

            // 移動を終了する
            moveStatus = false;

            // マウスキャプチャーを終了する
            moveForm.Capture = false;
        }
    }
}
