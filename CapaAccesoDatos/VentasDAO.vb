Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports CapaEntidades

Public Class VentasDAO
#Region "PATRON SINGLETON"
    Private Shared _VentasDAO As VentasDAO = Nothing

    Private Sub New()

    End Sub


    Public Shared Function getInstance() As VentasDAO
        If _VentasDAO Is Nothing Then
            _VentasDAO = New VentasDAO

        End If
        Return _VentasDAO

    End Function

#End Region

#Region "Rutinas"

    Public Function TotalVentas() As DataTable

        Dim conxion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim _Fecha As String
        _Fecha = Format(Date.Now, "yyyyMMdd")
        Try

            conxion = Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SumaVentas", conxion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Fecha", _Fecha)
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

    Public Function GeneralVentas(ByVal Fechaini As String, ByVal FechaFin As String, ByVal IDGim As Integer) As DataTable
        Dim conxion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim _Fecha As String
        _Fecha = Format(Date.Now, "yyyyMMdd")
        Try

            conxion = Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("Select * from v_VtasGral where Fecha >=N'" & Fechaini & "' and Fecha <='N" & FechaFin & "' and IDGimnasio = " & IDGim, conxion)
            cmd.CommandType = CommandType.Text
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
