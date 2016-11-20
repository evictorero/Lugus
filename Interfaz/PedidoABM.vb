Imports Negocio.Negocio.Pedido
Imports Negocio.Negocio.UsuarioPatente

    Public Class PedidoABM

        Dim TieneAccesoAlta As Boolean = False
        Dim TieneAccesoModif As Boolean = False
        Dim TieneAccesoElim As Boolean = False
        Dim TieneAccesoRehab As Boolean = False

#Region "Eventos Form"
        Private Sub PedidoABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If TienePermisoAcceso() = True Then
            'Seteo de aspecto de la grilla
            With Me.dgvPedidos
                .AllowDrop = False
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .AutoGenerateColumns = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False

                With .Columns
                    .Add("cid", "Código")
                    .Item(0).DataPropertyName = "id" 'nombre del dto
                    '.Item(0).Width = 100
                    .Item(0).Visible = False

                    .Add("cDescripcion", "Descripción")
                    .Item(1).DataPropertyName = "descripcion"
                    .Item(1).Width = 100

                    .Add("cEstado", "Estado")
                    .Item(2).DataPropertyName = "estado"
                    .Item(2).Width = 100
                    .Item(2).Visible = False

                    .Add("cEstado", "Estado")
                    .Item(3).DataPropertyName = "Desc estado"
                    .Item(3).Width = 100
                    .Item(3).Visible = True

                    .Add("cfechaBaja", "Fecha de Finalización")
                    .Item(4).DataPropertyName = "fechaBaja"
                    .Item(4).Width = 100
                    .Item(4).DefaultCellStyle.Format = "dd/MM/yyyy"

                    .Add("cfechaModif", "Fecha de modificación")
                    .Item(5).DataPropertyName = "fechaModif"
                    .Item(5).Width = 100
                    .Item(5).DefaultCellStyle.Format = "dd/MM/yyyy"

                    .Add("cidUsuario", "Usuario Alta/Modif")
                    .Item(6).DataPropertyName = "idUsuarioAlta"
                    .Item(6).Width = 100
                    .Item(6).Visible = False

                    .Add("cNombreUsuario", "Usuario Alta/Modif")
                    .Item(7).DataPropertyName = "Nombre Usuario"
                    .Item(7).Width = 150
                    .Item(7).Visible = True
                End With

            End With

            'Seteo de elementos de interfaz
            Me.btnFinalizar.Enabled = False
            Me.btnModificar.Enabled = False
            Me.btnNuevo.Enabled = True
            Me.btnReabrir.Enabled = False

            'Método de carga de datos en la grilla
            ActualizarGrilla()

            Me.dgvPedidos.ClearSelection()

            Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
            Me.KeyPreview = True
            AddHandler Me.KeyUp, AddressOf Ayuda

            ToolTip()
        Else
            Me.Close()
            MsgBox("Acceso Restringido")
        End If

    End Sub
#End Region

#Region "Métodos"

    Friend Sub ActualizarGrilla()
        Me.dgvPedidos.DataSource = (New Negocio.Negocio.Pedido).Listar
        If Me.dgvPedidos.RowCount = 0 Then
            Me.txtMensaje.Text = Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen Pedidos ingresados en el sistema")
        Else
            Me.txtMensaje.Text = ""
        End If
        If dgvPedidos.Rows.Count > 0 Then
            For i As Integer = 0 To dgvPedidos.Rows.Count - 1
                Dim mUsuario As New Negocio.Negocio.Usuario
                mUsuario.Cargar(CInt(dgvPedidos.Rows(i).Cells(6).Value))
                dgvPedidos.Rows(i).Cells(3).Value = EstadoPedido(dgvPedidos.Rows(i).Cells(2).Value)
                dgvPedidos.Rows(i).Cells(7).Value = mUsuario.usuario
            Next
        End If
        'Dim CadenaDigitoVerificador As String
        'If dgvPedidos.Rows.Count > 0 Then
        '    For i As Integer = 0 To dgvPedidos.Rows.Count - 1
        '        Dim mUSuario As New Negocio.Negocio.Usuario
        '        mUSuario.Cargar(CInt(dgvPedidos.Rows(i).Cells(0).Value))
        '        CadenaDigitoVerificador = mUSuario.usuario + mUSuario.nombre + mUSuario.apellido + Convert.ToString(mUSuario.fechaModif)
        '        mUSuario.dvh = Negocio.Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)
        '        mUSuario.Guardar()
        '    Next
        'End If
    End Sub
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim mId As Integer = CInt(Me.dgvPedidos.SelectedRows(0).Cells(0).Value)
        Dim Pedido As New Negocio.Negocio.Pedido(mId)
        If SePuedeEliminar(mId) Then
            Dim result As Integer = MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea finalizar el pedido seleccionado?"), "Eliminar", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Pedido.Eliminar()
                MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Pedido finalizado correctamente."))
            End If

            ActualizarGrilla()
        Else
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "El pedido no puede finalizarse debido a que posee una bebida o plato en curso."))
        End If
    End Sub
    Private Sub btnReabrir_Click(sender As Object, e As EventArgs) Handles btnReabrir.Click
        Dim mId As Integer = CInt(Me.dgvPedidos.SelectedRows(0).Cells(0).Value)
        Dim Pedido As New Negocio.Negocio.Pedido(mId)
        Dim result As Integer = MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea reabrir el pedido seleccionado?"), "Reabrir", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Pedido.Rehabilitar()
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Pedido reabierto correctamente."))
        End If
        ActualizarGrilla()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim mForm As New Pedidos
        mForm.mOperacion = Interfaz.Pedidos.TipoOperacion.Alta
        mForm.PedidoAEditar = New Negocio.Negocio.Pedido
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvPedidos.SelectedRows.Count > 0 Then
            Dim mId As Integer = CInt(Me.dgvPedidos.SelectedRows(0).Cells(0).Value)
            Dim mForm As New Pedidos
            mForm.mOperacion = Interfaz.Pedidos.TipoOperacion.Modificacion
            mForm.PedidoAEditar = New Negocio.Negocio.Pedido(mId)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub
    Private Sub dgvPedidos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPedidos.SelectionChanged
        Me.btnFinalizar.Enabled = False
        Me.btnModificar.Enabled = False
        Me.btnNuevo.Enabled = False
        Me.btnReabrir.Enabled = False

        If Me.dgvPedidos.SelectedRows.Count > 0 Then
            'Se evalua la fecha de baja, si esta vacio, (No se cargo el dto)
            If IsNothing(Me.dgvPedidos.SelectedRows(0).Cells(4).Value) Then
                If TieneAccesoElim Then
                    Me.btnFinalizar.Enabled = True
                End If
                If TieneAccesoModif Then
                    Me.btnModificar.Enabled = True
                End If
            Else
                If TieneAccesoRehab = True Then
                    Me.btnReabrir.Enabled = True
                End If
            End If
        End If

        If TieneAccesoAlta = True Then
            Me.btnNuevo.Enabled = True
        End If
    End Sub
    Public Function TienePermisoAcceso() As Boolean
        'Patentes 9 10 11 12
        Dim tieneAcceso As Boolean = False
        For x As Integer = 0 To Principal.UsuarioEnSesion.UsuarioPatente.Count - 1
            Select Case Principal.UsuarioEnSesion.UsuarioPatente(x).id_patente
                Case 9
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoAlta = True
                        tieneAcceso = True
                    End If

                Case 10
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoModif = True
                        tieneAcceso = True
                    End If

                Case 11
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoElim = True
                        tieneAcceso = True
                    End If

                Case 12
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoRehab = True
                        tieneAcceso = True
                    End If
            End Select
        Next
        Dim mListaPatentesDeFamiliaporUsuario As New List(Of Negocio.Negocio.UsuarioPatente)
        mListaPatentesDeFamiliaporUsuario = Principal.UsuarioEnSesion.ListarPatentesDeFamiliaPorUsuario
        For x As Integer = 0 To mListaPatentesDeFamiliaporUsuario.Count - 1
            Select Case mListaPatentesDeFamiliaporUsuario(x).id_patente
                Case 9
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoAlta = True
                        tieneAcceso = True
                    End If

                Case 10
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoModif = True
                        tieneAcceso = True
                    End If

                Case 11
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoElim = True
                        tieneAcceso = True
                    End If
                Case 12
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoRehab = True
                        tieneAcceso = True
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

    Sub ToolTip()
        ToolTip1.SetToolTip(btnNuevo, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Crear un pedido nuevo."))
        ToolTip1.SetToolTip(btnModificar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Modificar un pedido."))
        ToolTip1.SetToolTip(btnFinalizar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Dar por finalizado un pedido."))
        ToolTip1.SetToolTip(btnReabrir, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Reabrir un pedido."))
    End Sub

    Private Sub Ayuda(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            Dim mForm As New msgMensaje
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.TextBox1.Text = Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Este formulario permitirá administrar los Pedidos.") & "
" & Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Los botones se habilitarán según los permisos asignados.") & "
" & Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Podrá generar un nuevo pedido, modificarlo y reabrirlo.")
            mForm.ShowDialog(Me)
        End If
    End Sub
#End Region

End Class
