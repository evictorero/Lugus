Imports Negocio.Negocio.Usuario
Imports Negocio.Negocio.Bitacora

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
                'Verifica la integridad de DVV
                If Not (Negocio.Negocio.DigitoVerificador.VerificarIntegridad) Then
                    MsgBox("Problema de Integridad de Datos.Contacte al administrador del sistema.")
                    ' Application.Exit()
                End If

                'Cargar Perfil del Usuario Logueado
                Principal.estaAutenticado = True
                Principal.UsuarioEnSesion = mUsuario.ObtenerPorUsuario
                Principal.Show()
                Principal.Traducir()

            ElseIf rta = 2 Then
                MsgBox("Contraseña Incorrecta.")
                Dim mUsuarioaLoguearse = New Negocio.Negocio.Usuario
                mUsuarioaLoguearse.usuario = Me.txtUsuario.Text
                mUsuarioaLoguearse = mUsuario.ObtenerPorUsuario()
                mUsuarioaLoguearse.IncrementarIntentosLogin()
                mUsuarioaLoguearse.Guardar()
            ElseIf rta = 3 Then
                MsgBox("El usuario ingresado es Incorrecto.")
            ElseIf rta = 4 Then
                MsgBox("El usuario se encuentra bloqueado.")
            ElseIf rta = 5 Then
                MsgBox("No se pudo establecer la conexión con la base de datos, verifique el string de conexión.")
            End If
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Me.txtUsuario.Text = "" Then
            MsgBox("Debe completar con su usuario para poder enviar la nueva contraseña.")
        End If

        Dim mUsuario = New Negocio.Negocio.Usuario
        mUsuario.usuario = Me.txtUsuario.Text
        mUsuario = mUsuario.ObtenerPorUsuario

        Dim mdto = New DTO.UsuarioDTO
        mdto.usuario = Negocio.Negocio.Encriptador.EncriptarDatos(2, mUsuario.usuario)
        mdto.id = 0

        If mUsuario.ExisteUsuario(mDTO) = True Then
            mUsuario.HaOlvidadoSuContrasenia()
            msgContraseña.Show()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub LogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = True
        Me.txtUsuario.Focus()
        Me.txtUsuario.Text = "Cgomez"
        Me.txtPassword.Text = "1739273234"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.Show()
    End Sub
End Class