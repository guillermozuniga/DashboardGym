﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports CapaLogicaNegocio
Imports System.Net
Imports System.Net.Mail
Imports System.Configuration


Public Class Dashboard

    Inherits System.Web.UI.Page


    <System.Web.Services.WebMethod()> _
    Public Shared Function getChartData() As List(Of String)
        Dim grantotal As Double = 0.0

        Dim returnData = New List(Of String)()

        'Dim Con = New SqlConnection("Data Source=SQL.NEGOX.COM;Initial Catalog=eimagenn_gym_0001;Persist Security Info=True;User ID=eimagenn_usergym0001;Password=12@Kn1fe.")
        Dim Con = New SqlConnection(ConfigurationManager.ConnectionStrings("SQLServer").ConnectionString)

        ' Dim sql = New SqlCommand("select convert(varchar,Fecha,106) 'Fecha',sum(CAST(Pesos as DECIMAL(10,2))) 'Total' from tblFoliosVentas where Fecha >= '" & Now.Year & Now.Month.ToString.PadLeft(2, "0") & "01" & "' and Fecha < ' " & Format(Date.Today, "yyyyMMdd") & "' group by Fecha order By Fecha;", Con)
        Dim sql = New SqlCommand("select convert(varchar,Fecha,106) 'Fecha',sum(CAST(Pesos as DECIMAL(10,2))) 'Total' from tblFoliosVentas where Fecha >= '" + Format(Date.Today, "yyyyMM") + "01" & "' and Fecha <= '" & Format(Date.Today, "yyyyMMdd") & "' group by Fecha order By Fecha;", Con)
        'Dim sql = New SqlCommand("select convert(varchar,Fecha,106) 'Fecha',sum(CAST(Pesos as DECIMAL(10,2))) 'Total' from tblFoliosVentas group by Fecha order By Fecha;", Con)
        Dim dataAdapter = New SqlDataAdapter(sql)
        Dim dataset = New DataSet()
        dataAdapter.Fill(dataset)
        If dataset.Tables(0).Rows.Count > 0 Then

            Dim chartLabel = New StringBuilder()
            Dim chartData = New StringBuilder()
            chartLabel.Append("[")
            chartData.Append("[")

            For Each row As DataRow In dataset.Tables(0).Rows

                chartLabel.Append(String.Format("'{0}',", row("Fecha").ToString()))

                chartData.Append(String.Format("{0},", row("Total").ToString()))

                grantotal = grantotal + CType(row("Total"), Double)

            Next
            'Dim page As Page = DirectCast(HttpContext.Current.Handler, Page)
            'Dim LabelVenta As Label = DirectCast(page.FindControl("LabelVentas"), Label)
            'LabelVenta.Text = grantotal

            chartData.Length -= 1
            'For removing ','  
            chartData.Append("]")
            chartLabel.Length -= 1
            'For removing ',' 
            chartLabel.Append("]")

            returnData.Add(chartLabel.ToString())
            returnData.Add(chartData.ToString())

        End If

        Return returnData
    End Function

#Region "Rutinas"

    Function PrimerDiaDelMes(ByVal dtmFecha As Date) As Date
        PrimerDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha), 1)
    End Function


    Function UltimoDiaDelMes(ByVal dtmFecha As Date) As Date
        UltimoDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha) + 1, 0)
    End Function


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

    Private Sub CargarSociosQueRenovaron()
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosQueRenovaron


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("Renovados")

        If value Is DBNull.Value Then
            Me.LabelRenovados.Text = "0.00"
        Else
            Me.LabelRenovados.Text = CStr(value)
        End If
    End Sub


    Private Sub CargarSociosQueNoRenovaron()
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosQueNORenovaron


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("NoRenovados")

        If value Is DBNull.Value Then
            Me.LabelNoRenovados.Text = "0.00"
        Else
            Me.LabelNoRenovados.Text = CStr(value)
        End If
    End Sub


    Private Sub CargarSociosVencidosconasistencia()

        Dim dt As DataTable

        dt = SociosLN.getInstance().SociosVencidosconasistencia


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("NoRenovados")

        If value Is DBNull.Value Then
            Me.LabelNoRenovados.Text = "0.00"
        Else
            Me.LabelNoRenovados.Text = CStr(value)
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
                CargarSociosPorVencer()
                CargarSociosQueRenovaron()
                CargarSociosQueNoRenovaron()
                'CargarSociosVencidosconasistencia()

                'CargarVentas()
                Me.LabelSalesVentas.Text = "Grafica de Ventas"
                Me.LabelTituloGrafica.Text = "Del     " & Format(Date.Today, "yyyy/MM/") + "01 " & "     al     " & Format(Date.Today, "yyyy/MM/dd")

                Me.LabelUsersGrafic.Text = "Grafica de Usuarios"
                ' Me.Label1.Text = " Movimiento de Ventas: 1 -  " & MonthName(Month(Date.Now)) & "    al    " & Day(Date.Now) & "  -  " & MonthName(Month(Date.Now))

                'Me.Label2.Text = " Movimiento en Clientes: 1 -  " & MonthName(Month(Date.Now)) & "    al    " & Day(Date.Now) & "  -  " & MonthName(Month(Date.Now))


            End If
        End If

    End Sub

End Class