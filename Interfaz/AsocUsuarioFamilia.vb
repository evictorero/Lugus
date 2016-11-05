
Imports Negocio.Negocio
Public Class AsocUsuarioFamilia

#Region "Declaraciones"

    Dim mUsuarioFamilia As Negocio.Negocio.UsuarioFamilia

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

    Friend Property UsuarioFamiliaAEditar() As Negocio.Negocio.UsuarioFamilia
        Get
            Return mUsuarioFamilia
        End Get
        Set(ByVal value As Negocio.Negocio.UsuarioFamilia)
            mUsuarioFamilia = value
        End Set
    End Property
#End Region

#Region "Eventos Form"

    Private Sub AsocUsuarioFamilia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Negocio.Negocio.Traductor.TraducirVentana(Me, Principal.UsuarioEnSesion.id_idioma)
        Me.txtid_familia.Enabled = False

        Select Case mOperacion
            Case TipoOperacion.Alta
                Me.txtid_familia.Text = ""
                Me.lblDescripcion.Text = "Descripcion"
                cbDescripcionFamilia.DataSource = (New Negocio.Negocio.Familia).Listar
                cbDescripcionFamilia.DisplayMember = "descripcionCorta"
                cbDescripcionFamilia.ValueMember = "id"

            Case TipoOperacion.Baja
                If Not IsNothing(mUsuarioFamilia) Then
                    Me.txtId_familia.Text = mUsuarioFamilia.id_familia
                    Me.txtId_familia.Visible = False
                    Me.txtid_usuario.Text = mUsuarioFamilia.id_usuario
                    Me.txtid_usuario.Visible = False
                    Me.cbDescripcionFamilia.SelectedValue = mUsuarioFamilia.id_familia
                    Me.cbDescripcionFamilia.Enabled = False
                    Me.cbDescripcionFamilia.Visible = False
                    Me.lblDescripcion.Text = "¿Esta Seguro que desea eliminar esta asociacion Usuario Familia?"
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
        Try
            Select Case mOperacion
                Case TipoOperacion.Alta
                    mUsuarioFamilia = New Negocio.Negocio.UsuarioFamilia
                    mUsuarioFamilia.id_familia = cbDescripcionFamilia.SelectedValue
                    mUsuarioFamilia.id_usuario_alta = Principal.UsuarioEnSesion.id
                    CType(Me.Owner, Usuarios).UsuarioAEditar.AgregarUsuarioFamilia(mUsuarioFamilia)

                Case TipoOperacion.Baja
                    If Not IsNothing(mUsuarioFamilia) Then
                        Dim rtaFamilia As Boolean = False
                        rtaFamilia = Negocio.Negocio.UsuarioFamilia.EsFamiliaPatenteEsencial(mUsuarioFamilia.id_usuario, mUsuarioFamilia.id_familia)
                        If Not rtaFamilia Then
                            CType(Me.Owner, Usuarios).UsuarioAEditar.EliminarUsuarioFamilia(mUsuarioFamilia.IndiceColeccion)
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Close()
    End Sub

#End Region
End Class