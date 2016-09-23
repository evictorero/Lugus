Imports Datos.ProveedorDeDatos.DB

Namespace Negocio

    'bebida ES UNA ENTIDAD QUE PUEDE PERTENECER A UNA COLECCION
    'EN UNA RELACION DE AGREGACION, POR ESO IMPLEMENTA LA INTERFAZ ICOLECCIONABLE
    Public Class Bebida
        Implements IColeccionable

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
        Public Sub New(ByVal pDTO As DTO.BebidaDTO)
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
            Dim mDTO As New DTO.BebidaDTO

            mDTO.descripcionCorta = Me.descripcionCorta
            mDTO.descripcionLarga = Me.descripcionLarga
            mDTO.habilitado = Me.habilitado
            mDTO.fechaBaja = Me.fechaBaja
            mDTO.idUsuario = Me.idUsuario
            mDTO.fechaModif = Me.fechaModif
            mDTO.dvh = Me.dvh

            ValidarCampos()

            If mId = 0 Then
                mDTO.id = Datos.BebidaDatos.ObtenerProximoId()
                Datos.BebidaDatos.GuardarNuevo(mDTO)
            Else
                mDTO.Id = Me.Id
                Datos.BebidaDatos.GuardarModificacion(mDTO)
            End If

        End Sub
        Public Overridable Sub Cargar()
            If mId > 0 Then
                Dim mDTO As DTO.BebidaDTO = Datos.BebidaDatos.Obtener(mId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Bebida sin Id especificado")

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
            If mId > 0 Then
                Dim mDTO As DTO.BebidaDTO = Datos.BebidaDatos.Obtener(pId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Bebida sin Id especificado")
            End If
        End Sub
        Public Sub Cargar(ByVal pDTO As DTO.BebidaDTO)
            mId = pDTO.id
            mDescripcionCorta = pDTO.descripcionCorta
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
                    Datos.BebidaDatos.Eliminar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar la bebida especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar una bebida sin Id especifico.")
            End If
        End Sub

        Public Overridable Sub Activar()
            If mId > 0 Then
                Try
                    Datos.BebidaDatos.Activar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al activar la bebida especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó activar una bebida sin Id especifico.")
            End If
        End Sub

        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = Datos.BebidaDatos.ObtenerProximoId()
            End If
            ProximoId += 1
            Return ProximoId
        End Function
        Private Sub ValidarCampos()
            If (Me.descripcionCorta = "") Then
                Throw New ApplicationException("Debe completar la descripción corta.")
            End If
            If (Me.descripcionLarga = "") Then
                Throw New ApplicationException("Debe completar la descripción larga.")
            End If
            If (Me.habilitado = "") Then
                Throw New ApplicationException("Debe completar el campo habilitado.")
            End If
        End Sub
        Public Overridable Function Listar() As Collections.Generic.List(Of Bebida)
            Dim mCol As New Collections.Generic.List(Of Bebida)
            Dim mColDTO As List(Of DTO.BebidaDTO) = Datos.BebidaDatos.Listar()

            For Each mDTO As DTO.BebidaDTO In mColDTO
                mCol.Add(New Negocio.Bebida(mDTO))
            Next

            Return mCol
        End Function
#End Region

        'IMPLEMENTACION DE LOS MIEMBROS DE LA INTERFAZ ICOLECCIONABLE
#Region "IColeccionable"
        Dim mEstado As IColeccionable.EstadosColeccion
        Public Property EstadoColeccion() As IColeccionable.EstadosColeccion Implements IColeccionable.EstadoColeccion
            Get
                Return mEstado
            End Get
            Set(ByVal value As IColeccionable.EstadosColeccion)
                mEstado = value
            End Set
        End Property
        Dim mIndice As Integer
        Public Property IndiceColeccion() As Integer Implements IColeccionable.IndiceColeccion
            Get
                Return mIndice
            End Get
            Set(ByVal value As Integer)
                mIndice = value
            End Set
        End Property

#End Region

    End Class
End Namespace
