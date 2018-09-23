Imports System.Data.SqlClient
Imports CapaEntidades

Public Class EmpresaDAO
#Region "PATRON SINGLETON"
    Private Shared _EmpresaDAO As EmpresaDAO = Nothing

    Private Sub New()

    End Sub


    Public Shared Function GetInstance() As EmpresaDAO
        If _EmpresaDAO Is Nothing Then
            _EmpresaDAO = New EmpresaDAO

        End If
        Return _EmpresaDAO

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarEmpresa() As List(Of EmpresaEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objEmpresa As EmpresaEnt = Nothing

        Dim ListEmpresa As List(Of EmpresaEnt) = New List(Of EmpresaEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarEmpresa", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objEmpresa = New EmpresaEnt()

                objEmpresa.Empresa_ID = Convert.ToInt32(dr("Empresa_ID").ToString)
                objEmpresa.Empresa_RazonSocial = dr("Empresa_RazonSocial").ToString
                objEmpresa.Empresa_RFC = Convert.ToInt32(dr("Empresa_RFC").ToString)

                ListEmpresa.Add(objEmpresa)
            End While
        Catch ex As Exception
            objEmpresa = Nothing

            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try

        Return ListEmpresa


    End Function

#End Region
End Class
