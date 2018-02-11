
Public Class FrmCajero6

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        clsComun.clsFunciones.LiberarMemoria()
        Dim frmind As New frmIndex
        frmind.Show()
        frmind.Activate()
        Me.Close()
    End Sub
End Class