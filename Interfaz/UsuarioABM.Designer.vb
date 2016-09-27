<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsuarioABM
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
        Me.dgv_Usuarios = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DNI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaBaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnRehabilitar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.btnBlanquear = New System.Windows.Forms.Button()
        CType(Me.dgv_Usuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Usuarios
        '
        Me.dgv_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Usuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Usuario, Me.Nombre, Me.Apellido, Me.DNI, Me.FechaBaja})
        Me.dgv_Usuarios.Location = New System.Drawing.Point(29, 28)
        Me.dgv_Usuarios.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgv_Usuarios.Name = "dgv_Usuarios"
        Me.dgv_Usuarios.ReadOnly = True
        Me.dgv_Usuarios.RowTemplate.Height = 28
        Me.dgv_Usuarios.Size = New System.Drawing.Size(859, 502)
        Me.dgv_Usuarios.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Código"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        '
        'Usuario
        '
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Apellido
        '
        Me.Apellido.HeaderText = "Apellido"
        Me.Apellido.Name = "Apellido"
        Me.Apellido.ReadOnly = True
        '
        'DNI
        '
        Me.DNI.HeaderText = "DNI"
        Me.DNI.Name = "DNI"
        Me.DNI.ReadOnly = True
        '
        'FechaBaja
        '
        Me.FechaBaja.HeaderText = "Fecha de baja"
        Me.FechaBaja.Name = "FechaBaja"
        Me.FechaBaja.ReadOnly = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(240, 551)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(141, 38)
        Me.btnModificar.TabIndex = 2
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(387, 551)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(141, 38)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnRehabilitar
        '
        Me.btnRehabilitar.Location = New System.Drawing.Point(535, 551)
        Me.btnRehabilitar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRehabilitar.Name = "btnRehabilitar"
        Me.btnRehabilitar.Size = New System.Drawing.Size(141, 38)
        Me.btnRehabilitar.TabIndex = 5
        Me.btnRehabilitar.Text = "Rehabilitar"
        Me.btnRehabilitar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(92, 551)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(141, 38)
        Me.btnNuevo.TabIndex = 1
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnBlanquear
        '
        Me.btnBlanquear.Location = New System.Drawing.Point(683, 551)
        Me.btnBlanquear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBlanquear.Name = "btnBlanquear"
        Me.btnBlanquear.Size = New System.Drawing.Size(141, 38)
        Me.btnBlanquear.TabIndex = 6
        Me.btnBlanquear.Text = "Blanquear Clave"
        Me.btnBlanquear.UseVisualStyleBackColor = True
        '
        'UsuarioABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 626)
        Me.Controls.Add(Me.btnBlanquear)
        Me.Controls.Add(Me.btnRehabilitar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.dgv_Usuarios)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "UsuarioABM"
        Me.Text = "Usuarios"
        CType(Me.dgv_Usuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_Usuarios As DataGridView
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnRehabilitar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnBlanquear As Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Apellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DNI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaBaja As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
