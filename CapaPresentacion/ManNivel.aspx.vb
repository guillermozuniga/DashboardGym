Imports CapaEntidades
Imports CapaLogicaNegocio
Public Class ManNivel
    Inherits System.Web.UI.Page
    Dim bandnuevo As Boolean = False
    Dim Valor As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Valor = Convert.ToInt32(Request.QueryString("Valor"))
                If Valor > 0 Then
                    Me.HiddenFieldValor.Value = Valor
                    If Not CargarSecciones(Valor) Then

                        Me.TextBoxNombre.Focus()
                    End If
                Else
                    BindBancosToList("Select * from [eimagenn_sge_admin].[v_GetAllBancos]")
                    HiddenFieldValor.Value = 0
                    Me.TextBoxNombre.Focus()
                End If
            Else
                Response.Redirect("~/logout.aspx")
            End If
        End If
    End Sub

    Private Function CargarSecciones(valor As Integer) As Boolean
        BindBancosToList("Select * from [eimagenn_sge_admin].[v_GetAllBancos]")
        Throw New NotImplementedException()
    End Function

    Private Sub BindBancosToList(ByVal _Sentencia As String)
        If Not String.IsNullOrEmpty(_Sentencia) Then
            Dim Lista As List(Of BancosEnt) = Nothing
            Try
                Lista = BancosLN.getInstance.ListarBancos(_Sentencia)
                Me.DropDownListBancos.DataSource = Lista
                Me.DropDownListBancos.DataTextField = "Banco_Nombre"
                Me.DropDownListBancos.DataValueField = "Bancos_BancoID"
                Me.DropDownListBancos.DataBind()

            Catch ex As Exception
                Lista = Nothing
                Throw ex
            End Try
        Else
            Dim Lista As List(Of BancosEnt) = Nothing
            Try
                Lista = BancosLN.getInstance.ListarBancos(_Sentencia)
                Me.DropDownListBancos.DataSource = Lista
                Me.DropDownListBancos.DataTextField = "Banco_Nombre"
                Me.DropDownListBancos.DataValueField = "Bancos_BancoID"
                Me.DropDownListBancos.DataBind()

            Catch ex As Exception
                Lista = Nothing
                Throw ex
            End Try
        End If

    End Sub
    Protected Sub Btn_Regresar_Click()
        Response.Redirect("~/niveles.aspx")
    End Sub
    Protected Sub Btn_Guardar_Click()
        Response.Redirect("~/niveles.aspx")
    End Sub

End Class