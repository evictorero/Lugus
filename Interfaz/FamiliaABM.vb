Imports Negocio.Negocio.Familia
Imports Negocio.Negocio.Traductor

Public Class FamiliaABM

#Region "Eventos Form"
    Private Sub FamiliaABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized

        'Seteo de aspecto de la grilla
        With Me.dgvFamilias
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

                .Add("cfechaBaja", "Fecha de baja")
                .Item(3).DataPropertyName = "fechaBaja"
                .Item(3).Width = 100
                .Item(3).DefaultCellStyle.Format = "dd/MM/yyyy"

                .Add("cfechaModif", "Fecha de modificación")
                .Item(4).DataPropertyName = "fechaModif"
                .Item(4).Width = 100
                .Item(4).DefaultCellStyle.Format = "dd/MM/yyyy"

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

        Me.dgvFamilias.ClearSelection()

        TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

    End Sub
#End Region

#Region "Métodos"

    Friend Sub ActualizarGrilla()
        Me.dgvFamilias.DataSource = (New Negocio.Negocio.Familia).Listar
        If Me.dgvFamilias.RowCount = 0 Then
            Me.txtMensaje.Text = ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen familias ingresadas en el sistema")
        Else
            Me.txtMensaje.Text = ""
        End If
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mId As Integer = CInt(Me.dgvFamilias.SelectedRows(0).Cells(0).Value)
        Dim Familia As New Negocio.Negocio.Familia(mId)
        'Traducir Celeste
        Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea dar de baja la Familia seleccionada?"),
                                                ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Eliminar"),
                                                MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Familia.Eliminar()
            'Traducir Celeste
            MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Familia eliminada correctamente"))
        End If
        ActualizarGrilla()
    End Sub

    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        Dim mId As Integer = CInt(Me.dgvFamilias.SelectedRows(0).Cells(0).Value)
        Dim Familia As New Negocio.Negocio.Familia(mId)
        Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea rehabilitar la Familia seleccionada?"),
                                                ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Rehabilitar"),
                                                MessageBoxButtons.YesNo)
        'Traducir Celeste
        If result = DialogResult.Yes Then
            Familia.Rehabilitar()
            'Traducir Celeste
            MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Familia rehabilitada correctamente"))
        End If

        ActualizarGrilla()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim mForm As New Familia
        mForm.mOperacion = Familia.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        If Me.dgvFamilias.SelectedRows.Count > 0 Then
            Try
                Dim mId As Integer = CInt(Me.dgvFamilias.SelectedRows(0).Cells(0).Value)

                Dim mForm As New Familia
                mForm.mOperacion = Familia.TipoOperacion.Modificacion
                mForm.FamiliaAEditar = New Negocio.Negocio.Familia(mId)
                mForm.StartPosition = FormStartPosition.CenterParent
                mForm.ShowDialog(Me)

                ActualizarGrilla()
            Catch ex As Exception
                MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Error al intentar modificar la Familia seleccionada"))
            End Try

        End If


    End Sub

    Private Sub dgvFamilias_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFamilias.SelectionChanged
        If Me.dgvFamilias.SelectedRows.Count > 0 Then
            Me.btnModificar.Enabled = True
            Me.btnNuevo.Enabled = True
            'Se evalua la fecha de baja, si esta vacio, (No se cargo el dto)
            If IsNothing(Me.dgvFamilias.SelectedRows(0).Cells(4).Value) Then
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