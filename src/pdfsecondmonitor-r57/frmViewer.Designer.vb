<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmViewer
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.VlcControl1 = New Vlc.DotNet.Forms.VlcControl()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(477, 365)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'VlcControl1
        '
        Me.VlcControl1.BackColor = System.Drawing.Color.Black
        Me.VlcControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VlcControl1.Location = New System.Drawing.Point(0, 0)
        Me.VlcControl1.Name = "VlcControl1"
        Me.VlcControl1.Size = New System.Drawing.Size(477, 365)
        Me.VlcControl1.Spu = -1
        Me.VlcControl1.TabIndex = 5
        Me.VlcControl1.Text = "VlcControl1"
        Me.VlcControl1.VlcLibDirectory = Nothing
        Me.VlcControl1.VlcMediaplayerOptions = Nothing
        '
        'frmViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 365)
        Me.ControlBox = False
        Me.Controls.Add(Me.VlcControl1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmViewer"
        Me.Text = "Viewer Screen"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VlcControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents VlcControl1 As Vlc.DotNet.Forms.VlcControl
End Class
