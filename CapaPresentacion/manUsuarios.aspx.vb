Public Class manUsuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarRoles()
    End Sub


    Private Sub CargarRoles()

        Me.DropDownListRoles.DataSource = Roles.GetAllRoles()
        Me.DropDownListRoles.DataBind()
        DropDownListRoles.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Selecciona una opción", ""))
        DropDownListRoles.Items.Insert(DropDownListRoles.Items.Count, New System.Web.UI.WebControls.ListItem("Crear - Editar", ""))
    End Sub
End Class