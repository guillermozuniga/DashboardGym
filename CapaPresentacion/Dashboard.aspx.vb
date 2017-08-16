Imports System.Data.SqlClient
Imports System.Web.Security
Imports CapaEntidades
Imports CapaLogicaNegocio
Imports System.Net
Imports System.Net.Mail
Imports System.Data
Imports System.Web.Services
Imports System.Configuration

Public Class Dashboard
    Inherits System.Web.UI.Page

#Region "WebMethod"
    <WebMethod()> _
    Public Shared Function getChartData() As List(Of String)
        Dim returnData = New List(Of String)()
        Dim Con = New SqlConnection("Server=databaseserver;Database=chart;Trusted_Connection=True;")
        Dim sql = New SqlCommand("select convert(varchar,date,106) 'Date',sum(quantity_sold) 'Qty' from tblProduct group by date;", Con)
        Dim dataAdapter = New SqlDataAdapter(sql)
        Dim dataset = New DataSet()
        dataAdapter.Fill(dataset)


        Dim chartLabel = New StringBuilder()
        Dim chartData = New StringBuilder()
        chartLabel.Append("[")
        chartData.Append("[")

        For Each row As DataRow In dataset.Tables(0).Rows

            chartLabel.Append(String.Format("'{0}',", row("Date").ToString()))

            chartData.Append(String.Format("{0},", row("Qty").ToString()))
        Next

        chartData.Length -= 1
        'For removing ','  
        chartData.Append("]")
        chartLabel.Length -= 1
        'For removing ',' 
        chartLabel.Append("]")

        returnData.Add(chartLabel.ToString())
        returnData.Add(chartData.ToString())
        Return returnData
    End Function



#End Region
#Region "Rutinas"

    Private Sub CargarUnidadesNegocio()
        Dim dt As DataTable

        dt = UnidadNegocioLN.getInstance().CantidadNegocios

        If dt.Rows.Count > 0 Then

            Me.LabelUnidadNegocio.Text = dt.Rows.Count

        Else

            Me.LabelUnidadNegocio.Text = "0.00"

        End If


        'Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        'Dim value As Object

        'value = row.Item("TotalDonativo")
        'If value Is DBNull.Value Then
        '    Me.LabelUnidadNegocio.Text = "0.00"
        'Else
        '    Me.LabelUnidadNegocio.Text = CStr(value)
        'End If



    End Sub

    Private Sub CargarSociosActivos()
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosActivos


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("Activos")
        If value Is DBNull.Value Then
            Me.LabelSociosActivos.Text = "0.00"
        Else
            Me.LabelSociosActivos.Text = CStr(value)
        End If

       
    End Sub

    Private Sub CargarSociosNuevos()
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosNuevos


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("Nuevos")
        If value Is DBNull.Value Then
            Me.LabelSociosNuevos.Text = "0.00"
        Else
            Me.LabelSociosNuevos.Text = CStr(value)
        End If
    End Sub
    Private Sub CargarSociosPorVencer()
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosPorVencer


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("PorVencer")
        If value Is DBNull.Value Then
            Me.LabelPorVencer.Text = "0.00"
        Else
            Me.LabelPorVencer.Text = CStr(value)
        End If
    End Sub


    Private Sub CargarVentas()
        Dim dt As DataTable

        dt = VentasLN.getInstance().GetVentasTotales


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("VentaTotal")
        If value Is DBNull.Value Then
            Me.LabelVentas.Text = "0.00"
        Else
            Me.LabelVentas.Text = String.Format("{0:0,0.00}", CStr(value))
        End If
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '  Obtengo la página desde la que he llegado aquí

        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        HttpContext.Current.Response.Cache.SetNoServerCaching()
        HttpContext.Current.Response.Cache.SetNoStore()
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
        Dim uriAnterior As Uri = Request.UrlReferrer
        If Not uriAnterior Is Nothing Then
            Dim sRuta As String = uriAnterior.AbsolutePath
            HttpResponse.RemoveOutputCacheItem(sRuta)
        End If

        If Not (Page.IsPostBack) Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then

                CargarUnidadesNegocio()
                CargarSociosActivos()
                CargarSociosNuevos()
                CargarVentas()
                CargarSociosPorVencer()
                ' Me.Label1.Text = " Movimiento de Ventas: 1 -  " & MonthName(Month(Date.Now)) & "    al    " & Day(Date.Now) & "  -  " & MonthName(Month(Date.Now))

                'Me.Label2.Text = " Movimiento en Clientes: 1 -  " & MonthName(Month(Date.Now)) & "    al    " & Day(Date.Now) & "  -  " & MonthName(Month(Date.Now))
                
                
            End If
        End If

    End Sub

End Class