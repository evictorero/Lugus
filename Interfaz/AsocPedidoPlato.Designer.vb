<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsocPedidoPlato
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
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtid_pedido = New System.Windows.Forms.TextBox()
        Me.txtId_plato = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cbDescripcionPatente = New System.Windows.Forms.ComboBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(88, 78)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(52, 17)
        Me.lblEstado.TabIndex = 34
        Me.lblEstado.Text = "Estado"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(88, 39)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(82, 17)
        Me.lblDescripcion.TabIndex = 33
        Me.lblDescripcion.Text = "Descripcion"
        '
        'txtid_pedido
        '
        Me.txtid_pedido.Location = New System.Drawing.Point(70, 140)
        Me.txtid_pedido.Name = "txtid_pedido"
        Me.txtid_pedido.Size = New System.Drawing.Size(100, 22)
        Me.txtid_pedido.TabIndex = 32
        Me.txtid_pedido.Visible = False
        '
        'txtId_plato
        '
        Me.txtId_plato.Location = New System.Drawing.Point(70, 115)
        Me.txtId_plato.Name = "txtId_plato"
        Me.txtId_plato.Size = New System.Drawing.Size(100, 22)
        Me.txtId_plato.TabIndex = 31
        Me.txtId_plato.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(408, 131)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(109, 31)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(276, 131)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(109, 31)
        Me.btnGuardar.TabIndex = 28
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cbDescripcionPatente
        '
        Me.cbDescripcionPatente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescripcionPatente.FormattingEnabled = True
        Me.cbDescripcionPatente.Items.AddRange(New Object() {"Alta de Usuario", "Modificacion de Usuario", "Baja de Usuario"})
        Me.cbDescripcionPatente.Location = New System.Drawing.Point(230, 39)
        Me.cbDescripcionPatente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbDescripcionPatente.Name = "cbDescripcionPatente"
        Me.cbDescripcionPatente.Size = New System.Drawing.Size(365, 24)
        Me.cbDescripcionPatente.TabIndex = 27
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(230, 72)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(100, 22)
        Me.txtEstado.TabIndex = 35
        '
        'AsocPedidoPlato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 193)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtid_pedido)
        Me.Controls.Add(Me.txtId_plato)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cbDescripcionPatente)
        Me.Name = "AsocPedidoPlato"
        Me.Text = "AsocPedidoPlato"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblEstado As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents txtid_pedido As TextBox
    Friend WithEvents txtId_plato As TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents cbDescripcionPatente As ComboBox
    Friend WithEvents txtEstado As TextBox
End Class
