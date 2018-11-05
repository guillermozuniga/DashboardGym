Imports System.Web.SessionState
Imports System.Security.Principal

Imports System.Web.Security

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started

        'ConfigureAuth(app)
        CreateRolesandUsers()

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
        ' Fires upon attempting to authenticate the use
        If Not (HttpContext.Current.User Is Nothing) Then
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                If TypeOf HttpContext.Current.User.Identity Is FormsIdentity Then
                    Dim fi As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
                    Dim fat As FormsAuthenticationTicket = fi.Ticket

                    Dim astrRoles As String() = fat.UserData.Split("|"c)
                    HttpContext.Current.User = New GenericPrincipal(fi, astrRoles)
                End If
            End If
        End If
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
        Server.Transfer("/error_pages/FileNotFound.aspx")
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub
    Private Sub CreateRolesandUsers()

        Dim status As New MembershipCreateStatus

        Dim mypass As String = String.Empty
        Try
            If Not Roles.RoleExists("Administrador") Then
                Roles.CreateRole("Administrador")

            End If
            If Not Roles.RoleExists("Manager") Then
                Roles.CreateRole("Manager")

            End If
            If Not Roles.RoleExists("Docente") Then
                Roles.CreateRole("Docente")

            End If
            If Not Roles.RoleExists("Tutor") Then
                Roles.CreateRole("Tutor")

            End If
            If Not Roles.RoleExists("AuxAdmin") Then
                Roles.CreateRole("AuxAdmin")

            End If
            If Not Roles.RoleExists("Alumno") Then
                Roles.CreateRole("Alumno")

            End If

        Catch ex As Exception
            Throw ex

        End Try



        Dim newUser As MembershipUser = Membership.CreateUser("guillermo_zuniga@eimagen.mx", "12Knife1.", "guillermo_zuniga@eimagen.mx", "1", "1", True, status)

        Select Case status
            Case MembershipCreateStatus.Success
                'lblMessage.Text = "Account Created"
                If Not Roles.IsUserInRole("guillermo_zuniga@eimagen.mx", "Manager") Then
                    Roles.AddUserToRole("guillermo_zuniga@eimagen.mx", "Manager")
                End If
                Dim message As String = "Account Created,...!!!." & "guillermo_zuniga@eimagen.mx"

                Dim script As String = "window.onload = function(){ alert('"

                script &= message

                script &= "')};"

                '  ClientScriptManager..RegisterStartupScript(Me.GetType(), "ErrorMessage", script, True)
                Exit Select
        End Select

        newUser = Membership.CreateUser("jorge.madrigal@eimagen.mx", "12Knife", "jorge.madrigal@eimagen.mx", "1", "1", True, status)

        Select Case status
            Case MembershipCreateStatus.Success
                'lblMessage.Text = "Account Created"
                If Not Roles.IsUserInRole("jorge.madrigal@eimagen.mx", "Manager") Then
                    Roles.AddUserToRole("jorge.madrigal@eimagen.mx", "Manager")
                End If
                Dim message As String = "Account Created,...!!!." & "jorge.madrigal@eimagen.mx"

                Dim script As String = "window.onload = function(){ alert('"

                script &= message

                script &= "')};"



                'ClientScriptManager.RegisterStartupScript(Me.GetType(), "ErrorMessage", script, True)
                Exit Select
        End Select



        '/// proceso de alta de usuario al acceso del sistema
        'Dim context As ApplicationDbContext = New ApplicationDbContext()
        'Dim roleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(context))
        'Dim UserManager = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(context))

        '    If Not roleManager.RoleExists("Administrador") Then
        '        Dim role = New Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
        '        role.Name = "Administrador"
        '        roleManager.Create(role)
        '        Dim user = New ApplicationUser()
        '        user.UserName = "Memo"
        '        user.Email = "guillermo_zuniga@eimagen.mx"
        '        Dim userPWD As String = "12Knife1."
        '        Dim chkUser = UserManager.Create(user, userPWD)

        '        If chkUser.Succeeded Then
        '            Dim result1 = UserManager.AddToRole(user.Id, "Administrador")
        '        End If
        '    End If

        '    If Not roleManager.RoleExists("Manager") Then
        '        Dim role = New Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
        '        role.Name = "Manager"
        '        roleManager.Create(role)
        '    End If

        '    If Not roleManager.RoleExists("Tutor") Then
        '        Dim role = New Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
        '        role.Name = "Tutor"
        '        roleManager.Create(role)
        '    End If

        '    If Not roleManager.RoleExists("Docente") Then
        '        Dim role = New Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
        '        role.Name = "Docente"
        '        roleManager.Create(role)
        '    End If

        '    If Not roleManager.RoleExists("Alumno") Then
        '        Dim role = New Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
        '        role.Name = "Alumno"
        '        roleManager.Create(role)
        '    End If

        '    If Not roleManager.RoleExists("AuxAdmon") Then
        '        Dim role = New Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
        '        role.Name = "AuxAdmon"
        '        roleManager.Create(role)
        '    End If
    End Sub
End Class