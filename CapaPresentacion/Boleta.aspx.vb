Imports CapaEntidades
Imports CapaLogicaNegocio
Imports System.Drawing
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.Image
Public Class Boleta

    Inherits System.Web.UI.Page
    Dim fila As String = Nothing
    Dim sQlSentencia As String = Nothing
    Dim miDataTable, dtable As New DataTable
    Dim referencia, texto, texto1 As String
    Dim longitud As Integer
    Dim mat, grp As String
    Protected widestData As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                If Roles.IsUserInRole("Tutor") Then
                    MenuBar.Visible = False
                    MenuSelect.Visible = False
                    'GVBoleta.Columns(18).Visible = False
                    GVBoleta.Columns(0).Visible = False
                    ListaAlumnos.Visible = True
                    Btn_Imprimir.Visible = False
                    Me.BindAlumnosToList("Select * from [eimagenn_sge_admin].[v_GetAllTutorAlumnos] Where Tutores_Padre_UsuarioWEB = '" & HttpContext.Current.User.Identity.Name & "'")
                    Dim dt As DataTable = Nothing
                    Me.GVBoleta.DataSource = dt
                    Me.GVBoleta.DataBind()
                Else
                    MenuBar.Visible = False
                    GVBoleta.Columns(3).Visible = False
                    ListarBoletaXAlumno("Select * from [eimagenn_sge_admin].[v_CalifxAlumno]")
                End If
            Else
                Server.Transfer("~/logout.aspx")
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

    Private Sub ListarBoletaXAlumno(ByVal _sQlSentencia As String)

        Dim Lista As List(Of BoletaEnt) = Nothing
        Try
            Lista = BoletaLN.getInstance.ListarBoletas(_sQlSentencia)

            GVBoleta.DataSource = Lista
            GVBoleta.DataBind()

        Catch ex As Exception
            Lista = Nothing
        End Try

    End Sub
    Protected Sub Btn_Buscar_Click()
        If Not String.IsNullOrEmpty(Me.TextMatricula.Text) Then
            ListarBoletaXAlumno("Select * from [eimagenn_sge_admin].[v_CalifxAlumno] where Alumnos_Matricula Like '%" & Me.TextMatricula.Text & "%'")
        Else
            ListarBoletaXAlumno("Select  * from [eimagenn_sge_admin].[v_CalifxAlumno]")
        End If
    End Sub
    Protected Sub Btn_Limpiar_Click()
        ListarBoletaXAlumno("Select * from [eimagenn_sge_admin].[v_CalifxAlumno]")
        Me.TextMatricula.Text = String.Empty
        Me.TextMatricula.Focus()
    End Sub

    Private Sub GVBoleta_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVBoleta.PageIndexChanging
        If fila > 0 Then
            ListarBoletaXAlumno("Select  * from [eimagenn_sge_admin].[v_CalifxAlumno] Where Alumnos_Matricula = '" & fila & "'")

            GVBoleta.PageIndex = e.NewPageIndex

            GVBoleta.DataBind()

        Else

            ListarBoletaXAlumno("Select * from [eimagenn_sge_admin].[v_CalifxAlumno]")

            GVBoleta.PageIndex = e.NewPageIndex

            GVBoleta.DataBind()
        End If


    End Sub

    Private Sub GvAlum_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GvAlum.RowDataBound
        'If e.Row.RowType = DataControlRowType.Header Then
        '    e.Row.TableSection = TableRowSection.TableHeader
        'End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onMouseOver") = "this.style.cursor='Pointer'; this.originalstyle=this.style.backgroundColor ; this.style.backgroundColor='#B0C4DE'"
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=this.originalstyle;")
            e.Row.ToolTip = "Click selecciona renglon"
            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(sender, "Select$" & e.Row.RowIndex.ToString())
            e.Row.Attributes("OnDblClick") = Page.ClientScript.GetPostBackClientHyperlink(sender, "Select$" & e.Row.RowIndex.ToString())
        End If
    End Sub

    Private Sub GvAlum_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GvAlum.SelectedIndexChanging
        GvAlum.SelectedIndex = -1
    End Sub

    Private Sub GvAlum_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvAlum.RowCommand
        If e.CommandName = "Select" Then
            'Me.HiddenField1.Value = CType(GvAlum.SelectedRow.FindControl("lblNombre"), Label).Text
            ' Se obtiene indice de la row seleccionada

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Obtengo el id de la entidad que se esta editando
            ' en este caso de la entidad Person

            fila = Convert.ToInt32(GvAlum.DataKeys(index).Value)

            ListarBoletaXAlumno("Select  * from [eimagenn_sge_admin].[v_CalifxAlumno] Where Alumnos_Matricula = '" & fila & "'")
            Btn_Imprimir.Visible = True
            'panel1.Visible = False

        End If
    End Sub

    Private Sub GvAlum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GvAlum.SelectedIndexChanged
        GvAlum.SelectedRow.BackColor = Color.DarkOrange
        Dim row As GridViewRow = GvAlum.SelectedRow
        HiddenField1.Value = row.Cells(1).Text
        HiddenField2.Value = row.Cells(2).Text
        HiddenField3.Value = row.Cells(4).Text
        For i As Integer = 0 To GvAlum.Rows.Count - 1
            If GvAlum.Rows(i).RowIndex <> GvAlum.SelectedRow.RowIndex Then
                GvAlum.Rows(i).BackColor = Color.Empty
            End If
        Next
    End Sub

    Private Function CreateCell(ByVal texto As String, ByVal colorfondo As Boolean, ByVal cols As Integer, ByVal alineacion As Integer, ByVal medida As Integer, ByVal Border As Boolean, ByVal rowspan As Integer, ByVal italica As Boolean, ByVal negrita As Boolean) As PdfPCell
        'Dim largeBold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 32, iTextSharp.text.Font.BOLD)
        Dim largeBold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, medida, iTextSharp.text.Font.BOLD)
        Dim smallItalic As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, medida, iTextSharp.text.Font.ITALIC)
        Dim smallNormal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, medida, iTextSharp.text.Font.NORMAL)
        Dim redFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.ITALIC Or iTextSharp.text.Font.UNDERLINE, BaseColor.RED)

        Dim CELL As New PdfPCell

        If italica Then
            CELL.Phrase = New Phrase(texto, smallItalic)
        Else
            CELL.Phrase = New Phrase(texto, smallNormal)
        End If

        If negrita Then
            'Dim CELL As New PdfPCell(New Phrase(texto, FontFactory.GetFont(FontFactory.HELVETICA, size:=medida, style:=iTextSharp.text.Font.BOLD)))
            CELL.Phrase = New Phrase(texto, largeBold)
        End If

        'Dim cell As New PdfPCell(New Phrase(texto, FontFactory.GetFont(FontFactory.HELVETICA, size:=medida, style:=iTextSharp.text.Font.BOLD)))
        'Dim CELL As New PdfPCell

        'Dim cell As New PdfPCell(New Phrase(texto, smallItalic))

        If colorfondo Then
            CELL.BackgroundColor = New BaseColor(187, 224, 227)
            'cell.BackgroundColor = New BaseColor(192, 192, 192)

        End If

        If cols > 0 Then

            CELL.Colspan = cols

        End If

        CELL.HorizontalAlignment = alineacion

        If Border Then
            CELL.BorderColor = New BaseColor(180, 180, 180)
        Else
            CELL.Border = 0
        End If

        CELL.Rowspan = rowspan

        Return CELL

    End Function

    Protected Sub Btn_Imprimir_Click()
        Dim rowSelect As GridViewRow = GvAlum.SelectedRow

        If rowSelect IsNot Nothing Then
            If GVBoleta.Rows.Count > 0 Then

                ' ***********************************************************************************************************************
                Dim renglones As Integer = 10
                Dim parrafo, parrafo2 As New Paragraph
                Dim texto As String = "                                                                        "
                Dim segundos As DateTime = DateTime.Now
                parrafo2.Add(texto)

                Dim doc1 As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 15, 20, 10)

                Dim path As String = Server.MapPath("~/pdfs")

                Dim filename As String = path + "\Boleta" + segundos.ToString("ss") + ".pdf"

                Dim nombreimagen As String = String.Empty

                PdfWriter.GetInstance(doc1, New FileStream(filename, FileMode.OpenOrCreate))

                doc1.Open()

                doc1.NewPage()
                Dim imagen As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img" + "\anglo.png"))
                imagen.ScalePercent(50.0F)
                imagen.SetAbsolutePosition(50, 720.0F)
                doc1.Add(imagen)

                parrafo.Alignment = Element.ALIGN_CENTER
                parrafo.Font = FontFactory.GetFont("Arial", 12, ALIGN_CENTER)
                Dim maintable As New PdfPTable(4)
                maintable.TotalWidth = 430.0F
                maintable.LockedWidth = True

                Dim widths As Single() = New Single() {200, 70, 70, 80}
                maintable.SetWidths(widths)
                maintable.HorizontalAlignment = 2
                maintable.DefaultCell.Border = 0

                maintable.AddCell(CreateCell("COLEGIO ANGLO AMERICANO DE NUESTRA SEÑORA DE LA PAZ", False, 4, 1, 8, False, 1, True, True))
                maintable.AddCell(CreateCell("ESCUELA SECUNDARIA CLAVE 02PES0020G", False, 4, 1, 8, False, 1, True, False))
                maintable.AddCell(CreateCell("RUA AEROPUERTO No. 490, COLONIA RIVERA ", False, 4, 1, 8, False, 1, True, False))
                maintable.AddCell(CreateCell("Mexicali, Baja Calif. C.P. 21259 T: 554 7301 Ext. 2", False, 4, 1, 8, False, 1, True, False))
                maintable.AddCell(CreateCell("", False, 4, 1, 7, False, 1, True, False))

                Dim Celda As New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont(FontFactory.HELVETICA, 7.0F, style:=iTextSharp.text.Font.BOLD)))
                Dim Celda1 As New PdfPCell(New Phrase("MATRICULA", FontFactory.GetFont(FontFactory.HELVETICA, 7.0F, style:=iTextSharp.text.Font.BOLD)))
                Dim Celda2 As New PdfPCell(New Phrase("GRUPO", FontFactory.GetFont(FontFactory.HELVETICA, 7.0F, style:=iTextSharp.text.Font.BOLD)))
                Dim Celda3 As New PdfPCell(New Phrase("CICLO ESCOLAR", FontFactory.GetFont(FontFactory.HELVETICA, 7.0F, style:=iTextSharp.text.Font.BOLD)))


                Celda.HorizontalAlignment = 1
                Celda1.HorizontalAlignment = 1
                Celda2.HorizontalAlignment = 1
                Celda3.HorizontalAlignment = 1

                Celda.BackgroundColor = New BaseColor(187, 224, 227)
                Celda1.BackgroundColor = New BaseColor(187, 224, 227)
                Celda2.BackgroundColor = New BaseColor(187, 224, 227)
                Celda3.BackgroundColor = New BaseColor(187, 224, 227)

                Celda.BorderColor = New BaseColor(180, 180, 180)
                Celda1.BorderColor = New BaseColor(180, 180, 180)
                Celda2.BorderColor = New BaseColor(180, 180, 180)
                Celda3.BorderColor = New BaseColor(180, 180, 180)

                maintable.AddCell(Celda)
                maintable.AddCell(Celda1)
                maintable.AddCell(Celda2)
                maintable.AddCell(Celda3)

                maintable.AddCell(CreateCell(HiddenField2.Value, False, 0, 0, 8, True, 1, False, False))
                maintable.AddCell(CreateCell(HiddenField1.Value, False, 0, 1, 8, True, 1, False, False))
                maintable.AddCell(CreateCell(HiddenField3.Value, False, 0, 1, 8, True, 1, False, False))
                maintable.AddCell(CreateCell(" ", False, 0, 1, 8, True, 1, True, False))

                parrafo.Add(maintable)

                doc1.Add(parrafo)

                doc1.Add(parrafo2)

                parrafo.Clear()

                Dim mainreferencias As New PdfPTable(18) With {
            .TotalWidth = 570.0F,
            .LockedWidth = True
        }

                Dim widthsreferencias As Single() = New Single() {90, 25, 25, 25, 40, 25, 25, 25, 40, 25, 25, 25, 40, 25, 25, 25, 20, 40}
                mainreferencias.SetWidths(widthsreferencias)
                mainreferencias.HorizontalAlignment = 1
                mainreferencias.DefaultCell.Border = 0

                'mainreferencias.AddCell(CreateCell("", True, 2, 2, 6, True, 1, False, False))
                'mainreferencias.AddCell(CreateCell("Pago anticipado antes 1ro Mes", True, 2, 2, 6, True, 1, False, False))

                'mainreferencias.AddCell(CreateCell("Pago oportuno 1ro al 15 del Mes", True, 2, 2, 6, True, 1, False, False))
                'mainreferencias.AddCell(CreateCell("Pago con recargos despues del Dia 15", True, 2, 2, 6, True, 1, False, False))

                mainreferencias.AddCell(CreateCell("FORMACION ACADEMICA", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("SEP", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("OCT", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("NOV", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("P1", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("DIC", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("ENE", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("FEB", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("ENE", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("P2", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("ABR", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("MAY", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("JUN", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("P3", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("", True, 0, 1, 6, True, 1, False, False))
                mainreferencias.AddCell(CreateCell("PF", True, 0, 1, 6, True, 1, False, False))

                For Each row As GridViewRow In GVBoleta.Rows

                    If row.Cells(1).Text <> "PROMEDIOS" Then
                        mainreferencias.AddCell(CreateCell(Server.HtmlDecode(row.Cells(1).Text.ToString()), False, 0, 0, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell(row.Cells(2).Text.ToString(), False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell(row.Cells(3).Text.ToString(), False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", False, 0, 1, 7, True, 1, False, False))

                    Else
                        mainreferencias.AddCell(CreateCell(row.Cells(1).Text.ToString(), True, 0, 0, 7, True, 1, False, True))
                        mainreferencias.AddCell(CreateCell(row.Cells(2).Text.ToString(), True, 0, 1, 7, True, 1, False, True))
                        mainreferencias.AddCell(CreateCell(row.Cells(3).Text.ToString(), True, 0, 1, 7, True, 1, False, True))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, True, 1, False, False))
                        parrafo.Add(mainreferencias)

                        doc1.Add(parrafo)
                        doc1.Add(parrafo2)

                        parrafo.Clear()
                        mainreferencias.Rows.Clear()
                        mainreferencias.AddCell(CreateCell("NO CURRICULARES", True, 0, 0, 7, False, 1, False, True))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                        mainreferencias.AddCell(CreateCell("", True, 0, 1, 7, False, 1, False, False))
                    End If
                Next

                parrafo.Add(mainreferencias)
                doc1.Add(parrafo)
                parrafo.Clear()

                'If miDataTable.Rows.Count > 0 Then

                '    For y = 0 To miDataTable.Rows.Count - 1

                '        renglones = renglones - 1
                '        mainreferencias.AddCell(CreateCell(miDataTable.Rows(y).Item("FechadePago"), False, 0, 1, 6, True, 1, False, False))
                '        mainreferencias.AddCell(CreateCell(miDataTable.Rows(y).Item("Concepto"), False, 0, 1, 7, True, 1, False, False))
                '        mainreferencias.AddCell(CreateCell(miDataTable.Rows(y).Item("Importe"), False, 0, 1, 7, True, 1, False, False))
                '        mainreferencias.AddCell(CreateCell(miDataTable.Rows(y).Item("referenciabanco"), False, 0, 1, 8, True, 1, False, False))
                '        mainreferencias.AddCell(CreateCell(miDataTable.Rows(y).Item("Importe2"), False, 0, 1, 7, True, 1, False, False))
                '        mainreferencias.AddCell(CreateCell(miDataTable.Rows(y).Item("referenciabanco2"), False, 0, 1, 8, True, 1, False, False))
                '        mainreferencias.AddCell(CreateCell(miDataTable.Rows(y).Item("Importe3"), False, 0, 1, 7, True, 1, False, False))
                '        mainreferencias.AddCell(CreateCell(miDataTable.Rows(y).Item("referenciabanco3"), False, 0, 1, 8, True, 1, False, False))

                '    Next

                '    For z = 1 To renglones

                '        mainreferencias.AddCell(CreateCell(Space(10), False, 8, 1, 5, True, 1, False, False))

                '    Next
                'End If
                Dim mainobservaciones As New PdfPTable(1) With {
            .TotalWidth = 570.0F,
            .LockedWidth = True
        }

                Dim widthobservaciones As Single() = New Single() {570}
                mainobservaciones.SetWidths(widthobservaciones)
                mainobservaciones.HorizontalAlignment = 1
                mainobservaciones.DefaultCell.Border = 1
                mainobservaciones.AddCell(CreateCell(Space(5), False, 0, 1, 8, False, 1, False, False))
                mainobservaciones.AddCell(CreateCell("ALUMNO :" & HiddenField2.Value.ToString(), False, 0, 1, 8, True, 1, False, False))
                mainobservaciones.AddCell(CreateCell("MATRICULA : " & HiddenField1.Value.ToString() & " GRUPO : " & HiddenField3.Value.ToString(), False, 0, 0, 8, True, 1, False, False))
                mainobservaciones.AddCell(CreateCell("MES EVALUADO : OCTUBRE", False, 0, 0, 8, True, 1, False, False))
                mainobservaciones.AddCell(CreateCell(Space(5), False, 0, 1, 8, False, 1, False, False))
                mainobservaciones.AddCell(CreateCell("Firma Padre :____________________________________   Firma Madre :___________________________________", False, 0, 0, 8, False, 1, False, False))
                parrafo.Add(mainobservaciones)

                doc1.Add(parrafo)
                doc1.Add(parrafo2)
                doc1.Add(parrafo2)
                doc1.Add(parrafo2)
                doc1.Add(parrafo2)
                doc1.Add(parrafo2)

                doc1.Close()

                Dim targetFile As System.IO.FileInfo = New System.IO.FileInfo(filename)

                If targetFile.Exists Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + targetFile.Name)
                    Response.AddHeader("Content-Length", targetFile.Length.ToString)
                    Response.ContentType = "application/octet-stream"
                    Response.WriteFile(targetFile.FullName)
                End If

                parrafo2.Clear()

                parrafo.Clear()
                'End If
            Else
                Dim message As String = "No hay informacion para su impresión...!!!."

                Dim script As String = "window.onload = function(){ alert('"

                script &= message

                script &= "')};"

                ClientScript.RegisterStartupScript(Me.GetType(), "ErrorMessage", script, True)
            End If
        Else
            Dim message As String = "Selecciona un Alumno...!!!."

            Dim script As String = "window.onload = function(){ alert('"

            script &= message

            script &= "')};"

            ClientScript.RegisterStartupScript(Me.GetType(), "ErrorMessage", script, True)
        End If

    End Sub
End Class