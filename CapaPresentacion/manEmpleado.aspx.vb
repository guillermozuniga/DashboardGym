Imports CapaEntidades
Imports CapaLogicaNegocio

Public Class manEmpleado
    Inherits System.Web.UI.Page
    Dim bandnuevo As Boolean = False
    Dim Valor As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Valor = Convert.ToInt32(Request.QueryString("Valor"))
                If Valor > 0 Then
                    Me.HiddenFieldValor.Value = Valor
                    If Not CargarEmpleado(Valor) Then

                        Me.TextNumero.Enabled = False
                        Me.TextNombre.Enabled = True
                        Me.TextNombre.Focus()

                    End If
                Else
                    bandnuevo = True
                End If

            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub
    Private Function CargarEmpleado(ByVal valor As Integer) As Boolean
        Dim objEmpleado As New EmpleadoEnt
        objEmpleado = EmpleadosLN.getInstance.BuscarEmpleado(valor)
        Me.TextNumero.Text = objEmpleado.Empleados_Numero.ToString()
        Me.TextNombre.Text = objEmpleado.Empleados_NombreDePila.ToString()
        Me.TextApellidoPat.Text = objEmpleado.Empleados_NombreApPaterno.ToString()
        Me.TextApellidoMat.Text = objEmpleado.Empleados_NombreApMaterno.ToString()
        Me.TextColonia.Text = objEmpleado.Empleados_Direccion_Colonia.ToString()
        Return False
    End Function
End Class