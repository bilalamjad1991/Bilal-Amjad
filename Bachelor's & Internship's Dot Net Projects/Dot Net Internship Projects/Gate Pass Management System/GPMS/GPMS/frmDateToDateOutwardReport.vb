Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmDateToDateOutwardReport
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim cryRpt As New ReportDocument
        cryRpt.Load("C:\Users\BILAL\Desktop\GatePass - 23 Dec 14 reporting 4-21\GPMS\GPMS\DateToDateOutwardReport.rpt")

        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterRangeValue As New ParameterRangeValue

            crParameterRangeValue.StartValue = DateTimePicker1.Value
            crParameterRangeValue.EndValue = DateTimePicker2.Value
            crParameterFieldDefinitions =
            cryRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("Date")
            crParameterValues = crParameterFieldDefinition.CurrentValues

            crParameterValues.Clear()
            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()

        Catch ex As Exception
            ' MsgBox("Can't load Web page" & vbCrLf & ex.Message)
            MsgBox("Start And End Date Can't Be Same!")
        End Try
    End Sub

    Private Sub frmDateToDateOutwardReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class