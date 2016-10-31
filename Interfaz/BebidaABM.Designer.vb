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
        Me.btnRehabilitar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.dgvBebidas = New System.Windows.Forms.DataGridView()
        Me.txtMensaje = New System.Windows.Forms.Label()
        CType(Me.dgvBebidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRehabilitar
        '
        Me.btnRehabilitar.Location = New System.Drawing.Point(559, 384)
        Me.btnRehabilitar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRehabilitar.Name = "btnRehabilitar"
        Me.btnRehabilitar.Size = New System.Drawing.Size(141, 38)
        Me.btnRehabilitar.TabIndex = 21
        Me.btnRehabilitar.Text = "Rehabilitar"
        Me.btnRehabilitar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(412, 384)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(141, 38)
        Me.btnEliminar.TabIndex = 20
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(263, 384)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(141, 38)
        Me.btnModificar.TabIndex = 19
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(116, 384)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(141, 38)
        Me.btnNuevo.TabIndex = 18
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'dgvBebidas
        '
        Me.dgvBebidas.AllowUserToResizeColumns = False
        Me.dgvBebidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBebidas.Location = New System.Drawing.Point(45, 43)
        Me.dgvBebidas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvBebidas.Name = "dgvBebidas"
        Me.dgvBebidas.ReadOnly = True
        Me.dgvBebidas.RowTemplate.Height = 28
        Me.dgvBebidas.Size = New System.Drawing.Size(732, 321)
        Me.dgvBebidas.TabIndex = 22
        '
        'txtMensaje
        '
        Me.txtMensaje.AutoSize = True
        Me.txtMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.Location = New System.Drawing.Point(45, 13)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(68, 17)
        Me.txtMensaje.TabIndex = 23
        Me.txtMensaje.Text = "Mensaje"
        '
        'BebidaABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 448)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.dgvBebidas)
        Me.Controls.Add(Me.btnRehabilitar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "BebidaABM"
        Me.Text = "Bebida"
        CType(Me.dgvBebidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRehabilitar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents dgvBebidas As DataGridView
    Friend WithEvents txtMensaje As Label
End Class
