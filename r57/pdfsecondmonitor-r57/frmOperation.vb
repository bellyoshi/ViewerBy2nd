Imports ViewerBy2ndLib

Public Class frmOperation


#Region "初期処理"

    Private Sub ControlEnable()
        CtlPdf1ControlEnabled()
        CtlMovie1ControlEnabled()
        CtlImage1ControlEnabled()
        ListControlEnabled()
    End Sub

    Public Sub ListControlEnabled()
        btnDelete.Enabled = 0 < lstPDFFiles.SelectedItems.Count
        btnUnSelect.Enabled = 0 < lstPDFFiles.SelectedItems.Count

    End Sub

    Public Sub CtlPdf1ControlEnabled()

        Dim isEnabled = document.FileType.IsPDFExt()
        btnPDFFirst.Enabled = isEnabled
        btnPDFBack.Enabled = isEnabled
        btnPDFNext.Enabled = isEnabled
        btnPDFLast.Enabled = isEnabled
        btnPreviousHalf.Enabled = isEnabled
        btnNextHalf.Enabled = isEnabled

        Dim setwin As Boolean = document.FileType.IsPDFExt() OrElse document.FileType.IsImageExt() OrElse document.FileType.IsSVGExt()
        btnSetWindow.Enabled = setwin
        btnWhole.Enabled = setwin
    End Sub
    Public Sub CtlMovie1ControlEnabled()
        Dim isEnabled = document.FileType.IsMovieExt()
        GotoFirst.Enabled = isEnabled
        btnFastReverse.Enabled = isEnabled
        btnStartStop.Enabled = isEnabled
        btnStop.Enabled = isEnabled
        btnFastForward.Enabled = isEnabled

    End Sub

    Public Sub CtlImage1ControlEnabled()
        Dim isEnabled = document.FileType.IsImageExt() OrElse document.FileType.IsSVGExt()

        btnRotateM90.Enabled = isEnabled
        btnRotate90.Enabled = isEnabled
        btnRotate180.Enabled = isEnabled
        btnRotate0.Enabled = isEnabled

    End Sub

    Private Sub frmOperation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        screenDetect()
        AppSettingLoad()
        ControlEnable()
        Timer1.Interval = 100
        Timer1.Start()
    End Sub



#Region "設定値"
    Private loading As Boolean
    Private Sub AppSettingLoad()
        loading = True
        cmbDisplay.SelectedIndex = My.Settings.cmbDisplaySelectedIndex
        lblFormColor.BackColor = My.Settings.formColor
        chkUpdate.Checked = My.Settings.chkUpdate
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
        My.Settings.chkUpdate = chkUpdate.Checked
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

        Dim viewerSize = _dispacher.GetViewScreen().Bounds.Size

        pbThumbnail.Height = pbThumbnail.Width * viewerSize.Height \ viewerSize.Width

    End Sub

    Private _dispacher As FormDispacher = FormDispacher.GetInstance


#End Region

#Region "リストボックス処理"

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstPDFFiles.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim a = lstPDFFiles.SelectedItems.Cast(Of Object)
        Dim list = a.ToArray()
        For Each i In list
            lstPDFFiles.Items.Remove(i)
        Next

    End Sub

    Private Sub lstFiles_Click(sender As Object, e As EventArgs) Handles lstPDFFiles.Click

        Dim path = Me.fileViewParam.FileName
        If Not IO.File.Exists(path) Then
            Dim ret = MessageBox.Show("ファイルが見つかりません。リストから削除しますか？", "ファイルがありません", MessageBoxButtons.YesNo)
            If ret = DialogResult.Yes Then
                lstPDFFiles.Items.Remove(fileViewParam)
            End If
            Exit Sub
        End If
        txtPDFFileName.Text = fileViewParam.FileName

        SetFileInfo(fileViewParam)

        UpdateViewIfChecked()

        ControlEnable()

    End Sub

    Private Sub btnDisp_Click(sender As Object, e As EventArgs) Handles btnDisp.Click
        UpdateView()
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
            items.Add(New FileViewParam(filename, _dispacher.GetViewScreen.Bounds.Size))
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
            items.Add(New FileViewParam(f, _dispacher.GetViewScreen.Bounds.Size))
        Next
    End Sub

    Private Sub chkUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles chkUpdate.CheckedChanged
        UpdateViewIfChecked()
    End Sub

#End Region

#End Region
#Region "ctlImage"


    Private Sub btnRotate_Click(sender As Object, e As EventArgs) Handles btnRotate180.Click
        document.Rotate(RotateFlipType.Rotate180FlipNone)
        VScrollBar1Init()
        UpdateViewIfChecked()
    End Sub

    Private Sub btnRotate90_Click(sender As Object, e As EventArgs) Handles btnRotate90.Click
        document.Rotate(RotateFlipType.Rotate90FlipNone)
        VScrollBar1Init()
        UpdateViewIfChecked()
    End Sub

    Private Sub btnRotate0_Click(sender As Object, e As EventArgs) Handles btnRotate0.Click
        document.Rotate(RotateFlipType.RotateNoneFlipNone)
        VScrollBar1Init()
        UpdateViewIfChecked()
    End Sub

    Private Sub btnRotate270_Click(sender As Object, e As EventArgs) Handles btnRotateM90.Click
        document.Rotate(RotateFlipType.Rotate270FlipNone)
        VScrollBar1Init()
        UpdateViewIfChecked()
    End Sub

#End Region
#Region "Public Class ctlPdf"

    Public Sub UpdateViewIfChecked()
        SetPreview()
        If chkUpdate.Checked Then
            UpdateView()
        End If
    End Sub

    Public Sub UpdateView()
        _dispacher.ShowImage(pbThumbnail.Image)
    End Sub

    Private ReadOnly Property fileViewParam As FileViewParam
        Get
            If lstPDFFiles.SelectedItem Is Nothing Then
                Return New FileViewParam
            End If
            Dim p = DirectCast(lstPDFFiles.SelectedItem, FileViewParam)
            p.Bound = _dispacher.GetViewScreen.Bounds.Size
            Return p
        End Get
    End Property

    Private ReadOnly Property document As ViewerBy2ndLib.Document
        Get
            Return fileViewParam.document
        End Get
    End Property


    Public Sub SetColor()
        pbThumbnail.BackColor = My.Settings.formColor
    End Sub


#Region "ページ移動"

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnPDFFirst.Click
        document.FirstPage()
        UpdateViewIfChecked()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnPDFNext.Click
        document.NextPage()
        UpdateViewIfChecked()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnPDFBack.Click
        document.PrePage()
        UpdateViewIfChecked()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnPDFLast.Click
        document.LastPage()
        UpdateViewIfChecked()
    End Sub
#End Region





    Private Sub SetPreview()
        pbThumbnail.Image = document.Image
        pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom
        If document.FileType.IsPDFExt Then
            lblPageDisp.Text = $"ページ{document.page + 1}/{document.PageCount}"
        Else
            lblPageDisp.Text = ""
        End If

    End Sub



    Private _backFileName As String

    Public Sub SetFileInfo(f As FileViewParam)


        Dim sc = _dispacher.GetViewScreen().Bounds

        If document.FileType.IsMovieExt() Then
            player = _dispacher.ShowMovie()

            player.URL = fileViewParam.FileName
            player.uiMode = "none"
            player.stretchToFit = True
        End If


        UpdateViewIfChecked()
    End Sub



    Private Sub btnNextHalf_Click(sender As Object, e As EventArgs) Handles btnNextHalf.Click
        document.NextHalfPage()
        UpdateViewIfChecked()
    End Sub

    Private Sub btnPreviousHalf_Click(sender As Object, e As EventArgs) Handles btnPreviousHalf.Click
        document.PreviousHalfPage()
        UpdateViewIfChecked()
    End Sub



    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll

        fileViewParam.scrollBarValue = VScrollBar1.Value
        document.DispSetWindow()


        UpdateViewIfChecked()
    End Sub
    Private Sub VScrollBar1Init()
        VScrollBar1.Value = 0
        VScrollBar1.Minimum = 0
        VScrollBar1.Maximum = document.Image.Height

    End Sub
    Private Sub btnSetWindow_Click(sender As Object, e As EventArgs) Handles btnSetWindow.Click
        fileViewParam.scrollBarValue = 0
        fileViewParam.IsWidthEqualWin = True

        VScrollBar1Init()
        UpdateViewIfChecked()
    End Sub




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



    Private Sub trackBarSeek_ValueChanged(sender As Object, e As EventArgs) Handles trackBarSeek.Scroll
        trackBarSeek_Scrolled = True

    End Sub

    Private Sub btnWhole_Click(sender As Object, e As EventArgs) Handles btnWhole.Click
        fileViewParam.IsWidthEqualWin = False
        UpdateViewIfChecked()
    End Sub

    Private Sub lstPDFFiles_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles lstPDFFiles.ChangeUICues

    End Sub

    Private Sub lstPDFFiles_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstPDFFiles.SelectedValueChanged
        ControlEnable()
        UpdateViewIfChecked()
    End Sub






#End Region

#End Region


End Class