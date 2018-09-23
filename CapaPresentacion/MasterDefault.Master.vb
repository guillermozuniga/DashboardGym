Imports System.Data.SqlClient

Public Class MasterDefault
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then

                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Select Empresa_RazonSocial, Empresa_NombreCorto from SGE_Empresa") With {
                    .CommandType = CommandType.Text
                }
                Dim db As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LocalSQLServer").ConnectionString)
                cmd.Connection = db
                Try
                    cmd.Connection.Open()

                    If CBool(cmd.ExecuteNonQuery) Then
                        Dim dt As New DataTable
                        Dim da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                        Me.LblNombreCorto.Text = dt.Rows(0).Item(0) + " ( " + dt.Rows(0).Item(1) + " )"
                    Else

                    End If

                Catch ex As Exception

                    cmd.Connection.Close()

                Finally

                    cmd.Connection.Close()

                End Try

                'Dim cmd1 As New SqlCommand

                'cmd1 = New SqlCommand("Select * from SGE_VistaNombreEmpleado where UserName = '" & Context.User.Identity.Name & "'")

                'cmd1.CommandType = CommandType.Text

                'cmd1.Connection = db


                'Try
                '    cmd1.Connection.Open()

                '    If CBool(cmd1.ExecuteNonQuery) Then
                '        Dim dt1 As New DataTable
                '        Dim da As New SqlDataAdapter(cmd1)
                '        da.Fill(dt1)
                '        If dt1.Rows.Count > 0 Then
                '            Me.LblUser.Text = Mid(dt1.Rows(0).Item("Nombre").ToString, 1, 25)

                '            Me.LblRol.Text = " ( " + dt1.Rows(0).Item("RoleName").ToString + " )"
                '        Else
                '            'Alerta de Usuario no asociado a un empleado

                '            Response.Redirect("~/logout.aspx")

                '        End If

                '    Else

                '    End If

                'Catch ex As Exception

                'Finally

                '    cmd1.Connection.Close()

                'End Try

                'Me.lblAzul.Text = Texto

                If Roles.IsUserInRole("Docente") Then
                    ' /*Menu Principal*/
                    ' Me.ulDocente.Visible = True


                End If

                If Roles.IsUserInRole("SuperAdministrador") Then
                    ' /*Menu Principal*/
                    ' Me.uladmin.Visible = True
                    ' Me.ulDocente.Visible = True
                    ' Me.ulSistema.Visible = True

                End If

                If Roles.IsUserInRole("Administrador") Then
                    ' /*Menu Principal*/
                End If

                If Roles.IsUserInRole("AuxAdministrador") Then
                    ' /*Menu Principal*/
                    '  Me.ulEscolar.Visible = True
                End If
            End If

        Else

        End If


    End Sub

End Class