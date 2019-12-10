Public Class frmItemDetail

    
    Public ItemID As String
    Dim D As New DAL.DAL
    Private Sub frmShowDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim DT As New DataTable
        'DT.Clear()
        'DT = D.GetDataTable("SELECT stlName as Location, ISNULL((SELECT SUM(stDR) - SUM(stCR) From tblStock WHERE (tblStock.stLocationID = tblStockLocations.stlID) AND (tblStock.stItemCode = '" & ItemID & "')),0) AS Stock From tblStockLocations")
        'GridStock.DataSource = DT
        'Dim TS As Double
        'For Each R As DataGridViewRow In GridStock.Rows
        '    TS += R.Cells("colStock").Value
        'Next
        'txtTotal.Text = TS



        DT = D.GetDataTable("Select * from vwItems Where Code = '" & ItemID & "'")
        'On Error Resume Next
        lblCode.Text = ItemID
        lblDescription.Text = DT.Rows(0).Item("Description")
        lblShortDescription.Text = DT.Rows(0).Item("Short Description")
        For Each C As DataColumn In DT.Columns
            If Not IsDBNull(DT.Rows(0).Item(C.ColumnName)) Then
                Grid.Rows.Add(New String() {C.Caption, DT.Rows(0).Item(C.ColumnName)})
            End If
        Next
       
        
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class