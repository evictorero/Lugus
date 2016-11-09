Imports DTO.PlatoDTO
Imports Datos.ProveedorDeDatos.DB

Public Class PlatoDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.PlatoDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.bPlato (id_plato, descripcion_corta, descripcion_larga, habilitado,  id_usuario, dvh, fecha_modif)" &
        " VALUES " &
        "(" & pDTO.id & ", '" & pDTO.descripcionCorta & "' , '" & pDTO.descripcionLarga & "' , '" & pDTO.habilitado & "', " & pDTO.idUsuario & ", " & pDTO.dvh & ", '" & DateTime.Now.ToString("yyyyMMdd HH:mm:ss") & "')"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la plato", ex)
        End Try
    End Sub

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.PlatoDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE bPlato " &
                  " SET descripcion_corta = '" & pDTO.descripcionCorta & "'," &
                  " descripcion_larga =  '" & pDTO.descripcionLarga & "'," &
                  " habilitado =  '" & pDTO.habilitado & "'," &
                  " id_usuario =  " & pDTO.idUsuario & "," &
                  " dvh =  " & pDTO.dvh & "," &
                  " fecha_modif =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" &
                  " WHERE id_plato = " & pDTO.id
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar la plato", ex)
        End Try

    End Sub

    Public Shared Sub Eliminar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bPlato " &
                      " SET fecha_baja =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" &
                      " WHERE id_plato = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja la plato", ex)
        End Try
    End Sub

    Public Shared Sub Rehabilitar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bPlato " &
                  " SET fecha_baja =  null " &
                  " WHERE id_plato = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al rehabilitar la plato", ex)
        End Try
    End Sub

    Public Shared Function Obtener(ByVal pId As Integer) As DTO.PlatoDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_plato, descripcion_corta, descripcion_larga, habilitado, fecha_baja, id_usuario, dvh, fecha_modif FROM bPlato WHERE id_plato = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.PlatoDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la plato")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una plato sin Id especificado")
            Return Nothing
        End If

    End Function

    Public Shared Function Listar() As List(Of DTO.PlatoDTO)
        Dim mCol As New List(Of DTO.PlatoDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_plato,descripcion_corta,descripcion_larga,habilitado,fecha_baja,id_usuario,dvh,fecha_modif FROM dbo.bPlato")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.PlatoDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function ObtenerProximoId() As Integer
        If ProximoId = 0 Then
            ProximoId = Datos.ProveedorDeDatos.DB.ObtenerId("bPlato")
        End If
        ProximoId += 1
        Return ProximoId
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.PlatoDTO, ByVal pDr As DataRow)
        pDTO.id = pDr("id_plato")
        pDTO.descripcionCorta = pDr("descripcion_corta")
        pDTO.descripcionLarga = pDr("descripcion_larga")
        pDTO.habilitado = pDr("habilitado")
        If Not IsDBNull(pDr("fecha_baja")) Then
            pDTO.fechaBaja = pDr("fecha_baja")
        End If
        pDTO.idUsuario = pDr("id_usuario")
        pDTO.dvh = pDr("dvh")
        pDTO.fechaModif = pDr("fecha_modif")
    End Sub

End Class
