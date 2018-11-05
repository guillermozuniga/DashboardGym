Imports System.Drawing
Imports CapaEntidades
Imports CapaLogicaNegocio

Public Class ListBancos
    Inherits System.Web.UI.Page
    Dim valor As String = String.Empty
    Dim fila As String = Nothing
    Dim sQlSentencia As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                LlenarDropRegistros()
                BindBancosToList("Select * from [eimagenn_sge_admin].[v_GetAllBancos]")
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
    Protected Sub Btn_Buscar_Click()
        sQlSentencia = String.Empty
        sQlSentencia = "Select * from [eimagenn_sge_admin].[v_GetAllBancos]"
        If Not String.IsNullOrEmpty(Me.TextBanco.Text) Then
            sQlSentencia += " where Banco_Nombre Like '" & Trim(Me.TextBanco.Text.ToString) & "%'"
        End If

        If Not String.IsNullOrEmpty(Me.TextClave.Text) Then
            sQlSentencia += " where Banco_ClaveOficial Like '" & Trim(Me.TextClave.Text.ToString) & "%'"
        End If

        BindBancosToList(sQlSentencia)
    End Sub
    Protected Sub Btn_Limpiar_Click()
        Me.TextBanco.Text = String.Empty
        Me.TextClave.Text = String.Empty
    End Sub

    Protected Sub Btn_Nuevo_Click()
        Server.Transfer("~/manbancos.aspx")
    End Sub

    Protected Sub Btn_Eliminar_Click()

    End Sub
    Protected Sub Btn_Editar_Click()
        Dim row As GridViewRow = GVBancos.SelectedRow
        If row IsNot Nothing Then
            valor = row.Cells(0).Text
            If Not String.IsNullOrEmpty(valor) Then
                Server.Transfer("~/manbancos.aspx?Valor=" & valor)
            End If
        End If
    End Sub

    Private Sub BindBancosToList(ByVal _Sentencia As String)
        If Not String.IsNullOrEmpty(_Sentencia) Then
            Dim Lista As List(Of BancosEnt) = Nothing
            Try
                Lista = BancosLN.getInstance.ListarBancos(_Sentencia)
                Me.GVBancos.DataSource = Lista
                Me.GVBancos.DataBind()
            Catch ex As Exception
                Lista = Nothing
                Throw ex
            End Try
        Else
            Dim Lista As List(Of BancosEnt) = Nothing
            Try
                Lista = BancosLN.getInstance.ListarBancos(_Sentencia)
                Me.GVBancos.DataSource = Lista
                Me.GVBancos.DataBind()
            Catch ex As Exception
                Lista = Nothing
                Throw ex
            End Try
        End If

    End Sub

    Private Sub GVBancos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GVBancos.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onMouseOver") = "this.style.cursor='Pointer'; this.originalstyle=this.style.backgroundColor ; this.style.backgroundColor='#B0C4DE'"
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalstyle;")
            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(sender, "Select$" & e.Row.RowIndex.ToString())
        End If
    End Sub

    Private Sub GVBancos_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GVBancos.SelectedIndexChanging
        GVBancos.SelectedIndex = -1
    End Sub

    Private Sub GVBancos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVBancos.RowCommand
        If e.CommandName = "Select" Then
            ' Se obtiene indice de la row seleccionada
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' Obtengo el id de la entidad que se esta editando
            ' en este caso de la entidad Person  
            Dim id As Integer = Convert.ToInt32(GVBancos.DataKeys(index).Value)
        End If
    End Sub

    Private Sub GVBancos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVBancos.SelectedIndexChanged
        'fila = GVBancos.SelectedRow().Cells(0).Text

        GVBancos.SelectedRow.BackColor = Color.DarkOrange
        For i As Integer = 0 To GVBancos.Rows.Count - 1

            If GVBancos.Rows(i).RowIndex <> GVBancos.SelectedRow.RowIndex Then
                GVBancos.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub
End Class