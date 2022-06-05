Public Class frmViewer
    Private Sub frmMovieViewer_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
        End If
    End Sub
End Class
