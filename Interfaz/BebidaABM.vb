Public Class BebidaABM

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        msgMensaje.Show()
        msgMensaje.Text = "Eliminar"
        msgMensaje.Label1.Text = "Usted se encuentra seguro que desea dar de baja la  Bebida seleccionada?"
    End Sub

    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabiliatar.Click
        msgMensaje.Show()
        msgMensaje.Text = "Rehabilitar"
        msgMensaje.Label1.Text = "Usted se encuentra seguro que desea rehabilitar la bebida seleccionado?"
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        'Bebida.Show()
        Dim mForm As New Bebida
        mForm.mOperacion = Bebida.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ' ActualizarGrilla()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Bebida.Show()
    End Sub

    Private Sub BebidaABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class