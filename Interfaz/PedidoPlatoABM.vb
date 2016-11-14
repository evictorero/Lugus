Imports Negocio.Negocio.Traductor
Imports Negocio.Negocio.UsuarioPatente

Public Class PedidoPlatoABM
    Dim mPedidoPlato As Negocio.Negocio.PedidoPlato
    Dim mPedidoBebida As Negocio.Negocio.PedidoBebida

    Private Sub PedidoPlatoABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsNothing(mPedidoPlato) Then
            mPedidoPlato = New Negocio.Negocio.PedidoPlato
        End If
        If IsNothing(mPedidoBebida) Then
            mPedidoBebida = New Negocio.Negocio.PedidoBebida
        End If
        'Seteo de aspecto de la grilla 
        With Me.dgvPedidoPlato

            .AllowDrop = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            With .Columns
                .Add("cId", "Pedido")
                .Item(0).DataPropertyName = "Id_pedido"
                .Item(0).Visible = True

                .Add("cid_plato", "id_plato")
                .Item(1).DataPropertyName = "id_plato"
                .Item(1).Width = 125
                .Item(1).Visible = False

                .Add("cDescripcion", "Descripcion")
                .Item(2).DataPropertyName = "Descripcion"
                .Item(2).Width = 150
                .Item(2).Visible = True

                .Add("cdvh", "dvh")
                .Item(3).DataPropertyName = "dvh"
                .Item(3).Width = 125
                .Item(3).Visible = False

                .Add("cEstadoColeccion", "EstadoColeccion")
                .Item(4).DataPropertyName = "EstadoColeccion"
                .Item(4).Visible = False

                .Add("cIndiceColeccion", "IndiceColeccion")
                .Item(5).DataPropertyName = "IndiceColeccion"
                .Item(5).Visible = False

                .Add("cM_negada", "Estado")
                .Item(6).DataPropertyName = "Estado"
                .Item(6).Visible = False


                .Add("cM_negada", "Estado")
                .Item(7).DataPropertyName = "Desc Estado"
                .Item(7).Visible = True

            End With
        End With
        'Seteo de aspecto de la grilla 
        With Me.dgvPedidoBebidas

            .AllowDrop = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            With .Columns
                .Add("cId", "Pedido")
                .Item(0).DataPropertyName = "Id_pedido"
                .Item(0).Visible = True

                .Add("cid_plato", "id_bebida")
                .Item(1).DataPropertyName = "id_bebida"
                .Item(1).Width = 125
                .Item(1).Visible = False

                .Add("cDescripcion", "Descripcion")
                .Item(2).DataPropertyName = "Descripcion"
                .Item(2).Width = 150
                .Item(2).Visible = True

                .Add("cdvh", "dvh")
                .Item(3).DataPropertyName = "dvh"
                .Item(3).Width = 125
                .Item(3).Visible = False

                .Add("cEstadoColeccion", "EstadoColeccion")
                .Item(4).DataPropertyName = "EstadoColeccion"
                .Item(4).Visible = False

                .Add("cIndiceColeccion", "IndiceColeccion")
                .Item(5).DataPropertyName = "IndiceColeccion"
                .Item(5).Visible = False

                .Add("cM_negada", "Estado")
                .Item(6).DataPropertyName = "Estado"
                .Item(6).Visible = False


                .Add("cM_negada", "Estado")
                .Item(7).DataPropertyName = "Desc Estado"
                .Item(7).Visible = True

            End With
        End With
        ActualizarGrilla()
    End Sub

    Private Sub ActualizarGrilla()
        dgvPedidoPlato.DataSource = mPedidoPlato.Listar
        If dgvPedidoPlato.Rows.Count > 0 Then
            For i As Integer = 0 To dgvPedidoPlato.Rows.Count - 1
                Dim mPlato As New Negocio.Negocio.Plato
                mPlato.Cargar(CInt(dgvPedidoPlato.Rows(i).Cells(1).Value))
                dgvPedidoPlato.Rows(i).Cells(2).Value = mPlato.descripcionCorta
                dgvPedidoPlato.Rows(i).Cells(7).Value = EstadoPlatoBebida(dgvPedidoPlato.Rows(i).Cells(6).Value)
            Next
        End If
        dgvPedidoBebidas.DataSource = mPedidoBebida.Listar
        If dgvPedidoBebidas.Rows.Count > 0 Then
            For i As Integer = 0 To dgvPedidoBebidas.Rows.Count - 1
                Dim mBebida As New Negocio.Negocio.Bebida
                mBebida.Cargar(CInt(dgvPedidoBebidas.Rows(i).Cells(1).Value))
                dgvPedidoBebidas.Rows(i).Cells(2).Value = mBebida.descripcionCorta
                dgvPedidoBebidas.Rows(i).Cells(7).Value = EstadoPlatoBebida(dgvPedidoBebidas.Rows(i).Cells(6).Value)
            Next
        End If
    End Sub
    Public Function EstadoPlatoBebida(pEstado As String) As String
        Select Case pEstado
            Case "INGRESADO"
                Return "I"
            Case "PENDIENTE"
                Return "P"
            Case "EN PROCESO"
                Return "E"
            Case "LISTO"
                Return "L"
            Case "FINALIZADO"
                Return "F"
            Case "I"
                Return "INGRESADO"
            Case "P"
                Return "PENDIENTE"
            Case "E"
                Return "EN PROCESO"
            Case "L"
                Return "LISTO"
            Case "F"
                Return "FINALIZADO"
        End Select
        Return "I"
    End Function

    Private Sub btnEnProceso_Click(sender As Object, e As EventArgs) Handles btnEnProceso.Click
        If Me.dgvPedidoPlato.SelectedRows.Count > 0 And Me.dgvPedidoPlato.SelectedRows(0).Cells(6).Value = "P" Then

            Dim mId_pedido As Integer = CInt(Me.dgvPedidoPlato.SelectedRows(0).Cells(0).Value)
            Dim mId_plato As Integer = CInt(Me.dgvPedidoPlato.SelectedRows(0).Cells(1).Value)

            Dim mPedidoPlato As New Negocio.Negocio.PedidoPlato(mId_pedido, mId_plato)


            Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Desea enviar el Pedido a Cocina?"),
                                                    ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Enviar"),
                                                    MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                mPedidoPlato.Estado = "E"
                mPedidoPlato.GuardarModificacion()
                MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Pedido Enviado correctamente"))
            End If
            ActualizarGrilla()
        Else
            MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Debe seleccionar un pedido en estado Pendiente para Enviar."))
        End If
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click
        If Me.dgvPedidoPlato.SelectedRows.Count > 0 And Me.dgvPedidoPlato.SelectedRows(0).Cells(6).Value = "E" Then


            Dim mId_pedido As Integer = CInt(Me.dgvPedidoPlato.SelectedRows(0).Cells(0).Value)
            Dim mId_plato As Integer = CInt(Me.dgvPedidoPlato.SelectedRows(0).Cells(1).Value)

            Dim mPedidoPlato As New Negocio.Negocio.PedidoPlato(mId_pedido, mId_plato)


            Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Desea pasar a Listo el Pedido a Cocina?"),
                                                    ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Listo"),
                                                    MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                mPedidoPlato.Estado = "L"
                mPedidoPlato.GuardarModificacion()
                MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Pedido Enviado a Listo correctamente"))
            End If
            ActualizarGrilla()
        End If
    End Sub

    Private Sub btnProcesarBebida_Click(sender As Object, e As EventArgs) Handles btnProcesarBebida.Click
        If Me.dgvPedidoBebidas.SelectedRows.Count > 0 And Me.dgvPedidoBebidas.SelectedRows(0).Cells(6).Value = "P" Then

            Dim mId_pedido As Integer = CInt(Me.dgvPedidoBebidas.SelectedRows(0).Cells(0).Value)
            Dim mId_Bebida As Integer = CInt(Me.dgvPedidoBebidas.SelectedRows(0).Cells(1).Value)

            Dim mPedidoBebida As New Negocio.Negocio.PedidoBebida(mId_pedido, mId_Bebida)


            Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Desea enviar el Pedido a Cocina?"),
                                                    ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Enviar"),
                                                    MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                mPedidoBebida.Estado = "E"
                mPedidoBebida.GuardarModificacion()
                MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Pedido Enviado correctamente"))
            End If
            ActualizarGrilla()
        Else
            MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Debe seleccionar un pedido en estado Pendiente para Enviar."))
        End If
    End Sub

    Private Sub btnListoBebida_Click(sender As Object, e As EventArgs) Handles btnListoBebida.Click
        If Me.dgvPedidoBebidas.SelectedRows.Count > 0 And Me.dgvPedidoBebidas.SelectedRows(0).Cells(6).Value = "E" Then


            Dim mId_pedido As Integer = CInt(Me.dgvPedidoBebidas.SelectedRows(0).Cells(0).Value)
            Dim mId_Bebida As Integer = CInt(Me.dgvPedidoBebidas.SelectedRows(0).Cells(1).Value)

            Dim mPedidoBebida As New Negocio.Negocio.PedidoPlato(mId_pedido, mId_Bebida)


            Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Desea pasar a Listo el Pedido a Cocina?"),
                                                    ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Listo"),
                                                    MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                mPedidoBebida.Estado = "L"
                mPedidoPlato.GuardarModificacion()
                MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Pedido Enviado a Listo correctamente"))
            End If
            ActualizarGrilla()
        End If
    End Sub
End Class