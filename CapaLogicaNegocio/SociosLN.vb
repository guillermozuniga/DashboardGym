Imports CapaAccesoDatos
Imports CapaEntidades
Public Class SociosLN
#Region "PATRON SINGLETON"

    Private Shared _objSocios As SociosLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As SociosLN

        If _objSocios Is Nothing Then
            _objSocios = New SociosLN

        End If

        Return _objSocios

    End Function

#End Region

#Region "Rutinas"
    Public Function CantidadSociosActivos()
        Try
            Return SociosDAO.getInstance.SumaSociosActivos
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function

    Public Function CantidadSociosNuevos()
        Try
            Return SociosDAO.getInstance.SumaSociosNuevos
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function

    Public Function CantidadSociosPorVencer()
        Try
            Return SociosDAO.getInstance.SumaSociosPorVencer
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function
#End Region
End Class

