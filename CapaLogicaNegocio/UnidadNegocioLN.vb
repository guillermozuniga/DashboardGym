Imports CapaAccesoDatos
Imports CapaEntidades
Public Class UnidadNegocioLN
#Region "PATRON SINGLETON"

    Private Shared _objUNegocio As UnidadNegocioLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As UnidadNegocioLN

        If _objUNegocio Is Nothing Then
            _objUNegocio = New UnidadNegocioLN

        End If

        Return _objUNegocio

    End Function

#End Region
#Region "Rutinas"
    Public Function CantidadNegocios()
        Try
            Return UNegocioDAO.getInstance.GetSumaUNegocios
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function
   
#End Region


End Class
