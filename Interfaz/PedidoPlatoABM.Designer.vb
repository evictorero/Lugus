<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidoPlatoABM
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
        Me.dgvPedidoPlato = New System.Windows.Forms.DataGridView()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEnProceso = New System.Windows.Forms.Button()
        Me.btnListo = New System.Windows.Forms.Button()
        CType(Me.dgvPedidoPlato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPedidoPlato
        '
        Me.dgvPedidoPlato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPedidoPlato.Location = New System.Drawing.Point(24, 30)
        Me.dgvPedidoPlato.Name = "dgvPedidoPlato"
        Me.dgvPedidoPlato.RowTemplate.Height = 24
        Me.dgvPedidoPlato.Size = New System.Drawing.Size(523, 150)
        Me.dgvPedidoPlato.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvPedidoPlato)
        Me.GroupBox1.Location = New System.Drawing.Point(50, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 199)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnEnProceso
        '
        Me.btnEnProceso.Location = New System.Drawing.Point(155, 248)
        Me.btnEnProceso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEnProceso.Name = "btnEnProceso"
        Me.btnEnProceso.Size = New System.Drawing.Size(141, 38)
        Me.btnEnProceso.TabIndex = 21
        Me.btnEnProceso.Text = "Procesar"
        Me.btnEnProceso.UseVisualStyleBackColor = True
        '
        'btnListo
        '
        Me.btnListo.Location = New System.Drawing.Point(329, 248)
        Me.btnListo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(141, 38)
        Me.btnListo.TabIndex = 22
        Me.btnListo.Text = "Listo"
        Me.btnListo.UseVisualStyleBackColor = True
        '
        'PedidoPlatoABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 308)
        Me.Controls.Add(Me.btnListo)
        Me.Controls.Add(Me.btnEnProceso)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PedidoPlatoABM"
        Me.Text = "PedidoPlatoABM"
        CType(Me.dgvPedidoPlato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvPedidoPlato As DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnEnProceso As Button
    Friend WithEvents btnListo As Button
End Class
