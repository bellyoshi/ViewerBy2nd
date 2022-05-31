Public Class CtlImage

    Private _dispacher As FormDispacher = FormDispacher.GetInstance

    Private _pictureBox As PictureBox

    Private _image As Bitmap
    Property Image As Bitmap
        Get
            Return _image
        End Get
        Set(value As Bitmap)
            If value Is Nothing Then
                Exit Property

            End If
            _image = value
            _pictureBox.Image = _image
            pbThumbnail.Image = _image
            pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom
        End Set
    End Property

    Public Sub SetColor()
        pbThumbnail.BackColor = My.Settings.formColor
    End Sub

    Private Sub Rotate(flip As RotateFlipType)
        Dim bmp As Bitmap = New Bitmap(_fileViewParam.FileName)
        bmp.RotateFlip(flip)
        Image = bmp
        If flip = RotateFlipType.Rotate180FlipNone OrElse
                flip = RotateFlipType.RotateNoneFlipNone Then
        End If
    End Sub




    Private Sub btnRotate_Click(sender As Object, e As EventArgs) Handles btnRotate180.Click
        Rotate(RotateFlipType.Rotate180FlipNone)
        VScrollBar1Init()
    End Sub

    Private Sub btnRotate90_Click(sender As Object, e As EventArgs) Handles btnRotate90.Click
        Rotate(RotateFlipType.Rotate90FlipNone)
        VScrollBar1Init()
    End Sub

    Private Sub btnRotate0_Click(sender As Object, e As EventArgs) Handles btnRotate0.Click
        Rotate(RotateFlipType.RotateNoneFlipNone)
        VScrollBar1Init()
    End Sub

    Private Sub btnRotate270_Click(sender As Object, e As EventArgs) Handles btnRotateM90.Click
        Rotate(RotateFlipType.Rotate270FlipNone)
        VScrollBar1Init()
    End Sub

    Private _fileViewParam As FileViewParam

    Public Sub SetFileInfo(f As FileViewParam)
        Me._fileViewParam = f
        If f Is Nothing Then
            Return
        End If
        _pictureBox = _dispacher.ShowImage()
        Rotate(RotateFlipType.RotateNoneFlipNone)
        _pictureBox.SizeMode = PictureBoxSizeMode.Zoom 'サイズ調整


    End Sub

    Public Sub ControlEnabled()

        Me.Enabled = Not (_fileViewParam Is Nothing)

    End Sub


    Private Sub btnSetWindow_Click(sender As Object, e As EventArgs) Handles btnSetWindow.Click

        VScrollBar1Init()
        DispSetWindow()
    End Sub

    Private Sub VScrollBar1Init()
        VScrollBar1.Value = 0
        VScrollBar1.Minimum = 0
        VScrollBar1.Maximum = Image.Height

    End Sub


    Private Function GetSetWinImageHeight() As Integer
        Dim pbSize = _pictureBox.Size
        Return CType(pbSize.Height / pbSize.Width * Image.Width, Integer)
    End Function

    Private Sub DispSetWindow()
        If Image Is Nothing Then
            Exit Sub
        End If
        Dim ImageY As Integer
        If VScrollBar1.Value + GetSetWinImageHeight() > Image.Height Then
            ImageY = CType(Image.Height - GetSetWinImageHeight(), Integer)
        Else
            ImageY = VScrollBar1.Value
        End If
        Dim rect = New Rectangle(0, ImageY, Image.Width, GetSetWinImageHeight())
        Dim bmpNew As Bitmap = Image.Clone(rect, Image.PixelFormat)
        _pictureBox.Image = bmpNew




    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll


        DispSetWindow()
    End Sub
End Class
