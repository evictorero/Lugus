<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BebidaABM
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
        Me.btnRehabiliatar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id_plato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion_corta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion_Larga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.habilitado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.fecha_baja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRehabiliatar
        '
        Me.btnRehabiliatar.Location = New System.Drawing.Point(418, 132)
        Me.btnRehabiliatar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRehabiliatar.Name = "btnRehabiliatar"
        Me.btnRehabiliatar.Size = New System.Drawing.Size(106, 31)
        Me.btnRehabiliatar.TabIndex = 21
        Me.btnRehabiliatar.Text = "Rehabilitar"
        Me.btnRehabiliatar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(308, 132)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(106, 31)
        Me.btnEliminar.TabIndex = 20
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(196, 132)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(106, 31)
        Me.btnModificar.TabIndex = 19
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(86, 132)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(106, 31)
        Me.btnNuevo.TabIndex = 18
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id_plato, Me.Descripcion_corta, Me.Descripcion_Larga, Me.habilitado, Me.fecha_baja})
        Me.DataGridView1.Location = New System.Drawing.Point(34, 21)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(549, 98)
        Me.DataGridView1.TabIndex = 22
        '
        'Id_plato
        '
        Me.Id_plato.HeaderText = "Codigo"
        Me.Id_plato.Name = "Id_plato"
        Me.Id_plato.ReadOnly = True
        '
        'Descripcion_corta
        '
        Me.Descripcion_corta.HeaderText = "Nombre"
        Me.Descripcion_corta.Name = "Descripcion_corta"
        Me.Descripcion_corta.ReadOnly = True
        '
        'Descripcion_Larga
        '
        Me.Descripcion_Larga.HeaderText = "Detalle"
        Me.Descripcion_Larga.Name = "Descripcion_Larga"
        Me.Descripcion_Larga.ReadOnly = True
        '
        'habilitado
        '
        Me.habilitado.HeaderText = "En carta"
        Me.habilitado.Name = "habilitado"
        Me.habilitado.ReadOnly = True
        '
        'fecha_baja
        '
        Me.fecha_baja.HeaderText = "Fecha Baja"
        Me.fecha_baja.Name = "fecha_baja"
        Me.fecha_baja.ReadOnly = True
        '
        'BebidaABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 180)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnRehabiliatar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "BebidaABM"
        Me.Text = "Bebida"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnRehabiliatar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Id_plato As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_corta As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_Larga As DataGridViewTextBoxColumn
    Friend WithEvents habilitado As DataGridViewCheckBoxColumn
    Friend WithEvents fecha_baja As DataGridViewTextBoxColumn
End Class
