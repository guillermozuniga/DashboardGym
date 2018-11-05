Imports CapaEntidades
Imports CapaLogicaNegocio
Imports System.Drawing
Imports System.IO
Public Class listTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                If Roles.IsUserInRole("Tutor") Then
                    Me.MenuBar.Visible = False
                    Me.MenuSelect.Visible = False
                    Me.ListaAlumnos.Visible = True
                    'Me.ListarCargos()
                    Me.BindAlumnosToList("Select * from v_GetAllTutorAlumnos Where Tutores_Padre_UsuarioWEB = '" & HttpContext.Current.User.Identity.Name & "'")
                Else

                    ListarCalifXAlumno("Select Top 500 * from [eimagenn_sge_admin].[v_CalifxAlumno]")
                    'Me.ListarCargos()
                End If
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub
    Private Sub BindAlumnosToList(ByVal _sQlSentencia As String)
        'Dim dt As DataTable = Nothing
        'Me.gvAlumnos.DataSource = dt
        'Me.gvAlumnos.DataBind()

        If Not String.IsNullOrEmpty(_sQlSentencia) Then
            If Roles.IsUserInRole("Tutor") Then
                Dim Lista As List(Of AlumnoEnt) = Nothing
                Try
                    Lista = AlumnoLN.getInstance.ListarAlumnosXTutor(_sQlSentencia)
                    Me.GvAlum.DataSource = Lista
                    Me.GvAlum.DataBind()
                Catch ex As Exception
                    Lista = Nothing
                    Throw ex
                End Try
            Else
                Dim Lista As List(Of AlumnoEnt) = Nothing
                Try
                    Lista = AlumnoLN.getInstance.ListarAlumnos(_sQlSentencia)
                    Me.GvAlum.DataSource = Lista
                    Me.GvAlum.DataBind()
                Catch ex As Exception
                    Lista = Nothing
                    Throw ex
                End Try
            End If
        Else
            Dim Lista As List(Of AlumnoEnt) = Nothing
            Try
                Lista = AlumnoLN.getInstance.ListarAlumnos(_sQlSentencia)
                Me.GvAlum.DataSource = Lista
                Me.GvAlum.DataBind()
            Catch ex As Exception
                Lista = Nothing
                Throw ex
            End Try
        End If
    End Sub

    Private Sub ListarCalifXAlumno(ByVal _sQlSentencia As String)
        If Not String.IsNullOrEmpty(_sQlSentencia) Then

        End If
    End Sub

    Protected Sub Btn_Limpiar_Click()
        'ListarCargos()
        Me.TextMatricula.Text = String.Empty
        Me.TextNombreAlumno.Text = String.Empty

        Me.TextMatricula.Focus()
    End Sub

    Private Sub GvAlum_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GvAlum.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onMouseOver") = "this.style.cursor='Pointer'; this.originalstyle=this.style.backgroundColor ; this.style.backgroundColor='#B0C4DE'"

            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalstyle;")

            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(GvAlum, "Select$" & e.Row.RowIndex.ToString())
            'e.Row.Attributes("OnDblClick") = Page.ClientScript.GetPostBackClientHyperlink(gvAlumnos, "Select$" & e.Row.RowIndex.ToString())

        End If
    End Sub

    Private Sub GvAlum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GvAlum.SelectedIndexChanged
        GvAlum.SelectedRow.BackColor = Color.Orange
        Dim row As GridViewRow = GvAlum.SelectedRow
        Me.HiddenField1.Value = row.Cells(2).Text
        For i As Integer = 0 To GvAlum.Rows.Count - 1

            If GvAlum.Rows(i).RowIndex <> GvAlum.SelectedRow.RowIndex Then
                GvAlum.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub

    Private Sub GvAlum_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GvAlum.SelectedIndexChanging
        GvAlum.SelectedIndex = -1
    End Sub

    Private Sub GvAlum_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvAlum.RowCommand
        If e.CommandName = "Select" Then
            'Me.HiddenField1.Value = CType(GvAlum.SelectedRow.FindControl("lblNombre"), Label).Text
            ' Se obtiene indice de la row seleccionada
            '
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Obtengo el id de la entidad que se esta editando
            ' en este caso de la entidad Person          '

            Dim id As Integer = Convert.ToInt32(GvAlum.DataKeys(index).Value)

            'Me.BindAlumnosToList("Select * from v_GetAllTutorAlumnos Where Tutores_Padre_UsuarioWEB = '" & HttpContext.Current.User.Identity.Name & "'")
        End If
    End Sub
End Class