
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Web.Services
Imports System.Threading
Imports System.Configuration
Imports System.Collections.Generic
Imports CapaLogicaNegocio


Public Class wfventas
    Inherits System.Web.UI.Page



    Private Sub BindDropDownList(ddl As DropDownList, query As String, text As String, value As String, defaultText As String)

        'Dim conString As String = ConfigurationManager.ConnectionStrings("LocalSQLServer").ConnectionString
        'Dim cmd As New SqlCommand(query)
        'Using con As New SqlConnection(conString)
        '    Using sda As New SqlDataAdapter()
        '        Try
        '            cmd.Connection = con
        '            con.Open()
        '            ddl.DataSource = cmd.ExecuteReader()
        '            ddl.DataTextField = text
        '            ddl.DataValueField = value
        '            ddl.DataBind()
        '        Catch ex As Exception
        '            Throw ex
        '        Finally

        '            If cmd.Connection.State = ConnectionState.Open Then
        '                cmd.Connection.Close()
        '                ' cmd.Connection.Dispose()
        '            End If

        '        End Try


        '    End Using


        'End Using
        'ddl.Items.Insert(0, New ListItem(defaultText, "0"))
    End Sub

    Public Shared Function convertirfechaatexto(ByVal Fecha As String) As String

        Dim cFecha As String = ""

        'cFecha = Mid(Fecha, 5, 2) & "/" & Mid(Fecha, 7, 2) & "/" & Mid(Fecha, 1, 4)

        cFecha = Mid(Fecha, 7, 4) + Mid(Fecha, 1, 2) + Mid(Fecha, 4, 2)
        Return cFecha

    End Function

    Private Sub CargarUnidadesNegocio()

        Dim dt As New DataTable
        dt = UnidadNegocioLN.getInstance().CantidadNegocios
        DropDownListunegocio.DataSource = dt
        DropDownListunegocio.DataTextField = "NombreSucursal"
        DropDownListunegocio.DataValueField = "IDGimnasio"
        DropDownListunegocio.DataBind()
        DropDownListunegocio.Items.Insert(0, New ListItem("Todos", "0"))

    End Sub

    Private Sub wfventas_Init(sender As Object, e As EventArgs) Handles Me.Init
        CargarUnidadesNegocio()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        If txtFecha.Text.Length > 0 And TxtFechaFin.Text.Length > 0 Then
            If IsDate(txtFecha.Text) And IsDate(TxtFechaFin.Text) Then
                Dim dtVentas As New DataTable
                dtVentas = VentasLN.getInstance.GeneraldeVentas(convertirfechaatexto(Me.txtFecha.Text), convertirfechaatexto(Me.TxtFechaFin.Text), Me.DropDownListunegocio.SelectedValue)

                '            Dim workCol As DataColumn = dtVentas.Columns.Add( _
                '"Total", Type.GetType("System.Double"))
                '            workCol.AllowDBNull = True
                '            workCol.Unique = False

                Me.gvVentas.DataSource = dtVentas
                Me.gvVentas.DataBind()
                ' ClientScript.RegisterStartupScript(Me.GetType(), "Nombre", "SumarColumna(gvVentas, Importe)", True)
                Dim total As Decimal = dtVentas.AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("Total"))
                gvVentas.FooterRow.Cells(6).Text = "Total"
                gvVentas.FooterRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
                gvVentas.FooterRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
                gvVentas.FooterRow.Cells(7).Text = total.ToString("N2")

            End If
        End If

    End Sub

    Private Sub gvVentas_DataBound(sender As Object, e As EventArgs) Handles gvVentas.DataBound
        '' Recupera la el PagerRow...
        'Dim pagerRow As GridViewRow = gvVentas.BottomPagerRow
        '' Recupera los controles DropDownList y label...
        'Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("PageDropDownList"), DropDownList)
        'Dim pageLabel As Label = CType(pagerRow.Cells(0).FindControl("CurrentPageLabel"), Label)
        'If Not pageList Is Nothing Then
        '    ' Se crean los valores del DropDownList tomando el número total de páginas... 
        '    Dim i As Integer
        '    For i = 0 To gvVentas.PageCount - 1
        '        ' Se crea un objeto ListItem para representar la �gina...
        '        Dim pageNumber As Integer = i + 1
        '        Dim item As ListItem = New ListItem(pageNumber.ToString())
        '        If i = gvVentas.PageIndex Then
        '            item.Selected = True
        '        End If
        '        ' Se añade el ListItem a la colección de Items del DropDownList...
        '        pageList.Items.Add(item)
        '    Next i
        'End If
        'If Not pageLabel Is Nothing Then
        '    ' Calcula el nº de �gina actual...
        '    Dim currentPage As Integer = gvVentas.PageIndex + 1
        '    ' Actualiza el Label control con la �gina actual.
        '    pageLabel.Text = "Página " & currentPage.ToString() & " de " & gvVentas.PageCount.ToString()
        'End If
    End Sub

    Protected Sub PageDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Recupera la fila.
        Dim pagerRow As GridViewRow = gvVentas.BottomPagerRow
        ' Recupera el control DropDownList...
        Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("PageDropDownList"), DropDownList)
        ' Se Establece la propiedad PageIndex para visualizar la página seleccionada...

        gvVentas.PageIndex = pageList.SelectedIndex
        'Quita el mensaje de información si lo hubiera...
        'lblInfo.Text = ""
    End Sub

    Private Sub gvVentas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvVentas.PageIndexChanging
        Me.gvVentas.PageIndex = e.NewPageIndex
        Me.gvVentas.DataBind()
    End Sub
End Class