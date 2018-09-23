Public Class ListBancos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Me.BindBancosToList()

            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub
    Protected Sub Btn_Buscar_Click()

    End Sub

    Protected Sub Btn_Limpiar_Click()
        Me.TextBanco.Text = String.Empty
        Me.TextClave.Text = String.Empty

    End Sub

    Protected Sub Btn_Nuevo_Click()

    End Sub

    Private Sub BindBancosToList()
        Dim dt As DataTable = Nothing

        Me.gvBancos.DataSource = dt
        Me.gvBancos.DataBind()
    End Sub

    Private Sub gvBancos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvBancos.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub
End Class