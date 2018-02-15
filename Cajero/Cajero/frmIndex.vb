Public Class frmIndex

    Private Sub frmIndex_Click(sender As Object, e As EventArgs) Handles Me.Click

        Dim frm1 As New frmCajero1
        frm1.Show()
        frm1.Activate()
        Me.Hide()

    End Sub

    Private Sub frmIndex_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class