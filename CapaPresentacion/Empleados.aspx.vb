Imports System.Drawing
Imports CapaEntidades
Imports CapaLogicaNegocio
Public Class Empleados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                LlenarDropRegistros()
                Me.BindEmpleadosToList("")
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
    Private Sub BindEmpleadosToList(ByVal _SqlSentencia As String)
        Dim Lista As List(Of EmpleadoEnt) = Nothing
        If Not String.IsNullOrEmpty(Trim(_SqlSentencia)) Then
            Try
                Lista = EmpleadosLN.getInstance.ListarEmpleados()
                Me.GVEmpleados.DataSource = Lista
                Me.GVEmpleados.DataBind()
            Catch ex As Exception
                Lista = Nothing
                Throw ex
            End Try
        Else
            Try
                Lista = EmpleadosLN.getInstance.ListarEmpleados()
                Me.GVEmpleados.DataSource = Lista
                Me.GVEmpleados.DataBind()
            Catch ex As Exception
                Lista = Nothing
                Throw ex
            End Try
        End If



    End Sub

    Protected Sub Btn_Nuevo_Click()
        Server.Transfer("~/manEmpleado.aspx")
    End Sub

    Protected Sub Btn_Editar_Click()
        Dim row As GridViewRow = GVEmpleados.SelectedRow
        If row IsNot Nothing Then
            Dim valor As String = row.Cells(0).Text
            If Not String.IsNullOrEmpty(valor) Then
                Server.Transfer("~/manEmpleado.aspx?Valor=" & valor)
            End If
        End If
    End Sub

    Protected Sub Btn_Eliminar_Click()

    End Sub

    Protected Sub Btn_Buscar_Click()
        If Not String.IsNullOrEmpty(Trim(TextNombre.Text)) Then
            BindEmpleadosToList("")
        End If

        If Not String.IsNullOrEmpty(Trim(TextNumero.Text)) Then
            BindEmpleadosToList("")
        End If

        If Not String.IsNullOrEmpty(Trim(TextCurp.Text)) Then
            BindEmpleadosToList("")
        End If


    End Sub

    Private Sub GVEmpleados_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GVEmpleados.RowDataBound
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

    Private Sub GVEmpleados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVEmpleados.SelectedIndexChanged
        GVEmpleados.SelectedRow.BackColor = Color.Orange

        For i As Integer = 0 To GVEmpleados.Rows.Count - 1

            If GVEmpleados.Rows(i).RowIndex <> GVEmpleados.SelectedRow.RowIndex Then
                GVEmpleados.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub

    Private Sub GVEmpleados_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVEmpleados.PageIndexChanging

        BindEmpleadosToList("")
        Me.GVEmpleados.PageIndex = e.NewPageIndex
        Me.GVEmpleados.DataBind()
    End Sub
End Class