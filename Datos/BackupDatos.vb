Imports Datos.ProveedorDeDatos.DB

Public Class BackupDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.BackupDTO)
        Dim mStrCom As String


        mStrCom = "backup database lugus to disk='" & pDTO.ruta & "'"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al generar Backup", ex)
        End Try

        mStrCom = "INSERT INTO dbo.bBackup (id_backup, descripcion, ruta, fecha, id_usuario_alta, cant_volumen)" &
        " VALUES " &
        "(" & pDTO.id & ", '" & pDTO.descripcion & "' , '" & pDTO.ruta & "' , '" & DateTime.Now.ToString("yyyyMMdd HH:mm:ss") & "', " & pDTO.idUsuarioAlta & ", " & pDTO.cantVolumen & ")"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar el backup", ex)
        End Try
    End Sub

    Public Shared Sub Restaurar(ByVal pRuta As String)
        Dim mStrCom As String

        mStrCom = "use master restore database lugus from disk = '" & pRuta & "'"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al restaurar el Backup", ex)
        End Try

    End Sub

    Public Shared Function Listar() As List(Of DTO.BackupDTO)
        Dim mCol As New List(Of DTO.BackupDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_backup,descripcion,ruta,fecha,id_usuario_alta,cant_volumen FROM dbo.bBackup")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.BackupDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function ObtenerProximoId() As Integer
        If ProximoId = 0 Then
            ProximoId = Datos.ProveedorDeDatos.DB.ObtenerId("bBackup")
        End If
        ProximoId += 1
        Return ProximoId
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.BackupDTO, ByVal pDr As DataRow)
        pDTO.id = pDr("id_backup")
        pDTO.descripcion = pDr("descripcion")
        pDTO.ruta = pDr("ruta")
        pDTO.fecha = pDr("fecha")
        pDTO.idUsuarioAlta = pDr("id_usuario_alta")
        pDTO.cantVolumen = pDr("cant_volumen")
    End Sub

    Public Shared Function Obtener(ByVal pId As Integer) As DTO.BackupDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_backup,descripcion,ruta,fecha,id_usuario_alta,cant_volumen FROM dbo.bBackup WHERE id_backup = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.BackupDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else
                Throw New ApplicationException("Fallo al cargar el backup")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar un backup sin Id especificado")
            Return Nothing
        End If

    End Function
End Class
