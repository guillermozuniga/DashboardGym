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
                    .Materias_Nivel = CType(dr("Materias_Nivel"), Integer),
                    .Materias_ID = CType(dr("Materias_Id"), Integer)
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

    Public Function BuscarMateria(ByVal valor As Integer) As MateriaEnt

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objMateria As MateriaEnt = Nothing

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("Select * from v_GetAllMaterias Where Materias_ID = " & valor, conexion) With {
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
                    .Materias_PlanEscolar = dr("Materias_PlanEscolar").ToString(),
                    .Materias_Nivel = dr("Materias_Nivel"),
                    .Materias_ID = CType(dr("Materias_Id"), Integer),
                    .Materias_Creditos = dr("Materias_Creditos"),
                    .Materias_FaltasPermitidas = dr("Materias_FaltasPermitidas"),
                    .Materias_HorasSemana = dr("Materias_HorasSemana"),
                    .Materias_Materia = dr("Materias_Materia"),
                    .Materias_HorasTotales = dr("Materias_HorasTotales")
                }

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
        Return objMateria
    End Function

    Public Function RegistrarMateria(objMateria As MateriaEnt) As Boolean

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim resp As Boolean = False
        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_InsertarMateria", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }

            cmd.Parameters.AddWithValue("@Materias_Nombre", objMateria.Materias_Nombre)
            cmd.Parameters.AddWithValue("@Materias_Nivel", objMateria.Materias_Nivel)
            cmd.Parameters.AddWithValue("@Materias_Materia", objMateria.Materias_Materia)
            cmd.Parameters.AddWithValue("@Materias_NombreCorto", objMateria.Materias_NombreCorto)
            cmd.Parameters.AddWithValue("@Materias_PlanEscolar", objMateria.Materias_PlanEscolar)
            cmd.Parameters.AddWithValue("@Materias_CicloEscolar", objMateria.Materias_CicloEscolar)
            cmd.Parameters.AddWithValue("@Materias_ClaveEscolar", objMateria.Materias_ClaveOficial)
            cmd.Parameters.AddWithValue("@Materias_Creditos", objMateria.Materias_Creditos)
            cmd.Parameters.AddWithValue("@Materias_FaltasPermitidas", objMateria.Materias_FaltasPermitidas)
            cmd.Parameters.AddWithValue("@Materias_HorasSemana", objMateria.Materias_HorasSemana)
            cmd.Parameters.AddWithValue("@Materias_HorasTotales", objMateria.Materias_HorasTotales)

            conexion.Open()

            Dim Fila As Integer = cmd.ExecuteNonQuery()
            If Fila > 0 Then resp = True

        Catch ex As Exception
            objMateria = Nothing
            resp = False
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try

        Return resp

    End Function

    Public Function ModificarMateria(objMateria As MateriaEnt) As Boolean

        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim resp As Boolean = False

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_SGEActualizarMateria", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }
            cmd.Parameters.AddWithValue("@Materias_Id", Convert.ToInt32(objMateria.Materias_ID))
            cmd.Parameters.AddWithValue("@Materias_Nombre", objMateria.Materias_Nombre)
            cmd.Parameters.AddWithValue("@Materias_Nivel", objMateria.Materias_Nivel)
            cmd.Parameters.AddWithValue("@Materias_Materia", objMateria.Materias_Materia)
            cmd.Parameters.AddWithValue("@Materias_NombreCorto", objMateria.Materias_NombreCorto)
            cmd.Parameters.AddWithValue("@Materias_PlanEscolar", objMateria.Materias_PlanEscolar)
            cmd.Parameters.AddWithValue("@Materias_CicloEscolar", objMateria.Materias_CicloEscolar)
            cmd.Parameters.AddWithValue("@Materias_ClaveOficial", objMateria.Materias_ClaveOficial)
            cmd.Parameters.AddWithValue("@Materias_Creditos", objMateria.Materias_Creditos)
            cmd.Parameters.AddWithValue("@Materias_FaltasPermitidas", objMateria.Materias_FaltasPermitidas)
            cmd.Parameters.AddWithValue("@Materias_HorasSemana", objMateria.Materias_HorasSemana)
            cmd.Parameters.AddWithValue("@Materias_HorasTotales", objMateria.Materias_HorasTotales)

            conexion.Open()

            If CBool(cmd.ExecuteNonQuery) Then
                resp = True
            End If
        Catch ex As Exception
            objMateria = Nothing
            resp = False
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try

        Return resp

    End Function
#End Region

End Class
