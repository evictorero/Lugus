
Imports DTO.DigitoVerificadorDTO
Imports Datos.ProveedorDeDatos.DB

Public Class DigitoVerificadorDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.DigitoVerificadorDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.bDigitoVerificadorVertical (id_dvv, tabla, valor)" &
            " VALUES " &
            "(" & pDTO.id & ", '" & pDTO.tabla & "' , " & pDTO.valor & ")"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la Digito Verificador Vertical", ex)
        End Try
    End Sub

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.DigitoVerificadorDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE bDigitoVerificadorVertical " &
                      " SET tabla = '" & pDTO.tabla & "'," &
                      " valor =  " & pDTO.valor & "," &
                      " WHERE id_dvv = " & pDTO.id
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar el Digito Verificador Vertical", ex)
        End Try

    End Sub

    Public Shared Sub Eliminar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bDigitoVerificadorVertical " &
                      " SET fecha_baja =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" &
                      " WHERE id_dvv = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja el Digito Verificador Vertical", ex)
        End Try
    End Sub

    Public Shared Sub Rehabilitar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bDigitoVerificadorVertical " &
                      " SET fecha_baja =  null " &
                      " WHERE id_dvv = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al rehabilitar el Digito Verificador Vertical", ex)
        End Try
    End Sub

    Public Shared Function Obtener(ByVal pId As Integer) As DTO.DigitoVerificadorDTO
        If pId > 0 Then
            Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_dvv, tabla,  valor FROM bDigitoVerificadorVertical WHERE id_dvv = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.DigitoVerificadorDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar el Digito Verificador Vertical")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar el Digito Verificador Vertical sin Id especificado")
            Return Nothing
        End If

    End Function

    Public Shared Function Listar() As List(Of DTO.DigitoVerificadorDTO)
        Dim mCol As New List(Of DTO.DigitoVerificadorDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_dvv,tabla,valor FROM dbo.bDigitoVerificadorVertical")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.DigitoVerificadorDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function ObtenerProximoId() As Integer
        If ProximoId = 0 Then
            ProximoId = Datos.ProveedorDeDatos.DB.ObtenerId("bDigitoVerificadorVertical")
        End If
        ProximoId += 1
        Return ProximoId
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.DigitoVerificadorDTO, ByVal pDr As DataRow)
        ' id_dvv,tabla,descripcion_larga,habilitado,fecha_baja,valor,dvh,fecha_modif
        pDTO.id = pDr("id_dvv")
        pDTO.tabla = pDr("tabla")
        pDTO.valor = pDr("valor")

    End Sub

End Class
