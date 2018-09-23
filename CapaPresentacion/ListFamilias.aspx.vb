Imports CapaEntidades
Imports CapaLogicaNegocio

Public Class ListFamilias
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Me.BindFamiliasToList()
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub
    Protected Sub BtnNuevo_Click()
        Response.Redirect("ManFamilias.aspx")
    End Sub
    Protected Sub Btn_Limpiar_Click()
        Me.TextFirstName.Text = String.Empty
        Me.TextLastName.Text = String.Empty
        Me.TextRFC.Text = String.Empty
        Me.TextCURP.Text = String.Empty
        Me.TextFirstName.Focus()

    End Sub

    Protected Sub Btn_Buscar_Click()

    End Sub

    Private Sub BindFamiliasToList()
        'Dim dt As DataTable = Nothing

        'Me.gvAlumnos.DataSource = dt
        'Me.gvAlumnos.DataBind()
        Dim Lista As List(Of FamiliaEnt) = Nothing
        Try
            Lista = FamiliasLN.getInstance.ListarFamilias()
            Me.gvFamilias.DataSource = Lista
            Me.gvFamilias.DataBind()
        Catch ex As Exception
            Lista = Nothing
            Throw ex


        End Try
    End Sub

    Private Sub gvFamilias_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvFamilias.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Private Sub gvFamilias_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvFamilias.PageIndexChanging
        BindFamiliasToList()
        Me.gvFamilias.PageIndex = e.NewPageIndex
        Me.gvFamilias.DataBind()
    End Sub
End Class