Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            FormsAuthentication.SignOut()
            Roles.DeleteCookie()
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Cache.SetNoStore()
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
            HttpContext.Current.Response.Cache.SetNoServerCaching()
            HttpContext.Current.Response.Cache.SetNoStore()
            Session.Contents.RemoveAll()
            Session.Abandon()
            Session.Clear()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Cookies.Add(New HttpCookie("ASP.NET_SessionId", ""))

            'Response.Redirect("~/Account/acceso.aspx?ReturnPath=" + Server.UrlEncode(Request.Url.AbsoluteUri))
            'Response.Redirect("~/Default.aspx")
        Catch ex As Exception
            Response.Redirect("~/error_pages/oopss.aspx?Injection=" & ex.Message)
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class