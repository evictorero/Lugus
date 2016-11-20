Imports Microsoft.Reporting.WinForms
Imports Negocio.Negocio.Traductor

Public Class ReportePedidos

    Private Sub ReportePedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbEstado.DisplayMember = "Key"
        cmbEstado.ValueMember = "Value"

        cmbEstado.Items.Add(New DictionaryEntry("INGRESADO", "I"))
        cmbEstado.Items.Add(New DictionaryEntry("EN CURSO", "E"))
        cmbEstado.Items.Add(New DictionaryEntry("FINALIZADO", "F"))

        cmbEstado.SelectedIndex = 0

        dtpFechaDesde.CustomFormat = "dd/MM/yyyy"
        dtpFechaHasta.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub btn_ejecutar_Click(sender As Object, e As EventArgs) Handles btn_ejecutar.Click
        Dim mPedido As New Negocio.Negocio.Pedido

        Dim mFechaDesde As Date
        Dim mFechaHasta As Date
        Dim mEstado As String

        ' lleno los parámetros del filtro, si tilda todos envío NULL
        If chkEstado.Checked Then
            mEstado = Nothing
        Else
            mEstado = Me.cmbEstado.SelectedItem.Value
        End If

        If chkFechas.Checked Then
            mFechaDesde = Nothing
            mFechaHasta = Nothing
        Else
            mFechaDesde = Me.dtpFechaDesde.Value
            mFechaHasta = Me.dtpFechaHasta.Value
        End If

        Dim rptDataSource As ReportDataSource
        rptDataSource = New ReportDataSource("DataSetPedidos", (New Negocio.Negocio.Pedido).ListarConFiltro(mEstado, mFechaDesde, mFechaHasta))

        ' elimino datasource existente y cargo el nuevo
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub chkEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstado.CheckedChanged
        If chkEstado.Checked Then
            cmbEstado.Enabled = False
        Else
            cmbEstado.Enabled = True
        End If
    End Sub

    Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechas.CheckedChanged
        If chkFechas.Checked Then
            dtpFechaDesde.Enabled = False
            dtpFechaHasta.Enabled = False
        Else
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
        End If
    End Sub

End Class