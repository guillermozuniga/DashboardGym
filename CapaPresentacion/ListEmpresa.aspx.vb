Imports CapaLogicaNegocio
Imports CapaEntidades
Imports System.Drawing

Public Class ListEmpresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                LlenarDropRegistros()

                'LlenarGridViewTutores("Select * from SGE_VistaNombreTutor Order By Nombre")
                ListarEmpresas()
            Else
                Server.Transfer("~/logout.aspx")
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
        Server.Transfer("~/ManEmpresa.aspx")
    End Sub

    Public Sub ListarEmpresas()
        Dim Lista As List(Of EmpresaEnt) = Nothing
        Try
            Lista = EmpresaLN.getInstance.ListarEmpresa()
            Me.gvEmpresa.DataSource = Lista
            Me.gvEmpresa.DataBind()
            If Me.gvEmpresa.Rows.Count > 0 Then
                Me.Btn_Nuevo.Visible = False
            End If

        Catch ex As Exception

            Lista = Nothing
            Throw ex
        End Try

    End Sub
    Protected Sub Btn_Editar_Click()
        Dim row As GridViewRow = gvEmpresa.SelectedRow
        If row IsNot Nothing Then
            Dim valor As String = row.Cells(0).Text
            If Not String.IsNullOrEmpty(valor) Then
                Server.Transfer("~/manEmpresa.aspx?Valor=" & valor)
            End If
        End If
    End Sub
    Protected Sub Btn_Eliminar_Click()

    End Sub

    Protected Sub Btn_Buscar_Click()

    End Sub

    Private Sub GvEmpresa_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvEmpresa.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onMouseOver") = "this.style.cursor='Pointer'; this.originalstyle=this.style.backgroundColor ; this.style.backgroundColor='#B0C4DE'"
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalstyle;")
            e.Row.ToolTip = "Click selecciona renglon"
            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(sender, "Select$" & e.Row.RowIndex.ToString())

            e.Row.Style.Add("cursor", "hand")
        End If
    End Sub

    Private Sub GvEmpresa_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvEmpresa.PageIndexChanging

        ListarEmpresas()

        Me.gvEmpresa.PageIndex = e.NewPageIndex
        Me.gvEmpresa.DataBind()

    End Sub

    Private Sub GvEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvEmpresa.SelectedIndexChanged
        gvEmpresa.SelectedRow.BackColor = Color.Orange

        For i As Integer = 0 To gvEmpresa.Rows.Count - 1

            If gvEmpresa.Rows(i).RowIndex <> gvEmpresa.SelectedRow.RowIndex Then
                gvEmpresa.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub

End Class