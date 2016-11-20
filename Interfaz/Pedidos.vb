Imports Negocio.Negocio
Imports System.DateTime


    Public Class Pedidos

    Dim mPedido As Negocio.Negocio.Pedido

    Friend mOperacion As TipoOperacion

    Friend Enum TipoOperacion
        Alta = 1
        Baja = 2
        Modificacion = 3
        Rehabilitar = 4
    End Enum

    Friend Property PedidoAEditar() As Negocio.Negocio.Pedido
        Get
            Return mPedido
        End Get
        Set(ByVal value As Negocio.Negocio.Pedido)
            mPedido = value
        End Set
    End Property

    Private Sub Pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = True
        Me.txtDescripcion.Focus()

        TienePermisoAcceso()

        'Seteo de aspecto de la grilla 
        With Me.dgvPlatos
            .AllowDrop = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            With .Columns
                .Add("cId", "id_pedido")
                .Item(0).DataPropertyName = "Id_pedido"
                .Item(0).Visible = False

                .Add("cid_plato", "id_plato")
                .Item(1).DataPropertyName = "id_plato"
                .Item(1).Width = 125
                .Item(1).Visible = False

                .Add("cDescripcion", "Descripcion")
                .Item(2).DataPropertyName = "Descripcion"
                .Item(2).Width = 150
                .Item(2).Visible = True

                .Add("cdvh", "dvh")
                .Item(3).DataPropertyName = "dvh"
                .Item(3).Width = 125
                .Item(3).Visible = False

                .Add("cEstadoColeccion", "EstadoColeccion")
                .Item(4).DataPropertyName = "EstadoColeccion"
                .Item(4).Visible = False

                .Add("cIndiceColeccion", "IndiceColeccion")
                .Item(5).DataPropertyName = "IndiceColeccion"
                .Item(5).Visible = False

                .Add("cM_negada", "Estado")
                .Item(6).DataPropertyName = "Estado"
                .Item(6).Visible = False


                .Add("cM_negada", "Estado")
                .Item(7).DataPropertyName = "Desc Estado"
                .Item(7).Visible = True
            End With
        End With

        'Seteo de aspecto de la grilla 
        With Me.dgvBebidas
            .AllowDrop = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            With .Columns
                .Add("cId", "id_pedido")
                .Item(0).DataPropertyName = "Id_pedido"
                .Item(0).Visible = False

                .Add("cid_bebida", "id_bebida")
                .Item(1).DataPropertyName = "id_bebida"
                .Item(1).Width = 125
                .Item(1).Visible = False

                .Add("cDescripcion", "Descripcion")
                .Item(2).DataPropertyName = "Descripcion"
                .Item(2).Width = 150
                .Item(2).Visible = True

                .Add("cdvh", "dvh")
                .Item(3).DataPropertyName = "dvh"
                .Item(3).Width = 125
                .Item(3).Visible = False

                .Add("cEstadoColeccion", "EstadoColeccion")
                .Item(4).DataPropertyName = "EstadoColeccion"
                .Item(4).Visible = False

                .Add("cIndiceColeccion", "IndiceColeccion")
                .Item(5).DataPropertyName = "IndiceColeccion"
                .Item(5).Visible = False

                .Add("cM_negada", "Estado")
                .Item(6).DataPropertyName = "Estado"
                .Item(6).Visible = False


                .Add("cM_negada", "Estado")
                .Item(7).DataPropertyName = "Desc Estado"
                .Item(7).Visible = True
            End With
        End With

        Me.txtMesero.Text = Principal.UsuarioEnSesion.usuario

        Select Case mOperacion
            Case TipoOperacion.Alta
                Me.txtDescripcion.Text = ""
                Me.txtEstado.Text = "INGRESADO"
                Me.lblTitulo.Text = "Alta de Pedido"

            Case TipoOperacion.Modificacion
                If Not IsNothing(mPedido) Then
                    Me.txtId.Text = mPedido.id
                    Me.txtDescripcion.Text = mPedido.Descripcion
                    Me.txtCantidad.Text = mPedido.cantidad
                    Me.txtEstado.Text = EstadoPedido(mPedido.Estado)
                    Me.lblTitulo.Text = "Modificación de Pedido"
                End If
                ActualizarGrilla()
        End Select

        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf Ayuda

        ToolTip()

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Select Case mOperacion
                Case TipoOperacion.Alta, TipoOperacion.Modificacion
                    If IsNothing(mPedido) Then
                        mPedido = New Negocio.Negocio.Pedido
                    End If

                    mPedido.Descripcion = Me.txtDescripcion.Text
                    mPedido.cantidad = Me.txtCantidad.Text
                    mPedido.idUsuarioAlta = Principal.UsuarioEnSesion.id

                    If mOperacion = TipoOperacion.Alta Then
                        mPedido.Estado = "I"
                    Else
                        mPedido.Estado = "E"
                    End If
                    mPedido.ValidarFormato(Principal.UsuarioEnSesion.id_idioma)
                    mPedido.Guardar()
                    If mOperacion = TipoOperacion.Alta Then
                        MsgBox(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Pedido registrado correctamente."))
                    Else
                        MsgBox(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Pedido modificado correctamente."))
                    End If
                    Me.Close()
                Case TipoOperacion.Baja
                    Me.txtEstado.Text = "En Curso"
                    mPedido.Estado = "E"
                    mPedido.Eliminar()
                    Me.Close()
            End Select
        Catch ex As InvalidCastException
            MsgBox("Error al establecer el identificador del pedido seleccionado.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
            Select Case mOperacion
                Case TipoOperacion.Alta
                Dim result As Integer = MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Desea Cancelar la operación de Alta de Pedido?"), "Cancelar", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                        Me.Close()
                    End If
                Case TipoOperacion.Modificacion
                Dim result As Integer = MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Desea Cancelar la operación de Modificación de Pedido?"), "Cancelar", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                        Me.Close()
                    End If
            End Select

        End Sub

    Private Sub ActualizarGrilla()
        dgvPlatos.DataSource = mPedido.PedidoPlato
        If dgvPlatos.Rows.Count > 0 Then
            For i As Integer = 0 To dgvPlatos.Rows.Count - 1
                Dim mPlato As New Negocio.Negocio.Plato
                mPlato.Cargar(CInt(dgvPlatos.Rows(i).Cells(1).Value))
                dgvPlatos.Rows(i).Cells(2).Value = mPlato.descripcionCorta
                dgvPlatos.Rows(i).Cells(7).Value = EstadoPlatoBebida(dgvPlatos.Rows(i).Cells(6).Value)
            Next
        End If

        dgvBebidas.DataSource = mPedido.PedidoBebida
        If dgvBebidas.Rows.Count > 0 Then
            For i As Integer = 0 To dgvBebidas.Rows.Count - 1
                Dim mBebida As New Negocio.Negocio.Bebida
                mBebida.Cargar(CInt(dgvBebidas.Rows(i).Cells(1).Value))
                dgvBebidas.Rows(i).Cells(2).Value = mBebida.descripcionCorta
                dgvBebidas.Rows(i).Cells(7).Value = EstadoPlatoBebida(dgvBebidas.Rows(i).Cells(6).Value)
            Next
        End If

    End Sub

    Public Function TienePermisoAcceso() As Boolean
        'Patentes 9 10 11 12
        Dim tieneAcceso As Boolean = False
        For x As Integer = 0 To Principal.UsuarioEnSesion.UsuarioPatente.Count - 1
            Select Case Principal.UsuarioEnSesion.UsuarioPatente(x).id_patente
                Case 11
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        btnFinalizar.Enabled = True
                    End If
                Case 12
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        btnReabrir.Enabled = True
                    End If
            End Select
        Next
        Dim mListaPatentesDeFamiliaporUsuario As New List(Of Negocio.Negocio.UsuarioPatente)
        mListaPatentesDeFamiliaporUsuario = Principal.UsuarioEnSesion.ListarPatentesDeFamiliaPorUsuario
        For x As Integer = 0 To mListaPatentesDeFamiliaporUsuario.Count - 1
            Select Case mListaPatentesDeFamiliaporUsuario(x).id_patente
                Case 11
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        btnFinalizar.Enabled = True
                    End If
                Case 12
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        btnReabrir.Enabled = True
                    End If
            End Select
        Next
        Return tieneAcceso
    End Function

    Public Function SePuedeEliminar(ByVal pId As Integer) As Boolean
        'Dim pUsuario As New Negocio.Negocio.Usuario(pId)
        'If pUsuario.UsuarioPatente.Count > 0 Then
        '    For x As Integer = 0 To pUsuario.UsuarioPatente.Count - 1
        '        If Negocio.Negocio.UsuarioPatente.EsPatenteEsencial(pId, pUsuario.UsuarioPatente(x).id_patente) Then
        '            Return False
        '        End If
        '    Next
        'End If

        'If pUsuario.UsuarioFamilia.Count > 0 Then
        '    Dim mListaPatentesDeFamiliaporUsuario As New List(Of Negocio.Negocio.UsuarioPatente)
        '    mListaPatentesDeFamiliaporUsuario = pUsuario.ListarPatentesDeFamiliaPorUsuario
        '    For x As Integer = 0 To mListaPatentesDeFamiliaporUsuario.Count - 1
        '        If Negocio.Negocio.UsuarioFamilia.EsFamiliaPatenteEsencial(pId, pUsuario.UsuarioPatente(x).id_patente) Then
        '            Return False
        '        End If
        '    Next
        'End If
        Return True
    End Function

    Public Function EstadoPedido(pEstado As String) As String
        Select Case pEstado
            Case "I"
                Return "INGRESADO"
            Case "E"
                Return "EN CURSO"
            Case "F"
                Return "FINALIZADO"
        End Select

        Return "I"
    End Function

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

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim Pedido As New Negocio.Negocio.Pedido(txtId.Text)
        If SePuedeEliminar(Pedido.id) Then
            Dim result As Integer = MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea finalizar el pedido seleccionado?"), "Eliminar", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Pedido.Eliminar()
                MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Pedido finalizado correctamente."))
                Me.Close()
            End If
            ActualizarGrilla()
        Else
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "El pedido no puede finalizarse debido a que posee una bebida o plato en curso."))
        End If
    End Sub

    Private Sub btnAgregar_Platos_Click(sender As Object, e As EventArgs) Handles btnAgregar_Platos.Click
        If Me.txtId.Text = "" Then
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Guarde el pedido para poder agregar."))
        Else
            Me.txtEstado.Text = "EN CURSO"
            mPedido.Estado = "E"
            Dim mForm As New AsocPedidoPlato
            mForm.Operacion = AsocPedidoPlato.TipoOperacion.Alta
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnEliminar_platos_Click(sender As Object, e As EventArgs) Handles btnEliminar_platos.Click
        If Me.dgvPlatos.Rows.Count > 0 AndAlso Me.dgvPlatos.SelectedRows.Count = 1 Then
            Dim mIndice As Integer = CInt(dgvPlatos.SelectedRows(0).Cells(5).Value)
            Dim mForm As New AsocPedidoPlato
            mForm.Operacion = AsocPedidoPlato.TipoOperacion.Baja
            mForm.PedidoPlatoAEditar = mPedido.ObtenerPedidoPlatoPorIndice(mIndice)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnEnviar_plato_Click(sender As Object, e As EventArgs) Handles btnEnviar_plato.Click

        If Me.dgvPlatos.Rows.Count > 0 AndAlso Me.dgvPlatos.SelectedRows.Count = 1 Then
            Dim mIndice As Integer = CInt(Me.dgvPlatos.SelectedRows(0).Cells(5).Value)
            Dim mForm As New AsocPedidoPlato
            mForm.Operacion = AsocPedidoPlato.TipoOperacion.Enviar
            mForm.PedidoPlatoAEditar = mPedido.ObtenerPedidoPlatoPorIndice(mIndice)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnFinalizar_plato_Click(sender As Object, e As EventArgs) Handles btnFinalizar_plato.Click
        If Me.dgvPlatos.Rows.Count > 0 AndAlso Me.dgvPlatos.SelectedRows.Count = 1 Then
            Dim mIndice As Integer = CInt(Me.dgvPlatos.SelectedRows(0).Cells(5).Value)
            Dim mForm As New AsocPedidoPlato
            mForm.Operacion = AsocPedidoPlato.TipoOperacion.Finalizar
            mForm.PedidoPlatoAEditar = mPedido.ObtenerPedidoPlatoPorIndice(mIndice)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnAgregar_bebidas_Click(sender As Object, e As EventArgs) Handles btnAgregar_bebidas.Click
        If Me.txtId.Text = "" Then
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Guarde el pedido para poder agregar."))
        Else
            Me.txtEstado.Text = "EN CURSO"
            mPedido.Estado = "E"
            Dim mForm As New AsocPedidoBebida
            mForm.Operacion = AsocPedidoBebida.TipoOperacion.Alta
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnEnviar_bebidas_Click(sender As Object, e As EventArgs) Handles btnEnviar_bebidas.Click
        If Me.dgvBebidas.Rows.Count > 0 AndAlso Me.dgvBebidas.SelectedRows.Count = 1 Then
            Dim mIndice As Integer = CInt(Me.dgvBebidas.SelectedRows(0).Cells(5).Value)
            Dim mForm As New AsocPedidoBebida
            mForm.Operacion = AsocPedidoBebida.TipoOperacion.Enviar
            mForm.PedidoBebidaAEditar = mPedido.ObtenerPedidoBebidaPorIndice(mIndice)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnFinalizar_bebidas_Click(sender As Object, e As EventArgs) Handles btnFinalizar_bebidas.Click
        If Me.dgvBebidas.Rows.Count > 0 AndAlso Me.dgvBebidas.SelectedRows.Count = 1 Then
            Dim mIndice As Integer = CInt(Me.dgvBebidas.SelectedRows(0).Cells(5).Value)
            Dim mForm As New AsocPedidoBebida
            mForm.Operacion = AsocPedidoBebida.TipoOperacion.Finalizar
            mForm.PedidoBebidaAEditar = mPedido.ObtenerPedidoBebidaPorIndice(mIndice)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnEliminar_bebidas_Click(sender As Object, e As EventArgs) Handles btnEliminar_bebidas.Click
        If Me.dgvBebidas.Rows.Count > 0 AndAlso Me.dgvBebidas.SelectedRows.Count = 1 Then
            Dim mIndice As Integer = CInt(dgvBebidas.SelectedRows(0).Cells(5).Value)
            Dim mForm As New AsocPedidoBebida
            mForm.Operacion = AsocPedidoBebida.TipoOperacion.Baja
            mForm.PedidoBebidaAEditar = mPedido.ObtenerPedidoBebidaPorIndice(mIndice)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnEnviarTodo_Click(sender As Object, e As EventArgs) Handles btnEnviarTodo.Click
        Dim mPedidoPlato As Negocio.Negocio.PedidoPlato
        Dim ContadorPlatos As Integer = 0
        dgvPlatos.DataSource = mPedido.PedidoPlato
        If dgvPlatos.Rows.Count > 0 Then
            For i As Integer = 0 To dgvPlatos.Rows.Count - 1
                Dim mIndice As Integer = CInt(Me.dgvPlatos.Rows(i).Cells(5).Value)
                mPedidoPlato = mPedido.ObtenerPedidoPlatoPorIndice(mIndice)
                If mPedidoPlato.Estado = "I" Then
                    mPedidoPlato.Estado = "P"
                    mPedido.ModificarPedidoPlato(mPedidoPlato)
                    ContadorPlatos = 1
                End If
                ActualizarGrilla()
            Next
        End If

        Dim mPedidoBebida As Negocio.Negocio.PedidoBebida
        Dim ContadorBebidas As Integer = 0

        dgvBebidas.DataSource = mPedido.PedidoBebida
        If dgvBebidas.Rows.Count > 0 Then
            For i As Integer = 0 To dgvBebidas.Rows.Count - 1
                Dim mIndice As Integer = CInt(Me.dgvBebidas.Rows(i).Cells(5).Value)
                mPedidoBebida = mPedido.ObtenerPedidoBebidaPorIndice(mIndice)
                If mPedidoBebida.Estado = "I" Then
                    mPedidoBebida.Estado = "P"
                    mPedido.ModificarPedidoBebida(mPedidoBebida)
                    ContadorBebidas = 1
                End If
                ActualizarGrilla()
            Next
        End If
        If ContadorPlatos = 0 Then
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen platos Ingresados para Enviar a Pendiente."))
        End If
        If ContadorBebidas = 0 Then
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen bebidas Ingresadas para Enviar a Pendiente."))
        End If
    End Sub

    Sub ToolTip()
        ToolTip1.SetToolTip(btnAgregar_bebidas, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Agregar una bebida."))
        ToolTip1.SetToolTip(btnAgregar_Platos, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Agregar un plato."))

        ToolTip1.SetToolTip(btnEliminar_bebidas, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Eliminar una bebida."))
        ToolTip1.SetToolTip(btnEliminar_platos, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Eliminar un plato."))

        ToolTip1.SetToolTip(btnEnviar_bebidas, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Enviar la bebida a cocina."))
        ToolTip1.SetToolTip(btnEnviar_plato, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Enviar el plato a cocina."))

        ToolTip1.SetToolTip(btnFinalizar_bebidas, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Finalizar la bebida."))
        ToolTip1.SetToolTip(btnFinalizar_plato, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Finalizar el Plato."))

        ToolTip1.SetToolTip(btnFinalizar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Dar por Finalizado el pedido."))
        ToolTip1.SetToolTip(btnEnviarTodo, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Enviar todo el Pedido Pendiente a Cocina."))
        ToolTip1.SetToolTip(btnGuardar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Guardar los cambios realizados."))
        ToolTip1.SetToolTip(btnCancelar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Cancelar los cambios realizados."))
    End Sub

    Private Sub Ayuda(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            Dim mForm As New msgMensaje
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.TextBox1.Text = Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Este formulario permitirá administrar los Pedidos.") & Environment.NewLine &
                                   Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Podrá generar un nuevo usuario, modificarlo, agregarle y quitarle tanto familias como patentes.") & Environment.NewLine
            mForm.ShowDialog(Me)
        End If
    End Sub
End Class