Imports Negocio.Negocio
Public Class AsocUsuarioPatente

#Region "Declaraciones"
    Dim mPatente As Negocio.Negocio.Patente

    Friend mOperacion As TipoOperacion
        Friend Enum TipoOperacion
            Alta = 1
            Baja = 2
            Modificacion = 3
        End Enum
#End Region

#Region "Propiedades"
        Friend Property Operacion() As TipoOperacion
            Get
                Return mOperacion
            End Get
            Set(ByVal value As TipoOperacion)
                mOperacion = value
            End Set
        End Property
    Friend Property PatenteAEditar() As Negocio.Negocio.Patente
        Get
            Return mPatente
        End Get
        Set(ByVal value As Negocio.Negocio.Patente)
            mPatente = value
        End Set
    End Property
#End Region

#Region "Eventos Form"

    Private Sub AsocUsuarioPatente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)

        Me.txtId_patente.Enabled = False

        Select Case mOperacion
            Case TipoOperacion.Alta
                Me.txtId_patente.Text = ""
                Me.Label1.Text = "Nueva Patente"

                Me.cbDescripcionPatente.DataSource = (New Negocio.Negocio.Patente).Listar
                cbDescripcionPatente.DisplayMember = "descripcionLarga"
                cbDescripcionPatente.ValueMember = "id"

            Case TipoOperacion.Baja

                If Not IsNothing(mPatente) Then
                    Me.txtId_patente.Text =
                    Me.txtId_patente.Enabled = False
                    'Me.txtTipo.Text = mPatente.Tipo
                    'Me.txtTipo.Enabled = False
                    'Me.txtSuperficie.Text = mPatente.Superficie
                    'Me.txtSuperficie.Enabled = False
                    'Me.Label1.Text = "¿esta Seguro que desea Eliminar este Patente?"
                    Me.btnGuardar.Text = "Eliminar"
                    Me.btnGuardar.BackColor = Color.Firebrick
                    Me.btnGuardar.ForeColor = Color.AntiqueWhite
                End If

            Case TipoOperacion.Modificacion

                If Not IsNothing(mPatente) Then
                    Me.txtId_patente.Text = mPatente.id
                    'Me.txtTipo.Text = mPatente.Tipo
                    'Me.txtSuperficie.Text = mPatente.Superficie
                    Me.Label1.Text = "MODIFICACION DEL Patente"
                End If
        End Select
        End Sub
#End Region

#Region "Metodos"

        Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Me.Close()
        End Sub

        Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
            Select Case mOperacion
                Case TipoOperacion.Alta
                mPatente = New Negocio.Negocio.Patente
            'mPatente.Tipo = Me.txtTipo.Text

            'If Single.TryParse(Me.txtSuperficie.Text, mPatente.Superficie) Then
            '    mPatente.Superficie = Single.Parse(Me.txtSuperficie.Text)
            'Else
            '    mPatente.Superficie = 0
            'End If

            'CType(Me.Owner, Familias).FamiliaAEditar.AgregarPatente(mPatente)

            Case TipoOperacion.Modificacion
                If Not IsNothing(mPatente) Then
                    'mPatente.Tipo = Me.txtTipo.Text
                    'mPatente.Superficie = Me.txtSuperficie.Text
                    'CType(Me.Owner, Familias).PatenteAEditar.ModificarPatente(mPatente)
                End If
            Case TipoOperacion.Baja
                If Not IsNothing(mPatente) Then
                    'CType(Me.Owner, Familias).CasaAEditar.EliminarPatente(mPatente.IndiceColeccion)
                End If
        End Select
            Me.Close()
        End Sub



#End Region
End Class