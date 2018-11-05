Imports CapaAccesoDatos
Imports CapaEntidades
Public Class SeccionLN
#Region "PATRON SINGLETON"
    Private Shared _objSeccion As SeccionLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As SeccionLN
        If _objSeccion Is Nothing Then
            _objSeccion = New SeccionLN

        End If
        Return _objSeccion
    End Function


#End Region

#Region "Rutinas"
    Public Function ListarSeccion() As List(Of SeccionesEnt)
        Try
            Return SeccionDAO.GetInstance.ListarSeccion()

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
