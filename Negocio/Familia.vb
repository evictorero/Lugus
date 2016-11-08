Imports Datos.ProveedorDeDatos.DB

Namespace Negocio

    Public Class Familia : Implements IColeccionable

#Region "Declaraciones"
        Dim mDescripcionCorta As String
        Dim mDescripcionLarga As String
        Dim mHabilitado As String
        Dim mFechaBaja As Nullable(Of DateTime)
        Dim mIdUsuario As Integer
        Dim mDvh As Integer
        Dim mFechaModif As Date

        Private Shared ProximoId As Integer
        Dim mId As Integer = 0

        'Esta coleccion alojara las patentes de cada familia
        Protected mFamiliaPatente As New Collections.Generic.List(Of FamiliaPatente)
#End Region

#Region "Constructores"
        Public Sub New(ByVal pId As Integer)
            mId = pId
            Cargar()
        End Sub
        Public Sub New()

        End Sub
        Public Sub New(ByVal pDr As DataRow)
            Me.Cargar(pDr)
        End Sub
        Public Sub New(ByVal pDTO As DTO.FamiliaDTO)
            Me.Cargar(pDTO)
            Me.CargarFamiliaPatente()
        End Sub
#End Region

#Region "Propiedades"
        Public Overridable ReadOnly Property id() As Integer
            Get
                Return mId
            End Get
        End Property
        Public Property descripcionCorta() As String
            Get
                Return mDescripcionCorta
            End Get
            Set(ByVal value As String)
                mDescripcionCorta = value
            End Set
        End Property
        Public Property descripcionLarga() As String
            Get
                Return mDescripcionLarga
            End Get
            Set(ByVal value As String)
                mDescripcionLarga = value
            End Set
        End Property
        Public Property habilitado() As String
            Get
                Return mHabilitado
            End Get
            Set(ByVal value As String)
                mHabilitado = value
            End Set
        End Property
        Public Property fechaBaja() As Nullable(Of DateTime)
            Get
                Return mFechaBaja
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                mFechaBaja = value
            End Set
        End Property
        Public Property idUsuario() As Integer
            Get
                Return mIdUsuario
            End Get
            Set(ByVal value As Integer)
                mIdUsuario = value
            End Set
        End Property
        Public Property dvh() As Integer
            Get
                Return mDvh
            End Get
            Set(ByVal value As Integer)
                mDvh = value
            End Set
        End Property
        Public Property fechaModif() As Date
            Get
                Return mFechaModif
            End Get
            Set(ByVal value As Date)
                mFechaModif = value
            End Set
        End Property
        Public ReadOnly Property FamiliaPatente() As Collections.Generic.List(Of FamiliaPatente)
            Get
                Return Me.FiltrarFamiliaPatenteNoVisibles
            End Get
        End Property
#End Region

#Region "Métodos"

        Public Overridable Sub Guardar()
            Dim mDTO As New DTO.FamiliaDTO

            mDTO.descripcionCorta = Encriptador.EncriptarDatos(2, Me.descripcionCorta)
            mDTO.descripcionLarga = Me.descripcionLarga
            mDTO.fechaBaja = Me.fechaBaja
            mDTO.idUsuario = Me.idUsuario
            mDTO.fechaModif = Me.fechaModif

            'Recalculo del digito verificador 
            Dim CadenaDigitoVerificador As String = mDTO.descripcionCorta + mDTO.descripcionLarga + Convert.ToString(mDTO.fechaModif)
            mDTO.dvh = Negocio.DigitoVerificador.CalcularDVH(CadenaDigitoVerificador)

            If mId = 0 Then
                mDTO.id = Datos.FamiliaDatos.ObtenerProximoId()
                Datos.FamiliaDatos.GuardarNuevo(mDTO)
                Dim mBitacora As New Negocio.Bitacora(mDTO.idUsuario, "Creación de Familia", "Media")
                mBitacora.Guardar()

                Dim mDVV As New Negocio.DigitoVerificador("bfamilia")
                mDVV.tabla = "bfamilia"
                mDVV.valor = Negocio.DigitoVerificador.CalcularDVV("bfamilia")
                mDVV.Guardar()
            Else
                mDTO.id = Me.id
                Datos.FamiliaDatos.GuardarModificacion(mDTO)
                Dim mBitacora As New Negocio.Bitacora(mDTO.idUsuario, "Modificacion de Familia", "Media")
                mBitacora.Guardar()
                Dim mDVV As New Negocio.DigitoVerificador("bfamilia")
                mDVV.tabla = "bfamilia"
                mDVV.valor = Negocio.DigitoVerificador.CalcularDVV("bfamilia")
                mDVV.Guardar()
            End If

            Me.GuardarFamiliaPatentes()

        End Sub
        Public Overridable Sub Cargar()
            If mId > 0 Then
                Dim mDTO As DTO.FamiliaDTO = Datos.FamiliaDatos.Obtener(mId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Familia sin Id especificado")

            End If
        End Sub
        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mDescripcionCorta = pDr("descripcion_corta")
                mDescripcionLarga = pDr("descripcion_larga")
                mHabilitado = pDr("habilitado")
                mFechaBaja = pDr("fecha_baja")
                mIdUsuario = pDr("id_usuario")
                mDvh = pDr("dvh")
                mFechaModif = pDr("fecha_modif")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        Public Overridable Sub Cargar(ByVal pId As Integer)
            If pId > 0 Then
                Dim mDTO As DTO.FamiliaDTO = Datos.FamiliaDatos.Obtener(pId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Familia sin Id especificado")
            End If
        End Sub
        Public Sub Cargar(ByVal pDTO As DTO.FamiliaDTO)
            mId = pDTO.id
            mDescripcionCorta = Encriptador.DesencriptarDatos(2, pDTO.descripcionCorta)
            mDescripcionLarga = pDTO.descripcionLarga
            mFechaBaja = pDTO.fechaBaja
            mIdUsuario = pDTO.idUsuario
            mFechaModif = pDTO.fechaModif
            mDvh = pDTO.dvh
        End Sub
        Public Overridable Sub Eliminar()
            If mId > 0 Then
                Datos.FamiliaDatos.ValidarDatos(mId)
                Datos.FamiliaDatos.Eliminar(mId)
            Else
                Throw New ApplicationException("Se intentó eliminar una Familia sin Id especifico.")
            End If
        End Sub
        Public Overridable Sub Rehabilitar()
            If mId > 0 Then
                Try
                    Datos.FamiliaDatos.Rehabilitar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al activar la Familia especificada.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó activar una Familia sin Id especifico.")
            End If
        End Sub
        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = Datos.FamiliaDatos.ObtenerProximoId()
            End If
            ProximoId += 1
            Return ProximoId
        End Function
        Public Sub ValidarFormato(pid_idioma As Integer)
            Try
                If (Me.descripcionCorta = "") Then
                    Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar la descripción corta."))
                End If
                If (Me.descripcionLarga = "") Then
                    Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar la descripción larga."))
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Throw
            End Try
        End Sub
        Public Overridable Function Listar() As Collections.Generic.List(Of Familia)
            Dim mCol As New Collections.Generic.List(Of Familia)
            Dim mColDTO As List(Of DTO.FamiliaDTO) = Datos.FamiliaDatos.Listar()
            Dim miFamilia As Negocio.Familia

            For Each mDTO As DTO.FamiliaDTO In mColDTO
                miFamilia = New Negocio.Familia(mDTO)
                miFamilia.descripcionCorta = Encriptador.DesencriptarDatos(2, mDTO.descripcionCorta)
                mCol.Add(miFamilia)
            Next
            Return mCol
        End Function
#End Region

#Region "IColeccionable"
        Dim mEstadoColeccion As IColeccionable.EstadosColeccion
        Public Property EstadoColeccion() As IColeccionable.EstadosColeccion Implements IColeccionable.EstadoColeccion
            Get
                Return mEstadoColeccion
            End Get
            Set(ByVal value As IColeccionable.EstadosColeccion)
                mEstadoColeccion = value
            End Set
        End Property

        Dim mIndiceColeccion As Integer
        Public Property IndiceColeccion() As Integer Implements IColeccionable.IndiceColeccion
            Get
                Return mIndiceColeccion
            End Get
            Set(ByVal value As Integer)
                mIndiceColeccion = value
            End Set
        End Property


#End Region

#Region "FamiliaPAtente"
        Public Sub EliminarFamiliaPatente(ByVal pFamiliaPatente As FamiliaPatente)
            EliminarFamiliaPatente(pFamiliaPatente.IndiceColeccion)
        End Sub
        Public Sub EliminarFamiliaPatente(ByVal pIndice As Integer)
            If Me.mFamiliaPatente(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Then
                Me.mFamiliaPatente(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Quitado
            Else
                Me.mFamiliaPatente(pIndice).EstadoColeccion = IColeccionable.EstadosColeccion.Borrado
            End If

        End Sub
        Public Sub ModificarFamiliaPatente(ByVal pFamiliaPatente As FamiliaPatente)
            Me.mFamiliaPatente(pFamiliaPatente.IndiceColeccion) = pFamiliaPatente
            If Not pFamiliaPatente.EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Then
                pFamiliaPatente.EstadoColeccion = IColeccionable.EstadosColeccion.Modificado
            End If

        End Sub
        Public Sub AgregarFamiliaPatente(ByVal pFamiliaPatente As FamiliaPatente)
            Me.mFamiliaPatente.Add(pFamiliaPatente)
            Dim mInd As Integer = Me.mFamiliaPatente.IndexOf(pFamiliaPatente)
            Me.mFamiliaPatente(mInd).IndiceColeccion = mInd
            Me.mFamiliaPatente(mInd).EstadoColeccion = IColeccionable.EstadosColeccion.Agregado

            'POR ULTIMO EL NUEVO FamiliaPatente DEBE SABER A QUE Casa PERTENECE
            Me.mFamiliaPatente(mInd).id_familia = mId
        End Sub
        Private Sub GuardarFamiliaPatentes()
            Dim mLock As New Object
            Dim mReacomodar As Boolean = False
            SyncLock mLock
                Dim mEliminados As Integer = 0
                For x As Integer = 0 To Me.mFamiliaPatente.Count - 1
                    Select Case Me.mFamiliaPatente(x - mEliminados).EstadoColeccion
                        Case IColeccionable.EstadosColeccion.Agregado, IColeccionable.EstadosColeccion.Modificado
                            If Me.mFamiliaPatente(x - mEliminados).id_patente = 0 Then
                                Me.mFamiliaPatente(x - mEliminados).id_patente = mId
                            End If
                            Me.mFamiliaPatente(x - mEliminados).Guardar()
                            Me.mFamiliaPatente(x - mEliminados).EstadoColeccion = IColeccionable.EstadosColeccion.SinCambio

                        Case IColeccionable.EstadosColeccion.Borrado
                            Me.mFamiliaPatente(x - mEliminados).Eliminar()
                            Me.mFamiliaPatente.RemoveAt(Me.mFamiliaPatente(x - mEliminados).IndiceColeccion)
                            mEliminados += 1
                            mReacomodar = True

                        Case IColeccionable.EstadosColeccion.Quitado
                            Me.mFamiliaPatente.RemoveAt(Me.mFamiliaPatente(x - mEliminados).IndiceColeccion)
                            mEliminados += 1
                            mReacomodar = True
                    End Select

                Next
            End SyncLock

            'SI SE HA QUITADO ALGUN ELEMENTO DE LA COLECCION< DEBEREMOS REACOMODAR LOS INDICES
            'QUE CADA OBJETO CONOCE DE SI MISMO
            If mReacomodar Then
                Me.ReacomodarIndices()
            End If
        End Sub
        Private Sub ReacomodarIndices()
            'A CADA ELEMENTO DE LA COLECCION LE AVISAMOS CUAL ES SU NUEVO INDICE
            For Each mT As FamiliaPatente In Me.mFamiliaPatente
                mT.IndiceColeccion = Me.mFamiliaPatente.IndexOf(mT)
            Next
        End Sub
        Private Sub CargarFamiliaPatente()
            'AL CARGAR LOS FamiliaPatentes SIMPLEMENTE ASIGAMOS LA COLECCION QUE DEVUELVE EL METODO
            'LISTAR
            'INMEDIATAMENTE DESPUES LE AVISAMOS A CADA OBJETO FamiliaPatente QUE INDICE LE TOCO EN LA LISTA
            If mFamiliaPatente.Count = 0 Then
                Me.mFamiliaPatente = (New Negocio.FamiliaPatente).Listar(mId)
            End If


            For Each mT As FamiliaPatente In mFamiliaPatente
                mT.IndiceColeccion = Me.mFamiliaPatente.IndexOf(mT)
            Next
        End Sub
        Private Function FiltrarFamiliaPatenteNoVisibles() As Collections.Generic.List(Of FamiliaPatente)
            'ESTE METODO PERMITIRA FILTRAR LOS FamiliaPatentes ANTES DE MOSTRARLOS EN UN GRILLA
            'SE SUPONE QUE EN LA GRILLA NO SE VERAN LOS FamiliaPatentes BORRADOS Y QUITADOS
            Dim mCol As New Collections.Generic.List(Of FamiliaPatente)
            CargarFamiliaPatente()

            For Each mT As FamiliaPatente In Me.mFamiliaPatente
                If mT.EstadoColeccion = IColeccionable.EstadosColeccion.Agregado Or mT.EstadoColeccion = IColeccionable.EstadosColeccion.Modificado Or mT.EstadoColeccion = IColeccionable.EstadosColeccion.SinCambio Then
                    mCol.Add(mT)
                End If
            Next
            ReacomodarIndices()
            Return mCol
        End Function
        Public Function ObtenerFamiliaPatentePorIndice(ByVal pIndice As Integer) As FamiliaPatente
            Return Me.mFamiliaPatente(pIndice)
        End Function
#End Region

    End Class
End Namespace
