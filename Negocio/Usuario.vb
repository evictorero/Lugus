Imports Microsoft.VisualBasic
Imports DTO.UsuarioDTO
Imports Datos.ProveedorDeDatos


Namespace Negocio

    Public Class Usuario

#Region "Declaraciones"

        Dim mUombre As String
        Dim mNombre As String
        Dim mApellido As String
        Dim mDNI As Integer
        Dim mFechaNacimiento As Date
        Dim mEmail As String
        Private Shared ProximoId As Integer
        Dim mId As Integer = 0

#End Region

#Region "Constructores"
        Public Sub New(ByVal pId As Integer)
            mId = pId
            Cargar()
        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.UsuarioDTO)
            Me.Cargar(pDTO)
        End Sub
#End Region
#Region "Métodos"

        Public Overridable Sub Cargar()
            If mId > 0 Then
                Dim mDTO As DTO.UsuarioDTO = Datos.UsuarioDatos.Obtener(mId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Usuario sin Id especificado")

            End If
        End Sub

        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mId = pDr("id")
                mNombre = pDr("nombre")
                mApellido = pDr("apellido")
                mDNI = pDr("apellido")
                mFechaNacimiento = pDr("fecha_nacimiento")
                mEmail = pDr("email")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        Public Overridable Sub Cargar(ByVal pId As Integer)
            Try
                mId = pId
                MyClass.Cargar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        Public Sub Cargar(ByVal pDTO As DTO.UsuarioDTO)
            mId = pDTO.Id
            mNombre = pDTO.Nombre
            mApellido = pDTO.Apellido
        End Sub

        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = DB.ObtenerId("busuario")
                If mTempId Is DBNull.Value Then
                    ProximoId = 0
                Else
                    ProximoId = mTempId
                End If
            End If
            ProximoId += 1
            Return ProximoId
        End Function

        Public Overridable Function Listar() As Collections.Generic.List(Of Usuario)
            Dim mCol As New Collections.Generic.List(Of Usuario)
            Dim mColDTO As List(Of DTO.UsuarioDTO) = Datos.UsuarioDatos.Listar()

            For Each mDTO As DTO.UsuarioDTO In mColDTO
                mCol.Add(New Negocio.Usuario(mDTO))
            Next

            Return mCol
        End Function
#End Region

    End Class


End Namespace