<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsocPedidoBebida
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
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtid_pedido = New System.Windows.Forms.TextBox()
        Me.txtId_bebida = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cbDescripcionBebida = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(255, 79)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(100, 22)
        Me.txtEstado.TabIndex = 43
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(113, 85)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(52, 17)
        Me.lblEstado.TabIndex = 42
        Me.lblEstado.Text = "Estado"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(113, 46)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(82, 17)
        Me.lblDescripcion.TabIndex = 41
        Me.lblDescripcion.Text = "Descripcion"
        '
        'txtid_pedido
        '
        Me.txtid_pedido.Location = New System.Drawing.Point(95, 147)
        Me.txtid_pedido.Name = "txtid_pedido"
        Me.txtid_pedido.Size = New System.Drawing.Size(100, 22)
        Me.txtid_pedido.TabIndex = 40
        Me.txtid_pedido.Visible = False
        '
        'txtId_bebida
        '
        Me.txtId_bebida.Location = New System.Drawing.Point(95, 122)
        Me.txtId_bebida.Name = "txtId_bebida"
        Me.txtId_bebida.Size = New System.Drawing.Size(100, 22)
        Me.txtId_bebida.TabIndex = 39
        Me.txtId_bebida.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(433, 138)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(109, 31)
        Me.btnCancelar.TabIndex = 38
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(301, 138)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(109, 31)
        Me.btnGuardar.TabIndex = 37
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cbDescripcionBebida
        '
        Me.cbDescripcionBebida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescripcionBebida.FormattingEnabled = True
        Me.cbDescripcionBebida.Items.AddRange(New Object() {"Alta de Usuario", "Modificacion de Usuario", "Baja de Usuario"})
        Me.cbDescripcionBebida.Location = New System.Drawing.Point(255, 46)
        Me.cbDescripcionBebida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbDescripcionBebida.Name = "cbDescripcionBebida"
        Me.cbDescripcionBebida.Size = New System.Drawing.Size(365, 24)
        Me.cbDescripcionBebida.TabIndex = 36
        '
        'AsocPedidoBebida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 215)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtid_pedido)
        Me.Controls.Add(Me.txtId_bebida)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cbDescripcionBebida)
        Me.Name = "AsocPedidoBebida"
        Me.Text = "AsocPedidoBebida"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtEstado As TextBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents txtid_pedido As TextBox
    Friend WithEvents txtId_bebida As TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents cbDescripcionBebida As ComboBox
End Class
