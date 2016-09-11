Imports Negocio.Negocio

Public Class Bebida
    Dim mBebida As Negocio.Negocio.Bebida

    Friend mOperacion As TipoOperacion
    Friend Enum TipoOperacion
        Alta = 1
        Baja = 2
        Modificacion = 3
        Rehabilitar = 4
    End Enum
    Friend Property BebidaAEditar() As Negocio.Negocio.Bebida
        Get
            Return mBebida
        End Get
        Set(ByVal value As Negocio.Negocio.Bebida)
            mBebida = value
        End Set
    End Property

    Private Sub Bebida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtId_bebida.Enabled = False
        Select Case mOperacion
            Case TipoOperacion.Alta

                Me.txtDescripcion_corta.Text = ""
                Me.txtDescripcion_larga.Text = ""
                Me.txtFecha_Baja.Text = ""

                Me.Label1.Text = "Alta de Bebida"

            Case TipoOperacion.Baja

                If Not IsNothing(mBebida) Then
                    Me.txtDescripcion_corta.Text = mBebida.descripcionCorta
                    Me.txtDescripcion_larga.Text = mBebida.descripcionLarga
                    Me.txtFecha_Baja.Text = mBebida.fechaBaja

                    Me.Label1.Text = "¿Esta seguro que desea dar de baja esta Bebida?"
                    Me.btnGuardar.Text = "Eliminar"
                    Me.btnGuardar.BackColor = Color.Firebrick
                    Me.btnGuardar.ForeColor = Color.AntiqueWhite
                End If

            Case TipoOperacion.Modificacion

                If Not IsNothing(mBebida) Then
                    Me.txtDescripcion_corta.Text = mBebida.descripcionCorta
                    Me.txtDescripcion_larga.Text = mBebida.descripcionLarga
                    Me.txtFecha_Baja.Text = mBebida.fechaBaja
                    Me.Label1.Text = "Modificacion de Bebida"
                End If

            Case TipoOperacion.Rehabilitar

                Me.txtId_bebida.Text = mBebida.id
                Me.txtId_bebida.Enabled = False

                Me.txtDescripcion_corta.Text = mBebida.descripcionCorta
                Me.txtDescripcion_corta.Enabled = False
                Me.txtDescripcion_larga.Text = mBebida.descripcionLarga
                Me.txtDescripcion_larga.Enabled = False
                Me.Label1.Text = "Rehabilitar Bebida"
                Me.btnGuardar.Visible = False
        End Select
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
                'mBebida.fechaBaja = Me.txtFecha_Baja
                mBebida.idUsuario = 1
                mBebida.dvh = 1
                mBebida.Guardar()
                Me.Close()
            Case TipoOperacion.Baja
                mBebida.Eliminar()
                Me.Close()
        End Select
    End Sub

End Class