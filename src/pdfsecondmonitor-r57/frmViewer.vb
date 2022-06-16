Public Class frmViewer
    Private Sub frmMovieViewer_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            VideoPlayer1.Pause()

        End If
    End Sub


    Public Sub frmOperation_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        Dim dispacher = FormDispacher.GetInstance()
        dispacher.frmOperation_MouseWheel(sender, e)
    End Sub
End Class
