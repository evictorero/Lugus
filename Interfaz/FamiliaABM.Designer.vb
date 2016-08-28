<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FamiliaABM
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id_plato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion_corta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion_Larga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_baja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRehabilitar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id_plato, Me.Descripcion_corta, Me.Descripcion_Larga, Me.fecha_baja})
        Me.DataGridView1.Location = New System.Drawing.Point(42, 23)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(732, 120)
        Me.DataGridView1.TabIndex = 27
        '
        'Id_plato
        '
        Me.Id_plato.HeaderText = "Codigo"
        Me.Id_plato.Name = "Id_plato"
        Me.Id_plato.ReadOnly = True
        Me.Id_plato.Width = 50
        '
        'Descripcion_corta
        '
        Me.Descripcion_corta.HeaderText = "Descripcion Corta"
        Me.Descripcion_corta.Name = "Descripcion_corta"
        Me.Descripcion_corta.ReadOnly = True
        '
        'Descripcion_Larga
        '
        Me.Descripcion_Larga.HeaderText = "Descripcion Larga"
        Me.Descripcion_Larga.Name = "Descripcion_Larga"
        Me.Descripcion_Larga.ReadOnly = True
        Me.Descripcion_Larga.Width = 300
        '
        'fecha_baja
        '
        Me.fecha_baja.HeaderText = "Fecha Baja"
        Me.fecha_baja.Name = "fecha_baja"
        Me.fecha_baja.ReadOnly = True
        Me.fecha_baja.Width = 50
        '
        'btnRehabilitar
        '
        Me.btnRehabilitar.Location = New System.Drawing.Point(557, 159)
        Me.btnRehabilitar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRehabilitar.Name = "btnRehabilitar"
        Me.btnRehabilitar.Size = New System.Drawing.Size(142, 38)
        Me.btnRehabilitar.TabIndex = 26
        Me.btnRehabilitar.Text = "Rehabilitar"
        Me.btnRehabilitar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(410, 159)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(142, 38)
        Me.btnEliminar.TabIndex = 25
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(262, 159)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(142, 38)
        Me.btnModificar.TabIndex = 24
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(115, 159)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(142, 38)
        Me.btnNuevo.TabIndex = 23
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'FamiliaABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 218)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnRehabilitar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FamiliaABM"
        Me.Text = "Familia"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnRehabilitar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents Id_plato As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_corta As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_Larga As DataGridViewTextBoxColumn
    Friend WithEvents fecha_baja As DataGridViewTextBoxColumn
End Class
