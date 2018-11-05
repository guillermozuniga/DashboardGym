Imports System.Data.SqlClient
Imports CapaEntidades
Public Class MateriaDAO
#Region "PATRON SINGLETON"
    Private Shared _MateriaDAO As MateriaDAO = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As MateriaDAO
        If _MateriaDAO Is Nothing Then
            _MateriaDAO = New MateriaDAO

        End If
        Return _MateriaDAO
    End Function
#End Region

#Region "Rutinas"
    Public Function ListarMateria() As List(Of MateriaEnt)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objMateria As MateriaEnt = Nothing

        Dim ListaMaterias As List(Of MateriaEnt) = New List(Of MateriaEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarMaterias", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                objMateria = New MateriaEnt With {
                    .Materias_Nombre = dr("Materias_Nombre").ToString(),
                    .Materias_NombreCorto = dr("Materias_NombreCorto").ToString(),
                    .Materias_PlanEscolar = dr("Materias_PlanEscolar").ToString(),
                    .Materias_CicloEscolar = dr("Materias_CicloEscolar").ToString(),
                    .Materias_ClaveOficial = dr("Materias_ClaveOficial").ToString(),
                    .Materias_Nivel = CType(dr("Materias_Nivel"), Integer)
                }
                ListaMaterias.Add(objMateria)
            End While

        Catch ex As Exception
            objMateria = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try

        Return ListaMaterias

    End Function

    Public Function BuscarMateria(ByVal _SqlSentencia As String) As List(Of MateriaEnt)

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objMateria As MateriaEnt = Nothing

        Dim ListaMaterias As List(Of MateriaEnt) = New List(Of MateriaEnt)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand(_SqlSentencia, conexion) With {
                .CommandType = CommandType.Text
            }

            conexion.Open()

            dr = cmd.ExecuteReader()

            While (dr.Read())

                objMateria = New MateriaEnt With {
                    .Materias_Nombre = dr("Nombre").ToString(),
                    .Materias_CicloEscolar = dr("Materias_CicloEscolar").ToString(),
                    .Materias_ClaveOficial = dr("materias_ClaveOficial").ToString(),
                    .Materias_NombreCorto = dr("Materias_NombreCorto").ToString(),
                    .Materias_PlanEscolar = dr("Materias_PlanEscolar").ToString()
                }
                ListaMaterias.Add(objMateria)
            End While

        Catch ex As Exception
            objMateria = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try
        Return ListaMaterias
    End Function

#End Region

End Class
