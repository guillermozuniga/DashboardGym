Imports CapaEntidades
Imports CapaLogicaNegocio

Public Class ManBancos
    Inherits System.Web.UI.Page
    Dim bandnuevo As Boolean = False
    Dim Valor As Integer

#Region "Rutinas"
    Private Function CargarBancos(ByVal valor As Integer) As Boolean
        Dim objBanco As New BancosEnt
        objBanco = BancosLN.getInstance().BuscarBanco(valor)
        Me.TextBoxNombre.Text = objBanco.Banco_Nombre.ToString()
        Me.TextBoxClave.Text = objBanco.Banco_ClaveOficial.ToString()

        Return False
    End Function

    Private Function GetValues()
        Dim objBanco As BancosEnt = New BancosEnt With {
            .Banco_Nombre = Me.TextBoxNombre.Text.ToUpper,
            .Banco_ClaveOficial = Me.TextBoxClave.Text.ToUpper,
            .Bancos_BancoID = HiddenFieldValor.Value
        }

        Return objBanco

    End Function
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Valor = Convert.ToInt32(Request.QueryString("Valor"))
                If Valor > 0 Then
                    Me.HiddenFieldValor.Value = Valor
                    If Not CargarBancos(Valor) Then
                        Me.TextBoxNombre.Focus()
                    End If
                Else
                    HiddenFieldValor.Value = 0
                    Me.TextBoxNombre.Focus()
                End If
            Else
                Response.Redirect("~/logout.aspx")
            End If
        End If
    End Sub

    Protected Sub Btn_Guardar_Click()
        If Not String.IsNullOrEmpty(Me.TextBoxNombre.Text) And Not String.IsNullOrEmpty(Me.TextBoxClave.Text) Then
            Dim respuesta As Boolean

            Dim objBanco As BancosEnt = GetValues()

            If HiddenFieldValor.Value = 0 Then
                respuesta = BancosLN.getInstance().RegistrarBanco(objBanco)
            Else
                respuesta = BancosLN.getInstance().ModificarBanco(objBanco)
            End If

            If respuesta Then
                'Response.Write("<script>alert(' Insercion Correcta.')</script>")
                ClsFuniones.BootstrapAlert(lblMsg, "Acualización realizada con exito", ClsFuniones.BootstrapAlertType.Success, True)
            Else
                ' Response.Write("<script>alert(' Insercion Incorrecta.')</script>")
                ClsFuniones.BootstrapAlert(lblMsg, "Upps no se pudo realizar la actualización", ClsFuniones.BootstrapAlertType.Warning, True)
            End If
        Else
            Me.TextBoxNombre.Focus()
        End If
    End Sub

    Protected Sub Btn_Regresar_Click()
        Response.Redirect("~/ListBancos.aspx")
    End Sub
End Class