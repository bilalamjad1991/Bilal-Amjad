Public Class frmAllItemsShort
    Dim DT As New DataTable
    Dim D As New DAL.DAL
    Dim BS As New BindingSource
    Public MyOpt As String
    Private Sub frmAllItemsShort_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DT.Dispose()
        D = Nothing
        BS.Dispose()
    End Sub
    Private Sub frmAllItemsShort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        FillData()
    End Sub
    Public Sub FillData()

        DT = D.GetDataTable("SELECT Code, Description, [Short Description], Category, Unit, Vendor FROM vwItems")
        BS.Filter = ""
        BS.DataSource = DT
        Grid.DataSource = BS
        Dim C As Long = D.GetScaler("Select Count(ItemID) from tblItems")
        ToolStripStatusLabel1.Text = "Total: " & C
        ToolStripStatusLabel2.Text = "Found: " & Grid.Rows.Count
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect.Click
        If Grid.Rows.Count = 0 Then
            MsgBox("No item is selected", MsgBoxStyle.Information, CName)
            Exit Sub
        End If
        If MyOpt = "INDENT" Then
            With frmIndent
                .txtItemCode.Text = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value
                .txtItemDescription.Text = Grid.Rows(Grid.CurrentRow.Index).Cells("colDescription").Value
                .FillItemOtherDetail(Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value)
                .txtQuantity.Focus()
            End With
        
        ElseIf MyOpt = "INWARD" Then
            With frmInwardGatePass
                .txtItemID.Text = Grid.CurrentRow.Cells("colItemID").Value
                .txtDescription.Text = Grid.CurrentRow.Cells("colDescription").Value
                .txtUnit.Text = Grid.CurrentRow.Cells("colUnit").Value
                .txtBrand.Focus()
            End With
        ElseIf MyOpt = "SAL" Then
            'With frmSale
            '    .txtItemID.Text = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value
            '    .txtItemName.Text = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemName").Value
            '    .txtRate.Text = Val(Grid.Rows(Grid.CurrentRow.Index).Cells("colRate").Value)
            '    .txtQuantity.Text = 1
            '    .txtRate.Focus()
            '    .txtRate.SelectAll()
            'End With
        ElseIf MyOpt = "ITEMLEDGER" Then
            'With frmItemLedger
            '    .txtItemID.Text = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value
            '    .txtItemName.Text = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemName").Value
            '    Me.DialogResult = Windows.Forms.DialogResult.OK
            'End With
        ElseIf MyOpt = "PURRET" Then
            'With frmPurchaseReturns
            '    .txtItemID.Text = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value
            '    Dim C As Double, R As Double
            '    .txtItemName.Text = ItemIDToName(Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value, R, C)

            '    .txtRate.Text = Val(C)
            '    .txtRate.Focus()
            '    .txtRate.SelectAll()
            'End With

        ElseIf MyOpt = "TRANS" Then
            'With frmStockTransfer
            '    .txtItemID.Text = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value
            '    Dim C As Double, R As Double
            '    .txtItemName.Text = ItemIDToName(Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value, R, C)
            '    '.txtRate.Text = Val(C)
            '    '.txtRate.Focus()
            '    '.txtRate.SelectAll()
            '    .txtQuantity.Focus()
            'End With
        ElseIf MyOpt = "PRINTBC" Then
            'With frmPrintBarcode
            '    Dim ItemID As String = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value
            '    .txtItemID.Text = ItemID
            '    Dim C As Double, R As Double
            '    .txtItemName.Text = ItemIDToName(ItemID, R, C)
            '    .txtCompany.Text = ItemIDToCompany(ItemID)
            '    .txtCategory.Text = ItemIDToCategory(ItemID)
            '    .txtRate.Text = Val(C)
            '    .txtQuantity.Focus()
            'End With
        End If
        Me.Close()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'BS.Filter = "Name + Category + Company like '%" & txtFind.Text & "%'"
        'ToolStripStatusLabel2.Text = "Found : " & Grid.Rows.Count
        'If Grid.Rows.Count > 0 Then
        '    Grid.Focus()
        'End If
    End Sub

    Private Sub txtFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyDown
        If e.KeyCode = Keys.Enter Then Grid.Focus()
    End Sub

    

    

    Private Sub txtFind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFind.TextChanged
        BS.Filter = "code + Description + [Short Description] + vendor like '%" & txtFind.Text & "%'"
        ToolStripStatusLabel2.Text = "Items Filtered : " & Grid.Rows.Count

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        FillData()
        txtFind.Text = ""
        txtFind.Focus()
    End Sub

    Private Sub cmdShowDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowDetail.Click
        If Grid.Rows.Count > 0 Then
            frmItemDetail.ItemID = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value
            frmItemDetail.MdiParent = Me.MdiParent
            frmItemDetail.Show()
        End If
    End Sub

    Private Sub cmdPreviousPurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousPurchase.Click
        'If Grid.Rows.Count > 0 Then
        '    frmItemPurchaseHistory.ItemID = Grid.Rows(Grid.CurrentRow.Index).Cells("colItemID").Value
        '    frmItemPurchaseHistory.MdiParent = frmMain2
        '    frmItemPurchaseHistory.Show()
        'End If

    End Sub

    
    Private Sub cmdAddNew_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddNew.Click
        frmItemsAdd.MyOPT = "ALLITEMS"
        frmItemsAdd.MdiParent = frmMain
        frmItemsAdd.Show()
    End Sub
End Class