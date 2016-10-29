
Imports Negocio.Negocio.Usuario

Public Class UsuarioABM

#Region "Eventos Form"
    Private Sub UsuarioABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                .Item(7).Visible = False

                .Add("cNombreUsuario", "Usuario Alta/Modif")
                .Item(8).DataPropertyName = "Nombre Usuario"
                .Item(8).Width = 150
                .Item(8).Visible = True
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
        Try
            Me.dgv_Usuarios.DataSource = (New Negocio.Negocio.Usuario).Listar
            If Me.dgv_Usuarios.RowCount = 0 Then
                Me.txtMensaje.Text = Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen Usuarios ingresadas en el sistema")
            Else
                Me.txtMensaje.Text = ""
            End If
            If dgv_Usuarios.Rows.Count > 0 Then
                For i As Integer = 0 To dgv_Usuarios.Rows.Count - 1
                    Dim mUsuario As New Negocio.Negocio.Usuario
                    mUsuario.Cargar(CInt(dgv_Usuarios.Rows(i).Cells(7).Value))
                    dgv_Usuarios.Rows(i).Cells(8).Value = mUsuario.usuario
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.message)
            Throw
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mId As Integer = CInt(Me.dgv_Usuarios.SelectedRows(0).Cells(0).Value)
        Dim Usuario As New Negocio.Negocio.Usuario(mId)
        Dim result As Integer = MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea dar de baja el usuario seleccionado?"), "Eliminar", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Usuario.Eliminar()
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Usuario dado de baja correctamente."))
        End If
        ActualizarGrilla()
    End Sub


    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        Dim mId As Integer = CInt(Me.dgv_Usuarios.SelectedRows(0).Cells(0).Value)
        Dim Usuario As New Negocio.Negocio.Usuario(mId)
        Dim result As Integer = MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea rehabilitar el usuario seleccionado?"), "Rehabilitar", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Usuario.Rehabilitar()
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Usuario rehabilitado correctamente."))
        End If

        ActualizarGrilla()
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim mForm As New Usuarios
        mForm.mOperacion = Interfaz.Usuarios.TipoOperacion.Alta
        mForm.UsuarioAEditar = New Negocio.Negocio.Usuario
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
            If IsNothing(Me.dgv_Usuarios.SelectedRows(0).Cells(5).Value) Then
                Me.btnEliminar.Enabled = True
                Me.btnModificar.Enabled = True
                Me.btnRehabilitar.Enabled = False
            Else
                Me.btnRehabilitar.Enabled = True
                Me.btnModificar.Enabled = False
                Me.btnEliminar.Enabled = False
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

