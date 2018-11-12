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
                objEmpresa = New EmpresaEnt With {
                    .Empresa_ID = Convert.ToInt32(dr("Empresa_ID").ToString()),
                    .Empresa_RazonSocial = dr("Empresa_RazonSocial").ToString(),
                    .Empresa_RFC = dr("Empresa_RFC").ToString,
                    .Empresa_NombreCorto = dr("Empresa_NombreCorto").ToString
                }

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

    Public Function BuscarEmpresa(ByVal valor As Integer) As EmpresaEnt
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objEmpresa As EmpresaEnt = Nothing

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("sp_SGEbuscarEmpresa", conexion)
            cmd.Parameters.AddWithValue("@prmEmpresa_Id", valor)
            cmd.CommandType = CommandType.StoredProcedure

            conexion.Open()
            dr = cmd.ExecuteReader()

            If (dr.Read()) Then
                objEmpresa = New EmpresaEnt With {
                    .Empresa_RazonSocial = dr("RazonSocial").ToString(),
                    .Empresa_RFC = dr("RFC").ToString(),
                    .Empresa_NombreCorto = dr("NombreCorto").ToString(),
                    .Empresa_CURP = dr("CURP").ToString(),
                    .Empresa_Direccion_Calle = dr("Calle").ToString(),
                    .Empresa_Direccion_CPostal = dr("Cpostal").ToString(),
                    .Empresa_Direccion_Colonia = dr("Colonia").ToString(),
                    .Empresa_Direccion_Localidad = dr("Localidad").ToString(),
                    .Empresa_Direccion_Municipio = dr("Municipio").ToString(),
                    .Empresa_NombreComercial = dr("NombreComercial").ToString(),
                    .Empresa_Telefono1 = dr("Tel1").ToString(),
                    .Empresa_Telefono2 = dr("Tel2").ToString(),
                    .Empresa_Telefono3 = dr("Tel3").ToString(),
                    .Empresa_eMail = dr("eMail").ToString(),
                    .Empresa_Direccion_Estado = dr("Estado").ToString(),
                    .Empresa_Dominio = dr("dominio").ToString(),
                    .Empresa_Direccion_NoExterior = dr("NoExterior").ToString(),
                    .Empresa_Direccion_NoInterior = dr("NoInterior").ToString(),
                    .Empresa_Movil = dr("Movil").ToString()
                }

            End If

        Catch ex As Exception
            objEmpresa = Nothing

            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try

        Return objEmpresa
    End Function

    Public Function RegistrarEmpresa(objEmpresa As EmpresaEnt) As Boolean

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim resp As Boolean = False
        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_InsertarEmpresa", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }

            cmd.Parameters.AddWithValue("@Empresa_Nombrecomercial", objEmpresa.Empresa_NombreComercial)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Calle", objEmpresa.Empresa_Direccion_Calle)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_NoExterior", objEmpresa.Empresa_Direccion_NoExterior)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_NoInterior", objEmpresa.Empresa_Direccion_NoInterior)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Colonia", objEmpresa.Empresa_Direccion_Colonia)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Municipio", objEmpresa.Empresa_Direccion_Municipio)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Localidad", objEmpresa.Empresa_Direccion_Localidad)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Estado", objEmpresa.Empresa_Direccion_Estado)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Cpostal", objEmpresa.Empresa_Direccion_CPostal)
            cmd.Parameters.AddWithValue("@Empresa_RFC", objEmpresa.Empresa_RFC)
            cmd.Parameters.AddWithValue("@Empresa_CURP", objEmpresa.Empresa_CURP)
            cmd.Parameters.AddWithValue("@Empresa_NombreCorto", objEmpresa.Empresa_NombreCorto)
            cmd.Parameters.AddWithValue("@Empresa_RazonSocial", objEmpresa.Empresa_RazonSocial)

            conexion.Open()

            Dim Fila As Integer = cmd.ExecuteNonQuery()
            If Fila > 0 Then resp = True

        Catch ex As Exception
            objEmpresa = Nothing
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

    Public Function ModificarEmpresa(objEmpresa As EmpresaEnt) As Boolean

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim resp As Boolean = False

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SGEActualizarEmpresa", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }
            cmd.Parameters.AddWithValue("@Empresa_Id", Convert.ToInt32(objEmpresa.Empresa_ID))
            cmd.Parameters.AddWithValue("@Empresa_RazonSocial", objEmpresa.Empresa_RazonSocial)
            cmd.Parameters.AddWithValue("@Empresa_Nombrecomercial", objEmpresa.Empresa_NombreComercial)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Calle", objEmpresa.Empresa_Direccion_Calle)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_NoExterior", objEmpresa.Empresa_Direccion_NoExterior)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_NoInterior", objEmpresa.Empresa_Direccion_NoInterior)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Colonia", objEmpresa.Empresa_Direccion_Colonia.ToUpper)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Municipio", objEmpresa.Empresa_Direccion_Municipio.ToUpper)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Localidad", objEmpresa.Empresa_Direccion_Localidad.ToUpper)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Estado", objEmpresa.Empresa_Direccion_Estado.ToUpper)
            cmd.Parameters.AddWithValue("@Empresa_Direccion_Cpostal", objEmpresa.Empresa_Direccion_CPostal)
            cmd.Parameters.AddWithValue("@Empresa_CURP", objEmpresa.Empresa_CURP)
            cmd.Parameters.AddWithValue("@Empresa_NombreCorto", objEmpresa.Empresa_NombreCorto)
            cmd.Parameters.AddWithValue("@Empresa_Telefono1", objEmpresa.Empresa_Telefono1)
            cmd.Parameters.AddWithValue("@Empresa_Telefono2", objEmpresa.Empresa_Telefono2)
            cmd.Parameters.AddWithValue("@Empresa_Telefono3", objEmpresa.Empresa_Telefono3)
            cmd.Parameters.AddWithValue("@Empresa_Dominio", objEmpresa.Empresa_Dominio)
            cmd.Parameters.AddWithValue("@Empresa_eMail", objEmpresa.Empresa_eMail)
            cmd.Parameters.AddWithValue("@Empresa_Movil", objEmpresa.Empresa_Movil)

            conexion.Open()
            If CBool(cmd.ExecuteNonQuery) Then
                resp = True
            End If
        Catch ex As Exception
            objEmpresa = Nothing
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
#End Region
End Class
