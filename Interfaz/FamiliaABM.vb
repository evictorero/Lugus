Public Class FamiliaABM
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        Familia.Show()
    End Sub

    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Familia.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        msgBaja.Show()
        msgBaja.Label1.Text = "Usted se encuentra seguro que desea dar de baja la familia seleccionada?"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        msgRehabilitar.Show()
        msgRehabilitar.Label1.Text = "Usted se encuentra seguro que desea rehabiliar la familia seleccionada?"
    End Sub
End Class