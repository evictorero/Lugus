Imports Datos.ProveedorDeDatos.DB

Namespace Negocio

    Public Class Idioma

#Region "Declaraciones"
        Dim mDescripcion As String
        Dim mFechaBaja As Nullable(Of DateTime)

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
        Public Sub New(ByVal pDTO As DTO.IdiomaDTO)
            Me.Cargar(pDTO)
        End Sub
#End Region

#Region "Propiedades"
        Public Overridable ReadOnly Property id() As Integer
            Get
                Return mId
            End Get
        End Property

        Public Property descripcion() As String
            Get
                Return mDescripcion
            End Get
            Set(ByVal value As String)
                mDescripcion = value
            End Set
        End Property

        Public Property fechaBaja() As Nullable(Of DateTime)
            Get
                Return mFechaBaja
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                mFechaBaja = value
            End Set
        End Property

#End Region

#Region "Métodos"

        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.IdiomaDTO

            mDTO.descripcion = Me.descripcion
            mDTO.fechaBaja = Me.fechaBaja

            If mId = 0 Then
                mDTO.id = Datos.IdiomaDatos.ObtenerProximoId()
                Datos.IdiomaDatos.GuardarNuevo(mDTO)
            Else
                mDTO.id = Me.id
                Datos.IdiomaDatos.GuardarModificacion(mDTO)
            End If

        End Sub
        Public Overridable Sub Cargar()
            If mId > 0 Then
                Dim mDTO As DTO.IdiomaDTO = Datos.IdiomaDatos.Obtener(mId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Idioma sin Id especificado")

            End If
        End Sub
        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mDescripcion = pDr("descripcion")
                mFechaBaja = pDr("fecha_baja")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        Public Overridable Sub Cargar(ByVal pId As Integer)
            If mId > 0 Then
                Dim mDTO As DTO.IdiomaDTO = Datos.IdiomaDatos.Obtener(pId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Idioma sin Id especificado")
            End If
        End Sub
        Public Sub Cargar(ByVal pDTO As DTO.IdiomaDTO)
            mId = pDTO.id
            mDescripcion = pDTO.descripcion
            mFechaBaja = pDTO.fechaBaja
        End Sub
        Public Overridable Sub Eliminar()
            If mId > 0 Then
                Try
                    Datos.IdiomaDatos.Eliminar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar el idioma especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar una bebida sin Id especifico.")
            End If
        End Sub
        Public Overridable Sub Rehabilitar()
            If mId > 0 Then
                Try
                    Datos.IdiomaDatos.Rehabilitar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al activar el idioma especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó activar un idioma sin Id especifico.")
            End If
        End Sub
        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = Datos.IdiomaDatos.ObtenerProximoId()
            End If
            ProximoId += 1
            Return ProximoId
        End Function
        Public Sub ValidarFormato(pid_idioma As Integer)
            Try
                If (Me.descripcion = "") Then
                    Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar la descripción corta."))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Throw
            End Try
        End Sub
        Public Overridable Function Listar() As Collections.Generic.List(Of Idioma)
            Dim mCol As New Collections.Generic.List(Of Idioma)
            Dim mColDTO As List(Of DTO.IdiomaDTO) = Datos.IdiomaDatos.Listar()

            For Each mDTO As DTO.IdiomaDTO In mColDTO
                mCol.Add(New Negocio.Idioma(mDTO))
            Next

            Return mCol
        End Function
#End Region


    End Class
End Namespace
