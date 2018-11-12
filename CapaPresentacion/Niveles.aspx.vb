Imports CapaLogicaNegocio
Imports CapaEntidades
Imports System.Drawing
Public Class Niveles
    Inherits System.Web.UI.Page
#Region "Rutinas"
    Public Sub ListarSecciones()
        Dim Lista As List(Of SeccionesEnt) = Nothing

        Try
            Lista = SeccionLN.getInstance.ListarSeccion(0)
            Me.GvSeccion.DataSource = Lista
            Me.GvSeccion.DataBind()

        Catch ex As Exception

            Lista = Nothing
            Throw ex
        End Try
    End Sub

    Private Sub LlenarDropRegistros()
        DropDownList1.Items.Insert(0, "25")
        DropDownList1.Items.Insert(1, "50")
        DropDownList1.Items.Insert(2, "100")
        DropDownList1.Items.Insert(3, "250")
    End Sub

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                'LlenarGridViewTutores("Select * from SGE_VistaNombreTutor Order By Nombre")
                LlenarDropRegistros()
                ListarSecciones()
            Else
                Server.Transfer("~/logout.aspx")
            End If
        End If
    End Sub
    Protected Sub Btn_Nuevo_Click()
        Server.Transfer("~/mannivel.aspx")
    End Sub

    Protected Sub Btn_Editar_Click()
        Dim row As GridViewRow = GvSeccion.SelectedRow
        If row IsNot Nothing Then
            Dim valor As String = row.Cells(0).Text
            If Not String.IsNullOrEmpty(valor) Then
                Server.Transfer("~/mannivel.aspx?Valor=" & valor)
            End If
        End If
    End Sub
    Protected Sub Btn_Eliminar_Click()

    End Sub

    Private Sub GvSeccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GvSeccion.SelectedIndexChanged
        GvSeccion.SelectedRow.BackColor = Color.Orange
        For i As Integer = 0 To GvSeccion.Rows.Count - 1

            If GvSeccion.Rows(i).RowIndex <> GvSeccion.SelectedRow.RowIndex Then
                GvSeccion.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub

    Private Sub GvSeccion_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GvSeccion.RowDataBound
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

    Private Sub GvSeccion_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GvSeccion.PageIndexChanging
        ListarSecciones()

        Me.GvSeccion.PageIndex = e.NewPageIndex
        Me.GvSeccion.DataBind()
    End Sub
End Class