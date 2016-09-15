Public Class PlatosABM

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Platos.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        msgMensaje.Show()
        msgMensaje.Text = "Eliminar"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        msgRehabilitar.Show()
        msgRehabilitar.Label1.Text = "Usted se encuentra seguro que desea rehabiliar el plato seleccionado?"
    End Sub

    Private Sub PlatosABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub
End Class