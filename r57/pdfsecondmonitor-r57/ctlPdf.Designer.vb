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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSetWindow = New System.Windows.Forms.Button()
        Me.btnPreviousHalf = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPDFNext
        '
        Me.btnPDFNext.Location = New System.Drawing.Point(125, 21)
        Me.btnPDFNext.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPDFNext.Name = "btnPDFNext"
        Me.btnPDFNext.Size = New System.Drawing.Size(66, 33)
        Me.btnPDFNext.TabIndex = 24
        Me.btnPDFNext.Text = "次へ"
        Me.btnPDFNext.UseVisualStyleBackColor = True
        '
        'btnPDFBack
        '
        Me.btnPDFBack.Location = New System.Drawing.Point(65, 21)
        Me.btnPDFBack.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPDFBack.Name = "btnPDFBack"
        Me.btnPDFBack.Size = New System.Drawing.Size(66, 33)
        Me.btnPDFBack.TabIndex = 25
        Me.btnPDFBack.Text = "前へ"
        Me.btnPDFBack.UseVisualStyleBackColor = True
        '
        'btnPDFFirst
        '
        Me.btnPDFFirst.Location = New System.Drawing.Point(1, 21)
        Me.btnPDFFirst.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPDFFirst.Name = "btnPDFFirst"
        Me.btnPDFFirst.Size = New System.Drawing.Size(66, 33)
        Me.btnPDFFirst.TabIndex = 27
        Me.btnPDFFirst.Text = "最初へ"
        Me.btnPDFFirst.UseVisualStyleBackColor = True
        '
        'btnNextHalf
        '
        Me.btnNextHalf.Location = New System.Drawing.Point(99, 91)
        Me.btnNextHalf.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnNextHalf.Name = "btnNextHalf"
        Me.btnNextHalf.Size = New System.Drawing.Size(92, 31)
        Me.btnNextHalf.TabIndex = 28
        Me.btnNextHalf.Text = "0.5ページ先へ"
        Me.btnNextHalf.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(195, 21)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 240)
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'btnSetWindow
        '
        Me.btnSetWindow.Location = New System.Drawing.Point(2, 58)
        Me.btnSetWindow.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSetWindow.Name = "btnSetWindow"
        Me.btnSetWindow.Size = New System.Drawing.Size(189, 29)
        Me.btnSetWindow.TabIndex = 28
        Me.btnSetWindow.Text = "ウィンドウ幅に合わせる"
        Me.btnSetWindow.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.btnPreviousHalf.Location = New System.Drawing.Point(2, 91)
        Me.btnPreviousHalf.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPreviousHalf.Name = "Button1"
        Me.btnPreviousHalf.Size = New System.Drawing.Size(93, 31)
        Me.btnPreviousHalf.TabIndex = 28
        Me.btnPreviousHalf.Text = "0.5ページ前へ"
        Me.btnPreviousHalf.UseVisualStyleBackColor = True
        '
        'ctlPdf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnSetWindow)
        Me.Controls.Add(Me.btnPreviousHalf)
        Me.Controls.Add(Me.btnNextHalf)
        Me.Controls.Add(Me.btnPDFNext)
        Me.Controls.Add(Me.btnPDFBack)
        Me.Controls.Add(Me.btnPDFFirst)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "ctlPdf"
        Me.Size = New System.Drawing.Size(597, 326)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPDFNext As Button
    Friend WithEvents btnPDFBack As Button
    Friend WithEvents btnPDFFirst As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnNextHalf As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnSetWindow As Button
    Friend WithEvents btnPreviousHalf As Button
End Class
