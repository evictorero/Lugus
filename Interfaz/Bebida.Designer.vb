<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bebida
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
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtId_bebida = New System.Windows.Forms.TextBox()
        Me.txtDescripcion_corta = New System.Windows.Forms.TextBox()
        Me.txtDescripcion_larga = New System.Windows.Forms.TextBox()
        Me.cboxHabilitado = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFecha_baja = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(271, 273)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(109, 31)
        Me.btnCancelar.TabIndex = 20
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(139, 273)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(109, 31)
        Me.btnGuardar.TabIndex = 19
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(36, 38)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(68, 17)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Mensaje"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Detalle"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "En carta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha de baja"
        '
        'txtId_bebida
        '
        Me.txtId_bebida.Location = New System.Drawing.Point(131, 34)
        Me.txtId_bebida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtId_bebida.Name = "txtId_bebida"
        Me.txtId_bebida.ReadOnly = True
        Me.txtId_bebida.Size = New System.Drawing.Size(89, 22)
        Me.txtId_bebida.TabIndex = 6
        Me.txtId_bebida.Visible = False
        '
        'txtDescripcion_corta
        '
        Me.txtDescripcion_corta.Location = New System.Drawing.Point(131, 70)
        Me.txtDescripcion_corta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDescripcion_corta.MaxLength = 30
        Me.txtDescripcion_corta.Name = "txtDescripcion_corta"
        Me.txtDescripcion_corta.Size = New System.Drawing.Size(296, 22)
        Me.txtDescripcion_corta.TabIndex = 7
        '
        'txtDescripcion_larga
        '
        Me.txtDescripcion_larga.Location = New System.Drawing.Point(131, 102)
        Me.txtDescripcion_larga.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDescripcion_larga.MaxLength = 200
        Me.txtDescripcion_larga.Name = "txtDescripcion_larga"
        Me.txtDescripcion_larga.Size = New System.Drawing.Size(296, 22)
        Me.txtDescripcion_larga.TabIndex = 8
        '
        'cboxHabilitado
        '
        Me.cboxHabilitado.FormattingEnabled = True
        Me.cboxHabilitado.Items.AddRange(New Object() {"S", "N"})
        Me.cboxHabilitado.Location = New System.Drawing.Point(131, 138)
        Me.cboxHabilitado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboxHabilitado.Name = "cboxHabilitado"
        Me.cboxHabilitado.Size = New System.Drawing.Size(108, 24)
        Me.cboxHabilitado.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFecha_baja)
        Me.GroupBox1.Controls.Add(Me.cboxHabilitado)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion_larga)
        Me.GroupBox1.Controls.Add(Me.txtId_bebida)
        Me.GroupBox1.Controls.Add(Me.lblTitulo)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion_corta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 28)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(481, 218)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'txtFecha_baja
        '
        Me.txtFecha_baja.Location = New System.Drawing.Point(131, 176)
        Me.txtFecha_baja.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFecha_baja.Name = "txtFecha_baja"
        Me.txtFecha_baja.Size = New System.Drawing.Size(132, 22)
        Me.txtFecha_baja.TabIndex = 10
        '
        'Bebida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 325)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Bebida"
        Me.Text = "Bebida"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtId_bebida As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion_corta As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion_larga As System.Windows.Forms.TextBox
    Friend WithEvents cboxHabilitado As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha_baja As System.Windows.Forms.TextBox
End Class
