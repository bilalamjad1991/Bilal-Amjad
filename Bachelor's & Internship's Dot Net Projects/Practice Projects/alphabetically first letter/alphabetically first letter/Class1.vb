Public Class alphabet

    Public Sub setter(ByVal input1 As Char, ByVal input2 As Char, ByVal input3 As Char)
        Dim ch1 As Char
        Dim ch2 As Char
        Dim ch3 As Char

        ch1 = input1
        ch2 = input2
        ch3 = input3

    End Sub



    Public Function getfirst(ByVal letter1 As Char, ByVal letter2 As Char) As Char
        If letter1 < letter2 Then
            Return letter1
        Else : Return letter2
        End If
    End Function


End Class
