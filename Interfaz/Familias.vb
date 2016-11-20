Imports Negocio.Negocio
Imports System.DateTime


Public Class Familias

    Dim mFamilia As Negocio.Negocio.Familia

    Friend mOperacion As TipoOperacion
    Friend Enum TipoOperacion
        Alta = 1
        Baja = 2
        Modificacion = 3
        Rehabilitar = 4
    End Enum

    Friend Property FamiliaAEditar() As Negocio.Negocio.Familia
        Get
            Return mFamilia
        End Get
        Set(ByVal value As Negocio.Negocio.Familia)
            mFamilia = value
        End Set
    End Property
#Region "Eventos Form"
    Private Sub Familia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtId_familia.Enabled = False
        Me.txtFecha_baja.Enabled = False
        Me.lblFechaBaja.Enabled = False

        Me.txtId_familia.Visible = False
        Me.txtFecha_baja.Visible = False
        Me.lblFechaBaja.Visible = False

        'Seteo de aspecto de la grilla 
        With Me.dgvFamiliaPatentes
            .AllowDrop = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            With .Columns
                .Add("cId", "id_familia")
                .Item(0).DataPropertyName = "Id_familia"
                .Item(0).Visible = False

                .Add("cid_familia", "id_patente")
                .Item(1).DataPropertyName = "id_patente"
                .Item(1).Width = 125
                .Item(1).Visible = False

                .Add("cDescripcion", "Descripcion")
                .Item(2).DataPropertyName = "Descripcion"
                .Item(2).Width = 150
                .Item(2).Visible = True

                .Add("cdvh", "dvh")
                .Item(3).DataPropertyName = "dvh"
                .Item(3).Width = 125
                .Item(3).Visible = False

                .Add("cEstadoColeccion", "EstadoColeccion")
                .Item(4).DataPropertyName = "EstadoColeccion"
                .Item(4).Visible = False

                .Add("cIndiceColeccion", "IndiceColeccion")
                .Item(5).DataPropertyName = "IndiceColeccion"
                .Item(5).Visible = False

                .Add("cM_negada", "M_negada")
                .Item(6).DataPropertyName = "M_negada"
                .Item(6).Visible = True
            End With
        End With
        Select Case mOperacion
            Case TipoOperacion.Alta

                Me.txtDescripcion_corta.Text = ""
                Me.txtDescripcion_larga.Text = ""
                Me.txtFecha_baja.Text = ""
                Me.lblTitulo.Text = "Alta de Familia"

            Case TipoOperacion.Baja

                If Not IsNothing(mFamilia) Then
                    Me.txtDescripcion_corta.Text = mFamilia.descripcionCorta
                    Me.txtDescripcion_larga.Text = mFamilia.descripcionLarga
                    Me.txtFecha_baja.Text = mFamilia.fechaBaja

                    Me.lblTitulo.Text = "¿Esta seguro que desea dar de baja esta Familia?"
                    Me.btnGuardar.Text = "Eliminar"
                    Me.btnGuardar.BackColor = Color.Firebrick
                    Me.btnGuardar.ForeColor = Color.AntiqueWhite
                End If

            Case TipoOperacion.Modificacion

                If Not IsNothing(mFamilia) Then
                    Me.txtId_familia.Text = mFamilia.id
                    Me.txtDescripcion_corta.Text = mFamilia.descripcionCorta
                    Me.txtDescripcion_larga.Text = mFamilia.descripcionLarga
                    If Not IsNothing(mFamilia.fechaBaja) Then
                        Me.txtFecha_baja.Text = mFamilia.fechaBaja
                    End If
                    Me.lblTitulo.Text = "Modificación de Familia"
                End If
                ActualizarGrilla()
        End Select
        ActualizarBotones()
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf Ayuda

        ToolTip()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Select Case mOperacion
                Case TipoOperacion.Alta, TipoOperacion.Modificacion
                    If IsNothing(mFamilia) Then
                        mFamilia = New Negocio.Negocio.Familia
                    End If

                    mFamilia.descripcionCorta = Me.txtDescripcion_corta.Text
                    mFamilia.descripcionLarga = Me.txtDescripcion_larga.Text
                    mFamilia.idUsuario = Principal.UsuarioEnSesion.id
                    mFamilia.ValidarFormato(Principal.UsuarioEnSesion.id_idioma)
                    mFamilia.Guardar()
                    Me.Close()

                    If mOperacion = TipoOperacion.Alta Then
                        MsgBox(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Familia registrada correctamente."))
                    Else
                        MsgBox(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Familia modificada correctamente."))
                    End If
            End Select
        Catch ex As InvalidCastException
            MsgBox("Error al establecer el identificador del usuario seleccionado.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub ActualizarGrilla()
        dgvFamiliaPatentes.DataSource = mFamilia.FamiliaPatente
        If dgvFamiliaPatentes.Rows.Count > 0 Then
            For i As Integer = 0 To dgvFamiliaPatentes.Rows.Count - 1
                Dim mPatente As New Negocio.Negocio.Patente
                mPatente.Cargar(CInt(dgvFamiliaPatentes.Rows(i).Cells(1).Value))
                dgvFamiliaPatentes.Rows(i).Cells(2).Value = mPatente.descripcionCorta
            Next
        End If
    End Sub
    Private Sub ActualizarBotones()
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        If mOperacion = TipoOperacion.Modificacion Then
            btnAgregar.Enabled = True
            btnEliminar.Enabled = True
        End If
    End Sub
#End Region
#Region "Patentes"
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim mForm As New AsocFamiliaPatente
        mForm.Operacion = AsocFamiliaPatente.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvFamiliaPatentes.Rows.Count > 0 AndAlso Me.dgvFamiliaPatentes.SelectedRows.Count = 1 Then
            Dim mIndice As Integer = CInt(dgvFamiliaPatentes.SelectedRows(0).Cells(5).Value)
            Dim mForm As New AsocFamiliaPatente
            mForm.Operacion = AsocFamiliaPatente.TipoOperacion.Baja

            mForm.FamiliaPatenteAEditar = mFamilia.ObtenerFamiliaPatentePorIndice(mIndice)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            ActualizarGrilla()
        End If
    End Sub

    Sub ToolTip()
        ToolTip1.SetToolTip(btnAgregar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Agregar una patente."))
        ToolTip1.SetToolTip(btnEliminar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Eliminar una patente"))
        ToolTip1.SetToolTip(btnGuardar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Guardar los cambios realizados."))
        ToolTip1.SetToolTip(btnCancelar, Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Presione para Cancelar los cambios realizados."))
    End Sub

    Private Sub Ayuda(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            Dim mForm As New msgMensaje
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.TextBox1.Text = Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Este formulario permitirá administrar las familias.") & Environment.NewLine &
                                 Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Podrá generar una nueva familia, modificarla, agregarle y quitarle patentes.")
            mForm.ShowDialog(Me)
        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
#End Region

End Class