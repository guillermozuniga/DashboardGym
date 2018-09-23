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
    Public Function ListarBancos() As List(Of BancosEnt)
        Try
            Return BancosDAO.GetInstance.ListarBancos()


        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region
End Class
