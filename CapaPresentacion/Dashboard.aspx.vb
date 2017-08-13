Imports System.Data.SqlClient
Imports System.Web.Security
Imports CapaEntidades
Imports CapaLogicaNegocio
Imports System.Net
Imports System.Net.Mail

Public Class Dashboard
    Inherits System.Web.UI.Page
#Region "Rutinas"
    Private Sub CargarUnidadesNegocio()
        Dim dt As DataTable

        dt = UnidadNegocioLN.getInstance().CantidadNegocios

        Dim row As DataRow = dt.Rows(dt.Rows.Count - 1)

        Dim value As Object

        value = row.Item("TotalDonativo")
        If value Is DBNull.Value Then
            'Me.LabelMontoDonativos.Text = "0.00"
        Else
            ' Me.LabelMontoDonativos.Text = CStr(value)
        End If

        value = row.Item("ItemCount")
        If value Is DBNull.Value Then
            'Me.LabelCantidadDonativos.Text = "0.00"
        Else
            'Me.LabelCantidadDonativos.Text = CStr(value)
        End If

    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label1.Text = " Movimiento de Clientes: 1 -  " & MonthName(Month(Date.Now)) & "    al    " & Day(Date.Now) & "  -  " & MonthName(Month(Date.Now))

        Me.Label2.Text = " Movimiento en Ventas: 1 -  " & MonthName(Month(Date.Now)) & "    al    " & Day(Date.Now) & "  -  " & MonthName(Month(Date.Now))
    End Sub

End Class