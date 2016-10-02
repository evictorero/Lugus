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

        Select Case mOperacion
            Case TipoOperacion.Alta
                Me.txtUsuario.Text = ""
                Me.txtNombre.Text = ""
                Me.txtApellido.Text = ""
                Me.txtFecha_Nacimiento.Text = ""
                Me.txtEmail.Text = ""
                Me.txtDNI.Text = ""
                Me.lblTitulo.Text = "Alta de Usuario"

            'Case TipoOperacion.Baja
            '    'Celeste
            '    If Not IsNothing(mUsuario) Then
            '        Me.txtUsuario.Text = mUsuario.usuario
            '        Me.txtNombre.Text = mUsuario.nombre
            '        Me.txtApellido.Text = mUsuario.apellido
            '        Me.txtFecha_Nacimiento.Text = mUsuario.fecha_nacimiento
            '        Me.txtEmail.Text = mUsuario.email
            '        Me.txtDNI.Text = mUsuario.dni

            '        Me.lblTitulo.Text = "¿Esta seguro que desea dar de baja esta Bebida?"
            '        Me.btnGuardar.Text = "Eliminar"
            '        Me.btnGuardar.BackColor = Color.Firebrick
            '        Me.btnGuardar.ForeColor = Color.AntiqueWhite
            '    End If

            Case TipoOperacion.Modificacion

                If Not IsNothing(mUsuario) Then
                    Me.txtUsuario.Text = mUsuario.usuario
                    Me.txtNombre.Text = mUsuario.nombre
                    Me.txtApellido.Text = mUsuario.apellido
                    Me.txtFecha_Nacimiento.Text = mUsuario.fechaNacimiento
                    Me.txtEmail.Text = mUsuario.email
                    Me.txtDNI.Text = mUsuario.dni

                    Me.lblTitulo.Text = "Modificación de Usuario"
                End If

                'Case TipoOperacion.Rehabilitar

                '    Me.txtId_bebida.Text = mBebida.id
                '    Me.txtId_bebida.Enabled = False

                '    Me.txtDescripcion_corta.Text = mBebida.descripcionCorta
                '    Me.txtDescripcion_corta.Enabled = False
                '    Me.txtDescripcion_larga.Text = mBebida.descripcionLarga
                '    Me.txtDescripcion_larga.Enabled = False
                '    Me.lblTitulo.Text = "Rehabilitar bebida"
                '    Me.btnGuardar.Visible = False
        End Select

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
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
                mUsuario.Guardar()
                Me.Close()
            Case TipoOperacion.Baja
                mUsuario.Eliminar()
                Me.Close()
        End Select
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles btnAgregarPatente.Click
        AsocUsuarioPatente.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPatentes.CellContentClick

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnAgregarFamilia.Click
        AsocUsuarioFamilia.Show()
    End Sub

End Class