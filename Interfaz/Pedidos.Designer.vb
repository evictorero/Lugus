<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pedidos
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
        Me.components = New System.ComponentModel.Container()
        Me.Bebidas = New System.Windows.Forms.GroupBox()
        Me.btnFinalizar_bebidas = New System.Windows.Forms.Button()
        Me.dgvBebidas = New System.Windows.Forms.DataGridView()
        Me.btnEnviar_bebidas = New System.Windows.Forms.Button()
        Me.btnEliminar_bebidas = New System.Windows.Forms.Button()
        Me.btnAgregar_bebidas = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnFinalizar_plato = New System.Windows.Forms.Button()
        Me.btnEnviar_plato = New System.Windows.Forms.Button()
        Me.btnEliminar_platos = New System.Windows.Forms.Button()
        Me.btnAgregar_Platos = New System.Windows.Forms.Button()
        Me.dgvPlatos = New System.Windows.Forms.DataGridView()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMesero = New System.Windows.Forms.TextBox()
        Me.btnEnviarTodo = New System.Windows.Forms.Button()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.btnReabrir = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Bebidas.SuspendLayout()
        CType(Me.dgvBebidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPlatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bebidas
        '
        Me.Bebidas.Controls.Add(Me.btnFinalizar_bebidas)
        Me.Bebidas.Controls.Add(Me.dgvBebidas)
        Me.Bebidas.Controls.Add(Me.btnEnviar_bebidas)
        Me.Bebidas.Controls.Add(Me.btnEliminar_bebidas)
        Me.Bebidas.Controls.Add(Me.btnAgregar_bebidas)
        Me.Bebidas.Location = New System.Drawing.Point(556, 179)
        Me.Bebidas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Bebidas.Name = "Bebidas"
        Me.Bebidas.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Bebidas.Size = New System.Drawing.Size(504, 242)
        Me.Bebidas.TabIndex = 18
        Me.Bebidas.TabStop = False
        Me.Bebidas.Text = "Bebidas"
        '
        'btnFinalizar_bebidas
        '
        Me.btnFinalizar_bebidas.Location = New System.Drawing.Point(413, 112)
        Me.btnFinalizar_bebidas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFinalizar_bebidas.Name = "btnFinalizar_bebidas"
        Me.btnFinalizar_bebidas.Size = New System.Drawing.Size(84, 31)
        Me.btnFinalizar_bebidas.TabIndex = 12
        Me.btnFinalizar_bebidas.Text = "Finalizar"
        Me.btnFinalizar_bebidas.UseVisualStyleBackColor = True
        '
        'dgvBebidas
        '
        Me.dgvBebidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBebidas.Location = New System.Drawing.Point(12, 30)
        Me.dgvBebidas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvBebidas.Name = "dgvBebidas"
        Me.dgvBebidas.ReadOnly = True
        Me.dgvBebidas.RowTemplate.Height = 28
        Me.dgvBebidas.Size = New System.Drawing.Size(391, 191)
        Me.dgvBebidas.TabIndex = 0
        '
        'btnEnviar_bebidas
        '
        Me.btnEnviar_bebidas.Location = New System.Drawing.Point(413, 76)
        Me.btnEnviar_bebidas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEnviar_bebidas.Name = "btnEnviar_bebidas"
        Me.btnEnviar_bebidas.Size = New System.Drawing.Size(84, 31)
        Me.btnEnviar_bebidas.TabIndex = 11
        Me.btnEnviar_bebidas.Text = "Enviar"
        Me.btnEnviar_bebidas.UseVisualStyleBackColor = True
        '
        'btnEliminar_bebidas
        '
        Me.btnEliminar_bebidas.Location = New System.Drawing.Point(413, 148)
        Me.btnEliminar_bebidas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar_bebidas.Name = "btnEliminar_bebidas"
        Me.btnEliminar_bebidas.Size = New System.Drawing.Size(84, 31)
        Me.btnEliminar_bebidas.TabIndex = 10
        Me.btnEliminar_bebidas.Text = "Eliminar"
        Me.btnEliminar_bebidas.UseVisualStyleBackColor = True
        '
        'btnAgregar_bebidas
        '
        Me.btnAgregar_bebidas.Location = New System.Drawing.Point(413, 39)
        Me.btnAgregar_bebidas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregar_bebidas.Name = "btnAgregar_bebidas"
        Me.btnAgregar_bebidas.Size = New System.Drawing.Size(84, 31)
        Me.btnAgregar_bebidas.TabIndex = 9
        Me.btnAgregar_bebidas.Text = "Agregar"
        Me.btnAgregar_bebidas.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(799, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 17)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Código"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnFinalizar_plato)
        Me.GroupBox2.Controls.Add(Me.btnEnviar_plato)
        Me.GroupBox2.Controls.Add(Me.btnEliminar_platos)
        Me.GroupBox2.Controls.Add(Me.btnAgregar_Platos)
        Me.GroupBox2.Controls.Add(Me.dgvPlatos)
        Me.GroupBox2.Location = New System.Drawing.Point(37, 179)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(513, 242)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Platos"
        '
        'btnFinalizar_plato
        '
        Me.btnFinalizar_plato.Location = New System.Drawing.Point(409, 112)
        Me.btnFinalizar_plato.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFinalizar_plato.Name = "btnFinalizar_plato"
        Me.btnFinalizar_plato.Size = New System.Drawing.Size(84, 31)
        Me.btnFinalizar_plato.TabIndex = 8
        Me.btnFinalizar_plato.Text = "Finalizar"
        Me.btnFinalizar_plato.UseVisualStyleBackColor = True
        '
        'btnEnviar_plato
        '
        Me.btnEnviar_plato.Location = New System.Drawing.Point(409, 76)
        Me.btnEnviar_plato.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEnviar_plato.Name = "btnEnviar_plato"
        Me.btnEnviar_plato.Size = New System.Drawing.Size(84, 31)
        Me.btnEnviar_plato.TabIndex = 7
        Me.btnEnviar_plato.Text = "Enviar"
        Me.btnEnviar_plato.UseVisualStyleBackColor = True
        '
        'btnEliminar_platos
        '
        Me.btnEliminar_platos.Location = New System.Drawing.Point(409, 148)
        Me.btnEliminar_platos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar_platos.Name = "btnEliminar_platos"
        Me.btnEliminar_platos.Size = New System.Drawing.Size(84, 31)
        Me.btnEliminar_platos.TabIndex = 6
        Me.btnEliminar_platos.Text = "Eliminar"
        Me.btnEliminar_platos.UseVisualStyleBackColor = True
        '
        'btnAgregar_Platos
        '
        Me.btnAgregar_Platos.Location = New System.Drawing.Point(409, 39)
        Me.btnAgregar_Platos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregar_Platos.Name = "btnAgregar_Platos"
        Me.btnAgregar_Platos.Size = New System.Drawing.Size(84, 31)
        Me.btnAgregar_Platos.TabIndex = 4
        Me.btnAgregar_Platos.Text = "Agregar"
        Me.btnAgregar_Platos.UseVisualStyleBackColor = True
        '
        'dgvPlatos
        '
        Me.dgvPlatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPlatos.Location = New System.Drawing.Point(12, 30)
        Me.dgvPlatos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvPlatos.Name = "dgvPlatos"
        Me.dgvPlatos.ReadOnly = True
        Me.dgvPlatos.RowTemplate.Height = 28
        Me.dgvPlatos.Size = New System.Drawing.Size(391, 191)
        Me.dgvPlatos.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(754, 450)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(109, 31)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(254, 450)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(109, 31)
        Me.btnGuardar.TabIndex = 14
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(64, 46)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(724, 113)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Cantidad de comensales"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Observación"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(225, 62)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(171, 22)
        Me.txtCantidad.TabIndex = 4
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(127, 21)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(576, 22)
        Me.txtDescripcion.TabIndex = 1
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(885, 81)
        Me.txtEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(119, 22)
        Me.txtEstado.TabIndex = 13
        Me.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(797, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Estado"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(885, 51)
        Me.txtId.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(119, 22)
        Me.txtId.TabIndex = 17
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(799, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Mesero"
        '
        'txtMesero
        '
        Me.txtMesero.Location = New System.Drawing.Point(885, 115)
        Me.txtMesero.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMesero.Name = "txtMesero"
        Me.txtMesero.ReadOnly = True
        Me.txtMesero.Size = New System.Drawing.Size(119, 22)
        Me.txtMesero.TabIndex = 21
        Me.txtMesero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnEnviarTodo
        '
        Me.btnEnviarTodo.Location = New System.Drawing.Point(381, 450)
        Me.btnEnviarTodo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEnviarTodo.Name = "btnEnviarTodo"
        Me.btnEnviarTodo.Size = New System.Drawing.Size(109, 31)
        Me.btnEnviarTodo.TabIndex = 22
        Me.btnEnviarTodo.Text = "Enviar todo"
        Me.btnEnviarTodo.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Location = New System.Drawing.Point(508, 450)
        Me.btnFinalizar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(109, 31)
        Me.btnFinalizar.TabIndex = 23
        Me.btnFinalizar.Text = "Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'btnReabrir
        '
        Me.btnReabrir.Location = New System.Drawing.Point(630, 450)
        Me.btnReabrir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnReabrir.Name = "btnReabrir"
        Me.btnReabrir.Size = New System.Drawing.Size(109, 31)
        Me.btnReabrir.TabIndex = 24
        Me.btnReabrir.Text = "Reabrir"
        Me.btnReabrir.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(67, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(68, 17)
        Me.lblTitulo.TabIndex = 25
        Me.lblTitulo.Text = "Mensaje"
        '
        'Pedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 534)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnReabrir)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnEnviarTodo)
        Me.Controls.Add(Me.txtMesero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.Bebidas)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtId)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Pedidos"
        Me.Text = "Pedido"
        Me.Bebidas.ResumeLayout(False)
        CType(Me.dgvBebidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvPlatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Bebidas As GroupBox
    Friend WithEvents dgvBebidas As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnEliminar_platos As Button
    Friend WithEvents btnAgregar_Platos As Button
    Friend WithEvents dgvPlatos As DataGridView
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMesero As TextBox
    Friend WithEvents btnFinalizar_bebidas As Button
    Friend WithEvents btnEnviar_bebidas As Button
    Friend WithEvents btnEliminar_bebidas As Button
    Friend WithEvents btnAgregar_bebidas As Button
    Friend WithEvents btnFinalizar_plato As Button
    Friend WithEvents btnEnviar_plato As Button
    Friend WithEvents btnEnviarTodo As Button
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents btnReabrir As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
