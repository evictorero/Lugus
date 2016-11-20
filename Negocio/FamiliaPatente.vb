
Imports Datos.ProveedorDeDatos.DB

Namespace Negocio

    Public Class FamiliaPatente : Implements IColeccionable

#Region "Declaraciones"
        Dim mId_familia As Integer
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
            Dim mDTO As New DTO.FamiliaPatenteDTO
            Dim Existe As Boolean = False

            mDTO.Id_familia = Me.id_familia
            mDTO.Id_Patente = Me.id_patente
            mDTO.Id_Usuario_alta = Me.id_usuario_alta
            mDTO.M_negada = Me.mM_negada

            'Recalculo del digito verificador horizontal
            Dim CadenaDigitoVerificador As String = Convert.ToString(mDTO.Id_familia) + Convert.ToString(mDTO.Id_Patente)
            mDTO.Dvh = Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)

            Existe = Datos.FamiliaPatenteDatos.Existe(mDTO.Id_familia, mDTO.Id_Patente)
            If Not Existe Then
                Datos.FamiliaPatenteDatos.GuardarNuevo(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar una Familia Patente  ya existente.")
            End If

            'Recalculo del digito verificador vertical
            Dim mDVV As New Negocio.DigitoVerificador("rFamiliaPatente")
            mDVV.tabla = "rFamiliaPatente"
            mDVV.valor = Negocio.DigitoVerificador.CalcularDVV("rFamiliaPatente")
            mDVV.Guardar()
        End Sub
        Public Overridable Sub GuardarModificacion()
            Dim mDTO As New DTO.FamiliaPatenteDTO
            Dim Existe As Boolean = False

            mDTO.Id_familia = Me.id_familia
            mDTO.Id_Patente = Me.id_patente
            mDTO.Id_Usuario_alta = Me.id_usuario_alta
            mDTO.M_negada = Me.mM_negada

            'Recalculo del digito verificador horizontal
            Dim CadenaDigitoVerificador As String = Convert.ToString(mDTO.Id_familia) + Convert.ToString(mDTO.Id_Patente)
            mDTO.Dvh = Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)
            Datos.FamiliaPatenteDatos.GuardarModificacion(mDTO)

            'Recalculo del digito verificador vertical
            Dim mDVV As New Negocio.DigitoVerificador("rFamiliaPatente")
            mDVV.tabla = "rFamiliaPatente"
            mDVV.valor = Negocio.DigitoVerificador.CalcularDVV("rFamiliaPatente")
            mDVV.Guardar()
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
                mM_negada = pDr("m_negada")
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
            mM_negada = pDTO.M_negada
            mDvh = pDTO.Dvh
        End Sub

        Public Overridable Sub Eliminar()
            If mId_Patente > 0 And mId_familia > 0 Then
                Try
                    If Not EsFamiliaPatenteEsencial(mId_familia, mId_Patente) Then
                        Datos.FamiliaPatenteDatos.Eliminar(mId_familia, mId_Patente)

                        'Recalculo del digito verificador vertical
                        Dim mDVV As New Negocio.DigitoVerificador("rFamiliaPatente")
                        mDVV.tabla = "rFamiliaPatente"
                        mDVV.valor = Negocio.DigitoVerificador.CalcularDVV("rFamiliaPatente")
                        mDVV.Guardar()

                    Else
                        Throw New Exception
                    End If

                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar la Familia Patente especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar Familia Patente  sin Id especifico.")
            End If
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

        Public Shared Function EsFamiliaPatenteEsencial(ByVal pId_Familia As Integer, ByVal pId_Patente As Integer) As Boolean
            Dim rta As Boolean = False

            rta = Datos.FamiliaPatenteDatos.EsFamiliaPatenteEsencial(pId_Familia, pId_Patente)
            Return rta

        End Function
        Public Overridable Sub Cargar(ByVal pId_Familia As Integer, ByVal pId_patente As Integer)
            If pId_Familia > 0 And pId_patente > 0 Then
                Dim mDTO As DTO.FamiliaPatenteDTO = Datos.FamiliaPatenteDatos.Obtener(pId_Familia, pId_patente)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Pedido Plato  sin Id especificado")
            End If
        End Sub
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
