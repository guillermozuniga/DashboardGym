Imports CapaAccesoDatos
Imports CapaEntidades

Public Class AlumnoLN
#Region "PATRON SINGLETON"
    Private Shared _objAlumnos As AlumnoLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As AlumnoLN
        If _objAlumnos Is Nothing Then
            _objAlumnos = New AlumnoLN

        End If
        Return _objAlumnos
    End Function


#End Region

#Region "Rutinas"
    Public Function ListarAlumnos() As List(Of AlumnoEnt)
        Try
            Return AlumnoDAO.GetInstance.ListarAlumnos()

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
