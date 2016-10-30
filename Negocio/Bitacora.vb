Imports Datos.ProveedorDeDatos.DB

Namespace Negocio
    Public Class Bitacora

#Region "Declaraciones"

        Dim mIdUsuario As Integer
        Dim mDescripcionLarga As String
        Dim mFecha As DateTime
        Dim mDvh As Integer
        Dim mCriticidad As String

        Private Shared ProximoId As Integer
        Dim mId As Integer = 0
#End Region

#Region "Constructores"
        Public Sub New()

        End Sub

        Public Sub New(ByVal pIdUsuario As Integer, ByVal pDescripcionLarga As String, ByRef pCriticidad As String)
            Dim pDTO As New DTO.BitacoraDTO
            pDTO.idUsuario = pIdUsuario
            pDTO.descripcionLarga = pDescripcionLarga
            pDTO.criticidad = pCriticidad
            Me.Cargar(pDTO)
        End Sub

        Public Sub New(ByVal pDTO As DTO.BitacoraDTO)
            Me.Cargar(pDTO)
        End Sub
#End Region

#Region "Propiedades"
        Public Overridable ReadOnly Property id() As Integer
            Get
                Return mId
            End Get
        End Property

        Public Property idUsuario() As Integer
            Get
                Return mIdUsuario
            End Get
            Set(ByVal value As Integer)
                mIdUsuario = value
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

        Public Property fecha() As DateTime
            Get
                Return mFecha
            End Get
            Set(ByVal value As DateTime)
                mFecha = value
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
        Public Property criticidad() As String
            Get
                Return mCriticidad
            End Get
            Set(ByVal value As String)
                mCriticidad = value
            End Set
        End Property
#End Region

#Region "Métodos"

        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.BitacoraDTO

            mDTO.idUsuario = Me.idUsuario
            mDTO.descripcionLarga = Me.descripcionLarga
            mDTO.fecha = DateTime.Now
            mDTO.criticidad = Me.criticidad

            Dim CadenaDigitoVerificador As String = mDTO.idUsuario.ToString + mDTO.descripcionLarga + Convert.ToString(mDTO.fecha) + mDTO.criticidad
            mDTO.dvh = Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)

            If mId = 0 Then
                mDTO.id = Datos.BitacoraDatos.ObtenerProximoId()
                Datos.BitacoraDatos.GuardarNuevo(mDTO)
            End If

        End Sub

        Public Sub Cargar(ByVal pDTO As DTO.BitacoraDTO)
            mId = pDTO.id
            mIdUsuario = pDTO.idUsuario
            mDescripcionLarga = pDTO.descripcionLarga
            mFecha = pDTO.fecha
            mDvh = pDTO.dvh
            mCriticidad = pDTO.criticidad
        End Sub
        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = Datos.BitacoraDatos.ObtenerProximoId()
            End If
            ProximoId += 1
            Return ProximoId
        End Function
        Public Overridable Function Listar() As Collections.Generic.List(Of Bitacora)
            Dim mCol As New Collections.Generic.List(Of Bitacora)
            Dim mColDTO As List(Of DTO.BitacoraDTO) = Datos.BitacoraDatos.Listar()

            For Each mDTO As DTO.BitacoraDTO In mColDTO
                mCol.Add(New Negocio.Bitacora(mDTO))
            Next

            Return mCol
        End Function

        Public Overridable Function ListarConFiltro(ByVal pUsuario As Integer,
                                                    ByVal pFechaDesde As Date,
                                                    ByVal pFechaHasta As Date,
                                                    ByVal pCriticidad As String) As Collections.Generic.List(Of Bitacora)
            Dim mCol As New Collections.Generic.List(Of Bitacora)
            Dim mColDTO As List(Of DTO.BitacoraDTO) = Datos.BitacoraDatos.ListarConFiltro(pUsuario, pFechaDesde, pFechaHasta, pCriticidad)

            For Each mDTO As DTO.BitacoraDTO In mColDTO
                mCol.Add(New Negocio.Bitacora(mDTO))
            Next

            Return mCol
        End Function
#End Region


    End Class
End Namespace
