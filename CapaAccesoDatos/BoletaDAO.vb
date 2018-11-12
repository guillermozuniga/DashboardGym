Imports System.Data.SqlClient
Imports CapaEntidades
Public Class BoletaDAO
#Region "PATRON SINGLETON"
    Private Shared _BoletaDAO As BoletaDAO = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As BoletaDAO
        If _BoletaDAO Is Nothing Then
            _BoletaDAO = New BoletaDAO

        End If
        Return _BoletaDAO
    End Function
#End Region

#Region "Rutinas"
    Public Function ListarBoletas(ByVal _sqlSentencia As String) As List(Of BoletaEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objBoleta As BoletaEnt = Nothing

        Dim ListaBoleta As List(Of BoletaEnt) = New List(Of BoletaEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand(_sqlSentencia, conexion) With {
                .CommandType = CommandType.Text
            }
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objBoleta = New BoletaEnt With {
               .Boleta_Matricula = Trim(dr("Alumnos_Matricula").ToString()),
               .Boleta_Evaluacion1 = dr("Boletas_Evaluacion1").ToString,
               .Boleta_NombreMateria = dr("Boletas_NombreMateria").ToString,
               .Boleta_Evaluacion2 = dr("Boletas_Evaluacion2").ToString
                  }
                ListaBoleta.Add(objBoleta)
            End While
        Catch ex As Exception
            objBoleta = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If
        End Try


        Return ListaBoleta

    End Function
#End Region
End Class
