Imports System.Data
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

        Dim Con = New SqlConnection(ConfigurationManager.ConnectionStrings("SQLServer").ConnectionString)
       
        Dim sql = New SqlCommand("select convert(varchar,Fecha,106) 'Fecha',sum(CAST(Pesos as DECIMAL(10,2))) 'Total' from tblFoliosVentas where Fecha >= '" + Format(Date.Today, "yyyyMM") + "01" & "' and Fecha <= '" & Format(Date.Today, "yyyyMMdd") & "' group by Fecha order By Fecha;", Con)

        ' Dim sql = New SqlCommand("SELECT Count(IDCliente) as cnt, IDGImnasio from catClientes where IDCliente>2 and FechaVencimiento >= CONVERT(char(10), DATEADD(day,-5,GetDate()),112) group by IDGImnasio order by IDGimnasio", Con)

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
    <System.Web.Services.WebMethod()> _
    Public Shared Function getChartDataSocios() As List(Of String)
        Dim grantotal As Double = 0.0

        Dim returnData = New List(Of String)()

        Dim Con = New SqlConnection(ConfigurationManager.ConnectionStrings("SQLServer").ConnectionString)

        Dim sql = New SqlCommand("SELECT Count(IDCliente) as cnt, IDGImnasio from catClientes where IDCliente>=2 and FechaVencimiento >= CONVERT(char(10), DATEADD(day,0,GetDate()),112) group by IDGImnasio order by IDGimnasio", Con)

        Dim dataAdapter = New SqlDataAdapter(sql)

        Dim dataset = New DataSet()

        dataAdapter.Fill(dataset)

        If dataset.Tables(0).Rows.Count > 0 Then

            Dim chartLabel = New StringBuilder()
            Dim chartData = New StringBuilder()
            chartLabel.Append("[")
            chartData.Append("[")

            For Each row As DataRow In dataset.Tables(0).Rows

                chartLabel.Append(String.Format("'{0}',", row("IDGimnasio").ToString()))

                chartData.Append(String.Format("{0},", row("cnt").ToString()))

                grantotal = grantotal + CType(row("cnt"), Double)

            Next

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

    End Sub

    Private Sub CargarSociosActivos(ByVal Id As Integer)
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosActivos(Id)


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("Activos")
        If value Is DBNull.Value Then
            Me.LabelSociosActivos.Text = "0.00"
        Else
            Me.LabelSociosActivos.Text = CStr(value)
        End If


    End Sub

    Private Sub CargarSociosNuevos(ByVal Id As Integer)
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosNuevos(Id)


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("Nuevos")

        If value Is DBNull.Value Then

            Me.LabelSociosNuevos.Text = "0.00"

        Else

            Me.LabelSociosNuevos.Text = CStr(value)

        End If
    End Sub


    Private Sub CargarSociosPorVencer(ByVal Id As Integer)
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosPorVencer(Id)


        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("PorVencer")

        If value Is DBNull.Value Then
            Me.LabelPorVencer.Text = "0.00"
        Else
            Me.LabelPorVencer.Text = CStr(value)
        End If
    End Sub

    Private Sub CargarSociosQueRenovaron(ByVal Id As Integer)
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosQueRenovaron(Id)


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
                CargarSociosActivos(0)
                CargarSociosNuevos(0)
                CargarSociosPorVencer(0)
                CargarSociosQueRenovaron(0)
                CargarSociosQueNoRenovaron()
                Me.LabelSalesVentas.Text = "Grafica de Ventas Totales"
                Me.LabelTituloGrafica.Text = "Periodo   Del     " & Format(Date.Today, "yyyy/MM/") + "01 " & "     al     " & Format(Date.Today, "yyyy/MM/dd")

                Me.LabelUsersGrafic.Text = "Grafica de Usaurios por Unidad de Negocio"
              

            End If
        End If

    End Sub

End Class