Imports System.Data.SqlClient
Imports System.Web.Security
Imports CapaEntidades
Imports CapaLogicaNegocio
Imports System.Net
Imports System.Net.Mail

Public Class Dashboard
    Inherits System.Web.UI.Page

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

                Me.Label1.Text = " Movimiento de Clientes: 1 -  " & MonthName(Month(Date.Now)) & "    al    " & Day(Date.Now) & "  -  " & MonthName(Month(Date.Now))

                Me.Label2.Text = " Movimiento en Ventas: 1 -  " & MonthName(Month(Date.Now)) & "    al    " & Day(Date.Now) & "  -  " & MonthName(Month(Date.Now))
            End If
        End If

    End Sub

End Class