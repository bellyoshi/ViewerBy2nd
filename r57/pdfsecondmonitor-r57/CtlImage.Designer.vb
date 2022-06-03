<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlImage
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
        Me.btnRotate180 = New System.Windows.Forms.Button()
        Me.btnRotateM90 = New System.Windows.Forms.Button()
        Me.btnRotate90 = New System.Windows.Forms.Button()
        Me.btnRotate0 = New System.Windows.Forms.Button()
        Me.btnSetWindow = New System.Windows.Forms.Button()
        Me.pbThumbnail = New System.Windows.Forms.PictureBox()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.pbBack = New System.Windows.Forms.PictureBox()
        CType(Me.pbThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRotate180
        '
        Me.btnRotate180.Location = New System.Drawing.Point(88, 79)
        Me.btnRotate180.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRotate180.Name = "btnRotate180"
        Me.btnRotate180.Size = New System.Drawing.Size(91, 51)
        Me.btnRotate180.TabIndex = 0
        Me.btnRotate180.Text = "180度回転"
        Me.btnRotate180.UseVisualStyleBackColor = True
        '
        'btnRotateM90
        '
        Me.btnRotateM90.Location = New System.Drawing.Point(4, 56)
        Me.btnRotateM90.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRotateM90.Name = "btnRotateM90"
        Me.btnRotateM90.Size = New System.Drawing.Size(79, 51)
        Me.btnRotateM90.TabIndex = 0
        Me.btnRotateM90.Text = "左90度"
        Me.btnRotateM90.UseVisualStyleBackColor = True
        '
        'btnRotate90
        '
        Me.btnRotate90.Location = New System.Drawing.Point(184, 56)
        Me.btnRotate90.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRotate90.Name = "btnRotate90"
        Me.btnRotate90.Size = New System.Drawing.Size(80, 51)
        Me.btnRotate90.TabIndex = 0
        Me.btnRotate90.Text = "右90度"
        Me.btnRotate90.UseVisualStyleBackColor = True
        '
        'btnRotate0
        '
        Me.btnRotate0.Location = New System.Drawing.Point(88, 21)
        Me.btnRotate0.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRotate0.Name = "btnRotate0"
        Me.btnRotate0.Size = New System.Drawing.Size(91, 51)
        Me.btnRotate0.TabIndex = 0
        Me.btnRotate0.Text = "０度"
        Me.btnRotate0.UseVisualStyleBackColor = True
        '
        'btnSetWindow
        '
        Me.btnSetWindow.Location = New System.Drawing.Point(12, 135)
        Me.btnSetWindow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetWindow.Name = "btnSetWindow"
        Me.btnSetWindow.Size = New System.Drawing.Size(252, 36)
        Me.btnSetWindow.TabIndex = 29
        Me.btnSetWindow.Text = "ウィンドウ幅に合わせる"
        Me.btnSetWindow.UseVisualStyleBackColor = True
        '
        'pbThumbnail
        '
        Me.pbThumbnail.Location = New System.Drawing.Point(269, 21)
        Me.pbThumbnail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbThumbnail.Name = "pbThumbnail"
        Me.pbThumbnail.Size = New System.Drawing.Size(427, 300)
        Me.pbThumbnail.TabIndex = 30
        Me.pbThumbnail.TabStop = False
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(699, 21)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(23, 300)
        Me.VScrollBar1.TabIndex = 31
        '
        'pbBack
        '
        Me.pbBack.Location = New System.Drawing.Point(23, 379)
        Me.pbBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbBack.Name = "pbBack"
        Me.pbBack.Size = New System.Drawing.Size(427, 300)
        Me.pbBack.TabIndex = 30
        Me.pbBack.TabStop = False
        '
        'CtlImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.pbBack)
        Me.Controls.Add(Me.pbThumbnail)
        Me.Controls.Add(Me.btnSetWindow)
        Me.Controls.Add(Me.btnRotate90)
        Me.Controls.Add(Me.btnRotate0)
        Me.Controls.Add(Me.btnRotateM90)
        Me.Controls.Add(Me.btnRotate180)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "CtlImage"
        Me.Size = New System.Drawing.Size(801, 426)
        CType(Me.pbThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnRotate180 As Button
    Friend WithEvents btnRotateM90 As Button
    Friend WithEvents btnRotate90 As Button
    Friend WithEvents btnRotate0 As Button
    Friend WithEvents btnSetWindow As Button
    Friend WithEvents pbThumbnail As PictureBox
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents pbBack As PictureBox
End Class
