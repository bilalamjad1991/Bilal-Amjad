Module CurrentUser
    Public UserID As Long
    Public UserName As String
    Public SystemName As String
    'Public AccountID As String
    Public Sub GetUserInfo(ByVal UID As Long)
        Dim D As New DAL.DAL
        UserName = D.GetScaler("Select UserName from tblUsers where userid=" & UID)
        UserID = UID
        'AccountID = D.GetScaler("Select AccountID from tblUsers where userid =" & UID)


    End Sub
    Public Sub GetSysInfo()
        SystemName = System.Environment.MachineName
    End Sub
    Public Function HasRight(ByVal RightID As Integer) As Boolean
        Dim D As New DAL.DAL
        Return CBool(D.IsRecordExists("Select UserID from tblUserRights Where UserID = " & UserID & " and rightID = " & RightID))
        D = Nothing
    End Function
    Public Function HasRight(ByVal RightName As String) As Boolean
        Dim D As New DAL.DAL
        Return CBool(D.IsRecordExists("Select tblUserRights.userID FROM tblUserRights INNER JOIN tblRights ON tblUserRights.rightID = tblRights.rightID WHERE (tblRights.rightCaption = N'" & RightName & "')"))
        D = Nothing
    End Function
End Module
