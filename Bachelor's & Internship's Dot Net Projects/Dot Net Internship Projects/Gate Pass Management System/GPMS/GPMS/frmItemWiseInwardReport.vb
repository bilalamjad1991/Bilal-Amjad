Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmItemWiseInwardReport

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim cryRpt As New ReportDocument
        cryRpt.Load("C:\Users\BILAL\Desktop\GatePass - 23 Dec 14 reporting 4-21\GPMS\GPMS\ItemWiseInwardReport.rpt")

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        crParameterDiscreteValue.Value = TextBox1.Text
        crParameterFieldDefinitions =
        cryRpt.DataDefinition.ParameterFields
        crParameterFieldDefinition =
   crParameterFieldDefinitions.Item("Item")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class