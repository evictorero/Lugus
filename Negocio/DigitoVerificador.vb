Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports Negocio

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
                Return mDVV
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function ObtenerDVV(ByVal pTexto As String) As Integer
            Try
                Dim mDVV As Integer
                mDVV = Datos.DigitoVerificadorDatos.ObtenerDVV(pTexto)
                Return mDVV
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function VerificarIntegridad() As Boolean
            Try
                Dim rta As Boolean = True
                Dim DVH As Integer = 0
                Dim DVV As Integer = 0
                Dim NombreTablas(4) As String

                'la tabla de bitácora, patentes, usuarios y familias, así como también en las tablas platos y bebidas.
                NombreTablas(0) = "bFamilia"
                NombreTablas(1) = "bUsuario"
                NombreTablas(3) = "bPlato"
                NombreTablas(2) = "bBebida"
                NombreTablas(4) = "bBitacora"

                For i = 0 To 4
                    'obtener la tabla x
                    Dim errores As Integer = 0
                    Select Case NombreTablas(i)
                        Case "bFamilia"
                            Dim mFamilias As List(Of Familia) = (New Negocio.Familia).Listar
                            DVH = 0
                            For x As Integer = 0 To mFamilias.Count - 1
                                Dim CadenaDigitoVerificador As String = Encriptador.EncriptarDatos(2, mFamilias(x).descripcionCorta) + mFamilias(x).descripcionLarga
                                DVH = DVH + Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)
                            Next
                            DVV = ObtenerDVV("bFamilia")
                            If DVH <> DVV Then
                                Return False
                            End If
                        Case "bUsuario"
                            Dim mUSuarios As List(Of Usuario) = (New Negocio.Usuario).Listar
                            DVH = 0
                            For x As Integer = 0 To mUSuarios.Count - 1
                                Dim CadenaDigitoVerificador As String = Encriptador.EncriptarDatos(2, mUSuarios(x).usuario) + mUSuarios(x).nombre + mUSuarios(x).apellido
                                DVH = DVH + Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)
                            Next
                            DVV = ObtenerDVV("bUsuario")
                            If DVH <> DVV Then
                                Return False
                            End If
                        Case "bBebida"
                            Dim mBebidas As List(Of Bebida) = (New Negocio.Bebida).Listar
                            DVH = 0
                            For x As Integer = 0 To mBebidas.Count - 1
                                Dim CadenaDigitoVerificador As String = Encriptador.EncriptarDatos(2, mBebidas(x).descripcionCorta) + mBebidas(x).descripcionLarga
                                DVH = DVH + Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)
                            Next
                            DVV = ObtenerDVV("bBebida")
                            If DVH <> DVV Then
                                Return False
                            End If

                        Case "bPlato"
                            Dim mPlatos As List(Of Plato) = (New Negocio.Plato).Listar
                            DVH = 0
                            For x As Integer = 0 To mPlatos.Count - 1
                                Dim CadenaDigitoVerificador As String = Encriptador.EncriptarDatos(2, mPlatos(x).descripcionCorta) + mPlatos(x).descripcionLarga
                                DVH = DVH + Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)
                            Next
                            DVV = ObtenerDVV("bPlato")
                            If DVH <> DVV Then
                                Return False
                            End If
                    End Select

                Next

                Return True

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Shared Function RegenerarDigitoVerificadores() As Boolean
            Try
                Dim rta As Boolean = True
                Dim DVH As Integer = 0
                Dim DVV As Integer = 0
                Dim NombreTablas(9) As String

                'la tabla de bitácora, patentes, usuarios y familias, así como también en las tablas platos y bebidas.
                NombreTablas(0) = "bFamilia"
                NombreTablas(1) = "bUsuario"
                NombreTablas(2) = "bPlato"
                NombreTablas(3) = "bBebida"
                NombreTablas(4) = "bBitacora"
                NombreTablas(5) = "rUsuarioPatente"
                NombreTablas(6) = "rUsuarioFamilia"
                NombreTablas(7) = "rFamiliaPatente"
                NombreTablas(8) = "rPedidoPlato"
                NombreTablas(9) = "rPedidoBebida"

                For i = 0 To 9
                    'obtener la tabla x
                    Dim errores As Integer = 0
                    Select Case NombreTablas(i)
                        Case "bFamilia"
                            Dim mFamilias As List(Of Familia) = (New Negocio.Familia).Listar
                            For X As Integer = 0 To mFamilias.Count - 1
                                Dim mFamilia As New Negocio.Familia
                                mFamilia.Cargar(mFamilias(X).id)
                                mFamilia.Guardar()
                            Next
                        Case "bUsuario"
                            Dim mUsuarios As List(Of Usuario) = (New Negocio.Usuario).Listar
                            For X As Integer = 0 To mUsuarios.Count - 1
                                Dim mUsuario As New Negocio.Usuario
                                mUsuario.Cargar(mUsuarios(X).id)
                                mUsuario.Guardar()
                            Next
                        Case "bBebida"
                            Dim mBebidas As List(Of Bebida) = (New Negocio.Bebida).Listar
                            For X As Integer = 0 To mBebidas.Count - 1
                                Dim mBebida As New Negocio.Bebida
                                mBebida.Cargar(mBebidas(X).id)
                                mBebida.Guardar()
                            Next
                        Case "bPlato"
                            Dim mPlatos As List(Of Plato) = (New Negocio.Plato).Listar
                            For X As Integer = 0 To mPlatos.Count - 1
                                Dim mPlato As New Negocio.Plato
                                mPlato.Cargar(mPlatos(X).id)
                                mPlato.Guardar()
                            Next
                        Case "rPedidoPlato"
                            Dim mPedidoPlatos As List(Of PedidoPlato) = (New Negocio.PedidoPlato).Listar
                            For X As Integer = 0 To mPedidoPlatos.Count - 1
                                Dim mPedidoPlato As New Negocio.PedidoPlato
                                mPedidoPlato.Cargar(mPedidoPlatos(X).id_pedido, mPedidoPlatos(X).Id_Plato)
                                mPedidoPlato.GuardarModificacion()
                            Next
                        Case "rFamiliaPatente"
                            Dim mFamiliaPatentes As List(Of FamiliaPatente) = (New Negocio.FamiliaPatente).Listar
                            For X As Integer = 0 To mFamiliaPatentes.Count - 1
                                Dim mFamiliaPAtente As New Negocio.FamiliaPatente
                                mFamiliaPAtente.Cargar(mFamiliaPatentes(X).id_familia, mFamiliaPatentes(X).id_patente)
                                mFamiliaPAtente.GuardarModificacion()
                            Next
                        Case "rUsuarioPatente"
                            Dim mUsuarioPatentes As List(Of UsuarioPatente) = (New Negocio.UsuarioPatente).Listar
                            For X As Integer = 0 To mUsuarioPatentes.Count - 1
                                Dim mUsuarioPatente As New Negocio.UsuarioPatente
                                mUsuarioPatente.Cargar(mUsuarioPatentes(X).id_usuario, mUsuarioPatentes(X).id_patente)
                                mUsuarioPatente.GuardarModificacion()
                            Next
                    End Select

                Next

                Return True

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
    End Class

End Namespace
