Imports Microsoft.Reporting.WinForms
Imports Negocio.Negocio.Traductor

Public Class ReporteBitacora
    Private Sub ReporteBitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class