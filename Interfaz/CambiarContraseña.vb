Imports Negocio.Negocio.Traductor

Public Class CambiarContraseña
    Dim mUsuario As Negocio.Negocio.Usuario

    Private Sub CambiarContraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuario.Text = Principal.UsuarioEnSesion.usuario
        txtUsuario.Enabled = False
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim rta As Integer = -1
        Try
            If txtContraseniaActual.Text = "" Then
                Throw New ApplicationException("Debe Ingresar la Contraseña actual para poder avanzar.")
            End If

            If txtContraseniaNueva.Text = "" Or txtRepetirContraseniaNueva.Text = "" Then
                Throw New ApplicationException("Debe Ingresar la Contraseña nueva para poder avanzar.")
            End If

            If txtContraseniaNueva.Text <> txtRepetirContraseniaNueva.Text Then
                Throw New ApplicationException("Error en la nueva Contraseña")
            End If

            mUsuario = New Negocio.Negocio.Usuario
            mUsuario = Principal.UsuarioEnSesion

            mUsuario.usuario = Me.txtUsuario.Text
            mUsuario.password = Me.txtContraseniaActual.Text

            rta = mUsuario.ValidarLogin()

            If rta = 1 Then
                mUsuario.password = Me.txtContraseniaNueva.Text
                mUsuario.EnviarMail(mUsuario.usuario, mUsuario.password)
                mUsuario.Guardar()
                MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Su nueva contraseña ha sido enviada de forma exitosa a su casilla de email."))
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, ex.Message))
        End Try

    End Sub
End Class