
Imports DTO.PatenteDTO
Imports Datos.ProveedorDeDatos.DB

Public Class PatenteDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.PatenteDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.bPatente (id_Patente, descripcion_corta, descripcion_larga, habilitado,  id_usuario, dvh, fecha_modif)" &
    " VALUES " &
    "(" & pDTO.id & ", '" & pDTO.descripcionCorta & "' , '" & pDTO.descripcionLarga & "' , " & pDTO.idUsuario & ", " & pDTO.dvh & ", '" & DateTime.Now.ToString("yyyyMMdd HH:mm:ss") & "')"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la Patente", ex)
        End Try
    End Sub

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.PatenteDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE bPatente " &
              " SET descripcion_corta = '" & pDTO.descripcionCorta & "'," &
              " descripcion_larga =  '" & pDTO.descripcionLarga & "'," &
              " id_usuario =  " & pDTO.idUsuario & "," &
              " dvh =  " & pDTO.dvh & "," &
              " fecha_modif =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" &
              " WHERE id_Patente = " & pDTO.id
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar la Patente", ex)
        End Try

    End Sub

    Public Shared Sub Eliminar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bPatente " &
                  " SET fecha_baja =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" &
                  " WHERE id_Patente = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja la Patente", ex)
        End Try
    End Sub

    Public Shared Sub Rehabilitar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bPatente " &
              " SET fecha_baja =  null " &
              " WHERE id_Patente = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al rehabilitar la Patente", ex)
        End Try
    End Sub

    Public Shared Function Obtener(ByVal pId As Integer) As DTO.PatenteDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_Patente, descripcion_corta, descripcion_larga,  fecha_baja, id_usuario_alta, dvh, fecha_modif  FROM bPatente WHERE id_Patente = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.PatenteDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Patente")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Patente sin Id especificado")
            Return Nothing
        End If

    End Function

    Public Shared Function ListarPatentesPorFamilia(ByVal pId As Integer) As List(Of DTO.PatenteDTO)
        Dim mCol As New List(Of DTO.PatenteDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_Patente,id_familia,id_usuario_alta,dvh  FROM dbo.rFamiliaPatente WHERE id_familia = " & pId)

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.PatenteDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function Listar() As List(Of DTO.PatenteDTO)
        Dim mCol As New List(Of DTO.PatenteDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_Patente,descripcion_corta,descripcion_larga,fecha_baja,id_usuario_alta,dvh,fecha_modif FROM dbo.bPatente")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.PatenteDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function ObtenerProximoId() As Integer
        If ProximoId = 0 Then
            ProximoId = Datos.ProveedorDeDatos.DB.ObtenerId("bPatente")
        End If
        ProximoId += 1
        Return ProximoId
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.PatenteDTO, ByVal pDr As DataRow)
        ' id_Patente,descripcion_corta,descripcion_larga,habilitado,fecha_baja,id_usuario,dvh,fecha_modif
        pDTO.id = pDr("id_Patente")
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

End Class

