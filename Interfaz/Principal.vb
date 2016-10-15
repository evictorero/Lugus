﻿Imports Negocio

Public Class Principal

    Public estaAutenticado As Boolean = False
    Public UsuarioEnSesion As New Negocio.Negocio.Usuario

    Private Sub AdministrarUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs)
        UsuarioABM.Show()
    End Sub

    Private Sub AdministrarPlatosToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AdministracionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministracionToolStripMenuItem.Click

    End Sub

    Private Sub AdministrarUsuarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdministrarUsuarioToolStripMenuItem1.Click
        UsuarioABM.Show()

    End Sub

    Private Sub BackupToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem1.Click
        Backup.Show()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        Restore.Show()
    End Sub

    Private Sub AdministrarPedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministrarPedidosToolStripMenuItem.Click

    End Sub

    Private Sub AsignarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarToolStripMenuItem.Click

    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem.Click
        Bitacora.Show()

    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        CambiarContraseña.Show()
    End Sub

    Private Sub AdministrarPlatosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdministrarPlatosToolStripMenuItem1.Click
        FamiliaABM.Show()
    End Sub

    Private Sub PedidosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PedidosToolStripMenuItem1.Click
        PedidoABM.Show()

    End Sub

    Private Sub AdministrarDatosMaestrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministrarDatosMaestrosToolStripMenuItem.Click

    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click

    End Sub

    Private Sub AdministrarBebidasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdministrarBebidasToolStripMenuItem1.Click
        BebidaABM.Show()
    End Sub

    Private Sub AdministrarPlatosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AdministrarPlatosToolStripMenuItem.Click
        PlatosABM.Show()
    End Sub

    Private Sub AdministrarFamiliasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministrarFamiliasToolStripMenuItem.Click
        PatenteABM.Show()
    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If estaAutenticado Then
            Me.WindowState = FormWindowState.Maximized

            Dim idiomaDataSource As Collections.Generic.List(Of Negocio.Negocio.Idioma)
            idiomaDataSource = (New Negocio.Negocio.Idioma).Listar

            For Each t As Negocio.Negocio.Idioma In idiomaDataSource
                Dim subitem As New ToolStripMenuItem(t.descripcion)
                IdiomaToolStripMenuItem1.DropDownItems.Add(subitem)
            Next

        Else
            Me.Close()
        End If
    End Sub

    Public Sub Traducir()
        Try
            Dim traductor As New Negocio.Negocio.Traductor
            traductor.TraducirForm(Me, UsuarioEnSesion.id_idioma)
        Catch ex As Exception
            MessageBox.Show("IMPOSIBLE CAMBIAR EL IDIOMA")
        End Try

    End Sub

End Class