Imports Datos.ProveedorDeDatos.DB

Namespace Negocio

    Public Class UsuarioPatente : Implements IColeccionable

#Region "Declaraciones"
        Dim mId_usuario As Integer
        Dim mId_Patente As Integer
        Dim mId_Usuario_alta As Integer
        Dim mM_negada As String
        Dim mDvh As Integer

#End Region

#Region "Constructores"
        Public Sub New()

        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.UsuarioPatenteDTO)
            Me.Cargar(pDTO)
        End Sub
#End Region

#Region "Propiedades"
        Public Property id_patente() As Integer
            Get
                Return mId_Patente
            End Get
            Set(ByVal value As Integer)
                mId_Patente = value
            End Set
        End Property

        Public Property id_usuario() As Integer
            Get
                Return mId_usuario
            End Get
            Set(ByVal value As Integer)
                mId_usuario = value
            End Set
        End Property


        Public Property id_usuario_alta() As Integer
            Get
                Return mId_Usuario_alta
            End Get
            Set(ByVal value As Integer)
                mId_Usuario_alta = value
            End Set
        End Property

        Public Property dvh() As Integer
            Get
                Return mDvh
            End Get
            Set(ByVal value As Integer)
                mDvh = value
            End Set
        End Property

        Public Property m_negada() As String
            Get
                Return mM_negada
            End Get
            Set(ByVal value As String)
                mM_negada = value
            End Set
        End Property

#End Region

#Region "Métodos"

        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.UsuarioPatenteDTO
            Dim Existe As Boolean = False

            mDTO.Id_Usuario = Me.id_usuario
            mDTO.Id_Patente = Me.id_patente
            mDTO.Id_Usuario_alta = Me.id_usuario_alta
            mDTO.Dvh = Me.dvh
            mDTO.M_negada = Me.mM_negada

            Existe = Datos.UsuarioPatenteDatos.Existe(mDTO.Id_Usuario, mDTO.Id_Patente)

            If Not Existe Then
                Datos.UsuarioPatenteDatos.GuardarNuevo(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Usuario Patente ya existente.")
            End If

        End Sub
        Public Overridable Sub Cargar()
            If mId_Patente > 0 Then
                Dim mDTO As DTO.UsuarioPatenteDTO = Datos.UsuarioPatenteDatos.Obtener(mId_Patente)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Usuario Patente  sin Id especificado")

            End If
        End Sub

        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mId_usuario = pDr("id_usuario")
                mId_Patente = pDr("id_patente")
                mId_Usuario_alta = pDr("id_usuario_alta")
                mM_negada = pDr("m_negada")
                mDvh = pDr("dvh")


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Public Overridable Sub Cargar(ByVal pId_patente As Integer)
            If mId_Patente > 0 Then
                Dim mDTO As DTO.UsuarioPatenteDTO = Datos.UsuarioPatenteDatos.Obtener(pId_patente)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Usuario Patente  sin Id especificado")
            End If
        End Sub

        Public Sub Cargar(ByVal pDTO As DTO.UsuarioPatenteDTO)
            mId_usuario = pDTO.Id_Usuario
            mId_Patente = pDTO.Id_Patente
            mId_Usuario_alta = pDTO.Id_Usuario_alta
            mM_negada = pDTO.M_negada
            mDvh = pDTO.Dvh
        End Sub

        Public Overridable Sub Eliminar()
            If mId_Patente > 0 And mId_usuario > 0 Then
                Try

                    Datos.UsuarioPatenteDatos.Eliminar(mId_usuario, mId_Patente)
                Catch ex As Exception

                    Throw New ApplicationException("Error al borrar la Usuario Patente especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar Usuario Patente  sin Id especifico.")
            End If
        End Sub

        Public Overridable Function Listar() As Collections.Generic.List(Of UsuarioPatente)
            Dim mCol As New Collections.Generic.List(Of UsuarioPatente)
            Dim mColDTO As List(Of DTO.UsuarioPatenteDTO) = Datos.UsuarioPatenteDatos.Listar()

            For Each mDTO As DTO.UsuarioPatenteDTO In mColDTO
                mCol.Add(New Negocio.UsuarioPatente(mDTO))
            Next

            Return mCol
        End Function

        Public Overridable Function Listar(ByVal pid_usuario As Integer) As Collections.Generic.List(Of UsuarioPatente)
            Dim mCol As New Collections.Generic.List(Of UsuarioPatente)
            Dim mColDTO As List(Of DTO.UsuarioPatenteDTO) = Datos.UsuarioPatenteDatos.Listar(pid_usuario)

            For Each mDTO As DTO.UsuarioPatenteDTO In mColDTO
                mCol.Add(New Negocio.UsuarioPatente(mDTO))
            Next

            Return mCol
        End Function

        Public Shared Function EsPatenteEsencial(ByVal pId_usuario As Integer, ByVal pId_Patente As Integer) As Boolean

            Dim rta As Boolean = Datos.UsuarioPatenteDatos.EsPatenteEsencial(pId_usuario, pId_Patente)

            Return rta

        End Function
#End Region

#Region "IColeccionable"
        Dim mEstadoColeccion As IColeccionable.EstadosColeccion
        Public Property EstadoColeccion() As IColeccionable.EstadosColeccion Implements IColeccionable.EstadoColeccion
            Get
                Return mEstadoColeccion
            End Get
            Set(ByVal value As IColeccionable.EstadosColeccion)
                mEstadoColeccion = value
            End Set
        End Property

        Dim mIndiceColeccion As Integer
        Public Property IndiceColeccion() As Integer Implements IColeccionable.IndiceColeccion
            Get
                Return mIndiceColeccion
            End Get
            Set(ByVal value As Integer)
                mIndiceColeccion = value
            End Set
        End Property


#End Region

    End Class
End Namespace
