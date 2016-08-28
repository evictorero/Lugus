'Imports Negocio.

Public Class Bebida
    'Dim mBebida As Negocio.Bebida

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
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Select Case mOperacion
            Case TipoOperacion.Alta, TipoOperacion.Modificacion
                If IsNothing(mBebida) Then
                    mPropietario = New Negocio.Negocio.Propietario
                End If

                mPropietario.Nombre = Me.txtNombre.Text
                mPropietario.Apellido = Me.txtApellido.Text
                mPropietario.Guardar()
                Me.Close()
            Case TipoOperacion.Baja
                mPropietario.Eliminar()
                Me.Close()
        End Select
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class