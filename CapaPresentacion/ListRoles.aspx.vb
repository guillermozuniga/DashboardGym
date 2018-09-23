Public Class ListRoles
    Inherits System.Web.UI.Page
    Dim pageSize As Integer = 5
    Dim totalRoles As Integer
    Dim totalPages As Integer
    Dim currentPage As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                BindRolesToRolesList()

            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If


    End Sub

    Private Sub BindRolesToRolesList()

        ' Get all of the roles
        'Dim roleNames() As String = Roles.GetAllRoles()
        gvRoles.DataSource = Roles.GetAllRoles()
        gvRoles.DataBind()


        'Dim emails As List(Of String) = New List(Of String)()
        'Dim dt As DataTable = CType(gvRoles.DataSource, DataTable)

        'For Each row As DataRow In dt.Rows
        '    emails.Add(row(5))
        'Next
        'gvRoles.DataBind()

    End Sub

    Private Sub gvRoles_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvRoles.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Private Sub gvRoles_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvRoles.PageIndexChanging
        BindRolesToRolesList()
        Me.gvRoles.PageIndex = e.NewPageIndex
        Me.gvRoles.DataBind()
    End Sub
End Class