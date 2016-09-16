Public Class UsuarioABM
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Interfaz.Usuario.Show()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        msgMensaje.Show()
        msgMensaje.Text = "Eliminar"

    End Sub

    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        msgMensaje.Show()
        msgMensaje.Text = "Rehabilitar"

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Interfaz.Usuario.Show()
    End Sub

    Private Sub UsuarioABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

End Class
