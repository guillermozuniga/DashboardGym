Imports System.Data.SqlClient
Imports System.Web
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
    Public Function ListarAlumnos(ByVal _Sentencia As String) As List(Of AlumnoEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objAlumnos As AlumnoEnt = Nothing

        Dim ListaAlumnos As List(Of AlumnoEnt) = New List(Of AlumnoEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand(_Sentencia, conexion) With {
                .CommandType = CommandType.Text
            }
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objAlumnos = New AlumnoEnt With {
                .Alumnos_Matricula = dr("Alumnos_Matricula").ToString(),
                .Alumnos_CURP = dr("Alumnos_CURP").ToString(),
                .Alumnos_FechaDeNacimiento = dr("Alumnos_FechadeNacimiento").ToString(),
                .Nombre = HttpUtility.HtmlDecode(dr("Nombre").ToString()),
                .Alumnos_ID = dr("Alumnos_Id")
                }
                ListaAlumnos.Add(objAlumnos)
            End While


        Catch ex As Exception
            objAlumnos = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If
        End Try

        Return ListaAlumnos
    End Function

    Public Function ListarAlumnosxTutor(ByVal _sqlSentencia As String) As List(Of AlumnoEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objAlumnos As AlumnoEnt = Nothing

        Dim ListaAlumnos As List(Of AlumnoEnt) = New List(Of AlumnoEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand(_sqlSentencia, conexion) With {
                .CommandType = CommandType.Text
            }
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objAlumnos = New AlumnoEnt With {
                .Alumnos_Matricula = dr("Alumnos_Matricula").ToString(),
                .Alumnos_CURP = dr("Alumnos_CURP").ToString(),
                .Alumnos_FechaDeNacimiento = dr("Alumnos_FechadeNacimiento").ToString(),
                .Nombre = dr("Nombre").ToString(),
                .Alumnos_ID = dr("Alumnos_Id"),
                .Alumnos_GrupoGrado = dr("GrupoGrado").ToString(),
                .Alumnos_NombreNivel = dr("NombreNivel").ToString()
                }
                ListaAlumnos.Add(objAlumnos)
            End While


        Catch ex As Exception
            objAlumnos = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If
        End Try

        Return ListaAlumnos
    End Function

    Public Function RegistrarAlumnos() As List(Of AlumnoEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing

        Dim objAlumnos As AlumnoEnt = Nothing

        Dim ListaAlumnos As List(Of AlumnoEnt) = New List(Of AlumnoEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_InsertarAlumno", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }
            cmd.Parameters.Add("")
            conexion.Open()



        Catch ex As Exception
            objAlumnos = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If
        End Try

        Return ListaAlumnos
    End Function

#End Region
End Class
