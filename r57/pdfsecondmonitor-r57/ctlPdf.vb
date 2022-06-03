Public Class ctlPdf

    Private _dispacher As FormDispacher = FormDispacher.GetInstance

    Private _viewer As frmPdfViewer




#Region "ページ移動"

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnPDFFirst.Click
        _viewer.FirstPage()
        SetImage()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnPDFNext.Click
        _viewer.NextPage()
        SetImage()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnPDFBack.Click
        _viewer.PrePage()
        SetImage()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) 
        'todo
    End Sub
#End Region

    Public Sub ControlEnabled()

        Me.Enabled = Not (_fileViewParam Is Nothing)

    End Sub
    Private _picturebox As PictureBox
    Function GetImage() As Bitmap

        Return _viewer.GetImage()

    End Function

    Private Sub SetImage()
        Dim img = GetImage()
        If img Is Nothing Then
            Exit Sub

        End If
        pbBack.Image = img
        'todo:pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom
    End Sub



    Private _backFileName As String
    Private _fileViewParam As FileViewParam
    Public Sub SetFileInfo(f As FileViewParam)
        Me._fileViewParam = f
        If _fileViewParam Is Nothing Then
            Return
        End If
        _viewer = _dispacher.ShowPdfViewer()
        '_picturebox = _viewer.PictureBox1
        Dim sc = _dispacher.GetScreen().Bounds
        _setwinWidth = New SetWinWidthModule(sc, pbThumbnail, pbBack, VScrollBar1)
        _viewer.OpenFile(f.FileName)
        SetImage()
    End Sub

    Private Sub btnNextHalf_Click(sender As Object, e As EventArgs) Handles btnNextHalf.Click
        _viewer.NextHalfPage()
    End Sub

    Private Sub btnPreviousHalf_Click(sender As Object, e As EventArgs) Handles btnPreviousHalf.Click
        _viewer.PreviousHalfPage()
    End Sub

    Private Function GetSetWinImageHeight() As Integer
        Dim pbSize = _picturebox.Size
        Return CType(pbSize.Height / pbSize.Width * GetImage().Width, Integer)
    End Function


    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll


        _setwinWidth.DispSetWindow()
    End Sub
    Private Sub VScrollBar1Init()
        VScrollBar1.Value = 0
        VScrollBar1.Minimum = 0
        VScrollBar1.Maximum = GetImage().Height

    End Sub
    Private Sub btnSetWindow_Click(sender As Object, e As EventArgs) Handles btnSetWindow.Click
        VScrollBar1Init()
        _setwinWidth.DispSetWindow()
    End Sub

    Private _setwinWidth As SetWinWidthModule

    Friend Sub SetView()
        If pbThumbnail.Image Is Nothing Then
            Exit Sub
        End If
        _dispacher.ShowImage(pbThumbnail.Image)
    End Sub
End Class
