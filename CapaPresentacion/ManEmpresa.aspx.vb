Public Class ManEmpresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                If Not CargarEmpresa() Then

                    Me.TextRFC.Enabled = True
                    Me.TextRazonSocial.Enabled = True
                    Me.TextRFC.Focus()
                Else
                    Me.TextBoxNombreCom.Focus()

                End If
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If

    End Sub

    Protected Sub Btn_Guardar_Click()

    End Sub

    Protected Sub Btn_Regresar_Click()
        Response.Redirect("~/ListEmpresa.aspx")
    End Sub
    Private Function CargarEmpresa() As Boolean

        Return False

    End Function
End Class