Imports CapaAccesoDatos
Imports CapaEntidades

Public Class FamiliasLN
#Region "PATRON SINGLETON"
    Private Shared _objFamilias As FamiliasLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As FamiliasLN
        If _objFamilias Is Nothing Then
            _objFamilias = New FamiliasLN

        End If
        Return _objFamilias
    End Function


#End Region

#Region "Rutinas"
    Public Function ListarFamilias() As List(Of FamiliaEnt)
        Try
            Return FamiliasDAO.GetInstance.ListarFamilias()

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
