Public Class ManMaterias
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then

            Else
                Server.Transfer("~/logout.aspx")
            End If

        End If
    End Sub
    Protected Sub Btn_Regresar_Click()
        Server.Transfer("~/listMaterias.aspx")
    End Sub

    Protected Sub Btn_Guardar_Click()

    End Sub
End Class