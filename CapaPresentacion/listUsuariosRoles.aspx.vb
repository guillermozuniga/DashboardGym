Public Class listUsuariosRoles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then

                'LlenarGridViewTutores("Select * from SGE_VistaNombreTutor Order By Nombre")
                ListarUsuariosRole()
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub

    Protected Sub Btn_Limpiar_Click()

    End Sub

    Protected Sub Btn_Buscar_Click()

    End Sub
    Public Sub ListarUsuariosRole()


    End Sub
End Class