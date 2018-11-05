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
    Public Function ListarSeccion() As List(Of SeccionesEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objSeccion As SeccionesEnt = Nothing

        Dim ListaSeccion As List(Of SeccionesEnt) = New List(Of SeccionesEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarNiveles", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objSeccion = New SeccionesEnt With {
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


#End Region
End Class
