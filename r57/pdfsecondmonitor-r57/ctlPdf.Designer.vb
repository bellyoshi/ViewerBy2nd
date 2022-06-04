<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlPdf
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPDFNext = New System.Windows.Forms.Button()
        Me.btnPDFBack = New System.Windows.Forms.Button()
        Me.btnPDFFirst = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btnNextHalf = New System.Windows.Forms.Button()
        Me.pbThumbnail = New System.Windows.Forms.PictureBox()
        Me.btnSetWindow = New System.Windows.Forms.Button()
        Me.btnPreviousHalf = New System.Windows.Forms.Button()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.pbBack = New System.Windows.Forms.PictureBox()
        CType(Me.pbThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPDFNext
        '
        Me.btnPDFNext.Location = New System.Drawing.Point(173, 26)
        Me.btnPDFNext.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPDFNext.Name = "btnPDFNext"
        Me.btnPDFNext.Size = New System.Drawing.Size(88, 41)
        Me.btnPDFNext.TabIndex = 24
        Me.btnPDFNext.Text = "次へ"
        Me.btnPDFNext.UseVisualStyleBackColor = True
        '
        'btnPDFBack
        '
        Me.btnPDFBack.Location = New System.Drawing.Point(91, 26)
        Me.btnPDFBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPDFBack.Name = "btnPDFBack"
        Me.btnPDFBack.Size = New System.Drawing.Size(80, 41)
        Me.btnPDFBack.TabIndex = 25
        Me.btnPDFBack.Text = "前へ"
        Me.btnPDFBack.UseVisualStyleBackColor = True
        '
        'btnPDFFirst
        '
        Me.btnPDFFirst.Location = New System.Drawing.Point(1, 26)
        Me.btnPDFFirst.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPDFFirst.Name = "btnPDFFirst"
        Me.btnPDFFirst.Size = New System.Drawing.Size(88, 41)
        Me.btnPDFFirst.TabIndex = 27
        Me.btnPDFFirst.Text = "最初へ"
        Me.btnPDFFirst.UseVisualStyleBackColor = True
        '
        'btnNextHalf
        '
        Me.btnNextHalf.Location = New System.Drawing.Point(132, 114)
        Me.btnNextHalf.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNextHalf.Name = "btnNextHalf"
        Me.btnNextHalf.Size = New System.Drawing.Size(123, 39)
        Me.btnNextHalf.TabIndex = 28
        Me.btnNextHalf.Text = "0.5ページ先へ"
        Me.btnNextHalf.UseVisualStyleBackColor = True
        '
        'pbThumbnail
        '
        Me.pbThumbnail.Location = New System.Drawing.Point(267, 26)
        Me.pbThumbnail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbThumbnail.Name = "pbThumbnail"
        Me.pbThumbnail.Size = New System.Drawing.Size(427, 300)
        Me.pbThumbnail.TabIndex = 29
        Me.pbThumbnail.TabStop = False
        '
        'btnSetWindow
        '
        Me.btnSetWindow.Location = New System.Drawing.Point(3, 72)
        Me.btnSetWindow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetWindow.Name = "btnSetWindow"
        Me.btnSetWindow.Size = New System.Drawing.Size(258, 36)
        Me.btnSetWindow.TabIndex = 28
        Me.btnSetWindow.Text = "ウィンドウ幅に合わせる"
        Me.btnSetWindow.UseVisualStyleBackColor = True
        '
        'btnPreviousHalf
        '
        Me.btnPreviousHalf.Location = New System.Drawing.Point(3, 114)
        Me.btnPreviousHalf.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPreviousHalf.Name = "btnPreviousHalf"
        Me.btnPreviousHalf.Size = New System.Drawing.Size(124, 39)
        Me.btnPreviousHalf.TabIndex = 28
        Me.btnPreviousHalf.Text = "0.5ページ前へ"
        Me.btnPreviousHalf.UseVisualStyleBackColor = True
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(696, 26)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(23, 300)
        Me.VScrollBar1.TabIndex = 32
        '
        'pbBack
        '
        Me.pbBack.Location = New System.Drawing.Point(34, 330)
        Me.pbBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbBack.Name = "pbBack"
        Me.pbBack.Size = New System.Drawing.Size(427, 300)
        Me.pbBack.TabIndex = 29
        Me.pbBack.TabStop = False
        '
        'ctlPdf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.pbBack)
        Me.Controls.Add(Me.pbThumbnail)
        Me.Controls.Add(Me.btnSetWindow)
        Me.Controls.Add(Me.btnPreviousHalf)
        Me.Controls.Add(Me.btnNextHalf)
        Me.Controls.Add(Me.btnPDFNext)
        Me.Controls.Add(Me.btnPDFBack)
        Me.Controls.Add(Me.btnPDFFirst)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ctlPdf"
        Me.Size = New System.Drawing.Size(796, 501)
        CType(Me.pbThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPDFNext As Button
    Friend WithEvents btnPDFBack As Button
    Friend WithEvents btnPDFFirst As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnNextHalf As Button
    Friend WithEvents pbThumbnail As PictureBox
    Friend WithEvents btnSetWindow As Button
    Friend WithEvents btnPreviousHalf As Button
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents pbBack As PictureBox
End Class
