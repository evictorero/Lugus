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
        Me.dgvFamilias = New System.Windows.Forms.DataGridView()
        Me.btnRehabilitar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtMensaje = New System.Windows.Forms.Label()
        CType(Me.dgvFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFamilias
        '
        Me.dgvFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFamilias.Location = New System.Drawing.Point(69, 42)
        Me.dgvFamilias.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvFamilias.Name = "dgvFamilias"
        Me.dgvFamilias.ReadOnly = True
        Me.dgvFamilias.RowTemplate.Height = 28
        Me.dgvFamilias.Size = New System.Drawing.Size(732, 391)
        Me.dgvFamilias.TabIndex = 27
        '
        'btnRehabilitar
        '
        Me.btnRehabilitar.Location = New System.Drawing.Point(583, 448)
        Me.btnRehabilitar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRehabilitar.Name = "btnRehabilitar"
        Me.btnRehabilitar.Size = New System.Drawing.Size(141, 38)
        Me.btnRehabilitar.TabIndex = 26
        Me.btnRehabilitar.Text = "Rehabilitar"
        Me.btnRehabilitar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(437, 448)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(141, 38)
        Me.btnEliminar.TabIndex = 25
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(290, 448)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(141, 38)
        Me.btnModificar.TabIndex = 24
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(141, 448)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(141, 38)
        Me.btnNuevo.TabIndex = 23
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtMensaje
        '
        Me.txtMensaje.AutoSize = True
        Me.txtMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.Location = New System.Drawing.Point(40, 23)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(0, 17)
        Me.txtMensaje.TabIndex = 28
        '
        'FamiliaABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 531)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.dgvFamilias)
        Me.Controls.Add(Me.btnRehabilitar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FamiliaABM"
        Me.Text = "Familia"
        CType(Me.dgvFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvFamilias As DataGridView
    Friend WithEvents btnRehabilitar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents txtMensaje As Label
End Class
