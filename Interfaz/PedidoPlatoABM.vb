Imports Negocio.Negocio.Traductor
Imports Negocio.Negocio.UsuarioPatente

Public Class PedidoPlatoABM
    Dim mPedidoPlato As Negocio.Negocio.PedidoPlato

    Private Sub PedidoPlatoABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsNothing(mPedidoPlato) Then
            mPedidoPlato = New Negocio.Negocio.PedidoPlato
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

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEnProceso.Click
        Dim mId_pedido As Integer = CInt(Me.dgvPedidoPlato.SelectedRows(0).Cells(0).Value)
        Dim mId_plato As Integer = CInt(Me.dgvPedidoPlato.SelectedRows(0).Cells(1).Value)

        Dim mPedidoPlato As New Negocio.Negocio.PedidoPlato(mId_pedido, mId_plato)

        Dim result As Integer = MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "¿Usted se encuentra seguro que desea dar de baja la Bebida seleccionada?"),
                                                ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Eliminar"),
                                                MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            MessageBox.Show(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "Bebida eliminada correctamente"))
        End If
        ActualizarGrilla()
    End Sub
End Class