Imports DTO.BitacoraDTO
Imports Datos.ProveedorDeDatos.DB

Public Class BitacoraDatos
    Private Shared ProximoId As Integer

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.BitacoraDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO dbo.bBitacora (id_bitacora,id_usuario,descripcion_larga,fecha,dvh,criticidad)" &
        " VALUES " &
        "(" & pDTO.id & "," & pDTO.idUsuario & ",'" & pDTO.descripcionLarga & "','" & Format(pDTO.fecha, "yyyy/MM/dd HH:mm:ss") & "'," & pDTO.dvh & ",'" & pDTO.criticidad & "')"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar la bitacora", ex)
        End Try
    End Sub

    Public Shared Function Listar() As List(Of DTO.BitacoraDTO)
        Dim mCol As New List(Of DTO.BitacoraDTO)
        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset("SELECT id_bitacora,id_usuario,descripcion_larga,fecha,dvh,criticidad FROM dbo.bbitacora")

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.BitacoraDTO
            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function ListarConFiltro(ByVal pUsuario As Integer,
                                           ByVal pFechaDesde As Date,
                                           ByVal pFechaHasta As Date,
                                           ByVal pCriticidad As String) As List(Of DTO.BitacoraDTO)
        Dim mCol As New List(Of DTO.BitacoraDTO)
        Dim mCondicion As String = "WHERE 1=1"

        Dim mStrCom As String
        If pUsuario <> 0 Then
            mCondicion = mCondicion & " AND id_usuario = " & pUsuario
        End If

        If Format(pFechaDesde, "yyyy/MM/dd") <> "0001/01/01" Then
            mCondicion = mCondicion & " AND fecha BETWEEN '" & Format(pFechaDesde, "yyyy/MM/dd") & "' AND '" & Format(pFechaHasta, "yyyy/MM/dd") & "'"
        End If

        If Not IsNothing(pCriticidad) Then
            mCondicion = mCondicion & " AND criticidad = '" & pCriticidad & "'"
        End If

        mStrCom = "SELECT id_bitacora,id_usuario,descripcion_larga,fecha,dvh,criticidad " &
                                                                      " FROM dbo.bbitacora " &
                                                                        mCondicion

        Dim mDs As DataSet = Datos.ProveedorDeDatos.DB.ExecuteDataset(mStrCom)

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.BitacoraDTO
            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function

    Public Shared Function ObtenerProximoId() As Integer
        If ProximoId = 0 Then
            ProximoId = Datos.ProveedorDeDatos.DB.ObtenerId("bBitacora")
        End If
        ProximoId += 1
        Return ProximoId
    End Function

    Private Shared Sub CargarDTO(ByVal pDTO As DTO.BitacoraDTO, ByVal pDr As DataRow)
        pDTO.id = pDr("id_bitacora")
        pDTO.idUsuario = pDr("id_usuario")
        pDTO.descripcionLarga = pDr("descripcion_larga")
        pDTO.fecha = pDr("fecha")
        pDTO.dvh = pDr("dvh")
        pDTO.criticidad = pDr("criticidad")
    End Sub

End Class
