Public Class listModulos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                LlenarDropRegistros()

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
    Protected Sub Btn_Buscar_Click()

    End Sub

    Protected Sub Btn_Limpiar_Click()

    End Sub


    Protected Sub Btn_Nuevo_Click()

    End Sub
End Class