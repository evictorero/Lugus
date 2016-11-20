Public Class PatenteABM
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Patente.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        msgMensaje.Show()
        msgMensaje.Text = "Eliminar"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        msgMensaje.Show()
        msgMensaje.Text = "Rehabilitar"


    End Sub

    Private Sub PatenteABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Patente.Show()
    End Sub
End Class
