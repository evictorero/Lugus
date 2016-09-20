Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Namespace Negocio


    Public Class Encriptador

        'Funcion de encriptado
        Public Shared Function encriptarDatos(ByVal tipo As Integer, ByVal textoAEncriptar As String) As String
            Try
                'MD5
                If tipo = 1 Then
                    Dim contraseniaEncriptada As String
                    contraseniaEncriptada = ""
                    Dim md5 As New MD5CryptoServiceProvider
                    Dim byteValue() As Byte
                    Dim byteHash() As Byte
                    Dim indice As Integer

                    byteValue = System.Text.Encoding.UTF8.GetBytes(textoAEncriptar)

                    byteHash = md5.ComputeHash(byteValue)
                    md5.Clear()

                    For indice = 0 To byteHash.Length - 1
                        contraseniaEncriptada &= byteHash(indice).ToString("x").PadLeft(2, "0")
                    Next

                    Return contraseniaEncriptada
                ElseIf tipo = 2 Then
                    'DES
                    Dim buffer() As Byte = Encoding.UTF8.GetBytes(textoAEncriptar)
                    Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
                    des.Key = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5")
                    des.IV = ASCIIEncoding.ASCII.GetBytes("password")

                    Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
                End If

                ' si el tipo es inválido retorno el mismo texto
                Return textoAEncriptar

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Shared Function desencriptarDatos(ByVal tipo As Integer, ByVal textoEncriptado As String) As String
            Try
                'DES
                If tipo = 2 Then
                    Dim buffer() As Byte = Convert.FromBase64String(textoEncriptado)
                    Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
                    des.Key = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5")
                    des.IV = ASCIIEncoding.ASCII.GetBytes("password")
                    Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
                End If

                ' si el tipo es inválido retorno el mismo texto
                Return textoEncriptado
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace