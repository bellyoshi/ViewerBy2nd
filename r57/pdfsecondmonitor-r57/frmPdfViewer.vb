Imports PdfiumViewer
Public Class frmPdfViewer

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
        DispImage(canvas)
    End Sub
    Private Function GetImage(renderSize As Size) As Image
        Return pdfDoc.Render(page, renderSize.Width, renderSize.Height, 96, 96, False)
    End Function

    Private _image As Image
    Public Function GetImage() As Bitmap
        If _image Is Nothing Then
            Return New Bitmap(0, 0)
        End If
        Dim img As New Bitmap(_image)
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
        Render(renderSize.Value)
    End Sub

    Private Function GetRenderSize(pdfSize As SizeF) As Size?
        Dim renderSize = New Size(PictureBox1.Size.Width, PictureBox1.Size.Height)
        Dim pdfWdivH = pdfSize.Width / pdfSize.Height ' // pdfの縦横比
        Dim boxWdivH = PictureBox1.Width / PictureBox1.Height '  // コントロールの縦横比
        If (boxWdivH > 10) Then ' 落ちないよう
            Return Nothing
        End If
        If (pdfWdivH < boxWdivH) Then
            ' フォーム内にImageを当てはめる判定                    {
            renderSize.Width = CType(PictureBox1.Height * pdfWdivH, Integer)
        Else
            renderSize.Height = CType(PictureBox1.Width / pdfWdivH, Integer)
        End If
        Return renderSize
    End Function

    Private Sub Render(renderSize As Size)
        Dim img = GetImage(renderSize)

        DispImage(img)
    End Sub

    Private Sub DispImage(img As Image)
        _image = img
        Dim oldImage = PictureBox1.Image
        PictureBox1.Image = img
        If oldImage IsNot Nothing Then
            oldImage.Dispose() ';  // メモリー節約
        End If

    End Sub

End Class