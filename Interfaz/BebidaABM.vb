﻿Imports Negocio.Negocio.Bebida

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

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

    End Sub
#End Region

#Region "Métodos"

    Friend Sub ActualizarGrilla()
        Me.dgvBebidas.DataSource = (New Negocio.Negocio.Bebida).Listar
        If Me.dgvBebidas.RowCount = 0 Then
            Me.txtMensaje.Text = "No existen Bebidas ingresadas en el sistema"
            Me.txtMensaje.Text = Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen Bebidas ingresadas en el sistema")

        Else
            Me.txtMensaje.Text = ""
        End If
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mId As Integer = CInt(Me.dgvBebidas.SelectedRows(0).Cells(0).Value)
        Dim bebida As New Negocio.Negocio.Bebida(mId)
        'Traducir Celeste
        Dim result As Integer = MessageBox.Show("¿Usted se encuentra seguro que desea dar de baja la Bebida seleccionada?", "Eliminar", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            bebida.Eliminar()
            'Traducir Celeste
            MessageBox.Show("Bebida eliminada correctamente.")
        End If
        ActualizarGrilla()
    End Sub

    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        Dim mId As Integer = CInt(Me.dgvBebidas.SelectedRows(0).Cells(0).Value)
        Dim bebida As New Negocio.Negocio.Bebida(mId)
        Dim result As Integer = MessageBox.Show("¿Usted se encuentra seguro que desea rehabilitar la Bebida seleccionada?", "Rehabilitar", MessageBoxButtons.YesNo)
        'Traducir Celeste
        If result = DialogResult.Yes Then
            bebida.Rehabilitar()
            'Traducir Celeste
            MessageBox.Show("Bebida rehabilitada correctamente.")
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
            Catch ex As InvalidCastException
                MsgBox("Error al establecer el identificador la bebida seleccionada.")
            Catch ex As Exception
                MsgBox("Error al intentar modificar la bebida seleccionada.")
            End Try

        End If


    End Sub

    Private Sub dgvBebidas_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBebidas.SelectionChanged
        If Me.dgvBebidas.SelectedRows.Count > 0 Then
            Me.btnModificar.Enabled = True
            Me.btnNuevo.Enabled = True
            'Se evalua la fecha de baja, si esta vacio, (No se cargo el dto)
            If IsNothing(Me.dgvBebidas.SelectedRows(0).Cells(4).Value) Then
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