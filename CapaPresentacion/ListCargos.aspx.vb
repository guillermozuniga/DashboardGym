Imports CapaEntidades
Imports CapaLogicaNegocio
Imports System.Drawing
Imports System.IO
Public Class ListCargos
    Inherits System.Web.UI.Page
    Dim fila As String = Nothing
    Dim sQlSentencia As String = Nothing
    Dim miDataTable, dtable As New DataTable
    Dim referencia, texto, texto1, importe, comisiones As String
    Dim longitud As Integer
    Dim mat, grp As String
    Protected widestData As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then

                LlenarDropRegistros()
                If Roles.IsUserInRole("Tutor") Then
                    Me.MenuBar.Visible = False
                    Me.MenuSelect.Visible = False
                    Me.ListaAlumnos.Visible = True

                    Me.gvCargos.Columns(10).Visible = False
                    Me.gvCargos.Columns(1).Visible = False
                    Me.gvCargos.Columns(2).Visible = False

                    'Me.ListarCargos()
                    Me.BindAlumnosToList("Select * from [eimagenn_sge_admin].[v_GetAllTutorAlumnos] Where Tutores_Padre_UsuarioWEB = '" & HttpContext.Current.User.Identity.Name & "'")
                    Dim dt As DataTable = Nothing
                    Me.gvCargos.DataSource = dt
                    Me.gvCargos.DataBind()

                Else
                    Me.gvCargos.Columns(10).Visible = False
                    Me.gvCargos.Columns(9).Visible = False
                    ListarCargosXAlumno("Select Top 250 * from [eimagenn_sge_admin].[v_CargosXAlumno] order by Alumnos_Matricula")
                    'Me.ListarCargos()
                End If
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If

    End Sub
    Public Function QuitAccents(ByVal inputString As String) As String
        Dim a As Regex = New Regex("[á|à|ä|â]", RegexOptions.Compiled)
        Dim e As Regex = New Regex("[é|è|ë|ê]", RegexOptions.Compiled)
        Dim i As Regex = New Regex("[í|ì|ï|î]", RegexOptions.Compiled)
        Dim o As Regex = New Regex("[ó|ò|ö|ô]", RegexOptions.Compiled)
        Dim u As Regex = New Regex("[ú|ù|ü|û]", RegexOptions.Compiled)
        Dim n As Regex = New Regex("[ñ|Ñ]", RegexOptions.Compiled)
        inputString = a.Replace(inputString, "a")
        inputString = e.Replace(inputString, "e")
        inputString = i.Replace(inputString, "i")
        inputString = o.Replace(inputString, "o")
        inputString = u.Replace(inputString, "u")
        inputString = n.Replace(inputString, "n")
        Return inputString
    End Function

    Private Sub LlenarDropRegistros()
        DropDownList1.Items.Insert(0, "25")
        DropDownList1.Items.Insert(1, "50")
        DropDownList1.Items.Insert(2, "100")
        DropDownList1.Items.Insert(3, "250")
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
    Private Sub ListarCargos()
        Dim Lista As List(Of ColCargos) = Nothing
        Try
            Lista = CargosLN.getInstance.ListarCargo()
            Me.gvCargos.DataSource = Lista
            Me.gvCargos.DataBind()
        Catch ex As Exception
            Lista = Nothing
        End Try
    End Sub

    Private Sub ListarCargosXAlumno(ByVal _sQlSentencia As String)

        Dim Lista As List(Of ColCargos) = Nothing
        Try
            Lista = CargosLN.getInstance.ListarCargoXAlumnos(_sQlSentencia)

            Me.gvCargos.DataSource = Lista
            Me.gvCargos.DataBind()
        Catch ex As Exception
            Lista = Nothing
        End Try

    End Sub
    Protected Sub Btn_Buscar_Click()
        If Not String.IsNullOrEmpty(Me.TextMatricula.Text) Then
            If Not String.IsNullOrEmpty(Me.TextFecha.Text) Then
                ListarCargosXAlumno("Select Top 250 * from [eimagenn_sge_admin].[V_CargosXAlumno] where Alumnos_Matricula ='" & Me.TextMatricula.Text & "' and Cargos_fechadevencimiento = '" & Me.TextFecha.Text & "'")

            Else
                ListarCargosXAlumno("Select Top 250 * from [eimagenn_sge_admin].[V_CargosXAlumno] where Alumnos_Matricula Like '" & Me.TextMatricula.Text & "'")
            End If
        Else
            If Not String.IsNullOrEmpty(Me.TextFecha.Text) Then
                ListarCargosXAlumno("Select Top 250 * from [eimagenn_sge_admin].[v_CargosXAlumno] where Cargos_Fechadevencimiento = '" & Me.TextFecha.Text & "'")
            Else
                ListarCargosXAlumno("Select Top 250 * from [eimagenn_sge_admin].[v_CargosXAlumno]")
            End If
        End If
    End Sub
    Protected Sub Btn_Limpiar_Click()
        ListarCargosXAlumno("Select Top 500 * from [eimagenn_sge_admin].[v_CargosXAlumno]")
        Me.TextMatricula.Text = String.Empty
        Me.TextFecha.Text = String.Empty

        Me.TextMatricula.Focus()
    End Sub

    Private Sub GvCargos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvCargos.PageIndexChanging
        'ListarCargos()
        ListarCargosXAlumno("Select Top 250 * from [eimagenn_sge_admin].[v_CargosXAlumno]")
        Me.gvCargos.PageIndex = e.NewPageIndex
        Me.gvCargos.DataBind()
    End Sub

    Private Sub GvAlum_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GvAlum.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onMouseOver") = "this.style.cursor='Pointer'; this.originalstyle=this.style.backgroundColor ; this.style.backgroundColor='#B0C4DE'"
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalstyle;")
            e.Row.ToolTip = "Click selecciona renglon"
            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(sender, "Select$" & e.Row.RowIndex.ToString())
            'e.Row.Attributes("OnDblClick") = Page.ClientScript.GetPostBackClientHyperlink(sender, "Select$" & e.Row.RowIndex.ToString())
        End If
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

            ListarCargosXAlumno("Select Top 250 * from [eimagenn_sge_admin].[v_CargosXAlumno] Where Alumnos_Matricula = '" & id & "'")

        End If
    End Sub

    Private Sub GvAlum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GvAlum.SelectedIndexChanged
        GvAlum.SelectedRow.BackColor = Color.DarkOrange
        Dim row As GridViewRow = GvAlum.SelectedRow
        HiddenField1.Value = QuitAccents(row.Cells(2).Text)
        For i As Integer = 0 To GvAlum.Rows.Count - 1
            If GvAlum.Rows(i).RowIndex <> GvAlum.SelectedRow.RowIndex Then
                GvAlum.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub

    Private Sub gvCargos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvCargos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onMouseOver") = "this.style.cursor='Pointer'; this.originalstyle=this.style.backgroundColor ; this.style.backgroundColor='#B0C4DE'"
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalstyle;")
        End If

    End Sub

    Private Sub gvCargos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCargos.RowCommand
        texto1 = e.CommandArgument
        Dim mp As MasterPage = TryCast(Me.Master, MasterPage)
        longitud = texto1.Length

        Select Case e.CommandName
            Case "EnLinea"
                Dim collections, collections1, collections2 As New NameValueCollection()
                'Dim remoteUrl As String = "https://www.prosepago.com/tvirtual/tvsv.aspx?ppost=1&t=32159" 'Valle
                'Dim remoteUrl As String = "https://www.prosepago.com/tvirtual/tvsv.aspx?ppost=1&t=32324" 'salva
                'Dim remoteUrl As String = "https://www.prosepago.com/tvirtual/tvsv.aspx?ppost=1&t=32545" 'Anglo Americano
                Dim remoteUrl As String = "https://www.prosepago.com/tvirtual/tvsv.aspx?ppost=1&t=32546" 'MexicoAmericano

                Dim html As String = String.Empty

                Dim hf As HiddenField = TryCast(mp.FindControl("HiddenFieldCorreoTutor"), HiddenField)

                Dim lb As Label = TryCast(mp.FindControl("LblRol"), Label)

                If Not String.IsNullOrEmpty(texto1.TrimEnd) Then

                    collections.Add("nom", Server.HtmlDecode(HiddenField1.Value.ToString()))
                    collections.Add("con", CStr(texto1.Substring(0, InStr(Trim(e.CommandArgument.ToString), "/") - 1)))
                    collections.Add("ref", texto1.Substring(InStr(Trim(e.CommandArgument.ToString), "/"), InStr(Trim(e.CommandArgument.ToString), "@") - InStr(Trim(e.CommandArgument.ToString), "/") - 1))
                    importe = Convert.ToDouble(texto1.Substring(InStr(Trim(e.CommandArgument.ToString), "@"), longitud - InStr(Trim(e.CommandArgument.ToString), "@"))) / 0.96868
                    'comisiones = Convert.ToDouble(texto1.Substring(InStr(Trim(e.CommandArgument.ToString), "@"), longitud - InStr(Trim(e.CommandArgument.ToString), "@"))) / 0.96868
                    collections.Add("imp", importe)

                    collections.Add("autoBack", 0)
                    collections.Add("datbloq", 1)

                    If Not String.IsNullOrEmpty(Trim(hf.Value.ToString)) Then
                        collections.Add("ema", hf.Value.ToLower)
                    Else
                        collections.Add("ema", "contabilidad@comexam.edu.mx")
                    End If

                    html = "<html><head>"
                    html += "</head><body onload='document.forms[0].submit()'>"
                    html += String.Format("<form name='PostForm' method='POST' action='{0}' id='datos'>", remoteUrl)
                    For Each key As String In collections.Keys
                        html += String.Format("<input name='{0}' type='text' value='{1}' id='{0}'>", key, collections(key))
                    Next
                    html += "</form></body></html>"
                    Response.Clear()
                    Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1")
                    Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1")
                    Response.Charset = "ISO-8859-1"
                    Response.Write(html)
                    Response.End()
                End If
        End Select
    End Sub


End Class