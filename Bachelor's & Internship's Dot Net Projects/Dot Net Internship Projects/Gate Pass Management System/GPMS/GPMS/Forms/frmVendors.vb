Imports System.Data
Imports System.Data.SqlClient
Public Class frmVendors
    Dim DM As DAL.DAL.DataMode
    Dim D As New DAL.DAL
    Dim ComboLoading As Boolean
    Dim FormLoading As Boolean
    Dim AccTypeID As String = "001"
    Sub BindCities()
        Me.Cursor = Cursors.WaitCursor
        Dim D As New DAL.DAL
        Dim CityName As New AutoCompleteStringCollection
        Dim S As String
        S = "select distinct accCity from tblAccounts"
        Dim DT As New DataTable
        DT = D.GetDataTable(S)
        If DT.Rows.Count > 0 Then
            For N As Integer = 0 To DT.Rows.Count - 1
                If Not IsDBNull(DT.Rows(N)(0)) Then
                    CityName.Add(DT.Rows(N)(0))
                End If
            Next
        End If

        txtCity1.AutoCompleteCustomSource = CityName
        txtCity1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtCity1.AutoCompleteSource = AutoCompleteSource.CustomSource

        Me.Cursor = Cursors.Default
    End Sub
    Sub BindCountries()
        Me.Cursor = Cursors.WaitCursor
        Dim D As New DAL.DAL
        Dim CountryName As New AutoCompleteStringCollection
        Dim S As String
        S = "select distinct accCountry from tblAccounts"
        Dim DT As New DataTable
        DT = D.GetDataTable(S)
        If DT.Rows.Count > 0 Then
            For N As Integer = 0 To DT.Rows.Count - 1
                If Not IsDBNull(DT.Rows(N)(0)) Then
                    CountryName.Add(DT.Rows(N)(0))
                End If
            Next
        End If

        txtCountry.AutoCompleteCustomSource = CountryName
        txtCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtCountry.AutoCompleteSource = AutoCompleteSource.CustomSource

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    Private Sub frmVendord_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DM <> DAL.DAL.DataMode.SavedRecord Then
            MsgBox("Please save or cancel your changes", MsgBoxStyle.Information, CName)

            e.Cancel = True

        End If
    End Sub

    Private Sub frmVendors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormLoading = True
        Lockall(True)
        DM = DAL.DAL.DataMode.SavedRecord
        FillGrid()
        ComboLoading = False
        FormLoading = False

    End Sub
    Sub Lockall(ByVal OK As Boolean)
        cmdAdd.Enabled = OK
        cmdSave.Enabled = Not OK
        cmdCancel.Enabled = Not OK
        cmdEdit.Enabled = OK

        cmdClose.Enabled = OK
        gbBasicInfo.Enabled = Not OK
        gbDetail.Enabled = Not OK
        'chkOpeningBalance.Enabled = Not OK
        cmdFind.Enabled = OK
        cmdClearFind.Enabled = OK
        txtFind.Enabled = OK

        Grid.Enabled = OK

    End Sub

    Sub FillGrid()
        Grid.DataSource = D.GetDataTable("Select Code, Company, Contact, City, Country, Active from vwVendors")
        Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Lockall(False)
        ClearAll()
        txtCode.Text = GetNewVenCode()
        txtCode.Focus()
        DM = DAL.DAL.DataMode.NewRecord
        BindCities()
        BindCountries()
    End Sub
    Sub ClearAll()
        txtCode.Text = ""
        txtCompany.Text = ""
        txtContactPerson.Text = ""
        chkActive.Checked = True

        txtAddress1.Text = ""
        txtCity1.Text = ""
        txtCountry.Text = ""

        txtPhone1.Text = ""
        txtPhone2.Text = ""
        txtMobile.Text = ""
        txtFax.Text = ""
        txtEmail.Text = ""
        txtWebsite.Text = ""
        txtRemarks.Text = ""


    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        DM = DAL.DAL.DataMode.SavedRecord
        Lockall(True)
        cmdAdd.Focus()
        ClearAll()
        txtCode.Enabled = True
    End Sub
    Function GetNewVenCode()
        'Me.Cursor = Cursors.WaitCursor
        'Dim TypeID As String = "001"
        'Dim S As String
        'Dim N As Integer
        'S = D.GetScaler("Select Max(AccID) as M from tblAccounts where accTypeID ='" & TypeID & "'")
        'If S = "" Then
        '    Me.Cursor = Cursors.Default
        '    Return TypeID & "-00001"
        'Else
        '    S = Mid(S, 7, 5)
        '    N = CInt(S)
        '    N += 1
        '    S = N
        '    Select Case Len(S)
        '        Case 1 : S = "0000" & S
        '        Case 2 : S = "000" & S
        '        Case 3 : S = "00" & S
        '        Case 4 : S = "0" & S

        '    End Select
        '    Me.Cursor = Cursors.Default
        '    Return TypeID & "-" & S
        'End If
        Me.Cursor = Cursors.WaitCursor

        Dim S As String
        Dim N As Long
        S = D.GetScaler("Select Max(AccID) as M from tblAccounts where accTypeID ='" & AccTypeID & "'")
        If S = "" Then
            Me.Cursor = Cursors.Default
            Return "0000000001"
        Else
            N = Val(S)
            N += 1
            S = CStr(N)
            Select Case Len(S)
                Case 1 : Return "000000000" & S
                Case 2 : Return "00000000" & S
                Case 3 : Return "0000000" & S
                Case 4 : Return "000000" & S
                Case 5 : Return "00000" & S
                Case 6 : Return "0000" & S
                Case 7 : Return "000" & S
                Case 8 : Return "00" & S
                Case 9 : Return "0" & S
                Case 10 : Return S
            End Select
        End If
    End Function
    Function GetVenHeadID() As String
        'Me.Cursor = Cursors.WaitCursor
        'Dim headID As String = D.GetScaler("Select SettingValue from tblSettings where SettingName = 'HeadAccountIDForVendors'")
        'Return headID
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Not DataIsValid() Then Exit Sub
        SaveRec()
    End Sub
    Function DataIsValid() As Boolean
        DataIsValid = True
        If Len(txtCode.Text) = 0 Then
            MsgBox("Invalid vendor code", MsgBoxStyle.Critical, CName)
            txtCode.Focus()
            Return False
        End If
        If DM = DAL.DAL.DataMode.NewRecord Then
            If D.IsRecordExists("Select AccID from tblAccounts where AccID = '" & txtCode.Text & "' and AccTypeID = '" & AccTypeID & "'") Then
                MsgBox("This account code already exist in record", MsgBoxStyle.Critical, CName)
                txtCode.Focus()
                txtCode.SelectAll()
                Return False
            End If
        End If
        If Len(Trim(txtCompany.Text)) = 0 Then
            MsgBox("Please enter a valid employee name", MsgBoxStyle.Critical, CName)
            txtCompany.Focus()
            Return False
        End If



        Return True
    End Function
    Sub SaveRec()
        Dim QB As New QueryBuilder("tblAccounts")
        Dim strSQL As String
        With QB
            .AddField("accID", txtCode.Text, FieldType.Text)
            .AddField("accTypeID", "001", FieldType.Text)
            .AddField("accCompany", txtCompany.Text, FieldType.Text)
            .AddField("accContactName", txtContactPerson.Text, FieldType.Text)
            .AddField("accAddress", txtAddress1.Text, FieldType.Text)
            .AddField("accCity", txtCity1.Text, FieldType.Text)
            .AddField("accCountry", txtCountry.Text, FieldType.Text)
            .AddField("accPhone1", txtPhone1.Text, FieldType.Text)
            .AddField("accPhone2", txtPhone2.Text, FieldType.Text)
            .AddField("accMobile", txtMobile.Text, FieldType.Text)
            .AddField("accFax", txtFax.Text, FieldType.Text)
            .AddField("accEmail", txtEmail.Text, FieldType.Text)
            .AddField("accWebsite", txtWebsite.Text, FieldType.Text)
            .AddField("accNotes", txtRemarks.Text, FieldType.Text)
            .AddField("accActive", "True", FieldType.Text)
        End With
        If DM = DAL.DAL.DataMode.NewRecord Then
            strSQL = QB.GetInsertQuery
        ElseIf DM = DAL.DAL.DataMode.EditRecord Then
            QB.RemoveField("accID")
            QB.InsertDeleteFilterField("accID", txtCode.Text, FieldType.Text)
            strSQL = QB.GetUpdateQuery
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim C As New SqlConnection
        Dim COM As New SqlCommand
        Dim T As SqlTransaction
        Try
            C.ConnectionString = D.ConStr
            C.Open()
            T = C.BeginTransaction(IsolationLevel.ReadCommitted)
            COM.Connection = C
            COM.Transaction = T
            COM.CommandText = strSQL
            COM.ExecuteNonQuery()
            T.Commit()
        Catch e As Exception
            T.Rollback()
            MsgBox("Following error occured While saving data" & vbCr & e.Message & vbCr & "Contact SciTechIS", vbCritical, "SciTechIS")
            Me.Cursor = Cursors.Default
            Me.Cursor = Cursors.Default
            Exit Sub
        Finally
            C = Nothing
            COM = Nothing
            QB = Nothing
        End Try
        Me.Cursor = Cursors.Default
        MsgBox("Data of vendor is saved", MsgBoxStyle.Information, CName)
        FillGrid()
        ClearAll()
        Lockall(True)
        cmdAdd.Focus()
        DM = DAL.DAL.DataMode.SavedRecord
        txtCode.Enabled = True
    End Sub

    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        With Grid
            If .Rows.Count > 0 Then
                FillData(.Rows(.CurrentRow.Index).Cells("colCode").Value)
            End If
        End With
    End Sub
    Private Sub Grid_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.SelectionChanged
        With Grid
            If .Rows.Count > 0 Then
                FillData(.Rows(.CurrentRow.Index).Cells("colCode").Value)
            End If
        End With

    End Sub
    Sub FillData(ByVal AccID As String)
        Me.Cursor = Cursors.WaitCursor
        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from vwVendors Where Code = '" & AccID & "'")
        With DT
            'Not IsDBNull(DT.Rows(N)(0))

            If DT.Rows.Count > 0 Then
                txtCode.Text = .Rows(0).Item("Code")
                txtCompany.Text = .Rows(0).Item("Company")
                txtContactPerson.Text = IIf(IsDBNull(.Rows(0).Item("Contact")), "", .Rows(0).Item("Contact"))
                chkActive.Checked = .Rows(0).Item("Active")
                txtAddress1.Text = IIf(IsDBNull(.Rows(0).Item("Address")), "", .Rows(0).Item("Address"))
                txtCity1.Text = IIf(IsDBNull(.Rows(0).Item("City")), "", .Rows(0).Item("City"))
                txtCountry.Text = IIf(IsDBNull(.Rows(0).Item("Country")), "", .Rows(0).Item("Country"))
                txtPhone1.Text = IIf(IsDBNull(.Rows(0).Item("Phone")), "", .Rows(0).Item("Phone"))
                txtPhone2.Text = IIf(IsDBNull(.Rows(0).Item("Phone-2")), "", .Rows(0).Item("Phone-2"))
                txtMobile.Text = IIf(IsDBNull(.Rows(0).Item("Mobile")), "", .Rows(0).Item("Mobile"))
                txtFax.Text = IIf(IsDBNull(.Rows(0).Item("Fax")), "", .Rows(0).Item("Fax"))
                txtEmail.Text = IIf(IsDBNull(.Rows(0).Item("Email")), "", .Rows(0).Item("Email"))
                txtWebsite.Text = IIf(IsDBNull(.Rows(0).Item("Website")), "", .Rows(0).Item("Website"))
                txtRemarks.Text = IIf(IsDBNull(.Rows(0).Item("Remarks")), "", .Rows(0).Item("Remarks"))
            End If
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If Len(txtCode.Text) = 0 Then
            MsgBox("Please select record from table", vbInformation, CName)
            Grid.Focus()
            Exit Sub
        End If
        DM = DAL.DAL.DataMode.EditRecord

        Lockall(False)
        txtCode.Enabled = False
        txtCompany.Focus()
    End Sub



    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim S As String
        S = "Select Code, Company, Contact, City, Country, Active from vwVendors WHERE Code + Company + Contact + City + Country  like '%" & txtFind.Text & "%'"
        Grid.DataSource = D.GetDataTable(S)
        If Grid.Rows.Count > 0 Then

            Grid.Focus()
        Else
            MsgBox("Sorry, No record found for given criteria", vbInformation, CName)


        End If
    End Sub

    Private Sub cmdClearFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearFind.Click
        FillGrid()
        txtFind.Clear()

    End Sub

    Private Sub txtFind_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFind.GotFocus
        Me.AcceptButton = cmdFind
        Me.CancelButton = cmdClearFind
    End Sub

    Private Sub txtFind_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFind.LostFocus
        Me.AcceptButton = Nothing
        Me.CancelButton = Nothing
    End Sub


    Private Sub txtFind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFind.TextChanged

    End Sub

    Private Sub Grid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellContentClick

    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        Call OnlyNumerics(e)

    End Sub

    Private Sub txtCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCode.TextChanged

    End Sub

    Private Sub txtCode_Validated(sender As Object, e As System.EventArgs) Handles txtCode.Validated
        Dim S As String
        S = txtCode.Text
        Select Case Len(S)
            Case 1 : txtCode.Text = "000000000" & S
            Case 2 : txtCode.Text = "00000000" & S
            Case 3 : txtCode.Text = "0000000" & S
            Case 4 : txtCode.Text = "000000" & S
            Case 5 : txtCode.Text = "00000" & S
            Case 6 : txtCode.Text = "0000" & S
            Case 7 : txtCode.Text = "000" & S
            Case 8 : txtCode.Text = "00" & S
            Case 9 : txtCode.Text = "0" & S

        End Select

    End Sub
End Class