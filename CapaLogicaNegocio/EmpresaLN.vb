Imports CapaAccesoDatos
Imports CapaEntidades
Public Class EmpresaLN
#Region "PATRON SINGLETON"

    Private Shared _objEmpresa As EmpresaLN = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As EmpresaLN

        If _objEmpresa Is Nothing Then
            _objEmpresa = New EmpresaLN

        End If

        Return _objEmpresa

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarEmpresa() As List(Of EmpresaEnt)
        Try
            Return EmpresaDAO.GetInstance.ListarEmpresa()


        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

    Public Function GuardarEmpresa()


    End Function
#End Region
End Class

