Public Class frmViewer
    Private Sub frmMovieViewer_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            VlcControl1.Stop()
        End If
    End Sub

    Private Sub VlcControl1_VlcLibDirectoryNeeded(sender As Object, e As Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs) Handles VlcControl1.VlcLibDirectoryNeeded
        e.VlcLibDirectory = ViewerBy2ndLib.VLCDirectoryGetter.GetVlcLibDirectory()
    End Sub
End Class
