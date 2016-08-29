Imports Negocio.Negocio

Public Class Bebida
    Dim mBebida As Negocio.Negocio.Bebida

    Friend mOperacion As TipoOperacion
    Friend Enum TipoOperacion
        Alta = 1
        Baja = 2
        Modificacion = 3
        Vista = 4
    End Enum
    Private Sub Bebida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = True
        Me.txtDescripcion_corta.Focus()
        Me.cboxHabilitado.Items.Add("S")
        Me.cboxHabilitado.Items.Add("N")
        Me.cboxHabilitado.SelectedValue = "S"
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