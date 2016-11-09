Imports Negocio.Negocio
Imports System.DateTime


Public Class Platos
    Dim mPlatos As Negocio.Negocio.Plato

    Friend mOperacion As TipoOperacion
    Friend Enum TipoOperacion
        Alta = 1
        Baja = 2
        Modificacion = 3
        Rehabilitar = 4
    End Enum
    Friend Property PlatosAEditar() As Negocio.Negocio.Plato
        Get
            Return mPlatos
        End Get
        Set(ByVal value As Negocio.Negocio.Plato)
            mPlatos = value
        End Set
    End Property

    Private Sub Platos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtId_plato.Enabled = False
        Me.txtFecha_baja.Enabled = False

        Select Case mOperacion
            Case TipoOperacion.Alta

                Me.txtDescripcion_corta.Text = ""
                Me.txtDescripcion_larga.Text = ""
                Me.cboxHabilitado.Text = ""
                Me.txtFecha_baja.Text = ""
                Me.lblTitulo.Text = "Alta de plato"

            Case TipoOperacion.Baja

                If Not IsNothing(mPlatos) Then
                    Me.txtDescripcion_corta.Text = mPlatos.descripcionCorta
                    Me.txtDescripcion_larga.Text = mPlatos.descripcionLarga
                    Me.txtFecha_baja.Text = mPlatos.fechaBaja

                    Me.lblTitulo.Text = "¿Esta seguro que desea dar de baja esta Platos?"
                    Me.btnGuardar.Text = "Eliminar"
                    Me.btnGuardar.BackColor = Color.Firebrick
                    Me.btnGuardar.ForeColor = Color.AntiqueWhite
                End If

            Case TipoOperacion.Modificacion

                If Not IsNothing(mPlatos) Then
                    Me.txtId_plato.Text = mPlatos.id
                    Me.cboxHabilitado.Text = mPlatos.habilitado
                    Me.txtDescripcion_corta.Text = mPlatos.descripcionCorta
                    Me.txtDescripcion_larga.Text = mPlatos.descripcionLarga
                    If Not IsNothing(mPlatos.fechaBaja) Then
                        Me.txtFecha_baja.Text = mPlatos.fechaBaja
                    End If

                    Me.lblTitulo.Text = "Modificación de plato"
                End If

            Case TipoOperacion.Rehabilitar

                Me.txtId_plato.Text = mPlatos.id
                Me.txtId_plato.Enabled = False

                Me.txtDescripcion_corta.Text = mPlatos.descripcionCorta
                Me.txtDescripcion_corta.Enabled = False
                Me.txtDescripcion_larga.Text = mPlatos.descripcionLarga
                Me.txtDescripcion_larga.Enabled = False
                Me.lblTitulo.Text = "Rehabilitar plato"
                Me.btnGuardar.Visible = False
        End Select

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Select Case mOperacion
            Case TipoOperacion.Alta, TipoOperacion.Modificacion
                If IsNothing(mPlatos) Then
                    mPlatos = New Negocio.Negocio.Plato
                End If

                mPlatos.descripcionCorta = Me.txtDescripcion_corta.Text
                mPlatos.descripcionLarga = Me.txtDescripcion_larga.Text
                mPlatos.habilitado = Me.cboxHabilitado.Text
                mPlatos.idUsuario = Principal.UsuarioEnSesion.id
                mPlatos.ValidarFormato(Principal.UsuarioEnSesion.id_idioma)
                mPlatos.Guardar()

                If mOperacion = TipoOperacion.Alta Then
                    MsgBox(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Plato registrado correctamente."))
                Else
                    MsgBox(Negocio.Negocio.Traductor.ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Plato modificado correctamente."))
                End If
                Me.Close()

            Case TipoOperacion.Baja
                mPlatos.Eliminar()
                Me.Close()
        End Select
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub

End Class