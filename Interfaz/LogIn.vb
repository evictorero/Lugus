Public Class LogIn
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Principal.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        msgContraseña.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub LogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = True
        Me.txtUsuario.Focus()

    End Sub
End Class