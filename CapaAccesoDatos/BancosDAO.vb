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
    Public Function ListarBancos(ByVal _Sentencia As String) As List(Of BancosEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objBancos As BancosEnt = Nothing

        Dim ListaBancos As List(Of BancosEnt) = New List(Of BancosEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand(_Sentencia, conexion)
            cmd.CommandType = CommandType.Text
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objBancos = New BancosEnt With {
               .Banco_ClaveOficial = dr("Banco_ClaveOficial").ToString(),
               .Banco_Nombre = dr("Banco_Nombre").ToString(),
               .Bancos_BancoID = dr("Bancos_BancoID")
                }
                ListaBancos.Add(objBancos)
            End While


        Catch ex As Exception
            objBancos = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If
        End Try


        Return ListaBancos

    End Function

    Public Function BuscarBanco(ByVal valor As Integer) As BancosEnt
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objBanco As BancosEnt = Nothing

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SGEBuscarBanco", conexion)
            cmd.Parameters.AddWithValue("@prmBanco_ID", valor)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            If (dr.Read()) Then
                objBanco = New BancosEnt With {
                    .Banco_Nombre = dr("Nombre").ToString(),
                    .Banco_ClaveOficial = dr("Clave").ToString()
                }

            End If

        Catch ex As Exception
            objBanco = Nothing

            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try

        Return objBanco


    End Function


    Public Function RegistrarBanco(objBanco As BancosEnt) As Boolean

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim resp As Boolean = False
        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_InsertarBanco", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }

            cmd.Parameters.AddWithValue("@Nombre", objBanco.Banco_Nombre)
            cmd.Parameters.AddWithValue("@Clave", objBanco.Banco_ClaveOficial)
            conexion.Open()

            Dim Fila As Integer = cmd.ExecuteNonQuery()
            'If Fila > 0 Then resp = True
            resp = True
        Catch ex As Exception
            objBanco = Nothing
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

    Public Function ModificarBanco(objBanco As BancosEnt) As Boolean

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim resp As Boolean = False

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SGEActualizarBanco", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }
            cmd.Parameters.AddWithValue("@BancoId", Convert.ToInt32(objBanco.Bancos_BancoID))
            cmd.Parameters.AddWithValue("@Nombre", objBanco.Banco_Nombre)
            cmd.Parameters.AddWithValue("@Clave", objBanco.Banco_ClaveOficial)

            conexion.Open()
            If CBool(cmd.ExecuteNonQuery) Then
                resp = True
            End If
        Catch ex As Exception
            objBanco = Nothing
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
