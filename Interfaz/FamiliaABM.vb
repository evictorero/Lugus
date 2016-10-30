Imports Negocio.Negocio.Familia
Imports Negocio.Negocio.Traductor

Public Class FamiliaABM

#Region "Eventos Form"
    Private Sub FamiliaABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                .Item(0).Visible = False
                '
                .Add("cdescripcioncorta", "Nombre")
                .Item(1).DataPropertyName = "DescripcionCorta"
                .Item(1).Width = 150

                .Add("cdescripcionlarga", "Descripción")
                .Item(2).DataPropertyName = "DescripcionLarga"
                .Item(2).Width = 200

                .Add("cfechaBaja", "Fecha de baja")
                .Item(3).DataPropertyName = "fechaBaja"
                .Item(3).Width = 80
                .Item(3).DefaultCellStyle.Format = "dd/MM/yyyy"

                .Add("cfechaModif", "Fecha de modificación")
                .Item(4).DataPropertyName = "fechaModif"
                .Item(4).Width = 80
                .Item(4).DefaultCellStyle.Format = "dd/MM/yyyy"

                .Add("cidUsuario", "Usuario Alta/Modif")
                .Item(5).DataPropertyName = "idUsuario"
                .Item(5).Width = 100
                .Item(5).Visible = False

                .Add("cNombreUsuario", "Usuario Alta/Modif")
                .Item(6).DataPropertyName = "Nombre Usuario"
                .Item(6).Width = 100
                .Item(6).Visible = True
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
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim mId As Integer = CInt(Me.dgvFamilias.SelectedRows(0).Cells(0).Value)
            Dim Familia As New Negocio.Negocio.Familia(mId)
            Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea dar de baja la Familia seleccionada?"),
                                            ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Eliminar"),
                                            MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Familia.Eliminar()
                MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Familia eliminada correctamente"))
            End If
            ActualizarGrilla()
        Catch ex As Exception
            MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, ex.Message))
        End Try
    End Sub
    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        Try
            Dim mId As Integer = CInt(Me.dgvFamilias.SelectedRows(0).Cells(0).Value)
            Dim Familia As New Negocio.Negocio.Familia(mId)
            Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea rehabilitar la Familia seleccionada?"),
                                                ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Rehabilitar"),
                                                MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Familia.Rehabilitar()
                MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Familia rehabilitada correctamente"))
            End If

            ActualizarGrilla()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim mForm As New Familias
        mForm.mOperacion = Familias.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Me.dgvFamilias.SelectedRows.Count > 0 Then
                Dim mId As Integer = CInt(Me.dgvFamilias.SelectedRows(0).Cells(0).Value)

                Dim mForm As New Familias
                mForm.mOperacion = Familias.TipoOperacion.Modificacion
                mForm.FamiliaAEditar = New Negocio.Negocio.Familia(mId)
                mForm.StartPosition = FormStartPosition.CenterParent
                mForm.ShowDialog(Me)
                ActualizarGrilla()
            End If
        Catch ex As Exception
            MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, ex.Message))
        End Try


    End Sub
    Private Sub dgvFamilias_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFamilias.SelectionChanged
        If Me.dgvFamilias.SelectedRows.Count > 0 Then
            Me.btnModificar.Enabled = True
            Me.btnNuevo.Enabled = True
            'Se evalua la fecha de baja, si esta vacio, (No se cargo el dto)
            If IsNothing(Me.dgvFamilias.SelectedRows(0).Cells(3).Value) Then
                Me.btnEliminar.Enabled = True
                Me.btnModificar.Enabled = True
                Me.btnRehabilitar.Enabled = False
            Else
                Me.btnRehabilitar.Enabled = True
                Me.btnEliminar.Enabled = False
                Me.btnModificar.Enabled = False
            End If
        Else
            Me.btnEliminar.Enabled = False
            Me.btnModificar.Enabled = False
            Me.btnNuevo.Enabled = True
            Me.btnRehabilitar.Enabled = False
        End If

    End Sub
#End Region

#Region "Métodos"
    Friend Sub ActualizarGrilla()
        Me.dgvFamilias.DataSource = (New Negocio.Negocio.Familia).Listar
        If Me.dgvFamilias.RowCount = 0 Then
            Me.txtMensaje.Text = ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen familias ingresadas en el sistema")
        End If
        If dgvFamilias.Rows.Count > 0 Then
            For i As Integer = 0 To dgvFamilias.Rows.Count - 1
                Dim mUsuario As New Negocio.Negocio.Usuario
                mUsuario.Cargar(CInt(dgvFamilias.Rows(i).Cells(5).Value))
                dgvFamilias.Rows(i).Cells(6).Value = mUsuario.usuario
            Next
        End If

        'Dim CadenaDigitoVerificador As String
        'If dgvFamilias.Rows.Count > 0 Then
        '    For i As Integer = 0 To dgvFamilias.Rows.Count - 1
        '        Dim mFamilia As New Negocio.Negocio.Familia
        '        mFamilia.Cargar(CInt(dgvFamilias.Rows(i).Cells(0).Value))
        '        CadenaDigitoVerificador = mFamilia.descripcionCorta + mFamilia.descripcionLarga + Convert.ToString(mFamilia.fechaModif)
        '        mFamilia.dvh = Negocio.Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)
        '        mFamilia.Guardar()
        '    Next
        'End If
    End Sub
#End Region

End Class