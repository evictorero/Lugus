﻿Imports Datos.ProveedorDeDatos
Imports System.Data.SqlClient
Imports DTO.usuariodto

Public Class UsuarioDatos
    Private Shared ProximoId As Integer
    Public Shared Function Obtener(ByVal pId As Integer) As DTO.UsuarioDTO
        If pId > 0 Then
            Dim mDs As DataSet = DB.ExecuteDataset("SELECT id, nombre, apellido FROM dbo.busuario WHERE id_usuario = " & pId)
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.UsuarioDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else

                Throw New ApplicationException("Fallo al cargar el Usuario.")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar el Usuario sin Id especificado")
            Return Nothing
        End If

    End Function
    Public Shared Function ObtenerPorUsuario(ByVal pUsuario As String) As DTO.UsuarioDTO
        If Not IsNothing(pUsuario) Then
            Dim mDs As DataSet = DB.ExecuteDataset("SELECT id_usuario, usuario, nombre, apellido, dni, email, id_idioma,fecha_nacimiento FROM dbo.busuario WHERE usuario = '" & pUsuario & "'")
            If Not IsNothing(mDs) AndAlso mDs.Tables.Count > 0 AndAlso mDs.Tables(0).Rows.Count > 0 Then
                Dim mDTO As New DTO.UsuarioDTO

                CargarDTO(mDTO, mDs.Tables(0).Rows(0))

                Return mDTO
            Else
                Throw New ApplicationException("Fallo al cargar el Usuario.")
                Return Nothing
            End If
        Else
            Throw New ApplicationException("Se intentó cargar el Usuario sin Id especificado")
            Return Nothing
        End If

    End Function
    Private Shared Sub CargarDTO(ByVal pDTO As DTO.UsuarioDTO, ByVal pDr As DataRow)
        pDTO.id = pDr("id_usuario")
        pDTO.usuario = pDr("usuario")
        pDTO.nombre = pDr("nombre")
        pDTO.apellido = pDr("apellido")
        pDTO.email = pDr("email")
        pDTO.dni = pDr("dni")
        pDTO.id_idioma = pDr("id_idioma")
        ' probando 
        pDTO.fechaNacimiento = pDr("fecha_nacimiento")
    End Sub
    Public Shared Function Listar() As List(Of DTO.UsuarioDTO)

        Dim mCol As New List(Of DTO.UsuarioDTO)
        Dim mDs As DataSet = DB.ExecuteDataset(("SELECT id_usuario, nombre, apellido, email, dni, fecha_nacimiento FROM dbo.busuario "))

        For Each mDr As DataRow In mDs.Tables(0).Rows
            Dim mDTO As New DTO.UsuarioDTO

            CargarDTO(mDTO, mDr)

            mCol.Add(mDTO)
        Next

        Return mCol
    End Function
    Public Shared Function VerificarLogin(pDTO As DTO.UsuarioDTO) As Integer
        Dim mFuncion As String = " select count(*) from dbo.bUsuario where usuario = '" & pDTO.usuario & "' and contraseña = '" & pDTO.contrasenia & "' "
        Dim rta As Integer = -1
        rta = Datos.ProveedorDeDatos.DB.ExecuteScalar(mFuncion)
        If rta > 0 Then
            Return 1 ' USuario y contrase;a correcto
        End If
        mFuncion = " select count(*) from dbo.bUsuario where usuario = '" & pDTO.usuario & "'"
        rta = Datos.ProveedorDeDatos.DB.ExecuteScalar(mFuncion)
        If rta > 0 Then
            mFuncion = " select count(*) from dbo.bUsuario where usuario = '" & pDTO.usuario & "' and contraseña <> '" & pDTO.contrasenia & "' "
            rta = Datos.ProveedorDeDatos.DB.ExecuteScalar(mFuncion)
            'Intentos login 
            If rta > 0 Then
                Return 2  ' USuario OK  y contrase;a NOK
            End If
        Else
            Return 3 'Usuario NOK
        End If
        Return rta
    End Function

    Public Shared Sub GuardarNuevo(ByVal pDTO As DTO.UsuarioDTO)
        Dim mStrCom As String

        mStrCom = "INSERT INTO [dbo].[bUsuario] ([id_usuario],[usuario],[contraseña],[nombre],[apellido],[dni],[email],[id_idioma],[fecha_nacimiento],[dvh],[intentos_login],[fecha_modif],[id_usuario_alta])" &
        " VALUES " &
        "(" & pDTO.id & ", '" & pDTO.usuario & "' , '" & pDTO.contrasenia & "' , '" & pDTO.nombre & "', '" & pDTO.apellido & "', " & pDTO.dni & ", '" & pDTO.email & "', " & pDTO.id_idioma & ",  '" & pDTO.fechaNacimiento & "', " & pDTO.dvh & ", " & pDTO.intentosLogin & ",'" & DateTime.Now.ToString("yyyyMMdd HH:mm:ss") & "'," & pDTO.idUsuarioAlta & ")"
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al insertar el Usuario", ex)
        End Try
    End Sub

    Public Shared Sub GuardarModificacion(ByVal pDTO As DTO.UsuarioDTO)

        Dim mStrCom As String

        mStrCom = "UPDATE bUsuario " &
                   "SET usuario = '" & pDTO.usuario & "'," &
                      " contraseña = '" & pDTO.contrasenia & "'," &
                      "nombre = '" & pDTO.nombre & "'," &
                      "apellido = '" & pDTO.apellido & "'," &
                      "dni = " & pDTO.dni & "," &
                      "email ='" & pDTO.email & "'," &
                      "id_idioma = " & pDTO.id_idioma & "," &
                      "fecha_nacimiento = '" & Format(pDTO.fechaNacimiento, "yyyy/MM/dd") & "'," &
                      "dvh = " & pDTO.dvh & "," &
                      "intentos_login = " & pDTO.intentosLogin & "," &
                      "fecha_modif =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'," &
                      "id_usuario_alta = " & pDTO.idUsuarioAlta &
                     " where id_usuario = " & pDTO.id

        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al modificar el usuario", ex)
        End Try

    End Sub

    Public Shared Sub Eliminar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bUsuario " &
                  " SET fecha_baja =  '" & Format(DateTime.Now, "yyyy/MM/dd") & "'" &
                  " WHERE id_usuario = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al dar de baja el Usuario.", ex)
        End Try
    End Sub

    Public Shared Sub Rehabilitar(ByVal pId As Integer)
        Dim mStrCom As String

        mStrCom = "UPDATE bUsuario " &
                  " SET fecha_baja =  null " &
                  " WHERE id_usuario = " & pId
        Try
            Datos.ProveedorDeDatos.DB.ExecuteNonQuery(mStrCom)
        Catch ex As Exception
            Throw New ApplicationException("Fallo al Rehabilitar el usuario.", ex)
        End Try
    End Sub

End Class
