Public Class manAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            If Not (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub

    Protected Sub Btn_Regresar_Click()
        Response.Redirect("~/Alumnos.aspx")
    End Sub

    Protected Sub Btn_Guardar_Click()

    End Sub
End Class