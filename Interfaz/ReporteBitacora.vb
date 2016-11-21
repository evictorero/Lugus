Imports Microsoft.Reporting.WinForms
Imports Negocio.Negocio.Traductor

Public Class ReporteBitacora
    Private Sub ReporteBitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim mBitacora As New Negocio.Negocio.Bitacora
        Dim mUsuario As Integer
        Dim mFechaDesde As Date
        Dim mFechaHasta As Date
        Dim mCriticidad As String
        Dim mOrden As String

        ' lleno los parámetros del filtro, si tilda todos envío NULL
        If chkUsuario.Checked Then
            mUsuario = Nothing
        Else
            mUsuario = Me.cmbUsuario.SelectedValue
        End If

        If chkFechas.Checked Then
            mFechaDesde = Nothing
            mFechaHasta = Nothing
        Else
            mFechaDesde = Me.dtpFechaDesde.Value
            mFechaHasta = Me.dtpFechaHasta.Value
        End If

        If chkCriticidad.Checked Then
            mCriticidad = Nothing
        Else
            If rbtnAlta.Checked Then
                mCriticidad = "Alta"
            ElseIf rbtnMedia.Checked Then
                mCriticidad = "Media"
            Else
                mCriticidad = "Baja"
            End If
        End If

        If OrdenarCriticidad.Checked Then
            mOrden = "criticidad"
        ElseIf OrdenarFecha.Checked Then
            mOrden = "fecha"
        Else
            mOrden = "id_usuario"
        End If

        Dim rptDataSource As ReportDataSource
        rptDataSource = New ReportDataSource("DataSetBitacora", (New Negocio.Negocio.Bitacora).ListarConFiltro(mUsuario,
                                                                                   mFechaDesde,
                                                                                   mFechaHasta,
                                                                                   mCriticidad,
                                                                                   mOrden))

        ' elimino datasource existente y cargo el nuevo
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub chkUsuario_CheckedChanged(sender As Object, e As EventArgs)
        If chkUsuario.Checked Then
            cmbUsuario.Enabled = False
        Else
            cmbUsuario.Enabled = True
        End If
    End Sub

    Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs)
        If chkFechas.Checked Then
            dtpFechaDesde.Enabled = False
            dtpFechaHasta.Enabled = False
        Else
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
        End If
    End Sub

    Private Sub chkCriticidad_CheckedChanged(sender As Object, e As EventArgs)
        If chkCriticidad.Checked Then
            rbtnAlta.Enabled = False
            rbtnMedia.Enabled = False
            rbtnBaja.Enabled = False
        Else
            rbtnAlta.Enabled = True
            rbtnMedia.Enabled = True
            rbtnBaja.Enabled = True
        End If
    End Sub
End Class