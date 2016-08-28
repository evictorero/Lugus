Public Class PatenteABM
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Patente.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        msgMensaje.Show()
        msgMensaje.Text = "Eliminar"
        msgMensaje.Label1.Text = "Usted se encuentra seguro que desea dar de baja la Patente seleccionada?"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        msgMensaje.Show()
        msgMensaje.Text = "Rehabilitar"
        msgMensaje.Label1.Text = "Usted se encuentra seguro que desea rehabiliar la Patente seleccionada?"

    End Sub

    Private Sub PatenteABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Patente.Show()
    End Sub
End Class
