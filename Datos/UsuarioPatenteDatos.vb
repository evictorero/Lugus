Imports DTO.UsuarioPatenteDTO
Imports Datos.ProveedorDeDatos.DB

Public Class UsuarioPatenteDatos
    Private Shared ProximoId As Integer
    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.UsuarioPatenteDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.rUsuarioPatente  (id_usuario,id_patente,id_usuario_alta,m_negada,dvh) VALUES " &
        "(" & pDTO.Id_Usuario & ", " & pDTO.Id_Patente & " , " & pDTO.Id_Usuario_alta & " , '" & pDTO.M_negada & "' , " & pDTO.Dvh & ")"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la relacion Usuario Patente", ex)
        End Try
    End Sub

    Public Shared Sub Eliminar(ByVal pid_usuario As Integer, ByVal pId_Patente As Integer)
        Dim mStrCom As String

        mStrCom = "DELETE FROM dbo.rUsuarioPatente" &
                   " WHERE id_usuario =  " & pid_usuario & " and id_Patente = " & pId_Patente
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja la Usuario Patente", ex)
        End Try
    End Sub

    Public Shared Function Obtener(ByVal pId As Integer) As DTO.UsuarioPatenteDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_patente,id_usuario_alta,m_negada, dvh FROM dbo.rUsuarioPatente WHERE id_patente = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.UsuarioPatenteDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Usuario Patente")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Usuario Patente sin Id especificado")
            Return Nothing
        End If

    End Function

    Public Shared Function Listar(ByVal pid_usuario As Integer) As List(Of DTO.UsuarioPatenteDTO)
        Dim mCol As New List(Of DTO.UsuarioPatenteDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_patente,id_usuario_alta,m_negada,dvh FROM dbo.rUsuarioPatente where id_usuario = " & pid_usuario)

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.UsuarioPatenteDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function Listar() As List(Of DTO.UsuarioPatenteDTO)
        Dim mCol As New List(Of DTO.UsuarioPatenteDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_Usuario,id_patente,m_negada,id_usuario_alta,dvh FROM dbo.rUsuarioPatente")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.UsuarioPatenteDTO

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

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.UsuarioPatenteDTO, ByVal pDr As DataRow)
        pDTO.Id_Usuario = pDr("id_usuario")
        pDTO.Id_Patente = pDr("id_patente")
        pDTO.Id_Usuario_alta = pDr("Id_Usuario_alta")
        pDTO.M_negada = pDr("m_negada")
        pDTO.Dvh = pDr("dvh")
    End Sub

    Public Shared Function ListarPatentesDeFamiliaPorUsuario(ByVal pId As Integer) As List(Of DTO.UsuarioPatenteDTO)

        Dim mCol As New List(Of DTO.UsuarioPatenteDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("select fp.id_patente ,u.id_usuario, fp.m_negada,fp.id_usuario_alta,fp.dvh from busuario as u , rUsuarioFamilia as uf, rFamiliaPatente as fp  where u.id_usuario = uf.id_usuario and uf.id_familia = fp.id_familia and u.id_usuario =" & pId)

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.UsuarioPatenteDTO
            CargarDTO(mDTO, mDr)
            mCol.Add(mDTO)
        Next
        Return mCol
    End Function

    Public Shared Function ListarPatentesDeFamiliaPorUsuario(ByVal pId As Integer, ByVal pId_Familia As Integer) As List(Of DTO.UsuarioPatenteDTO)

        Dim mCol As New List(Of DTO.UsuarioPatenteDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("select fp.id_patente ,u.id_usuario, fp.m_negada,fp.id_usuario_alta,fp.dvh from busuario as u , rUsuarioFamilia as uf, rFamiliaPatente as fp  where u.id_usuario = uf.id_usuario and uf.id_familia = fp.id_familia and u.id_usuario =" & pId & " and uf.id_familia = " & pId_Familia)

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.UsuarioPatenteDTO
            CargarDTO(mDTO, mDr)
            mCol.Add(mDTO)
        Next
        Return mCol
    End Function

    Public Shared Function Existe(ByVal pId_usuario As Integer, ByVal pId_Patente As Integer) As Boolean

        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_patente,id_usuario_alta,m_negada,dvh FROM dbo.rUsuarioPatente where id_usuario = " & pId_usuario & " and id_patente = " & pId_Patente)

        Dim rta As Boolean = False

        For Each mDr As DataRow In mDs.Tables(0).Rows
            rta = True
        Next

        Return rta

    End Function

    Public Shared Function EsPatenteEsencial(ByVal pId_usuario As Integer, ByVal pId_Patente As Integer) As Boolean

        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_patente,id_usuario_alta,m_negada,dvh FROM dbo.rUsuarioPatente where m_negada = 'N' and id_usuario != " & pId_usuario & " and id_patente = " & pId_Patente)

        Dim rta As Boolean = True

        For Each mDr As DataRow In mDs.Tables(0).Rows
            rta = False
        Next

        Return rta

    End Function

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.UsuarioPatenteDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE rUsuarioPatente " &
                   "SET m_negada = '" & pDTO.M_negada & "'," &
                      "dvh = " & pDTO.Dvh &
                     " where id_Usuario = " & pDTO.Id_Usuario &
                      "and id_patente = " & pDTO.Id_Patente
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar el familia patente.", ex)
        End Try

    End Sub

    Public Shared Function Obtener(ByVal pId_Usuario As Integer, ByVal pId_patente As Integer) As DTO.UsuarioPatenteDTO
        If pId_Usuario > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_usuario,id_patente,id_usuario_alta,m_negada, dvh FROM dbo.rUsuarioPatente WHERE id_usuario = " & pId_Usuario & " and id_patente = " & pId_patente)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.UsuarioPatenteDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Usuario Patente")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Usuario sin Id especificado")
            Return Nothing
        End If
    End Function
End Class

