<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuario
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
        Me.txtFecha_Nacimiento = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtdni = New System.Windows.Forms.TextBox()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnEliminarPatente = New System.Windows.Forms.Button()
        Me.btnAgregarPatente = New System.Windows.Forms.Button()
        Me.dgvPatentes = New System.Windows.Forms.DataGridView()
        Me.Cod_Patente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnEliminarFamilia = New System.Windows.Forms.Button()
        Me.btnAgregarFamilia = New System.Windows.Forms.Button()
        Me.dgvFamilias = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPatentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFecha_Nacimiento)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.txtdni)
        Me.GroupBox1.Controls.Add(Me.txtApellido)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(702, 222)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Personales"
        '
        'txtFecha_Nacimiento
        '
        Me.txtFecha_Nacimiento.Location = New System.Drawing.Point(593, 143)
        Me.txtFecha_Nacimiento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFecha_Nacimiento.Name = "txtFecha_Nacimiento"
        Me.txtFecha_Nacimiento.Size = New System.Drawing.Size(89, 22)
        Me.txtFecha_Nacimiento.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(480, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "F.Nacimiento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "email"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "DNI"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Apellido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Usuario"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(107, 181)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(576, 22)
        Me.txtEmail.TabIndex = 5
        '
        'txtdni
        '
        Me.txtdni.Location = New System.Drawing.Point(107, 146)
        Me.txtdni.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtdni.Name = "txtdni"
        Me.txtdni.Size = New System.Drawing.Size(171, 22)
        Me.txtdni.TabIndex = 4
        '
        'txtApellido
        '
        Me.txtApellido.Location = New System.Drawing.Point(107, 108)
        Me.txtApellido.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(576, 22)
        Me.txtApellido.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(107, 74)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(576, 22)
        Me.txtNombre.TabIndex = 1
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(107, 38)
        Me.txtUsuario.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUsuario.MaxLength = 10
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(171, 22)
        Me.txtUsuario.TabIndex = 0
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(910, 51)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(89, 22)
        Me.TextBox4.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(837, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Codigo"
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(416, 480)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(110, 31)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(548, 480)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(110, 31)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnEliminarPatente)
        Me.GroupBox2.Controls.Add(Me.btnAgregarPatente)
        Me.GroupBox2.Controls.Add(Me.dgvPatentes)
        Me.GroupBox2.Location = New System.Drawing.Point(23, 245)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(504, 209)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Patentes"
        '
        'btnEliminarPatente
        '
        Me.btnEliminarPatente.Location = New System.Drawing.Point(412, 120)
        Me.btnEliminarPatente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminarPatente.Name = "btnEliminarPatente"
        Me.btnEliminarPatente.Size = New System.Drawing.Size(84, 31)
        Me.btnEliminarPatente.TabIndex = 6
        Me.btnEliminarPatente.Text = "Eliminar"
        Me.btnEliminarPatente.UseVisualStyleBackColor = True
        '
        'btnAgregarPatente
        '
        Me.btnAgregarPatente.Location = New System.Drawing.Point(412, 75)
        Me.btnAgregarPatente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregarPatente.Name = "btnAgregarPatente"
        Me.btnAgregarPatente.Size = New System.Drawing.Size(84, 31)
        Me.btnAgregarPatente.TabIndex = 4
        Me.btnAgregarPatente.Text = "Agregar"
        Me.btnAgregarPatente.UseVisualStyleBackColor = True
        '
        'dgvPatentes
        '
        Me.dgvPatentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPatentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Patente, Me.Descripcion})
        Me.dgvPatentes.Location = New System.Drawing.Point(12, 30)
        Me.dgvPatentes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvPatentes.Name = "dgvPatentes"
        Me.dgvPatentes.ReadOnly = True
        Me.dgvPatentes.RowTemplate.Height = 28
        Me.dgvPatentes.Size = New System.Drawing.Size(391, 158)
        Me.dgvPatentes.TabIndex = 0
        '
        'Cod_Patente
        '
        Me.Cod_Patente.HeaderText = "Patente"
        Me.Cod_Patente.Name = "Cod_Patente"
        Me.Cod_Patente.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 150
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnEliminarFamilia)
        Me.GroupBox3.Controls.Add(Me.btnAgregarFamilia)
        Me.GroupBox3.Controls.Add(Me.dgvFamilias)
        Me.GroupBox3.Location = New System.Drawing.Point(542, 245)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(504, 209)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Familias"
        '
        'btnEliminarFamilia
        '
        Me.btnEliminarFamilia.Location = New System.Drawing.Point(409, 120)
        Me.btnEliminarFamilia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminarFamilia.Name = "btnEliminarFamilia"
        Me.btnEliminarFamilia.Size = New System.Drawing.Size(84, 31)
        Me.btnEliminarFamilia.TabIndex = 6
        Me.btnEliminarFamilia.Text = "Eliminar"
        Me.btnEliminarFamilia.UseVisualStyleBackColor = True
        '
        'btnAgregarFamilia
        '
        Me.btnAgregarFamilia.Location = New System.Drawing.Point(409, 75)
        Me.btnAgregarFamilia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregarFamilia.Name = "btnAgregarFamilia"
        Me.btnAgregarFamilia.Size = New System.Drawing.Size(84, 31)
        Me.btnAgregarFamilia.TabIndex = 4
        Me.btnAgregarFamilia.Text = "Agregar"
        Me.btnAgregarFamilia.UseVisualStyleBackColor = True
        '
        'dgvFamilias
        '
        Me.dgvFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFamilias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvFamilias.Location = New System.Drawing.Point(12, 30)
        Me.dgvFamilias.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvFamilias.Name = "dgvFamilias"
        Me.dgvFamilias.ReadOnly = True
        Me.dgvFamilias.RowTemplate.Height = 28
        Me.dgvFamilias.Size = New System.Drawing.Size(391, 158)
        Me.dgvFamilias.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Familia"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'Usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 527)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextBox4)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Usuario"
        Me.Text = "Usuario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvPatentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFecha_Nacimiento As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtdni As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnEliminarPatente As Button
    Friend WithEvents btnAgregarPatente As Button
    Friend WithEvents dgvPatentes As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnEliminarFamilia As Button
    Friend WithEvents btnAgregarFamilia As Button
    Friend WithEvents dgvFamilias As DataGridView
    Friend WithEvents Cod_Patente As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
End Class
