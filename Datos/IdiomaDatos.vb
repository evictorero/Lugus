Imports DTO.IdiomaDTO
Imports Datos.ProveedorDeDatos.DB

Public Class IdiomaDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.IdiomaDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.bIdioma (id_idioma, descripcion)" &
        " VALUES " &
        "(" & pDTO.id & ", '" & pDTO.descripcion & "')"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar el idioma", ex)
        End Try
    End Sub

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.IdiomaDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE bIdioma " & _
                  " SET descripcion = '" & pDTO.descripcion & "'," & _
                  " WHERE id_idioma = " & pDTO.id
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar el idioma", ex)
        End Try

    End Sub

    Public Shared Sub Eliminar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bIdioma " & _
                  " SET fecha_baja =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" & _
                  " WHERE id_idioma = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja el idioma", ex)
        End Try
    End Sub

    Public Shared Sub Rehabilitar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bIdioma " &
                  " SET fecha_baja =  null " &
                  " WHERE id_idioma = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al rehabilitar el idioma", ex)
        End Try
    End Sub

    Public Shared Function Obtener(ByVal pId As Integer) As DTO.IdiomaDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_idioma, descripcion, fecha_baja FROM bIdioma WHERE id_idioma = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.IdiomaDTO
                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else
                Throw New ApplicationException("Fallo al cargar el idioma")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar un idioma sin Id especificado")
            Return Nothing
        End If

    End Function

    Public Shared Function Listar() As List(Of DTO.IdiomaDTO)
        Dim mCol As New List(Of DTO.IdiomaDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_idioma,descripcion,fecha_baja FROM dbo.bIdioma")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.IdiomaDTO
            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function ObtenerProximoId() As Integer
        If ProximoId = 0 Then
            ProximoId = Datos.ProveedorDeDatos.DB.ObtenerId("bIdioma")
        End If
        ProximoId += 1
        Return ProximoId
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.IdiomaDTO, ByVal pDr As DataRow)
        pDTO.id = pDr("id_idioma")
        pDTO.descripcion = pDr("descripcion")
        If Not IsDBNull(pDr("fecha_baja")) Then
            pDTO.fechaBaja = pDr("fecha_baja")
        End If
    End Sub

End Class
