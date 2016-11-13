Imports Negocio.Negocio
Public Class AsocPedidoPlato

#Region "Declaraciones"

    Dim mPedidoPlato As Negocio.Negocio.PedidoPlato

    Friend mOperacion As TipoOperacion
    Friend Enum TipoOperacion
        Alta = 1
        Baja = 2
        Modificacion = 3
    End Enum
#End Region

#Region "Propiedades"
    Friend Property Operacion() As TipoOperacion
        Get
            Return mOperacion
        End Get
        Set(ByVal value As TipoOperacion)
            mOperacion = value
        End Set
    End Property

    Friend Property PedidoPlatoAEditar() As Negocio.Negocio.PedidoPlato
        Get
            Return mPedidoPlato
        End Get
        Set(ByVal value As Negocio.Negocio.PedidoPlato)
            mPedidoPlato = value
        End Set
    End Property
#End Region

#Region "Eventos Form"

    Private Sub AsocPedidoPlato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
        Me.txtid_plato.Enabled = False
        Me.txtEstado.ReadOnly = True

        Select Case mOperacion
            Case TipoOperacion.Alta
                Me.txtId_plato.Text = ""
                Me.txtEstado.Text = "INGRESADO"
                Me.lblDescripcion.Text = "Descripcion"
                cbDescripcionPatente.DataSource = (New Negocio.Negocio.Plato).Listar
                cbDescripcionPatente.DisplayMember = "descripcionLarga"
                cbDescripcionPatente.ValueMember = "id"

            Case TipoOperacion.Baja

                If Not IsNothing(mPedidoPlato) Then
                    Me.txtid_plato.Text = mPedidoPlato.Id_Plato
                    Me.txtid_plato.Visible = False
                    Me.txtid_usuario.Text = mPedidoPlato.id_pedido
                    Me.txtid_usuario.Visible = False
                    Me.cbDescripcionPatente.SelectedValue = mPedidoPlato.Id_Plato
                    Me.cbDescripcionPatente.Enabled = False
                    Me.cbDescripcionPatente.Visible = False
                    Me.txtEstado.Visible = False
                    Me.lblEstado.Visible = False
                    Me.lblDescripcion.Text = "¿Esta Seguro que desea eliminar esta asociacion Pedido Plato?"
                    Me.btnGuardar.Text = "Eliminar"
                    Me.btnGuardar.BackColor = Color.Firebrick
                    Me.btnGuardar.ForeColor = Color.AntiqueWhite
                End If
        End Select
    End Sub
#End Region

#Region "Metodos"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Select Case mOperacion
                Case TipoOperacion.Alta
                    mPedidoPlato = New Negocio.Negocio.PedidoPlato
                    mPedidoPlato.Id_Plato = cbDescripcionPatente.SelectedValue
                    mPedidoPlato.id_usuario_alta = Principal.UsuarioEnSesion.id
                    mPedidoPlato.Estado = txtEstado.Text

                    CType(Me.Owner, Pedidos).PedidoAEditar.AgregarPedidoPlato(mPedidoPlato)

                Case TipoOperacion.Baja
                    If Not IsNothing(mPedidoPlato) Then
                        CType(Me.Owner, Pedidos).PedidoAEditar.EliminarPedidoPlato(mPedidoPlato.IndiceColeccion)
                    End If
            End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Me.Close()
        End Sub
    Public Function EstadoPlatoBebida(pEstado As String) As String
        Select Case pEstado
            Case "INGRESADO"
                Return "I"
            Case "PENDIENTE"
                Return "P"
            Case "EN PROCESO"
                Return "E"
            Case "LISTO"
                Return "L"
            Case "FINALIZADO"
                Return "F"
            Case "I"
                Return "INGRESADO"
            Case "P"
                Return "PENDIENTE"
            Case "E"
                Return "EN PROCESO"
            Case "L"
                Return "LISTO"
            Case "F"
                Return "FINALIZADO"
        End Select
        Return "I"
    End Function
#End Region
End Class
