﻿Public Class CtlImage

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
            imageH = bmp.Height
            ImageW = bmp.Width
        Else
            imageH = bmp.Height
            ImageW = bmp.Width
        End If
    End Sub
    Private imageH As Integer
    Private ImageW As Integer



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

    Private isSetWindow = False

    Private Sub btnSetWindow_Click(sender As Object, e As EventArgs) Handles btnSetWindow.Click
        isSetWindow = True
        VScrollBar1Init()
        DispSetWindow()
    End Sub

    Private Sub VScrollBar1Init()
        VScrollBar1.Value = 0
        VScrollBar1.Minimum = 0
        VScrollBar1.Maximum = Image.Height

    End Sub


    Private Function GetSetWinImageHeight() As Double
        Dim pbSize = _pictureBox.Size
        Return pbSize.Height / pbSize.Width * ImageW
    End Function

    Private Sub DispSetWindow()
        If Image Is Nothing Then
            Exit Sub
        End If
        Dim ImageY As Integer
        If VScrollBar1.Value + GetSetWinImageHeight() > imageH Then
            ImageY = imageH - GetSetWinImageHeight()
        Else
            ImageY = VScrollBar1.Value
        End If
        Dim rect = New Rectangle(0, ImageY, ImageW, GetSetWinImageHeight())
        Dim bmpNew As Bitmap = Image.Clone(rect, Image.PixelFormat)
        _pictureBox.Image = bmpNew




    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll


        DispSetWindow()
    End Sub
End Class
