Public Class Form1

    Private Sub btnDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDraw.Click

        Dim myPen As Pen
        myPen = New Pen(Drawing.Color.Black, 5)
        Dim myGraphics As Graphics = Me.CreateGraphics
        myGraphics.DrawEllipse(myPen, 200, 30, 50, 50)

        Dim myGraphics1 As Graphics = Me.CreateGraphics
        Dim myPen1 As Pen
        myPen1 = New Pen(Brushes.Black, 5)
        myGraphics1.DrawLine(myPen1, 180, 150, 220, 80)

        Dim myGraphics2 As Graphics = Me.CreateGraphics
        Dim myPen2 As Pen
        myPen2 = New Pen(Brushes.Black, 5)
        myGraphics2.DrawLine(myPen2, 250, 150, 220, 80)


        Dim myGraphics3 As Graphics = Me.CreateGraphics
        Dim myPen3 As Pen
        myPen3 = New Pen(Brushes.Black, 5)
        myGraphics.DrawLine(myPen3, 170, 150, 270, 150)

        Dim myGraphics4 As Graphics = Me.CreateGraphics
        Dim myPen4 As Pen
        myPen4 = New Pen(Brushes.Black, 5)
        myGraphics1.DrawLine(myPen4, 140, 220, 200, 150)


        Dim myGraphics5 As Graphics = Me.CreateGraphics
        Dim myPen5 As Pen
        myPen5 = New Pen(Brushes.Black, 5)
        myGraphics5.DrawLine(myPen5, 280, 220, 240, 150)


    End Sub

    
End Class
