Imports CapaAccesoDatos
Imports CapaEntidades
Public Class CargosLN
#Region "PATRON SINGLETON"

    Private Shared _objCargos As CargosLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As CargosLN

        If _objCargos Is Nothing Then
            _objCargos = New CargosLN

        End If

        Return _objCargos

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarCargo() As List(Of ColCargos)
        Try
            Return CargoDAO.GetInstance.ListarCargo()


        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

End Class
