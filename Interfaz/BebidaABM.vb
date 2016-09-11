Imports Negocio.Negocio.Bebida

Public Class BebidaABM

#Region "Eventos Form"
    Private Sub BebidaABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized

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
                .Add("cid", "Codigo")
                .Item(0).DataPropertyName = "id" 'nombre del dto
                '.Item(0).Width = 100
                .Item(0).Visible = False
                '
                .Add("cdescripcioncorta", "Nombre")
                .Item(1).DataPropertyName = "DescripcionCorta"
                .Item(1).Width = 100

                .Add("cdescripcionlarga", "Descripcion")
                .Item(2).DataPropertyName = "DescripcionLarga"
                .Item(2).Width = 100

                .Add("chabilitado", "En Carta")
                .Item(3).DataPropertyName = "habilitado"
                .Item(3).Width = 100

                .Add("cfechaBaja", "Fecha Baja")
                .Item(4).DataPropertyName = "fechaBaja"
                .Item(4).Width = 100

                .Add("cfechaModif", "Fecha Modif")
                .Item(5).DataPropertyName = "fechaModif"
                .Item(5).Width = 100

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

    End Sub
#End Region

#Region "Métodos"

    Friend Sub ActualizarGrilla()
        Me.dgvBebidas.DataSource = (New Negocio.Negocio.Bebida).Listar
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mForm As New Bebida
        mForm.mOperacion = Bebida.TipoOperacion.Baja
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
        '  msgMensaje.Show()
        ' msgMensaje.Text = "Eliminar"
        'msgMensaje.Label1.Text = "Usted se encuentra seguro que desea dar de baja la  Bebida seleccionada?"
    End Sub

    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        msgMensaje.Show()
        msgMensaje.Text = "Rehabilitar"
        msgMensaje.Label1.Text = "Usted se encuentra seguro que desea rehabilitar la bebida seleccionado?"
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
                mForm.BebidaAEditar = New Negocio.Negocio.Bebida()
                mForm.StartPosition = FormStartPosition.CenterParent
                mForm.ShowDialog(Me)
                ActualizarGrilla()

            Catch ex As InvalidCastException
                MsgBox("Error al establecer el identificador el propietario seleccionado.")
            Catch ex As Exception
                MsgBox("Error al intentar modificar el propietario seleccionado.")
            End Try

        End If


    End Sub

    Private Sub dgvBebidas_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBebidas.SelectionChanged
        If Me.dgvBebidas.SelectedRows.Count > 0 Then
            Me.btnModificar.Enabled = True
            Me.btnNuevo.Enabled = True
            'Se evalua la fecha de baja, si esta vacio, (No se cargo el dto)
            If Me.dgvBebidas.SelectedRows(0).Cells(4).Value Is Nothing Then
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