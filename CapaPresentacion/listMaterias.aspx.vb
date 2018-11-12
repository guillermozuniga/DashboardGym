Imports CapaLogicaNegocio
Imports CapaEntidades
Imports System.Drawing
Public Class listMaterias
    Inherits System.Web.UI.Page
    Dim fila As String = Nothing
    Dim sQlSentencia As String = Nothing

#Region "Rutinas"
    Public Sub ListarMaterias(ByVal _sQlSentencia As String)
        Dim Lista As List(Of MateriaEnt) = Nothing
        If Not String.IsNullOrEmpty(_sQlSentencia) Then
            Try
                Lista = MateriasLN.GetInstance.BuscarMateria(_sQlSentencia)
                Me.GvMaterias.DataSource = Lista
                Me.GvMaterias.DataBind()
            Catch ex As Exception
                Lista = Nothing
                Throw ex
            End Try
        Else
            Try
                Lista = MateriasLN.GetInstance.ListarMaterias()
                Me.GvMaterias.DataSource = Lista
                Me.GvMaterias.DataBind()
            Catch ex As Exception
                Lista = Nothing
                Throw ex
            End Try
        End If
    End Sub
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                'LlenarGridViewTutores("Select * from SGE_VistaNombreTutor Order By Nombre")
                LlenarDropRegistros()
                ListarMaterias("")
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
        Server.Transfer("~/ManMaterias.aspx")
    End Sub

    Protected Sub Btn_Editar_Click()
        Dim row As GridViewRow = GvMaterias.SelectedRow
        If row IsNot Nothing Then
            Dim valor As String = row.Cells(0).Text
            If Not String.IsNullOrEmpty(valor) Then
                Server.Transfer("~/ManMaterias.aspx?Valor=" & valor)
            End If
        End If
    End Sub

    Protected Sub Btn_Eliminar_Click()

    End Sub
    Protected Sub Btn_Buscar_Click()
        sQlSentencia = String.Empty
        sQlSentencia = "Select * from v_GetAllMaterias "

        If Not String.IsNullOrEmpty(Me.TextNombre.Text) Then
            sQlSentencia += "where Nombre Like '" & Trim(Me.TextNombre.Text) & "%'"
        End If

        If Not String.IsNullOrEmpty(Me.TextNombreCorto.Text) Then
            sQlSentencia += "where materias_NombreCorto Like '" & Trim(Me.TextNombreCorto.Text) & "%'"
        End If
        ListarMaterias(sQlSentencia)
    End Sub
    Protected Sub Btn_Limpiar_Click()
        ListarMaterias("")
        Me.TextNombreCorto.Text = String.Empty
        Me.TextNombre.Text = String.Empty
        Me.TextNombre.Focus()
    End Sub

    Private Sub GvMaterias_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GvMaterias.RowDataBound
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

    Private Sub GvMaterias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GvMaterias.SelectedIndexChanged
        GvMaterias.SelectedRow.BackColor = Color.Orange
        For i As Integer = 0 To GvMaterias.Rows.Count - 1
            If GvMaterias.Rows(i).RowIndex <> GvMaterias.SelectedRow.RowIndex Then
                GvMaterias.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub

    Private Sub GvMaterias_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GvMaterias.PageIndexChanging
        ListarMaterias("Select * from v_GetAllMaterias")
        Me.GvMaterias.PageIndex = e.NewPageIndex
        Me.GvMaterias.DataBind()
    End Sub
End Class