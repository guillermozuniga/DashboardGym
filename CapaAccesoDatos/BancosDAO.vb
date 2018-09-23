Imports System.Data.SqlClient
Imports CapaEntidades
Public Class BancosDAO

#Region "PATRON SINGLETON"
    Private Shared _BancosDAO As BancosDAO = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As BancosDAO
        If _BancosDAO Is Nothing Then
            _BancosDAO = New BancosDAO

        End If
        Return _BancosDAO
    End Function
#End Region

#Region "Rutinas"
    Public Function ListarBancos() As List(Of BancosEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objBancos As BancosEnt = Nothing

        Dim ListaBancos As List(Of BancosEnt) = New List(Of BancosEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarBancos", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objBancos = New BancosEnt With {
               .Banco_ClaveOficial = dr("Bancos_ClaveOficial"),
               .Banco_Nombre = dr("Bancos_Nombre")
                }
                ListaBancos.Add(objBancos)
            End While


        Catch ex As Exception
            objBancos = Nothing
            Throw ex
        Finally
            conexion.Close()
            conexion.Dispose()

        End Try


        Return ListaBancos

    End Function
#End Region
End Class
