Imports CapaAccesoDatos
Imports CapaEntidades
Public Class BoletaLN
#Region "PATRON SINGLETON"

    Private Shared _objBoleta As BoletaLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As BoletaLN

        If _objBoleta Is Nothing Then
            _objBoleta = New BoletaLN

        End If

        Return _objBoleta

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarBoletas(ByVal _sqlSentencia As String) As List(Of BoletaEnt)
        Try
            Return BoletaDAO.GetInstance.ListarBoletas(_sqlSentencia)


        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region
End Class
