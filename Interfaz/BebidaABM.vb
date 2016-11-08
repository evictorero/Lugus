Imports Negocio.Negocio.Bebida
Imports Negocio.Negocio.Traductor
Imports Negocio.Negocio.UsuarioPatente

Public Class BebidaABM

    Dim TieneAccesoAlta As Boolean = False
    Dim TieneAccesoModif As Boolean = False
    Dim TieneAccesoElim As Boolean = False
    Dim TieneAccesoRehab As Boolean = False

#Region "Eventos Form"
    Private Sub BebidaABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TienePermisoAcceso() = True Then

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
                    .Add("cid", "Código")
                    .Item(0).DataPropertyName = "id" 'nombre del dto
                    '.Item(0).Width = 100
                    .Item(0).Visible = False
                    '
                    .Add("cdescripcioncorta", "Nombre")
                    .Item(1).DataPropertyName = "DescripcionCorta"
                    .Item(1).Width = 100

                    .Add("cdescripcionlarga", "Descripción")
                    .Item(2).DataPropertyName = "DescripcionLarga"
                    .Item(2).Width = 100

                    .Add("chabilitado", "En carta")
                    .Item(3).DataPropertyName = "habilitado"
                    .Item(3).Width = 100

                    .Add("cfechaBaja", "Fecha de baja")
                    .Item(4).DataPropertyName = "fechaBaja"
                    .Item(4).Width = 100
                    .Item(4).DefaultCellStyle.Format = "dd/MM/yyyy"

                    .Add("cfechaModif", "Fecha de modificación")
                    .Item(5).DataPropertyName = "fechaModif"
                    .Item(5).Width = 100
                    .Item(5).DefaultCellStyle.Format = "dd/MM/yyyy"

                    .Add("cidUsuario", "Usuario Alta/Modif")
                    .Item(6).DataPropertyName = "idUsuario"
                    .Item(6).Width = 100

                End With

            End With

            'Seteo de elementos de interfaz
            Me.btnEliminar.Enabled = False
            Me.btnModificar.Enabled = False
            Me.btnNuevo.Enabled = True
            Me.btnRehabilitar.Enabled = False

            'Método de carga de datos en la grilla
            ActualizarGrilla()

            Me.dgvBebidas.ClearSelection()

            TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
        Else
            Me.Close()
            MsgBox("Acceso Restringido")
        End If
    End Sub
#End Region

#Region "Métodos"

    Friend Sub ActualizarGrilla()
        Me.dgvBebidas.DataSource = (New Negocio.Negocio.Bebida).Listar
        If Me.dgvBebidas.RowCount = 0 Then
            Me.txtMensaje.Text = ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen Bebidas ingresadas en el sistema")
        Else
            Me.txtMensaje.Text = ""
        End If
        'GENERAR DIGITO VERIFICADOR
        'Dim CadenaDigitoVerificador As String
        'If dgvBebidas.Rows.Count > 0 Then
        '    For i As Integer = 0 To dgvBebidas.Rows.Count - 1
        '        Dim mBebida As New Negocio.Negocio.Bebida
        '        mBebida.Cargar(CInt(dgvBebidas.Rows(i).Cells(0).Value))
        '        CadenaDigitoVerificador = mBebida.descripcionCorta + mBebida.descripcionLarga + Convert.ToString(mBebida.fechaModif)
        '        mBebida.dvh = Negocio.Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)
        '        mBebida.Guardar()
        '    Next
        'End If
        'Dim mDVV As New Negocio.Negocio.DigitoVerificador("bBebida")
        'mDVV.tabla = "bBebida"
        'mDVV.valor = Negocio.Negocio.DigitoVerificador.CalcularDVV("bBebida")
        'mDVV.Guardar()
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mId As Integer = CInt(Me.dgvBebidas.SelectedRows(0).Cells(0).Value)
        Dim bebida As New Negocio.Negocio.Bebida(mId)
        Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea dar de baja la Bebida seleccionada?"),
                                                ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Eliminar"),
                                                MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            bebida.Eliminar()
            MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Bebida eliminada correctamente"))
        End If
        ActualizarGrilla()
    End Sub

    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        Dim mId As Integer = CInt(Me.dgvBebidas.SelectedRows(0).Cells(0).Value)
        Dim bebida As New Negocio.Negocio.Bebida(mId)
        Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea rehabilitar la Bebida seleccionada?"),
                                                ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Rehabilitar"),
                                                MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            bebida.Rehabilitar()
            MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Bebida rehabilitada correctamente"))
        End If

        ActualizarGrilla()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim mForm As New Bebida
        mForm.mOperacion = Bebida.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvBebidas.SelectedRows.Count > 0 Then
            Try
                Dim mId As Integer = CInt(Me.dgvBebidas.SelectedRows(0).Cells(0).Value)

                Dim mForm As New Bebida
                mForm.mOperacion = Bebida.TipoOperacion.Modificacion
                mForm.BebidaAEditar = New Negocio.Negocio.Bebida(mId)
                mForm.StartPosition = FormStartPosition.CenterParent
                mForm.ShowDialog(Me)
                ActualizarGrilla()
            Catch ex As Exception
                'MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Error al intentar modificar la bebida seleccionada"))
            End Try

        End If


    End Sub

    Private Sub dgvBebidas_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBebidas.SelectionChanged
        Me.btnEliminar.Enabled = False
        Me.btnModificar.Enabled = False
        Me.btnNuevo.Enabled = False
        Me.btnRehabilitar.Enabled = False
        If Me.dgvBebidas.SelectedRows.Count > 0 Then
            'Se evalua la fecha de baja, si esta vacio, (No se cargo el dto)
            If IsNothing(Me.dgvBebidas.SelectedRows(0).Cells(4).Value) Then
                If TieneAccesoElim Then
                    Me.btnEliminar.Enabled = True
                End If
                If TieneAccesoModif Then
                    Me.btnModificar.Enabled = True
                End If
            Else
                If TieneAccesoRehab = True Then
                    Me.btnRehabilitar.Enabled = True
                End If
            End If
        End If
        If TieneAccesoAlta = True Then
            Me.btnNuevo.Enabled = True
        End If
    End Sub

    Public Function TienePermisoAcceso() As Boolean
        'Patentes 5 6 7 8
        Dim tieneAcceso As Boolean = False
        For x As Integer = 0 To Principal.UsuarioEnSesion.UsuarioPatente.Count - 1
            Select Case Principal.UsuarioEnSesion.UsuarioPatente(x).id_patente
                Case 5
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoAlta = True
                        tieneAcceso = True
                    End If
                Case 6
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoModif = True
                        tieneAcceso = True
                    End If
                Case 7
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoElim = True
                        tieneAcceso = True
                    End If
                Case 8
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
                Case 5
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoAlta = True
                        tieneAcceso = True
                    End If
                Case 6
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoModif = True
                        tieneAcceso = True
                    End If
                Case 7
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoElim = True
                        tieneAcceso = True
                    End If
                Case 8
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoRehab = True
                        tieneAcceso = True
                    End If
            End Select
        Next
        Return tieneAcceso
    End Function
#End Region

End Class