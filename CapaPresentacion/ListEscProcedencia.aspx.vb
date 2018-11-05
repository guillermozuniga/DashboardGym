Public Class ListEscProcedencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                LlenarDropRegistros()

                Me.BindEscuelasToList()
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub
    Private Sub LlenarDropRegistros()
        DropDownList1.Items.Insert(0, "25")
        DropDownList1.Items.Insert(1, "50")
        DropDownList1.Items.Insert(2, "100")
        DropDownList1.Items.Insert(3, "250")
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