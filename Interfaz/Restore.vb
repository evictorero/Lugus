Public Class Restore
    Dim mBackup As Negocio.Negocio.Backup

    Private Sub Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim listaBackups As List(Of Negocio.Negocio.Backup) = (New Negocio.Negocio.Backup).Listar
        For Each mBackup As Negocio.Negocio.Backup In listaBackups
            cmbBackup.Items.Add(mBackup.ruta)
        Next

        cmbBackup.SelectedIndex = 0

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(mBackup) Then
            mBackup = New Negocio.Negocio.Backup
        End If

        mBackup.Restaurar(cmbBackup.Text)

        Me.Close()
    End Sub
End Class