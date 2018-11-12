Imports CapaEntidades
Imports CapaLogicaNegocio
Public Class ManMaterias
    Inherits System.Web.UI.Page
    Dim bandnuevo As Boolean = False
    Dim Valor As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Valor = Convert.ToInt32(Request.QueryString("Valor"))
                If Valor > 0 Then
                    Me.HiddenFieldValor.Value = Valor
                    If Not SelectMaterias(Valor) Then
                        Me.TextNombre.Focus()
                    End If
                Else
                    ListarSecciones()

                    HiddenFieldValor.Value = 0
                    Me.TextNombre.Focus()
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
            DropDownListaSecciones.DataSource = Lista
            DropDownListaSecciones.DataTextField = "Nivel_Descripcion"
            DropDownListaSecciones.DataValueField = "Nivel_ID"
            DropDownListaSecciones.DataBind()

        Catch ex As Exception

            Lista = Nothing
            Throw ex
        End Try
    End Sub
    Public Function SelectMaterias(ByVal valor As Integer) As Boolean
        Dim Resp As Boolean = True
        Dim objMateria As MateriaEnt = Nothing

        Try
            objMateria = MateriasLN.GetInstance.BuscarMateria(valor)

            Me.TextNombre.Text = objMateria.Materias_Nombre.ToUpper
            Me.TextNombreCorto.Text = objMateria.Materias_NombreCorto.ToUpper
            Me.TextBoxClaveOficial.Text = objMateria.Materias_ClaveOficial
            Me.TextBoxCreditos.Text = objMateria.Materias_Creditos
            Me.TextBoxFaltasPer.Text = objMateria.Materias_FaltasPermitidas
            Me.TextBoxHorasSema.Text = objMateria.Materias_HorasSemana
            Me.TextBoxHorastot.Text = objMateria.Materias_HorasTotales
            Me.TextBoxMateria.Text = objMateria.Materias_Materia

            ListarSecciones()
            Me.DropDownListaSecciones.SelectedValue = objMateria.Materias_Nivel + 1

        Catch ex As Exception

            objMateria = Nothing
            Throw ex
            Resp = False

        End Try
        Return Resp
    End Function

    Private Function GetValues()
        Dim objMateria As MateriaEnt = New MateriaEnt With {
           .Materias_Nombre = Me.TextNombre.Text,
           .Materias_ClaveOficial = TextBoxClaveOficial.Text,
           .Materias_FaltasPermitidas = TextBoxFaltasPer.Text,
           .Materias_Creditos = TextBoxCreditos.Text,
           .Materias_CicloEscolar = TextBoxCreditos.Text,
           .Materias_HorasSemana = TextBoxHorasSema.Text,
           .Materias_NombreCorto = TextNombreCorto.Text,
           .Materias_Materia = TextBoxMateria.Text,
           .Materias_Nivel = Me.DropDownListaSecciones.SelectedIndex - 1,
           .Materias_HorasTotales = Me.TextBoxHorastot.Text,
           .Materias_ID = HiddenFieldValor.Value
        }

        Return objMateria

    End Function
    Protected Sub Btn_Regresar_Click()
        Server.Transfer("~/listMaterias.aspx")
    End Sub

    Protected Sub Btn_Guardar_Click()
        If Not String.IsNullOrEmpty(Me.TextNombre.Text) And Not String.IsNullOrEmpty(Me.TextBoxClaveOficial.Text) Then
            Dim respuesta As Boolean
            Dim objMateria As MateriaEnt = GetValues()
            If bandnuevo Then
                respuesta = MateriasLN.GetInstance().RegistrarMateria(objMateria)
            Else
                respuesta = MateriasLN.GetInstance().ModificarMateria(objMateria)
            End If

            If respuesta Then
                'Response.Write("<script>alert(' Insercion Correcta.')</script>")
                ClsFuniones.BootstrapAlert(lblMsg, "Actualización realizada con exito", ClsFuniones.BootstrapAlertType.Success, True)
            Else
                ' Response.Write("<script>alert(' Insercion Incorrecta.')</script>")
                ClsFuniones.BootstrapAlert(lblMsg, "Upps no se pudo realizar la actualización", ClsFuniones.BootstrapAlertType.Warning, True)
            End If
        Else
            Me.TextNombre.Focus()
        End If
    End Sub
End Class