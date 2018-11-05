Imports System.Data.SqlClient
Imports CapaEntidades
Public Class EmpleadosDAO
#Region "PATRON SINGLETON"
    Private Shared _EmpleadosDAO As EmpleadosDAO = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As EmpleadosDAO
        If _EmpleadosDAO Is Nothing Then
            _EmpleadosDAO = New EmpleadosDAO

        End If
        Return _EmpleadosDAO

    End Function
#End Region

#Region "Rutinas"
    Public Function ListarEmpleados() As List(Of EmpleadoEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objEmpleados As EmpleadoEnt = Nothing

        Dim ListaEmpleados As List(Of EmpleadoEnt) = New List(Of EmpleadoEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarEmpleados", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }

            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objEmpleados = New EmpleadoEnt With {
               .Empleados_CURP = dr("Empleados_CURP").ToString(),
               .Nombre = dr("Nombre").ToString(),
               .Empleados_Numero = dr("Empleados_Numero").ToString(),
               .Empleados_IMSS = dr("Empleados_Imss").ToString(),
               .Empleados_RFC = dr("Empleados_RFC").ToString(),
               .Empleados_AreaLaboral = dr("Empleados_AreaLaboral").ToString(),
               .Empleados_eMail = dr("Empleados_eMail").ToString()
                }
                ListaEmpleados.Add(objEmpleados)
            End While

        Catch ex As Exception
            objEmpleados = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If
        End Try


        Return ListaEmpleados

    End Function


    Public Function BuscarEmpleado(ByVal valor As Integer) As EmpleadoEnt
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objEmpleado As EmpleadoEnt = Nothing

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SGEbuscarEmpleado", conexion)
            cmd.Parameters.AddWithValue("@prmEmpleado_Numero", valor)
            cmd.CommandType = CommandType.StoredProcedure

            conexion.Open()
            dr = cmd.ExecuteReader()

            If (dr.Read()) Then
                objEmpleado = New EmpleadoEnt With {
                    .Empleados_RFC = dr("RFC").ToString(),
                    .Empleados_CURP = dr("CURP").ToString(),
                    .Empleados_Direccion_Calle = dr("Calle").ToString(),
                    .Empleados_DIreccion_CPostal = dr("Cpostal").ToString(),
                    .Empleados_Direccion_Colonia = dr("Colonia").ToString(),
                    .Empleados_Direccion_Localidad = dr("Localidad").ToString(),
                    .Empleados_Direccion_Municipio = dr("Municipio").ToString(),
                    .Empleados_Telefono = dr("Tel1").ToSring(),
                    .Empleados_eMail = dr("eMail").ToString(),
                    .Empleados_Direccion_Estado = dr("Estado").ToString(),
                    .Empleados_Movil = dr("Movil").ToString()
                }

            End If

        Catch ex As Exception
            objEmpleado = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try

        Return objEmpleado

    End Function


    Public Function RegistrarEmpleado(objEmpleado As EmpleadoEnt) As Boolean

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim resp As Boolean = False
        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_InsertarEmpleado", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }

            'cmd.Parameters.AddWithValue("@Empresa_Direccion_Calle", objEmpresa.Empresa_Direccion_Calle)
            'cmd.Parameters.AddWithValue("@Empresa_Direccion_Colonia", objEmpresa.Empresa_Direccion_Colonia)
            'cmd.Parameters.AddWithValue("@Empresa_Direccion_Municipio", objEmpresa.Empresa_Direccion_Municipio)
            'cmd.Parameters.AddWithValue("@Empresa_Direccion_Localidad", objEmpresa.Empresa_Direccion_Localidad)
            'cmd.Parameters.AddWithValue("@Empresa_Direccion_Estado", objEmpresa.Empresa_Direccion_Estado)
            'cmd.Parameters.AddWithValue("@Empresa_Direccion_Cpostal", objEmpresa.Empresa_Direccion_CPostal)
            'cmd.Parameters.AddWithValue("@Empresa_RFC", objEmpresa.Empresa_RFC)
            'cmd.Parameters.AddWithValue("@Empresa_CURP", objEmpresa.Empresa_CURP)

            conexion.Open()

            Dim Fila As Integer = cmd.ExecuteNonQuery()
            If Fila > 0 Then resp = True

        Catch ex As Exception
            'objEmpresa = Nothing
            resp = False
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try

        Return resp

    End Function


    Public Function BuscarEmpleados(ByVal valor As Integer) As EmpleadoEnt
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objEmpleado As EmpleadoEnt = Nothing

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SGEbuscarEmpleado", conexion)
            cmd.Parameters.AddWithValue("@prmEmpleado_Numero", valor)
            cmd.CommandType = CommandType.StoredProcedure

            conexion.Open()
            dr = cmd.ExecuteReader()

            If (dr.Read()) Then
                objEmpleado = New EmpleadoEnt With {
                    .Empleados_RFC = dr("RFC").ToString(),
                    .Empleados_CURP = dr("CURP").ToString(),
                    .Empleados_Direccion_Calle = dr("Calle").ToString(),
                    .Empleados_DIreccion_CPostal = dr("Cpostal").ToString(),
                    .Empleados_Direccion_Colonia = dr("Colonia").ToString(),
                    .Empleados_Direccion_Localidad = dr("Localidad").ToString(),
                    .Empleados_Direccion_Municipio = dr("Municipio").ToString(),
                    .Empleados_Telefono = dr("Tel1").ToSring(),
                    .Empleados_eMail = dr("eMail").ToString(),
                    .Empleados_Direccion_Estado = dr("Estado").ToString(),
                    .Empleados_Movil = dr("Movil").ToString()
                }

            End If

        Catch ex As Exception
            objEmpleado = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try

        Return objEmpleado

    End Function

#End Region
End Class
