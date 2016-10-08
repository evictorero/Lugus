Imports Negocio.Negocio
Imports System.DateTime


Public Class Familia
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
End Class