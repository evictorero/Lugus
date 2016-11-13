﻿Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO


Namespace ProveedorDeDatos
    Public Class DB

        Shared mCon As SqlConnection
        Public Shared StrConnection As String
        'Public Shared StrConnection As String = ConfigurationManager.ConnectionStrings("InterfazConnString").ConnectionString
        Public Shared servidor As String
        Public Shared instancia As String

        Public Shared Sub obtenercadenaconexion()

            Dim rutaFicheroINI As String
            rutaFicheroINI = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "configuracion.txt")

            Dim leer As StreamReader
            'Leer el archivo por la ruta
            leer = New StreamReader(rutaFicheroINI)

            If File.Exists(rutaFicheroINI) = True Then
                'Variable de control para leer la primera linea
                Dim c As Integer = 0
                'Leer linea a linea hasta el final
                While c <= 1 And Not leer.EndOfStream
                    If c = 0 Then
                        servidor = leer.ReadLine
                    End If

                    If c = 1 Then
                        instancia = leer.ReadLine
                    End If
                    c += 1
                End While
            End If

            StrConnection = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=lugus;Integrated Security=True"

        End Sub

        Public Shared Function ExecuteDataset(ByVal pCommandText As String) As DataSet
            Dim mDs As New DataSet
            Try
                obtenercadenaconexion()
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
                MsgBox("Ocurrió un error en el acceso a la base de datos" & ControlChars.CrLf &
                "MENSAJE: " & ex.Message & ControlChars.CrLf &
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
            obtenercadenaconexion()

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
                MsgBox("Ocurrió un error en el acceso a la base de datos" & ControlChars.CrLf &
                "MENSAJE: " & ex.Message & ControlChars.CrLf &
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
            obtenercadenaconexion()
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

        Public Shared Function ExecuteScalar(ByVal pCommandText As String) As Integer
            obtenercadenaconexion()
            Try
                mCon = New SqlConnection(StrConnection)
                Dim mCom As New SqlCommand(pCommandText, mCon)
                mCon.Open()
                Return mCom.ExecuteScalar
            Catch ex As Exception
                '       MsgBox(ex.Message & "  METODO: ExecuteScalar, CLASE: DB")
                Return 0
            Finally
                mCon.Close()
                mCon.Dispose()
            End Try
        End Function

        Public Shared Function Exec_Function(ByVal nomfun As String, ByVal pDTO As DTO.UsuarioDTO) As Object
            obtenercadenaconexion()
            Dim cn As New SqlConnection(StrConnection)
            Dim cmd As New SqlCommand("SELECT " & nomfun, cn)   'Para ejecutar "SELECT <nombrefuncion>

            cmd.CommandType = CommandType.Text

            cn.Open()

            Dim param As System.Data.SqlClient.SqlParameter
            param = New System.Data.SqlClient.SqlParameter()
            param.ParameterName = “@pUsuario”
            param.SqlDbType = SqlDbType.VarChar
            param.Size = 20
            param.Value = pDTO.usuario

            cmd.Parameters.Add(param)
            Dim param2 As System.Data.SqlClient.SqlParameter
            param2 = New System.Data.SqlClient.SqlParameter()
            param2.ParameterName = “@pPassword”
            param2.SqlDbType = SqlDbType.VarChar
            param2.Size = 20
            param2.Value = pDTO.contrasenia

            cmd.Parameters.Add(param2)
            Dim resultado As Integer = cmd.ExecuteScalar()
            cn.Close()
            Return resultado
        End Function

        Public Shared Function ObtenerId(ByVal pTabla As String) As Integer
            obtenercadenaconexion()
            Try
                Dim mId As String
                ' obtengo nombre de id según tabla
                Select Case pTabla
                    Case "bBebida"
                        mId = "id_bebida"
                    Case "bPlato"
                        mId = "id_plato"
                    Case "rPedidoBebida"
                        mId = "id_pedidobebida"
                    Case "rPedidoPlato"
                        mId = "id_pedidoplato"
                    Case "bUsuario"
                        mId = "id_usuario"
                    Case "bFamilia"
                        mId = "id_familia"
                    Case "bBackup"
                        mId = "id_backup"
                    Case "bBitacora"
                        mId = "id_bitacora"
                    Case "bDigitoVerificadorVertical"
                        mId = "id_dvv"
                    Case "bPedido"
                        mId = "id_pedido"
                    Case Else
                        mId = "id"

                End Select

                mCon = New SqlConnection(StrConnection)
                Dim mCom As New SqlCommand("SELECT ISNULL(MAX(" & mId & "),0) FROM " & pTabla, mCon)
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
