Public Class Restore
    Dim mBackup As Negocio.Negocio.Backup

    Private Sub Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim listaBackups As List(Of Negocio.Negocio.Backup) = (New Negocio.Negocio.Backup).Listar
        For Each mBackup As Negocio.Negocio.Backup In listaBackups
            cmbBackup.Items.Add(mBackup.ruta)
        Next

        If cmbBackup.Items.Count > 1 Then
            cmbBackup.SelectedIndex = 0
        End If

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(mBackup) Then
            mBackup = New Negocio.Negocio.Backup
        End If
        Me.Cursor = Cursors.WaitCursor
        mBackup.Restaurar(cmbBackup.Text)
        Me.Cursor = Cursors.Default
        MessageBox.Show("La copia de respaldo se restauró correctamente")
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class