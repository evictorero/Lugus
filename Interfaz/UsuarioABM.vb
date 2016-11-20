Imports Negocio.Negocio.Usuario
Imports Negocio.Negocio.UsuarioPatente

Public Class UsuarioABM

    Dim TieneAccesoAlta As Boolean = False
    Dim TieneAccesoModif As Boolean = False
    Dim TieneAccesoElim As Boolean = False
    Dim TieneAccesoRehab As Boolean = False

#Region "Eventos Form"
    Private Sub UsuarioABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TienePermisoAcceso() = True Then
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

                    .Add("cdni", "DNI")
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
        Else
            Me.Close()
            MsgBox("Acceso Restringido")
        End If

        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf Ayuda

        ToolTip()
    End Sub
#End Region

#Region "Métodos"

    Friend Sub ActualizarGrilla()
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
        'Dim CadenaDigitoVerificador As String
        'If dgv_Usuarios.Rows.Count > 0 Then
        '    For i As Integer = 0 To dgv_Usuarios.Rows.Count - 1
        '        Dim mUSuario As New Negocio.Negocio.Usuario
        '        mUSuario.Cargar(CInt(dgv_Usuarios.Rows(i).Cells(0).Value))
        '        CadenaDigitoVerificador = mUSuario.usuario + mUSuario.nombre + mUSuario.apellido + Convert.ToString(mUSuario.fechaModif)
        '        mUSuario.dvh = Negocio.Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)
        '        mUSuario.Guardar()
        '    Next
        'End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mId As Integer = CInt(Me.dgv_Usuarios.SelectedRows(0).Cells(0).Value)
        Dim Usuario As New Negocio.Negocio.Usuario(mId)
        If SePuedeEliminar(mId) Then
            Dim result As Integer = MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea dar de baja el usuario seleccionado?"), "Eliminar", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Usuario.Eliminar()
                MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Usuario dado de baja correctamente."))
            End If

            ActualizarGrilla()
        Else
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "El usuario no puede eliminarse debido a que posee una familia/patente esencial."))
        End If

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
            Dim mId As Integer = CInt(Me.dgv_Usuarios.SelectedRows(0).Cells(0).Value)
            Dim mForm As New Usuarios
            mForm.mOperacion = Interfaz.Usuarios.TipoOperacion.Modificacion
            mForm.UsuarioAEditar = New Negocio.Negocio.Usuario(mId)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Private Sub dgv_Usuarios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Usuarios.SelectionChanged
        Me.btnEliminar.Enabled = False
        Me.btnModificar.Enabled = False
        Me.btnNuevo.Enabled = False
        Me.btnRehabilitar.Enabled = False
        Me.btnBlanquear.Enabled = False

        If Me.dgv_Usuarios.SelectedRows.Count > 0 Then
            'Se evalua la fecha de baja, si esta vacio, (No se cargo el dto)
            If IsNothing(Me.dgv_Usuarios.SelectedRows(0).Cells(5).Value) Then
                If TieneAccesoElim Then
                    Me.btnEliminar.Enabled = True
                End If
                If TieneAccesoModif Then
                    Me.btnModificar.Enabled = True
                    Me.btnBlanquear.Enabled = True
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

    Private Sub btnBlanquear_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Dim mId As Integer = CInt(Me.dgv_Usuarios.SelectedRows(0).Cells(0).Value)
        Dim Usuario As New Negocio.Negocio.Usuario(mId)
        Dim result As Integer = MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea blanquear la clave del usuario seleccionado?"), "Blanqueo de Clave", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Usuario.Blanquear()
            MessageBox.Show(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "El blanqueo de clave ha sido exitoso."))
        End If
        ActualizarGrilla()
    End Sub

    Public Function TienePermisoAcceso() As Boolean
        'Patentes 18 19 20 21
        Dim tieneAcceso As Boolean = False
        For x As Integer = 0 To Principal.UsuarioEnSesion.UsuarioPatente.Count - 1
            Select Case Principal.UsuarioEnSesion.UsuarioPatente(x).id_patente
                Case 18
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoAlta = True
                        tieneAcceso = True
                    End If

                Case 19
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoModif = True
                        tieneAcceso = True
                    End If

                Case 20
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoElim = True
                        tieneAcceso = True
                    End If

                Case 21
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
                Case 18
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoAlta = True
                        tieneAcceso = True
                    End If

                Case 19
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoModif = True
                        tieneAcceso = True
                    End If

                Case 20
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoElim = True
                        tieneAcceso = True
                    End If
                Case 21
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoRehab = True
                        tieneAcceso = True
                    End If
            End Select
        Next
        Return tieneAcceso
    End Function

    Public Function SePuedeEliminar(ByVal pId As Integer) As Boolean
        Dim pUsuario As New Negocio.Negocio.Usuario(pId)
        If pUsuario.UsuarioPatente.Count > 0 Then
            For x As Integer = 0 To pUsuario.UsuarioPatente.Count - 1
                If Negocio.Negocio.UsuarioPatente.EsPatenteEsencial(pId, pUsuario.UsuarioPatente(x).id_patente) Then
                    Return False
                End If
            Next
        End If

        If pUsuario.UsuarioFamilia.Count > 0 Then
            Dim mListaPatentesDeFamiliaporUsuario As New List(Of Negocio.Negocio.UsuarioPatente)
            mListaPatentesDeFamiliaporUsuario = pUsuario.ListarPatentesDeFamiliaPorUsuario
            For x As Integer = 0 To mListaPatentesDeFamiliaporUsuario.Count - 1
                If Negocio.Negocio.UsuarioFamilia.EsFamiliaPatenteEsencial(pId, pUsuario.UsuarioPatente(x).id_patente) Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Sub ToolTip()
        ToolTip1.SetToolTip(btnNuevo, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Crear un usuario nuevo."))
        ToolTip2.SetToolTip(btnModificar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Modificar un usuario."))
        ToolTip3.SetToolTip(btnEliminar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Dar de baja un usuario."))
        ToolTip4.SetToolTip(btnRehabilitar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Rehabilitar un usuario."))
        ToolTip5.SetToolTip(btnBlanquear, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para blanquear clave de usuario e intentos inválidos."))
    End Sub

    Private Sub Ayuda(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            Dim mForm As New msgMensaje
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.TextBox1.Text = Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Este formulario permitirá administrar los usuarios.") & Environment.NewLine &
                                Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Los botones se habilitarán según los permisos asignados.") & Environment.NewLine &
                                 Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Podrá generar un nuevo usuario, modificarlo, eliminarlo, rehabilitarlo y blanquear su clave.")
            mForm.ShowDialog(Me)
        End If
    End Sub

#End Region

End Class

