<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PatenteABM
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Id_plato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion_corta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion_Larga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_baja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id_plato, Me.Descripcion_corta, Me.Descripcion_Larga, Me.fecha_baja})
        Me.DataGridView1.Location = New System.Drawing.Point(20, 23)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(547, 98)
        Me.DataGridView1.TabIndex = 32
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(404, 132)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 31)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "Rehabilitar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(292, 132)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 31)
        Me.Button3.TabIndex = 30
        Me.Button3.Text = "Eliminar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(182, 132)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(106, 31)
        Me.btnModificar.TabIndex = 29
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(71, 132)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(106, 31)
        Me.btnNuevo.TabIndex = 28
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Id_plato
        '
        Me.Id_plato.HeaderText = "Código"
        Me.Id_plato.Name = "Id_plato"
        Me.Id_plato.ReadOnly = True
        Me.Id_plato.Width = 50
        '
        'Descripcion_corta
        '
        Me.Descripcion_corta.HeaderText = "Descripción corta"
        Me.Descripcion_corta.Name = "Descripcion_corta"
        Me.Descripcion_corta.ReadOnly = True
        '
        'Descripcion_Larga
        '
        Me.Descripcion_Larga.HeaderText = "Descripción larga"
        Me.Descripcion_Larga.Name = "Descripcion_Larga"
        Me.Descripcion_Larga.ReadOnly = True
        Me.Descripcion_Larga.Width = 300
        '
        'fecha_baja
        '
        Me.fecha_baja.HeaderText = "Fecha de baja"
        Me.fecha_baja.Name = "fecha_baja"
        Me.fecha_baja.ReadOnly = True
        Me.fecha_baja.Width = 50
        '
        'PatenteABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 182)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "PatenteABM"
        Me.Text = "Patente"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents Id_plato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_corta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_Larga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_baja As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
