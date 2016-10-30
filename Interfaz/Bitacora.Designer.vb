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
        Me.chkCriticidad = New System.Windows.Forms.CheckBox()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.chkUsuario = New System.Windows.Forms.CheckBox()
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
        Me.GroupBox1.SuspendLayout()
        CType(Me.dvgBitacora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCriticidad)
        Me.GroupBox1.Controls.Add(Me.chkFechas)
        Me.GroupBox1.Controls.Add(Me.chkUsuario)
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
        Me.GroupBox1.Location = New System.Drawing.Point(17, 23)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(546, 162)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'chkCriticidad
        '
        Me.chkCriticidad.AutoSize = True
        Me.chkCriticidad.Location = New System.Drawing.Point(482, 103)
        Me.chkCriticidad.Name = "chkCriticidad"
        Me.chkCriticidad.Size = New System.Drawing.Size(15, 14)
        Me.chkCriticidad.TabIndex = 21
        Me.chkCriticidad.UseVisualStyleBackColor = True
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(482, 66)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(15, 14)
        Me.chkFechas.TabIndex = 20
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'chkUsuario
        '
        Me.chkUsuario.AutoSize = True
        Me.chkUsuario.Location = New System.Drawing.Point(482, 29)
        Me.chkUsuario.Name = "chkUsuario"
        Me.chkUsuario.Size = New System.Drawing.Size(15, 14)
        Me.chkUsuario.TabIndex = 19
        Me.chkUsuario.UseVisualStyleBackColor = True
        '
        'rbtnBaja
        '
        Me.rbtnBaja.AutoSize = True
        Me.rbtnBaja.Location = New System.Drawing.Point(346, 102)
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
        Me.rbtnMedia.Location = New System.Drawing.Point(237, 102)
        Me.rbtnMedia.Name = "rbtnMedia"
        Me.rbtnMedia.Size = New System.Drawing.Size(54, 17)
        Me.rbtnMedia.TabIndex = 17
        Me.rbtnMedia.TabStop = True
        Me.rbtnMedia.Text = "Media"
        Me.rbtnMedia.UseVisualStyleBackColor = True
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Location = New System.Drawing.Point(314, 63)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(124, 20)
        Me.dtpFechaHasta.TabIndex = 15
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
        Me.Label4.Location = New System.Drawing.Point(234, 67)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Fecha hasta"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Location = New System.Drawing.Point(91, 63)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(124, 20)
        Me.dtpFechaDesde.TabIndex = 13
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(459, 137)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(50, 21)
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
        Me.cmbUsuario.Size = New System.Drawing.Size(347, 21)
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
        'dvgBitacora
        '
        Me.dvgBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dvgBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvgBitacora.Location = New System.Drawing.Point(17, 207)
        Me.dvgBitacora.Margin = New System.Windows.Forms.Padding(2)
        Me.dvgBitacora.Name = "dvgBitacora"
        Me.dvgBitacora.RowTemplate.Height = 28
        Me.dvgBitacora.Size = New System.Drawing.Size(546, 156)
        Me.dvgBitacora.TabIndex = 7
        '
        'txtMensaje
        '
        Me.txtMensaje.AutoSize = True
        Me.txtMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.Location = New System.Drawing.Point(14, 187)
        Me.txtMensaje.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(54, 13)
        Me.txtMensaje.TabIndex = 24
        Me.txtMensaje.Text = "Mensaje"
        '
        'Bitacora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 374)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.dvgBitacora)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Bitacora"
        Me.Text = "Bitácora"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dvgBitacora, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents chkCriticidad As System.Windows.Forms.CheckBox
    Friend WithEvents chkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents chkUsuario As System.Windows.Forms.CheckBox
    Friend WithEvents txtMensaje As System.Windows.Forms.Label
End Class
