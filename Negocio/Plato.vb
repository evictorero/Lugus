Imports Datos.ProveedorDeDatos.DB

Namespace Negocio

    Public Class Plato

#Region "Declaraciones"
        Dim mDescripcionCorta As String
        Dim mDescripcionLarga As String
        Dim mHabilitado As String
        Dim mFechaBaja As Nullable(Of DateTime)
        Dim mIdUsuario As Integer
        Dim mDvh As Integer
        Dim mFechaModif As Date

        Private Shared ProximoId As Integer
        Dim mId As Integer = 0
#End Region

#Region "Constructores"
        Public Sub New(ByVal pId As Integer)
            mId = pId
            Cargar()
        End Sub
        Public Sub New()

        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.PlatoDTO)
            Me.Cargar(pDTO)
        End Sub
#End Region

#Region "Propiedades"
        Public Overridable ReadOnly Property id() As Integer
            Get
                Return mId
            End Get
        End Property

        Public Property descripcionCorta() As String
            Get
                Return mDescripcionCorta
            End Get
            Set(ByVal value As String)
                mDescripcionCorta = value
            End Set
        End Property

        Public Property descripcionLarga() As String
            Get
                Return mDescripcionLarga
            End Get
            Set(ByVal value As String)
                mDescripcionLarga = value
            End Set
        End Property

        Public Property habilitado() As String
            Get
                Return mHabilitado
            End Get
            Set(ByVal value As String)
                mHabilitado = value
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

        Public Property idUsuario() As Integer
            Get
                Return mIdUsuario
            End Get
            Set(ByVal value As Integer)
                mIdUsuario = value
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


        Public Property fechaModif() As Date
            Get
                Return mFechaModif
            End Get
            Set(ByVal value As Date)
                mFechaModif = value
            End Set
        End Property
#End Region

#Region "Métodos"

        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.PlatoDTO

            mDTO.descripcionCorta = Encriptador.EncriptarDatos(2, Me.descripcionCorta)
            mDTO.descripcionLarga = Me.descripcionLarga
            mDTO.habilitado = Me.habilitado
            mDTO.fechaBaja = Me.fechaBaja
            mDTO.idUsuario = Me.idUsuario
            mDTO.fechaModif = Me.fechaModif

            'Recalculo del digito verificador horizontal
            Dim CadenaDigitoVerificador As String = mDTO.descripcionCorta + mDTO.descripcionLarga
            mDTO.dvh = Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)


            If mId = 0 Then
                mDTO.id = Datos.PlatoDatos.ObtenerProximoId()
                Datos.PlatoDatos.GuardarNuevo(mDTO)
                Dim mBitacora As New Negocio.Bitacora(mDTO.id, "Creacion de Plato: " & mDTO.descripcionLarga, "Media")
                mBitacora.Guardar()
            Else
                mDTO.id = Me.id
                Datos.PlatoDatos.GuardarModificacion(mDTO)
                Dim mBitacora As New Negocio.Bitacora(mDTO.id, "Modificacion de Plato: " & mDTO.descripcionLarga, "Media")
                mBitacora.Guardar()
            End If

            'Recalculo del digito verificador vertical
            Dim mDVV As New Negocio.DigitoVerificador("bPlato")
            mDVV.tabla = "bplato"
            mDVV.valor = Negocio.DigitoVerificador.CalcularDVV("bPlato")
            mDVV.Guardar()

        End Sub
        Public Overridable Sub Cargar()
            If mId > 0 Then
                Dim mDTO As DTO.PlatoDTO = Datos.PlatoDatos.Obtener(mId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Plato sin Id especificado")

            End If
        End Sub

        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mDescripcionCorta = pDr("descripcion_corta")
                mDescripcionLarga = pDr("descripcion_larga")
                mHabilitado = pDr("habilitado")
                mFechaBaja = pDr("fecha_baja")
                mIdUsuario = pDr("id_usuario")
                mDvh = pDr("dvh")
                mFechaModif = pDr("fecha_modif")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Public Overridable Sub Cargar(ByVal pId As Integer)
            If pId > 0 Then
                Dim mDTO As DTO.PlatoDTO = Datos.PlatoDatos.Obtener(pId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Plato sin Id especificado")
            End If
        End Sub
        Public Sub Cargar(ByVal pDTO As DTO.PlatoDTO)
            mId = pDTO.id
            mDescripcionCorta = Encriptador.DesencriptarDatos(2, pDTO.descripcionCorta)
            mDescripcionLarga = pDTO.descripcionLarga
            mHabilitado = pDTO.habilitado
            mFechaBaja = pDTO.fechaBaja
            mIdUsuario = pDTO.idUsuario
            mFechaModif = pDTO.fechaModif
            mDvh = pDTO.dvh
        End Sub

        Public Overridable Sub Eliminar()
            If mId > 0 Then
                Try
                    Datos.PlatoDatos.Eliminar(mId)
                    Dim mBitacora As New Negocio.Bitacora(mId, "Eliminacion de Plato: Id " & mId, "Media")
                    mBitacora.Guardar()
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar el plato especificado.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar un plato sin Id especifico.")
            End If
        End Sub

        Public Overridable Sub Rehabilitar()
            If mId > 0 Then
                Try
                    Datos.PlatoDatos.Rehabilitar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al activar el plato especificado.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó activar un plato sin Id especifico.")
            End If
        End Sub

        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = Datos.PlatoDatos.ObtenerProximoId()
            End If
            ProximoId += 1
            Return ProximoId
        End Function

        Public Sub ValidarFormato(pid_idioma As Integer)
            Try
                If (Me.descripcionCorta = "") Then
                    Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar la descripción corta."))
                End If
                If (Me.descripcionLarga = "") Then
                    Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar la descripción larga."))
                End If
                If (Me.habilitado = "") Then
                    Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar el campo habilitado."))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Throw
            End Try

        End Sub
        Public Overridable Function Listar() As Collections.Generic.List(Of Plato)
            Dim mCol As New Collections.Generic.List(Of Plato)
            Dim mColDTO As List(Of DTO.PlatoDTO) = Datos.PlatoDatos.Listar()

            For Each mDTO As DTO.PlatoDTO In mColDTO
                mCol.Add(New Negocio.Plato(mDTO))
            Next

            Return mCol
        End Function
#End Region
    End Class
End Namespace
