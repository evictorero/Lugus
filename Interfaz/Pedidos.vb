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

        'dgvFamilias.DataSource = mUsuario.UsuarioFamilia
        'If dgvFamilias.Rows.Count > 0 Then
        '    For i As Integer = 0 To dgvFamilias.Rows.Count - 1
        '        Dim mFamilia As New Negocio.Negocio.Familia
        '        mFamilia.Cargar(CInt(dgvFamilias.Rows(i).Cells(1).Value))
        '        dgvFamilias.Rows(i).Cells(2).Value = mFamilia.descripcionCorta
        '    Next
        'End If

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
        Me.txtEstado.Text = "EN CURSO"
        mPedido.Estado = "E"
        Dim mForm As New AsocPedidoPlato
        mForm.Operacion = AsocPedidoPlato.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
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
End Class