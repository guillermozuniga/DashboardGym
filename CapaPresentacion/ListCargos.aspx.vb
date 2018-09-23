Imports CapaEntidades
Imports CapaLogicaNegocio
Public Class ListCargos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then

                ListarCargos()
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If

    End Sub

    Public Sub ListarCargos()
        Dim Lista As List(Of ColCargos) = Nothing
        Try
            Lista = CargosLN.getInstance.ListarCargo()
            Me.gvCargos.DataSource = Lista
            Me.gvCargos.DataBind()
        Catch ex As Exception
            Lista = Nothing

        End Try

    End Sub

    Protected Sub Btn_Buscar_Click()

    End Sub

    Protected Sub Btn_Limpiar_Click()
        ListarCargos()
        Me.TextMatricula.Text = String.Empty
        Me.TextFecha.Text = String.Empty

        Me.TextMatricula.Focus()
    End Sub

    Private Sub gvCargos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvCargos.PageIndexChanging
        ListarCargos()
        Me.gvCargos.PageIndex = e.NewPageIndex
        Me.gvCargos.DataBind()
    End Sub
End Class