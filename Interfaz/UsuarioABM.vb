
Imports Negocio.Negocio.Usuario

Public Class UsuarioABM

#Region "Eventos Form"
    Private Sub UsuarioABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized

        'Seteo de aspecto de la grilla
        With Me.dgv_Usuarios
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

                .Add("cUsuario", "Usuario")
                .Item(1).DataPropertyName = "Usuario"
                .Item(1).Width = 100

                .Add("cdescripcioncorta", "Nombre")
                .Item(2).DataPropertyName = "nombre"
                .Item(2).Width = 100

                .Add("cdescripcionlarga", "Apellido")
                .Item(3).DataPropertyName = "Apellido"
                .Item(3).Width = 100

                .Add("cdni", "dni")
                .Item(4).DataPropertyName = "dni"
                .Item(4).Width = 100

                .Add("cfechaBaja", "Fecha de baja")
                .Item(5).DataPropertyName = "fechaBaja"
                .Item(5).Width = 100
                .Item(5).DefaultCellStyle.Format = "dd/MM/yyyy"

                .Add("cfechaModif", "Fecha de modificación")
                .Item(6).DataPropertyName = "fechaModif"
                .Item(6).Width = 100
                .Item(6).DefaultCellStyle.Format = "dd/MM/yyyy"

                .Add("cidUsuario", "Usuario Alta/Modif")
                .Item(7).DataPropertyName = "idUsuarioAlta"
                .Item(7).Width = 100

            End With

        End With

        'Seteo de elementos de interfaz
        Me.btnEliminar.Enabled = False
        Me.btnModificar.Enabled = False
        Me.btnNuevo.Enabled = True
        Me.btnRehabilitar.Enabled = False

        'Método de carga de datos en la grilla
        ActualizarGrilla()

        Me.dgv_Usuarios.ClearSelection()

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

    End Sub
#End Region

#Region "Métodos"

    Friend Sub ActualizarGrilla()
        Me.dgv_Usuarios.DataSource = (New Negocio.Negocio.Usuario).Listar
        If Me.dgv_Usuarios.RowCount = 0 Then
            Me.txtMensaje.Text = "No existen Usuarios ingresados en el sistema"
            Me.txtMensaje.Text = Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen Bebidas ingresadas en el sistema")

        Else
            Me.txtMensaje.Text = ""
            End If
        End Sub
        Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mId As Integer = CInt(Me.dgv_Usuarios.SelectedRows(0).Cells(0).Value)
        Dim Usuario As New Negocio.Negocio.Usuario(mId)
        'Traducir Celeste
        Dim result As Integer = MessageBox.Show("¿Usted se encuentra seguro que desea dar de baja el usuario seleccionado?", "Eliminar", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Usuario.Eliminar()
            'Traducir Celeste
            MessageBox.Show("Usuario dado de baja correctamente.")
        End If
            ActualizarGrilla()
        End Sub

        Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        Dim mId As Integer = CInt(Me.dgv_Usuarios.SelectedRows(0).Cells(0).Value)
        Dim Usuario As New Negocio.Negocio.Usuario(mId)
        Dim result As Integer = MessageBox.Show("¿Usted se encuentra seguro que desea rehabilitar el usuario seleccionado?", "Rehabilitar", MessageBoxButtons.YesNo)
        'Traducir Celeste
        If result = DialogResult.Yes Then
            Usuario.Rehabilitar()
            'Traducir Celeste
            MessageBox.Show("Usuario rehabilitado correctamente.")
        End If

            ActualizarGrilla()
        End Sub

        Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim mForm As New Usuarios
        mForm.mOperacion = Interfaz.Usuarios.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        If Me.dgv_Usuarios.SelectedRows.Count > 0 Then
            Try
                Dim mId As Integer = CInt(Me.dgv_Usuarios.SelectedRows(0).Cells(0).Value)

                Dim mForm As New Usuarios
                mForm.mOperacion = Interfaz.Usuarios.TipoOperacion.Modificacion
                mForm.UsuarioAEditar = New Negocio.Negocio.Usuario(mId)
                mForm.StartPosition = FormStartPosition.CenterParent
                mForm.ShowDialog(Me)

                ActualizarGrilla()
            Catch ex As InvalidCastException
                MsgBox("Error al establecer el identificador del usuario seleccionado.")
            Catch ex As Exception
                MsgBox("Error al intentar modificar el usuario seleccionado.")
            End Try

        End If


    End Sub

    Private Sub dgv_Usuarios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Usuarios.SelectionChanged
        If Me.dgv_Usuarios.SelectedRows.Count > 0 Then
            Me.btnModificar.Enabled = True
            Me.btnNuevo.Enabled = True
            'Se evalua la fecha de baja, si esta vacio, (No se cargo el dto)
            If IsNothing(Me.dgv_Usuarios.SelectedRows(0).Cells(4).Value) Then
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
    ' Private Sub UsuarioABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'     Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
'End Sub

'End Class
