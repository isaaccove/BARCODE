Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class Printbarcode
    Inherits Windows.Forms.Form
    Dim crp As New CrystalReport1
    Dim mylog As CrystalDecisions.Shared.TableLogOnInfo
    Dim sy As String
    Dim mty As CrystalDecisions.CrystalReports.Engine.Table


    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

        crp = New CrystalReport1
        For Each Me.mty In crp.Database.Tables
            mylog = mty.LogOnInfo
            mylog.ConnectionInfo.DatabaseName = "barcodedb"
            mylog.ConnectionInfo.UserID = "sa"
            mylog.ConnectionInfo.ServerName = "COVEBABA\COVE"
            mylog.ConnectionInfo.Password = "cove1"
            mty.ApplyLogOnInfo(mylog)

        Next
        sy = "{barcodetb.barcode}='" & BACODEGEN.TXT1.Text & "'"
        crp.RecordSelectionFormula = sy
        CrystalReportViewer1.ReportSource = crp

    End Sub
End Class