Imports Negocio.Negocio.Plato
Imports Negocio.Negocio.Traductor

Public Class PlatosABM

#Region "Eventos Form"
    Private Sub PlatoABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized

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

        Me.dgvPlatos.ClearSelection()

        TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

    End Sub
#End Region

#Region "Métodos"

    Friend Sub ActualizarGrilla()
        Me.dgvPlatos.DataSource = (New Negocio.Negocio.Plato).Listar
        If Me.dgvPlatos.RowCount = 0 Then
            Me.txtMensaje.Text = ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen Platos ingresadas en el sistema")
        Else
            Me.txtMensaje.Text = ""
        End If
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mId As Integer = CInt(Me.dgvPlatos.SelectedRows(0).Cells(0).Value)
        Dim bebida As New Negocio.Negocio.Plato(mId)
        'Traducir Celeste
        Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea dar de baja la Plato seleccionada?"),
                                                ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Eliminar"),
                                                MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            bebida.Eliminar()
            'Traducir Celeste
            MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Plato eliminada correctamente"))
        End If
        ActualizarGrilla()
    End Sub

    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        Dim mId As Integer = CInt(Me.dgvPlatos.SelectedRows(0).Cells(0).Value)
        Dim bebida As New Negocio.Negocio.Plato(mId)
        Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea rehabilitar la Plato seleccionada?"),
                                                ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Rehabilitar"),
                                                MessageBoxButtons.YesNo)
        'Traducir Celeste
        If result = DialogResult.Yes Then
            bebida.Rehabilitar()
            'Traducir Celeste
            MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Plato rehabilitada correctamente"))
        End If

        ActualizarGrilla()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim mForm As New Platos
        mForm.mOperacion = Platos.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        If Me.dgvPlatos.SelectedRows.Count > 0 Then
            Try
                Dim mId As Integer = CInt(Me.dgvPlatos.SelectedRows(0).Cells(0).Value)

                Dim mForm As New Platos
                mForm.mOperacion = Platos.TipoOperacion.Modificacion
                mForm.PlatosAEditar = New Negocio.Negocio.Plato(mId)
                mForm.StartPosition = FormStartPosition.CenterParent
                mForm.ShowDialog(Me)

                ActualizarGrilla()
            Catch ex As Exception
                MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Error al intentar modificar la bebida seleccionada"))
            End Try

        End If


    End Sub

    Private Sub dgvPlatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPlatos.SelectionChanged
        If Me.dgvPlatos.SelectedRows.Count > 0 Then
            Me.btnModificar.Enabled = True
            Me.btnNuevo.Enabled = True
            'Se evalua la fecha de baja, si esta vacio, (No se cargo el dto)
            If IsNothing(Me.dgvPlatos.SelectedRows(0).Cells(4).Value) Then
                Me.btnEliminar.Enabled = True
            Else
                Me.btnRehabilitar.Enabled = True
            End If
        Else
            Me.btnEliminar.Enabled = False
            Me.btnModificar.Enabled = False
            Me.btnNuevo.Enabled = True
            Me.btnRehabilitar.Enabled = False
        End If
    End Sub

#End Region

End Class