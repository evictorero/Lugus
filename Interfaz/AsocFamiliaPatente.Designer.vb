<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AsocFamiliaPatente
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
        Me.lblNegada = New System.Windows.Forms.Label()
        Me.chbM_Negada = New System.Windows.Forms.CheckBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.cbDescripcionPatente = New System.Windows.Forms.ComboBox()
        Me.txtId_patente = New System.Windows.Forms.TextBox()
        Me.txtid_familia = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblNegada
        '
        Me.lblNegada.AutoSize = True
        Me.lblNegada.Location = New System.Drawing.Point(84, 66)
        Me.lblNegada.Name = "lblNegada"
        Me.lblNegada.Size = New System.Drawing.Size(58, 17)
        Me.lblNegada.TabIndex = 16
        Me.lblNegada.Text = "Negada"
        '
        'chbM_Negada
        '
        Me.chbM_Negada.AutoSize = True
        Me.chbM_Negada.Location = New System.Drawing.Point(172, 66)
        Me.chbM_Negada.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chbM_Negada.Name = "chbM_Negada"
        Me.chbM_Negada.Size = New System.Drawing.Size(18, 17)
        Me.chbM_Negada.TabIndex = 15
        Me.chbM_Negada.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(351, 94)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(109, 31)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(219, 94)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(109, 31)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(80, 30)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(82, 17)
        Me.lblDescripcion.TabIndex = 12
        Me.lblDescripcion.Text = "Descripcion"
        '
        'cbDescripcionPatente
        '
        Me.cbDescripcionPatente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescripcionPatente.ForeColor = System.Drawing.SystemColors.Window
        Me.cbDescripcionPatente.FormattingEnabled = True
        Me.cbDescripcionPatente.Items.AddRange(New Object() {"Alta de Usuario", "Modificacion de Usuario", "Baja de Usuario"})
        Me.cbDescripcionPatente.Location = New System.Drawing.Point(172, 27)
        Me.cbDescripcionPatente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbDescripcionPatente.Name = "cbDescripcionPatente"
        Me.cbDescripcionPatente.Size = New System.Drawing.Size(365, 24)
        Me.cbDescripcionPatente.TabIndex = 11
        '
        'txtId_patente
        '
        Me.txtId_patente.Location = New System.Drawing.Point(12, 94)
        Me.txtId_patente.Name = "txtId_patente"
        Me.txtId_patente.Size = New System.Drawing.Size(100, 22)
        Me.txtId_patente.TabIndex = 17
        Me.txtId_patente.Visible = False
        '
        'txtid_familia
        '
        Me.txtid_familia.Location = New System.Drawing.Point(12, 119)
        Me.txtid_familia.Name = "txtid_familia"
        Me.txtid_familia.Size = New System.Drawing.Size(100, 22)
        Me.txtid_familia.TabIndex = 18
        Me.txtid_familia.Visible = False
        '
        'AsocFamiliaPatente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 153)
        Me.Controls.Add(Me.txtid_familia)
        Me.Controls.Add(Me.txtId_patente)
        Me.Controls.Add(Me.lblNegada)
        Me.Controls.Add(Me.chbM_Negada)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.cbDescripcionPatente)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AsocFamiliaPatente"
        Me.Text = "Patente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNegada As Label
    Friend WithEvents chbM_Negada As CheckBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents cbDescripcionPatente As ComboBox
    Friend WithEvents txtId_patente As TextBox
    Friend WithEvents txtid_familia As TextBox
End Class
