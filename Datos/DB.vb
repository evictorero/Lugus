Imports System.Data.SqlClient

Namespace ProveedorDeDatos

    Public Class DB
        Shared mCon As SqlConnection

        Public Shared StrConnection As String = "Data Source=.\SQLEXPRESS;Initial Catalog=lugus;Integrated Security=True"

        Public Shared Function ExecuteDataset(ByVal pCommandText As String) As DataSet
            Dim mDs As New DataSet
            Try
                mCon = New SqlConnection(StrConnection)
                Dim mDa As New SqlDataAdapter(pCommandText, mCon)
                mCon.Open()
                mDa.Fill(mDs)
                Return mDs
            Catch ex As SqlException
                Dim mStr As String = ""
                For Each mErr As SqlError In ex.Errors
                    mStr &= mErr.Message & ControlChars.CrLf
                Next
                MsgBox("Ocurrió un error en el acceso a la base de datos" & ControlChars.CrLf & _
                "MENSAJE: " & ex.Message & ControlChars.CrLf & _
                "ERRORES DEL SERVIDOR SQL: " & mStr)
                Return Nothing
            Catch ex As Exception
                MsgBox(ex.Message & "  METODO: ExecuteDataset, CLASE: DB")
                Return Nothing
            Finally
                mCon.Close()
                mCon.Dispose()
            End Try

        End Function

        Public Shared Function ExecuteReader(ByVal pCommandText As String) As SqlDataReader
            Dim mDr As SqlDataReader
            Try
                mCon = New SqlConnection(StrConnection)
                Dim mCom As New SqlCommand(pCommandText, mCon)
                mCon.Open()
                mDr = mCom.ExecuteReader(CommandBehavior.CloseConnection)
                Return mDr

            Catch ex As SqlException
                Dim mStr As String = ""
                For Each mErr As SqlError In ex.Errors
                    mStr &= mErr.Message & ControlChars.CrLf
                Next
                MsgBox("Ocurrió un error en el acceso a la base de datos" & ControlChars.CrLf & _
                "MENSAJE: " & ex.Message & ControlChars.CrLf & _
                "ERRORES DEL SERVIDOR SQL: " & mStr)
                Return Nothing
            Catch ex As Exception
                MsgBox(ex.Message & "  METODO: ExecuteReader, CLASE: DB")
                'mDr.Close()
                mCon.Close()
                mCon.Dispose()
                Return Nothing
            Finally
                'mDr.Close()
                mCon.Close()
                mCon.Dispose()
            End Try
        End Function

        Public Shared Function ExecuteNonQuery(ByVal pCommandText As String) As Integer
            Try
                mCon = New SqlConnection(StrConnection)
                Dim mCom As New SqlCommand(pCommandText, mCon)
                mCon.Open()
                Return mCom.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message & "  METODO: ExecuteNonQuery, CLASE: DB")
                Return Nothing
            Finally
                mCon.Close()
                mCon.Dispose()
            End Try
        End Function

        Public Shared Function ObtenerId(ByVal pTabla As String) As Integer
            Try
                mCon = New SqlConnection(StrConnection)
                Dim mCom As New SqlCommand("SELECT ISNULL(MAX(Id),0) FROM " & pTabla, mCon)
                mCon.Open()
                Return mCom.ExecuteScalar
            Catch ex As Exception
                MsgBox(ex.Message & "  METODO: ObtenerId, CLASE: DB")
                Return Nothing
            Finally
                mCon.Close()
                mCon.Dispose()
            End Try
        End Function

    End Class
End Namespace
