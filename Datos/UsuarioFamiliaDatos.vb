Imports DTO.UsuarioFamiliaDTO
Imports Datos.ProveedorDeDatos.DB

Public Class UsuarioFamiliaDatos
    Private Shared ProximoId As Integer
    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.UsuarioFamiliaDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.rUsuarioFamilia  (id_usuario,id_familia,id_usuario_alta,dvh) VALUES " &
        "(" & pDTO.Id_Usuario & ", " & pDTO.Id_Familia & " , " & pDTO.Id_Usuario_alta & " , " & pDTO.Dvh & ")"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la relacion Usuario Familia", ex)
        End Try
    End Sub
    Public Shared Sub Eliminar(ByVal pid_usuario As Integer, ByVal pid_familia As Integer)
        Dim mStrCom As String

        mStrCom = "DELETE FROM dbo.rUsuarioFamilia" &
                   " WHERE id_usuario =  " & pid_usuario & " and id_familia = " & pid_familia
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja la Usuario Familia", ex)
        End Try
    End Sub
    Public Shared Function Obtener(ByVal pId As Integer) As DTO.UsuarioFamiliaDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_familia,id_usuario_alta,m_negada, dvh FROM dbo.rUsuarioFamilia WHERE id_familia = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.UsuarioFamiliaDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Usuario Familia")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Usuario Familia sin Id especificado")
            Return Nothing
        End If

    End Function

    Public Shared Function Listar(ByVal pid_usuario As Integer) As List(Of DTO.UsuarioFamiliaDTO)
        Dim mCol As New List(Of DTO.UsuarioFamiliaDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_familia,id_usuario_alta,dvh FROM dbo.rUsuarioFamilia where id_usuario = " & pid_usuario)

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.UsuarioFamiliaDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function
    Public Shared Function Listar() As List(Of DTO.UsuarioFamiliaDTO)
        Dim mCol As New List(Of DTO.UsuarioFamiliaDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_bebida,descripcion_corta,descripcion_larga,habilitado,fecha_baja,id_usuario,dvh,fecha_modif FROM dbo.bBebida")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.UsuarioFamiliaDTO

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

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.UsuarioFamiliaDTO, ByVal pDr As DataRow)
        pDTO.Id_Usuario = pDr("id_usuario")
        pDTO.Id_Familia = pDr("id_familia")
        pDTO.Id_Usuario_alta = pDr("Id_Usuario_alta")
        pDTO.Dvh = pDr("dvh")
    End Sub

End Class


