Public Class msgMensaje

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub
End Class