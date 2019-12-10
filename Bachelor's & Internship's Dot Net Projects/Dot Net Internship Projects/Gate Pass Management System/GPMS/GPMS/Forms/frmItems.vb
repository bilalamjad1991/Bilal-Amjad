Imports System.Data
Imports System.Data.SqlClient

Public Class frmItems
    Dim FormLoading As Boolean
    Dim ComboLoading As Boolean
    Dim DM As DAL.DAL.DataMode
    Dim D As New DAL.DAL
    Private Sub frmItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DM = DAL.DAL.DataMode.SavedRecord
        FormLoading = True
        Lockall(True)
        FillCombos()
        FillGrid()
        FormLoading = False
    End Sub
    Sub FillGrid()
        GridItems.DataSource = D.GetDataTable("Select Code, Description, Unit, Category from vwItems Order By Code")
        GridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        lblTotalItems.Text = "Total Items: " & Val(D.GetScaler("Select Count(ItemID) from tblItems"))

    End Sub
    Sub FillCombos()
        FillCatagories()
        FillUnits()
        FillVendors()
    End Sub
    Sub FillCatagories()
        ComboLoading = True
        Dim DT As New DataTable
        DT = D.GetDataTable("Select CatID,CatName from tblItemCategories")
        cmbCategory.DataSource = DT
        cmbCategory.DisplayMember = "CatName"
        cmbCategory.ValueMember = "CatID"
        cmbCategory.SelectedIndex = -1
        ComboLoading = False
    End Sub
    Sub FillVendors()
        ComboLoading = True
        Dim DT As New DataTable
        DT = D.GetDataTable("Select accID, accCompany from tblAccounts")
        cmbVendors.DataSource = DT
        cmbVendors.DisplayMember = "accCompany"
        cmbVendors.ValueMember = "accID"
        cmbVendors.SelectedIndex = -1
        ComboLoading = False
    End Sub

    Sub FillUnits()
        ComboLoading = True
        Dim DT As New DataTable
        DT = D.GetDataTable("Select unitid, unitname + ' (' +  unitShortName + ')' as uName from tblItemUnits")
        cmbUnits.DataSource = DT
        cmbUnits.DisplayMember = "uName"
        cmbUnits.ValueMember = "unitID"
        cmbUnits.SelectedIndex = -1
        ComboLoading = False
    End Sub
    
    Sub Lockall(ByVal OK As Boolean)
        cmdAdd.Enabled = OK
        cmdSave.Enabled = Not OK
        cmdCancel.Enabled = Not OK
        cmdEdit.Enabled = OK
        cmdClose.Enabled = OK

        grpItemDetail.Enabled = Not OK
        grpList.Enabled = OK


    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Lockall(False)
        ClearAll()
        DM = DAL.DAL.DataMode.NewRecord
        cmbCategory.Enabled = True
        cmbCategory.Focus()
        txtItemCode.Focus()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Lockall(True)

        With GridItems
            If .Rows.Count > 0 Then
                FillData(.Rows(.CurrentRow.Index).Cells("colCode").Value)
            End If
        End With
        txtItemCode.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Sub ClearAll()
        'txtItemCodeOld.Text = ""
        txtItemCode.Clear()
        cmbCategory.SelectedIndex = -1
        txtDescription.Text = ""
        txtShortDescription.Text = ""
        cmbUnits.SelectedIndex = -1
        cmbVendors.SelectedIndex = -1

    End Sub

    Sub FillData(ByVal ItemID As String)
        Me.Cursor = Cursors.WaitCursor
        ClearAll()
        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblItems where ItemID='" & ItemID & "'")
        With DT
            If DT.Rows.Count > 0 Then
                'tbItem 
                txtItemCode.Text = .Rows(0).Item("ItemID")
                cmbCategory.SelectedValue = .Rows(0).Item("catID")
                txtDescription.Text = .Rows(0).Item("ItemDescription")
                txtShortDescription.Text = .Rows(0).Item("ItemShortDescription")
                cmbUnits.SelectedValue = .Rows(0)("ItemUnitID")
                cmbVendors.SelectedValue = .Rows(0)("ItemPrefferedVenID")

            End If
        End With
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub GridItems_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridItems.SelectionChanged
        With GridItems
            If .Rows.Count > 0 Then
                FillData(.Rows(.CurrentRow.Index).Cells("colCode").Value)
            End If
        End With
    End Sub

    Private Sub cmbCompany_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")

    End Sub

    Private Sub cmbCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then cmbCompany.Focus()
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged
        'If DM = DAL.DAL.DataMode.NewRecord Then
        '    txtItemCodeOld.Text = GetNewItemCode(cmbCategory.SelectedValue)
        'End If
    End Sub
    Function GetNewItemCode(ByVal CatID As String)
        Me.Cursor = Cursors.WaitCursor
        Dim S As String
        Dim N As Long
        If CatID = "" Then
            Me.Cursor = Cursors.Default
            Return ""
        End If
        S = D.GetScaler("Select Max(ItemID) from tblItems Where CatID ='" & CatID & "'")
        If S = "" Then
            Me.Cursor = Cursors.Default
            Return CatID & "00001"
        Else
            N = Mid(S, 4, 5)
            N += 1
            S = N
            Select Case Len(S)
                Case 1 : S = CatID & "0000" & S
                Case 2 : S = CatID & "000" & S
                Case 3 : S = CatID & "00" & S
                Case 4 : S = CatID & "0" & S
                Case 5 : S = CatID & S
            End Select
            Me.Cursor = Cursors.Default
            Return S
        End If
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Not DataIsValid() Then Exit Sub
        SaveRec()

    End Sub
    Sub SaveRec()
        Dim QB As New QueryBuilder("tblItems")
        Dim strSQL As String
        With QB
            .AddField("ItemID", txtItemCode.Text, FieldType.Text)
            .AddField("CatID", cmbCategory.SelectedValue, FieldType.Text)
            .AddField("ItemDescription", txtDescription.Text, FieldType.Text)
            .AddField("ItemShortDescription", txtShortDescription.Text, FieldType.Text)
            .AddField("ItemUnitID", cmbUnits.SelectedValue, FieldType.Numeric)
            .AddField("ItemPrefferedVenID", cmbVendors.SelectedValue, FieldType.Text)
        End With
        If DM = DAL.DAL.DataMode.NewRecord Then
            strSQL = QB.GetInsertQuery
        ElseIf DM = DAL.DAL.DataMode.EditRecord Then
            QB.RemoveField("ItemID")
            QB.InsertDeleteFilterField("ItemID", txtItemCode.Text, FieldType.Text)
            strSQL = QB.GetUpdateQuery
        End If
        Dim strSql2 As String


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
            Exit Sub
        Finally
            C = Nothing
            COM = Nothing
            QB = Nothing

        End Try
        'UpdateItemAverage(txtItemCode.Text, txtUnitPurchasePrice.Text)
        Me.Cursor = Cursors.Default
        MsgBox("Data of Item is saved", MsgBoxStyle.Information, CName)
        FillGrid()
        'ClearAll()
        txtItemCode.Enabled = True
        Lockall(True)
        cmdFillCatagories.Enabled = True
        DM = DAL.DAL.DataMode.SavedRecord
        cmdAdd.Focus()
    End Sub


    Function DataIsValid() As Boolean
        DataIsValid = True
        If Not txtItemCode.MaskCompleted Then
            txtItemCode.Focus()
            MsgBox("Please enter complete item code", MsgBoxStyle.Critical, CName)
            Return False
        End If
        If DM = DAL.DAL.DataMode.NewRecord Then
            If D.IsRecordExists("tblItems", "ItemID", txtItemCode.Text) Then
                txtItemCode.Focus()
                txtItemCode.SelectAll()
                MsgBox("This item code already exist in record", MsgBoxStyle.Critical, CName)
                Return False
            End If
        End If
        If cmbCategory.SelectedIndex = -1 Then
            cmbCategory.Focus()
            MsgBox("Please select a Catagory from the list", MsgBoxStyle.Critical, CName)
            Return False
        End If

        If txtDescription.TextLength = 0 Then
            txtDescription.Focus()
            MsgBox("Please enter a valid item description", MsgBoxStyle.Critical, CName)
            Return False
        End If
        If DM = DAL.DAL.DataMode.EditRecord Then
            Dim CurrItemName As String = D.GetScaler("Select ItemDescription from tblItems Where ItemID = '" & txtItemCode.Text & "'")
            If txtDescription.Text <> CurrItemName And D.IsRecordExists("tblItems", "ItemDescription", txtDescription.Text) Then
                txtDescription.Focus()
                txtDescription.SelectAll()
                MsgBox("This item name already exist in record", MsgBoxStyle.Critical, CName)
                Return False
            End If

        ElseIf DM = DAL.DAL.DataMode.NewRecord Then
        If D.IsRecordExists("tblItems", "ItemDescription", txtDescription.Text) Then
            txtDescription.Focus()
            txtDescription.SelectAll()
            MsgBox("This item name already exist in record", MsgBoxStyle.Critical, CName)
            Return False
        End If
        End If



        If txtShortDescription.TextLength = 0 Then
            txtShortDescription.Focus()
            MsgBox("Please enter a valid short description", MsgBoxStyle.Critical, CName)
            Return False
        End If
        If cmbUnits.SelectedIndex = -1 Then
            cmbUnits.Focus()
            MsgBox("Please select a valid Unit of measurement", MsgBoxStyle.Critical, CName)
            Return False
        End If
        If cmbVendors.SelectedIndex = -1 Then
            cmbVendors.Focus()
            MsgBox("Please select a vendor from the list", MsgBoxStyle.Critical, CName)
            Return False
        End If

    End Function

    Private Sub txtItemName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DM = DAL.DAL.DataMode.NewRecord Then
            txtShortDescription.Text = txtDescription.Text

        End If

    End Sub
























    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        DM = DAL.DAL.DataMode.EditRecord
        Lockall(False)
        txtDescription.Focus()
        txtItemCode.Enabled = False
        cmdFillCatagories.Enabled = False

    End Sub

    Private Sub cmdFindItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindItem.Click
        Me.Cursor = Cursors.WaitCursor
        GridItems.DataSource = D.GetDataTable("Select Code, Description, Unit, Category from vwItems Where Code + Description + Unit + Category Like '%" & txtFindItem.Text & "%' Order By Code")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtFindItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFindItem.GotFocus
        Me.AcceptButton = cmdFindItem
    End Sub

    Private Sub txtFindItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFindItem.LostFocus
        Me.AcceptButton = Nothing
    End Sub

    Private Sub cmdClearSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearSearch.Click
        txtFindItem.Text = ""
        FillGrid()
    End Sub



    Private Sub cmdRefreshCombo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DM = DAL.DAL.DataMode.NewRecord Then
            FillCatagories()
        End If

    End Sub

    Private Sub txtUnitsPerPack_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
        Else
            Call OnlyNumerics(e)
        End If
    End Sub

    Private Sub txtUnitsPerPack_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'txtPackPurchasePrice.Text = Val(txtUnitPurchasePrice.Text) * Val(txtUnitsPerPack.Text)
        'txtPackSalePrice.Text = Val(txtUnitSaleRate.Text) * Val(txtUnitsPerPack.Text)
    End Sub

    Private Sub txtUnitPurchasePrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
        Else
            Call OnlyDecimalNumerics(e, sender)
        End If
    End Sub

    Private Sub txtUnitPurchasePrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'txtPackPurchasePrice.Text = Val(txtUnitPurchasePrice.Text) * Val(txtUnitsPerPack.Text)

    End Sub

    Private Sub txtUnitSaleRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'txtPackSalePrice.Text = Val(txtUnitSaleRate.Text) * Val(txtUnitsPerPack.Text)
    End Sub

    Private Sub cmbLocations_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Escape Then
            cmdSave.Focus()
        End If

    End Sub

    Function Val1(ByVal Amt As String) As Single
        Dim S As String
        S = Replace(Amt, ",", "")
        Return Val(S)

    End Function

    Private Sub cmdFillCatagories_Click(sender As System.Object, e As System.EventArgs) Handles cmdFillCatagories.Click
        FillCatagories()
    End Sub

    Private Sub Label18_Click(sender As System.Object, e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub cmbFillUnits_Click(sender As System.Object, e As System.EventArgs) Handles cmbFillUnits.Click
        FillUnits()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FillVendors()
    End Sub

    Private Sub GridItems_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridItems.CellContentClick

    End Sub
End Class
