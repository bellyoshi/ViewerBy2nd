Public Class ctlPdf

    Private _dispacher As FormDispacher = FormDispacher.GetInstance

    Private _viewer As frmPdfViewer




#Region "ページ移動"

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnPDFFirst.Click
        _viewer.FirstPage()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnPDFNext.Click
        _viewer.NextPage()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnPDFBack.Click
        _viewer.PrePage()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) 
        'todo
    End Sub
#End Region

    Public Sub ControlEnabled()

        Me.Enabled = Not (_fileViewParam Is Nothing)

    End Sub



    Private _backFileName As String
    Private _fileViewParam As FileViewParam
    Public Sub SetFileInfo(f As FileViewParam)
        Me._fileViewParam = f
        If _fileViewParam Is Nothing Then
            Return
        End If
        _viewer = _dispacher.ShowPdfViewer()
        _viewer.OpenFile(f.FileName)
    End Sub

    Private Sub btnNextHalf_Click(sender As Object, e As EventArgs) Handles btnNextHalf.Click
        _viewer.NextHalfPage()
    End Sub

    Private Sub btnPreviousHalf_Click(sender As Object, e As EventArgs) Handles btnPreviousHalf.Click
        _viewer.PreviousHalfPage()
    End Sub
End Class
