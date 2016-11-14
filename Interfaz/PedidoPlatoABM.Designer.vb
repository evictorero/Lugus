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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnListoBebida = New System.Windows.Forms.Button()
        Me.dgvPedidoBebidas = New System.Windows.Forms.DataGridView()
        Me.btnProcesarBebida = New System.Windows.Forms.Button()
        CType(Me.dgvPedidoPlato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPedidoBebidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPedidoPlato
        '
        Me.dgvPedidoPlato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPedidoPlato.Location = New System.Drawing.Point(24, 30)
        Me.dgvPedidoPlato.Name = "dgvPedidoPlato"
        Me.dgvPedidoPlato.RowTemplate.Height = 24
        Me.dgvPedidoPlato.Size = New System.Drawing.Size(557, 150)
        Me.dgvPedidoPlato.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnListo)
        Me.GroupBox1.Controls.Add(Me.dgvPedidoPlato)
        Me.GroupBox1.Controls.Add(Me.btnEnProceso)
        Me.GroupBox1.Location = New System.Drawing.Point(50, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(771, 199)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pedidos de Platos a Cocina"
        '
        'btnEnProceso
        '
        Me.btnEnProceso.Location = New System.Drawing.Point(600, 45)
        Me.btnEnProceso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEnProceso.Name = "btnEnProceso"
        Me.btnEnProceso.Size = New System.Drawing.Size(141, 38)
        Me.btnEnProceso.TabIndex = 21
        Me.btnEnProceso.Text = "Procesar"
        Me.btnEnProceso.UseVisualStyleBackColor = True
        '
        'btnListo
        '
        Me.btnListo.Location = New System.Drawing.Point(600, 112)
        Me.btnListo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(141, 38)
        Me.btnListo.TabIndex = 22
        Me.btnListo.Text = "Listo"
        Me.btnListo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnListoBebida)
        Me.GroupBox2.Controls.Add(Me.dgvPedidoBebidas)
        Me.GroupBox2.Controls.Add(Me.btnProcesarBebida)
        Me.GroupBox2.Location = New System.Drawing.Point(52, 256)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(771, 199)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pedidos de Bebidas a Cocina"
        '
        'btnListoBebida
        '
        Me.btnListoBebida.Location = New System.Drawing.Point(600, 112)
        Me.btnListoBebida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnListoBebida.Name = "btnListoBebida"
        Me.btnListoBebida.Size = New System.Drawing.Size(141, 38)
        Me.btnListoBebida.TabIndex = 22
        Me.btnListoBebida.Text = "Listo"
        Me.btnListoBebida.UseVisualStyleBackColor = True
        '
        'dgvPedidoBebidas
        '
        Me.dgvPedidoBebidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPedidoBebidas.Location = New System.Drawing.Point(24, 30)
        Me.dgvPedidoBebidas.Name = "dgvPedidoBebidas"
        Me.dgvPedidoBebidas.RowTemplate.Height = 24
        Me.dgvPedidoBebidas.Size = New System.Drawing.Size(557, 150)
        Me.dgvPedidoBebidas.TabIndex = 0
        '
        'btnProcesarBebida
        '
        Me.btnProcesarBebida.Location = New System.Drawing.Point(600, 45)
        Me.btnProcesarBebida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnProcesarBebida.Name = "btnProcesarBebida"
        Me.btnProcesarBebida.Size = New System.Drawing.Size(141, 38)
        Me.btnProcesarBebida.TabIndex = 21
        Me.btnProcesarBebida.Text = "Procesar"
        Me.btnProcesarBebida.UseVisualStyleBackColor = True
        '
        'PedidoPlatoABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 512)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PedidoPlatoABM"
        Me.Text = "PedidoPlatoABM"
        CType(Me.dgvPedidoPlato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvPedidoBebidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvPedidoPlato As DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnEnProceso As Button
    Friend WithEvents btnListo As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnListoBebida As Button
    Friend WithEvents dgvPedidoBebidas As DataGridView
    Friend WithEvents btnProcesarBebida As Button
End Class
