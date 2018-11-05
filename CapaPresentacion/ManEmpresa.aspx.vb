Imports CapaEntidades
Imports CapaLogicaNegocio

Public Class ManEmpresa
    Inherits System.Web.UI.Page

    Dim bandnuevo As Boolean = False
    Dim Valor As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Valor = Convert.ToInt32(Request.QueryString("Valor"))
                If Valor > 0 Then
                    Me.HiddenFieldValor.Value = Valor
                    If Not CargarEmpresa(Valor) Then

                        Me.TextRFC.Enabled = False
                        Me.TextRazonSocial.Enabled = True
                        Me.TextRazonSocial.Focus()

                    End If
                Else
                    bandnuevo = True

                    Me.TextRFC.Enabled = True
                    Me.TextRazonSocial.Enabled = True
                    Me.TextRFC.Focus()

                End If

            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If

    End Sub

    Private Function GetValues()
        Dim objEmpresa As EmpresaEnt = New EmpresaEnt With {
            .Empresa_CURP = Me.TextCURP.Text,
            .Empresa_Direccion_Calle = Me.TextCalle.Text,
            .Empresa_Direccion_Colonia = Me.TextColonia.Text,
            .Empresa_Direccion_CPostal = Me.TextCodigoP.Text,
            .Empresa_Direccion_Estado = Me.TextEstado.Text,
            .Empresa_Direccion_Localidad = Me.TextLocalidad.Text,
            .Empresa_Direccion_Municipio = Me.TextMunicipio.Text,
            .Empresa_Direccion_NoExterior = Me.TextNumExt.Text,
            .Empresa_Direccion_NoInterior = Me.TextNumInt.Text,
            .Empresa_Dominio = Me.TextDominio.Text,
            .Empresa_eMail = Me.TextEmail.Text,
            .Empresa_Movil = Me.TextMovil.Text,
            .Empresa_NombreComercial = Me.TextBoxNombreCom.Text,
            .Empresa_RazonSocial = Me.TextRazonSocial.Text,
            .Empresa_RFC = Me.TextRFC.Text,
            .Empresa_Telefono1 = Me.TextTel1.Text,
            .Empresa_Telefono2 = Me.TextTel2.Text,
            .Empresa_Telefono3 = Me.TextTel3.Text,
            .Empresa_NombreCorto = Me.TextNombreCorto.Text,
            .Empresa_ID = HiddenFieldValor.Value
        }

        Return objEmpresa

    End Function
    Protected Sub Btn_Guardar_Click()

        If Not String.IsNullOrEmpty(Me.TextRFC.Text) And Not String.IsNullOrEmpty(Me.TextRazonSocial.Text) Then
            Dim respuesta As Boolean
            Dim objEmpre As EmpresaEnt = GetValues()
            If bandnuevo Then
                respuesta = EmpresaLN.getInstance().RegistrarEmpresa(objEmpre)
            Else
                respuesta = EmpresaLN.getInstance().ModificarEmpresa(objEmpre)
            End If

            If respuesta Then
                'Response.Write("<script>alert(' Insercion Correcta.')</script>")
                ClsFuniones.BootstrapAlert(lblMsg, "Acualización realizada con exito", ClsFuniones.BootstrapAlertType.Success, True)
            Else
                ' Response.Write("<script>alert(' Insercion Incorrecta.')</script>")
                ClsFuniones.BootstrapAlert(lblMsg, "Upps no se pudo realizar la actualización", ClsFuniones.BootstrapAlertType.Warning, True)
            End If
        Else
            Me.TextRFC.Focus()
        End If


    End Sub

    Protected Sub Btn_Regresar_Click()
        Response.Redirect("~/ListEmpresa.aspx")
    End Sub

    Protected Sub Btn_Submit_Click()

    End Sub

    Protected Sub Btn_Aceptar_Click()

    End Sub
    Private Function CargarEmpresa(ByVal valor As Integer) As Boolean
        Dim objEmpresa As New EmpresaEnt
        objEmpresa = EmpresaLN.getInstance().BuscarEmpresa(valor)
        Me.TextRFC.Text = objEmpresa.Empresa_RFC.ToString()
        Me.TextNombreCorto.Text = objEmpresa.Empresa_NombreCorto.ToString()
        Me.TextRazonSocial.Text = objEmpresa.Empresa_RazonSocial.ToString()
        Me.TextNombreCorto.Text = objEmpresa.Empresa_NombreCorto.ToString()
        Me.TextCalle.Text = objEmpresa.Empresa_Direccion_Calle.ToString()
        Me.TextBoxNombreCom.Text = objEmpresa.Empresa_NombreComercial.ToString()
        Me.TextEmail.Text = objEmpresa.Empresa_eMail.ToString()
        Me.TextColonia.Text = objEmpresa.Empresa_Direccion_Colonia.ToString()
        Me.TextEstado.Text = objEmpresa.Empresa_Direccion_Estado.ToString()
        Me.TextMunicipio.Text = objEmpresa.Empresa_Direccion_Municipio.ToString()
        Me.TextLocalidad.Text = objEmpresa.Empresa_Direccion_Localidad.ToString()
        Me.TextTel1.Text = objEmpresa.Empresa_Telefono1.ToString()
        Me.TextTel2.Text = objEmpresa.Empresa_Telefono2.ToString()
        Me.TextTel3.Text = objEmpresa.Empresa_Telefono3.ToString()
        Me.TextMovil.Text = objEmpresa.Empresa_Movil.ToString()
        Me.TextCodigoP.Text = objEmpresa.Empresa_Direccion_CPostal.ToString()
        Me.TextCURP.Text = objEmpresa.Empresa_CURP.ToString()
        Me.TextDominio.Text = objEmpresa.Empresa_Dominio.ToString()
        Me.TextNumExt.Text = objEmpresa.Empresa_Direccion_NoExterior.ToString()
        Me.TextNumInt.Text = objEmpresa.Empresa_Direccion_NoInterior.ToString()

        Return False
    End Function
End Class