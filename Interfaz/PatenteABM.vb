Public Class PatenteABM
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Patente.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        msgBaja.Show()
        msgBaja.Label1.Text = "Usted se encuentra seguro que desea dar de baja la Patente seleccionada?"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        msgRehabilitar.Show()
        msgRehabilitar.Label1.Text = "Usted se encuentra seguro que desea rehabiliar la Patente seleccionada?"

    End Sub
End Class
