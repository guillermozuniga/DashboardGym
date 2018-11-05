Imports System.Data
Imports System.Data.SqlClient


Public Class ClsFunciones
    Dim cmd As New SqlCommand
    'Dim db As SqlConnection = New SqlConnection(Conexion.getInstance.Conexiondb)

    Public Function SeleccionarDatos(ByVal Sentencia As String) As DataTable

        cmd = New SqlCommand(Sentencia) With {
            .CommandType = CommandType.Text,
            .Connection = Conexion.getInstance.Conexiondb
        }

        Try
            cmd.Connection.Open()

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
                ' cmd.Connection.Dispose()
            End If
        End Try
    End Function
End Class
