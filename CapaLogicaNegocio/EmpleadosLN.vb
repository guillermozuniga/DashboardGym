Imports CapaAccesoDatos
Imports CapaEntidades
Public Class EmpleadosLN
#Region "PATRON SINGLETON"

    Private Shared _objEmpleados As EmpleadosLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As EmpleadosLN

        If _objEmpleados Is Nothing Then
            _objEmpleados = New EmpleadosLN

        End If

        Return _objEmpleados

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarEmpleados() As List(Of EmpleadoEnt)
        Try
            Return EmpleadosDAO.GetInstance.ListarEmpleados()


        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region
End Class
