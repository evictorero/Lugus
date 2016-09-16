Public Class Familia
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Familia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = True
        Me.txtDescripcion_corta.Focus()
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub
End Class