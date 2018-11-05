Public Class ManFamilias
    Inherits System.Web.UI.Page
    Dim Sexos As New ArrayList()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LlenarComboSexo()
        DropDownListEstadoCivil.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Selecciona una opción", ""))
        DropDownListEstadoCivil.Items.Insert(1, New System.Web.UI.WebControls.ListItem("Crear - Editar", ""))
    End Sub


    Private Sub LlenarComboSexo()

        Sexos.Clear()

        Sexos.Add("Hombre")

        Sexos.Add("Mujer")

        'Add blank item at index 0.

        DropDownListSexo.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Selecciona una opción", ""))

        'Loop and add items from ArrayList.

        For Each Sexo As Object In Sexos

            DropDownListSexo.Items.Add(New System.Web.UI.WebControls.ListItem(Sexo.ToString(), Sexo.ToString()))

        Next
    End Sub

    Protected Sub Btn_Regresar_Click()
        Server.Transfer("~/ListFamilias.aspx")
    End Sub
End Class