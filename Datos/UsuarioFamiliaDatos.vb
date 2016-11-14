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
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_familia,id_usuario_alta,dvh FROM dbo.rUsuarioFamilia")

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

    Public Shared Function Existe(ByVal pId_usuario As Integer, ByVal pId_Familia As Integer) As Boolean

        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_familia,id_usuario_alta,dvh FROM dbo.rUsuariofamilia where id_usuario = " & pId_usuario & " and id_familia = " & pId_Familia)

        Dim rta As Boolean = False

        For Each mDr As DataRow In mDs.Tables(0).Rows
            rta = True
        Next

        Return rta

    End Function

    Public Shared Function EsFamiliaEsencial(ByVal pId_usuario As Integer, ByVal pId_Patente As Integer) As Boolean

        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("select fp.id_patente ,u.id_usuario, fp.m_negada,fp.id_usuario_alta,fp.dvh from busuario as u , rUsuarioFamilia as uf, rFamiliaPatente as fp  where u.id_usuario = uf.id_usuario and uf.id_familia = fp.id_familia and fp.m_negada = 'N' and u.id_usuario   != " & pId_usuario & " and fp.id_patente = " & pId_Patente)

        Dim rta As Boolean = True

        For Each mDr As DataRow In mDs.Tables(0).Rows
            rta = False
        Next

        Return rta

    End Function

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.UsuarioFamiliaDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE rUsuariofamilia " &
                   "SET dvh = " & pDTO.Dvh &
                     " where id_Usuario = " & pDTO.Id_Usuario &
                      "and id_familia = " & pDTO.Id_Familia
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar el usuario familia.", ex)
        End Try

    End Sub

    Public Shared Function Obtener(ByVal pId_Usuario As Integer, ByVal pId_familia As Integer) As DTO.UsuarioFamiliaDTO
        If pId_Usuario > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_familia,id_usuario_alta, dvh FROM dbo.rUsuarioFamilia WHERE id_usuario = " & pId_Usuario & " and id_familia = " & pId_familia)
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
End Class


