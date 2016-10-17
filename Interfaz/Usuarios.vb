Imports Negocio.Negocio
Imports System.DateTime


Public Class Usuarios

    Dim mUsuario As Negocio.Negocio.Usuario

    Friend mOperacion As TipoOperacion
    Friend Enum TipoOperacion
        Alta = 1
        Baja = 2
        Modificacion = 3
        Rehabilitar = 4
    End Enum

    Friend Property UsuarioAEditar() As Negocio.Negocio.Usuario
        Get
            Return mUsuario
        End Get
        Set(ByVal value As Negocio.Negocio.Usuario)
            mUsuario = value
        End Set
    End Property

    Private Sub Usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.cbId_Propietario.DataSource = (New Negocio.Negocio.Propietario).Listar
        Me.Visible = True
        Me.txtUsuario.Focus()

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

        Me.txtId_usuario.Enabled = False

        'Seteo de aspecto de la grilla 
        With Me.dgvPatentes
            .AllowDrop = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            With .Columns
                .Add("cId", "id_usuario")
                .Item(0).DataPropertyName = "Id_Usuario"
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
                Me.txtUsuario.Text = ""
                Me.txtNombre.Text = ""
                Me.txtApellido.Text = ""
                Me.txtFecha_Nacimiento.Text = ""
                Me.txtEmail.Text = ""
                Me.txtDNI.Text = ""
                Me.lblTitulo.Text = "Alta de Usuario"

            Case TipoOperacion.Modificacion

                If Not IsNothing(mUsuario) Then
                    Me.txtId_usuario.Text = mUsuario.id
                    Me.txtUsuario.Text = mUsuario.usuario
                    Me.txtNombre.Text = mUsuario.nombre
                    Me.txtApellido.Text = mUsuario.apellido
                    Me.txtFecha_Nacimiento.Text = mUsuario.fechaNacimiento
                    Me.txtEmail.Text = mUsuario.email
                    Me.txtDNI.Text = mUsuario.dni

                    Me.lblTitulo.Text = "Modificación de Usuario"
                End If
        End Select

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

        ActualizarGrilla()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Select Case mOperacion
            Case TipoOperacion.Alta, TipoOperacion.Modificacion
                If IsNothing(mUsuario) Then
                    mUsuario = New Negocio.Negocio.Usuario
                End If
                mUsuario.usuario = Me.txtUsuario.Text
                mUsuario.nombre = Me.txtNombre.Text
                mUsuario.apellido = Me.txtApellido.Text
                mUsuario.dni = Me.txtDNI.Text
                mUsuario.email = Me.txtEmail.Text
                mUsuario.fechaNacimiento = Me.txtFecha_Nacimiento.Text
                mUsuario.idUsuarioAlta = Principal.UsuarioEnSesion.id
                mUsuario.dvh = 1 'Digito Verificador Celes
                mUsuario.id_idioma = 1 'Idioma Celes

                mUsuario.Guardar()
                Me.Close()
            Case TipoOperacion.Baja
                mUsuario.Eliminar()
                Me.Close()
        End Select
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'Traducir Celeste
        Select Case mOperacion
            Case TipoOperacion.Alta, TipoOperacion.Modificacion
                Dim result As Integer = MessageBox.Show("¿Desea Cancelar la operación de Alta de usuario? ", "Cancelar", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Me.Close()
                End If
            Case TipoOperacion.Baja
                Dim result As Integer = MessageBox.Show("¿Desea Cancelar la operación de Modificacion de Usuario? ", "Cancelar", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Me.Close()
                End If
        End Select

    End Sub

    Private Sub btnAgregarPatente_Click(sender As Object, e As EventArgs) Handles btnAgregarPatente.Click
        Dim mForm As New AsocUsuarioPatente
        mForm.Operacion = AsocUsuarioPatente.TipoOperacion.Alta
        mForm.StartPosition = FormStartPosition.CenterParent
        mForm.ShowDialog(Me)
        ActualizarGrilla()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnAgregarFamilia.Click
        AsocUsuarioPatente.Show()
    End Sub

    Private Sub ActualizarGrilla()
        dgvPatentes.DataSource = mUsuario.UsuarioPatente
        If dgvPatentes.Rows.Count > 0 Then
            For i As Integer = 0 To dgvPatentes.Rows.Count - 1
                Dim mPatente As New Negocio.Negocio.Patente
                mPatente.Cargar(CInt(dgvPatentes.Rows(i).Cells(1).Value))
                dgvPatentes.Rows(i).Cells(2).Value = mPatente.descripcionCorta
            Next
        End If
    End Sub

End Class