<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlatosABM
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(638, 207)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 48)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Rehabilitar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(472, 207)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(160, 48)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Eliminar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(306, 207)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(160, 48)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Modificar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(140, 207)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(160, 48)
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id_plato, Me.Descripcion_corta, Me.Descripcion_Larga, Me.habilitado, Me.fecha_baja})
        Me.DataGridView1.Location = New System.Drawing.Point(77, 38)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(824, 150)
        Me.DataGridView1.TabIndex = 11
        '
        'Id_plato
        '
        Me.Id_plato.HeaderText = "Codigo"
        Me.Id_plato.Name = "Id_plato"
        '
        'Descripcion_corta
        '
        Me.Descripcion_corta.HeaderText = "Nombre"
        Me.Descripcion_corta.Name = "Descripcion_corta"
        '
        'Descripcion_Larga
        '
        Me.Descripcion_Larga.HeaderText = "Detalle"
        Me.Descripcion_Larga.Name = "Descripcion_Larga"
        '
        'habilitado
        '
        Me.habilitado.HeaderText = "En carta"
        Me.habilitado.Name = "habilitado"
        '
        'fecha_baja
        '
        Me.fecha_baja.HeaderText = "Fecha Baja"
        Me.fecha_baja.Name = "fecha_baja"
        '
        'PlatosABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 282)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnNuevo)
        Me.Name = "PlatosABM"
        Me.Text = "Platos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Id_plato As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_corta As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_Larga As DataGridViewTextBoxColumn
    Friend WithEvents habilitado As DataGridViewCheckBoxColumn
    Friend WithEvents fecha_baja As DataGridViewTextBoxColumn
End Class
