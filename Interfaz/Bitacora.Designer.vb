<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bitacora
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
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
        Me.dvgBitacora = New System.Windows.Forms.DataGridView()
        Me.txtMensaje = New System.Windows.Forms.Label()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dvgBitacora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(23, 28)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(728, 199)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkCriticidad)
        Me.GroupBox3.Controls.Add(Me.chkFechas)
        Me.GroupBox3.Controls.Add(Me.chkUsuario)
        Me.GroupBox3.Location = New System.Drawing.Point(509, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(91, 139)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Todos"
        '
        'chkCriticidad
        '
        Me.chkCriticidad.AutoSize = True
        Me.chkCriticidad.Location = New System.Drawing.Point(36, 113)
        Me.chkCriticidad.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCriticidad.Name = "chkCriticidad"
        Me.chkCriticidad.Size = New System.Drawing.Size(18, 17)
        Me.chkCriticidad.TabIndex = 24
        Me.chkCriticidad.UseVisualStyleBackColor = True
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(36, 67)
        Me.chkFechas.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(18, 17)
        Me.chkFechas.TabIndex = 23
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'chkUsuario
        '
        Me.chkUsuario.AutoSize = True
        Me.chkUsuario.Location = New System.Drawing.Point(36, 22)
        Me.chkUsuario.Margin = New System.Windows.Forms.Padding(4)
        Me.chkUsuario.Name = "chkUsuario"
        Me.chkUsuario.Size = New System.Drawing.Size(18, 17)
        Me.chkUsuario.TabIndex = 22
        Me.chkUsuario.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OrdenarCriticidad)
        Me.GroupBox2.Controls.Add(Me.OrdenarFecha)
        Me.GroupBox2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.GroupBox2.Location = New System.Drawing.Point(617, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(89, 97)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ordenar"
        '
        'OrdenarCriticidad
        '
        Me.OrdenarCriticidad.AutoSize = True
        Me.OrdenarCriticidad.Location = New System.Drawing.Point(37, 70)
        Me.OrdenarCriticidad.Name = "OrdenarCriticidad"
        Me.OrdenarCriticidad.Size = New System.Drawing.Size(17, 16)
        Me.OrdenarCriticidad.TabIndex = 32
        Me.OrdenarCriticidad.TabStop = True
        Me.OrdenarCriticidad.UseVisualStyleBackColor = True
        '
        'OrdenarFecha
        '
        Me.OrdenarFecha.AutoSize = True
        Me.OrdenarFecha.Location = New System.Drawing.Point(37, 27)
        Me.OrdenarFecha.Name = "OrdenarFecha"
        Me.OrdenarFecha.Size = New System.Drawing.Size(17, 16)
        Me.OrdenarFecha.TabIndex = 31
        Me.OrdenarFecha.TabStop = True
        Me.OrdenarFecha.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(517, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Todos"
        '
        'rbtnBaja
        '
        Me.rbtnBaja.AutoSize = True
        Me.rbtnBaja.Location = New System.Drawing.Point(437, 126)
        Me.rbtnBaja.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnBaja.Name = "rbtnBaja"
        Me.rbtnBaja.Size = New System.Drawing.Size(57, 21)
        Me.rbtnBaja.TabIndex = 18
        Me.rbtnBaja.TabStop = True
        Me.rbtnBaja.Text = "Baja"
        Me.rbtnBaja.UseVisualStyleBackColor = True
        '
        'rbtnMedia
        '
        Me.rbtnMedia.AutoSize = True
        Me.rbtnMedia.Location = New System.Drawing.Point(279, 126)
        Me.rbtnMedia.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnMedia.Name = "rbtnMedia"
        Me.rbtnMedia.Size = New System.Drawing.Size(67, 21)
        Me.rbtnMedia.TabIndex = 17
        Me.rbtnMedia.TabStop = True
        Me.rbtnMedia.Text = "Media"
        Me.rbtnMedia.UseVisualStyleBackColor = True
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaHasta.Location = New System.Drawing.Point(390, 78)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(111, 22)
        Me.dtpFechaHasta.TabIndex = 15
        Me.dtpFechaHasta.Value = New Date(2016, 11, 12, 19, 0, 38, 0)
        '
        'rbtnAlta
        '
        Me.rbtnAlta.AutoSize = True
        Me.rbtnAlta.Checked = True
        Me.rbtnAlta.Location = New System.Drawing.Point(172, 126)
        Me.rbtnAlta.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnAlta.Name = "rbtnAlta"
        Me.rbtnAlta.Size = New System.Drawing.Size(53, 21)
        Me.rbtnAlta.TabIndex = 16
        Me.rbtnAlta.TabStop = True
        Me.rbtnAlta.Text = "Alta"
        Me.rbtnAlta.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(285, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Fecha hasta"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaDesde.Location = New System.Drawing.Point(121, 78)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(111, 22)
        Me.dtpFechaDesde.TabIndex = 13
        Me.dtpFechaDesde.Value = New Date(2016, 1, 1, 0, 0, 0, 0)
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(637, 159)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(85, 26)
        Me.btnBuscar.TabIndex = 12
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Criticidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha desde"
        '
        'cmbUsuario
        '
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.Location = New System.Drawing.Point(121, 32)
        Me.cmbUsuario.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(382, 24)
        Me.cmbUsuario.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Usuario"
        '
        'dvgBitacora
        '
        Me.dvgBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dvgBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvgBitacora.Location = New System.Drawing.Point(23, 255)
        Me.dvgBitacora.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dvgBitacora.Name = "dvgBitacora"
        Me.dvgBitacora.RowTemplate.Height = 28
        Me.dvgBitacora.Size = New System.Drawing.Size(728, 192)
        Me.dvgBitacora.TabIndex = 7
        '
        'txtMensaje
        '
        Me.txtMensaje.AutoSize = True
        Me.txtMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.Location = New System.Drawing.Point(19, 230)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(68, 17)
        Me.txtMensaje.TabIndex = 24
        Me.txtMensaje.Text = "Mensaje"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(662, 460)
        Me.btnExportar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(89, 26)
        Me.btnExportar.TabIndex = 33
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Bitacora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 515)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.dvgBitacora)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Bitacora"
        Me.Text = "Bitácora"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dvgBitacora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbUsuario As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents dvgBitacora As DataGridView
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbtnBaja As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMedia As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnAlta As System.Windows.Forms.RadioButton
    Friend WithEvents txtMensaje As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents OrdenarCriticidad As RadioButton
    Friend WithEvents OrdenarFecha As RadioButton
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkCriticidad As CheckBox
    Friend WithEvents chkFechas As CheckBox
    Friend WithEvents chkUsuario As CheckBox
    Friend WithEvents btnExportar As Button
End Class
