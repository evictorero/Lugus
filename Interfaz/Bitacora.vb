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

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        MessageBox.Show(cmbUsuario.SelectedValue)
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