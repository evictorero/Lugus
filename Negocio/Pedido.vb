Imports Microsoft.VisualBasic
Imports DTO.PedidoDTO
Imports Datos.ProveedorDeDatos
Imports System.Globalization
Imports System.Text.RegularExpressions


Namespace Negocio
    Public Class Pedido : Implements IColeccionable

#Region "Declaraciones"

        Dim mDescripcion As String
        Dim mEstado As String
        Dim mCantidad As Integer
        Dim mFechaBaja As Nullable(Of DateTime)
        Dim mIdUsuarioAlta As Integer
        Dim mFechaModif As Date
        Private Shared ProximoId As Integer
        Dim mId As Integer = 0

        'Esta coleccion alojara las patentes de cada usuario
        Protected mPedidoPlato As New Collections.Generic.List(Of PedidoPlato)

        'Esta coleccion alojara las familia de cada usuario
        'Protected mUsuarioFamilia As New Collections.Generic.List(Of UsuarioFamilia)

#End Region

#Region "Constructores"
        Public Sub New(ByVal pId As Integer)
            mId = pId
            Cargar()
        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.PedidoDTO)
            Me.Cargar(pDTO)
            Me.CargarPedidoPlato()
        End Sub
        Public Sub New()
            mId = 0
        End Sub
#End Region

#Region "Propiedades"
        Public Property Descripcion() As String
            Get
                Return mDescripcion
            End Get
            Set(ByVal value As String)
                mDescripcion = value
            End Set
        End Property
        Public Property Estado() As String
            Get
                Return mEstado
            End Get
            Set(ByVal value As String)
                mEstado = value
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
        Public Property cantidad() As Integer
            Get
                Return mCantidad
            End Get
            Set(ByVal value As Integer)
                mCantidad = value
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

        Public ReadOnly Property PedidoPlato() As Collections.Generic.List(Of PedidoPlato)
            Get
                Return Me.FiltrarPedidoPlatoNoVisibles
            End Get
        End Property


        'Public ReadOnly Property UsuarioFamilia() As Collections.Generic.List(Of UsuarioFamilia)
        '    Get
        '        Return Me.FiltrarUsuarioFamiliaNoVisibles
        '    End Get
        'End Property
#End Region


#Region "Métodos"

        Public Overridable Sub Cargar()
            If mId > 0 Then
                Dim mDTO As DTO.PedidoDTO = Datos.PedidoDatos.Obtener(mId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Pedido sin Id especificado")
            End If
        End Sub
        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mId = pDr("id")
                mDescripcion = pDr("Descripcion")
                mEstado = pDr("Estado")
                mFechaModif = pDr("fecha_modif")
                mCantidad = pDr("Cantidad")
                mIdUsuarioAlta = pDr("id_usuario_alta")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        Public Overridable Sub Cargar(ByVal pId As Integer)
            If pId > 0 Then
                Dim mDTO As DTO.PedidoDTO = Datos.PedidoDatos.Obtener(pId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Pedido sin Id especificado")
            End If
        End Sub
        Public Sub Cargar(ByVal pDTO As DTO.PedidoDTO)
            mId = pDTO.id
            mDescripcion = pDTO.descripcion
            mEstado = pDTO.estado
            mFechaBaja = pDTO.fechaBaja
            mCantidad = pDTO.cantidad
            mFechaModif = pDTO.fechaModif
            mIdUsuarioAlta = pDTO.idUsuarioAlta
        End Sub
        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = DB.ObtenerId("bPedido")
                If mTempId Is DBNull.Value Then
                    ProximoId = 0
                Else
                    ProximoId = mTempId
                End If
            End If
            ProximoId += 1
            Return ProximoId
        End Function
        Public Overridable Function Listar() As Collections.Generic.List(Of Pedido)
            Dim mCol As New Collections.Generic.List(Of Pedido)
            Dim mColDTO As List(Of DTO.PedidoDTO) = Datos.PedidoDatos.Listar()
            Dim miPedido As Negocio.Pedido
            For Each mDTO As DTO.PedidoDTO In mColDTO
                miPedido = New Negocio.Pedido(mDTO)
                mCol.Add(miPedido)
            Next
            Return mCol
        End Function
        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.PedidoDTO
            mDTO.descripcion = Me.Descripcion
            mDTO.estado = Me.Estado
            mDTO.idUsuarioAlta = Me.idUsuarioAlta
            mDTO.fechaModif = Me.mFechaModif
            mDTO.cantidad = Me.cantidad

            If mId = 0 Then
                mDTO.id = Datos.PedidoDatos.ObtenerProximoId()
                Datos.PedidoDatos.GuardarNuevo(mDTO)
                Dim mBitacora As New Negocio.Bitacora(Me.mIdUsuarioAlta, "Creación del Pedido : " & Me.id, "Media")
                mBitacora.Guardar()
            Else
                mDTO.id = Me.id
                Datos.PedidoDatos.GuardarModificacion(mDTO)
                Dim mBitacora As New Negocio.Bitacora(Me.mIdUsuarioAlta, "Modificación del Pedido: " & Me.id, "Media")
                mBitacora.Guardar()
            End If

            Me.GuardarPedidoPlatos()
            'Me.GuardarUsuarioFamilias()
        End Sub

        Public Sub ValidarFormato(pid_idioma As Integer)
            If (Me.Descripcion = "") Then
                Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar el Descripcion del pedido."))
            End If
            If (Me.Estado = "") Then
                Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar el Estado del pedido."))
            End If

            If Not ValidarCantidad() Then
                Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Error al querer guardar pedido: La cantidad ingresada no tiene el formato correcto."))
            End If
        End Sub

        Function ValidarCantidad() As Boolean
            If IsNothing(Me.cantidad) Or Me.cantidad < 1 Then Return False
            Return True
        End Function

        Public Overridable Sub Eliminar()
            If mId > 0 Then
                Try
                    Datos.PedidoDatos.Eliminar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar el pedido especificado.", ex)
                End Try
            Else
                Throw New ApplicationException("Se intentó eliminar un pedido sin Id especifico.")
            End If
        End Sub

        Public Overridable Sub Rehabilitar()
            If mId > 0 Then
                Try
                    Datos.PedidoDatos.Rehabilitar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al activar el pedido especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó activar un pedido sin Id especifico.")
            End If
        End Sub

        'Public Function ListarPatentesDeFamiliaPorUsuario() As List(Of PedidoPlato)
        '    Dim mCol As New List(Of PedidoPlato)
        '    Dim mColDTO As List(Of DTO.PedidoPlatoDTO) = Datos.PedidoPlatoDatos.ListarPatentesDeFamiliaPorUsuario(Me.mId)
        '    Dim miPedidoPlato As Negocio.PedidoPlato
        '    For Each mDTO As DTO.PedidoPlatoDTO In mColDTO
        '        miPedidoPlato = New Negocio.PedidoPlato(mDTO)
        '        mCol.Add(miPedidoPlato)
        '    Next
        '    Return mCol
        'End Function
        'Public Function ListarPatentesDeFamiliaPorUsuario(ByVal pId_Familia As Integer) As List(Of PedidoPlato)
        '    Dim mCol As New List(Of PedidoPlato)
        '    Dim mColDTO As List(Of DTO.PedidoPlatoDTO) = Datos.PedidoPlatoDatos.ListarPatentesDeFamiliaPorUsuario(Me.mId, pId_Familia)
        '    Dim miPedidoPlato As Negocio.PedidoPlato
        '    For Each mDTO As DTO.PedidoPlatoDTO In mColDTO
        '        miPedidoPlato = New Negocio.PedidoPlato(mDTO)
        '        mCol.Add(miPedidoPlato)
        '    Next
        '    Return mCol
        'End Function
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

#Region "PedidoPlato"
        Public Sub EliminarPedidoPlato(ByVal pPedidoPlato As PedidoPlato)
            EliminarPedidoPlato(pPedidoPlato.IndiceColeccion)
        End Sub
        Public Sub EliminarPedidoPlato(ByVal pIndice As Integer)
            If Me.mPedidoPlato(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Then
                Me.mPedidoPlato(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Quitado
            Else
                Me.mPedidoPlato(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Borrado
            End If

        End Sub
        Public Sub ModificarPedidoPlato(ByVal pPedidoPlato As PedidoPlato)
            Me.mPedidoPlato(pPedidoPlato.IndiceColeccion) = pPedidoPlato
            If Not pPedidoPlato.EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Then
                pPedidoPlato.EstadoColeccion = IColeccionable.EstadosColeccion.Modificado
            End If

        End Sub
        Public Sub AgregarPedidoPlato(ByVal pPedidoPlato As PedidoPlato)
            Me.mPedidoPlato.Add(pPedidoPlato)
            Dim mInd As Integer = Me.mPedidoPlato.IndexOf(pPedidoPlato)
            Me.mPedidoPlato(mInd).IndiceColeccion = mInd
            Me.mPedidoPlato(mInd).EstadoColeccion = IColeccionable.EstadosColeccion.Agregado

            'POR ULTIMO EL NUEVO PedidoPlato DEBE SABER A QUE Usuario PERTENECE
            Me.mPedidoPlato(mInd).id_pedido = mId
        End Sub
        Private Sub GuardarPedidoPlatos()
            Dim mLock As New Object
            Dim mReacomodar As Boolean = False
            SyncLock mLock
                Dim mEliminados As Integer = 0
                For x As Integer = 0 To Me.mPedidoPlato.Count - 1
                    Select Case Me.mPedidoPlato(x - mEliminados).EstadoColeccion
                        Case IColeccionable.EstadosColeccion.Agregado, IColeccionable.EstadosColeccion.Modificado
                            If Me.mPedidoPlato(x - mEliminados).id_pedido = 0 Then
                                Me.mPedidoPlato(x - mEliminados).id_pedido = mId
                            End If
                            If Me.mPedidoPlato(x - mEliminados).EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Then
                                Me.mPedidoPlato(x - mEliminados).Guardar()
                            Else
                                Me.mPedidoPlato(x - mEliminados).GuardarModificacion()
                            End If
                            Me.mPedidoPlato(x - mEliminados).EstadoColeccion = IColeccionable.EstadosColeccion.SinCambio

                        Case IColeccionable.EstadosColeccion.Borrado


                            Me.mPedidoPlato(x - mEliminados).Eliminar()
                            Me.mPedidoPlato.RemoveAt(Me.mPedidoPlato(x - mEliminados).IndiceColeccion)
                            mEliminados += 1
                            mReacomodar = True

                        Case IColeccionable.EstadosColeccion.Quitado
                            Me.mPedidoPlato.RemoveAt(Me.mPedidoPlato(x - mEliminados).IndiceColeccion)
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
            For Each mT As PedidoPlato In Me.mPedidoPlato
                mT.IndiceColeccion = Me.mPedidoPlato.IndexOf(mT)
            Next
        End Sub
        Private Sub CargarPedidoPlato()
            'AL CARGAR LOS PedidoPlatos SIMPLEMENTE ASIGAMOS LA COLECCION QUE DEVUELVE EL METODO
            'LISTAR
            'INMEDIATAMENTE DESPUES LE AVISAMOS A CADA OBJETO PedidoPlato QUE INDICE LE TOCO EN LA LISTA
            If mPedidoPlato.Count = 0 Then
                Me.mPedidoPlato = (New Negocio.PedidoPlato).Listar(mId)
            End If
            For Each mT As PedidoPlato In mPedidoPlato
                mT.IndiceColeccion = Me.mPedidoPlato.IndexOf(mT)
            Next
        End Sub
        Private Function FiltrarPedidoPlatoNoVisibles() As Collections.Generic.List(Of PedidoPlato)
            'ESTE METODO PERMITIRA FILTRAR LOS PedidoPlatos ANTES DE MOSTRARLOS EN UN GRILLA
            'SE SUPONE QUE EN LA GRILLA NO SE VERAN LOS PedidoPlatos BORRADOS Y QUITADOS
            Dim mCol As New Collections.Generic.List(Of PedidoPlato)
            CargarPedidoPlato()

            For Each mT As PedidoPlato In Me.mPedidoPlato
                If mT.EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Or mT.EstadoColeccion = IColeccionable.EstadosColeccion.Modificado Or mT.EstadoColeccion = IColeccionable.EstadosColeccion.SinCambio Then
                    mCol.Add(mT)
                End If
            Next
            ReacomodarIndices()
            Return mCol
        End Function
        Public Function ObtenerPedidoPlatoPorIndice(ByVal pIndice As Integer) As PedidoPlato
            Return Me.mPedidoPlato(pIndice)
        End Function
#End Region




    End Class
End Namespace

