Imports Negocio

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

    Private Sub AdministrarFamiliasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        PatenteABM.Show()
    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If estaAutenticado Then
            Me.WindowState = FormWindowState.Maximized

            Dim idiomaDataSource As Collections.Generic.List(Of Negocio.Negocio.Idioma)
            idiomaDataSource = (New Negocio.Negocio.Idioma).Listar

            For Each idioma As Negocio.Negocio.Idioma In idiomaDataSource
                Dim subitem As New ToolStripMenuItem(idioma.descripcion)
                ' habilito la posibilidad del check
                subitem.CheckOnClick = True

                ' asigno el item completo al menu para poder obtener los datos luego
                subitem.Tag = idioma

                ' chequeo solo el que tenga el usuario definido
                If UsuarioEnSesion.id_idioma = idioma.id Then
                    subitem.PerformClick()
                End If

                ' agrego a todos el mismo handler al hacer click
                AddHandler subitem.Click, AddressOf ToolStripMenuItemIdioma_Click 'place the name of your function

                ' agrego el nuevo subitem al menu de Idioma
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

    Private Sub ToolStripMenuItemIdioma_Click(sender As Object, e As EventArgs)
        ' casteo el item
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

        ' casteo el idioma desde el item clickeado
        Dim idioma As Negocio.Negocio.Idioma = DirectCast(item.Tag, Negocio.Negocio.Idioma)

        ' obtengo el padre para recorrer todos los subitems y tildar solo el nuevo
        Dim padre = DirectCast(item.OwnerItem, ToolStripMenuItem)

        For Each menuIdioma As ToolStripMenuItem In padre.DropDownItems
            menuIdioma.Checked = False

            If menuIdioma.Text = item.Text Then
                menuIdioma.Checked = True
            End If
        Next

        ' seteo el nuevo idioma en el usuario en memoria
        UsuarioEnSesion.id_idioma = idioma.id

        ' persisto el nuevo idioma en BD
        UsuarioEnSesion.Guardar()

        MessageBox.Show("Iniciar sesión nuevamente para utilizar el nuevo idioma")

        ' cierro para que inicie sesion con el nuevo idioma
        Me.Close()

    End Sub

End Class