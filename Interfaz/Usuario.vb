Imports Negocio.Negocio
Imports System.DateTime


Public Class Usuario
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
        Me.txtId_bebida.Enabled = False
        Me.txtFecha_baja.Enabled = False

        Select Case mOperacion
            Case TipoOperacion.Alta

                Me.txtDescripcion_corta.Text = ""
                Me.txtDescripcion_larga.Text = ""
                Me.cboxHabilitado.Text = ""
                Me.txtFecha_baja.Text = ""
                Me.lblTitulo.Text = "Alta de bebida"

            Case TipoOperacion.Baja

                If Not IsNothing(mBebida) Then
                    Me.txtDescripcion_corta.Text = mBebida.descripcionCorta
                    Me.txtDescripcion_larga.Text = mBebida.descripcionLarga
                    Me.txtFecha_baja.Text = mBebida.fechaBaja

                    Me.lblTitulo.Text = "¿Esta seguro que desea dar de baja esta Bebida?"
                    Me.btnGuardar.Text = "Eliminar"
                    Me.btnGuardar.BackColor = Color.Firebrick
                    Me.btnGuardar.ForeColor = Color.AntiqueWhite
                End If

            Case TipoOperacion.Modificacion

                If Not IsNothing(mBebida) Then
                    Me.txtId_bebida.Text = mBebida.id
                    Me.cboxHabilitado.Text = mBebida.habilitado
                    Me.txtDescripcion_corta.Text = mBebida.descripcionCorta
                    Me.txtDescripcion_larga.Text = mBebida.descripcionLarga
                    If Not IsNothing(mBebida.fechaBaja) Then
                        Me.txtFecha_baja.Text = mBebida.fechaBaja
                    End If

                    Me.lblTitulo.Text = "Modificación de bebida"
                End If

            Case TipoOperacion.Rehabilitar

                Me.txtId_bebida.Text = mBebida.id
                Me.txtId_bebida.Enabled = False

                Me.txtDescripcion_corta.Text = mBebida.descripcionCorta
                Me.txtDescripcion_corta.Enabled = False
                Me.txtDescripcion_larga.Text = mBebida.descripcionLarga
                Me.txtDescripcion_larga.Enabled = False
                Me.lblTitulo.Text = "Rehabilitar bebida"
                Me.btnGuardar.Visible = False
        End Select

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Select Case mOperacion
            Case TipoOperacion.Alta, TipoOperacion.Modificacion
                If IsNothing(mBebida) Then
                    mBebida = New Negocio.Negocio.Bebida
                End If

                mBebida.descripcionCorta = Me.txtDescripcion_corta.Text
                mBebida.descripcionLarga = Me.txtDescripcion_larga.Text
                mBebida.habilitado = Me.cboxHabilitado.Text
                mBebida.idUsuario = Principal.UsuarioEnSesion.id
                mBebida.dvh = 1 'Digito Verificador Celes
                mBebida.Guardar()
                Me.Close()
            Case TipoOperacion.Baja
                mBebida.Eliminar()
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

    Private Sub Usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.cbId_Propietario.DataSource = (New Negocio.Negocio.Propietario).Listar
        Me.Visible = True
        Me.txtUsuario.Focus()

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

    End Sub
End Class