Public Class Platos
    Private Sub Platos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = True
        Me.TextBox2.Focus()
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub
End Class