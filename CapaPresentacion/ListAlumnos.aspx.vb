Imports CapaEntidades
Imports CapaLogicaNegocio
Public Class ListAlumnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Me.BindAlumnosToList()

            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub

    Protected Sub Btn_Limpiar_Click()
        Me.TextCurp.Text = String.Empty
        Me.TextMatricula.Text = String.Empty
        Me.TextNombre.Text = String.Empty
        Me.TextMatricula.Focus()

    End Sub

    Protected Sub Btn_Nuevo_Click()
        Response.Redirect("~/manAlumno.aspx")
    End Sub
    Protected Sub Btn_Buscar_Click()

    End Sub

    Private Sub BindAlumnosToList()
        'Dim dt As DataTable = Nothing

        'Me.gvAlumnos.DataSource = dt
        'Me.gvAlumnos.DataBind()
        Dim Lista As List(Of AlumnoEnt) = Nothing
        Try
            Lista = AlumnoLN.getInstance.ListarAlumnos()
            Me.gvAlumnos.DataSource = Lista
            Me.gvAlumnos.DataBind()
        Catch ex As Exception
            Lista = Nothing
            Throw ex


        End Try
    End Sub

    Private Sub gvAlumnos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvAlumnos.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Private Sub gvAlumnos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvAlumnos.PageIndexChanging
        BindAlumnosToList()
        Me.gvAlumnos.PageIndex = e.NewPageIndex
        Me.gvAlumnos.DataBind()
    End Sub
End Class