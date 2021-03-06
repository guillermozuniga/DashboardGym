﻿Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Imports CapaLogicaNegocio

Public Class Acceso
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ButtonIngresar_Click(sender As Object, e As EventArgs) Handles ButtonIngresar.Click
        If String.IsNullOrEmpty(Trim(Me.TextBoxUsuario.Text)) Or String.IsNullOrEmpty(Trim(Me.TextBoxContrasena.Text)) Then
            Dim message As String = "Hay un error en la captura...!!!."

            Dim script As String = "window.onload = function(){ alert('"

            script &= message

            script &= "')};"

            ClientScript.RegisterStartupScript(Me.GetType(), "ErrorMessage", script, True)
        Else
            Try
                Dim isValid As Boolean = Membership.ValidateUser(TextBoxUsuario.Text, TextBoxContrasena.Text)

                If Not isValid Then

                    Dim user As MembershipUser = Membership.GetUser(TextBoxUsuario.Text)

                    If user IsNot Nothing Then
                        'User exists
                        If Not user.IsApproved Then
                            'Account Unapproved

                            lblMessage.Text = "Su Cuanta no a sido Aprovada"
                        ElseIf user.IsLockedOut Then
                            'Account Locked
                            lblMessage.Text = "Su Cuenta a sido Bloqueada"
                        Else
                            'Invalid username or password
                            lblMessage.Text = "Usuario o Contraseña Invalida."
                        End If
                    Else
                        'Invalid username or password
                        lblMessage.Text = "Usuario o Contraseña Invalida."
                    End If

                Else

                    'If chkRememberMe.Checked Then
                    Dim authTicket As FormsAuthenticationTicket = New FormsAuthenticationTicket(TextBoxUsuario.Text, True, (12 * 60))
                    Dim encryptedTicket As String = FormsAuthentication.Encrypt(authTicket)
                    Dim cookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                    cookie.Expires = authTicket.Expiration
                    HttpContext.Current.Response.Cookies.Set(cookie)
                    'Else
                    FormsAuthentication.SetAuthCookie(TextBoxUsuario.Text, False)
                    'End If
                    'valid username or password
                    lblMessage.Text = "The user account was successfully created !!!."

                    Response.Redirect("~/Dashboard.aspx")

                End If
            Catch ex As Exception
                Throw ex
            Finally


            End Try
        End If
    End Sub

    Private Sub Acceso_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        'Dim yo As MembershipUser = Membership.GetUser("Username")
        'If yo.IsLockedOut Then
        '    Response.Write("your account is locked because you entered in 5 times the wrong password")
        'End If
    End Sub
End Class