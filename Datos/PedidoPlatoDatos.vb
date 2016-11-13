Imports DTO.PedidoPlatoDTO
Imports Datos.ProveedorDeDatos.DB

Public Class PedidoPlatoDatos
    Private Shared ProximoId As Integer
    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.PedidoPlatoDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.rPedidoPlato  (id_pedido,id_plato,id_usuario_alta,estado,dvh) VALUES " &
            "(" & pDTO.Id_pedido & ", " & pDTO.id_plato & " , " & pDTO.Id_Usuario_alta & " , '" & pDTO.Estado & "' , " & pDTO.Dvh & ")"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la relacion Pedido Plato", ex)
        End Try
    End Sub
    Public Shared Sub Eliminar(ByVal pId_pedido As Integer, ByVal pid_plato As Integer)
        Dim mStrCom As String

        mStrCom = "DELETE FROM dbo.rPedidoPlato" &
                       " WHERE Id_pedido =  " & pId_pedido & " and id_plato = " & pid_plato
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja la Pedido Plato", ex)
        End Try
    End Sub
    Public Shared Function Obtener(ByVal pId As Integer) As DTO.PedidoPlatoDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_plato,id_usuario_alta,estado, dvh FROM dbo.rPedidoPlato WHERE id_plato = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.PedidoPlatoDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Pedido Plato")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Pedido Plato sin Id especificado")
            Return Nothing
        End If
    End Function

    Public Shared Function Obtener(ByVal pId_pedido As Integer, ByVal pId_plato As Integer) As DTO.PedidoPlatoDTO
        If pId_pedido > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_plato,id_usuario_alta,estado, dvh FROM dbo.rPedidoPlato WHERE id_plato = " & pId_pedido & " and id_pedido = " & pId_plato)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.PedidoPlatoDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Pedido Plato")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Pedido Plato sin Id especificado")
            Return Nothing
        End If
    End Function

    Public Shared Function Listar(ByVal pId_pedido As Integer) As List(Of DTO.PedidoPlatoDTO)
        Dim mCol As New List(Of DTO.PedidoPlatoDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_plato,id_usuario_alta,estado,dvh FROM dbo.rPedidoPlato where id_pedido = " & pId_pedido)

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.PedidoPlatoDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function
    Public Shared Function Listar() As List(Of DTO.PedidoPlatoDTO)
        Dim mCol As New List(Of DTO.PedidoPlatoDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_plato, estado, dvh,id_usuario_alta FROM dbo.rpedidoplato")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.PedidoPlatoDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.PedidoPlatoDTO, ByVal pDr As DataRow)
        pDTO.Id_pedido = pDr("id_pedido")
        pDTO.id_plato = pDr("id_plato")
        pDTO.Id_Usuario_alta = pDr("Id_Usuario_alta")
        pDTO.Estado = pDr("estado")
        pDTO.Dvh = pDr("dvh")
    End Sub

    Public Shared Function Existe(ByVal pId_pedido As Integer, ByVal pid_plato As Integer) As Boolean

        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_plato,id_usuario_alta,estado,dvh FROM dbo.rPedidoPlato where id_pedido = " & pId_pedido & " and id_plato = " & pid_plato)

        Dim rta As Boolean = False

        For Each mDr As DataRow In mDs.Tables(0).Rows
            rta = True
        Next

        Return rta

    End Function
    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.PedidoPlatoDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE rPedidoPlato " &
                   "SET estado = '" & pDTO.Estado & "'," &
                      "dvh = " & pDTO.Dvh &
                     " where id_pedido = " & pDTO.Id_pedido &
                      "and id_plato = " & pDTO.id_plato
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar el pedido plato.", ex)
        End Try

    End Sub
End Class

