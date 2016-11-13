<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteUsuarios
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.UsuarioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.cbDescripcionPatente = New System.Windows.Forms.ComboBox()
        Me.btn_ejecutar = New System.Windows.Forms.Button()
        Me.rbtnPatente = New System.Windows.Forms.RadioButton()
        Me.rbtnFamilia = New System.Windows.Forms.RadioButton()
        Me.rbtnTodos = New System.Windows.Forms.RadioButton()
        Me.cbDescripcionFamilia = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.UsuarioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UsuarioBindingSource
        '
        Me.UsuarioBindingSource.DataSource = GetType(Negocio.Negocio.Usuario)
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSetUsuarios"
        ReportDataSource2.Value = Me.UsuarioBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Interfaz.ReporteUsuarios.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(3, 16)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(712, 290)
        Me.ReportViewer1.TabIndex = 0
        '
        'cbDescripcionPatente
        '
        Me.cbDescripcionPatente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescripcionPatente.FormattingEnabled = True
        Me.cbDescripcionPatente.Items.AddRange(New Object() {"Alta de Usuario", "Modificacion de Usuario", "Baja de Usuario"})
        Me.cbDescripcionPatente.Location = New System.Drawing.Point(36, 17)
        Me.cbDescripcionPatente.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDescripcionPatente.Name = "cbDescripcionPatente"
        Me.cbDescripcionPatente.Size = New System.Drawing.Size(436, 21)
        Me.cbDescripcionPatente.TabIndex = 20
        '
        'btn_ejecutar
        '
        Me.btn_ejecutar.Location = New System.Drawing.Point(607, 67)
        Me.btn_ejecutar.Name = "btn_ejecutar"
        Me.btn_ejecutar.Size = New System.Drawing.Size(75, 23)
        Me.btn_ejecutar.TabIndex = 21
        Me.btn_ejecutar.Text = "Ejecutar"
        Me.btn_ejecutar.UseVisualStyleBackColor = True
        '
        'rbtnPatente
        '
        Me.rbtnPatente.AutoSize = True
        Me.rbtnPatente.Location = New System.Drawing.Point(497, 18)
        Me.rbtnPatente.Name = "rbtnPatente"
        Me.rbtnPatente.Size = New System.Drawing.Size(80, 17)
        Me.rbtnPatente.TabIndex = 22
        Me.rbtnPatente.Text = "Por patente"
        Me.rbtnPatente.UseVisualStyleBackColor = True
        '
        'rbtnFamilia
        '
        Me.rbtnFamilia.AutoSize = True
        Me.rbtnFamilia.Location = New System.Drawing.Point(497, 48)
        Me.rbtnFamilia.Name = "rbtnFamilia"
        Me.rbtnFamilia.Size = New System.Drawing.Size(73, 17)
        Me.rbtnFamilia.TabIndex = 23
        Me.rbtnFamilia.Text = "Por familia"
        Me.rbtnFamilia.UseVisualStyleBackColor = True
        '
        'rbtnTodos
        '
        Me.rbtnTodos.AutoSize = True
        Me.rbtnTodos.Checked = True
        Me.rbtnTodos.Location = New System.Drawing.Point(497, 76)
        Me.rbtnTodos.Name = "rbtnTodos"
        Me.rbtnTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbtnTodos.TabIndex = 24
        Me.rbtnTodos.TabStop = True
        Me.rbtnTodos.Text = "Todos"
        Me.rbtnTodos.UseVisualStyleBackColor = True
        '
        'cbDescripcionFamilia
        '
        Me.cbDescripcionFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescripcionFamilia.FormattingEnabled = True
        Me.cbDescripcionFamilia.Items.AddRange(New Object() {"Alta de Usuario", "Modificacion de Usuario", "Baja de Usuario"})
        Me.cbDescripcionFamilia.Location = New System.Drawing.Point(36, 47)
        Me.cbDescripcionFamilia.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDescripcionFamilia.Name = "cbDescripcionFamilia"
        Me.cbDescripcionFamilia.Size = New System.Drawing.Size(436, 21)
        Me.cbDescripcionFamilia.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ReportViewer1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(718, 309)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reporte"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbDescripcionFamilia)
        Me.GroupBox2.Controls.Add(Me.rbtnTodos)
        Me.GroupBox2.Controls.Add(Me.rbtnFamilia)
        Me.GroupBox2.Controls.Add(Me.rbtnPatente)
        Me.GroupBox2.Controls.Add(Me.btn_ejecutar)
        Me.GroupBox2.Controls.Add(Me.cbDescripcionPatente)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(715, 98)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        '
        'ReporteUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 435)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ReporteUsuarios"
        Me.Text = "Reporte de usuarios"
        CType(Me.UsuarioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents UsuarioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cbDescripcionPatente As System.Windows.Forms.ComboBox
    Friend WithEvents btn_ejecutar As System.Windows.Forms.Button
    Friend WithEvents rbtnPatente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFamilia As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTodos As System.Windows.Forms.RadioButton
    Friend WithEvents cbDescripcionFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
