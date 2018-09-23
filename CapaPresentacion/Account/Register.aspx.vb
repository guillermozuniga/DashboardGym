Imports System.Data.SqlClient
Imports System.Web.Security
Imports CapaLogicaNegocio
Imports System.Net
Imports System.Net.Mail

Public Class Register
    Inherits System.Web.UI.Page
    Private Sub SendActivationEmail(userId As Integer)

        Dim constr As String = ConfigurationManager.ConnectionStrings("SQLServer").ConnectionString

        Dim activationCode As String = Guid.NewGuid().ToString()

        Using con As New SqlConnection(constr)

            Using cmd As New SqlCommand("INSERT INTO AccesoActivation VALUES(@IdAcceso, @ActivationCode)")

                Using sda As New SqlDataAdapter()

                    cmd.CommandType = CommandType.Text

                    cmd.Parameters.AddWithValue("@IdAcceso", userId)

                    cmd.Parameters.AddWithValue("@ActivationCode", activationCode)

                    cmd.Connection = con

                    con.Open()

                    cmd.ExecuteNonQuery()

                    con.Close()

                End Using

            End Using

        End Using

        Using mm As New MailMessage("notificaciones@eimagen.mx", "guillermo_zuniga@eimagen.mx")

            mm.Subject = "Account Activation"

            Dim body As String = "Hello " + Me.TextBoxFullName.Text.Trim() + ","

            body += "<br /><br />Please click the following link to activate your account"

            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Registro.aspx", Convert.ToString("Activation.aspx?ActivationCode=") & activationCode) + "'> Click here to activate your account.</a>"

            body += "<br /><br />Thanks"

            mm.Body = body

            mm.IsBodyHtml = True

            Dim smtp As New SmtpClient()

            smtp.Host = "mail.eimagen.mx"

            smtp.EnableSsl = False

            Dim NetworkCred As New NetworkCredential("notificaciones@eimagen.mx", "12@Kn1fe.")

            smtp.UseDefaultCredentials = True

            smtp.Credentials = NetworkCred

            smtp.Port = 587

            smtp.Send(mm)

        End Using

    End Sub

    Public Function GetErrorMessage(status As MembershipCreateStatus) As String

        Select Case status
            Case MembershipCreateStatus.DuplicateUserName
                Return "Username already exists. Please enter a different user name."

            Case MembershipCreateStatus.DuplicateEmail
                Return "A username for that e-mail address already exists. Please enter a different e-mail address."

            Case MembershipCreateStatus.InvalidPassword
                Return "The password provided is invalid. Please enter a valid password value."

            Case MembershipCreateStatus.InvalidEmail
                Return "The e-mail address provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.InvalidAnswer
                Return "The password retrieval answer provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.InvalidQuestion
                Return "The password retrieval question provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.InvalidUserName
                Return "The user name provided is invalid. Please check the value and try again."

            Case MembershipCreateStatus.ProviderError
                Return "The authentication provider Returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."

            Case MembershipCreateStatus.UserRejected
                Return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."

            Case Else
                Return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."
        End Select
    End Function

    Private Function validar() As Boolean
        Dim bandera As Boolean = True
        If String.IsNullOrEmpty(Trim(TextBoxFullName.Text)) Then
            bandera = False
        ElseIf String.IsNullOrEmpty(Trim(TextBoxEmail.Text)) Then
            bandera = False
        ElseIf String.IsNullOrEmpty(Trim(TextBoxContrasena.Text)) Then
            bandera = False
        ElseIf String.IsNullOrEmpty(Trim(TextBoxConfirmacion.Text)) Then
            bandera = False

        End If

        If Trim(TextBoxContrasena.Text) <> Trim(TextBoxConfirmacion.Text) Then
            bandera = False

        End If
        Return bandera

    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub RegisterUser(sender As Object, e As EventArgs) Handles ButtonRegistrar.Click
        If validar() Then
            Dim message As String = String.Empty

            Try
                Dim newUser As MembershipUser = Membership.CreateUser(TextBoxEmail.Text, TextBoxContrasena.Text, TextBoxEmail.Text)

                'SendActivationEmail(newUser.UserName)
                message = "Registration successful. Activation email has been sent."

                ClientScript.RegisterStartupScript([GetType](), "alert", (Convert.ToString("alert('") & message) + "');", True)
                If Not Roles.RoleExists("Administrador") Then
                    Roles.CreateRole("Administrador")
                    Roles.CreateRole("Manager")
                    Roles.CreateRole("Tutor")
                    Roles.CreateRole("AuxAdmon")
                    Roles.CreateRole("Docente")
                    Roles.CreateRole("Estudiante")
                End If

                Roles.AddUserToRole(TextBoxEmail.Text, "Administrador")

                Response.Redirect("~/login.aspx")

            Catch ex As MembershipCreateUserException
                Msg.Text = GetErrorMessage(ex.StatusCode)
            Catch ex As HttpException
                Msg.Text = ex.Message
            End Try


            'Dim userId As Integer = UsuarioLN.getInstance.InsertarUsuario(Me.TextBoxEmail.Text.Trim, Me.TextBoxContrasena.Text.Trim, Me.TextBoxEmail.Text.Trim)

            'Select Case userId

            '    Case -1

            '        message = "Username already exists.\nPlease choose a different username."

            '        Exit Select

            '    Case -2

            '        message = "Supplied email address has already been used."

            '        Exit Select

            '    Case Else

            '        message = "Registration successful. Activation email has been sent."

            '        SendActivationEmail(userId)
            '        Response.Redirect("~/Login.aspx")
            '        Exit Select

            'End Select

            ClientScript.RegisterStartupScript([GetType](), "alert", (Convert.ToString("alert('") & message) + "');", True)
        Else
            Dim message As String = "Hay un error en la captura...!!!."

            Dim script As String = "window.onload = function(){ alert('"

            script &= message

            script &= "')};"

            ClientScript.RegisterStartupScript(Me.GetType(), "ErrorMessage", script, True)
        End If
    End Sub

End Class