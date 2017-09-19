
Imports System
Imports System.IO
Imports System.Web.Services
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Configuration
Imports System.Web.UI
Imports System.Collections.Generic
Imports CapaEntidades
Imports CapaLogicaNegocio
Public Class wfventas
    Inherits System.Web.UI.Page

    Private Sub BindDropDownList(ddl As DropDownList, query As String, text As String, value As String, defaultText As String)

        Dim conString As String = ConfigurationManager.ConnectionStrings("LocalSQLServer").ConnectionString
        Dim cmd As New SqlCommand(query)
        Using con As New SqlConnection(conString)
            Using sda As New SqlDataAdapter()
                Try
                    cmd.Connection = con

                    con.Open()

                    ddl.DataSource = cmd.ExecuteReader()

                    ddl.DataTextField = text

                    ddl.DataValueField = value

                    ddl.DataBind()
                Catch ex As Exception

                Finally

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                        ' cmd.Connection.Dispose()
                    End If

                End Try


            End Using
        End Using
        ddl.Items.Insert(0, New ListItem(defaultText, "0"))
    End Sub

    Private Sub CargarUnidadesNegocio()
        Dim dt As DataTable
        dt = UnidadNegocioLN.getInstance().CantidadNegocios
        DropDownListunegocio.DataSource = dt
        DropDownListunegocio.DataTextField = "NombreSucursal"
        DropDownListunegocio.DataValueField = "IDGimnasio"
        DropDownListunegocio.DataBind()
        DropDownListunegocio.Items.Insert(0, New ListItem("Todos", "0"))

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'BindDropDownList(DropDownListunegocio, "Select * from SGE_VistaTutorEstudiante where Tutor = '" & miDataTable.Rows(0).Item(0).ToString & "' ", "Nombre", "Matricula_Estudiante", "-- Seleccione Estudiante --")

        CargarUnidadesNegocio()
    End Sub

End Class