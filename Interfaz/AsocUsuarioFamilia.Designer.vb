<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AsocUsuarioFamilia
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDescripcionFamilia = New System.Windows.Forms.ComboBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtid_usuario = New System.Windows.Forms.TextBox()
        Me.txtId_familia = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Descripcion"
        '
        'cbDescripcionFamilia
        '
        Me.cbDescripcionFamilia.FormattingEnabled = True
        Me.cbDescripcionFamilia.Items.AddRange(New Object() {"Alta de Usuario", "Modificacion de Usuario", "Baja de Usuario"})
        Me.cbDescripcionFamilia.Location = New System.Drawing.Point(164, 22)
        Me.cbDescripcionFamilia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbDescripcionFamilia.Name = "cbDescripcionFamilia"
        Me.cbDescripcionFamilia.Size = New System.Drawing.Size(365, 24)
        Me.cbDescripcionFamilia.TabIndex = 5
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(72, 42)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(82, 17)
        Me.lblDescripcion.TabIndex = 30
        Me.lblDescripcion.Text = "Descripcion"
        '
        'txtid_usuario
        '
        Me.txtid_usuario.Location = New System.Drawing.Point(85, 104)
        Me.txtid_usuario.Name = "txtid_usuario"
        Me.txtid_usuario.Size = New System.Drawing.Size(100, 22)
        Me.txtid_usuario.TabIndex = 29
        Me.txtid_usuario.Visible = False
        '
        'txtId_familia
        '
        Me.txtId_familia.Location = New System.Drawing.Point(85, 79)
        Me.txtId_familia.Name = "txtId_familia"
        Me.txtId_familia.Size = New System.Drawing.Size(100, 22)
        Me.txtId_familia.TabIndex = 28
        Me.txtId_familia.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(374, 79)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(109, 31)
        Me.btnCancelar.TabIndex = 27
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(259, 79)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(109, 31)
        Me.btnGuardar.TabIndex = 26
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'AsocUsuarioFamilia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 139)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtid_usuario)
        Me.Controls.Add(Me.txtId_familia)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbDescripcionFamilia)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AsocUsuarioFamilia"
        Me.Text = "Familia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents cbDescripcionFamilia As ComboBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents txtid_usuario As TextBox
    Friend WithEvents txtId_familia As TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
End Class
