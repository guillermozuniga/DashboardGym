Imports CapaEntidades
Imports CapaLogicaNegocio

Public Class ListEmpleados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Me.BindEmpleadosToList()

            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub

    Protected Sub Btn_Limpiar_Click()
        Me.TextCURP.Text = String.Empty
        Me.TextNombre.Text = String.Empty
        Me.TextRFC.Text = String.Empty
        Me.TextRFC.Focus()

    End Sub

    Protected Sub Btn_Buscar_Click()

    End Sub

    Private Sub BindEmpleadosToList()
        'Dim dt As DataTable = Nothing

        'Me.gvAlumnos.DataSource = dt
        'Me.gvAlumnos.DataBind()
        Dim Lista As List(Of EmpleadoEnt) = Nothing
        Try
            Lista = EmpleadosLN.getInstance.ListarEmpleados()

            Me.gvEmpleados.DataSource = Lista
            Me.gvEmpleados.DataBind()
        Catch ex As Exception
            Lista = Nothing
            Throw ex


        End Try
    End Sub

    Private Sub gvEmpleados_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvEmpleados.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Private Sub gvEmpleados_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvEmpleados.PageIndexChanging
        BindEmpleadosToList()
        Me.gvEmpleados.PageIndex = e.NewPageIndex
        Me.gvEmpleados.DataBind()
    End Sub
End Class