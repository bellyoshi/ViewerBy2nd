

Public Class FileViewParam
    Public Property FileName As String
    Public Property zoom As Decimal
    Public Overrides Function ToString() As String
        Return $"{System.IO.Path.GetFileName(FileName)}"

    End Function

    Public Sub New(ByVal filename As String)
        Me.FileName = filename
        Me.zoom = 100
    End Sub

    Public Sub New()
        'シリアル化用
    End Sub
End Class
