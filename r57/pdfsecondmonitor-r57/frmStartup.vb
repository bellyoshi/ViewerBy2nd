Public Class frmStartup

    Private _dispacher As FormDispacher = FormDispacher.GetInstance
    Private Sub fmStartup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dispacher.SetStartup(Me)
        _dispacher.ShowPdfViewer()
        _dispacher.ShowOperation()

    End Sub

End Class