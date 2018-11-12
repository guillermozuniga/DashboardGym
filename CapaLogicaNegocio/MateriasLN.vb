Imports CapaAccesoDatos
Imports CapaEntidades
Public Class MateriasLN

#Region "PATRON SINGLETON"

    Private Shared _objMateria As MateriasLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As MateriasLN

        If _objMateria Is Nothing Then
            _objMateria = New MateriasLN

        End If

        Return _objMateria

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarMaterias() As List(Of MateriaEnt)
        Try
            Return MateriaDAO.GetInstance().ListarMateria()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RegistrarMateria(objMateria As MateriaEnt)
        Try
            Return MateriaDAO.GetInstance().RegistrarMateria(objMateria)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ModificarMateria(objMateria As MateriaEnt)
        Try
            Return MateriaDAO.GetInstance().ModificarMateria(objMateria)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function BuscarMateria(ByVal valor As Integer)
        Try
            Return MateriaDAO.GetInstance.BuscarMateria(valor)
        Catch ex As Exception

            Throw ex

        End Try

    End Function
#End Region
End Class
