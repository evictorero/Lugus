<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarContraseña
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
        Me.txtContraseniaActual = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.lblContraseniaActual = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblContraseniaNueva = New System.Windows.Forms.Label()
        Me.txtContraseniaNueva = New System.Windows.Forms.TextBox()
        Me.txtRepetirContraseniaNueva = New System.Windows.Forms.TextBox()
        Me.lblRepetirContraseniaNueva = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtContraseniaActual
        '
        Me.txtContraseniaActual.Location = New System.Drawing.Point(249, 73)
        Me.txtContraseniaActual.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContraseniaActual.MaxLength = 10
        Me.txtContraseniaActual.Name = "txtContraseniaActual"
        Me.txtContraseniaActual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseniaActual.Size = New System.Drawing.Size(181, 22)
        Me.txtContraseniaActual.TabIndex = 11
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(249, 41)
        Me.txtUsuario.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(181, 22)
        Me.txtUsuario.TabIndex = 10
        '
        'lblContraseniaActual
        '
        Me.lblContraseniaActual.AutoSize = True
        Me.lblContraseniaActual.Location = New System.Drawing.Point(45, 78)
        Me.lblContraseniaActual.Name = "lblContraseniaActual"
        Me.lblContraseniaActual.Size = New System.Drawing.Size(123, 17)
        Me.lblContraseniaActual.TabIndex = 9
        Me.lblContraseniaActual.Text = "Contraseña actual"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(45, 43)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(57, 17)
        Me.lblUsuario.TabIndex = 8
        Me.lblUsuario.Text = "Usuario"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(249, 188)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(116, 33)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(111, 188)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(116, 33)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblContraseniaNueva
        '
        Me.lblContraseniaNueva.AutoSize = True
        Me.lblContraseniaNueva.Location = New System.Drawing.Point(45, 111)
        Me.lblContraseniaNueva.Name = "lblContraseniaNueva"
        Me.lblContraseniaNueva.Size = New System.Drawing.Size(124, 17)
        Me.lblContraseniaNueva.TabIndex = 12
        Me.lblContraseniaNueva.Text = "Contraseña nueva"
        '
        'txtContraseniaNueva
        '
        Me.txtContraseniaNueva.Location = New System.Drawing.Point(249, 106)
        Me.txtContraseniaNueva.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContraseniaNueva.MaxLength = 10
        Me.txtContraseniaNueva.Name = "txtContraseniaNueva"
        Me.txtContraseniaNueva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseniaNueva.Size = New System.Drawing.Size(181, 22)
        Me.txtContraseniaNueva.TabIndex = 13
        '
        'txtRepetirContraseniaNueva
        '
        Me.txtRepetirContraseniaNueva.Location = New System.Drawing.Point(249, 140)
        Me.txtRepetirContraseniaNueva.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtRepetirContraseniaNueva.MaxLength = 10
        Me.txtRepetirContraseniaNueva.Name = "txtRepetirContraseniaNueva"
        Me.txtRepetirContraseniaNueva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRepetirContraseniaNueva.Size = New System.Drawing.Size(181, 22)
        Me.txtRepetirContraseniaNueva.TabIndex = 15
        '
        'lblRepetirContraseniaNueva
        '
        Me.lblRepetirContraseniaNueva.AutoSize = True
        Me.lblRepetirContraseniaNueva.Location = New System.Drawing.Point(45, 145)
        Me.lblRepetirContraseniaNueva.Name = "lblRepetirContraseniaNueva"
        Me.lblRepetirContraseniaNueva.Size = New System.Drawing.Size(172, 17)
        Me.lblRepetirContraseniaNueva.TabIndex = 14
        Me.lblRepetirContraseniaNueva.Text = "Repetir contraseña nueva"
        '
        'CambiarContraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 246)
        Me.Controls.Add(Me.txtRepetirContraseniaNueva)
        Me.Controls.Add(Me.lblRepetirContraseniaNueva)
        Me.Controls.Add(Me.txtContraseniaNueva)
        Me.Controls.Add(Me.lblContraseniaNueva)
        Me.Controls.Add(Me.txtContraseniaActual)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.lblContraseniaActual)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "CambiarContraseña"
        Me.Text = "Cambiar contraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtContraseniaActual As TextBox
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents lblContraseniaActual As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblContraseniaNueva As Label
    Friend WithEvents txtContraseniaNueva As TextBox
    Friend WithEvents txtRepetirContraseniaNueva As TextBox
    Friend WithEvents lblRepetirContraseniaNueva As Label
End Class
