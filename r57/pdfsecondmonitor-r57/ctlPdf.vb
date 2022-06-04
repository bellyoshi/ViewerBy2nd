Imports PdfiumViewer

Public Class ctlPdf


    Private _dispacher As FormDispacher = FormDispacher.GetInstance

    Private _chkupdate As Boolean
    Public Property chkUpdate As Boolean
        Get
            Return _chkupdate
        End Get
        Set(value As Boolean)
            _chkupdate = value
            UpdateImage()
        End Set
    End Property

    Public Sub UpdateImage()
        If _chkupdate Then
            SetView()
        End If
    End Sub

    Dim pdfDoc As PdfDocument
    Dim page As Integer = 0
    Public Sub OpenFile(fileName As String)
        isHalf = False
        pdfDoc = PdfDocument.Load(fileName)
        FirstPage()
    End Sub

    Public Sub FirstPage()

        isHalf = False
        page = 0
        DisplayPage()
    End Sub

    Public Sub NextPage()
        isHalf = False
        If page < pdfDoc.PageCount - 1 Then
            page += 1
            DisplayPage()
        End If
    End Sub

    Public Sub PrePage()
        isHalf = False
        If 0 < page Then
            page -= 1
            DisplayPage()
        End If
    End Sub

    Private buttomInPage As Decimal
    Private _isHalf As Boolean
    Public Property isHalf As Boolean
        Set(value As Boolean)
            _isHalf = value
            If Not _isHalf Then
                buttomInPage = 0.0D
            End If
        End Set
        Get
            Return _isHalf
        End Get
    End Property
    Public Sub NextHalfPage()



        buttomInPage += 0.5D
        If buttomInPage = 1.5D Then
            NextPage()
            buttomInPage = 0.5D
        End If
        isHalf = True
        DisplayHalfPage()
    End Sub

    Public Sub PreviousHalfPage()

        'If Not isHalf Then
        '    page -= 1
        'End If
        If page = 0D AndAlso buttomInPage <= 0.5D Then
            Exit Sub
        End If
        buttomInPage -= 0.5D
        If buttomInPage <= 0.0D Then
            buttomInPage = 1D
            page -= 1

        End If
        isHalf = True
        DisplayHalfPage()
    End Sub

    Private Sub DisplayHalfPage()
        If (page >= pdfDoc.PageCount) OrElse (page < 0) Then
            Return
        End If
        Dim pdfSize = pdfDoc.PageSizes(page)
        Dim sourceSize As New SizeF
        sourceSize.Height = pdfSize.Height / 2
        sourceSize.Width = pdfSize.Width
        Dim renderSize As Size? = GetRenderSize(sourceSize)
        If renderSize Is Nothing Then
            Return
        End If
        Dim r = renderSize.Value
        r.Height *= 2
        RenderHalf(r)
    End Sub

    Private Sub RenderHalf(renderSize As Size)
        Dim height = renderSize.Height \ 2
        Dim width = renderSize.Width
        Dim canvas As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(canvas)
            Dim img = GetImage(renderSize)
            Dim y = CType(renderSize.Height * (buttomInPage - 0.5), Integer)
            Dim srcRect As New Rectangle(0, y, width, height)
            Dim desRect As New Rectangle(0, 0, srcRect.Width, srcRect.Height)
            g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel)
        End Using
        Image = canvas
    End Sub
    Private Function GetImage(renderSize As Size) As Image
        Return pdfDoc.Render(page, renderSize.Width, renderSize.Height, 96, 96, False)
    End Function

    Private _image As Image
    Public Property Image As Image
        Get
            Return _image
        End Get
        Set(value As Image)
            _image = value
            pbThumbnail.Image = _image
            pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom
            UpdateImage()
        End Set
    End Property

    Public Function GetBmp() As Bitmap
        If Image Is Nothing Then
            Return New Bitmap(0, 0)
        End If
        Dim img As New Bitmap(Image)
        Return img
    End Function

    Private Sub DisplayPage()
        If (page >= pdfDoc.PageCount) Then
            Return
        End If
        Dim sourceSize = pdfDoc.PageSizes(page)
        Dim renderSize As Size? = GetRenderSize(sourceSize)
        If renderSize Is Nothing Then
            Return
        End If
        Image = GetImage(renderSize.Value)
    End Sub



    Private Function GetRenderSize(pdfSize As SizeF) As Size?
        Dim bound = _dispacher.GetScreen().Bounds
        Dim renderSize = New Size(bound.Size)
        Dim pdfWdivH = pdfSize.Width / pdfSize.Height ' // pdfの縦横比
        Dim boxWdivH = bound.Width / bound.Height '  // コントロールの縦横比
        If (boxWdivH > 10) Then ' 落ちないよう
            Return Nothing
        End If
        If (pdfWdivH < boxWdivH) Then
            ' フォーム内にImageを当てはめる判定                    {
            renderSize.Width = bound.Height * pdfWdivH
        Else
            renderSize.Height = bound.Width / pdfWdivH
        End If
        Return renderSize
    End Function




#Region "ページ移動"

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnPDFFirst.Click
        FirstPage()
        SetImage()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnPDFNext.Click
        NextPage()
        SetImage()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnPDFBack.Click
        PrePage()
        SetImage()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs)
        'todo
    End Sub
#End Region

    Public Sub ControlEnabled()

        Me.Enabled = Not (_fileViewParam Is Nothing)

    End Sub



    Private Sub SetImage()
        Dim img = GetBmp()
        If img Is Nothing Then
            Exit Sub

        End If
        pbBack.Image = img
        pbThumbnail.Image = pbBack.Image
        pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom
        lblPage.Text = "ページ" & page + 1 & "/" & pdfDoc.PageCount
    End Sub



    Private _backFileName As String
    Private _fileViewParam As FileViewParam
    Public Sub SetFileInfo(f As FileViewParam)
        Me._fileViewParam = f
        If _fileViewParam Is Nothing Then
            Return
        End If

        Dim sc = _dispacher.GetScreen().Bounds

        OpenFile(f.FileName)
        SetImage()
        _setwinWidth = New SetWinWidthModule(sc, pbThumbnail, pbBack, VScrollBar1)
        UpdateImage()
    End Sub

    Private Sub btnNextHalf_Click(sender As Object, e As EventArgs) Handles btnNextHalf.Click
        NextHalfPage()
        SetImage()
    End Sub

    Private Sub btnPreviousHalf_Click(sender As Object, e As EventArgs) Handles btnPreviousHalf.Click
        PreviousHalfPage()
        SetImage()
    End Sub



    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll


        _setwinWidth.DispSetWindow()
        UpdateImage()
    End Sub
    Private Sub VScrollBar1Init()
        VScrollBar1.Value = 0
        VScrollBar1.Minimum = 0
        VScrollBar1.Maximum = GetBmp().Height

    End Sub
    Private Sub btnSetWindow_Click(sender As Object, e As EventArgs) Handles btnSetWindow.Click
        VScrollBar1Init()
        _setwinWidth.DispSetWindow()
        UpdateImage()
    End Sub

    Private _setwinWidth As SetWinWidthModule

    Friend Sub SetView()
        If pbThumbnail.Image Is Nothing Then
            Exit Sub
        End If
        _dispacher.ShowImage(pbThumbnail.Image)
    End Sub
End Class
