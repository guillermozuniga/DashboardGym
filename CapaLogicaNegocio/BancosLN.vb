Imports CapaAccesoDatos
Imports CapaEntidades
Public Class BancosLN
#Region "PATRON SINGLETON"

    Private Shared _objBancos As BancosLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As BancosLN

        If _objBancos Is Nothing Then
            _objBancos = New BancosLN

        End If

        Return _objBancos

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarBancos(ByVal _Sentencia As String) As List(Of BancosEnt)
        Try
            Return BancosDAO.GetInstance.ListarBancos(_Sentencia)


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RegistrarBanco(objBanco As BancosEnt)
        Try
            Return BancosDAO.GetInstance().RegistrarBanco(objBanco)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ModificarBanco(objBanco As BancosEnt)
        Try
            Return BancosDAO.GetInstance().ModificarBanco(objBanco)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function BuscarBanco(ByVal valor As Integer)
        Try
            Return BancosDAO.GetInstance().BuscarBanco(valor)
        Catch ex As Exception

            Throw ex

        End Try

    End Function
#End Region
End Class
