Public Class Usuario

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        AsocUsuarioPatente.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        AsocUsuarioFamilia.Show()
    End Sub

    Private Sub Usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.cbId_Propietario.DataSource = (New Negocio.Negocio.Propietario).Listar
        Me.Visible = True
        Me.TextBox2.Focus()


    End Sub
End Class