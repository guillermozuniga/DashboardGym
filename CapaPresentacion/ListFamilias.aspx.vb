Imports CapaEntidades
Imports CapaLogicaNegocio
Imports System.Drawing


Public Class ListFamilias
    Inherits System.Web.UI.Page
    Dim fila As String = Nothing
    Dim sQlSentencia As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                LlenarDropRegistros()

                Me.BindFamiliasToList("")
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
    Protected Sub Btn_Nuevo_Click()
        Response.Redirect("ManFamilias.aspx")
    End Sub
    Protected Sub Btn_Limpiar_Click()
        Me.TextFirstName.Text = String.Empty
        Me.TextLastName.Text = String.Empty
        Me.TextRFC.Text = String.Empty
        Me.TextCURP.Text = String.Empty
        Me.TextFirstName.Focus()

    End Sub
    Protected Sub Btn_Editar_Click()
        If gvFamilias.SelectedIndex >= 0 Then
            Dim row As GridViewRow = gvFamilias.SelectedRow
            Dim valor As String = row.Cells(1).Text
            Response.Redirect("~/manFamilias.aspx")
        End If

    End Sub

    Protected Sub Btn_Eliminar_Click()
        If gvFamilias.SelectedIndex >= 0 Then

            Dim row As GridViewRow = gvFamilias.SelectedRow

            Dim valor As String = row.Cells(1).Text

            Response.Redirect("~/manFamilias.aspx")
        End If
    End Sub
    Protected Sub Btn_Buscar_Click()
        sQlSentencia = String.Empty
        sQlSentencia = "Select * from v_GetAllFamilias"
        If Not String.IsNullOrEmpty(Me.TextFirstName.Text) Then
            sQlSentencia += " where Nombre Like '%" & Trim(Me.TextFirstName.Text.ToString) & "%'"
        End If
        BindFamiliasToList(sQlSentencia)
    End Sub

    Private Sub BindFamiliasToList(ByVal _sQlSentencia As String)
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
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onMouseOver") = "this.style.cursor='Pointer'; this.originalstyle=this.style.backgroundColor ; this.style.backgroundColor='#B0C4DE'"
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalstyle;")

            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(gvFamilias, "Select$" & e.Row.RowIndex.ToString())
            'e.Row.Attributes("OnDblClick") = Page.ClientScript.GetPostBackClientHyperlink(gvAlumnos, "Select$" & e.Row.RowIndex.ToString())

        End If
    End Sub

    Private Sub gvFamilias_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvFamilias.PageIndexChanging
        BindFamiliasToList("Select * from v_GetAllFamilias")
        Me.gvFamilias.PageIndex = e.NewPageIndex
        Me.gvFamilias.DataBind()
    End Sub

    Private Sub gvFamilias_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles gvFamilias.SelectedIndexChanging
        gvFamilias.SelectedIndex = -1
    End Sub

    Private Sub gvFamilias_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvFamilias.RowCommand
        If e.CommandName = "Select" Then

            ' Se obtiene indice de la row seleccionada

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Obtengo el id de la entidad que se esta editando
            ' en este caso de la entidad Person           '

            Dim id As Integer = Convert.ToInt32(gvFamilias.DataKeys(index).Value)
        End If
    End Sub

    Private Sub gvFamilias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvFamilias.SelectedIndexChanged
        ' fila = gvAlumnos.SelectedRow().Cells(0).Text

        gvFamilias.SelectedRow.BackColor = Color.Orange

        For i As Integer = 0 To gvFamilias.Rows.Count - 1
            If gvFamilias.Rows(i).RowIndex <> gvFamilias.SelectedRow.RowIndex Then
                gvFamilias.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub
End Class