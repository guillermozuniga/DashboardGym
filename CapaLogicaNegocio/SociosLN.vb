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
    Public Function CantidadSociosActivos(ByVal Id As Integer)
        Try
            Return SociosDAO.getInstance.SumaSociosActivos(Id)
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function

    Public Function CantidadSociosNuevos(ByVal Id As Integer)
        Try
            Return SociosDAO.getInstance.SumaSociosNuevos(Id)
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function

    Public Function CantidadSociosPorVencer(ByVal Id As Integer)
        Try
            Return SociosDAO.getInstance.SumaSociosPorVencer(Id)
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function

    Public Function CantidadSociosQueRenovaron(ByVal Id As Integer)
        Try
            Return SociosDAO.getInstance.SumaSociosQueRenovaron(Id)
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function

    Public Function CantidadSociosQueNORenovaron()
        Try
            Return SociosDAO.getInstance.SumaSociosQueNoRenovaron
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function

    Public Function SociosVencidosconasistencia()
        Try
            Return SociosDAO.getInstance.Vencidosconasistencia
        Catch ex As Exception
            Console.WriteLine("SQL Error: " + ex.Message)
            Throw ex
        End Try
    End Function
#End Region
End Class

