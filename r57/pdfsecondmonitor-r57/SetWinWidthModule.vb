'ウインドウ幅に合わせる機能の提供
Public Class SetWinWidthModule

    Private pbDisp As PictureBox
    Private pbThumbnail As PictureBox
    Private scrollBar As VScrollBar

    Public Sub New(disp As PictureBox, thumb As PictureBox, scroll As VScrollBar)
        pbDisp = disp
        pbThumbnail = thumb
        scrollBar = scroll
    End Sub

    Private ReadOnly Property Image As Bitmap
        Get
            Return pbThumbnail.Image
        End Get
    End Property

    Public Function CanSetWindowWidthRate(imageSize, pictureBoxSize) As Boolean
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
        If Not CanSetWindowWidthRate(Image.Size, pbDisp.Size) Then
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
        pbDisp.Image = bmpNew
        pbDisp.SizeMode = PictureBoxSizeMode.Zoom
    End Sub
    Private Function GetSetWinImageHeight() As Integer
        Dim pbSize = pbDisp.Size
        Return CType(pbSize.Height / pbSize.Width * Image.Width, Integer)
    End Function

End Class
