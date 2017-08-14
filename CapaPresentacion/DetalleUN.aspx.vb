Imports System.Data.SqlClient
Imports System.Web.Security
Imports CapaEntidades
Imports CapaLogicaNegocio

Public Class DetalleUN
    Inherits System.Web.UI.Page


#Region "Rutinas"
    Private Sub GetAllUnidadesNegocio()
        Dim dt As DataTable

        dt = UnidadNegocioLN.getInstance().CantidadNegocios

        If dt.Rows.Count > 0 Then
            Me.dlUnidadesNegocio.DataSource = dt
            Me.dlUnidadesNegocio.DataBind()
        End If

    End Sub

    Public Function ProcessMyDataItem(myValue As Object) As String
        Dim valor As String
        If myValue Is Nothing Then
            Return " "
        Else

            valor = myValue.ToString
        End If
        Return valor.Substring(0, 15)

    End Function


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

                GetAllUnidadesNegocio()
            End If
        End If

    End Sub

End Class