Imports System.Data.SqlClient

Public Class MasterDefault
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            DeshabilitarMenus()

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then

                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Select Empresa_RazonSocial, Empresa_NombreCorto from [eimagenn_sge_admin].[SGE_Empresa]") With {
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
                        Dim nombre As String = Nothing
                        nombre = dt.Rows(0).Item(0).ToString

                        Me.LblNombreCorto.Text = nombre.Substring(0, 18) + " ( " + dt.Rows(0).Item(1) + " )"
                    End If

                Catch ex As Exception

                    cmd.Connection.Close()

                Finally

                    cmd.Connection.Close()

                End Try
                Me.LblRol.Text = Context.User.Identity.Name.Substring(0, 15)

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

                If Roles.IsUserInRole("Administrador") Then
                    ' /*Menu Principal*/
                    Me.ModuloAdministracion.Visible = True
                    Me.ModuloColegiaturas.Visible = True
                    Me.ModuloEscolares.Visible = True
                    Me.ModuloRH.Visible = True
                    Me.ModuloSeguridad.Visible = True
                    Me.ModuloConfiguracion.Visible = True
                    Me.ModuloEspeciales.Visible = True
                    ModEvaluaciones.Visible = True

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
                End If

                If Roles.IsUserInRole("AuxAdm") Then
                    ' /*Menu Principal*/
                    Me.ModuloAdministracion.Visible = True
                    Me.ModuloColegiaturas.Visible = True
                    Me.ModuloEscolares.Visible = True
                    Me.ModuloRH.Visible = True
                    Me.ModuloConfiguracion.Visible = True
                    ModEvaluaciones.Visible = True
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
                End If

                If Roles.IsUserInRole("Tutor") Then
                    ' /*Menu Principal*/

                    Me.ModuloColegiaturas.Visible = True
                    Me.ModuloEscolares.Visible = True
                    ModEvaluaciones.Visible = True
                    Dim cmd1 As New SqlCommand

                    cmd1 = New SqlCommand("Select Tutores_Padre_UsuarioWEB, Nombre from v_GetAllFamilias where Tutores_Padre_UsuarioWEB = '" & Context.User.Identity.Name & "'") With {
                        .CommandType = CommandType.Text,
                        .Connection = db
                    }

                    Try
                        cmd1.Connection.Open()
                        If CBool(cmd1.ExecuteNonQuery) Then
                            Dim dt1 As New DataTable
                            Dim da As New SqlDataAdapter(cmd1)
                            da.Fill(dt1)
                            If dt1.Rows.Count > 0 Then
                                Me.HiddenFieldCorreoTutor.Value = Trim(dt1.Rows(0).Item("Tutores_Padre_UsuarioWEB").ToString())
                                Me.LblRol.Text = Mid(dt1.Rows(0).Item("Nombre").ToString, 1, 10)

                                'Me.LblRol.Text += " ( " + Context.User.Identity.Name + " )"
                            Else
                                'Alerta de Usuario no asociado a un empleado
                                Response.Redirect("~/logout.aspx")
                            End If

                        Else

                        End If

                    Catch ex As Exception
                        Throw ex

                    Finally

                        cmd1.Connection.Close()

                    End Try

                End If

                If Roles.IsUserInRole("Manager") Then
                    ' /*Menu Principal*/
                    Me.ModuloAdministracion.Visible = True
                    Me.ModuloColegiaturas.Visible = True
                    Me.ModuloEscolares.Visible = True
                    Me.ModuloEspeciales.Visible = True
                    Me.ModuloRH.Visible = True
                    Me.ModuloSeguridad.Visible = True
                    Me.ModuloConfiguracion.Visible = True
                    ModEvaluaciones.Visible = True
                End If

                If Roles.IsUserInRole("Docente") Then
                    ' /*Menu Principal*/

                    Me.ModuloColegiaturas.Visible = True
                    Me.ModuloEscolares.Visible = True
                    Me.ModuloRH.Visible = True

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
                End If

            End If

        End If


    End Sub


    Private Sub DeshabilitarMenus()
        Me.ModuloAdministracion.Visible = False
        Me.ModuloColegiaturas.Visible = False
        Me.ModuloEscolares.Visible = False
        Me.ModuloEspeciales.Visible = False
        Me.ModuloRH.Visible = False
        Me.ModuloSeguridad.Visible = False
        Me.ModuloConfiguracion.Visible = False

    End Sub
End Class