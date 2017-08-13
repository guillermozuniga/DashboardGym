Imports System
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks


Public NotInheritable Class Conexion

#Region "PATRON SINGLETON"

    Private Shared _conexion As Conexion = Nothing

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As Conexion
        If _conexion Is Nothing Then
            _conexion = New Conexion

        End If
        Return _conexion

    End Function

#End Region

    Public Function Conexiondb() As SqlConnection

        Dim conexion As New SqlConnection

        conexion.ConnectionString = ConfigurationManager.ConnectionStrings("eimagenn_gym_0001").ConnectionString

        Return conexion

    End Function
End Class


