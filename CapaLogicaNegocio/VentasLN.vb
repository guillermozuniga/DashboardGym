Imports CapaAccesoDatos
Imports CapaEntidades
Public Class VentasLN
#Region "PATRON SINGLETON"

    Private Shared _objVentas As VentasLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As VentasLN

        If _objVentas Is Nothing Then
            _objVentas = New VentasLN

        End If

        Return _objVentas

    End Function

#End Region

#Region "Rutinas"
    Public Function GetVentasTotales()
        Try
            Return VentasDAO.getInstance.TotalVentas
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function
#End Region
End Class
