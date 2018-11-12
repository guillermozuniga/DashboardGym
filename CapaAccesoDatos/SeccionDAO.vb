Imports System.Data.SqlClient
Imports CapaEntidades
Public Class SeccionDAO
#Region "PATRON SINGLETON"
    Private Shared _SeccionDAO As SeccionDAO = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As SeccionDAO
        If _SeccionDAO Is Nothing Then
            _SeccionDAO = New SeccionDAO

        End If
        Return _SeccionDAO
    End Function
#End Region

#Region "Rutinas"
    Public Function ListarSeccion(ByVal valor As Integer) As List(Of SeccionesEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objSeccion As SeccionesEnt = Nothing

        Dim ListaSeccion As List(Of SeccionesEnt) = New List(Of SeccionesEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarNiveles", conexion)
            cmd.Parameters.AddWithValue("@prmNivel_Id", valor)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objSeccion = New SeccionesEnt With {
                .Nivel_ID = CType(dr("Nivel_ID"), Integer),
                .Nivel_Grados = dr("Nivel_Grados").ToString(),
                .Nivel_Clave = dr("Nivel_Clave").ToString(),
                .Nivel_BancoID = CType(dr("Nivel_BancoId"), Integer),
                .Nivel_Descripcion = dr("Nivel_Descripcion").ToString(),
                .Nivel_GradoInicial = dr("Nivel_GradoInicial").ToString(),
                .Nivel_CURP = dr("Nivel_CURP").ToString(),
                .Nivel_Dominio = dr("Nivel_Dominio").ToString(),
                .Nivel_eMail = dr("Nivel_eMail").ToString(),
                .Nivel_RFC = dr("Nivel_RFC").ToString(),
                .Nivel_NombreComercial = dr("Nivel_NombreComercial").ToString(),
                .Nivel_RazonSocial = dr("Nivel_RazonSocial").ToString(),
                .Nivel_SistemaOficial = dr("Nivel_SistemaOficial").ToString(),
                .Nivel_Telefono1 = dr("Nivel_Telefono1").ToString(),
                .Nivel_Telefono2 = dr("Nivel_Telefono2").ToString(),
                .Nivel_Telefono3 = dr("Nivel_Telefono3").ToString(),
                .Nivel_Direccion_Calle = dr("Nivel_Direccion_Calle").ToString(),
                .Nivel_Direccion_Cpostal = dr("Nivel_Direccion_Cpostal").ToString(),
                .Nivel_Direccion_Colonia = dr("Nivel_Direccion_Colonia").ToString(),
                .Nivel_Direccion_Estado = dr("Nivel_Direccion_Estado").ToString(),
                .Nivel_Direccion_localidad = dr("Nivel_Direccion_localidad").ToString(),
                .Nivel_Direccion_Municipio = dr("Nivel_Direccion_Municipio").ToString(),
                .Nivel_Direccion_NoExterior = dr("Nivel_Direccion_NoExterior").ToString(),
                .Nivel_Direccion_NoInterior = dr("Nivel_Direccion_NoInterior").ToString(),
                .Nivel_RepresentanteLegal = dr("Nivel_RepresentanteLegal").ToString(),
                .Nivel_RepresentanteLegal_Curp = dr("Nivel_RepresentanteLegal_Curp").ToString(),
                .Nivel_RepresentanteLegal_RFC = dr("Nivel_RepresentanteLegal_RFC").ToString(),
                .Nivel_Movil = dr("Nivel_Movil").ToString(),
                .Nivel_EvaluacionesPorPeriodo = dr("Nivel_EvaluacionesPorPeriodo").ToString(),
                .Nivel_Periodos = dr("Nivel_Periodos").ToString()
                }
                ListaSeccion.Add(objSeccion)
            End While

        Catch ex As Exception
            objSeccion = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If
        End Try

        Return ListaSeccion

    End Function

    Public Function SelectSeccion(ByVal Valor As Integer) As SeccionesEnt
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objSeccion As SeccionesEnt = Nothing
        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarNiveles", conexion)
            cmd.Parameters.AddWithValue("@prmNivel_Id", Valor)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objSeccion = New SeccionesEnt With {
                .Nivel_ID = CType(dr("Nivel_ID"), Integer),
                .Nivel_Grados = dr("Nivel_Grados").ToString(),
                .Nivel_Clave = dr("Nivel_Clave").ToString(),
                .Nivel_BancoID = CType(dr("Nivel_BancoId"), Integer),
                .Nivel_Descripcion = dr("Nivel_Descripcion").ToString(),
                .Nivel_GradoInicial = dr("Nivel_GradoInicial").ToString(),
                .Nivel_CURP = dr("Nivel_CURP").ToString(),
                .Nivel_Dominio = dr("Nivel_Dominio").ToString(),
                .Nivel_eMail = dr("Nivel_eMail").ToString(),
                .Nivel_RFC = dr("Nivel_RFC").ToString(),
                .Nivel_NombreComercial = dr("Nivel_NombreComercial").ToString(),
                .Nivel_RazonSocial = dr("Nivel_RazonSocial").ToString(),
                .Nivel_SistemaOficial = dr("Nivel_SistemaOficial").ToString(),
                .Nivel_Telefono1 = dr("Nivel_Telefono1").ToString(),
                .Nivel_Telefono2 = dr("Nivel_Telefono2").ToString(),
                .Nivel_Telefono3 = dr("Nivel_Telefono3").ToString(),
                .Nivel_Direccion_Calle = dr("Nivel_Direccion_Calle").ToString(),
                .Nivel_Direccion_Cpostal = dr("Nivel_Direccion_Cpostal").ToString(),
                .Nivel_Direccion_Colonia = dr("Nivel_Direccion_Colonia").ToString(),
                .Nivel_Direccion_Estado = dr("Nivel_Direccion_Estado").ToString(),
                .Nivel_Direccion_localidad = dr("Nivel_Direccion_localidad").ToString(),
                .Nivel_Direccion_Municipio = dr("Nivel_Direccion_Municipio").ToString(),
                .Nivel_Direccion_NoExterior = dr("Nivel_Direccion_NoExterior").ToString(),
                .Nivel_Direccion_NoInterior = dr("Nivel_Direccion_NoInterior").ToString(),
                .Nivel_RepresentanteLegal = dr("Nivel_RepresentanteLegal").ToString(),
                .Nivel_RepresentanteLegal_Curp = dr("Nivel_RepresentanteLegal_Curp").ToString(),
                .Nivel_RepresentanteLegal_RFC = dr("Nivel_RepresentanteLegal_RFC").ToString(),
                .Nivel_Movil = dr("Nivel_Movil").ToString(),
                .Nivel_EvaluacionesPorPeriodo = dr("Nivel_EvaluacionesPorPeriodo").ToString(),
                .Nivel_Periodos = dr("Nivel_Periodos").ToString()
                }

            End While

        Catch ex As Exception
            objSeccion = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If
        End Try

        Return objSeccion

    End Function

    Public Function RegistrarSeccion(objSeccion As SeccionesEnt) As Boolean

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim resp As Boolean = False
        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_InsertarNivel", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }

            cmd.Parameters.AddWithValue("@Nivel_Descripcion", objSeccion.Nivel_Descripcion)
            cmd.Parameters.AddWithValue("@Nivel_Clave", objSeccion.Nivel_Clave)
            cmd.Parameters.AddWithValue("@Nivel_Grados", objSeccion.Nivel_Grados)
            cmd.Parameters.AddWithValue("@Nivel_GradoInicial", objSeccion.Nivel_GradoInicial)
            cmd.Parameters.AddWithValue("@Nivel_Periodos", objSeccion.Nivel_Periodos)
            cmd.Parameters.AddWithValue("@Nivel_EvaluacionesPorPeriodo", objSeccion.Nivel_EvaluacionesPorPeriodo)
            cmd.Parameters.AddWithValue("@Nivel_SistemaOficial", objSeccion.Nivel_SistemaOficial)
            cmd.Parameters.AddWithValue("@Nivel_NombreComercial", objSeccion.Nivel_NombreComercial)
            cmd.Parameters.AddWithValue("@Nivel_RazonSocial", objSeccion.Nivel_RazonSocial)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Calle", objSeccion.Nivel_Direccion_Calle)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_NoExterior", objSeccion.Nivel_Direccion_NoExterior)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_NoInterior", objSeccion.Nivel_Direccion_NoInterior)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Colonia", objSeccion.Nivel_Direccion_Colonia)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Localidad", objSeccion.Nivel_Direccion_localidad)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Municipio", objSeccion.Nivel_Direccion_Municipio)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Cpostal", objSeccion.Nivel_Direccion_Cpostal)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Estado", objSeccion.Nivel_Direccion_Estado)
            cmd.Parameters.AddWithValue("@Nivel_EvaluacionesPorPeriodo", objSeccion.Nivel_EvaluacionesPorPeriodo)
            cmd.Parameters.AddWithValue("@Nivel_eMail", objSeccion.Nivel_eMail)
            cmd.Parameters.AddWithValue("@Nivel_Movil", objSeccion.Nivel_Movil)
            cmd.Parameters.AddWithValue("@Nivel_CURP", objSeccion.Nivel_CURP)
            cmd.Parameters.AddWithValue("@Nivel_RepresentanteLegal", objSeccion.Nivel_RepresentanteLegal)
            cmd.Parameters.AddWithValue("@Nivel_RepresentanteLegal_CURP", objSeccion.Nivel_RepresentanteLegal_Curp)
            cmd.Parameters.AddWithValue("@Nivel_RepresentanteLegal_RFC", objSeccion.Nivel_RepresentanteLegal_RFC)
            cmd.Parameters.AddWithValue("@Nivel_Periodos", objSeccion.Nivel_Periodos)
            conexion.Open()

            Dim Fila As Integer = cmd.ExecuteNonQuery()
            If Fila > 0 Then resp = True

        Catch ex As Exception
            objSeccion = Nothing
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

    Public Function ModificarSeccion(objSeccion As SeccionesEnt) As Boolean

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim resp As Boolean = False

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SGEActualizarNivel", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }
            cmd.Parameters.AddWithValue("@Nivel_Id", Convert.ToInt32(objSeccion.Nivel_ID))
            cmd.Parameters.AddWithValue("@Nivel_Descripcion", objSeccion.Nivel_Descripcion)
            cmd.Parameters.AddWithValue("@Nivel_Clave", objSeccion.Nivel_Clave)
            cmd.Parameters.AddWithValue("@Nivel_Grados", objSeccion.Nivel_Grados)
            cmd.Parameters.AddWithValue("@Nivel_GradoInicial", objSeccion.Nivel_GradoInicial)
            cmd.Parameters.AddWithValue("@Nivel_Periodos", objSeccion.Nivel_Periodos)
            cmd.Parameters.AddWithValue("@Nivel_EvaluacionesPorPeriodo", objSeccion.Nivel_EvaluacionesPorPeriodo)
            cmd.Parameters.AddWithValue("@Nivel_SistemaOficial", objSeccion.Nivel_SistemaOficial)
            cmd.Parameters.AddWithValue("@Nivel_NombreComercial", objSeccion.Nivel_NombreComercial)
            cmd.Parameters.AddWithValue("@Nivel_RazonSocial", objSeccion.Nivel_RazonSocial)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Calle", objSeccion.Nivel_Direccion_Calle)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_NoExterior", objSeccion.Nivel_Direccion_NoExterior)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_NoInterior", objSeccion.Nivel_Direccion_NoInterior)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Colonia", objSeccion.Nivel_Direccion_Colonia)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Localidad", objSeccion.Nivel_Direccion_localidad)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Estado", objSeccion.Nivel_Direccion_Estado)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_Municipio", objSeccion.Nivel_Direccion_Municipio)
            cmd.Parameters.AddWithValue("@Nivel_RepresentanteLegal", objSeccion.Nivel_RepresentanteLegal)
            cmd.Parameters.AddWithValue("@Nivel_RepresentanteLegal_RFC", objSeccion.Nivel_RepresentanteLegal_RFC)
            cmd.Parameters.AddWithValue("@Nivel_RepresentanteLegal_CURP", objSeccion.Nivel_RepresentanteLegal_Curp)
            cmd.Parameters.AddWithValue("@Nivel_Direccion_CPostal", objSeccion.Nivel_Direccion_Cpostal)
            cmd.Parameters.AddWithValue("@Nivel_RFC", objSeccion.Nivel_RFC)
            cmd.Parameters.AddWithValue("@Nivel_CURP", objSeccion.Nivel_CURP)
            cmd.Parameters.AddWithValue("@Nivel_Telefono1", objSeccion.Nivel_Telefono1)
            cmd.Parameters.AddWithValue("@Nivel_Telefono2", objSeccion.Nivel_Telefono2)
            cmd.Parameters.AddWithValue("@Nivel_Telefono3", objSeccion.Nivel_Telefono3)
            cmd.Parameters.AddWithValue("@Nivel_Movil", objSeccion.Nivel_Movil)
            cmd.Parameters.AddWithValue("@Nivel_email", objSeccion.Nivel_eMail)
            cmd.Parameters.AddWithValue("@Nivel_Dominio", objSeccion.Nivel_Dominio)
            cmd.Parameters.AddWithValue("@Nivel_BancoID", objSeccion.Nivel_BancoID)



            conexion.Open()

            If CBool(cmd.ExecuteNonQuery) Then
                resp = True
            End If

        Catch ex As Exception
            objSeccion = Nothing
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
