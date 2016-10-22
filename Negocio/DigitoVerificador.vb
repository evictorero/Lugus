Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Namespace Negocio
    Public Class DigitoVerificador

#Region "Declaraciones"
        Dim mTabla As String
        Dim mValor As Integer

        Private Shared ProximoId As Integer
        Dim mId As Integer = 0
#End Region

#Region "Constructores"
        Public Sub New(ByVal pId As Integer)
            mId = pId
            Cargar()
        End Sub
        Public Sub New()

        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.DigitoVerificadorDTO)
            Me.Cargar(pDTO)
        End Sub
#End Region

#Region "Propiedades"

        Public Overridable ReadOnly Property id() As Integer
            Get
                Return mId
            End Get
        End Property

        Public Property tabla() As String
            Get
                Return mTabla
            End Get
            Set(ByVal value As String)
                mTabla = value
            End Set
        End Property

        Public Property valor() As Integer
            Get
                Return mValor
            End Get
            Set(ByVal value As Integer)
                mValor = value
            End Set
        End Property
#End Region

#Region "Métodos"

        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.DigitoVerificadorDTO

            mDTO.tabla = Me.tabla
            mDTO.valor = Me.valor

            If mId = 0 Then
                mDTO.id = Datos.DigitoVerificadorDatos.ObtenerProximoId()
                Datos.DigitoVerificadorDatos.GuardarNuevo(mDTO)
            Else
                mDTO.id = Me.id
                Datos.DigitoVerificadorDatos.GuardarModificacion(mDTO)
            End If

        End Sub
        Public Overridable Sub Cargar()
            If mId > 0 Then
                Dim mDTO As DTO.DigitoVerificadorDTO = Datos.DigitoVerificadorDatos.Obtener(mId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un DigitoVerificador sin Id especificado")

            End If
        End Sub
        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mTabla = pDr("tabla")
                mValor = pDr("valor")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        Public Overridable Sub Cargar(ByVal pId As Integer)
            If mId > 0 Then
                Dim mDTO As DTO.DigitoVerificadorDTO = Datos.DigitoVerificadorDatos.Obtener(pId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un DigitoVerificador sin Id especificado")
            End If
        End Sub
        Public Sub Cargar(ByVal pDTO As DTO.DigitoVerificadorDTO)
            mId = pDTO.id
            mTabla = pDTO.tabla
            mValor = pDTO.valor

        End Sub
        Public Overridable Sub Eliminar()
            If mId > 0 Then
                Try
                    Datos.DigitoVerificadorDatos.Eliminar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar la DigitoVerificador especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar una DigitoVerificador sin Id especifico.")
            End If
        End Sub
        Public Overridable Sub Rehabilitar()
            If mId > 0 Then
                Try
                    Datos.DigitoVerificadorDatos.Rehabilitar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al activar la DigitoVerificador especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó activar una DigitoVerificador sin Id especifico.")
            End If
        End Sub
        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = Datos.DigitoVerificadorDatos.ObtenerProximoId()
            End If
            ProximoId += 1
            Return ProximoId
        End Function

        Public Overridable Function Listar() As Collections.Generic.List(Of DigitoVerificador)
            Dim mCol As New Collections.Generic.List(Of DigitoVerificador)
            Dim mColDTO As List(Of DTO.DigitoVerificadorDTO) = Datos.DigitoVerificadorDatos.Listar()

            For Each mDTO As DTO.DigitoVerificadorDTO In mColDTO
                mCol.Add(New Negocio.DigitoVerificador(mDTO))
            Next

            Return mCol
        End Function




        Public Shared Function CalcularDVH(ByVal pTexto As String) As Integer
            Try
                'pTexto son todos los campos de la tabla 
                Dim buffer() As Byte = Convert.FromBase64String(pTexto)
                Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
                des.Key = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5")
                des.IV = ASCIIEncoding.ASCII.GetBytes("DigitoVerificador")

                Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function CalcularDVV(ByVal pTexto As String) As Integer
            Try
                'pTexto es el nombre de la tabla de la cual se desea generar el DVV 
                Dim buffer() As Byte = Convert.FromBase64String(pTexto)
                Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
                des.Key = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5")
                des.IV = ASCIIEncoding.ASCII.GetBytes("DigitoVerificador")
                Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function VerificarIntegridad() As Boolean
            Try
                'se debe verificar que todos los DVH y DVV sean correctos para poder ingresar al sistema

                Return True

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
    End Class

End Namespace
