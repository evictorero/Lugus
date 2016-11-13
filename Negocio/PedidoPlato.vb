Imports Datos.ProveedorDeDatos.DB

Namespace Negocio

    Public Class PedidoPlato : Implements IColeccionable

#Region "Declaraciones"
        Dim mId_pedido As Integer
        Dim mId_Plato As Integer
        Dim mId_Usuario_alta As Integer
        Dim mEstado As String
        Dim mDvh As Integer
#End Region

#Region "Constructores"
        Public Sub New()

        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.PedidoPlatoDTO)
            Me.Cargar(pDTO)
        End Sub
#End Region

#Region "Propiedades"
        Public Property Id_Plato() As Integer
            Get
                Return mId_Plato
            End Get
            Set(ByVal value As Integer)
                mId_Plato = value
            End Set
        End Property

        Public Property id_pedido() As Integer
            Get
                Return mId_pedido
            End Get
            Set(ByVal value As Integer)
                mId_pedido = value
            End Set
        End Property


        Public Property id_usuario_alta() As Integer
            Get
                Return mId_Usuario_alta
            End Get
            Set(ByVal value As Integer)
                mId_Usuario_alta = value
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
        Public Property dvh() As Integer
            Get
                Return mDvh
            End Get
            Set(ByVal value As Integer)
                mDvh = value
            End Set
        End Property
#End Region

#Region "Métodos"

        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.PedidoPlatoDTO
            Dim Existe As Boolean = False

            mDTO.id_pedido = Me.id_pedido
            mDTO.Id_Plato = Me.Id_Plato
            mDTO.Id_Usuario_alta = Me.id_usuario_alta
            mDTO.Estado = Me.mEstado

            Existe = Datos.PedidoPlatoDatos.Existe(mDTO.Id_pedido, mDTO.id_plato)

            'Recalculo del digito verificador horizontal
            Dim CadenaDigitoVerificador As String = Convert.ToString(mDTO.Id_pedido) + Convert.ToString(mDTO.id_plato)
            mDTO.Dvh = Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)

            If Not Existe Then
                Datos.PedidoPlatoDatos.GuardarNuevo(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Pedido Plato ya existente.")
            End If
            'Recalculo del digito verificador vertical
            Dim mDVV As New Negocio.DigitoVerificador("rPedidoPlato")
            mDVV.tabla = "rPedidoPlato"
            mDVV.valor = Negocio.DigitoVerificador.CalcularDVV("rPedidoPlato")
            mDVV.Guardar()

        End Sub
        Public Overridable Sub Cargar()
            If mId_Plato > 0 Then
                Dim mDTO As DTO.PedidoPlatoDTO = Datos.PedidoPlatoDatos.Obtener(mId_Plato)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Pedido plato sin Id especificado")

            End If
        End Sub

        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mId_pedido = pDr("id_pedido")
                mId_Plato = pDr("Id_Plato")
                mId_Usuario_alta = pDr("id_usuario_alta")
                mEstado = pDr("Estado")
                mDvh = pDr("dvh")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Public Overridable Sub Cargar(ByVal pId_Plato As Integer)
            If mId_Plato > 0 Then
                Dim mDTO As DTO.PedidoPlatoDTO = Datos.PedidoPlatoDatos.Obtener(pId_Plato)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Pedido Plato  sin Id especificado")
            End If
        End Sub

        Public Sub Cargar(ByVal pDTO As DTO.PedidoPlatoDTO)
            mId_pedido = pDTO.Id_pedido
            mId_Plato = pDTO.id_plato
            mId_Usuario_alta = pDTO.Id_Usuario_alta
            mEstado = pDTO.Estado
            mDvh = pDTO.Dvh
        End Sub

        Public Overridable Sub Eliminar()
            If mId_Plato > 0 And mId_pedido > 0 Then
                Try

                    Datos.PedidoPlatoDatos.Eliminar(mId_pedido, mId_Plato)
                Catch ex As Exception

                    Throw New ApplicationException("Error al borrar la Pedido Plato especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar Pedido Plato  sin Id especifico.")
            End If
        End Sub

        Public Overridable Function Listar() As Collections.Generic.List(Of PedidoPlato)
            Dim mCol As New Collections.Generic.List(Of PedidoPlato)
            Dim mColDTO As List(Of DTO.PedidoPlatoDTO) = Datos.PedidoPlatoDatos.Listar()

            For Each mDTO As DTO.PedidoPlatoDTO In mColDTO
                mCol.Add(New Negocio.PedidoPlato(mDTO))
            Next

            Return mCol
        End Function

        Public Overridable Function Listar(ByVal pId_pedido As Integer) As Collections.Generic.List(Of PedidoPlato)
            Dim mCol As New Collections.Generic.List(Of PedidoPlato)
            Dim mColDTO As List(Of DTO.PedidoPlatoDTO) = Datos.PedidoPlatoDatos.Listar(pId_pedido)

            For Each mDTO As DTO.PedidoPlatoDTO In mColDTO
                mCol.Add(New Negocio.PedidoPlato(mDTO))
            Next

            Return mCol
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

    End Class
End Namespace

