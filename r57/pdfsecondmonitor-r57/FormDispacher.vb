Public Class FormDispacher

    Private _secondScreen As Screen
    Public Function GetScreen() As Screen
        Return _secondScreen
    End Function
    Public Sub SetSecondScreen(ByVal screen As Screen)
        _secondScreen = screen
        For Each frm In _secondMonitorWindows
            SetViewerBounds(frm)
        Next
    End Sub

    Private Sub SetViewerBounds(ByVal frm As Form)
        If _secondScreen Is Nothing Then
            Return
        End If
        Dim bouds = _secondScreen.Bounds
        frm.StartPosition = FormStartPosition.Manual
        frm.Location = bouds.Location
        frm.Size = bouds.Size
    End Sub

    Private _secondMonitorWindows As New List(Of Form)

    Private Sub registViewer(frm As Form)
        If Not _secondMonitorWindows.Contains(frm) Then
            _secondMonitorWindows.Add(frm)
        End If
        SetViewerBounds(frm)
    End Sub

    Private Shared instance As FormDispacher
    Public Shared Function GetInstance() As FormDispacher
        If instance Is Nothing Then
            instance = New FormDispacher
        End If
        Return instance
    End Function

    Public Sub ShowImage(image As Image)
        Show(_frmImageViewer, GetType(frmImageViewer))
        _frmImageViewer.PictureBox1.Image = image
        _frmImageViewer.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
    End Sub
    Private _frmImageViewer As frmImageViewer

    Private _frmMovieViewer As frmMovieViewer
    Public Function ShowMovie() As AxWMPLib.AxWindowsMediaPlayer
        Show(_frmMovieViewer, GetType(frmMovieViewer))
        Return _frmMovieViewer.AxWindowsMediaPlayer1
    End Function

    Public Sub Create(ByRef form As Form, ByVal formType As Type)
        If form Is Nothing OrElse
         Not _secondMonitorWindows.Contains(form) Then
            form = Activator.CreateInstance(formType)
            form.BackColor = color
            AddHandler form.FormClosed, AddressOf from_Closed
        End If

    End Sub

    Private Sub from_Closed(sender As Object, e As EventArgs)
        Dim form = DirectCast(sender, Form)
        _secondMonitorWindows.Remove(form)
    End Sub

    Private Sub HideOther(ByVal targetForm As Form)
        For Each frm In _secondMonitorWindows
            If frm Is targetForm Then
                Continue For
            End If
            frm.Hide()
        Next
    End Sub

    Public Sub Show(ByRef targetForm As Form, ByVal formType As Type)
        Create(targetForm, formType)
        registViewer(targetForm)
        HideOther(targetForm)
        targetForm.Show()
    End Sub

    Dim _frmPdfViewer As frmPdfViewer
    Public Function ShowPdfViewer() As frmPdfViewer
        Show(_frmPdfViewer, GetType(frmPdfViewer))
        _frmPdfViewer.Hide()
        Return _frmPdfViewer
    End Function

    Private color As Color
    Public Sub SetColor(color As Color)
        Me.color = color
        For Each frm In _secondMonitorWindows
            frm.BackColor = color
        Next

    End Sub

    Public Sub CloseViewers()
        Dim forms = New List(Of Form)(_secondMonitorWindows)
        For Each frm In forms
            frm.Close()
        Next
    End Sub

End Class
