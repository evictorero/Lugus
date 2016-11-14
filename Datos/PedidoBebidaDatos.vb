Imports DTO.PedidoBebidaDTO
Imports Datos.ProveedorDeDatos.DB

    Public Class PedidoBebidaDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.PedidoBebidaDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.rPedidoBebida  (id_pedido,id_bebida,id_usuario_alta,estado,dvh) VALUES " &
            "(" & pDTO.Id_pedido & ", " & pDTO.id_bebida & " , " & pDTO.Id_Usuario_alta & " , '" & pDTO.Estado & "' , " & pDTO.Dvh & ")"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la relacion Pedido Bebida", ex)
        End Try
    End Sub

    Public Shared Sub Eliminar(ByVal pId_pedido As Integer, ByVal pid_bebida As Integer)
        Dim mStrCom As String

        mStrCom = "DELETE FROM dbo.rPedidoBebida" &
                       " WHERE Id_pedido =  " & pId_pedido & " and id_bebida = " & pid_bebida
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja la Pedido Bebida", ex)
        End Try
    End Sub

    Public Shared Function Obtener(ByVal pId As Integer) As DTO.PedidoBebidaDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_bebida,id_usuario_alta,estado, dvh FROM dbo.rPedidoBebida WHERE id_bebida = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.PedidoBebidaDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Pedido Bebida")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Pedido Bebida sin Id especificado")
            Return Nothing
        End If
    End Function

    Public Shared Function Obtener(ByVal pId_pedido As Integer, ByVal pid_bebida As Integer) As DTO.PedidoBebidaDTO
        If pId_pedido > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_bebida,id_usuario_alta,estado, dvh FROM dbo.rPedidoBebida WHERE id_bebida = " & pId_pedido & " and id_pedido = " & pid_bebida)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.PedidoBebidaDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Pedido Bebida")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Pedido Bebida sin Id especificado")
            Return Nothing
        End If
    End Function

    Public Shared Function Listar(ByVal pId_pedido As Integer) As List(Of DTO.PedidoBebidaDTO)
        Dim mCol As New List(Of DTO.PedidoBebidaDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_bebida,id_usuario_alta,estado,dvh FROM dbo.rPedidoBebida where id_pedido = " & pId_pedido)

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.PedidoBebidaDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function Listar() As List(Of DTO.PedidoBebidaDTO)
        Dim mCol As New List(Of DTO.PedidoBebidaDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_bebida, estado, dvh,id_usuario_alta FROM dbo.rPedidoBebida")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.PedidoBebidaDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.PedidoBebidaDTO, ByVal pDr As DataRow)
        pDTO.Id_pedido = pDr("id_pedido")
        pDTO.id_bebida = pDr("id_bebida")
        pDTO.Id_Usuario_alta = pDr("Id_Usuario_alta")
        pDTO.Estado = pDr("estado")
        pDTO.Dvh = pDr("dvh")
    End Sub

    Public Shared Function Existe(ByVal pId_pedido As Integer, ByVal pid_bebida As Integer) As Boolean

        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_pedido,id_bebida,id_usuario_alta,estado,dvh FROM dbo.rPedidoBebida where id_pedido = " & pId_pedido & " and id_bebida = " & pid_bebida)

        Dim rta As Boolean = False

        For Each mDr As DataRow In mDs.Tables(0).Rows
            rta = True
        Next

        Return rta

    End Function

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.PedidoBebidaDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE rPedidoBebida " &
                   "SET estado = '" & pDTO.Estado & "'," &
                      "dvh = " & pDTO.Dvh &
                     " where id_pedido = " & pDTO.Id_pedido &
                      "and id_bebida = " & pDTO.id_bebida
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar el pedido Bebida.", ex)
        End Try

    End Sub
End Class

