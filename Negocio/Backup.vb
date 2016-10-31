Imports System.IO
Imports Datos.ProveedorDeDatos.DB
Imports Ionic.Zip

Namespace Negocio

    Public Class Backup

#Region "Declaraciones"
        Dim mId As Integer = 0
        Dim mDescripcion As String
        Dim mRuta As String
        Dim mFecha As Date
        Dim mIdUsuarioAlta As Integer
        Dim mCantVolumen As Integer

        Private Shared ProximoId As Integer

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
        Public Sub New(ByVal pDTO As DTO.BackupDTO)
            Me.Cargar(pDTO)
        End Sub
#End Region

#Region "Propiedades"
        Public Overridable ReadOnly Property id() As Integer
            Get
                Return mId
            End Get
        End Property

        Public Property descripcion() As String
            Get
                Return mDescripcion
            End Get
            Set(ByVal value As String)
                mDescripcion = value
            End Set
        End Property

        Public Property ruta() As String
            Get
                Return mRuta
            End Get
            Set(ByVal value As String)
                mRuta = value
            End Set
        End Property

        Public Property idUsuarioAlta() As Integer
            Get
                Return mIdUsuarioAlta
            End Get
            Set(ByVal value As Integer)
                mIdUsuarioAlta = value
            End Set
        End Property

        Public Property fecha() As Date
            Get
                Return mFecha
            End Get
            Set(ByVal value As Date)
                mFecha = value
            End Set
        End Property

        Public Property cantVolumen() As Integer
            Get
                Return mCantVolumen
            End Get
            Set(ByVal value As Integer)
                mCantVolumen = value
            End Set
        End Property
#End Region

#Region "Métodos"

        Public Overridable Sub GuardarNuevo()
            Dim mDTO As New DTO.BackupDTO
            Dim hora As String = Now.Hour.ToString & Now.Minute.ToString & Now.Second.ToString
            Dim fecha As String = Now.Day & Now.Month & Now.Year
            Dim nombreArchivoBak As String = fecha & hora & "_V" & Me.cantVolumen & ".bak"
            Dim rutaCompletaBak As String = Me.ruta & nombreArchivoBak
            Dim rutaCompletaTemp As String = rutaCompletaBak.Replace(".bak", ".temp")
            Dim rutaCompletaZip As String = rutaCompletaBak.Replace(".bak", ".zip")
            Dim archivoBackup As FileInfo
            Dim tamanioArchivoBackup As Long
            Dim maxOutputSegmentSize As Long

            If Directory.Exists(ruta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(ruta)
            End If


            mDTO.descripcion = Me.descripcion
            mDTO.ruta = rutaCompletaBak
            mDTO.fecha = Me.fecha
            mDTO.idUsuarioAlta = Me.idUsuarioAlta
            mDTO.cantVolumen = Me.cantVolumen

            If mId = 0 Then
                mDTO.id = Datos.BackupDatos.ObtenerProximoId()
                Datos.BackupDatos.GuardarNuevo(mDTO)
            End If


            If File.Exists(rutaCompletaBak) Then
                ' comprimo
                Using zip As ZipFile = New ZipFile()
                    zip.AddFile(rutaCompletaBak, "")
                    zip.Save(rutaCompletaTemp)
                End Using


                ' si se creo correctamente busco el tamaño para
                ' dividirlo en las partes solicitadas
                archivoBackup = New FileInfo(rutaCompletaTemp)
                tamanioArchivoBackup = archivoBackup.Length

                maxOutputSegmentSize = Math.Round(tamanioArchivoBackup / Me.cantVolumen)
                ' el tamaño minimo es 65560
                If maxOutputSegmentSize < 65560 Then
                    maxOutputSegmentSize = 65560
                End If

                ' comprimo nuevamente el archivo final indicando la cantidad de volumenes
                Using zip As ZipFile = New ZipFile()
                    zip.AddFile(rutaCompletaBak, "")
                    zip.MaxOutputSegmentSize = maxOutputSegmentSize
                    zip.Save(rutaCompletaZip)
                End Using

                ' elimino archivos .bak y .temp
                'If File.Exists(rutaCompletaBak) Then
                ' File.Delete(rutaCompletaBak)
                'End If

                If File.Exists(rutaCompletaTemp) Then
                    File.Delete(rutaCompletaTemp)
                End If

            End If

        End Sub
        Public Overridable Sub Cargar()
            If mId > 0 Then
                Dim mDTO As DTO.BackupDTO = Datos.BackupDatos.Obtener(mId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Backup sin Id especificado")

            End If
        End Sub
        Public Overridable Sub Cargar(ByVal pDr As DataRow)
            Try
                mDescripcion = pDr("descripcion")
                mRuta = pDr("ruta")
                mFecha = pDr("fecha")
                mIdUsuarioAlta = pDr("id_usuario_alta")
                mCantVolumen = pDr("cant_volumen")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Public Overridable Sub Restaurar(ByVal pRuta As String)
            Dim rutaCompletaZip As String = pRuta
            Dim rutaCompletaBak As String = pRuta.Replace(".zip", ".bak")
            Dim directorioDestino As String = Path.GetDirectoryName(rutaCompletaZip) & "\"

            Using zip As ZipFile = ZipFile.Read(rutaCompletaZip)
                'zip.ExtractAll(directorioDestino)
                For Each arch As Ionic.Zip.ZipEntry In zip
                    arch.Extract(directorioDestino, ExtractExistingFileAction.OverwriteSilently)
                Next
            End Using

            If File.Exists(rutaCompletaBak) Then
                Datos.BackupDatos.Restaurar(rutaCompletaBak)
                'If File.Exists(rutaCompletaBak) Then
                'File.Delete(rutaCompletaBak)
                    'End If
                Else
                Throw New ApplicationException("Se produjo un error descomprimiendo el archivo")
            End If
        End Sub

        Public Overridable Sub Cargar(ByVal pId As Integer)
            If mId > 0 Then
                Dim mDTO As DTO.BackupDTO = Datos.BackupDatos.Obtener(pId)
                MyClass.Cargar(mDTO)
            Else
                Throw New ApplicationException("Se intentó cargar un Backup sin Id especificado")
            End If
        End Sub
        Public Sub Cargar(ByVal pDTO As DTO.BackupDTO)
            mId = pDTO.id
            mDescripcion = pDTO.descripcion
            mRuta = pDTO.ruta
            mFecha = pDTO.fecha
            mIdUsuarioAlta = pDTO.idUsuarioAlta
            mCantVolumen = pDTO.cantVolumen
        End Sub

        Public Overridable Sub Eliminar()
            If mId > 0 Then
                Try
                    Datos.BebidaDatos.Eliminar(mId)
                Catch ex As Exception
                    Throw New ApplicationException("Error al borrar el backup especificado.", ex)
                End Try

            Else
                Throw New ApplicationException("Se intentó eliminar un backup sin Id especifico.")
            End If
        End Sub

        Private Shared Function ObtenerProximoId() As Integer
            If ProximoId = 0 Then
                Dim mTempId As Object = Datos.BackupDatos.ObtenerProximoId()
            End If
            ProximoId += 1
            Return ProximoId
        End Function

        Public Sub ValidarFormato(pid_idioma As Integer)
            Try
                If (Me.descripcion = "") Then
                    Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar la descripción corta."))
                End If
                If (Me.ruta = "") Then
                    Throw New ApplicationException(Negocio.Traductor.ObtenerTraduccion(pid_idioma, "Debe completar la ruta."))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Throw
            End Try
        End Sub

        Public Overridable Function Listar() As Collections.Generic.List(Of Backup)
            Dim mCol As New Collections.Generic.List(Of Backup)
            Dim mColDTO As List(Of DTO.BackupDTO) = Datos.BackupDatos.Listar()

            For Each mDTO As DTO.BackupDTO In mColDTO
                mCol.Add(New Negocio.Backup(mDTO))
            Next

            Return mCol
        End Function
#End Region


    End Class
End Namespace
