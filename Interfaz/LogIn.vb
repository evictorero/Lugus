Imports Negocio.Negocio.Usuario

Public Class LogIn

    Dim mUsuario As Negocio.Negocio.Usuario

    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click

        Dim rta As Integer = -1
        mUsuario = New Negocio.Negocio.Usuario
        If txtPassword.Text = "" Or txtUsuario.Text = "" Then
            'debe ingresar ambos campos
            MsgBox("Debe Ingresar Usuario y Contraseña para poder avanzar")
        Else
            mUsuario.usuario = Me.txtUsuario.Text
            mUsuario.password = Me.txtPassword.Text

            rta = mUsuario.ValidarLogin()
            If rta = 1 Then
                'Cargar Perfil del Usuario Logueado
                Principal.estaAutenticado = True
                Principal.UsuarioEnSesion = mUsuario.ObtenerPorUsuario

                'MsgBox(Principal.UsuarioEnSesion.id_idioma)

                'mUsuario.RegistrarSesionUsuario(u.Id)
                Principal.Show()
                Principal.Traducir()

                'Me.Close() Celeste
            ElseIf rta = 2 Then
                MsgBox("Contraseña Incorrecta.")
            ElseIf rta = 3 Then
                MsgBox("El usuario ingresado es Incorrecto.")
            End If
        End If


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
        Me.txtUsuario.Text = "Cgomez"
        Me.txtPassword.Text = "123"
    End Sub
End Class