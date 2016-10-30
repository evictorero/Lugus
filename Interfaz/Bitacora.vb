Imports Negocio.Negocio.Traductor

Public Class Bitacora
    Private Sub Bitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim listaUsuarios As List(Of Negocio.Negocio.Usuario) = (New Negocio.Negocio.Usuario).Listar

        cmbUsuario.DisplayMember = "nombre"
        cmbUsuario.ValueMember = "id"
        cmbUsuario.DataSource = listaUsuarios

        If cmbUsuario.SelectedIndex >= 0 Then
            cmbUsuario.SelectedIndex = 0
        End If

        dtpFechaDesde.Value = New DateTime(1900, 1, 1)
        dtpFechaHasta.Value = Date.Now

        chkUsuario.Checked = True
        chkFechas.Checked = True
        chkCriticidad.Checked = True

        'Seteo de aspecto de la grilla
        With Me.dvgBitacora
            .AllowDrop = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            With .Columns
                .Add("cid", "Código")
                .Item(0).DataPropertyName = "id"
                '.Item(0).Width = 100
                .Item(0).Visible = False
                '
                .Add("cdescripcionlarga", "Descripcion")
                .Item(1).DataPropertyName = "DescripcionLarga"
                .Item(1).Width = 200

                .Add("cfecha", "Fecha")
                .Item(2).DataPropertyName = "fecha"
                .Item(2).Width = 150
                .Item(2).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"

                .Add("ccriticidad", "Criticidad")
                .Item(3).DataPropertyName = "criticidad"
                .Item(3).Width = 80


            End With

        End With

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim mBitacora As New Negocio.Negocio.Bitacora

        Me.dvgBitacora.DataSource = (New Negocio.Negocio.Bitacora).ListarConFiltro(Me.cmbUsuario.SelectedValue,
                                                                                   Me.dtpFechaDesde.Value,
                                                                                   Me.dtpFechaHasta.Value,
                                                                                   "Baja")

        If Me.dvgBitacora.RowCount = 0 Then
            Me.txtMensaje.Text = ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen bitácoras ingresadas en el sistema")
        Else
            Me.txtMensaje.Text = ""
        End If
    End Sub

    Private Sub chkUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsuario.CheckedChanged
        If chkUsuario.Checked Then
            cmbUsuario.Enabled = True
        Else
            cmbUsuario.Enabled = False
        End If
    End Sub

    Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechas.CheckedChanged
        If chkFechas.Checked Then
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
        Else
            dtpFechaDesde.Enabled = False
            dtpFechaHasta.Enabled = False
        End If
    End Sub

    Private Sub chkCriticidad_CheckedChanged(sender As Object, e As EventArgs) Handles chkCriticidad.CheckedChanged
        If chkCriticidad.Checked Then
            rbtnAlta.Enabled = True
            rbtnMedia.Enabled = True
            rbtnBaja.Enabled = True
        Else
            rbtnAlta.Enabled = False
            rbtnMedia.Enabled = False
            rbtnBaja.Enabled = False
        End If
    End Sub
End Class