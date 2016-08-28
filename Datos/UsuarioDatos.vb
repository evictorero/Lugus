Imports Datos.ProveedorDeDatos

Imports DTO.UsuarioDTO

Public Class UsuarioDatos
    Private Shared ProximoId As Integer
    Public Shared Function Obtener(ByVal pId As Integer) As DTO.UsuarioDTO
        If pId > 0 Then
            Dim mDs As DataSet = DB.ExecuteDataset("SELECT id, nombre, apellido FROM dbo.busuario WHERE id_usuario = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.UsuarioDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar el Usuario.")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar el Usuario sin Id especificado")
            Return Nothing
        End If

    End Function
    Private Shared Sub CargarDTO(ByVal pDTO As DTO.UsuarioDTO, ByVal pDr As DataRow)
        pDTO.id = pDr("id_usuario")
        pDTO.usuario = pDr("usuario")
        pDTO.nombre = pDr("nombre")
        pDTO.apellido = pDr("apellido")
        pDTO.email = pDr("email")
        pDTO.dni = pDr("dni")
        ' probando 
        pDTO.fechaNacimiento = pDr("fecha_nacimiento")
    End Sub
    Public Shared Function Listar() As List(Of DTO.UsuarioDTO)

        Dim mCol As New List(Of DTO.UsuarioDTO)
        Dim mDs As DataSet = DB.ExecuteDataset(("SELECT id_usuario, nombre, apellido, email, dni, fecha_nacimiento FROM dbo.busuario "))

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.UsuarioDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function
End Class
