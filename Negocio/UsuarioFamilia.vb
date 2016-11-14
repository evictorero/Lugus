
Imports Datos.ProveedorDeDatos.DB

Namespace Negocio

    Public Class UsuarioFamilia : Implements IColeccionable

#Region "Declaraciones"
        Dim mId_usuario As Integer
        Dim mId_Familia As Integer
        Dim mId_Usuario_alta As Integer
        Dim mDvh As Integer

#End Region

#Region "Constructores"
        Public Sub New()

        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.UsuarioFamiliaDTO)
            Me.Cargar(pDTO)
        End Sub
#End Region

#Region "Propiedades"
        Public Property id_familia() As Integer
            Get
                Return mId_Familia
            End Get
            Set(ByVal value As Integer)
                mId_Familia = value
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

#End Region

#Region "Métodos"

        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.UsuarioFamiliaDTO
            Dim Existe As Boolean = False

            mDTO.Id_Usuario = Me.id_usuario
            mDTO.Id_Familia = Me.id_familia
            mDTO.Id_Usuario_alta = Me.id_usuario_alta

            'Recalculo del digito verificador horizontal
            Dim CadenaDigitoVerificador As String = Convert.ToString(mDTO.Id_Usuario) + Convert.ToString(mDTO.Id_Familia)
            mDTO.Dvh = Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)

            Existe = Datos.UsuarioFamiliaDatos.Existe(mDTO.Id_Usuario, mDTO.Id_Familia)

            If Not Existe Then
                Datos.UsuarioFamiliaDatos.GuardarNuevo(mDTO)

            Else
                Throw New ApplicationException("Se intentó cargar un Usuario Familia ya existente.")
            End If

            'Recalculo del digito verificador vertical
            Dim mDVV As New Negocio.DigitoVerificador("rUsuarioFamilia")
            mDVV.tabla = "rUsuarioFamilia"
            mDVV.valor = Negocio.DigitoVerificador.CalcularDVV("rUsuarioFamilia")
            mDVV.Guardar()

        End Sub
        Public Overridable Sub Cargar()
            If mId_Familia > 0 Then
                Dim mDTO As DTO.UsuarioFamiliaDTO = Datos.UsuarioFamiliaDatos.Obtener(mId_Familia)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un usuario patente  sin Id especificado")

            End If
        End Sub

        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mId_usuario = pDr("id_usuario")
                mId_Familia = pDr("id_familia")
                mId_Usuario_alta = pDr("id_usuario_alta")
                mDvh = pDr("dvh")


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Public Overridable Sub Cargar(ByVal pid_familia As Integer)
            If mId_Familia > 0 Then
                Dim mDTO As DTO.UsuarioFamiliaDTO = Datos.UsuarioFamiliaDatos.Obtener(pid_familia)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un usuario patente  sin Id especificado")
            End If
        End Sub

        Public Sub Cargar(ByVal pDTO As DTO.UsuarioFamiliaDTO)
            mId_usuario = pDTO.Id_Usuario
            mId_Familia = pDTO.Id_Familia
            mId_Usuario_alta = pDTO.Id_Usuario_alta
            mDvh = pDTO.Dvh
        End Sub

        Public Overridable Sub Eliminar()
            If mId_Familia > 0 And mId_usuario > 0 Then
                Try
                    Datos.UsuarioFamiliaDatos.Eliminar(mId_usuario, mId_Familia)
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar la usuario patente especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar usuario patente  sin Id especifico.")
            End If
        End Sub


        Public Overridable Function Listar() As Collections.Generic.List(Of UsuarioFamilia)
            Dim mCol As New Collections.Generic.List(Of UsuarioFamilia)
            Dim mColDTO As List(Of DTO.UsuarioFamiliaDTO) = Datos.UsuarioFamiliaDatos.Listar()

            For Each mDTO As DTO.UsuarioFamiliaDTO In mColDTO
                mCol.Add(New Negocio.UsuarioFamilia(mDTO))
            Next

            Return mCol
        End Function

        Public Overridable Function Listar(ByVal pid_usuario As Integer) As Collections.Generic.List(Of UsuarioFamilia)
            Dim mCol As New Collections.Generic.List(Of UsuarioFamilia)
            Dim mColDTO As List(Of DTO.UsuarioFamiliaDTO) = Datos.UsuarioFamiliaDatos.Listar(pid_usuario)

            For Each mDTO As DTO.UsuarioFamiliaDTO In mColDTO
                mCol.Add(New Negocio.UsuarioFamilia(mDTO))
            Next

            Return mCol
        End Function

        Public Shared Function EsFamiliaPatenteEsencial(ByVal pId_usuario As Integer, ByVal pId_Familia As Integer) As Boolean
            Dim mCol As New List(Of UsuarioPatente)
            Dim mColDTO As List(Of DTO.UsuarioPatenteDTO) = Datos.UsuarioPatenteDatos.ListarPatentesDeFamiliaPorUsuario(pId_usuario, pId_Familia)
            Dim miUsuarioPatente As Negocio.UsuarioPatente
            For Each mDTO As DTO.UsuarioPatenteDTO In mColDTO
                miUsuarioPatente = New Negocio.UsuarioPatente(mDTO)
                If Datos.UsuarioPatenteDatos.EsPatenteEsencial(pId_usuario, miUsuarioPatente.id_patente) And
                       Datos.UsuarioFamiliaDatos.EsFamiliaEsencial(pId_usuario, miUsuarioPatente.id_patente) Then
                    Throw New Exception("Esta intentando eliminar una familia que tiene la patente esencial:" & miUsuarioPatente.id_patente)
                End If
            Next
            Return False
        End Function

        Public Shared Function EsFamiliaEsencial(ByVal pId_usuario As Integer, ByVal pId_Patente As Integer) As Boolean

            Dim rta As Boolean = Datos.UsuarioFamiliaDatos.EsFamiliaEsencial(pId_usuario, pId_Patente)

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

