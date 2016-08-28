Public Class PlatosABM
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

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
End Class