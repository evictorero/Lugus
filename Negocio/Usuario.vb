Imports Microsoft.VisualBasic
Imports DTO.UsuarioDTO
Imports Datos.ProveedorDeDatos


Namespace Negocio
    Public Class Usuario

#Region "Declaraciones"
        Dim mUsuario As String
        Dim mPassword As String
        Dim mNombre As String
        Dim mApellido As String
        Dim mDNI As Integer
        Dim mEmail As String
        Dim mId_idioma As Integer
        Dim mFechaNacimiento As Date
        Dim mFechaBaja As Nullable(Of DateTime)
        Dim mDvh As Integer
        Dim mIntentosLogin As Integer
        Dim mIdUsuarioAlta As Integer
        Dim mFechaModif As Date
        Private Shared ProximoId As Integer
        Dim mId As Integer = 0
#End Region

#Region "Constructores"
        Public Sub New(ByVal pId As Integer)
            mId = pId
            Cargar()
        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.UsuarioDTO)
            Me.Cargar(pDTO)
        End Sub
        Public Sub New()

        End Sub
#End Region

#Region "Propiedades"
        Public Property usuario() As String
            Get
                Return mUSuario
            End Get
            Set(ByVal value As String)
                mUSuario = value
            End Set
        End Property
        Public Property nombre() As String
            Get
                Return mNombre
            End Get
            Set(ByVal value As String)
                mNombre = value
            End Set
        End Property
        Public Property apellido() As String
            Get
                Return mApellido
            End Get
            Set(ByVal value As String)
                mApellido = value
            End Set
        End Property
        Public Property password() As String
            Get
                Return mPassword
            End Get
            Set(ByVal value As String)
                mPassword = value
            End Set
        End Property
        Public Property dni() As Integer
            Get
                Return mDNI
            End Get
            Set(ByVal value As Integer)
                mDNI = value
            End Set
        End Property
        Public Property id_idioma() As String
            Get
                Return mId_idioma
            End Get
            Set(ByVal value As String)
                mId_idioma = value
            End Set
        End Property
        Public Property fechaNacimiento() As Date
            Get
                Return mFechaNacimiento
            End Get
            Set(ByVal value As Date)
                mFechaNacimiento = value
            End Set
        End Property
        Public Property email() As String
            Get
                Return mEmail
            End Get
            Set(ByVal value As String)
                mEmail = value
            End Set
        End Property
        Public Property idUsuarioAlta() As Integer
            Get
                Return mIdUsuarioAlta
            End Get
            Set(ByVal value As Integer)
                mIdUsuarioAlta = value
            End Set
        End Property
        Public Property fechaBaja() As Nullable(Of DateTime)
            Get
                Return mFechaBaja
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                mFechaBaja = value
            End Set
        End Property
        Public Property dvh() As Integer
            Get
                Return mDvh
            End Get
            Set(ByVal value As Integer)
                mDvh = value
            End Set
        End Property
        Public Property intentoLogin() As Integer
            Get
                Return mIntentosLogin
            End Get
            Set(ByVal value As Integer)
                mIntentosLogin = value
            End Set
        End Property
        Public Property fechaModif() As Date
            Get
                Return mFechaModif
            End Get
            Set(ByVal value As Date)
                mFechaModif = value
            End Set
        End Property
        Public Property id() As Integer
            Get
                Return mId
            End Get
            Set(ByVal value As Integer)
                mId = value
            End Set
        End Property
#End Region


#Region "Métodos"

        Public Overridable Sub Cargar()
            If mId > 0 Then
                Dim mDTO As DTO.UsuarioDTO = Datos.UsuarioDatos.Obtener(mId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Usuario sin Id especificado")

            End If
        End Sub

        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mId = pDr("id")
                mUsuario = pDr("usuario")
                mNombre = pDr("nombre")
                mApellido = pDr("apellido")
                mDNI = pDr("dni")
                mFechaNacimiento = pDr("fecha_nacimiento")
                mFechaNacimiento = pDr("fecha_modif")
                mEmail = pDr("email")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        Public Overridable Sub Cargar(ByVal pId As Integer)
            Try
                mId = pId
                MyClass.Cargar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        Public Sub Cargar(ByVal pDTO As DTO.UsuarioDTO)
            mId = pDTO.id
            mUsuario = pDTO.usuario
            mPassword = pDTO.contrasenia
            mNombre = pDTO.nombre
            mApellido = pDTO.apellido
            mDNI = pDTO.dni
            mId_idioma = pDTO.id_idioma
            mEmail = pDTO.email
            mFechaNacimiento = pDTO.fechaNacimiento
            mFechaBaja = pDTO.fechaBaja
            mDvh = pDTO.dvh
            mIntentosLogin = pDTO.intentosLogin
            mFechaModif = pDTO.fechaModif

        End Sub

        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = DB.ObtenerId("busuario")
                If mTempId Is DBNull.Value Then
                    ProximoId = 0
                Else
                    ProximoId = mTempId
                End If
            End If
            ProximoId += 1
            Return ProximoId
        End Function

        Public Overridable Function Listar() As Collections.Generic.List(Of Usuario)
            Dim mCol As New Collections.Generic.List(Of Usuario)
            Dim mColDTO As List(Of DTO.UsuarioDTO) = Datos.UsuarioDatos.Listar()
            Dim miUsuario As Negocio.Usuario

            For Each mDTO As DTO.UsuarioDTO In mColDTO
                miUsuario = New Negocio.Usuario(mDTO)
                miUsuario.usuario = Encriptador.DesencriptarDatos(2, mDTO.usuario)
                mCol.Add(miUsuario)
            Next

            Return mCol
        End Function
        Public Shared Function ValidarFormato(pUsuario As String, pContrasenia As String) As Boolean
            'Celeste
            Return True
        End Function

        Public Function ValidarLogin() As Integer
            Dim mDTO As New DTO.UsuarioDTO
            Dim rta As Integer

            mDTO.usuario = Encriptador.EncriptarDatos(2, mUsuario)
            mDTO.contrasenia = Encriptador.encriptarDatos(1, mPassword)

            If ValidarFormato(mDTO.usuario, mDTO.contrasenia) Then
                rta = Datos.UsuarioDatos.VerificarLogin(mDTO)
            End If
            Return rta

        End Function

        Public Function ObtenerPorUsuario() As Negocio.Usuario
            Dim mDTO As New DTO.UsuarioDTO
            Dim mNegocio As New Negocio.Usuario

            mDTO = Datos.UsuarioDatos.ObtenerPorUsuario(Encriptador.EncriptarDatos(2, Me.usuario))

            mNegocio.Cargar(mDTO)

            Return mNegocio
        End Function

        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.UsuarioDTO

            mDTO.usuario = Encriptador.EncriptarDatos(2, Me.usuario)
            mDTO.nombre = Me.nombre
            mDTO.apellido = Me.apellido
            mDTO.dni = Me.dni
            mDTO.email = Me.email
            mDTO.id_idioma = Me.id_idioma
            mDTO.fechaNacimiento = Me.fechaNacimiento
            mDTO.dvh = Me.dvh ' Celes
            mDTO.idUsuarioAlta = Me.idUsuarioAlta
            mDTO.fechaModif = Me.mFechaModif


            ValidarCampos()

            If mId = 0 Then
                mDTO.id = Datos.UsuarioDatos.ObtenerProximoId()
                Datos.UsuarioDatos.GuardarNuevo(mDTO)
            Else
                mDTO.id = Me.id
                Datos.UsuarioDatos.GuardarModificacion(mDTO)
            End If

        End Sub
        Private Sub ValidarCampos()
            If (Me.nombre = "") Then
                Throw New ApplicationException("Debe completar la descripción corta.")
            End If
            If (Me.apellido = "") Then
                Throw New ApplicationException("Debe completar la descripción larga.")
            End If
            If (Me.usuario = "") Then
                Throw New ApplicationException("Debe completar el campo habilitado.")
            End If
        End Sub

        Public Overridable Sub Eliminar()
            If mId > 0 Then
                Try
                    Datos.UsuarioDatos.Eliminar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar la bebida especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar una bebida sin Id especifico.")
            End If
        End Sub

        Public Overridable Sub Rehabilitar()
            If mId > 0 Then
                Try
                    Datos.UsuarioDatos.Rehabilitar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al activar la bebida especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó activar una bebida sin Id especifico.")
            End If
        End Sub
#End Region

    End Class
End Namespace