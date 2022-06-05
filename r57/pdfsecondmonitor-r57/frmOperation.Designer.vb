<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOperation
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperation))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cmbDisplay = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFormColor = New System.Windows.Forms.Label()
        Me.btnColorChange = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPDFFileName = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lstPDFFiles = New System.Windows.Forms.ListBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btnUnSelect = New System.Windows.Forms.Button()
        Me.btnFileAdd = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.btnDisp = New System.Windows.Forms.Button()
        Me.chkUpdate = New System.Windows.Forms.CheckBox()
        Me.btnUnDisp = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.pbThumbnail = New System.Windows.Forms.PictureBox()
        Me.btnSetWindow = New System.Windows.Forms.Button()
        Me.btnRotate90 = New System.Windows.Forms.Button()
        Me.btnRotate0 = New System.Windows.Forms.Button()
        Me.btnRotateM90 = New System.Windows.Forms.Button()
        Me.btnRotate180 = New System.Windows.Forms.Button()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.trackBarSeek = New System.Windows.Forms.TrackBar()
        Me.GotoFirst = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnFastReverse = New System.Windows.Forms.Button()
        Me.btnFastForward = New System.Windows.Forms.Button()
        Me.btnStartStop = New System.Windows.Forms.Button()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.btnPreviousHalf = New System.Windows.Forms.Button()
        Me.btnNextHalf = New System.Windows.Forms.Button()
        Me.btnPDFNext = New System.Windows.Forms.Button()
        Me.btnPDFBack = New System.Windows.Forms.Button()
        Me.btnPDFFirst = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbBack = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackBarSeek, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'cmbDisplay
        '
        Me.cmbDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDisplay.FormattingEnabled = True
        Me.cmbDisplay.Location = New System.Drawing.Point(198, 19)
        Me.cmbDisplay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbDisplay.Name = "cmbDisplay"
        Me.cmbDisplay.Size = New System.Drawing.Size(163, 23)
        Me.cmbDisplay.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "表示するディスプレイ"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblFormColor)
        Me.GroupBox1.Controls.Add(Me.btnColorChange)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbDisplay)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 12)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(661, 54)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "設定"
        '
        'lblFormColor
        '
        Me.lblFormColor.AutoSize = True
        Me.lblFormColor.Location = New System.Drawing.Point(567, 25)
        Me.lblFormColor.Name = "lblFormColor"
        Me.lblFormColor.Size = New System.Drawing.Size(27, 15)
        Me.lblFormColor.TabIndex = 9
        Me.lblFormColor.Text = "　　"
        '
        'btnColorChange
        '
        Me.btnColorChange.Location = New System.Drawing.Point(445, 17)
        Me.btnColorChange.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnColorChange.Name = "btnColorChange"
        Me.btnColorChange.Size = New System.Drawing.Size(93, 31)
        Me.btnColorChange.TabIndex = 8
        Me.btnColorChange.Text = "背景色変更"
        Me.btnColorChange.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(368, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 15)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "ファイル情報"
        '
        'txtPDFFileName
        '
        Me.txtPDFFileName.Location = New System.Drawing.Point(363, 86)
        Me.txtPDFFileName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPDFFileName.Name = "txtPDFFileName"
        Me.txtPDFFileName.ReadOnly = True
        Me.txtPDFFileName.Size = New System.Drawing.Size(655, 22)
        Me.txtPDFFileName.TabIndex = 4
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(101, 536)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(105, 31)
        Me.btnDelete.TabIndex = 21
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lstPDFFiles
        '
        Me.lstPDFFiles.AllowDrop = True
        Me.lstPDFFiles.FormattingEnabled = True
        Me.lstPDFFiles.ItemHeight = 15
        Me.lstPDFFiles.Location = New System.Drawing.Point(35, 170)
        Me.lstPDFFiles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lstPDFFiles.Name = "lstPDFFiles"
        Me.lstPDFFiles.Size = New System.Drawing.Size(308, 349)
        Me.lstPDFFiles.TabIndex = 19
        '
        'btnUnSelect
        '
        Me.btnUnSelect.Location = New System.Drawing.Point(241, 114)
        Me.btnUnSelect.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUnSelect.Name = "btnUnSelect"
        Me.btnUnSelect.Size = New System.Drawing.Size(90, 40)
        Me.btnUnSelect.TabIndex = 20
        Me.btnUnSelect.Text = "選択解除"
        Me.btnUnSelect.UseVisualStyleBackColor = True
        '
        'btnFileAdd
        '
        Me.btnFileAdd.Location = New System.Drawing.Point(212, 536)
        Me.btnFileAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFileAdd.Name = "btnFileAdd"
        Me.btnFileAdd.Size = New System.Drawing.Size(131, 31)
        Me.btnFileAdd.TabIndex = 21
        Me.btnFileAdd.Text = "ファイルを追加"
        Me.btnFileAdd.UseVisualStyleBackColor = True
        '
        'btnDisp
        '
        Me.btnDisp.Location = New System.Drawing.Point(35, 114)
        Me.btnDisp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDisp.Name = "btnDisp"
        Me.btnDisp.Size = New System.Drawing.Size(98, 40)
        Me.btnDisp.TabIndex = 20
        Me.btnDisp.Text = "表示"
        Me.btnDisp.UseVisualStyleBackColor = True
        '
        'chkUpdate
        '
        Me.chkUpdate.AutoSize = True
        Me.chkUpdate.Location = New System.Drawing.Point(60, 88)
        Me.chkUpdate.Name = "chkUpdate"
        Me.chkUpdate.Size = New System.Drawing.Size(195, 19)
        Me.chkUpdate.TabIndex = 25
        Me.chkUpdate.Text = "操作中にモニターを更新する"
        Me.chkUpdate.UseVisualStyleBackColor = True
        '
        'btnUnDisp
        '
        Me.btnUnDisp.Location = New System.Drawing.Point(145, 114)
        Me.btnUnDisp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUnDisp.Name = "btnUnDisp"
        Me.btnUnDisp.Size = New System.Drawing.Size(90, 40)
        Me.btnUnDisp.TabIndex = 20
        Me.btnUnDisp.Text = "表示終了"
        Me.btnUnDisp.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(832, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 15)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "表示プレビュー"
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(1120, 168)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(23, 300)
        Me.VScrollBar1.TabIndex = 39
        '
        'pbThumbnail
        '
        Me.pbThumbnail.Location = New System.Drawing.Point(690, 168)
        Me.pbThumbnail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbThumbnail.Name = "pbThumbnail"
        Me.pbThumbnail.Size = New System.Drawing.Size(427, 300)
        Me.pbThumbnail.TabIndex = 38
        Me.pbThumbnail.TabStop = False
        '
        'btnSetWindow
        '
        Me.btnSetWindow.Location = New System.Drawing.Point(384, 379)
        Me.btnSetWindow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetWindow.Name = "btnSetWindow"
        Me.btnSetWindow.Size = New System.Drawing.Size(252, 36)
        Me.btnSetWindow.TabIndex = 37
        Me.btnSetWindow.Text = "ウィンドウ幅に合わせる"
        Me.btnSetWindow.UseVisualStyleBackColor = True
        '
        'btnRotate90
        '
        Me.btnRotate90.Location = New System.Drawing.Point(556, 300)
        Me.btnRotate90.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRotate90.Name = "btnRotate90"
        Me.btnRotate90.Size = New System.Drawing.Size(80, 51)
        Me.btnRotate90.TabIndex = 33
        Me.btnRotate90.Text = "右90度"
        Me.btnRotate90.UseVisualStyleBackColor = True
        '
        'btnRotate0
        '
        Me.btnRotate0.Location = New System.Drawing.Point(460, 265)
        Me.btnRotate0.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRotate0.Name = "btnRotate0"
        Me.btnRotate0.Size = New System.Drawing.Size(91, 51)
        Me.btnRotate0.TabIndex = 34
        Me.btnRotate0.Text = "０度"
        Me.btnRotate0.UseVisualStyleBackColor = True
        '
        'btnRotateM90
        '
        Me.btnRotateM90.Location = New System.Drawing.Point(376, 300)
        Me.btnRotateM90.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRotateM90.Name = "btnRotateM90"
        Me.btnRotateM90.Size = New System.Drawing.Size(79, 51)
        Me.btnRotateM90.TabIndex = 35
        Me.btnRotateM90.Text = "左90度"
        Me.btnRotateM90.UseVisualStyleBackColor = True
        '
        'btnRotate180
        '
        Me.btnRotate180.Location = New System.Drawing.Point(460, 323)
        Me.btnRotate180.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRotate180.Name = "btnRotate180"
        Me.btnRotate180.Size = New System.Drawing.Size(91, 51)
        Me.btnRotate180.TabIndex = 36
        Me.btnRotate180.Text = "180度回転"
        Me.btnRotate180.UseVisualStyleBackColor = True
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(690, 157)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(466, 222)
        Me.AxWindowsMediaPlayer1.TabIndex = 47
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'trackBarSeek
        '
        Me.trackBarSeek.Location = New System.Drawing.Point(369, 509)
        Me.trackBarSeek.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.trackBarSeek.Name = "trackBarSeek"
        Me.trackBarSeek.Size = New System.Drawing.Size(317, 56)
        Me.trackBarSeek.TabIndex = 46
        '
        'GotoFirst
        '
        Me.GotoFirst.Location = New System.Drawing.Point(362, 455)
        Me.GotoFirst.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GotoFirst.Name = "GotoFirst"
        Me.GotoFirst.Size = New System.Drawing.Size(51, 50)
        Me.GotoFirst.TabIndex = 41
        Me.GotoFirst.Text = "先頭"
        Me.GotoFirst.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(550, 455)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(51, 50)
        Me.btnStop.TabIndex = 42
        Me.btnStop.Text = "||"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnFastReverse
        '
        Me.btnFastReverse.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnFastReverse.Location = New System.Drawing.Point(425, 455)
        Me.btnFastReverse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFastReverse.Name = "btnFastReverse"
        Me.btnFastReverse.Size = New System.Drawing.Size(51, 50)
        Me.btnFastReverse.TabIndex = 43
        Me.btnFastReverse.Text = "◀◀"
        Me.btnFastReverse.UseVisualStyleBackColor = True
        '
        'btnFastForward
        '
        Me.btnFastForward.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnFastForward.Location = New System.Drawing.Point(629, 455)
        Me.btnFastForward.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFastForward.Name = "btnFastForward"
        Me.btnFastForward.Size = New System.Drawing.Size(51, 50)
        Me.btnFastForward.TabIndex = 44
        Me.btnFastForward.Text = "▶▶"
        Me.btnFastForward.UseVisualStyleBackColor = True
        '
        'btnStartStop
        '
        Me.btnStartStop.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnStartStop.Location = New System.Drawing.Point(481, 455)
        Me.btnStartStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.Size = New System.Drawing.Size(51, 50)
        Me.btnStartStop.TabIndex = 45
        Me.btnStartStop.Text = "▶"
        Me.btnStartStop.UseVisualStyleBackColor = True
        '
        'lblPage
        '
        Me.lblPage.AutoSize = True
        Me.lblPage.Location = New System.Drawing.Point(837, 691)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(43, 15)
        Me.lblPage.TabIndex = 56
        Me.lblPage.Text = "ページ"
        '
        'btnPreviousHalf
        '
        Me.btnPreviousHalf.Location = New System.Drawing.Point(384, 213)
        Me.btnPreviousHalf.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPreviousHalf.Name = "btnPreviousHalf"
        Me.btnPreviousHalf.Size = New System.Drawing.Size(124, 39)
        Me.btnPreviousHalf.TabIndex = 52
        Me.btnPreviousHalf.Text = "0.5ページ前へ"
        Me.btnPreviousHalf.UseVisualStyleBackColor = True
        '
        'btnNextHalf
        '
        Me.btnNextHalf.Location = New System.Drawing.Point(513, 213)
        Me.btnNextHalf.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNextHalf.Name = "btnNextHalf"
        Me.btnNextHalf.Size = New System.Drawing.Size(123, 39)
        Me.btnNextHalf.TabIndex = 53
        Me.btnNextHalf.Text = "0.5ページ先へ"
        Me.btnNextHalf.UseVisualStyleBackColor = True
        '
        'btnPDFNext
        '
        Me.btnPDFNext.Location = New System.Drawing.Point(553, 168)
        Me.btnPDFNext.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPDFNext.Name = "btnPDFNext"
        Me.btnPDFNext.Size = New System.Drawing.Size(88, 41)
        Me.btnPDFNext.TabIndex = 48
        Me.btnPDFNext.Text = "次へ"
        Me.btnPDFNext.UseVisualStyleBackColor = True
        '
        'btnPDFBack
        '
        Me.btnPDFBack.Location = New System.Drawing.Point(471, 168)
        Me.btnPDFBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPDFBack.Name = "btnPDFBack"
        Me.btnPDFBack.Size = New System.Drawing.Size(80, 41)
        Me.btnPDFBack.TabIndex = 49
        Me.btnPDFBack.Text = "前へ"
        Me.btnPDFBack.UseVisualStyleBackColor = True
        '
        'btnPDFFirst
        '
        Me.btnPDFFirst.Location = New System.Drawing.Point(381, 168)
        Me.btnPDFFirst.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPDFFirst.Name = "btnPDFFirst"
        Me.btnPDFFirst.Size = New System.Drawing.Size(88, 41)
        Me.btnPDFFirst.TabIndex = 50
        Me.btnPDFFirst.Text = "最初へ"
        Me.btnPDFFirst.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(902, 490)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "ページ"
        '
        'pbBack
        '
        Me.pbBack.Location = New System.Drawing.Point(690, 519)
        Me.pbBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbBack.Name = "pbBack"
        Me.pbBack.Size = New System.Drawing.Size(427, 300)
        Me.pbBack.TabIndex = 58
        Me.pbBack.TabStop = False
        '
        'frmOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 649)
        Me.Controls.Add(Me.pbBack)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPage)
        Me.Controls.Add(Me.btnPreviousHalf)
        Me.Controls.Add(Me.btnNextHalf)
        Me.Controls.Add(Me.btnPDFNext)
        Me.Controls.Add(Me.btnPDFBack)
        Me.Controls.Add(Me.btnPDFFirst)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Controls.Add(Me.trackBarSeek)
        Me.Controls.Add(Me.GotoFirst)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnFastReverse)
        Me.Controls.Add(Me.btnFastForward)
        Me.Controls.Add(Me.btnStartStop)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.pbThumbnail)
        Me.Controls.Add(Me.btnSetWindow)
        Me.Controls.Add(Me.btnRotate90)
        Me.Controls.Add(Me.btnRotate0)
        Me.Controls.Add(Me.btnRotateM90)
        Me.Controls.Add(Me.btnRotate180)
        Me.Controls.Add(Me.chkUpdate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnFileAdd)
        Me.Controls.Add(Me.btnDisp)
        Me.Controls.Add(Me.btnUnDisp)
        Me.Controls.Add(Me.btnUnSelect)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lstPDFFiles)
        Me.Controls.Add(Me.txtPDFFileName)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmOperation"
        Me.Text = "PDF Second Monitor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackBarSeek, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents cmbDisplay As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Timer1 As Windows.Forms.Timer
    Friend WithEvents txtPDFFileName As TextBox
    Friend WithEvents lstPDFFiles As ListBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnUnSelect As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents btnFileAdd As Button
    Friend WithEvents btnColorChange As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents lblFormColor As Label
    Friend WithEvents btnDisp As Button
    Friend WithEvents chkUpdate As CheckBox
    Friend WithEvents btnUnDisp As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents pbThumbnail As PictureBox
    Friend WithEvents btnSetWindow As Button
    Friend WithEvents btnRotate90 As Button
    Friend WithEvents btnRotate0 As Button
    Friend WithEvents btnRotateM90 As Button
    Friend WithEvents btnRotate180 As Button
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents trackBarSeek As TrackBar
    Friend WithEvents GotoFirst As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents btnFastReverse As Button
    Friend WithEvents btnFastForward As Button
    Friend WithEvents btnStartStop As Button
    Friend WithEvents lblPage As Label
    Friend WithEvents btnPreviousHalf As Button
    Friend WithEvents btnNextHalf As Button
    Friend WithEvents btnPDFNext As Button
    Friend WithEvents btnPDFBack As Button
    Friend WithEvents btnPDFFirst As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents pbBack As PictureBox
End Class
