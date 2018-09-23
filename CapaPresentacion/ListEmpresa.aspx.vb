Imports CapaLogicaNegocio
Imports CapaEntidades
Public Class ListEmpresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (HttpContext.Current.User.Identity.IsAuthenticated) Then

                'LlenarGridViewTutores("Select * from SGE_VistaNombreTutor Order By Nombre")
                ListarEmpresas()
            Else
                Response.Redirect("~/logout.aspx")
            End If

        End If
    End Sub
    Protected Sub Btn_Nuevo_Click()
        Response.Redirect("ManEmpresa.aspx")
    End Sub

    Public Sub ListarEmpresas()
        Dim Lista As List(Of EmpresaEnt) = Nothing
        Try
            Lista = EmpresaLN.getInstance.ListarEmpresa()
            Me.gvEmpresa.DataSource = Lista
            Me.gvEmpresa.DataBind()
        Catch ex As Exception
            Lista = Nothing

        End Try

    End Sub
    Protected Sub Btn_Buscar_Click()

    End Sub
End Class