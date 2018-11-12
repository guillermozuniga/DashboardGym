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
                    If Not SelectSecciones(Valor) Then
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

    Public Sub ListarSecciones()
        Dim Lista As List(Of SeccionesEnt) = Nothing

        Try
            Lista = SeccionLN.getInstance.ListarSeccion(0)

        Catch ex As Exception

            Lista = Nothing
            Throw ex
        End Try
    End Sub

    Public Function SelectSecciones(ByVal valor As Integer) As Boolean
        Dim Resp As Boolean = True
        Dim objSeccion As SeccionesEnt = Nothing

        Try
            objSeccion = SeccionLN.getInstance.SelectSeccion(valor)
            Me.TextBoxNombre.Text = objSeccion.Nivel_Descripcion.ToUpper
            Me.TextBoxClave.Text = objSeccion.Nivel_Clave.ToUpper
            Me.TextBoxGrados.Text = objSeccion.Nivel_Grados
            Me.TextBoxGradoInicial.Text = objSeccion.Nivel_GradoInicial
            Me.TextBoxPeriodos.Text = objSeccion.Nivel_Periodos
            Me.DropDownListBancos.SelectedValue = objSeccion.Nivel_BancoID
            Me.TextCalle.Text = objSeccion.Nivel_Direccion_Calle
            Me.TextColonia.Text = objSeccion.Nivel_Direccion_Colonia
            Me.TextCodigoP.Text = objSeccion.Nivel_Direccion_Cpostal
            Me.TextEstado.Text = objSeccion.Nivel_Direccion_Estado
            Me.TextLocalidad.Text = objSeccion.Nivel_Direccion_localidad
            Me.TextMunicipio.Text = objSeccion.Nivel_Direccion_Municipio
            Me.TextNumExt.Text = objSeccion.Nivel_Direccion_NoExterior
            Me.TextEmail.Text = objSeccion.Nivel_eMail
            Me.TextNumInt.Text = objSeccion.Nivel_Direccion_NoInterior
            Me.TextDominio.Text = objSeccion.Nivel_Dominio
            TextBoxRazonSocial.Text = objSeccion.Nivel_RazonSocial
            TextBoxNombreComercial.Text = objSeccion.Nivel_NombreComercial
            TextBoxSistemaOficial.Text = objSeccion.Nivel_SistemaOficial
            TextTel1.Text = objSeccion.Nivel_Telefono1
            TextTel2.Text = objSeccion.Nivel_Telefono2
            TextTel3.Text = objSeccion.Nivel_Telefono3
            TextMovil.Text = objSeccion.Nivel_Movil
            TextBoxPeriodos.Text = objSeccion.Nivel_Periodos
            TextBoxNivelPorPeriodos.Text = objSeccion.Nivel_EvaluacionesPorPeriodo
            TextBoxCURP.Text = objSeccion.Nivel_CURP
            TextBoxRFC.Text = objSeccion.Nivel_RFC
            TextBoxRepresentante.Text = objSeccion.Nivel_RepresentanteLegal
            TextBoxRepresentanteCURP.Text = objSeccion.Nivel_RepresentanteLegal_Curp
            TextBoxRepresentanteRFC.Text = objSeccion.Nivel_RepresentanteLegal_RFC
            BindBancosToList("Select * from [eimagenn_sge_admin].[v_GetAllBancos]")
            Me.DropDownListBancos.SelectedValue = objSeccion.Nivel_BancoID

        Catch ex As Exception

            objSeccion = Nothing
            Throw ex
            Resp = False

        End Try
        Return Resp
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
                DropDownListBancos.DataSource = Lista
                DropDownListBancos.DataTextField = "Banco_Nombre"
                DropDownListBancos.DataValueField = "Bancos_BancoID"
                DropDownListBancos.DataBind()

            Catch ex As Exception

                Lista = Nothing

                Throw ex

            End Try
        End If

    End Sub
    Private Function GetValues()
        Dim objSeccion As SeccionesEnt = New SeccionesEnt With {
            .Nivel_Descripcion = Me.TextBoxNombre.Text,
            .Nivel_Clave = Me.TextBoxClave.Text,
            .Nivel_Grados = Me.TextBoxGrados.Text,
            .Nivel_GradoInicial = Me.TextBoxGradoInicial.Text,
            .Nivel_BancoID = Me.DropDownListBancos.SelectedIndex,
            .Nivel_Direccion_Calle = Me.TextCalle.Text.ToUpper,
            .Nivel_Direccion_Colonia = Me.TextColonia.Text.ToUpper,
            .Nivel_Direccion_Cpostal = Me.TextCodigoP.Text,
            .Nivel_Direccion_Estado = Me.TextEstado.Text.ToUpper,
            .Nivel_Direccion_localidad = Me.TextLocalidad.Text.ToUpper,
            .Nivel_Direccion_Municipio = Me.TextMunicipio.Text.ToUpper,
            .Nivel_Direccion_NoExterior = Me.TextNumExt.Text,
            .Nivel_eMail = Me.TextEmail.Text,
            .Nivel_Direccion_NoInterior = Me.TextNumInt.Text,
            .Nivel_Dominio = Me.TextDominio.Text,
            .Nivel_RazonSocial = TextBoxRazonSocial.Text.ToUpper,
            .Nivel_NombreComercial = TextBoxNombreComercial.Text.ToUpper,
            .Nivel_SistemaOficial = TextBoxSistemaOficial.Text,
            .Nivel_Telefono1 = TextTel1.Text,
            .Nivel_Telefono2 = TextTel2.Text,
            .Nivel_Telefono3 = TextTel3.Text,
            .Nivel_Movil = TextMovil.Text,
            .Nivel_Periodos = TextBoxPeriodos.Text,
            .Nivel_EvaluacionesPorPeriodo = TextBoxNivelPorPeriodos.Text,
            .Nivel_CURP = TextBoxCURP.Text,
            .Nivel_RFC = TextBoxRFC.Text,
            .Nivel_RepresentanteLegal = TextBoxRepresentante.Text,
            .Nivel_RepresentanteLegal_Curp = TextBoxRepresentanteCURP.Text,
            .Nivel_RepresentanteLegal_RFC = TextBoxRepresentanteRFC.Text,
            .Nivel_ID = HiddenFieldValor.Value
        }

        Return objSeccion

    End Function
    Protected Sub Btn_Regresar_Click()
        Response.Redirect("~/niveles.aspx")
    End Sub
    Protected Sub Btn_Guardar_Click()
        If Not String.IsNullOrEmpty(Me.TextBoxNombre.Text) And Not String.IsNullOrEmpty(Me.TextBoxClave.Text) Then
            Dim respuesta As Boolean
            Dim objNivel As SeccionesEnt = GetValues()
            If bandnuevo Then
                respuesta = SeccionLN.getInstance().RegistrarSeccion(objNivel)
            Else
                respuesta = SeccionLN.getInstance().ModificarSeccion(objNivel)
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

End Class