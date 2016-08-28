Public Class BebidaABM
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        Bebida.Show()
    End Sub

    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Bebida.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        msgBaja.Show()
        msgBaja.Label1.Text = "Usted se encuentra seguro que desea dar de baja la  Bebida seleccionada?"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        msgRehabilitar.Show()
        msgRehabilitar.Label1.Text = "Usted se encuentra seguro que desea rehabilitar la bebida seleccionado?"

    End Sub
End Class