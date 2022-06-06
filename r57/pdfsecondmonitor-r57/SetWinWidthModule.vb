'ウインドウ幅に合わせる機能の提供
Public Class SetWinWidthModule

    Private pbThumb As PictureBox
    Private disp As Rectangle
    Private pbBack As PictureBox
    Private scrollBar As VScrollBar

    Public Sub New(disp As Rectangle, thum As PictureBox, back As PictureBox, scroll As VScrollBar)
        pbThumb = thum
        pbBack = back
        scrollBar = scroll
        Me.disp = disp
    End Sub

    Private ReadOnly Property Image As Bitmap
        Get
            Return New Bitmap(pbBack.Image)
        End Get
    End Property

    Public Function CanSetWindowWidthRate(imageSize As Size, pictureBoxSize As Size) As Boolean
        Dim imageRate = GetWidthHeightRate(imageSize)
        Dim pbRate = GetWidthHeightRate(pictureBoxSize)
        If imageRate > pbRate Then
            Return False
        End If
        Return True
    End Function
    Private Function GetWidthHeightRate(ByVal size As Size) As Double
        Return size.Width / size.Height
    End Function

    Public Sub DispSetWindow()
        If Image Is Nothing Then
            Exit Sub
        End If
        If Not CanSetWindowWidthRate(Image.Size, disp.Size) Then
            Exit Sub
        End If

        Dim ImageY As Integer
        If scrollBar.Value + GetSetWinImageHeight() > Image.Height Then
            ImageY = CType(Image.Height - GetSetWinImageHeight(), Integer)
        Else
            ImageY = scrollBar.Value
        End If
        Dim rect = New Rectangle(0, ImageY, Image.Width, GetSetWinImageHeight())
        Dim bmpNew As Bitmap = Image.Clone(rect, Image.PixelFormat)
        pbThumb.Image = bmpNew
        pbThumb.SizeMode = PictureBoxSizeMode.Zoom
    End Sub
    Private Function GetSetWinImageHeight() As Integer
        Dim pbSize = disp.Size
        Return CType(pbSize.Height / pbSize.Width * Image.Width, Integer)
    End Function

End Class
