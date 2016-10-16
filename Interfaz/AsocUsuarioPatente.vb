Imports Negocio.Negocio
Public Class AsocUsuarioPatente

#Region "Declaraciones"

        Dim mUsuarioPatente As Negocio.Negocio.UsuarioPatente

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

        Friend Property UsuarioPatenteAEditar() As Negocio.Negocio.UsuarioPatente
            Get
                Return mUsuarioPatente
            End Get
            Set(ByVal value As Negocio.Negocio.UsuarioPatente)
                mUsuarioPatente = value
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
                    Me.lblDescripcion.Text = "Descripcion"
                    cbDescripcionPatente.DataSource = (New Negocio.Negocio.Patente).Listar
                    cbDescripcionPatente.DisplayMember = "descripcionLarga"
                    cbDescripcionPatente.ValueMember = "id"

                Case TipoOperacion.Baja

                    If Not IsNothing(mUsuarioPatente) Then
                        Me.txtId_patente.Text = mUsuarioPatente.id_patente
                        Me.txtId_patente.Visible = False
                    Me.txtid_usuario.Text = mUsuarioPatente.id_usuario
                    Me.txtid_usuario.Visible = False
                    Me.cbDescripcionPatente.SelectedValue = mUsuarioPatente.id_patente
                        Me.cbDescripcionPatente.Enabled = False
                        Me.cbDescripcionPatente.Visible = False
                        Me.chbM_Negada.Visible = False
                        Me.lblNegada.Visible = False
                        Me.lblDescripcion.Text = "¿Esta Seguro que desea eliminar esta asociacion familia patente?"
                        Me.btnGuardar.Text = "Eliminar"
                        Me.btnGuardar.BackColor = Color.Firebrick
                        Me.btnGuardar.ForeColor = Color.AntiqueWhite
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
                mUsuarioPatente = New Negocio.Negocio.UsuarioPatente
                mUsuarioPatente.id_patente = cbDescripcionPatente.SelectedValue
                mUsuarioPatente.id_usuario_alta = Principal.UsuarioEnSesion.id
                If chbM_Negada.Checked = True Then
                    mUsuarioPatente.m_negada = "S"
                Else
                    mUsuarioPatente.m_negada = "N"
                End If

                CType(Me.Owner, Usuarios).UsuarioAEditar.AgregarUsuarioPatente(mUsuarioPatente)

            Case TipoOperacion.Baja
                If Not IsNothing(mUsuarioPatente) Then
                    CType(Me.Owner, Usuarios).UsuarioAEditar.EliminarUsuarioPatente(mUsuarioPatente.IndiceColeccion)
                End If
        End Select
        Me.Close()
    End Sub

#End Region
End Class
