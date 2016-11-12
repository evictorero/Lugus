Imports DTO.FamiliaDTO
Imports Datos.ProveedorDeDatos.DB

Public Class FamiliaDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.FamiliaDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.bFamilia (id_Familia, descripcion_corta, descripcion_larga, id_usuario_alta, dvh, fecha_modif)" &
        " VALUES " &
        "(" & pDTO.id & ", '" & pDTO.descripcionCorta & "' , '" & pDTO.descripcionLarga & "' , " & pDTO.idUsuario & ", " & pDTO.dvh & ", '" & DateTime.Now.ToString("yyyyMMdd HH:mm:ss") & "')"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la Familia", ex)
        End Try
    End Sub

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.FamiliaDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE bFamilia " &
                  " SET descripcion_corta = '" & pDTO.descripcionCorta & "'," &
                  " descripcion_larga =  '" & pDTO.descripcionLarga & "'," &
                  " id_usuario_alta =  " & pDTO.idUsuario & "," &
                  " dvh =  " & pDTO.dvh & "," &
                  " fecha_modif =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" &
                  " WHERE id_Familia = " & pDTO.id
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar la Familia", ex)
        End Try

    End Sub

    Public Shared Sub Eliminar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bFamilia " &
                  " SET fecha_baja =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" &
                  " WHERE id_Familia = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja la Familia", ex)
        End Try
    End Sub

    Public Shared Sub Rehabilitar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bFamilia " &
                  " SET fecha_baja =  null " &
                  " WHERE id_Familia = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al rehabilitar la Familia", ex)
        End Try
    End Sub

    Public Shared Function Obtener(ByVal pId As Integer) As DTO.FamiliaDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_Familia, descripcion_corta, descripcion_larga, fecha_baja, id_usuario_alta, dvh, fecha_modif FROM bFamilia WHERE id_Familia = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.FamiliaDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Familia")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Familia sin Id especificado")
            Return Nothing
        End If

    End Function

    Public Shared Function Listar() As List(Of DTO.FamiliaDTO)
        Dim mCol As New List(Of DTO.FamiliaDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_Familia,descripcion_corta,descripcion_larga,fecha_baja,id_usuario_alta,dvh,fecha_modif FROM dbo.bFamilia")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.FamiliaDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function ObtenerProximoId() As Integer
        If ProximoId = 0 Then
            ProximoId = Datos.ProveedorDeDatos.DB.ObtenerId("bFamilia")
        End If
        ProximoId += 1
        Return ProximoId
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.FamiliaDTO, ByVal pDr As DataRow)
        ' id_Familia,descripcion_corta,descripcion_larga,habilitado,fecha_baja,id_usuario_alta,dvh,fecha_modif
        pDTO.id = pDr("id_Familia")
        pDTO.descripcionCorta = pDr("descripcion_corta")
        pDTO.descripcionLarga = pDr("descripcion_larga")
        If Not IsDBNull(pDr("fecha_baja")) Then
            pDTO.fechaBaja = pDr("fecha_baja")
        End If

        'End If
        pDTO.idUsuario = pDr("id_usuario_alta")
        pDTO.dvh = pDr("dvh")
        pDTO.fechaModif = pDr("fecha_modif")
    End Sub

    Public Shared Sub ValidarDatos(ByVal pId As Integer)
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT * FROM rUsuarioFamilia WHERE id_Familia = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Throw New ApplicationException("Familia asociada a un usuario.")
            End If
        Else
            Throw New ApplicationException("Se intentó borrar una Familia sin Id especificado")
        End If
    End Sub

    Public Shared Function ExisteDescripcion(ByVal pDTO As DTO.FamiliaDTO) As Boolean
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_familia FROM dbo.bfamilia WHERE descripcion_corta = '" & pDTO.descripcionCorta & "' and id_familia != " & pDTO.id)
        If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
