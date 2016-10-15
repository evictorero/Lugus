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

    Private Sub Familia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtId_familia.Enabled = False
        Me.txtFecha_baja.Enabled = False

        'Seteo de aspecto de la grilla AMBIENTES
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

                .Add("cdvh", "dvh")
                .Item(2).DataPropertyName = "dvh"
                .Item(2).Width = 125

                .Add("cEstadoColeccion", "EstadoColeccion")
                .Item(3).DataPropertyName = "EstadoColeccion"
                .Item(3).Visible = True

                .Add("cIndiceColeccion", "IndiceColeccion")
                .Item(4).DataPropertyName = "IndiceColeccion"
                .Item(4).Visible = True

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
                dgvFamiliaPatentes.DataSource = mFamilia.FamiliaPatente

            Case TipoOperacion.Rehabilitar

                Me.txtId_familia.Text = mFamilia.id
                Me.txtId_familia.Enabled = False

                Me.txtDescripcion_corta.Text = mFamilia.descripcionCorta
                Me.txtDescripcion_corta.Enabled = False
                Me.txtDescripcion_larga.Text = mFamilia.descripcionLarga
                Me.txtDescripcion_larga.Enabled = False
                Me.lblTitulo.Text = "Rehabilitar Familia"
                Me.btnGuardar.Visible = False
        End Select

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Select Case mOperacion
            Case TipoOperacion.Alta, TipoOperacion.Modificacion
                If IsNothing(mFamilia) Then
                    mFamilia = New Negocio.Negocio.Familia
                End If

                mFamilia.descripcionCorta = Me.txtDescripcion_corta.Text
                mFamilia.descripcionLarga = Me.txtDescripcion_larga.Text
                mFamilia.idUsuario = Principal.UsuarioEnSesion.id
                mFamilia.dvh = 1 'Digito Verificador Celes
                mFamilia.ValidarFormato(Principal.UsuarioEnSesion.id_idioma)
                mFamilia.Guardar()
                Me.Close()
            Case TipoOperacion.Baja
                mFamilia.Eliminar()
                Me.Close()
        End Select
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub


#Region "Patentes"
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim mForm As New AsocFamiliaPatente
        mForm.Operacion = AsocFamiliaPatente.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        dgvFamiliaPatentes.DataSource = mFamilia.FamiliaPatente
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvFamiliaPatentes.Rows.Count > 0 AndAlso Me.dgvFamiliaPatentes.SelectedRows.Count = 1 Then
            Dim mIndice As Integer = CInt(dgvFamiliaPatentes.SelectedRows(0).Cells(4).Value)
            Dim mForm As New AsocFamiliaPatente
            mForm.Operacion = AsocFamiliaPatente.TipoOperacion.Baja

            mForm.FamiliaPatenteAEditar = mFamilia.ObtenerFamiliaPatentePorIndice(mIndice)
            mForm.StartPosition = FormStartPosition.CenterParent
            mForm.ShowDialog(Me)
            Me.dgvFamiliaPatentes.DataSource = mFamilia.FamiliaPatente
        End If
    End Sub

#End Region

End Class