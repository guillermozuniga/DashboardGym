Imports System.Data.SqlClient
Imports CapaEntidades

Public Class CargoDAO
#Region "PATRON SINGLETON"
    Private Shared _CargoDAO As CargoDAO = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As CargoDAO
        If _CargoDAO Is Nothing Then
            _CargoDAO = New CargoDAO

        End If
        Return _CargoDAO

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarCargo() As List(Of ColCargos)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objCargo As ColCargos = Nothing

        Dim ListCargos As List(Of ColCargos) = New List(Of ColCargos)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarCargos", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                'objCargo.Cargos_Grado = Convert.ToInt32(dr("Cargos_Grado").ToString)
                'objCargo.Cargos_Grupo = Convert.ToInt32(dr("Cargos_Grupo").ToString)
                objCargo = New ColCargos With {
                    .Cargos_ID = Convert.ToInt32(dr("Cargos_ID").ToString),
                    .Cargos_Cicloescolar = dr("Cargos_CicloEscolar").ToString,
                    .Cargos_Matricula = Convert.ToInt32(dr("Cargos_Matricula").ToString),
                    .Cargos_FechaVencimiento = dr("Cargos_FechaDeVencimiento").ToString,
                    .Cargos_Importe = dr("Cargos_Importe").ToString
                }
                'objCargo.Cargos_Saldo = dr("Cargos_Saldo").ToString
                ListCargos.Add(objCargo)
            End While
        Catch ex As Exception
            objCargo = Nothing

            Throw ex
        Finally

            conexion.Close()
            conexion.Dispose()

        End Try
        Return ListCargos


    End Function


    Public Function ListarCargoConParametros() As List(Of ColCargos)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objCargo As ColCargos = Nothing

        Dim ListCargos As List(Of ColCargos) = New List(Of ColCargos)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarCargos", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objCargo = New ColCargos()

                objCargo.Cargos_ID = Convert.ToInt32(dr("Cargos_ID").ToString)
                objCargo.Cargos_Cicloescolar = dr("Cargos_CicloEscolar").ToString
                objCargo.Cargos_Matricula = Convert.ToInt32(dr("Cargos_Matricula").ToString)
                'objCargo.Cargos_Grado = Convert.ToInt32(dr("Cargos_Grado").ToString)
                'objCargo.Cargos_Grupo = Convert.ToInt32(dr("Cargos_Grupo").ToString)
                'objCargo.Cargos_FechaVencimiento = dr("Cargos_FechaVencimiento").ToString
                objCargo.Cargos_Importe = dr("Cargos_Importe").ToString
                'objCargo.Cargos_Saldo = dr("Cargos_Saldo").ToString
                ListCargos.Add(objCargo)
            End While
        Catch ex As Exception
            objCargo = Nothing

            Throw ex
        Finally

            conexion.Close()
            conexion.Dispose()

        End Try
        Return ListCargos


    End Function

#End Region
End Class


