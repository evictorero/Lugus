Imports Microsoft.VisualBasic
Imports DTO.UsuarioDTO
Imports Datos.ProveedorDeDatos


Namespace Negocio
    Public Class Usuario : Implements IColeccionable

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

        'Esta coleccion alojara las patentes de cada usuario
        Protected mUsuarioPatente As New Collections.Generic.List(Of UsuarioPatente)

        'Esta coleccion alojara las familia de cada usuario
        Protected mUsuarioFamilia As New Collections.Generic.List(Of UsuarioFamilia)

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
            Me.CargarUsuarioPatente()
        End Sub
        Public Sub New()
            mId = 0
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

        Public ReadOnly Property UsuarioPatente() As Collections.Generic.List(Of UsuarioPatente)
            Get
                Return Me.FiltrarUsuarioPatenteNoVisibles
            End Get
        End Property


        Public ReadOnly Property UsuarioFamilia() As Collections.Generic.List(Of UsuarioFamilia)
            Get
                Return Me.FiltrarUsuarioFamiliaNoVisibles
            End Get
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
                mEmail = pDr("email")
                mId_idioma = pDr("email")
                mFechaNacimiento = pDr("fecha_nacimiento")
                mFechaNacimiento = pDr("fecha_modif")
                mIntentosLogin = pDr("intentosLogin")
                mIdUsuarioAlta = pDr("id_usuario_alta")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        Public Overridable Sub Cargar(ByVal pId As Integer)
            If pId > 0 Then
                Dim mDTO As DTO.UsuarioDTO = Datos.UsuarioDatos.Obtener(pId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Usurio sin Id especificado")
            End If
        End Sub

        Public Sub Cargar(ByVal pDTO As DTO.UsuarioDTO)
            mId = pDTO.id
            mUsuario = Encriptador.DesencriptarDatos(2, pDTO.usuario)
            mPassword = pDTO.contrasenia
            mNombre = pDTO.nombre
            mApellido = pDTO.apellido
            mDNI = pDTO.dni
            mEmail = pDTO.email
            mId_idioma = pDTO.id_idioma
            mFechaNacimiento = pDTO.fechaNacimiento
            mFechaBaja = pDTO.fechaBaja
            mDvh = pDTO.dvh
            mIntentosLogin = pDTO.intentosLogin
            mFechaModif = pDTO.fechaModif
            mIdUsuarioAlta = pDTO.idUsuarioAlta
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

            'El 2 implica DES(Reversible) y el 1 MD5(Irreversible)
            mDTO.usuario = Encriptador.EncriptarDatos(2, mUsuario)
            mDTO.contrasenia = Encriptador.encriptarDatos(1, mPassword)

            If ValidarFormato(mDTO.usuario, mDTO.contrasenia) Then
                rta = Datos.UsuarioDatos.VerificarLogin(mDTO)
            End If

            If rta = 1 Then
                Dim mBitacora As New Negocio.Bitacora(Me.ObtenerPorUsuario.id, "Inicio de sesión", "Baja")
                mBitacora.Guardar()
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
            Dim pass As String

            mDTO.usuario = Encriptador.EncriptarDatos(2, Me.usuario)
            mDTO.nombre = Me.nombre
            mDTO.apellido = Me.apellido
            mDTO.dni = Me.dni
            mDTO.email = Me.email
            'Guarda el idioma por defecto
            If Me.id_idioma = 0 Then
                mDTO.id_idioma = 1
            Else
                mDTO.id_idioma = Me.id_idioma
            End If

            mDTO.fechaNacimiento = Me.fechaNacimiento
            mDTO.idUsuarioAlta = Me.idUsuarioAlta
            mDTO.fechaModif = Me.mFechaModif
            mDTO.intentosLogin = Me.intentoLogin

            'Recalculo del digito verificador 
            Dim CadenaDigitoVerificador As String = mDTO.usuario + mDTO.nombre + mDTO.apellido + Convert.ToString(mDTO.fechaModif)
            mDTO.dvh = Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)

            If mId = 0 Then
                mDTO.id = Datos.UsuarioDatos.ObtenerProximoId()
                pass = GenerarPasswordAleatorio()
                mDTO.contrasenia = Encriptador.EncriptarDatos(1, pass)
                If Validar(mDTO) Then
                    Datos.UsuarioDatos.GuardarNuevo(mDTO)
                    EnviarMail(Me.usuario, pass)
                    Dim mBitacora As New Negocio.Bitacora(Me.ObtenerPorUsuario.id, "Creación de usuario", "Media")
                    mBitacora.Guardar()
                End If

            Else
                mDTO.id = Me.id
                If Validar(mDTO) Then
                    Datos.UsuarioDatos.GuardarModificacion(mDTO)
                    Dim mBitacora As New Negocio.Bitacora(Me.ObtenerPorUsuario.id, "Modificación de Usuario", "Media")
                    mBitacora.Guardar()
                End If
            End If

            Me.GuardarUsuarioPatentes()
            Me.GuardarUsuarioFamilias()

        End Sub
        Public Function Validar(ByVal pDTO As DTO.UsuarioDTO)
            If Datos.UsuarioDatos.ExisteDNI(pDTO) = True Then
                Throw New ApplicationException("Usuario Duplicado: El dni ingresado ya existe.")
            End If
            If Datos.UsuarioDatos.ExisteEmail(pDTO) = True Then
                Throw New ApplicationException("Usuario Duplicado: El email ingresado ya existe")
            End If
            If Datos.UsuarioDatos.ExisteUsuario(pDTO) = True Then
                Throw New ApplicationException("Usuario Duplicado: El usuario ya existe.")
            End If
            Return True
        End Function

        Public Sub ValidarFormato(pid_idioma As Integer)
            If (Me.nombre = "") Then
                Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar el nombre del usuario."))
            End If
            If (Me.apellido = "") Then
                Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar el apellido del usuario."))
            End If
            If (Me.usuario = "") Then
                Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar el usuario a utilizar."))
            End If
        End Sub

        Public Overridable Sub Eliminar()
            If mId > 0 Then
                Try
                    Datos.UsuarioDatos.Eliminar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar el usuario especificado.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar un usuario sin Id especifico.")
            End If
        End Sub

        Public Overridable Sub Blanquear()
            Dim mDTO As New DTO.UsuarioDTO
            Dim pass As String
            Try
                mDTO.id = Me.id
                mDTO.usuario = Encriptador.EncriptarDatos(2, Me.usuario)
                mDTO.nombre = Me.nombre
                mDTO.apellido = Me.apellido
                mDTO.dni = Me.dni
                mDTO.email = Me.email
                mDTO.id_idioma = Me.id_idioma
                mDTO.fechaNacimiento = Me.fechaNacimiento
                mDTO.dvh = Me.dvh
                mDTO.idUsuarioAlta = Me.idUsuarioAlta
                mDTO.fechaModif = Me.mFechaModif
                mDTO.intentosLogin = 0
                pass = GenerarPasswordAleatorio()
                MsgBox("Password Aleatorio " & pass)
                mDTO.contrasenia = Encriptador.EncriptarDatos(1, pass)
                Datos.UsuarioDatos.GuardarModificacion(mDTO)
                EnviarMail(Me.usuario, pass)
            Catch ex As Exception
                Throw New ApplicationException("Error al blanquear el usuario especificado.", ex)
            End Try
        End Sub

        Public Overridable Sub Rehabilitar()
            If mId > 0 Then
                Try
                    Datos.UsuarioDatos.Rehabilitar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al activar el usuario especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó activar una usuario sin Id especifico.")
            End If
        End Sub

        Public Function GenerarPasswordAleatorio() As String
            Dim numAleatorio As New Random()
            Dim password As String
            password = System.Convert.ToString(numAleatorio.Next)
            Return password
        End Function

        Public Sub EnviarMail(ByVal pNombreUsuario As String, ByVal pPass As String)
            Dim ruta As String = "C:\UsuarioContrasenia\" & pNombreUsuario & ".txt"
            If System.IO.File.Exists(ruta) Then
                System.IO.File.Delete(ruta)
            End If
            System.IO.File.Create(ruta).Dispose()
            Dim Escribir As New System.IO.StreamWriter(ruta, True)
            Escribir.WriteLine("Usuario : " & pNombreUsuario)
            Escribir.WriteLine("Contraseña : " & pPass)
            Escribir.Close()

        End Sub

        Public Sub IncrementarIntentosLogin()
            Me.intentoLogin = Me.intentoLogin + 1
        End Sub

        Public Function ExisteUsuario(ByVal pDTO As DTO.UsuarioDTO)
            If Datos.UsuarioDatos.ExisteUsuario(pDTO) = True Then
                Return True
            End If
            Return False
        End Function
#End Region

#Region "IColeccionable"
        Dim mEstadoColeccion As IColeccionable.EstadosColeccion
        Public Property EstadoColeccion() As IColeccionable.EstadosColeccion Implements IColeccionable.EstadoColeccion
            Get
                Return mEstadoColeccion
            End Get
            Set(ByVal value As IColeccionable.EstadosColeccion)
                mEstadoColeccion = value
            End Set
        End Property

        Dim mIndiceColeccion As Integer
        Public Property IndiceColeccion() As Integer Implements IColeccionable.IndiceColeccion
            Get
                Return mIndiceColeccion
            End Get
            Set(ByVal value As Integer)
                mIndiceColeccion = value
            End Set
        End Property



#End Region

#Region "UsuarioPatente"
        Public Sub EliminarUsuarioPatente(ByVal pUsuarioPatente As UsuarioPatente)
            EliminarUsuarioPatente(pUsuarioPatente.IndiceColeccion)
        End Sub
        Public Sub EliminarUsuarioPatente(ByVal pIndice As Integer)
            If Me.mUsuarioPatente(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Then
                Me.mUsuarioPatente(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Quitado
            Else
                Me.mUsuarioPatente(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Borrado
            End If

        End Sub
        Public Sub ModificarUsuarioPatente(ByVal pUsuarioPatente As UsuarioPatente)
            Me.mUsuarioPatente(pUsuarioPatente.IndiceColeccion) = pUsuarioPatente
            If Not pUsuarioPatente.EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Then
                pUsuarioPatente.EstadoColeccion = IColeccionable.EstadosColeccion.Modificado
            End If

        End Sub
        Public Sub AgregarUsuarioPatente(ByVal pUsuarioPatente As UsuarioPatente)
            Me.mUsuarioPatente.Add(pUsuarioPatente)
            Dim mInd As Integer = Me.mUsuarioPatente.IndexOf(pUsuarioPatente)
            Me.mUsuarioPatente(mInd).IndiceColeccion = mInd
            Me.mUsuarioPatente(mInd).EstadoColeccion = IColeccionable.EstadosColeccion.Agregado

            'POR ULTIMO EL NUEVO UsuarioPatente DEBE SABER A QUE Usuario PERTENECE
            Me.mUsuarioPatente(mInd).id_usuario = mId
        End Sub
        Private Sub GuardarUsuarioPatentes()
            Dim mLock As New Object
            Dim mReacomodar As Boolean = False
            SyncLock mLock
                Dim mEliminados As Integer = 0
                For x As Integer = 0 To Me.mUsuarioPatente.Count - 1
                    Select Case Me.mUsuarioPatente(x - mEliminados).EstadoColeccion
                        Case IColeccionable.EstadosColeccion.Agregado, IColeccionable.EstadosColeccion.Modificado
                            If Me.mUsuarioPatente(x - mEliminados).id_patente = 0 Then
                                Me.mUsuarioPatente(x - mEliminados).id_patente = mId
                            End If
                            Me.mUsuarioPatente(x - mEliminados).Guardar()
                            Me.mUsuarioPatente(x - mEliminados).EstadoColeccion = IColeccionable.EstadosColeccion.SinCambio

                        Case IColeccionable.EstadosColeccion.Borrado
                            Me.mUsuarioPatente(x - mEliminados).Eliminar()
                            Me.mUsuarioPatente.RemoveAt(Me.mUsuarioPatente(x - mEliminados).IndiceColeccion)
                            mEliminados += 1
                            mReacomodar = True

                        Case IColeccionable.EstadosColeccion.Quitado
                            Me.mUsuarioPatente.RemoveAt(Me.mUsuarioPatente(x - mEliminados).IndiceColeccion)
                            mEliminados += 1
                            mReacomodar = True
                    End Select

                Next
            End SyncLock

            'SI SE HA QUITADO ALGUN ELEMENTO DE LA COLECCION< DEBEREMOS REACOMODAR LOS INDICES
            'QUE CADA OBJETO CONOCE DE SI MISMO
            If mReacomodar Then
                Me.ReacomodarIndices()
            End If
        End Sub
        Private Sub ReacomodarIndices()
            'A CADA ELEMENTO DE LA COLECCION LE AVISAMOS CUAL ES SU NUEVO INDICE
            For Each mT As UsuarioPatente In Me.mUsuarioPatente
                mT.IndiceColeccion = Me.mUsuarioPatente.IndexOf(mT)
            Next
        End Sub
        Private Sub CargarUsuarioPatente()
            'AL CARGAR LOS UsuarioPatentes SIMPLEMENTE ASIGAMOS LA COLECCION QUE DEVUELVE EL METODO
            'LISTAR
            'INMEDIATAMENTE DESPUES LE AVISAMOS A CADA OBJETO UsuarioPatente QUE INDICE LE TOCO EN LA LISTA
            If mUsuarioPatente.Count = 0 Then
                Me.mUsuarioPatente = (New Negocio.UsuarioPatente).Listar(mId)
            End If
            For Each mT As UsuarioPatente In mUsuarioPatente
                mT.IndiceColeccion = Me.mUsuarioPatente.IndexOf(mT)
            Next
        End Sub
        Private Function FiltrarUsuarioPatenteNoVisibles() As Collections.Generic.List(Of UsuarioPatente)
            'ESTE METODO PERMITIRA FILTRAR LOS UsuarioPatentes ANTES DE MOSTRARLOS EN UN GRILLA
            'SE SUPONE QUE EN LA GRILLA NO SE VERAN LOS UsuarioPatentes BORRADOS Y QUITADOS
            Dim mCol As New Collections.Generic.List(Of UsuarioPatente)
            CargarUsuarioPatente()

            For Each mT As UsuarioPatente In Me.mUsuarioPatente
                If mT.EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Or mT.EstadoColeccion = IColeccionable.EstadosColeccion.Modificado Or mT.EstadoColeccion = IColeccionable.EstadosColeccion.SinCambio Then
                    mCol.Add(mT)
                End If
            Next
            ReacomodarIndices()
            Return mCol
        End Function
        Public Function ObtenerUsuarioPatentePorIndice(ByVal pIndice As Integer) As UsuarioPatente
            Return Me.mUsuarioPatente(pIndice)
        End Function
#End Region


#Region "UsuarioFamilia"
        Public Sub EliminarUsuarioFamilia(ByVal pUsuarioFamilia As UsuarioFamilia)
            EliminarUsuarioFamilia(pUsuarioFamilia.IndiceColeccion)
        End Sub
        Public Sub EliminarUsuarioFamilia(ByVal pIndice As Integer)
            If Me.mUsuarioFamilia(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Then
                Me.mUsuarioFamilia(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Quitado
            Else
                Me.mUsuarioFamilia(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Borrado
            End If

        End Sub
        Public Sub ModificarUsuarioFamilia(ByVal pUsuarioFamilia As UsuarioFamilia)
            Me.mUsuarioFamilia(pUsuarioFamilia.IndiceColeccion) = pUsuarioFamilia
            If Not pUsuarioFamilia.EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Then
                pUsuarioFamilia.EstadoColeccion = IColeccionable.EstadosColeccion.Modificado
            End If

        End Sub
        Public Sub AgregarUsuarioFamilia(ByVal pUsuarioFamilia As UsuarioFamilia)
            Me.mUsuarioFamilia.Add(pUsuarioFamilia)
            Dim mInd As Integer = Me.mUsuarioFamilia.IndexOf(pUsuarioFamilia)
            Me.mUsuarioFamilia(mInd).IndiceColeccion = mInd
            Me.mUsuarioFamilia(mInd).EstadoColeccion = IColeccionable.EstadosColeccion.Agregado

            'POR ULTIMO EL NUEVO UsuarioFamilia DEBE SABER A QUE Casa PERTENECE
            Me.mUsuarioFamilia(mInd).id_usuario = mId
        End Sub
        Private Sub GuardarUsuarioFamilias()
            Dim mLock As New Object
            Dim mReacomodar As Boolean = False
            SyncLock mLock
                Dim mEliminados As Integer = 0
                For x As Integer = 0 To Me.mUsuarioFamilia.Count - 1
                    Select Case Me.mUsuarioFamilia(x - mEliminados).EstadoColeccion
                        Case IColeccionable.EstadosColeccion.Agregado, IColeccionable.EstadosColeccion.Modificado
                            If Me.mUsuarioFamilia(x - mEliminados).id_familia = 0 Then
                                Me.mUsuarioFamilia(x - mEliminados).id_familia = mId
                            End If
                            Me.mUsuarioFamilia(x - mEliminados).Guardar()
                            Me.mUsuarioFamilia(x - mEliminados).EstadoColeccion = IColeccionable.EstadosColeccion.SinCambio

                        Case IColeccionable.EstadosColeccion.Borrado
                            Me.mUsuarioFamilia(x - mEliminados).Eliminar()
                            Me.mUsuarioFamilia.RemoveAt(Me.mUsuarioFamilia(x - mEliminados).IndiceColeccion)
                            mEliminados += 1
                            mReacomodar = True

                        Case IColeccionable.EstadosColeccion.Quitado
                            Me.mUsuarioFamilia.RemoveAt(Me.mUsuarioFamilia(x - mEliminados).IndiceColeccion)
                            mEliminados += 1
                            mReacomodar = True
                    End Select

                Next
            End SyncLock

            'SI SE HA QUITADO ALGUN ELEMENTO DE LA COLECCION< DEBEREMOS REACOMODAR LOS INDICES
            'QUE CADA OBJETO CONOCE DE SI MISMO
            If mReacomodar Then
                Me.ReacomodarIndicesFamilia()
            End If
        End Sub
        Private Sub ReacomodarIndicesFamilia()
            'A CADA ELEMENTO DE LA COLECCION LE AVISAMOS CUAL ES SU NUEVO INDICE
            For Each mT As UsuarioFamilia In Me.mUsuarioFamilia
                mT.IndiceColeccion = Me.mUsuarioFamilia.IndexOf(mT)
            Next
        End Sub
        Private Sub CargarUsuarioFamilia()
            'AL CARGAR LOS UsuarioFamilias SIMPLEMENTE ASIGAMOS LA COLECCION QUE DEVUELVE EL METODO
            'LISTAR
            'INMEDIATAMENTE DESPUES LE AVISAMOS A CADA OBJETO UsuarioFamilia QUE INDICE LE TOCO EN LA LISTA
            If mUsuarioFamilia.Count = 0 Then
                Me.mUsuarioFamilia = (New Negocio.UsuarioFamilia).Listar(mId)
            End If
            For Each mT As UsuarioFamilia In mUsuarioFamilia
                mT.IndiceColeccion = Me.mUsuarioFamilia.IndexOf(mT)
            Next
        End Sub
        Private Function FiltrarUsuarioFamiliaNoVisibles() As Collections.Generic.List(Of UsuarioFamilia)
            'ESTE METODO PERMITIRA FILTRAR LOS UsuarioFamilias ANTES DE MOSTRARLOS EN UN GRILLA
            'SE SUPONE QUE EN LA GRILLA NO SE VERAN LOS UsuarioFamilias BORRADOS Y QUITADOS
            Dim mCol As New Collections.Generic.List(Of UsuarioFamilia)
            CargarUsuarioFamilia()

            For Each mT As UsuarioFamilia In Me.mUsuarioFamilia
                If mT.EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Or mT.EstadoColeccion = IColeccionable.EstadosColeccion.Modificado Or mT.EstadoColeccion = IColeccionable.EstadosColeccion.SinCambio Then
                    mCol.Add(mT)
                End If
            Next
            ReacomodarIndicesFamilia()
            Return mCol
        End Function
        Public Function ObtenerUsuarioFamiliaPorIndice(ByVal pIndice As Integer) As UsuarioFamilia
            Return Me.mUsuarioFamilia(pIndice)
        End Function


#End Region


    End Class
End Namespace