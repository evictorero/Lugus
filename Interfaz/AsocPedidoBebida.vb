Imports Negocio.Negocio
Public Class AsocPedidoBebida

#Region "Declaraciones"

    Dim mPedidoBebida As Negocio.Negocio.PedidoBebida

    Friend mOperacion As TipoOperacion
    Friend Enum TipoOperacion
        Alta = 1
        Baja = 2
        Enviar = 3
        Finalizar = 4
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

    Friend Property PedidoBebidaAEditar() As Negocio.Negocio.PedidoBebida
        Get
            Return mPedidoBebida
        End Get
        Set(ByVal value As Negocio.Negocio.PedidoBebida)
            mPedidoBebida = value
        End Set
    End Property
#End Region

#Region "Eventos Form"

    Private Sub AsocPedidoBebida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
        Me.txtId_bebida.Enabled = False
        Me.txtEstado.ReadOnly = True

        cbDescripcionBebida.DataSource = (New Negocio.Negocio.Bebida).Listar
        cbDescripcionBebida.DisplayMember = "descripcionLarga"
        cbDescripcionBebida.ValueMember = "id"

        Select Case mOperacion
            Case TipoOperacion.Alta
                Me.txtId_bebida.Text = ""
                Me.txtEstado.Text = "INGRESADO"
                Me.lblDescripcion.Text = "Descripcion"
            Case TipoOperacion.Enviar
                If Not IsNothing(mPedidoBebida) Then
                    If mPedidoBebida.Estado = "I" Then
                        Me.txtId_bebida.Text = mPedidoBebida.Id_bebida
                        Me.txtid_pedido.Text = mPedidoBebida.id_pedido
                        Me.txtId_bebida.Text = mPedidoBebida.Id_bebida
                        Me.txtId_bebida.Visible = False
                        Me.txtid_pedido.Text = mPedidoBebida.id_pedido
                        Me.txtid_pedido.Visible = False
                        Me.cbDescripcionBebida.SelectedValue = mPedidoBebida.Id_bebida
                        Me.cbDescripcionBebida.Enabled = False
                        Me.txtEstado.Text = "PENDIENTE"
                    Else
                        MsgBox("Solo puede Enviar a cocina aquello que este en estado Ingresado.")
                        Me.Close()
                    End If
                End If
            Case TipoOperacion.Finalizar
                If Not IsNothing(mPedidoBebida) Then
                    If mPedidoBebida.Estado = "I" Or mPedidoBebida.Estado = "P" Then
                        Me.txtId_bebida.Text = mPedidoBebida.Id_bebida
                        Me.txtid_pedido.Text = mPedidoBebida.id_pedido
                        Me.txtId_bebida.Text = mPedidoBebida.Id_bebida
                        Me.txtId_bebida.Visible = False
                        Me.txtid_pedido.Text = mPedidoBebida.id_pedido
                        Me.txtid_pedido.Visible = False
                        Me.cbDescripcionBebida.SelectedValue = mPedidoBebida.Id_bebida
                        Me.cbDescripcionBebida.Enabled = False
                        Me.txtEstado.Text = "FINALIZADO"
                    Else
                        MsgBox("Solo puede Finalizar aquello que este en estado Ingresado o Pendiente.")
                        Me.Close()
                    End If


                End If
            Case TipoOperacion.Baja

                If Not IsNothing(mPedidoBebida) Then
                    Me.txtId_bebida.Text = mPedidoBebida.Id_bebida
                    Me.txtId_bebida.Visible = False
                    Me.txtid_pedido.Text = mPedidoBebida.id_pedido
                    Me.txtid_pedido.Visible = False
                    Me.cbDescripcionBebida.SelectedValue = mPedidoBebida.Id_bebida
                    Me.cbDescripcionBebida.Enabled = False
                    Me.cbDescripcionBebida.Visible = False
                    Me.txtEstado.Visible = False
                    Me.lblEstado.Visible = False
                    Me.lblDescripcion.Text = "¿Esta Seguro que desea eliminar esta asociacion Pedido Bebida?"
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
                    mPedidoBebida = New Negocio.Negocio.PedidoBebida
                    mPedidoBebida.Id_bebida = cbDescripcionBebida.SelectedValue
                    mPedidoBebida.id_usuario_alta = Principal.UsuarioEnSesion.id
                    mPedidoBebida.Estado = EstadoPlatoBebida(txtEstado.Text)
                    CType(Me.Owner, Pedidos).PedidoAEditar.AgregarPedidoBebida(mPedidoBebida)

                Case TipoOperacion.Enviar
                    If Not IsNothing(mPedidoBebida) Then
                        mPedidoBebida.Id_bebida = cbDescripcionBebida.SelectedValue
                        mPedidoBebida.id_usuario_alta = Principal.UsuarioEnSesion.id
                        mPedidoBebida.Estado = txtEstado.Text
                        mPedidoBebida.Estado = EstadoPlatoBebida(Me.txtEstado.Text)
                        CType(Me.Owner, Pedidos).PedidoAEditar.ModificarPedidoBebida(mPedidoBebida)
                    End If

                Case TipoOperacion.Finalizar
                    If Not IsNothing(mPedidoBebida) Then
                        mPedidoBebida.Id_bebida = cbDescripcionBebida.SelectedValue
                        mPedidoBebida.id_usuario_alta = Principal.UsuarioEnSesion.id
                        mPedidoBebida.Estado = txtEstado.Text
                        mPedidoBebida.Estado = EstadoPlatoBebida(Me.txtEstado.Text)
                        CType(Me.Owner, Pedidos).PedidoAEditar.ModificarPedidoBebida(mPedidoBebida)
                    End If
                Case TipoOperacion.Baja
                    If Not IsNothing(mPedidoBebida) Then
                        CType(Me.Owner, Pedidos).PedidoAEditar.EliminarPedidoBebida(mPedidoBebida.IndiceColeccion)
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