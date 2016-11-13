
Imports DTO.FamiliaPatenteDTO
Imports Datos.ProveedorDeDatos.DB

Public Class FamiliaPatenteDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.FamiliaPatenteDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.rFamiliaPatente  (id_familia,id_patente,id_usuario_alta,m_negada,dvh) VALUES " &
        "(" & pDTO.Id_familia & ", " & pDTO.Id_Patente & " , " & pDTO.Id_Usuario_alta & " , '" & pDTO.M_negada & "' , " & pDTO.Dvh & ")"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la relacion Familia Patente", ex)
        End Try
    End Sub

    Public Shared Sub Eliminar(ByVal pId_Familia As Integer, ByVal pId_Patente As Integer)
        Dim mStrCom As String

        mStrCom = "DELETE FROM dbo.rFamiliaPatente" &
                   " WHERE id_familia =  " & pId_Familia & " and id_Patente = " & pId_Patente
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja la Familia Patente", ex)
        End Try
    End Sub


    Public Shared Function Obtener(ByVal pId As Integer) As DTO.FamiliaPatenteDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_familia,id_patente,id_usuario_alta,m_negada, dvh FROM dbo.rFamiliaPatente WHERE id_patente = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.FamiliaPatenteDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar la Familia Patente")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar una Familia Patente sin Id especificado")
            Return Nothing
        End If

    End Function

    Public Shared Function Listar(ByVal pId_familia As Integer) As List(Of DTO.FamiliaPatenteDTO)
        Dim mCol As New List(Of DTO.FamiliaPatenteDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_familia,id_patente,id_usuario_alta,m_negada,dvh FROM dbo.rFamiliaPatente where id_familia = " & pId_familia)

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.FamiliaPatenteDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function Existe(ByVal pId_familia As Integer, ByVal pId_Patente As Integer) As Boolean

        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_familia,id_patente,id_usuario_alta,m_negada,dvh FROM dbo.rFamiliaPatente where id_familia = " & pId_familia & " and id_patente = " & pId_Patente)

        Dim rta As Boolean = False

        For Each mDr As DataRow In mDs.Tables(0).Rows
            rta = True
        Next

        Return rta

    End Function

    Public Shared Function EsPatenteEsencial(ByVal pId_familia As Integer, ByVal pId_Patente As Integer) As Boolean

        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("select fp.id_patente , u.id_usuario, fp.m_negada, fp.id_usuario_alta, fp.dvh From busuario As u , rUsuarioFamilia As uf, rFamiliaPatente As fp Where u.id_usuario = uf.id_usuario And uf.id_familia = fp.id_familia And fp.m_negada = 'N'  and fp.id_patente = " & pId_Patente & " And fp.id_familia = " & pId_familia)
        Dim rta As Boolean = True

        If mDs.Tables.Count > 1 Then
            rta = False
        End If

        Return rta

    End Function

    Public Shared Function Listar() As List(Of DTO.FamiliaPatenteDTO)
        Dim mCol As New List(Of DTO.FamiliaPatenteDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("Select id_bebida,descripcion_corta,descripcion_larga,habilitado,fecha_baja,id_usuario,dvh,fecha_modif FROM dbo.bBebida")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.FamiliaPatenteDTO

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

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.FamiliaPatenteDTO, ByVal pDr As DataRow)
        pDTO.Id_familia = pDr("id_familia")
        pDTO.Id_Patente = pDr("id_patente")
        pDTO.Id_Usuario_alta = pDr("Id_Usuario_alta")
        pDTO.M_negada = pDr("m_negada")
        pDTO.Dvh = pDr("dvh")
    End Sub

End Class

