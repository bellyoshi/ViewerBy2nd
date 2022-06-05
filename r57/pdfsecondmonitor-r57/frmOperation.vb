Imports ViewerBy2ndLib

Public Class frmOperation
#Region "サポートするファイルの種類"



#End Region

#Region "初期処理"

    Private Sub ControlEnable()
        CtlPdf1ControlEnabled()
        CtlMovie1ControlEnabled()
        CtlImage1ControlEnabled()
    End Sub

    Public Sub CtlPdf1ControlEnabled()

        Dim isEnabled = MyFileType.IsPDFExt()
        btnPDFFirst.Enabled = isEnabled
        btnPDFBack.Enabled = isEnabled
        btnPDFNext.Enabled = isEnabled

        btnPreviousHalf.Enabled = isEnabled
        btnNextHalf.Enabled = isEnabled

        Dim setwin As Boolean = MyFileType.IsPDFExt() OrElse MyFileType.IsImageExt() OrElse MyFileType.IsSVGExt()
        btnSetWindow.Enabled = setwin
        btnWhole.Enabled = setwin
    End Sub
    Public Sub CtlMovie1ControlEnabled()
        Dim isEnabled = MyFileType.IsMovieExt()
        GotoFirst.Enabled = isEnabled
        btnFastReverse.Enabled = isEnabled
        btnStartStop.Enabled = isEnabled
        btnStop.Enabled = isEnabled
        btnFastForward.Enabled = isEnabled

    End Sub

    Public Sub CtlImage1ControlEnabled()
        Dim isEnabled = MyFileType.IsImageExt() OrElse MyFileType.IsSVGExt()

        btnRotateM90.Enabled = isEnabled
        btnRotate90.Enabled = isEnabled
        btnRotate180.Enabled = isEnabled
        btnRotate0.Enabled = isEnabled

    End Sub

    Private Sub frmOperation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        screenDetect()
        AppSettingLoad()
        ActivateForm()
        ControlEnable()
    End Sub

    Private Sub ActivateForm()

        Timer1.Interval = 100
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Activate()
        Timer1.Stop()
    End Sub

#Region "設定値"
    Private loading As Boolean
    Private Sub AppSettingLoad()
        loading = True
        cmbDisplay.SelectedIndex = My.Settings.cmbDisplaySelectedIndex
        lblFormColor.BackColor = My.Settings.formColor
        _dispacher.SetColor(My.Settings.formColor)
        SetColor()
        Try
            Dim fvinfos As New List(Of FileViewParam)

            'XmlSerializerオブジェクトを作成
            Dim serializer As New System.Xml.Serialization.XmlSerializer(
                GetType(List(Of FileViewParam)))
            '読み込むファイルを開く
            Dim filename = "lstPDFFiles.xml"
            If Not IO.File.Exists(filename) Then
                Return
            End If
            Using sr As New System.IO.StreamReader(
                filename, New System.Text.UTF8Encoding(False))
                'XMLファイルから読み込み、逆シリアル化する
                fvinfos =
                DirectCast(serializer.Deserialize(sr), List(Of FileViewParam))
                'ファイルを閉じる
            End Using
            For Each info In fvinfos
                lstPDFFiles.Items.Add(info)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
        loading = False
    End Sub

    Private Sub AppSettingSave()

        My.Settings.cmbDisplaySelectedIndex = cmbDisplay.SelectedIndex
        My.Settings.formColor = lblFormColor.BackColor
        My.Settings.Save()

        Dim fvinfos As New List(Of FileViewParam)
        For Each info As FileViewParam In lstPDFFiles.Items
            fvinfos.Add(info)
        Next
        Dim serializer As New System.Xml.Serialization.XmlSerializer(
            GetType(List(Of FileViewParam)))
        '書き込むファイルを開く（UTF-8 BOM無し）
        Using sw As New System.IO.StreamWriter(
            "lstPDFFiles.xml", False, New System.Text.UTF8Encoding(False))
            'シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, fvinfos)
            'ファイルを閉じる
        End Using
    End Sub

#End Region

    Private Sub screenDetect()
        'デバイス名が表示されるようにする
        Me.cmbDisplay.DisplayMember = "DeviceName"
        Me.cmbDisplay.DataSource = Screen.AllScreens

    End Sub

    Private Sub btnColorChange_Click(sender As Object, e As EventArgs) Handles btnColorChange.Click
        If ColorDialog1.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If
        Me.lblFormColor.BackColor = ColorDialog1.Color
        My.Settings.formColor = ColorDialog1.Color
        SetColor()
        _dispacher.SetColor(ColorDialog1.Color)
    End Sub

#End Region

#Region "終了処理"

    Private Sub frmOperation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        AppSettingSave()


    End Sub
#End Region

#Region "フォームをセカンドディスプレイに表示"
    Private Sub cmbDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDisplay.SelectedIndexChanged

        If cmbDisplay.SelectedIndex < 0 Then
            Exit Sub
        End If
        If cmbDisplay.SelectedItem Is Nothing Then
            Exit Sub
        End If
        '        'フォームを表示するディスプレイのScreenを取得する
        Dim s As Screen = DirectCast(Me.cmbDisplay.SelectedItem, Screen)
        '        'フォームの開始位置をディスプレイの左上座標に設定する
        _dispacher.SetSecondScreen(s)




    End Sub



    Private _dispacher As FormDispacher = FormDispacher.GetInstance


#End Region

#Region "リストボックス処理"



    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstPDFFiles.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim fileviewinfo As FileViewParam
        fileviewinfo = DirectCast(lstPDFFiles.SelectedItem, FileViewParam)
        lstPDFFiles.Items.Remove(fileviewinfo)
    End Sub



    Private Sub lstFiles_Click(sender As Object, e As EventArgs) Handles lstPDFFiles.Click

        Dim fileviewinfo As FileViewParam
        fileviewinfo = DirectCast(lstPDFFiles.SelectedItem, FileViewParam)
        If fileviewinfo Is Nothing Then
            Exit Sub
        End If
        Dim path = fileviewinfo.FileName
        If Not IO.File.Exists(path) Then
            Dim ret = MessageBox.Show("ファイルが見つかりません。リストから削除しますか？", "ファイルがありません", MessageBoxButtons.YesNo)
            If ret = DialogResult.Yes Then
                lstPDFFiles.Items.Remove(fileviewinfo)
            End If
            Exit Sub
        End If
        txtPDFFileName.Text = fileviewinfo.FileName
        Dim ext = IO.Path.GetExtension(fileviewinfo.FileName)

        UpdateImage()
        SetFileInfo(fileviewinfo)

        ControlEnable()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDisp.Click
        Dim fileviewinfo As FileViewParam
        If lstPDFFiles.SelectedItem Is Nothing Then
            _dispacher.ShowImage(Nothing)
            Exit Sub
        End If
        fileviewinfo = DirectCast(lstPDFFiles.SelectedItem, FileViewParam)
        Dim ext = IO.Path.GetExtension(fileviewinfo.FileName)
        SetView()




    End Sub









    Private Sub btnFileAdd_Click(sender As Object, e As EventArgs) Handles btnFileAdd.Click
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.Filter = FileType.CreateFilter()
        OpenFileDialog1.FileName = txtPDFFileName.Text
        Dim ret = OpenFileDialog1.ShowDialog()
        If ret = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim items = lstPDFFiles.Items

        For Each filename In OpenFileDialog1.FileNames
            items.Add(New FileViewParam(filename))
        Next


    End Sub

    Private Sub btnUnSelect_Click(sender As Object, e As EventArgs) Handles btnUnSelect.Click
        lstPDFFiles.SelectedItem = Nothing
        pbThumbnail.Image = Nothing
        ControlEnable()
    End Sub

    Private Sub btnUnDisp_Click(sender As Object, e As EventArgs) Handles btnUnDisp.Click
        _dispacher.CloseViewers()
    End Sub

#Region "ドラッグアンドドロップ"
    Private Sub lstPDFFiles_DragEnter(sender As Object, e As DragEventArgs) Handles lstPDFFiles.DragEnter
        'コントロール内にドラッグされたとき実行される
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstPDFFiles_DragDrop(sender As Object, e As DragEventArgs) Handles lstPDFFiles.DragDrop
        Dim items = lstPDFFiles.Items
        Dim fileName As String() = CType(
                e.Data.GetData(DataFormats.FileDrop, False),
                String())

        For Each f In fileName
            items.Add(New FileViewParam(f))
        Next
    End Sub

    Private Sub chkUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles chkUpdate.CheckedChanged
        UpdateImage()
    End Sub






#End Region







#End Region
#Region "ctlImage"



    Private _image As Bitmap
    'Property Image As Bitmap
    '    Get
    '        Return _image
    '    End Get
    '    Set(value As Bitmap)
    '        If value Is Nothing Then
    '            Exit Property

    '        End If
    '        _image = value
    '        '         _pictureBox.Image = _image
    '        pbThumbnail.Image = _image
    '        pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom
    '    End Set
    'End Property



    Public Function LoadImage(filename As String) As Bitmap
        If System.IO.Path.GetExtension(filename) = ".svg" Then
            Dim doc = Svg.SvgDocument.Open(filename)
            Dim sc = _dispacher.GetScreen().Bounds
            Dim bbmp = doc.Draw(sc.Height, sc.Height)
            Return bbmp
        End If
        Return New Bitmap(filename)
    End Function


    Private Sub Rotate(flip As RotateFlipType)
        Dim bmp = LoadImage(_fileViewParam.FileName)
        bmp.RotateFlip(flip)
        Image = bmp
        pbBack.Image = bmp
    End Sub




    Private Sub btnRotate_Click(sender As Object, e As EventArgs) Handles btnRotate180.Click
        Rotate(RotateFlipType.Rotate180FlipNone)
        VScrollBar1Init()
        UpdateImage()
    End Sub

    Private Sub btnRotate90_Click(sender As Object, e As EventArgs) Handles btnRotate90.Click
        Rotate(RotateFlipType.Rotate90FlipNone)
        VScrollBar1Init()
        UpdateImage()
    End Sub

    Private Sub btnRotate0_Click(sender As Object, e As EventArgs) Handles btnRotate0.Click
        Rotate(RotateFlipType.RotateNoneFlipNone)
        VScrollBar1Init()
        UpdateImage()
    End Sub

    Private Sub btnRotate270_Click(sender As Object, e As EventArgs) Handles btnRotateM90.Click
        Rotate(RotateFlipType.Rotate270FlipNone)
        VScrollBar1Init()
        UpdateImage()
    End Sub
















    Private SetWinWidthModule As SetWinWidthModule


#End Region
#Region "Public Class ctlPdf"
    Friend Sub SetView()
        If pbThumbnail.Image Is Nothing Then
            Exit Sub
        End If
        _dispacher.ShowImage(pbThumbnail.Image)
    End Sub



    Public Sub UpdateImage()
        If chkUpdate.Checked Then
            SetView()
        End If
    End Sub

    Dim pdfDoc As PdfiumViewer.PdfDocument
    Dim page As Integer = 0
    Public Sub OpenFile(fileName As String)
        isHalf = False
        pdfDoc = PdfiumViewer.PdfDocument.Load(fileName)
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
        If buttomInPage = 1.0 AndAlso page = pdfDoc.PageCount - 1 Then
            Exit Sub
        End If


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

    'Private _image As Image
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

    Public Sub SetColor()
        pbThumbnail.BackColor = My.Settings.formColor
    End Sub


    Public Function GetBmp() As Bitmap
        If Image Is Nothing Then
            Return New Bitmap(1, 1)
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





    Private Sub SetImage()
        Dim img = GetBmp()
        If img Is Nothing Then
            Exit Sub

        End If
        pbBack.Image = img
        pbThumbnail.Image = pbBack.Image
        pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom
        If pdfDoc Is Nothing Then
            Exit Sub
        End If
        lblPage.Text = "ページ" & page + 1 & "/" & pdfDoc.PageCount
    End Sub



    Private _backFileName As String
    Private _fileViewParam As FileViewParam
    Private MyFileType As FileType = New FileType("")
    Public Sub SetFileInfo(f As FileViewParam)
        Me._fileViewParam = f
        MyFileType = New FileType(f.FileName)
        If _fileViewParam Is Nothing Then
            SetImage()
            Return
        End If

        Dim sc = _dispacher.GetScreen().Bounds

        If MyFileType.IsPDFExt() Then
            OpenFile(f.FileName)
            SetImage()
        ElseIf MyFileType.IsImageExt() Then
            Rotate(RotateFlipType.RotateNoneFlipNone)
        ElseIf MyFileType.IsMovieExt() Then
            player = _dispacher.ShowMovie()

            player.URL = _fileViewParam.FileName
            player.uiMode = "none"
            player.stretchToFit = True

        End If

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



#End Region
#Region "douga"



    Private player As AxWMPLib.AxWindowsMediaPlayer




#Region "Media Playerの処理"




    Private Sub btnStartStop_Click(sender As Object, e As EventArgs) Handles btnStartStop.Click
        player.Ctlcontrols.play()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        player.Ctlcontrols.pause()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnFastForward.Click
        player.Ctlcontrols.fastForward()
    End Sub

    Private Sub btnFastReverse_Click(sender As Object, e As EventArgs) Handles btnFastReverse.Click
        player.Ctlcontrols.fastReverse()

    End Sub



    Private Sub GotoFirst_Click(sender As Object, e As EventArgs) Handles GotoFirst.Click
        player.Ctlcontrols.stop()
        player.Ctlcontrols.play()
        player.Ctlcontrols.pause()
    End Sub

    Private trackBarSeek_Scrolled As Boolean = False
    Private Sub Seek(sender As Object, e As EventArgs) Handles Timer1.Tick
        If player Is Nothing Then
            Exit Sub
        End If
        Try
            If trackBarSeek_Scrolled Then
                player.Ctlcontrols.currentPosition = trackBarSeek.Value / 100
                If Not player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                    player.Ctlcontrols.play()
                    player.Ctlcontrols.pause()

                End If
                trackBarSeek_Scrolled = False
            Else
                trackBarSeek.Maximum = CType(player.Ctlcontrols.currentItem.duration * 100, Integer)
                trackBarSeek.Value = CType(player.Ctlcontrols.currentPosition * 100, Integer)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ctlMovie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 100
        Timer1.Start()

    End Sub

    Private Sub trackBarSeek_ValueChanged(sender As Object, e As EventArgs) Handles trackBarSeek.Scroll
        trackBarSeek_Scrolled = True

    End Sub


#End Region

#End Region


End Class