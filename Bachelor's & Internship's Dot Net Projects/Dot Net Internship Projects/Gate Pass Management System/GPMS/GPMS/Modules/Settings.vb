'   1-OutBoundITNRatePerKM
'   2-OutBoundDNRatePerKM
'   3-HeadAccountIDForBanks
'   4-HeadAccountIDForEmployees
'   5-HeadAccountIDForVehicles
'   6-EFLAccountID
'   7-RevenueAccount
'   8-CashAccountID
'   9-SuspenseAccountID

'SaveSetting
'GetSetting

Module Settings
    Public Function GetMySetting(ByVal settingName As String) As String
        Dim D As New DAL.DAL
        Dim S As String
        S = D.GetScaler("Select settingValue from tblSettings where settingName = '" & settingName & "'")
        D = Nothing
        Return S

    End Function
    Public Function SaveMySetting(ByVal settingName As String, ByVal settingValue As String) As Boolean
        Dim D As New DAL.DAL
        Dim S As String
        If D.IsRecordExists("Select settingName from tblSettings where settingName = '" & settingName & "'") Then
            S = "UPDATE tblSettings Set settingValue = '" & settingValue & "'" & _
                 " WHERE settingName ='" & settingName & "'"

        Else
            Dim NewID As Long = D.GetScaler("Select Max(SettingID) from tblSettings")
            NewID += 1
            S = "INSERT INTO tblSettings (settingID, settingName, settingValue) " & _
               "VALUES (" & NewID & ", '" & settingName & "', '" & settingValue & "')"
        End If
        D.ExecuteNonQuery(S)
        Return True

    End Function
    
End Module
