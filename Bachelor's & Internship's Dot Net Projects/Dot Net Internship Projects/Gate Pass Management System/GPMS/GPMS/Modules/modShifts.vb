Module modShifts
    Dim D As New DAL.DAL
    Public Structure typeShift
        Dim sID As Integer
        Dim sName As String
        Dim sStartTime As Date
        Dim sEndTime As Date
    End Structure
    Public CurrentShiftID As Integer
    Public CurrentShiftName As String

    Public Shifts(3) As typeShift
    Public Sub LoadShifts()
        Dim DT As DataTable
        Dim N As Integer = 0
        DT = D.GetDataTable("Select * from tblShifts where shiftActive =1")
        For Each R As DataRow In DT.Rows
            Shifts(N).sID = R.Item("ShiftID")
            Shifts(N).sName = R.Item("ShiftName")
            Shifts(N).sStartTime = Format(R.Item("ShiftStartTime"), "HH:MM")
            Shifts(N).sEndTime = Format(R.Item("ShiftEndTime"), "HH:MM")
            N += 1
        Next
    End Sub
    Function DayStart() As Date
        Dim N As Integer
        For N = 0 To 3
            If Shifts(N).sID = FirstShiftID() Then
                Return Shifts(N).sStartTime
                Exit Function
            End If
        Next

    End Function
    Function FirstShiftID() As Integer
        FirstShiftID = Shifts(0).sID
    End Function
    Sub GetCurrentShift()
        Dim sDayStart As Date
        Dim CurrentTime As Date
        Dim N As Integer
        Dim cShiftStart As Date
        Dim cShiftEnd As Date

        sDayStart = DayStart
        CurrentTime = Format(Now, "hh:mm:ss tt")
        If CurrentTime < sDayStart Then
            CurrentTime = Now.AddDays(1)
        Else
            CurrentTime = Now
        End If
        CurrentShiftID = 0
        For N = 0 To 3
            cShiftStart = Format(Now.Date, "dd-MMM-yy") & " " & Format(Shifts(N).sStartTime, "HH:MM")
            cShiftEnd = Format(Shifts(N).sEndTime, "HH:MM")
            If cShiftEnd < sDayStart Then
                cShiftEnd = Format(Now.AddDays(1), "dd-MMM-yy") & " " & Format(Shifts(N).sEndTime, "HH:MM")
            Else
                cShiftEnd = Format(Now.Date, "dd-MMM-yy") & " " & Format(Shifts(N).sEndTime, "HH:MM")
            End If
            If CurrentTime >= cShiftStart And CurrentTime <= cShiftEnd Then
                CurrentShiftID = Shifts(N).sID
                CurrentShiftName = Shifts(N).sName
                Exit For
            End If

        Next
        If CurrentShiftID = 0 Then
            CurrentShiftName = "Shift Closed"
        End If
    End Sub


End Module

