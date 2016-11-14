Imports Negocio.Conexion

Public Class Conexion
    Dim mConexion As Negocio.Conexion
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim strConn As String
        strConn = "Data Source=.\" & Me.txt_servidor.Text & ";Initial Catalog=" & Me.txt_base_de_datos.Text & ";Integrated Security=True"
        mConexion = New Negocio.Conexion
        mConexion.CambiarString(strConn)

        MessageBox.Show("Se modificó el string de conexión, reinicie la aplicación y vuelva a iniciar sesión")
        Application.Exit()
    End Sub

    Private Sub Conexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class