Imports System.Data.SqlClient

Public Class manGenerarUsuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Not (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Server.Transfer("~/logout.aspx")
            End If

        End If
    End Sub


    Protected Sub Btn_Generar_Tutores_Click()
        Dim status As New MembershipCreateStatus
        Dim newUser As MembershipUser
        Dim mypass As String = String.Empty
        Dim dr As SqlDataReader = Nothing
        Dim cmd As New SqlCommand

        Dim db As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LocalSQLServer").ConnectionString)

        cmd = New SqlCommand("usp_ListarFamilias", db) With {
            .CommandType = CommandType.StoredProcedure,
            .Connection = db
        }

        Try
            cmd.Connection.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())
                newUser = Membership.CreateUser(Trim(dr("Tutores_Padre_UsuarioWEB")), Trim(dr("Tutores_Padre_PasswordWEB")), Trim(dr("Tutores_Padre_UsuarioWEB")), "1", "1", True, status)
                Select Case status
                    Case MembershipCreateStatus.Success
                        If Not Roles.IsUserInRole(dr("Tutores_Padre_UsuarioWEB"), "Tutor") Then
                            Roles.AddUserToRole(dr("Tutores_Padre_UsuarioWEB"), "Tutor")
                        End If
                        Exit Select
                End Select
            End While
        Catch ex As Exception
            cmd.Connection.Close()
            cmd.Connection.Dispose()
        Finally
            cmd.Connection.Close()
            cmd.Connection.Dispose()

        End Try
    End Sub
End Class