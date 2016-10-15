Imports Datos.ProveedorDeDatos
Imports System.Data.SqlClient
Imports DTO.TraductorDTO

Public Class TraductorDatos
    Private Shared Sub CargarDTO(ByVal pDTO As DTO.TraductorDTO, ByVal pDr As DataRow)
        pDTO.id = pDr("id_idioma")
        pDTO.mensaje = pDr("mensaje")
        pDTO.traduccion = pDr("traduccion")
    End Sub

    Public Shared Function ObtenerTraduccion(ByVal pIdIdioma As String,
                                             ByVal pMensaje As String) As String
        Dim l_return As String
        l_return = "{{" + pMensaje + "}}"

        If Not IsNothing(pIdIdioma) Then
            Dim mDs As DataSet
            Try
                If Not IsNothing(pMensaje) And Not pMensaje.Equals("") Then
                    mDs = DB.ExecuteDataset("SELECT traduccion FROM dbo.btraductor WHERE id_idioma = '" & pIdIdioma & "' AND mensaje = '" & pMensaje & "'")
                    If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                        l_return = mDs.Tables(0).Rows(0)("traduccion")
                    End If
                End If
            Catch ex As Exception
                Throw New ApplicationException("Fallo al obtener traducción", ex)
            End Try
        Else
            Throw New ApplicationException("Se intentó obtener traduccion sin id de idioma")
        End If
        Return l_return
    End Function

End Class
