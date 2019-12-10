Imports System.Data
Imports System.Data.SqlClient



Module Utility
    
    Function AddZerosToMakeThree(ByVal S As String) As String
        Select Case Len(S)
            Case 1 : Return "00" & S
            Case 2 : Return "0" & S
            Case 3 : Return S

        End Select
    End Function
    Public Function OnlyDecimalNumerics(ByRef e As System.Windows.Forms.KeyPressEventArgs, ByVal TxtBox As TextBox) As Boolean
        If e.KeyChar = Microsoft.VisualBasic.ChrW(8) Then Exit Function
        If e.KeyChar = "." And TxtBox.Text.IndexOf(".") > 0 Then
            e.Handled = True
            Exit Function
        End If
        Dim allowedChars As String = "0123456789."
        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If

    End Function
    Public Function OnlyDecimalMobileNo(ByRef e As System.Windows.Forms.KeyPressEventArgs, ByVal TxtBox As TextBox) As Boolean
        If e.KeyChar = Microsoft.VisualBasic.ChrW(8) Then Exit Function
        If e.KeyChar = "-" And TxtBox.Text.IndexOf("-") > 0 Then
            e.Handled = True
            Exit Function
        End If
        Dim allowedChars As String = "0123456789-"
        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If

    End Function
    Public Function OnlyNumerics(ByRef e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(8), Microsoft.VisualBasic.ChrW(13)
                Return True
        End Select

        Dim allowedChars As String = "0123456789"
        If allowedChars.IndexOf(e.KeyChar) = -1 Then

            e.Handled = True
            Return False

        End If
        Return True

    End Function
    Public Function OnlyAlphaCaps(ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        e.KeyChar = StrConv(e.KeyChar, VbStrConv.Uppercase)
        Dim ValidSTR As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-"
        If InStr(ValidSTR, e.KeyChar) = 0 Then
            e.KeyChar = ""
            e.Handled = True
            Return False
        End If
    End Function



    Public Function AccountHeadIDtoControlID(ByVal headID As String) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select ctlID from tblAccountHead Where headID='" & headID & "'")
        D = Nothing

    End Function
    Public Function AccountIDHeadID(ByVal AccID As String) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select HeadID from tblAccounts Where AccID='" & AccID & "'")
        D = Nothing

    End Function
    Public Function GetHomeCityID() As Integer
        Dim D As New DAL.DAL
        Return D.GetScaler("Select cityID from tblCities Where cityIsHome=1")
    End Function
    Public Function GetDistance(ByVal FromCity As Integer, ByVal ToCity As Integer) As Long
        Dim S As Long
        Dim D As New DAL.DAL
        S = D.GetScaler("Select distDistance from tblDistances where (distFromCityID = " & FromCity & " and distToCityID = " & ToCity & ") OR (distFromCityID = " & ToCity & " and distToCityID = " & FromCity & ")")
        Return S
    End Function
    Public Function GetCityIdToName(ByVal cityID As Integer)
        Dim S As String
        Dim D As New DAL.DAL
        S = D.GetScaler("Select CityName From tblCities where cityID = " & cityID)
        Return S
    End Function
    Public Function GetHomeCityName() As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select cityName from tblCities Where cityIsHome=1")
    End Function

    Public Function GetNewBillNo(ByVal Prefix As String) As String
        'Format:  V201201-0001
        'where V20 is Prefix
        '12 is Year
        '01 is Month
        '001 is Incremental Serial Number

        'V20: Out Bound 20 ft(Variable Cost 20 ft)
        'V50: Out Bound 50 ft(Variable Cost 50 ft)
        'F20: Fixed Cost 20 ft
        'F50: Fixed Cost 50 ft
        'OPN: Open
        'HPO
        'HPF: HPO Fixed
        'HPV: HPO Variable
        'ENG: Engineering
        'MIS: Misc

        Dim P As String
        Dim T As String
        Dim N As Integer
        P = Prefix & Format(Now.Date, "yyMM") & "-"
        Dim D As New DAL.DAL
        T = D.GetScaler("Select Max(BillNo) from tblBillMaster Where BillNo like '" & P & "%'")
        If T = "" Then
            T = P & "0001"
        Else
            N = Val(Right(T, 4))
            N += 1

            Select Case Len(CStr(N))
                Case 1 : T = "000" & N
                Case 2 : T = "00" & N
                Case 3 : T = "0" & N
                Case 4 : T = N
            End Select
            T = P & T
        End If
        Return T
    End Function
    Public Function GetNewVoucherNo(ByVal Prefix As String) As String
        'Format:  CRV1201-00001
        'where CRV is Prefix
        '12 is Year
        '01 is Month
        '001 is Incremental Serial Number

        'CR: Cach Receive 
        'CP: Cash Payment 
        'JV: General Voucher

        Dim P As String
        Dim T As String
        Dim N As Integer
        P = Prefix & Format(Now.Date, "yyMM") & "-"
        Dim D As New DAL.DAL
        T = D.GetScaler("Select Max(ledRefNo) from tblLedger Where ledRefNo like '" & P & "%'")
        If T = "" Then
            T = P & "00001"
        Else
            N = Val(Right(T, 5))
            N += 1

            Select Case Len(CStr(N))
                Case 1 : T = "0000" & N
                Case 2 : T = "000" & N
                Case 3 : T = "00" & N
                Case 4 : T = "0" & N
                Case 5 : T = N
            End Select
            T = P & T
        End If
        Return T
    End Function
    Public Function GetLastBillEndDate(ByVal BillType As String) As Date
        'V20 for OutBound 20 ft
        Dim D As New DAL.DAL
        Dim DT
        Dim DT1 As Date
        DT = D.GetScaler("Select BillEndDate from tblBillMaster where BillNo = (Select Max(BillNo) from tblBillMaster where billType ='" & BillType & "')")
        If IsNothing(DT) Then
            DT1 = Now.Date
        Else
            DT1 = DateAdd(DateInterval.Day, 1, CDate(DT))

        End If
        Return DT1
    End Function
    Public Function AccountIDtoName(ByVal accID As String) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select AccName from tblAccounts where AccID = '" & accID & "'")
        D = Nothing
    End Function

    Public Sub AddLedgerEntry(ByRef COM As SqlCommand, ByVal lRefNo As String, ByVal lDate As Date,
                                   ByVal lAccID As String, ByVal lBillNo As String, ByVal lDesc As String,
                                   ByVal lDR As Decimal, ByVal lCR As Decimal, ByVal lType As String, ByVal lCreatedBy As Long,
                                   ByVal lCreatedOn As Date, ByVal lEditedBy As Long, ByVal lEditedOn As Date)

        Dim strSQL As String
        strSQL = "INSERT INTO tblLedger (" & _
                 "ledRefNo, ledDate, ledAccountID, ledBillNo, " & _
                 "ledDesc, ledDR, ledCR, ledType, " & _
                 "ledCreatedBy, ledCreatedOn, ledEditedBy, ledEditedOn) VALUES(" & _
                 "'" & lRefNo & "', " & _
                 "'" & lDate & "', " & _
                 "'" & lAccID & "', " & _
                 "'" & lBillNo & "', " & _
                 "'" & lDesc & "', " & _
                 " " & lDR & ", " & _
                 " " & lCR & ", " & _
                 "'" & lType & "', " & _
                 "" & lCreatedBy & ", " & _
                 "'" & lCreatedOn & "', " &
                 "" & lEditedBy & ", " & _
                 "'" & lEditedOn & "')"
        COM.CommandText = strSQL
        COM.ExecuteNonQuery()

    End Sub
    Public Function AccountIDToBalance(ByVal AccID As String) As Decimal
        Dim B As Decimal
        Dim D As New DAL.DAL
        B = Val(D.GetScaler("Select Sum(ledDr) - Sum(ledCR) from tblLedger Where ledAccountID = '" & AccID & "'"))
        Return B
    End Function
    Public Function AccountIDToBalance(ByVal AccID As String, ByVal BeforeDate As Date) As Decimal
        Dim B As Decimal
        Dim D As New DAL.DAL
        B = Val(D.GetScaler("Select Sum(ledDr) - Sum(ledCR) from tblLedger Where ledAccountID = '" & AccID & "' and ledDate < '" & BeforeDate & "'"))
        Return B
    End Function
    Public Function GetNewBookingNumber(ByVal PreFix As String) As String
        Dim P As String
        P = Format(Now.Date, "yyMM")
        P = PreFix & P & "-"
        Dim D As New DAL.DAL
        Dim Cn As SqlConnection = New SqlConnection(D.ConStr)
        Dim Com As SqlCommand = New SqlCommand("GetNewBookingNo", Cn)
        Dim B As String
        Dim N As Long
        Com.CommandType = CommandType.StoredProcedure
        Com.Parameters.Add("@PreFix", SqlDbType.NVarChar)
        Com.Parameters("@PreFix").Value = P

        Dim DT As New DataTable
        Dim DA As SqlDataAdapter = New SqlDataAdapter(Com)
        Try
            Com.Connection.Open()
            DA.Fill(DT)
            If IsDBNull(DT.Rows(0).Item(0)) Then
                Return P & "00001"
            Else
                B = DT.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Cn.Close()
        Cn.Dispose()
        Com.Dispose()
        DA.Dispose()

        B = Mid(B, 8, 5)
        N = CLng(B)
        N += 1
        Select Case CStr(N).Length
            Case 1 : B = P & "0000" & CStr(N)
            Case 2 : B = P & "000" & CStr(N)
            Case 3 : B = P & "00" & CStr(N)
            Case 4 : B = P & "0" & CStr(N)
            Case 5 : B = P & CStr(N)

        End Select
        Return B




    End Function
    Public Function ItemIDToName(ByVal ItemID As String) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select ItemDescription from tblItems Where ItemID = '" & ItemID & "'")
        D = Nothing

    End Function
    Public Function ItemIDToRate(ByVal ItemID As String) As Single
        Dim D As New DAL.DAL
        Return Val(D.GetScaler("Select ItemUnitSaleRate from tblItems Where ItemID = '" & ItemID & "'"))
        D = Nothing

    End Function


    Public Function ItemIDToCost(ByVal ItemID As String) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select ItemAvgCost from tblItems Where ItemID = '" & ItemID & "'")
        D = Nothing

    End Function
    Public Function ItemIDToCompany(ByVal ItemID As String) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select Company from vwItems Where Code = '" & ItemID & "'")
        D = Nothing

    End Function
    Public Function ItemIDToCategory(ByVal ItemID As String) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select Category from vwItems Where Code = '" & ItemID & "'")
        D = Nothing

    End Function

    Public Function ItemIDToStock(ByVal ItemID As String) As Double
        Dim D As New DAL.DAL
        Return D.GetScaler("Select Sum(stDR)- Sum(stCR) from tblStock Where stItemID = '" & ItemID & "'")
        D = Nothing

    End Function
    Public Function ItemIDToStock(ByVal ItemID As String, ByVal BeforeDate As Date) As String
        Dim D As New DAL.DAL
        'Return D.GetScaler("Select Sum(stDR)- Sum(stCR) from tblStock Where stItemID = '" & ItemID & "' and convert(varchar(10),stDate,105) < '" & Format(BeforeDate, "dd-MM-yyyy") & "'")
        Return D.GetScaler("Select Sum(stDR)- Sum(stCR) from tblStock Where stItemcode = '" & ItemID & "' and stDate < '" & BeforeDate & "'")

        D = Nothing

    End Function
    Public Function ItemIDToName(ByVal ItemID As String, ByRef Rate As Double, ByRef Cost As Double) As String
        Dim D As New DAL.DAL
        Dim DT As New DataTable
        Dim iName As String
        Dim iRate As Double
        Dim iCost As Double
        DT = D.GetDataTable("SELECT ItemName, ItemUnitPurRate, ItemUnitSaleRate FROM tblItems WHERE ItemID = '" & ItemID & "'")
        If DT.Rows.Count = 0 Then
            iName = ""
        Else
            iRate = CDbl(DT.Rows(0).Item("ItemUnitSaleRate"))
            iCost = CDbl(DT.Rows(0).Item("ItemUnitPurRate"))
            iName = DT.Rows(0).Item("ItemName")
        End If
        D = Nothing
        DT.Dispose()

        If iName = "" Then
            Return ""
        Else
            Rate = iRate
            Cost = iCost
            Return iName
        End If
    End Function
    Public Function ItemIDtoUnit(ByVal ItemID As String) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select unitShortName FROM tblItems LEFT OUTER JOIN tblItemUnits ON tblItems.ItemUnitID = tblItemUnits.unitID WHERE ItemID = N'" & ItemID & "'")
        D = Nothing
    End Function

    Public Sub UpdateItemStock(ByVal ItemID As String)
        Dim S As String
        Dim D As New DAL.DAL
        Dim C As Double = D.GetScaler("Select sum(stDR) - sum(stCR) from tblStock Where stItemCode = '" & ItemID & "'")
        S = "Update tblItems set ItemCurrStock = " & C & " where ItemID ='" & ItemID & "'"
        D.ExecuteNonQuery(S)
        D = Nothing
    End Sub
    Public Function LocationIDtoName(ByVal ID As Long) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select stlName from tblStockLocations Where stlID = " & ID)
        D = Nothing
    End Function
    Public Function CurrentLocationID() As Long
        Return GetSetting("POS", "SALE", "StockLocationID", 0)
    End Function
    Public Sub UpdateItemAverage(ByVal ItemID As String, ByVal CurrentCost As Single)
        Dim strSQL As String
        Dim D As New DAL.DAL
        Dim TotalPurQty As Single
        Dim TotalValue As Single
        Dim AverageCost As Single
        strSQL = "Select sum(stDR) from tblStock where stItemCode = '" & ItemID & "' and stType IN ('PUR','OP')"
        TotalPurQty = Val(D.GetScaler(strSQL))
        strSQL = "Select Sum(stCost * stDR) from tblStock where stItemCode = '" & ItemID & "' and stType IN ('PUR','OP')"
        TotalValue = Val(D.GetScaler(strSQL))
        If TotalPurQty > 0 Then
            AverageCost = TotalValue / TotalPurQty
        Else
            AverageCost = CurrentCost
        End If

        strSQL = "Update tblItems set ItemAvgCost = " & AverageCost & " where ItemID ='" & ItemID & "'"
        D.ExecuteNonQuery(strSQL)
        D = Nothing
    End Sub
    Public Function GetSettingValue(ByVal SettingName As String) As String
        Dim D As New DAL.DAL
        Return D.GetScaler("Select settingValue from tblSettings where settingName ='" & SettingName & "'")

    End Function
    Public Function Val1(ByVal Amt As String) As Single
        Dim S As String
        S = Replace(Amt, ",", "")
        Return Val(S)

    End Function

End Module
