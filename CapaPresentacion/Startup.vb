Imports System.Data.SqlClient
Imports System.Web.Security


Partial Public Class Startup
    Public Sub Configuration()
        'ConfigureAuth(app)
        CreateRolesandUsers()
    End Sub

    Private Sub CreateRolesandUsers()
        Dim status As New MembershipCreateStatus
        Dim mypass As String = String.Empty

        If Not Roles.RoleExists("Administrator") Then
            Roles.CreateRole("Administrator")

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


        Dim newUser As MembershipUser = Membership.CreateUser("guillermo_zuniga@eimagen.mx", "12Knife", "guillermo_zuniga@eimagen.mx", "1", "1", True, status)

        Select Case status
            Case MembershipCreateStatus.Success
                'lblMessage.Text = "Account Created"
                If Not Roles.IsUserInRole("guillermo_zuniga@eimagen.mx", "Administrador") Then
                    Roles.AddUserToRole("guillermo_zuniga@eimagen.mx", "Administrador")
                End If
                Dim message As String = "Account Created,...!!!." & "guillermo_zuniga@eimagen.mx"

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
