Imports System.Data.SqlClient
Imports CapaEntidades
Public Class FamiliasDAO
#Region "PATRON SINGLETON"
    Private Shared _FamiliasDAO As FamiliasDAO = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As FamiliasDAO
        If _FamiliasDAO Is Nothing Then
            _FamiliasDAO = New FamiliasDAO
        End If
        Return _FamiliasDAO

    End Function
#End Region

#Region "Rutinas"
    Public Function ListarFamilias() As List(Of FamiliaEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objFamilias As FamiliaEnt = Nothing

        Dim ListaFamilias As List(Of FamiliaEnt) = New List(Of FamiliaEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarFamilias", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objFamilias = New FamiliaEnt With {
               .Tutores_ID = dr("Tutores_ID"),
               .NombreMama = dr("NombreMama"),
               .NombrePapa = dr("NombrePapa"),
               .Tutores_Tutor = dr("Tutores_Tutor")
                }
                ListaFamilias.Add(objFamilias)
            End While

        Catch ex As Exception
            objFamilias = Nothing
            Throw ex
        Finally
            conexion.Close()
            conexion.Dispose()

        End Try


        Return ListaFamilias

    End Function

#End Region
End Class
