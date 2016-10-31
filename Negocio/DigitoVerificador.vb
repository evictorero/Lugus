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
        Public Sub New(ByVal pTabla As String)
            Me.Cargar(pTabla)
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
        Public Overridable Sub Cargar(ByVal pTabla As String)
            If pTabla <> "" Then
                Dim mCol As New Collections.Generic.List(Of DigitoVerificador)
                Dim mColDTO As List(Of DTO.DigitoVerificadorDTO) = Datos.DigitoVerificadorDatos.Listar(pTabla)

                For Each mDTO As DTO.DigitoVerificadorDTO In mColDTO
                    MyClass.Cargar(mDTO)
                Next
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
                Dim i As Integer = 0
                Dim result As Integer = 0
                Dim DVH As Integer = 0
                Dim multiplo As Integer = 1

                For i = 0 To pTexto.Length - 1
                    If multiplo = 1 Then
                        result = Convert.ToInt16(pTexto(i))
                        DVH = DVH + (result * multiplo)
                        multiplo = 3
                    Else
                        result = Convert.ToInt16(pTexto(i))
                        DVH = DVH + (result * multiplo)
                        multiplo = 1
                    End If
                Next
                Return DVH
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function CalcularDVV(ByVal pTexto As String) As Integer
            Try
                Dim mDVV As Integer
                mDVV = Datos.DigitoVerificadorDatos.GenerarDVV(pTexto)
                MsgBox(mDVV)
                Return mDVV
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
