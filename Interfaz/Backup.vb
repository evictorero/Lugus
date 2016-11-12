Imports Negocio.Negocio
Imports Negocio.Negocio.UsuarioPatente
Imports Negocio.Negocio.Traductor

Public Class Backup

    Dim TieneAccesoAlta As Boolean = False
    Dim TieneAccesoModif As Boolean = False
    Dim TieneAccesoElim As Boolean = False
    Dim TieneAccesoRehab As Boolean = False

    Dim mBackup As Negocio.Negocio.Backup

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(mBackup) Then
            mBackup = New Negocio.Negocio.Backup
        End If
        mBackup.descripcion = "Backup de la base de datos Lugus"

        ' aseguro que el path siempre termine con la barra
        mBackup.ruta = txtRuta.Text.TrimEnd("\\") & "\"

        mBackup.cantVolumen = Me.cbCantVolumenes.SelectedItem
        mBackup.idUsuarioAlta = Principal.UsuarioEnSesion.id
        Me.Cursor = Cursors.Default
        mBackup.GuardarNuevo()
        MessageBox.Show("La copia de respaldo se realizó correctamente")
        Me.Close()

    End Sub

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TienePermisoAcceso() = True Then
            cbCantVolumenes.Text = 5
            txtRuta.Text = "C:\backup\"
            Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
        Else
            Me.Close()
        MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Acceso Restringido"))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim folderDialog As FolderBrowserDialog = New FolderBrowserDialog()
        If folderDialog.ShowDialog() = DialogResult.OK Then
            txtRuta.Text = folderDialog.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Public Function TienePermisoAcceso() As Boolean
        'Patentes 26
        Dim tieneAcceso As Boolean = False
        For x As Integer = 0 To Principal.UsuarioEnSesion.UsuarioPatente.Count - 1
            Select Case Principal.UsuarioEnSesion.UsuarioPatente(x).id_patente
                Case 26
                    If Principal.UsuarioEnSesion.UsuarioPatente(x).m_negada = "N" Then
                        TieneAccesoAlta = True
                        tieneAcceso = True
                    End If
            End Select
        Next
        Dim mListaPatentesDeFamiliaporUsuario As New List(Of Negocio.Negocio.UsuarioPatente)
        mListaPatentesDeFamiliaporUsuario = Principal.UsuarioEnSesion.ListarPatentesDeFamiliaPorUsuario
        For x As Integer = 0 To mListaPatentesDeFamiliaporUsuario.Count - 1
            Select Case mListaPatentesDeFamiliaporUsuario(x).id_patente
                Case 26
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoAlta = True
                        tieneAcceso = True
                    End If
            End Select
        Next
        Return tieneAcceso
    End Function
End Class