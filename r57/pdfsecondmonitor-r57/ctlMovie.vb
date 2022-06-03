Public Class ctlMovie
    Private _dispacher As FormDispacher = FormDispacher.GetInstance


    Private player As AxWMPLib.AxWindowsMediaPlayer

    Private _fileViewParam As FileViewParam

    Public Sub SetFileInfo(f As FileViewParam)
        Me._fileViewParam = f
        If _fileViewParam Is Nothing Then
            Return
        End If
        player = _dispacher.ShowMovie()

        player.URL = _fileViewParam.FileName
        player.uiMode = "none"
        player.stretchToFit = True
    End Sub

#Region "Media Playerの処理"




    Private Sub btnStartStop_Click(sender As Object, e As EventArgs) Handles btnStartStop.Click
        player.Ctlcontrols.play()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        player.Ctlcontrols.pause()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnFastForward.Click
        player.Ctlcontrols.fastForward()
    End Sub

    Private Sub btnFastReverse_Click(sender As Object, e As EventArgs) Handles btnFastReverse.Click
        player.Ctlcontrols.fastReverse()

    End Sub


    Public Sub ControlEnabled()

        Me.Enabled = Not (_fileViewParam Is Nothing)

    End Sub

    Private Sub GotoFirst_Click(sender As Object, e As EventArgs) Handles GotoFirst.Click
        player.Ctlcontrols.stop()
        player.Ctlcontrols.play()
        player.Ctlcontrols.pause()
    End Sub

    Private trackBarSeek_Scrolled As Boolean = False
    Private Sub Seek(sender As Object, e As EventArgs) Handles Timer1.Tick
        If player Is Nothing Then
            Exit Sub
        End If
        Try
            If trackBarSeek_Scrolled Then
                player.Ctlcontrols.currentPosition = trackBarSeek.Value / 100
                If Not player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                    player.Ctlcontrols.play()
                    player.Ctlcontrols.pause()

                End If
                trackBarSeek_Scrolled = False
            Else
                trackBarSeek.Maximum = CType(player.Ctlcontrols.currentItem.duration * 100, Integer)
                trackBarSeek.Value = CType(player.Ctlcontrols.currentPosition * 100, Integer)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ctlMovie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 100
        Timer1.Start()

    End Sub

    Private Sub trackBarSeek_ValueChanged(sender As Object, e As EventArgs) Handles trackBarSeek.Scroll
        trackBarSeek_Scrolled = True

    End Sub

    Friend Sub SetView()
        Throw New NotImplementedException()
    End Sub






#End Region
End Class
