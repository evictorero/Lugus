Public Class FamiliaABM
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        msgMensaje.Show()
        msgMensaje.Text = "Eliminar"
        msgMensaje.Label1.Text = "Usted se encuentra seguro que desea dar de baja la familia seleccionada?"
    End Sub

    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        msgMensaje.Show()
        msgMensaje.Text = "Rehabilitar"
        msgMensaje.Label1.Text = "Usted se encuentra seguro que desea rehabilitar la familia seleccionada?"
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Familia.Show()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Familia.Show()
    End Sub
End Class