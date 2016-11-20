Imports Negocio.Negocio.Traductor
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO


Public Class Bitacora
    Dim APP As New Excel.Application
    Dim worksheet As Excel.Worksheet
    Dim workbook As Excel.Workbook
    Dim excelLocation As String = "C:\Celes\test.xlsx"

    Private Sub Bitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim listaUsuarios As List(Of Negocio.Negocio.Usuario) = (New Negocio.Negocio.Usuario).Listar

        cmbUsuario.DisplayMember = "nombre"
        cmbUsuario.ValueMember = "id"
        cmbUsuario.DataSource = listaUsuarios

        If cmbUsuario.SelectedIndex >= 0 Then
            cmbUsuario.SelectedIndex = 0
        End If

        ' dtpFechaDesde.Value = New DateTime(2016, 1, 1)
        ' dtpFechaHasta.Value = Date.Now

        dtpFechaDesde.CustomFormat = "dd/MM/yyyy"
        dtpFechaHasta.CustomFormat = "dd/MM/yyyy"

        chkUsuario.Checked = False
        chkFechas.Checked = False
        chkCriticidad.Checked = False

        'Seteo de aspecto de la grilla
        With Me.dvgBitacora
            .AllowDrop = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            With .Columns
                .Add("cid", "Código")
                .Item(0).DataPropertyName = "id"
                '.Item(0).Width = 100
                .Item(0).Visible = False
                '
                .Add("cdescripcionlarga", "Descripcion")
                .Item(1).DataPropertyName = "DescripcionLarga"
                .Item(1).Width = 200

                .Add("cfecha", "Fecha")
                .Item(2).DataPropertyName = "fecha"
                .Item(2).Width = 150
                .Item(2).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"

                .Add("ccriticidad", "Criticidad")
                .Item(3).DataPropertyName = "criticidad"
                .Item(3).Width = 80


            End With

        End With

        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim mBitacora As New Negocio.Negocio.Bitacora
        Dim mUsuario As Integer
        Dim mFechaDesde As Date
        Dim mFechaHasta As Date
        Dim mCriticidad As String
        Dim mOrden As String

        ' lleno los parámetros del filtro, si tilda todos envío NULL
        If chkUsuario.Checked Then
            mUsuario = Nothing
        Else
            mUsuario = Me.cmbUsuario.SelectedValue
        End If

        If chkFechas.Checked Then
            mFechaDesde = Nothing
            mFechaHasta = Nothing
        Else
            mFechaDesde = Me.dtpFechaDesde.Value
            mFechaHasta = Me.dtpFechaHasta.Value
        End If

        If chkCriticidad.Checked Then
            mCriticidad = Nothing
        Else
            If rbtnAlta.Checked Then
                mCriticidad = "Alta"
            ElseIf rbtnMedia.Checked Then
                mCriticidad = "Media"
            Else
                mCriticidad = "Baja"
            End If
        End If

        If OrdenarCriticidad.Checked Then
            mOrden = "criticidad"
        ElseIf OrdenarFecha.Checked Then
            mOrden = "fecha"
        Else
            mOrden = "id_usuario"
        End If

        Me.dvgBitacora.DataSource = (New Negocio.Negocio.Bitacora).ListarConFiltro(mUsuario,
                                                                                   mFechaDesde,
                                                                                   mFechaHasta,
                                                                                   mCriticidad,
                                                                                   mOrden)

        If Me.dvgBitacora.RowCount = 0 Then
            Me.txtMensaje.Text = ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "No existen bitácoras ingresadas en el sistema")
        Else
            Me.txtMensaje.Text = ""
        End If
    End Sub

    Private Sub chkUsuario_CheckedChanged(sender As Object, e As EventArgs)
        If chkUsuario.Checked Then
            cmbUsuario.Enabled = False
        Else
            cmbUsuario.Enabled = True
        End If
    End Sub

    Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs)
        If chkFechas.Checked Then
            dtpFechaDesde.Enabled = False
            dtpFechaHasta.Enabled = False
        Else
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
        End If
    End Sub

    Private Sub chkCriticidad_CheckedChanged(sender As Object, e As EventArgs)
        If chkCriticidad.Checked Then
            rbtnAlta.Enabled = False
            rbtnMedia.Enabled = False
            rbtnBaja.Enabled = False
        Else
            rbtnAlta.Enabled = True
            rbtnMedia.Enabled = True
            rbtnBaja.Enabled = True
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click


        Dim folderDialog As FolderBrowserDialog = New FolderBrowserDialog()
        If folderDialog.ShowDialog() = DialogResult.OK Then
            excelLocation = folderDialog.SelectedPath

            excelLocation = excelLocation.TrimEnd("\\") & "\"


            If Directory.Exists(excelLocation) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(excelLocation)
            End If

            excelLocation = excelLocation & "ReporteBitacora.xls"

            If Dir(excelLocation) = "" Then

                With APP
                    '.Visible = True
                    'Asi creas el Libro de Excel
                    .Workbooks.Add()
                    'Asi Guardas el Libro de Excel
                    .ActiveWorkbook.SaveAs(excelLocation)
                End With
            End If

            workbook = APP.Workbooks.Open(excelLocation)
            worksheet = workbook.Worksheets("sheet1")

            'Export Header Names Start
            Dim columnsCount As Integer = dvgBitacora.Columns.Count
            For Each column In dvgBitacora.Columns
                worksheet.Cells(1, column.Index + 1).Value = column.Name
            Next
            'Export Header Name End
            Me.Cursor = Cursors.WaitCursor

            'Export Each Row Start
            For i As Integer = 0 To dvgBitacora.Rows.Count - 1
                Dim columnIndex As Integer = 0
                Do Until columnIndex = columnsCount
                    worksheet.Cells(i + 2, columnIndex + 1).Value = dvgBitacora.Item(columnIndex, i).Value.ToString
                    columnIndex += 1
                Loop
            Next

            Me.Cursor = Cursors.Default

            'Export Each Row End
            workbook.Save()
            workbook.Close()

            MsgBox("Exportado correctamente")
        End If
    End Sub

End Class