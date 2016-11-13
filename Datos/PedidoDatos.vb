Imports Datos.ProveedorDeDatos
Imports System.Data.SqlClient
Imports DTO.PedidoDTO

Public Class PedidoDatos
        Private Shared ProximoId As Integer
    Public Shared Function Obtener(ByVal pId As Integer) As DTO.PedidoDTO
        If pId > 0 Then
            Dim mDs As DataSet = DB.ExecuteDataset("SELECT id_pedido, descripcion, estado, fecha_baja,cantidad,fecha_modif,id_usuario_alta  FROM dbo.bPedido WHERE id_pedido = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.PedidoDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else
                Throw New ApplicationException("Fallo al cargar el Pedido.")

            End If
        Else
            Throw New ApplicationException("Se intentó cargar el Usuario sin Id especificado")
        End If

    End Function
    Private Shared Sub CargarDTO(ByVal pDTO As DTO.PedidoDTO, ByVal pDr As DataRow)
        pDTO.id = pDr("id_pedido")
        pDTO.descripcion = pDr("descripcion")
        pDTO.estado = pDr("estado")
        If Not IsDBNull(pDr("fecha_baja")) Then
            pDTO.fechaBaja = pDr("fecha_baja")
        End If
        pDTO.cantidad = pDr("cantidad")
        pDTO.fechaModif = pDr("fecha_modif")
        pDTO.idUsuarioAlta = pDr("id_usuario_alta")
    End Sub
    Public Shared Function Listar() As List(Of DTO.PedidoDTO)

        Dim mCol As New List(Of DTO.PedidoDTO)
        Dim mDs As DataSet = DB.ExecuteDataset(("SELECT id_pedido, descripcion, estado,fecha_baja,cantidad,fecha_modif,id_usuario_alta FROM dbo.bPedido "))

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.PedidoDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function
    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.PedidoDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO [dbo].[bPedido] ([id_pedido],[descripcion],[estado],[cantidad],[fecha_modif],[id_usuario_alta])" &
        " VALUES " &
        "(" & pDTO.id & ", '" & pDTO.descripcion & "', '" & pDTO.estado & "', " & pDTO.cantidad & ",'" & DateTime.Now.ToString("yyyyMMdd HH:mm:ss") & "'," & pDTO.idUsuarioAlta & ")"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar el Pedido", ex)
        End Try
    End Sub
    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.PedidoDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE bPedido " &
                   "SET descripcion = '" & pDTO.descripcion & "'," &
                      "estado = '" & pDTO.estado & "'," &
                      "cantidad = " & pDTO.cantidad & "," &
                      "fecha_modif =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'," &
                      "id_usuario_alta = " & pDTO.idUsuarioAlta &
                     " where id_pedido = " & pDTO.id

        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar el pedido", ex)
        End Try

    End Sub
    Public Shared Sub Eliminar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bPedido " &
                  " SET fecha_baja =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" &
                  ", estado = 'F' " &
                  " WHERE id_pedido = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja el pedido.", ex)
        End Try
    End Sub
    Public Shared Sub Rehabilitar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bPedido " &
                  " SET fecha_baja =  null " &
                  ", estado = 'I' " &
                  " WHERE id_pedido = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al Rehabilitar el pedido.", ex)
        End Try
    End Sub
    Public Shared Function ObtenerProximoId() As Integer
        If ProximoId = 0 Then
            ProximoId = Datos.ProveedorDeDatos.DB.ObtenerId("bPedido")
        End If
        ProximoId += 1
        Return ProximoId
    End Function

End Class
