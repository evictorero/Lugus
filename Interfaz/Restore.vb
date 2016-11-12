Imports Negocio.Negocio.UsuarioPatente
Imports Negocio.Negocio.Traductor

Public Class Restore

    Dim TieneAccesoAlta As Boolean = False
    Dim TieneAccesoModif As Boolean = False
    Dim TieneAccesoElim As Boolean = False
    Dim TieneAccesoRehab As Boolean = False

    Dim mBackup As Negocio.Negocio.Backup

    Private Sub Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TienePermisoAcceso() = True Then
            Dim listaBackups As List(Of Negocio.Negocio.Backup) = (New Negocio.Negocio.Backup).Listar
            For Each mBackup As Negocio.Negocio.Backup In listaBackups
                cmbBackup.Items.Add(mBackup.ruta)
            Next

            If cmbBackup.Items.Count > 1 Then
                cmbBackup.SelectedIndex = 0
            End If

            Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
        Else
            Me.Close()
            MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Acceso Restringido"))
        End If

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

    Public Function TienePermisoAcceso() As Boolean
        'Patentes 27
        Dim tieneAcceso As Boolean = False
        For x As Integer = 0 To Principal.UsuarioEnSesion.UsuarioPatente.Count - 1
            Select Case Principal.UsuarioEnSesion.UsuarioPatente(x).id_patente
                Case 27
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
                Case 27
                    If mListaPatentesDeFamiliaporUsuario(x).m_negada = "N" Then
                        TieneAccesoAlta = True
                        tieneAcceso = True
                    End If
            End Select
        Next
        Return tieneAcceso
    End Function
End Class