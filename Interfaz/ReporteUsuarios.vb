Imports Microsoft.Reporting.WinForms

Public Class ReporteUsuarios

    Private Sub ReporteUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' inicio con los combo deshabilitados, por default está en todos
        cbDescripcionFamilia.Enabled = False
        cbDescripcionPatente.Enabled = False

        cbDescripcionPatente.DataSource = (New Negocio.Negocio.Patente).Listar
        cbDescripcionPatente.DisplayMember = "descripcionLarga"
        cbDescripcionPatente.ValueMember = "id"

    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_ejecutar.Click
        Dim rptDataSource As ReportDataSource

        If rbtnFamilia.Checked Then
            rptDataSource = New ReportDataSource("DataSetUsuarios", (New Negocio.Negocio.Usuario).ListarPorFamilia(cbDescripcionFamilia.SelectedValue))
        ElseIf rbtnPatente.Checked Then
            rptDataSource = New ReportDataSource("DataSetUsuarios", (New Negocio.Negocio.Usuario).ListarPorPatente(cbDescripcionPatente.SelectedValue))
        Else
            rptDataSource = New ReportDataSource("DataSetUsuarios", (New Negocio.Negocio.Usuario).Listar())
        End If

        ' elimino datasource existente y cargo el nuevo
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub rbtnTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTodos.CheckedChanged
        cbDescripcionFamilia.Enabled = False
        cbDescripcionPatente.Enabled = False
    End Sub

    Private Sub rbtnFamilia_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFamilia.CheckedChanged
        cbDescripcionFamilia.Enabled = True
        cbDescripcionPatente.Enabled = False
    End Sub

    Private Sub rbtnPatente_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPatente.CheckedChanged
        cbDescripcionFamilia.Enabled = False
        cbDescripcionPatente.Enabled = True
    End Sub

End Class