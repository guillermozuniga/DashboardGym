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
            cmd = New SqlCommand("usp_ListarEmpleados", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objEmpleados = New EmpleadoEnt With {
               .Empleados_CURP = dr("Empleados_CURP"),
               .Nombre = dr("Nombre"),
               .Empleados_Numero = dr("Empleados_Numero"),
               .Empleados_IMSS = dr("Empleados_Imss"),
               .Empleados_RFC = dr("Empleados_RFC")
                }
                ListaEmpleados.Add(objEmpleados)
            End While

        Catch ex As Exception
            objEmpleados = Nothing
            Throw ex
        Finally
            conexion.Close()
            conexion.Dispose()

        End Try


        Return ListaEmpleados

    End Function

#End Region
End Class
