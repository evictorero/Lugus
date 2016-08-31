Imports DTO.BebidaDTO
Imports Datos.ProveedorDeDatos.DB

Public Class BebidaDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.BebidaDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.bBebida (id_bebida, descripcion_corta, descripcion_larga, habilitado, fecha_baja, id_usuario, dvh, fecha_modif)" & _
        " VALUES " & _
        "(" & pDTO.id & ", '" & pDTO.descripcionCorta & "' , '" & pDTO.descripcionLarga & "' , '" & pDTO.habilitado & "', '" & pDTO.fechaBaja & "', " & pDTO.idUsuario & ", " & pDTO.dvh & ", '" & DateTime.Now.ToString("yyyyMMdd HH:mm:ss") & "')"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar o modificar la bebida", ex)
        End Try
    End Sub

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.BebidaDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE bBebida " & _
                  " SET descripcion_corta = '" & pDTO.descripcionCorta & "'," & _
                  " descripcion_larga =  " & pDTO.descripcionLarga & "," & _
                  " habilitado =  " & pDTO.habilitado & _
                  " fecha_baja =  " & pDTO.fechaBaja & _
                  " id_usuario =  " & pDTO.idUsuario & _
                  " dvh =  " & pDTO.dvh & _
                  " fecha_modif =  " & DateTime.Now & _
                  " WHERE id = " & pDTO.id
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar o modificar la bebida", ex)
        End Try

    End Sub

    Public Shared Sub Eliminar(ByVal pId As Integer)
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery("DELETE FROM bBebida WHERE id = " & pId)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al borrar la bebida", ex)
        End Try
    End Sub

    Public Shared Function Obtener(ByVal pId As Integer) As DTO.BebidaDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_bebida, descripcion_corta, descripcion_larga, habilitado, fecha_baja, id_usuario, dvh, fecha_modif FROM bBebida WHERE id = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.BebidaDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la bebida")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una bebida sin Id especificado")
            Return Nothing
        End If

    End Function

    Public Shared Function Listar() As List(Of DTO.BebidaDTO)
        Dim mCol As New List(Of DTO.BebidaDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_bebida,descripcion_corta,descripcion_larga,habilitado,fecha_baja,id_usuario,dvh,fecha_modif FROM dbo.bBebida")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.BebidaDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function ObtenerProximoId() As Integer
        If ProximoId = 0 Then
            ProximoId = Datos.ProveedorDeDatos.DB.ObtenerId("bBebida")
        End If
        ProximoId += 1
        Return ProximoId
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.BebidaDTO, ByVal pDr As DataRow)
        ' id_bebida,descripcion_corta,descripcion_larga,habilitado,fecha_baja,id_usuario,dvh,fecha_modif
        pDTO.id = pDr("id_bebida")
        pDTO.descripcionCorta = pDr("descripcion_corta")
        pDTO.descripcionLarga = pDr("descripcion_larga")
        pDTO.habilitado = pDr("habilitado")
        pDTO.fechaBaja = pDr("fecha_baja")
        pDTO.idUsuario = pDr("id_usuario")
        pDTO.dvh = pDr("dvh")
        pDTO.fechaModif = pDr("fecha_modif")
    End Sub

End Class
