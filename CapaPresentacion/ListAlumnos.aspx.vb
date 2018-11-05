Imports System.Drawing
Imports CapaEntidades
Imports CapaLogicaNegocio
Public Class ListAlumnos
    Inherits System.Web.UI.Page
    Dim fila As String = Nothing
    Dim sQlSentencia As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            If HttpContext.Current.User.Identity.IsAuthenticated Then
                If Roles.IsUserInRole("Tutor") Then
                    Me.MenuBar.Visible = False
                    Me.MenuSelect.Visible = False
                    Me.BindAlumnosToList("Select * from v_GetAllAlumnos Where Alumnos_Tutor = '" & HttpContext.Current.User.Identity.Name & "'")
                    'Me.BindAlumnosToList("")
                Else
                    Me.BindAlumnosToList("Select * from v_GetAllAlumnos")
                End If
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub

    Protected Sub Btn_Editar_Click()
        If gvAlumnos.SelectedIndex >= 0 Then
            Dim row As GridViewRow = gvAlumnos.SelectedRow
            Dim valor As String = row.Cells(1).Text
            Response.Redirect("~/manAlumno.aspx")
        End If
    End Sub

    Protected Sub Btn_Eliminar_Click()

    End Sub
    Protected Sub Btn_Limpiar_Click()
        TextCurp.Text = String.Empty
        TextMatricula.Text = String.Empty
        TextNombre.Text = String.Empty
        TextMatricula.Focus()

    End Sub

    Protected Sub Btn_Nuevo_Click()
        Response.Redirect("~/manAlumno.aspx")
    End Sub

    Protected Sub Btn_Buscar_Click()

        sQlSentencia = String.Empty
        sQlSentencia = "Select * from v_GetAllAlumnos"
        If Not String.IsNullOrEmpty(Me.TextMatricula.Text) Then
            sQlSentencia += " where Alumnos_Matricula Like '%" & Trim(Me.TextMatricula.Text.ToString) & "%'"
        End If

        If Not String.IsNullOrEmpty(Me.TextCurp.Text) Then
            sQlSentencia += " where Alumnos_CURP Like '%" & Trim(Me.TextCurp.Text.ToString) & "%'"
        End If

        If Not String.IsNullOrEmpty(Me.TextNombre.Text) Then
            sQlSentencia += " where Nombre Like '%" & Trim(Me.TextNombre.Text.ToString) & "%'"
        End If
        BindAlumnosToList(sQlSentencia)

    End Sub


    Private Sub BindAlumnosToList(ByVal _sQlSentencia As String)
        'Dim dt As DataTable = Nothing

        'Me.gvAlumnos.DataSource = dt
        'Me.gvAlumnos.DataBind()

        If Roles.IsUserInRole("Tutor") Then
            If Not String.IsNullOrEmpty(_sQlSentencia) Then
                Dim Lista As List(Of AlumnoEnt) = Nothing
                Try
                    Lista = AlumnoLN.getInstance.ListarAlumnos(_sQlSentencia)
                    Me.gvAlumnos.DataSource = Lista
                    Me.gvAlumnos.DataBind()
                Catch ex As Exception
                    Lista = Nothing
                    Throw ex


                End Try
            Else
                Dim Lista As List(Of AlumnoEnt) = Nothing
                Try
                    Lista = AlumnoLN.getInstance.ListarAlumnos(_sQlSentencia)
                    Me.gvAlumnos.DataSource = Lista
                    Me.gvAlumnos.DataBind()
                Catch ex As Exception
                    Lista = Nothing
                    Throw ex


                End Try
            End If
        Else
            Dim Lista As List(Of AlumnoEnt) = Nothing
            Try
                Lista = AlumnoLN.getInstance.ListarAlumnos(_sQlSentencia)
                Me.gvAlumnos.DataSource = Lista
                Me.gvAlumnos.DataBind()
            Catch ex As Exception
                Lista = Nothing
                Throw ex


            End Try
        End If

    End Sub

    Private Sub GvAlumnos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvAlumnos.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
        If Roles.IsUserInRole("Tutor") Then
            e.Row.Cells(0).Visible = True
        End If
        'For Each row As GridViewRow In Me.GridView1.Rows

        '    If row.Cells(1).Text = Me.txtSearch.Text.Trim() Then
        '        GridView1.SelectRow(row.RowIndex)
        '        row.BackColor = Color.PeachPuff
        '    End If
        'Next
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    GridView1.SelectRow(row.RowIndex)
        '    '    e.Row.Attributes.Add("OnMouseOver", "On(this);")
        '    '    e.Row.Attributes.Add("OnMouseOut", "Off(this);")
        '    '    ' e.Row.Attributes("OnClick") =
        '    '    'Page.ClientScript.GetPostBackClientHyperlink(Me.gvAlumnos, "Select$" + e.Row.RowIndex.ToString)

        'End If
        'If e.Row.RowType = DataControlRowType.DataRow Then

        '    'e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor = '#E8E8E8';")
        '    'e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = 'white';")
        '    e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvAlumnos, "Select$" + e.Row.RowIndex.ToString)
        'End If

        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim desc As String = e.Row.Cells(0).Text
        '    Dim cant As Integer = (From item In (CType(Session("datos"), DataTable)).AsEnumerable() Where item.Field(Of String)("Descripcion") = desc Select item).Count()

        '    If cant > 1 Then
        '        e.Row.BackColor = Color.LightCoral
        '    End If
        'End If

        'If e.Row.RowType = DataControlRowType.DataRow Then

        '    e.Row.Attributes.Add("OnMouseOut", "Resaltar_On(this);")
        '    e.Row.Attributes.Add("OnMouseOver", "Resaltar_Off(this)")

        'End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onMouseOver") = "this.style.cursor='Pointer'; this.originalstyle=this.style.backgroundColor ; this.style.backgroundColor='#B0C4DE'"
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalstyle;")

            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(gvAlumnos, "Select$" & e.Row.RowIndex.ToString())
            'e.Row.Attributes("OnDblClick") = Page.ClientScript.GetPostBackClientHyperlink(gvAlumnos, "Select$" & e.Row.RowIndex.ToString())

        End If
    End Sub

    Private Sub gvAlumnos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvAlumnos.PageIndexChanging
        BindAlumnosToList("Select * from v_GetAllAlumnos")
        Me.gvAlumnos.PageIndex = e.NewPageIndex
        Me.gvAlumnos.DataBind()
    End Sub

    Private Sub gvAlumnos_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles gvAlumnos.SelectedIndexChanging
        'gvAlumnos.SelectedRow.BackColor = Color.Gray
        'For i As Integer = 0 To gvAlumnos.Rows.Count - 1

        '    If gvAlumnos.Rows(i).RowIndex <> gvAlumnos.SelectedRow.RowIndex Then
        '        gvAlumnos.Rows(i).BackColor = Color.Empty
        '    End If
        'Next

        'Dim row As GridViewRow = gvAlumnos.Rows(e.NewSelectedIndex)

        gvAlumnos.SelectedIndex = -1
    End Sub

    Private Sub gvAlumnos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAlumnos.RowCommand
        If e.CommandName = "Select" Then

            ' Se obtiene indice de la row seleccionada

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Obtengo el id de la entidad que se esta editando
            ' en este caso de la entidad Person           '

            Dim id As Integer = Convert.ToInt32(gvAlumnos.DataKeys(index).Value)
        End If
    End Sub

    Private Sub gvAlumnos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvAlumnos.SelectedIndexChanged
        fila = gvAlumnos.SelectedRow().Cells(0).Text

        gvAlumnos.SelectedRow.BackColor = Color.DarkOrange

        For i As Integer = 0 To gvAlumnos.Rows.Count - 1

            If gvAlumnos.Rows(i).RowIndex <> gvAlumnos.SelectedRow.RowIndex Then
                gvAlumnos.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub

    'Private Sub SelectRow(ByVal rowindex As Integer)
    '    gvAlumnos.Rows(rowindex).BackColor = Color.Gray

    '    For i As Integer = 0 To gvAlumnos.Rows.Count - 1

    '        If gvAlumnos.Rows(i).RowIndex <> rowindex Then
    '            gvAlumnos.Rows(i).BackColor = Color.Empty
    '        End If
    '    Next
    'End Sub

    Public Function FncGetNivel(ByVal estado As Byte) As String
        Dim Nivel As String = String.Empty

        Select Case estado

            Case 0
                Nivel = "Maternal"
            Case 1
                Nivel = "Pre Escolar"
            Case 2
                Nivel = "Primaria"
            Case 3
                Nivel = "Secundaria"
            Case 4
                Nivel = "Preparatoria"
            Case > 4
                Nivel = "No selección"

        End Select
        Return Nivel
    End Function
End Class