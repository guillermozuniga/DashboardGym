Imports System.Data.SqlClient
Imports CapaEntidades

Public Class CargoDAO
#Region "PATRON SINGLETON"
    Private Shared _CargoDAO As CargoDAO = Nothing

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As CargoDAO
        If _CargoDAO Is Nothing Then
            _CargoDAO = New CargoDAO

        End If
        Return _CargoDAO

    End Function

#End Region

#Region "Rutinas"
    Public Function ListarCargo() As List(Of ColCargos)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim objCargo As ColCargos = Nothing

        Dim ListCargos As List(Of ColCargos) = New List(Of ColCargos)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand("usp_ListarCargos", conexion) With {
                .CommandType = CommandType.StoredProcedure
            }
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                'objCargo.Cargos_Grado = Convert.ToInt32(dr("Cargos_Grado").ToString)
                'objCargo.Cargos_Grupo = Convert.ToInt32(dr("Cargos_Grupo").ToString)
                objCargo = New ColCargos With {
                    .Cargos_ID = Convert.ToInt32(dr("Cargos_ID").ToString()),
                    .Cargos_Cicloescolar = dr("Cargos_CicloEscolar").ToString(),
                    .Cargos_Matricula = Convert.ToInt32(dr("Cargos_Matricula").ToString()),
                    .Cargos_FechaVencimiento = dr("Cargos_FechaDeVencimiento").ToString(),
                    .Cargos_Importe = dr("Cargos_Importe").ToString(),
                    .Cargos_Descripcion = dr("Descripcion").ToString()
                }
                'objCargo.Cargos_Saldo = dr("Cargos_Saldo").ToString
                ListCargos.Add(objCargo)
            End While
        Catch ex As Exception
            objCargo = Nothing

            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If
        End Try
        Return ListCargos


    End Function


    Public Function ListarCargoXAlumno(ByVal _sQl As String) As List(Of ColCargos)
        Dim conexion As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim dt As DataTable = Nothing
        Dim ImporteComisiones As Double = 0
        Dim ImporteTotal As Double = 0
        Dim Porcentaje As Double = 0
        Dim objCargo As ColCargos = Nothing

        Dim ListCargos As List(Of ColCargos) = New List(Of ColCargos)

        Try
            conexion = CapaAccesoDatos.Conexion.getInstance.Conexiondb
            cmd = New SqlCommand(_sQl, conexion) With {
                .CommandType = CommandType.Text
            }
            conexion.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                'objCargo.Cargos_Grado = Convert.ToInt32(dr("Cargos_Grado").ToString)
                'objCargo.Cargos_Grupo = Convert.ToInt32(dr("Cargos_Grupo").ToString)
                'objCargo.Cargos_FechaVencimiento = dr("Cargos_FechaVencimiento").ToString

                If (DateTime.Compare(Convert.ToDateTime(dr("Cargos_FechaDeVencimiento")), DateTime.Today) >= 0) Then

                    'ImporteComisiones = Convert.ToDouble(dr("Cargos_Saldo")) * 2.8 / 100
                    ImporteTotal = ImporteComisiones + Convert.ToDouble(dr("Cargos_Saldo"))

                Else

                    If Convert.ToInt32(dr("Cargos_Recargos")) = 0 Then
                        If Convert.ToInt32(dr("Conceptos_Recargos") < 50) Then

                            Porcentaje = Convert.ToDouble(dr("Conceptos_Recargos") / 100)
                            ImporteTotal = Convert.ToDouble(dr("Cargos_Saldo")) + Convert.ToDouble(dr("Cargos_Importe") * Porcentaje)
                            'ImporteComisiones = ImporteTotal * 2.8 / 100
                            ImporteTotal = ImporteTotal + ImporteComisiones

                        Else
                            ImporteTotal = Convert.ToDouble(dr("Cargos_Saldo")) + Convert.ToDouble(dr("Conceptos_Recargos"))
                            'ImporteComisiones = ImporteTotal * 2.8 / 100
                            ImporteTotal = ImporteTotal + ImporteComisiones

                        End If
                    Else

                        ImporteTotal = Convert.ToDouble(dr("Cargos_Saldo"))
                        ' ImporteComisiones = ImporteTotal * 2.8 / 100
                        ImporteTotal = ImporteTotal + ImporteComisiones

                    End If

                End If


                objCargo = New ColCargos With {
                    .Cargos_ID = Convert.ToInt32(dr("Cargos_ID").ToString()),
                    .Cargos_Cicloescolar = dr("Cargos_CicloEscolar").ToString,
                    .Cargos_Matricula = Convert.ToInt32(dr("Alumnos_Matricula").ToString()),
                    .Cargos_Descripcion = dr("Descripcion").ToString(),
                    .Cargos_Importe = ImporteTotal,
                    .Cargos_FechaVencimiento = dr("Cargos_FechaDeVencimiento").ToString(),
                    .Cargos_Referencia = dr("ReferenciaBanco").ToString(),
                    .Cargos_Nombre = dr("Nombre")
                }
                ListCargos.Add(objCargo)
            End While

        Catch ex As Exception
            objCargo = Nothing
            Throw ex
        Finally
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd.Dispose()
            End If

        End Try
        Return ListCargos
    End Function

#End Region
End Class


