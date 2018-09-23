Public Class ListEscProcedencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Me.BindEscuelasToList()
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub

    Protected Sub Btn_Limpiar_Click()
        Me.TextRazonSocial.Text = String.Empty
        Me.TextRFC.Text = String.Empty
        Me.TextRazonSocial.Focus()

    End Sub

    Protected Sub Btn_Buscar_Click()

    End Sub

    Private Sub BindEscuelasToList()
        Dim dt As DataTable = Nothing

        Me.gvescProcedencia.DataSource = dt
        Me.gvescProcedencia.DataBind()
    End Sub
End Class