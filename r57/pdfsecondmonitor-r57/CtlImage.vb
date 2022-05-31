Public Class CtlImage

    Private _dispacher As FormDispacher = FormDispacher.GetInstance

    Private _pictureBox As PictureBox

    Private _image As Bitmap
    Property Image As Bitmap
        Get
            Return _image
        End Get
        Set(value As Bitmap)
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
    End Sub

    Private Sub btnRotate_Click(sender As Object, e As EventArgs) Handles btnRotate180.Click
        Rotate(RotateFlipType.Rotate180FlipNone)
    End Sub

    Private Sub btnRotate90_Click(sender As Object, e As EventArgs) Handles btnRotate90.Click
        Rotate(RotateFlipType.Rotate90FlipNone)
    End Sub

    Private Sub btnRotate0_Click(sender As Object, e As EventArgs) Handles btnRotate0.Click
        Rotate(RotateFlipType.RotateNoneFlipNone)
    End Sub

    Private Sub btnRotate270_Click(sender As Object, e As EventArgs) Handles btnRotateM90.Click
        Rotate(RotateFlipType.Rotate270FlipNone)
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

    Private isSetWindow = False
    Private ImageY = 0

    Private Sub btnSetWindow_Click(sender As Object, e As EventArgs) Handles btnSetWindow.Click
        isSetWindow = True
        ImageY = 0
        DispSetWindow()
    End Sub

    Private Sub DispSetWindow()
        Dim pbSize = _pictureBox.Size
        Dim rect = New Rectangle(0, ImageY, Image.Width, pbSize.Height / pbSize.Width * Image.Width)
        Dim bmpNew As Bitmap = Image.Clone(rect, Image.PixelFormat)
        _pictureBox.Image = bmpNew

    End Sub


End Class
