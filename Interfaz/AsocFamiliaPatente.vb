Imports Negocio.Negocio
Imports Negocio.Negocio.Traductor


Public Class AsocFamiliaPatente


#Region "Declaraciones"

    Dim mFamiliaPatente As Negocio.Negocio.FamiliaPatente

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

    Friend Property FamiliaPatenteAEditar() As Negocio.Negocio.FamiliaPatente
        Get
            Return mFamiliaPatente
        End Get
        Set(ByVal value As Negocio.Negocio.FamiliaPatente)
            mFamiliaPatente = value
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

                If Not IsNothing(mFamiliaPatente) Then
                    Me.txtId_patente.Text = mFamiliaPatente.id_patente
                    Me.txtId_patente.Visible = False
                    Me.txtid_familia.Text = mFamiliaPatente.id_familia
                    Me.txtid_familia.Visible = False
                    Me.cbDescripcionPatente.SelectedValue = mFamiliaPatente.id_patente
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
                mFamiliaPatente = New Negocio.Negocio.FamiliaPatente
                mFamiliaPatente.id_patente = cbDescripcionPatente.SelectedValue
                mFamiliaPatente.id_usuario_alta = Principal.UsuarioEnSesion.id
                If chbM_Negada.Checked = True Then
                    mFamiliaPatente.m_negada = "S"
                Else
                    mFamiliaPatente.m_negada = "N"
                End If

                CType(Me.Owner, Familias).FamiliaAEditar.AgregarFamiliaPatente(mFamiliaPatente)

            Case TipoOperacion.Baja
                If Not IsNothing(mFamiliaPatente) Then
                    If Not Negocio.Negocio.FamiliaPatente.EsFamiliaPatenteEsencial(mFamiliaPatente.id_familia, mFamiliaPatente.id_patente) Then
                        CType(Me.Owner, Familias).FamiliaAEditar.EliminarFamiliaPatente(mFamiliaPatente.IndiceColeccion)
                    Else
                        MsgBox(ObtenerTraduccion(Principal.UsuarioEnSesion.id_idioma, "La pantente que desea eliminar es esencial."))
                    End If
                End If
        End Select
        Me.Close()
    End Sub
#End Region
End Class