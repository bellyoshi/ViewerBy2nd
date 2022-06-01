Public Module ImageModule
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

End Module
