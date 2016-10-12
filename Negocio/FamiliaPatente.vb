
Imports Datos.ProveedorDeDatos.DB

Namespace Negocio

    Public Class FamiliaPatente : Implements IColeccionable

#Region "Declaraciones"
        Dim mId_familia As Integer
        Dim mId_Patente As Integer
        Dim mId_Usuario_alta As Integer
        Dim mDvh As Integer

#End Region

#Region "Constructores"
        Public Sub New()

        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.FamiliaPatenteDTO)
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

        Public Property id_familia() As Integer
            Get
                Return mId_familia
            End Get
            Set(ByVal value As Integer)
                mId_familia = value
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
            Dim mDTO As New DTO.FamiliaPatenteDTO

            mDTO.Id_familia = Me.id_familia
            mDTO.Id_Patente = Me.id_patente
            mDTO.Id_Usuario_alta = Me.id_usuario_alta
            mDTO.Dvh = Me.dvh

            ValidarCampos() ' Celeste Cambiar

            'If mId = 0 Then
            '    mDTO.id = Datos.BebidaDatos.ObtenerProximoId()
            '    mDTO.dvh = "23423354"
            Datos.FamiliaPatenteDatos.GuardarNuevo(mDTO)
            'Else
            '    mDTO.id = Me.id
            '    mDTO.dvh = "23423433"
            '    Datos.BebidaDatos.GuardarModificacion(mDTO)
            'End If

        End Sub
        Public Overridable Sub Cargar()
            If mId_Patente > 0 Then
                Dim mDTO As DTO.FamiliaPatenteDTO = Datos.FamiliaPatenteDatos.Obtener(mId_Patente)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Familia Patente  sin Id especificado")

            End If
        End Sub

        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mId_familia = pDr("id_familia")
                mId_Patente = pDr("id_patente")
                mId_Usuario_alta = pDr("id_usuario_alta")
                mDvh = pDr("dvh")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Public Overridable Sub Cargar(ByVal pId_patente As Integer)
            If mId_Patente > 0 Then
                Dim mDTO As DTO.FamiliaPatenteDTO = Datos.FamiliaPatenteDatos.Obtener(pId_patente)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Familia Patente  sin Id especificado")
            End If
        End Sub

        Public Sub Cargar(ByVal pDTO As DTO.FamiliaPatenteDTO)
            mId_familia = pDTO.Id_familia
            mId_Patente = pDTO.Id_Patente
            mId_Usuario_alta = pDTO.Id_Usuario_alta
            mDvh = pDTO.Dvh
        End Sub

        Public Overridable Sub Eliminar()
            If mId_Patente > 0 And mId_familia > 0 Then
                Try
                    Datos.FamiliaPatenteDatos.Eliminar(mId_familia, mId_Patente)
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar la Familia Patente especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar Familia Patente  sin Id especifico.")
            End If
        End Sub

        Private Sub ValidarCampos()
            'If (Me.descripcionCorta = "") Then
            '    Throw New ApplicationException("Debe completar la descripción corta.")
            'End If
            'If (Me.descripcionLarga = "") Then
            '    Throw New ApplicationException("Debe completar la descripción larga.")
            'End If
            'If (Me.habilitado = "") Then
            '    Throw New ApplicationException("Debe completar el campo habilitado.")
            'End If
        End Sub

        Public Overridable Function Listar() As Collections.Generic.List(Of FamiliaPatente)
            Dim mCol As New Collections.Generic.List(Of FamiliaPatente)
            Dim mColDTO As List(Of DTO.FamiliaPatenteDTO) = Datos.FamiliaPatenteDatos.Listar()

            For Each mDTO As DTO.FamiliaPatenteDTO In mColDTO
                mCol.Add(New Negocio.FamiliaPatente(mDTO))
            Next

            Return mCol
        End Function

        Public Overridable Function Listar(ByVal pId_familia As Integer) As Collections.Generic.List(Of FamiliaPatente)
            Dim mCol As New Collections.Generic.List(Of FamiliaPatente)
            Dim mColDTO As List(Of DTO.FamiliaPatenteDTO) = Datos.FamiliaPatenteDatos.Listar(pId_familia)

            For Each mDTO As DTO.FamiliaPatenteDTO In mColDTO
                mCol.Add(New Negocio.FamiliaPatente(mDTO))
            Next

            Return mCol
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
