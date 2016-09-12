Imports Microsoft.VisualBasic
Imports DTO.TraductorDTO
Imports Datos.ProveedorDeDatos
Imports System.Security
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Namespace Negocio


    Public Class Traductor

#Region "Declaraciones"

        Dim mIdUsuario As String
        Dim mMensaje As String
        Dim mTraduccion As String
#End Region

#Region "Constructores"
        Public Sub New()

        End Sub
#End Region

#Region "Propiedades"
        Public Property idUsuario() As Integer
            Get
                Return mIdUsuario
            End Get
            Set(ByVal value As Integer)
                mIdUsuario = value
            End Set
        End Property

        Public Property mensaje() As String
            Get
                Return mMensaje
            End Get
            Set(ByVal value As String)
                mMensaje = value
            End Set
        End Property

        Public Property traduccion() As String
            Get
                Return mTraduccion
            End Get
            Set(ByVal value As String)
                mTraduccion = value
            End Set
        End Property
#End Region


#Region "Métodos"

        Public Function ObtenerTraduccion(pIdIdioma As Integer, pMensaje As String) As String
            Dim mMensajeTraducido As String

            mMensajeTraducido = Datos.TraductorDatos.ObtenerTraduccion(pIdIdioma, pMensaje)

            Return mMensajeTraducido
        End Function

        Public Sub TraducirForm(ByRef Form As Form,
                                ByVal idIdioma As Integer)
            'traduzco solo si es distinto del default español
            If idIdioma <> 1 Then
                ' CAMBIO EL TEXTO DE LA VENTANA
                Form.Text = Datos.TraductorDatos.ObtenerTraduccion(idIdioma, Form.Text)

                'Recorro con recursividad todo el menu para traducir
                Dim menues As New List(Of ToolStripItem)
                For Each t As ToolStripItem In Form.MainMenuStrip.Items
                    GetMenues(t, menues)
                Next

                Dim msg As String = ""
                For Each t As ToolStripItem In menues
                    'comparo que no retorne null ni string de 1 espacio sino falla
                    If Not String.IsNullOrEmpty(t.Text.Trim) Then
                        t.Text = Datos.TraductorDatos.ObtenerTraduccion(idIdioma, t.Text)
                    End If
                Next
                MessageBox.Show(msg)
            End If
        End Sub
        Public Sub GetMenues(ByVal Current As ToolStripItem, ByRef menues As List(Of ToolStripItem))
            menues.Add(Current)
            If TypeOf (Current) Is ToolStripMenuItem Then
                For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                    GetMenues(menu, menues)
                Next
            End If
        End Sub

#End Region


    End Class
End Namespace