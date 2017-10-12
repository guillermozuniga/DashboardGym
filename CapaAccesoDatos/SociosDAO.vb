Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports CapaEntidades

Public Class SociosDAO
#Region "PATRON SINGLETON"
    Private Shared _SociosDAO As SociosDAO = Nothing

    Private Sub New()

    End Sub


    Public Shared Function getInstance() As SociosDAO
        If _SociosDAO Is Nothing Then
            _SociosDAO = New SociosDAO

        End If
        Return _SociosDAO

    End Function

#End Region

#Region "Rutinas"
    Public Function SumaSociosActivos() As DataTable

        Dim conxion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim _Fecha As String
        _Fecha = Format(Date.Now, "yyyyMMdd")
        Try

            conxion = Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SumaSociosActivos2", conxion)
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

    Public Function SumaSociosNuevos() As DataTable

        Dim conxion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim _Fecha, _FechaFinal As String
        Dim fechainicio As New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)

        Dim fechafin As DateTime = fechainicio.AddMonths(1).AddDays(-1)


        '_Fecha = Format(fechainicio, "yyyyMMdd")
        _Fecha = Format(Date.Now, "yyyyMMdd")
        _FechaFinal = Format(fechafin, "yyyyMMdd")

        Try

            conxion = Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SumaSociosNuevos", conxion)
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

    Public Function SumaSociosPorVencer() As DataTable

        Dim conxion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim _Fecha, _FechaFin As String
        _Fecha = Format(Date.Now, "yyyyMMdd")
        _FechaFin = Format(Date.Now.AddDays(2), "yyyyMMdd")
        Try

            conxion = Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SumaSociosPorVencer", conxion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Fecha", _Fecha)
            cmd.Parameters.AddWithValue("@FechaFinal", _FechaFin)
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

    Public Function SumaSociosQueRenovaron() As DataTable

        Dim conxion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim _Fecha, _FechaFin As String
        _Fecha = Format(Date.Now, "yyyyMMdd")
        _FechaFin = Format(Date.Now.AddDays(2), "yyyyMMdd")
        Try

            conxion = Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SumaSociosquerenovaron", conxion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Fecha", _Fecha)
            'cmd.Parameters.AddWithValue("@FechaFinal", _FechaFin)
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

    Public Function SumaSociosQueNoRenovaron() As DataTable

        Dim conxion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim _Fecha, _FechaFin As String
        _Fecha = Format(Date.Now, "yyyyMMdd")
        _FechaFin = Format(Date.Now.AddDays(-1), "yyyyMMdd")


        Try

            conxion = Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SumaSociosqueNorenovaron", conxion)
            cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.AddWithValue("@Fecha", _Fecha)
            cmd.Parameters.AddWithValue("@FechaFinal", _FechaFin)
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


    Public Function Vencidosconasistencia() As DataTable
        Dim conxion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim _Fecha, _FechaFin As String
        _Fecha = Format(Date.Now, "yyyyMMdd")
        _FechaFin = Format(Date.Now.AddDays(-1), "yyyyMMdd")


        Try

            conxion = Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SumaSociosVencidosconasistencia", conxion)
            cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.AddWithValue("@Fecha", _Fecha)
            cmd.Parameters.AddWithValue("@FechaFinal", _FechaFin)
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
