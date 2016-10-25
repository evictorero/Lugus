Imports Negocio.Negocio

Public Class Backup
    Dim mBackup As Negocio.Negocio.Backup

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(mBackup) Then
            mBackup = New Negocio.Negocio.Backup
        End If
        mBackup.descripcion = "Backup de la base de datos Lugus"
        mBackup.ruta = txtRuta.Text
        mBackup.fecha = Today

        Dim tamanioVolumenes As Integer

        If Me.cmbCantVolumenes.Text = "" Then
            tamanioVolumenes = 1048576 * 100
        ElseIf Me.cmbCantVolumenes.Text = "100 KB" Then
            tamanioVolumenes = 102400
        ElseIf Me.cmbCantVolumenes.Text = "1 MB" Then
            tamanioVolumenes = 1048576
        ElseIf Me.cmbCantVolumenes.Text = "10 MB" Then
            tamanioVolumenes = 1048576 * 10
        ElseIf Me.cmbCantVolumenes.Text = "100 MB" Then
            tamanioVolumenes = 1048576 * 100
        ElseIf Me.cmbCantVolumenes.Text = "1 GB" Then
            tamanioVolumenes = 1048576 * 1000
        End If

        mBackup.cantVolumen = tamanioVolumenes
        mBackup.idUsuarioAlta = Principal.UsuarioEnSesion.id
        mBackup.GuardarNuevo()

        Me.Close()
    End Sub

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbCantVolumenes.Items.Add("100 KB")
        cmbCantVolumenes.Items.Add("1 MB")
        cmbCantVolumenes.Items.Add("10 MB")
        cmbCantVolumenes.Items.Add("100 MB")
        cmbCantVolumenes.Items.Add("1 GB")

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sfd As SaveFileDialog = New SaveFileDialog()

        sfd.Title = "Open File Dialog"
        sfd.InitialDirectory = "C:\"
        sfd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        sfd.FilterIndex = 2
        sfd.RestoreDirectory = True

        If sfd.ShowDialog() = DialogResult.OK Then
            txtRuta.Text = sfd.FileName
        End If
    End Sub
End Class