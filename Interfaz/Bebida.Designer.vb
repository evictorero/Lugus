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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtId_bebida = New System.Windows.Forms.TextBox()
        Me.txtDescripcion_corta = New System.Windows.Forms.TextBox()
        Me.txtDescripcion_larga = New System.Windows.Forms.TextBox()
        Me.cboxHabilitado = New System.Windows.Forms.ComboBox()
        Me.txtFecha_Baja = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(203, 222)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(82, 25)
        Me.btnCancelar.TabIndex = 20
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(104, 222)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(82, 25)
        Me.btnGuardar.TabIndex = 19
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 87)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Detalle"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 118)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "En carta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 146)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha Baja"
        '
        'txtId_bebida
        '
        Me.txtId_bebida.Location = New System.Drawing.Point(98, 28)
        Me.txtId_bebida.Margin = New System.Windows.Forms.Padding(2)
        Me.txtId_bebida.Name = "txtId_bebida"
        Me.txtId_bebida.ReadOnly = True
        Me.txtId_bebida.Size = New System.Drawing.Size(68, 20)
        Me.txtId_bebida.TabIndex = 6
        '
        'txtDescripcion_corta
        '
        Me.txtDescripcion_corta.Location = New System.Drawing.Point(98, 57)
        Me.txtDescripcion_corta.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescripcion_corta.MaxLength = 30
        Me.txtDescripcion_corta.Name = "txtDescripcion_corta"
        Me.txtDescripcion_corta.Size = New System.Drawing.Size(223, 20)
        Me.txtDescripcion_corta.TabIndex = 7
        '
        'txtDescripcion_larga
        '
        Me.txtDescripcion_larga.Location = New System.Drawing.Point(98, 83)
        Me.txtDescripcion_larga.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescripcion_larga.MaxLength = 200
        Me.txtDescripcion_larga.Name = "txtDescripcion_larga"
        Me.txtDescripcion_larga.Size = New System.Drawing.Size(223, 20)
        Me.txtDescripcion_larga.TabIndex = 8
        '
        'cboxHabilitado
        '
        Me.cboxHabilitado.FormattingEnabled = True
        Me.cboxHabilitado.Location = New System.Drawing.Point(98, 112)
        Me.cboxHabilitado.Margin = New System.Windows.Forms.Padding(2)
        Me.cboxHabilitado.Name = "cboxHabilitado"
        Me.cboxHabilitado.Size = New System.Drawing.Size(82, 21)
        Me.cboxHabilitado.TabIndex = 9
        '
        'txtFecha_Baja
        '
        Me.txtFecha_Baja.Location = New System.Drawing.Point(98, 141)
        Me.txtFecha_Baja.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFecha_Baja.Name = "txtFecha_Baja"
        Me.txtFecha_Baja.Size = New System.Drawing.Size(82, 20)
        Me.txtFecha_Baja.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFecha_Baja)
        Me.GroupBox1.Controls.Add(Me.cboxHabilitado)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion_larga)
        Me.GroupBox1.Controls.Add(Me.txtId_bebida)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion_corta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 23)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(361, 195)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'Bebida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 264)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Bebida"
        Me.Text = "Bebida"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtId_bebida As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion_corta As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion_larga As System.Windows.Forms.TextBox
    Friend WithEvents cboxHabilitado As System.Windows.Forms.ComboBox
    Friend WithEvents txtFecha_Baja As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
