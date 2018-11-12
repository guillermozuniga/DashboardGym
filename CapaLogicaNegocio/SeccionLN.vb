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
    Public Function ListarSeccion(ByVal valor As Integer) As List(Of SeccionesEnt)
        Try
            Return SeccionDAO.GetInstance.ListarSeccion(valor)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SelectSeccion(ByVal valor As Integer) As SeccionesEnt
        Try
            Return SeccionDAO.GetInstance.SelectSeccion(valor)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RegistrarSeccion(objSeccion As SeccionesEnt)
        Try
            Return SeccionDAO.GetInstance().RegistrarSeccion(objSeccion)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ModificarSeccion(objSeccion As SeccionesEnt)
        Try
            Return SeccionDAO.GetInstance().ModificarSeccion(objSeccion)
        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region
End Class
