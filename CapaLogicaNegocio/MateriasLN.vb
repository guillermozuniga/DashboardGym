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

    'Public Function RegistrarEmpresa(objEmpresa As EmpresaEnt)
    '    Try
    '        Return EmpresaDAO.GetInstance().RegistrarEmpresa(objEmpresa)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function ModificarEmpresa(objEmpresa As EmpresaEnt)
    '    Try
    '        Return EmpresaDAO.GetInstance().ModificarEmpresa(objEmpresa)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    Public Function BuscarMateria(ByVal _Sentencia As String)
        Try
            Return MateriaDAO.GetInstance.BuscarMateria(_Sentencia)
        Catch ex As Exception

            Throw ex

        End Try

    End Function
#End Region
End Class
