Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports CapaEntidades

Public Class UNegocioDAO
#Region "PATRON SINGLETON"
    Private Shared _UNegocioDAO As UNegocioDAO = Nothing

    Private Sub New()

    End Sub


    Public Shared Function getInstance() As UNegocioDAO
        If _UNegocioDAO Is Nothing Then
            _UNegocioDAO = New UNegocioDAO

        End If
        Return _UNegocioDAO

    End Function

#End Region

#Region "Rutinas"
    Public Function GetSumaUNegocios() As DataTable

        Dim conxion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        Try

            conxion = Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_GetAllGimnasios", conxion)
            cmd.CommandType = CommandType.StoredProcedure
            ' cmd.Connection.Open()
            da.SelectCommand = cmd
            da.Fill(dt)

        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex

        Finally

            cmd.Connection.Close()
            cmd.Connection.Dispose()

        End Try

        Return dt

    End Function
#End Region
End Class
