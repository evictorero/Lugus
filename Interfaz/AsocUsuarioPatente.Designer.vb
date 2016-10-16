<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsocUsuarioPatente
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
        Me.txtid_usuario = New System.Windows.Forms.TextBox()
        Me.txtId_patente = New System.Windows.Forms.TextBox()
        Me.chbM_Negada = New System.Windows.Forms.CheckBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cbDescripcionPatente = New System.Windows.Forms.ComboBox()
        Me.lblNegada = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtid_usuario
        '
        Me.txtid_usuario.Location = New System.Drawing.Point(36, 130)
        Me.txtid_usuario.Name = "txtid_usuario"
        Me.txtid_usuario.Size = New System.Drawing.Size(100, 22)
        Me.txtid_usuario.TabIndex = 24
        Me.txtid_usuario.Visible = False
        '
        'txtId_patente
        '
        Me.txtId_patente.Location = New System.Drawing.Point(36, 105)
        Me.txtId_patente.Name = "txtId_patente"
        Me.txtId_patente.Size = New System.Drawing.Size(100, 22)
        Me.txtId_patente.TabIndex = 23
        Me.txtId_patente.Visible = False
        '
        'chbM_Negada
        '
        Me.chbM_Negada.AutoSize = True
        Me.chbM_Negada.Location = New System.Drawing.Point(196, 77)
        Me.chbM_Negada.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chbM_Negada.Name = "chbM_Negada"
        Me.chbM_Negada.Size = New System.Drawing.Size(18, 17)
        Me.chbM_Negada.TabIndex = 22
        Me.chbM_Negada.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(375, 105)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(109, 31)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(243, 105)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(109, 31)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cbDescripcionPatente
        '
        Me.cbDescripcionPatente.FormattingEnabled = True
        Me.cbDescripcionPatente.Items.AddRange(New Object() {"Alta de Usuario", "Modificacion de Usuario", "Baja de Usuario"})
        Me.cbDescripcionPatente.Location = New System.Drawing.Point(196, 38)
        Me.cbDescripcionPatente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbDescripcionPatente.Name = "cbDescripcionPatente"
        Me.cbDescripcionPatente.Size = New System.Drawing.Size(365, 24)
        Me.cbDescripcionPatente.TabIndex = 19
        '
        'lblNegada
        '
        Me.lblNegada.AutoSize = True
        Me.lblNegada.Location = New System.Drawing.Point(58, 74)
        Me.lblNegada.Name = "lblNegada"
        Me.lblNegada.Size = New System.Drawing.Size(58, 17)
        Me.lblNegada.TabIndex = 26
        Me.lblNegada.Text = "Negada"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(54, 38)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(82, 17)
        Me.lblDescripcion.TabIndex = 25
        Me.lblDescripcion.Text = "Descripcion"
        '
        'AsocUsuarioPatente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 173)
        Me.Controls.Add(Me.lblNegada)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtid_usuario)
        Me.Controls.Add(Me.txtId_patente)
        Me.Controls.Add(Me.chbM_Negada)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cbDescripcionPatente)
        Me.Name = "AsocUsuarioPatente"
        Me.Text = "AsocUsuarioPatente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtid_usuario As TextBox
    Friend WithEvents txtId_patente As TextBox
    Friend WithEvents chbM_Negada As CheckBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents cbDescripcionPatente As ComboBox
    Friend WithEvents lblNegada As Label
    Friend WithEvents lblDescripcion As Label
End Class
