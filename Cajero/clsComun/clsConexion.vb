Imports System.Data.SqlClient
Imports System.Configuration

Public Class clsConexion

#Region "Declaracion Variales"

    Protected cnnBase As SqlConnection
    'Protected cnnString As ConnectionStringSettings
    Protected cnnBaseWeb As SqlConnection
#End Region
    Protected Function conectadoBase()
        Try

            cnnBase = New SqlConnection(My.MySettings.Default.GymConexion)

            cnnBase.Open()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error de Conexion")
            Return False

        End Try
    End Function


    Protected Function DesconectadoBase()
        Try
            If cnnBase.State = ConnectionState.Open Then
                cnnBase.Dispose()
                cnnBase.Close()
                Return True
            Else
                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error de Conexion")
            Return False

        End Try
    End Function
    Protected Function DesconectadoBaseWeb()
        Try
            If cnnBaseWeb.State = ConnectionState.Open Then
                cnnBaseWeb.Dispose()
                cnnBaseWeb.Close()
                Return True
            Else
                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error de Conexion")
            Return False

        End Try
    End Function

    Protected Function ConexionArchivoWeb() As Boolean

    End Function

End Class
