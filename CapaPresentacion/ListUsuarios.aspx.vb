Public Class ListUsuarios
    Inherits System.Web.UI.Page
    Dim pageSize As Integer = 5
    Dim totalUsers As Integer
    Dim totalPages As Integer
    Dim currentPage As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then

                BindUsersToUserList()

            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub

    Protected Sub Btn_Nuevo_Click()
        Response.Redirect("manUsuarios.aspx")
    End Sub

    Private Sub BindUsersToUserList()
        ' Get all of the user accounts
        Dim users As MembershipUserCollection = Membership.GetAllUsers()

        'Me.GridView1.DataSource = Membership.GetAllUsers(currentPage - 1, pageSize, totalUsers)
        Me.gvUsuarios.DataSource = users
        Me.gvUsuarios.DataBind()

    End Sub

    Private Sub gvUsuarios_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvUsuarios.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub gvUsuarios_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        BindUsersToUserList()
        Me.gvUsuarios.PageIndex = e.NewPageIndex
        Me.gvUsuarios.DataBind()
    End Sub
End Class