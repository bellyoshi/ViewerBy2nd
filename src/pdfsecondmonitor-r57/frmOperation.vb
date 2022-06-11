Imports ViewerBy2ndLib

Public Class frmOperation


#Region "初期処理"

    Private Sub ControlEnable()
        CtlPdf1ControlEnabled()
        CtlMovie1ControlEnabled()
        CtlImage1ControlEnabled()
        ListControlEnabled()
        CtlSecondEnabled()
    End Sub

    Public Sub ListControlEnabled()
        btnDelete.Enabled = 0 < lstPDFFiles.SelectedItems.Count
        btnUnSelect.Enabled = 0 < lstPDFFiles.SelectedItems.Count

    End Sub

    Public ReadOnly Property isMovie As Boolean
        Get
            Return (document IsNot Nothing) AndAlso document.FileType.IsMovieExt()
        End Get
    End Property


    Private Sub CtlSecondEnabled()

        btnDispPause.Enabled = isMovie
        btnDispPaly.Enabled = isMovie
        btnDispStart.Enabled = isMovie
        btnDisp.Enabled = Not isMovie AndAlso Not chkUpdate.Checked
    End Sub

    Public Sub CtlPdf1ControlEnabled()

        Dim isEnabled = (document IsNot Nothing) AndAlso document.FileType.IsPDFExt()
        btnPDFFirst.Enabled = isEnabled
        btnPDFBack.Enabled = isEnabled
        btnPDFNext.Enabled = isEnabled
        btnPDFLast.Enabled = isEnabled
        btnPreviousHalf.Enabled = isEnabled
        btnNextHalf.Enabled = isEnabled

        Dim canSetWin As Boolean = (document IsNot Nothing) AndAlso
            (document.FileType.IsPDFExt() OrElse document.FileType.IsImageExt() OrElse document.FileType.IsSVGExt())
        btnSetWindow.Enabled = canSetWin
        btnWhole.Enabled = canSetWin
        VScrollBar1.Enabled = (fileViewParam IsNot Nothing) AndAlso fileViewParam.IsWidthEqualWin
    End Sub
    Public Sub CtlMovie1ControlEnabled()

        Dim canThumnailPlay As Boolean = isMovie AndAlso Not isPlay
        GotoFirst.Enabled = canThumnailPlay
        btnFastReverse.Enabled = canThumnailPlay
        btnStart.Enabled = canThumnailPlay
        btnStop.Enabled = canThumnailPlay
        btnFastForward.Enabled = canThumnailPlay
        chkUpdate.Enabled = Not isMovie
        thumbnailPlayer.Visible = isMovie
        trackBarSeek.Enabled = canThumnailPlay
        trackBarSeek.Visible = isMovie
        If Not isMovie Then
            thumbnailPlayer.Stop()
        End If
        lblMovieTime.Visible = isMovie
    End Sub

    Public Sub CtlImage1ControlEnabled()
        Dim isEnabled = (document IsNot Nothing) AndAlso (Not document.FileType.IsMovieExt())

        btnRotateM90.Enabled = isEnabled
        btnRotate90.Enabled = isEnabled
        btnRotate180.Enabled = isEnabled
        btnRotate0.Enabled = isEnabled

    End Sub

    Private Sub frmOperation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dispacher.RegistfrmOperation(Me)
        screenDetect()
        AppSettingLoad()
        ControlEnable()
        SeekTimer.Interval = 100
        SeekTimer.Start()
    End Sub



#Region "設定値"
    Private loading As Boolean
    Private Sub AppSettingLoad()
        loading = True
        If cmbDisplay.Items.Count > My.Settings.cmbDisplaySelectedIndex Then
            cmbDisplay.SelectedIndex = My.Settings.cmbDisplaySelectedIndex
        Else
            cmbDisplay.SelectedIndex = 0
        End If

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

        SetThumnailSize()

    End Sub

    Private Sub SetThumnailSize()

        pbThumbnail.Height = getThumnailWidth(pbThumbnail.Width)
        thumbnailPlayer.Height = getThumnailWidth(thumbnailPlayer.Width)
    End Sub
    Private Function getThumnailWidth(thumWidth As Integer) As Integer
        Dim viewerSize = _dispacher.GetViewScreen().Bounds.Size
        Return thumWidth * viewerSize.Height \ viewerSize.Width
    End Function



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
        If list.Contains(DispFileViewParam) Then
            UpdateView()
            ControlEnable()
        End If
    End Sub

    Private Sub lstFiles_Click(sender As Object, e As EventArgs) Handles lstPDFFiles.Click
        If fileViewParam Is Nothing Then
            Return
        End If
        Dim path = fileViewParam.FileName
        If Not IO.File.Exists(path) Then
            Dim ret = MessageBox.Show("ファイルが見つかりません。リストから削除しますか？", "ファイルがありません", MessageBoxButtons.YesNo)
            If ret = DialogResult.Yes Then
                lstPDFFiles.Items.Remove(fileViewParam)
            End If
            Exit Sub
        End If



        UpdateViewIfChecked()

        ControlEnable()

    End Sub

    Private Sub btnDisp_Click(sender As Object, e As EventArgs) Handles btnDisp.Click
        UpdateView()
    End Sub

    Private ReadOnly Property isPlay As Boolean
        Get
            If player Is Nothing Then
                Return False
            End If
            Return player.State = Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing
        End Get
    End Property
    Private Sub btnDispPaly_Click(sender As Object, e As EventArgs) Handles btnDispPaly.Click

        Dim vlc = _dispacher.ShowMovie()
        Dim starttime As Integer = Convert.ToInt32(thumbnailPlayer.Time / 1000)
        Dim op = New String() {$"start-time={starttime}"}
        vlc.Play(New Uri("file://" & fileViewParam.FileName), op)
        player = vlc
        DispFileViewParam = fileViewParam

    End Sub

    Private player As Vlc.DotNet.Forms.VlcControl

    Private Sub btnDispPause_Click(sender As Object, e As EventArgs) Handles btnDispPause.Click
        player.Pause()
        If thumbnailPlayer.IsPlaying Then
            thumbnailPlayer.Pause()
        End If
    End Sub

    Private Sub btnDispStart_Click(sender As Object, e As EventArgs) Handles btnDispStart.Click
        player.Play()
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
        DispFileViewParam = Nothing
    End Sub
    Private Sub btnUnSelectUpdate_Click(sender As Object, e As EventArgs) Handles btnUnSelectUpdate.Click
        lstPDFFiles.SelectedItem = Nothing
        pbThumbnail.Image = Nothing
        SetPreview()
        UpdateView()
        ControlEnable()
        DispFileViewParam = Nothing
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
        ControlEnable()
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
        If chkUpdate.Checked AndAlso Not (document?.FileType?.IsMovieExt) Then
            UpdateView()
        End If
    End Sub

    Public Sub UpdateView()
        _dispacher.ShowImage(pbThumbnail.Image)
        DispFileViewParam = fileViewParam

    End Sub

    Private ReadOnly Property fileViewParam As FileViewParam
        Get
            If lstPDFFiles.SelectedItems.Count <> 1 Then
                Return Nothing
            End If
            If lstPDFFiles.SelectedItem Is Nothing Then
                Return Nothing
            End If
            Dim p = DirectCast(lstPDFFiles.SelectedItem, FileViewParam)
            p.Bound = _dispacher.GetViewScreen.Bounds.Size
            Return p
        End Get
    End Property

    Private ReadOnly Property document As ViewerBy2ndLib.Document
        Get
            Return fileViewParam?.document
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



    Private requirePouse As Boolean = False

    Private Sub SetPreview()
        txtPDFFileName.Text = "" & fileViewParam?.FileName
        pbThumbnail.Image = document?.Image
        pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom
        If document?.FileType?.IsPDFExt Then
            lblPageDisp.Visible = True
            lblPageDisp.Text = $"ページ{document.page + 1}/{document.PageCount}"
        Else
            lblPageDisp.Visible = False
        End If
        pbThumbnail.Visible = (document Is Nothing) OrElse (Not document.FileType.IsMovieExt)
        thumbnailPlayer.Visible = (document IsNot Nothing) AndAlso document.FileType.IsMovieExt

        If document IsNot Nothing AndAlso document.FileType.IsMovieExt() Then

            thumbnailPlayer.Play((New Uri("file://" & fileViewParam.FileName)), New String() {})
            requirePouse = True

        End If
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
        ' IsScroll = True
        VSctollUpdate()
    End Sub

    Private Sub VSctollUpdate()
        If fileViewParam Is Nothing Then
            Return
        End If
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
        ControlEnable()
        VScrollBar1Init()
        UpdateViewIfChecked()
    End Sub




#End Region
#Region "douga"






#Region "Media Playerの処理"




    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        thumbnailPlayer.Rate = 1
        btnFastForward.Text = "▶▶"
        thumbnailPlayer.Play()
        thumbnailPlayer.Audio.Volume = 0
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        thumbnailPlayer.Pause()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnFastForward.Click
        'todo:
        btnFastForward.Text = "▶▶▶"
        If thumbnailPlayer.Rate = 2.0 Then
            thumbnailPlayer.Rate = 4.0
        Else
            thumbnailPlayer.Rate = 2.0
        End If



    End Sub

    Private Sub btnFastReverse_Click(sender As Object, e As EventArgs) Handles btnFastReverse.Click
        'todo:
        If thumbnailPlayer.Time < 15000 Then
            thumbnailPlayer.Time = 0
        Else
            thumbnailPlayer.Time = thumbnailPlayer.Time - 15000
        End If




    End Sub



    Private Sub GotoFirst_Click(sender As Object, e As EventArgs) Handles GotoFirst.Click
        thumbnailPlayer.VlcMediaPlayer.Time = 0
    End Sub

    Private trackBarSeek_Scrolled As Boolean = False
    Private Sub SeekTimer_Tick(sender As Object, e As EventArgs) Handles SeekTimer.Tick

        Trackbar_Seek()
    End Sub

    Private Sub Trackbar_Seek()
        Try
            If trackBarSeek_Scrolled Then
                thumbnailPlayer.VlcMediaPlayer.Time = Convert.ToInt32(trackBarSeek.Value * 100)
                trackBarSeek_Scrolled = False
            Else
                trackBarSeek.Maximum = Convert.ToInt32(thumbnailPlayer.VlcMediaPlayer.Length / 100)
                trackBarSeek.Value = Convert.ToInt32(thumbnailPlayer.Time / 100)
            End If

        Catch ex As Exception

        End Try
        If requirePouse Then
            If thumbnailPlayer.Time <> 0 Then
                thumbnailPlayer.Pause()
                requirePouse = False
            End If


        End If
        lbl_Update()
    End Sub

    Private Sub lbl_Update()
        Dim ts As New TimeSpan(thumbnailPlayer.VlcMediaPlayer.Time * 10000)
        lblMovieTime.Text = ts.ToString("hh\:mm\:ss")
        ControlEnable()
    End Sub


    Private Sub trackBarSeek_Scroll(sender As Object, e As EventArgs) Handles trackBarSeek.Scroll
        trackBarSeek_Scrolled = True

    End Sub

    Private Sub btnWhole_Click(sender As Object, e As EventArgs) Handles btnWhole.Click
        fileViewParam.IsWidthEqualWin = False
        ControlEnable()
        UpdateViewIfChecked()
    End Sub



    Private Sub lstPDFFiles_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstPDFFiles.SelectedValueChanged
        ControlEnable()
        UpdateViewIfChecked()
    End Sub

    Private Sub btnAllSelect_Click(sender As Object, e As EventArgs) Handles btnAllSelect.Click
        For i As Integer = 0 To lstPDFFiles.Items.Count - 1

            lstPDFFiles.SetSelected(i, True)
        Next
    End Sub

    Private Sub thumbnailPlayer_VlcLibDirectoryNeeded(sender As Object, e As Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs) Handles thumbnailPlayer.VlcLibDirectoryNeeded
        e.VlcLibDirectory = VLCDirectoryGetter.GetVlcLibDirectory()
    End Sub

    Private Sub trackBarSeek_MouseDown(sender As Object, e As MouseEventArgs) Handles trackBarSeek.MouseDown
        Dim TrackBar1 = trackBarSeek
        If e.Button <> Windows.Forms.MouseButtons.Left _
            OrElse e.X < 0 OrElse e.X > TrackBar1.Width OrElse e.Y < 0 OrElse e.Y > TrackBar1.Height Then
            Exit Sub
        End If

        If e.X < 8 Then
            TrackBar1.Value = TrackBar1.Minimum
        ElseIf e.X > TrackBar1.Width - 8 Then
            TrackBar1.Value = TrackBar1.Maximum
        Else
            Dim seekWidth As Double = TrackBar1.Width - 16
            Dim ticWidth As Double = seekWidth / (TrackBar1.Maximum - TrackBar1.Minimum)
            TrackBar1.Value = CInt((e.X - 8) / ticWidth) + TrackBar1.Minimum
        End If
        trackBarSeek_Scrolled = True
        Trackbar_Seek()
    End Sub

    Public Sub frmOperation_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If Not VScrollBar1.Enabled Then
            Return
        End If
        Dim numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 10
        Debug.Print(numberOfTextLinesToMove.ToString)
        Dim expect As Integer = -Convert.ToInt32(numberOfTextLinesToMove) + VScrollBar1.Value
        If expect < 0 Then
            expect = 0
            If document.CanPrePage() Then
                expect = VScrollBar1.Maximum
                document.PrePage()
            End If
        End If

        If VScrollBar1.Maximum < expect Then
            expect = VScrollBar1.Maximum
            If document.CanNextPage() Then
                expect = 0
                document.NextPage()
            End If
        End If
        VScrollBar1.Value = expect
        VSctollUpdate()
    End Sub







#End Region

#End Region

    Private DispFileViewParam As FileViewParam

End Class