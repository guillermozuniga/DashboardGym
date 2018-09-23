Imports System.Data.SqlClient
Imports CapaEntidades
Public Class AlumnoDAO
#Region "PATRON SINGLETON"
    Private Shared _AlumnoDAO As AlumnoDAO = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As AlumnoDAO
        If _AlumnoDAO Is Nothing Then
            _AlumnoDAO = New AlumnoDAO
        End If
        Return _AlumnoDAO

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarAlumnos() As List(Of AlumnoEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objAlumnos As AlumnoEnt = Nothing

        Dim ListaAlumnos As List(Of AlumnoEnt) = New List(Of AlumnoEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarAlumnos", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objAlumnos = New AlumnoEnt With {
                .Alumnos_Matricula = dr("Alumnos_Matricula"),
                .Alumnos_CURP = dr("Alumnos_CURP"),
                .Alumnos_FechaDeNacimiento = dr("Alumnos_FechadeNacimiento"),
                .Nombre = dr("Nombre")
                }
                ListaAlumnos.Add(objAlumnos)
            End While


        Catch ex As Exception
            objAlumnos = Nothing
            Throw ex
        Finally
            conexion.Close()
            conexion.Dispose()

        End Try

        Return ListaAlumnos
    End Function


#End Region
End Class
