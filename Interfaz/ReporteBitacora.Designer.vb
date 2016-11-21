<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReporteBitacora
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.BitacoraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkCriticidad = New System.Windows.Forms.CheckBox()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.chkUsuario = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.OrdenarCriticidad = New System.Windows.Forms.RadioButton()
        Me.OrdenarFecha = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rbtnBaja = New System.Windows.Forms.RadioButton()
        Me.rbtnMedia = New System.Windows.Forms.RadioButton()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.rbtnAlta = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbUsuario = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.BitacoraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BitacoraBindingSource
        '
        Me.BitacoraBindingSource.DataSource = GetType(Negocio.Negocio.Bitacora)
        '
        'ReportViewer1
        '
        ReportDataSource3.Name = "DataSet1"
        ReportDataSource3.Value = Me.BitacoraBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Interfaz.ReporteBitacora.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(27, 196)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(661, 246)
        Me.ReportViewer1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.rbtnBaja)
        Me.GroupBox1.Controls.Add(Me.rbtnMedia)
        Me.GroupBox1.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox1.Controls.Add(Me.rbtnAlta)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbUsuario)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(74, 11)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(546, 162)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkCriticidad)
        Me.GroupBox3.Controls.Add(Me.chkFechas)
        Me.GroupBox3.Controls.Add(Me.chkUsuario)
        Me.GroupBox3.Location = New System.Drawing.Point(382, 11)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(68, 113)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Todos"
        '
        'chkCriticidad
        '
        Me.chkCriticidad.AutoSize = True
        Me.chkCriticidad.Location = New System.Drawing.Point(27, 92)
        Me.chkCriticidad.Name = "chkCriticidad"
        Me.chkCriticidad.Size = New System.Drawing.Size(15, 14)
        Me.chkCriticidad.TabIndex = 24
        Me.chkCriticidad.UseVisualStyleBackColor = True
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(27, 54)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(15, 14)
        Me.chkFechas.TabIndex = 23
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'chkUsuario
        '
        Me.chkUsuario.AutoSize = True
        Me.chkUsuario.Location = New System.Drawing.Point(27, 18)
        Me.chkUsuario.Name = "chkUsuario"
        Me.chkUsuario.Size = New System.Drawing.Size(15, 14)
        Me.chkUsuario.TabIndex = 22
        Me.chkUsuario.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OrdenarCriticidad)
        Me.GroupBox2.Controls.Add(Me.OrdenarFecha)
        Me.GroupBox2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.GroupBox2.Location = New System.Drawing.Point(463, 46)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(67, 79)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ordenar"
        '
        'OrdenarCriticidad
        '
        Me.OrdenarCriticidad.AutoSize = True
        Me.OrdenarCriticidad.Location = New System.Drawing.Point(28, 57)
        Me.OrdenarCriticidad.Margin = New System.Windows.Forms.Padding(2)
        Me.OrdenarCriticidad.Name = "OrdenarCriticidad"
        Me.OrdenarCriticidad.Size = New System.Drawing.Size(14, 13)
        Me.OrdenarCriticidad.TabIndex = 32
        Me.OrdenarCriticidad.TabStop = True
        Me.OrdenarCriticidad.UseVisualStyleBackColor = True
        '
        'OrdenarFecha
        '
        Me.OrdenarFecha.AutoSize = True
        Me.OrdenarFecha.Location = New System.Drawing.Point(28, 22)
        Me.OrdenarFecha.Margin = New System.Windows.Forms.Padding(2)
        Me.OrdenarFecha.Name = "OrdenarFecha"
        Me.OrdenarFecha.Size = New System.Drawing.Size(14, 13)
        Me.OrdenarFecha.TabIndex = 31
        Me.OrdenarFecha.TabStop = True
        Me.OrdenarFecha.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(388, 11)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Todos"
        '
        'rbtnBaja
        '
        Me.rbtnBaja.AutoSize = True
        Me.rbtnBaja.Location = New System.Drawing.Point(328, 102)
        Me.rbtnBaja.Name = "rbtnBaja"
        Me.rbtnBaja.Size = New System.Drawing.Size(46, 17)
        Me.rbtnBaja.TabIndex = 18
        Me.rbtnBaja.TabStop = True
        Me.rbtnBaja.Text = "Baja"
        Me.rbtnBaja.UseVisualStyleBackColor = True
        '
        'rbtnMedia
        '
        Me.rbtnMedia.AutoSize = True
        Me.rbtnMedia.Location = New System.Drawing.Point(209, 102)
        Me.rbtnMedia.Name = "rbtnMedia"
        Me.rbtnMedia.Size = New System.Drawing.Size(54, 17)
        Me.rbtnMedia.TabIndex = 17
        Me.rbtnMedia.TabStop = True
        Me.rbtnMedia.Text = "Media"
        Me.rbtnMedia.UseVisualStyleBackColor = True
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaHasta.Location = New System.Drawing.Point(292, 63)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(84, 20)
        Me.dtpFechaHasta.TabIndex = 15
        Me.dtpFechaHasta.Value = New Date(2016, 11, 12, 19, 0, 38, 0)
        '
        'rbtnAlta
        '
        Me.rbtnAlta.AutoSize = True
        Me.rbtnAlta.Checked = True
        Me.rbtnAlta.Location = New System.Drawing.Point(129, 102)
        Me.rbtnAlta.Name = "rbtnAlta"
        Me.rbtnAlta.Size = New System.Drawing.Size(43, 17)
        Me.rbtnAlta.TabIndex = 16
        Me.rbtnAlta.TabStop = True
        Me.rbtnAlta.Text = "Alta"
        Me.rbtnAlta.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(214, 67)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Fecha hasta"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaDesde.Location = New System.Drawing.Point(91, 63)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(84, 20)
        Me.dtpFechaDesde.TabIndex = 13
        Me.dtpFechaDesde.Value = New Date(2016, 1, 1, 0, 0, 0, 0)
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(478, 129)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 21)
        Me.btnBuscar.TabIndex = 12
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 104)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Criticidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 67)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha desde"
        '
        'cmbUsuario
        '
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.Location = New System.Drawing.Point(91, 26)
        Me.cmbUsuario.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(288, 21)
        Me.cmbUsuario.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 30)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Usuario"
        '
        'ReporteBitacora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 454)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ReporteBitacora"
        Me.Text = "ReporteBitacora"
        CType(Me.BitacoraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents BitacoraBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCriticidad As System.Windows.Forms.CheckBox
    Friend WithEvents chkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents chkUsuario As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OrdenarCriticidad As System.Windows.Forms.RadioButton
    Friend WithEvents OrdenarFecha As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbtnBaja As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMedia As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbtnAlta As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
