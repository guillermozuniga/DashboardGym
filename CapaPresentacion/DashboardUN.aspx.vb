Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports CapaLogicaNegocio
Imports System.Net
Imports System.Net.Mail
Imports System.Configuration

Public Class DashboardUN
    Inherits System.Web.UI.Page
    <System.Web.Services.WebMethod()> _
    Public Shared Function getChartDataUN() As List(Of String)
        Dim grantotal As Double = 0.0

        Dim returnData = New List(Of String)()

        Dim Con = New SqlConnection(ConfigurationManager.ConnectionStrings("SQLServer").ConnectionString)

        Dim sql = New SqlCommand("select convert(varchar,Fecha,106) 'Fecha',sum(CAST(Pesos as DECIMAL(10,2))) 'Total' from tblFoliosVentas where Fecha >= '" + Format(Date.Today, "yyyyMM") + "01" & "' and Fecha <= '" & Format(Date.Today, "yyyyMMdd") & "' and IDGimnasio = 1 group by Fecha order By Fecha;", Con)

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

    Function PrimerDiaDelMes(ByVal dtmFecha As Date) As Date
        PrimerDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha), 1)
    End Function


    Function UltimoDiaDelMes(ByVal dtmFecha As Date) As Date
        UltimoDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha) + 1, 0)
    End Function

    Private Sub CargarSociosActivos(ByVal id As Integer)
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosActivos(id)

        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("Activos")
        If value Is DBNull.Value Then
            Me.LabelSociosActivos.Text = "0.00"
        Else
            Me.LabelSociosActivos.Text = CStr(value)
        End If

    End Sub

    Private Sub CargarSociosNuevos(ByVal ID As Integer)
        Dim dt As DataTable

        dt = SociosLN.getInstance().CantidadSociosNuevos(ID)


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


    'Private Sub CargarSociosQueNoRenovaron()
    '    Dim dt As DataTable

    '    dt = SociosLN.getInstance().CantidadSociosQueNORenovaron


    '    Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

    '    Dim value As Object

    '    value = row.Item("NoRenovados")

    '    If value Is DBNull.Value Then
    '        Me.LabelNoRenovados.Text = "0.00"
    '    Else
    '        Me.LabelNoRenovados.Text = CStr(value)
    '    End If
    'End Sub


    'Private Sub CargarSociosVencidosconasistencia()

    '    Dim dt As DataTable

    '    dt = SociosLN.getInstance().SociosVencidosconasistencia


    '    Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

    '    Dim value As Object

    '    value = row.Item("NoRenovados")

    '    If value Is DBNull.Value Then
    '        Me.LabelNoRenovados.Text = "0.00"
    '    Else
    '        Me.LabelNoRenovados.Text = CStr(value)
    '    End If
    'End Sub


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


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            Me.LabelTituloGrafica.Text = "Del     " & Format(Date.Today, "yyyy/MM/") + "01 " & "     al     " & Format(Date.Today, "yyyy/MM/dd")

            LabelTitulo.Text = "Detalles de " & " ' " & HttpUtility.UrlDecode(Request.QueryString("Name")) & " '"
            CargarSociosActivos(HttpUtility.UrlDecode(Request.QueryString("Id")))
            CargarSociosNuevos(HttpUtility.UrlDecode(Request.QueryString("Id")))
            CargarSociosPorVencer(HttpUtility.UrlDecode(Request.QueryString("Id")))
            CargarSociosQueRenovaron(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Label1.Text = HttpUtility.UrlDecode(Request.QueryString("Id"))
        End If
    End Sub

End Class