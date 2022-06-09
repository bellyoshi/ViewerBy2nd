<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlMovie
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlMovie))
        Me.GotoFirst = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnFastReverse = New System.Windows.Forms.Button()
        Me.btnFastForward = New System.Windows.Forms.Button()
        Me.btnStartStop = New System.Windows.Forms.Button()
        Me.trackBarSeek = New System.Windows.Forms.TrackBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.trackBarSeek, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GotoFirst
        '
        Me.GotoFirst.Location = New System.Drawing.Point(57, 48)
        Me.GotoFirst.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GotoFirst.Name = "GotoFirst"
        Me.GotoFirst.Size = New System.Drawing.Size(51, 50)
        Me.GotoFirst.TabIndex = 12
        Me.GotoFirst.Text = "先頭"
        Me.GotoFirst.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(245, 48)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(51, 50)
        Me.btnStop.TabIndex = 13
        Me.btnStop.Text = "||"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnFastReverse
        '
        Me.btnFastReverse.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnFastReverse.Location = New System.Drawing.Point(120, 48)
        Me.btnFastReverse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFastReverse.Name = "btnFastReverse"
        Me.btnFastReverse.Size = New System.Drawing.Size(51, 50)
        Me.btnFastReverse.TabIndex = 14
        Me.btnFastReverse.Text = "◀◀"
        Me.btnFastReverse.UseVisualStyleBackColor = True
        '
        'btnFastForward
        '
        Me.btnFastForward.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnFastForward.Location = New System.Drawing.Point(324, 48)
        Me.btnFastForward.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFastForward.Name = "btnFastForward"
        Me.btnFastForward.Size = New System.Drawing.Size(51, 50)
        Me.btnFastForward.TabIndex = 15
        Me.btnFastForward.Text = "▶▶"
        Me.btnFastForward.UseVisualStyleBackColor = True
        '
        'btnStartStop
        '
        Me.btnStartStop.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnStartStop.Location = New System.Drawing.Point(176, 48)
        Me.btnStartStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.Size = New System.Drawing.Size(51, 50)
        Me.btnStartStop.TabIndex = 16
        Me.btnStartStop.Text = "▶"
        Me.btnStartStop.UseVisualStyleBackColor = True
        '
        'trackBarSeek
        '
        Me.trackBarSeek.Location = New System.Drawing.Point(57, 110)
        Me.trackBarSeek.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.trackBarSeek.Name = "trackBarSeek"
        Me.trackBarSeek.Size = New System.Drawing.Size(317, 56)
        Me.trackBarSeek.TabIndex = 17
        '
        'Timer1
        '
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(394, 48)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(466, 222)
        Me.AxWindowsMediaPlayer1.TabIndex = 18
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'ctlMovie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Controls.Add(Me.trackBarSeek)
        Me.Controls.Add(Me.GotoFirst)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnFastReverse)
        Me.Controls.Add(Me.btnFastForward)
        Me.Controls.Add(Me.btnStartStop)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ctlMovie"
        Me.Size = New System.Drawing.Size(927, 390)
        CType(Me.trackBarSeek, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GotoFirst As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents btnFastReverse As Button
    Friend WithEvents btnFastForward As Button
    Friend WithEvents btnStartStop As Button
    Friend WithEvents trackBarSeek As TrackBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
End Class
