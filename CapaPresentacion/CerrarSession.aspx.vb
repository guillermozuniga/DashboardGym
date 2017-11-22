
Imports System.Web.Security

Public Class CerrarSession
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormsAuthentication.SignOut()
        'Roles.DeleteCookie()
        Session.Clear()
        Session.RemoveAll()
        Session.Abandon()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

End Class