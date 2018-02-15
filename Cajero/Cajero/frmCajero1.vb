Imports System.Runtime.InteropServices

Public Class frmCajero1

    Private Sub ButtonMembresia_Click(sender As Object, e As EventArgs) Handles ButtonMembresia.Click
        Dim frm3 As New frmCajero3
        frm3.Show()
        frm3.Activate()
        Me.Close()
    End Sub

    Private Sub ButtonRegistrarte_Click(sender As Object, e As EventArgs) Handles ButtonRegistrarte.Click
        Dim frm2 As New frmCajero2
        frm2.Show()
        frm2.Activate()
        Me.Close()
    End Sub

    Private Declare Function GetLastInputInfo Lib "user32" (ByRef plii As LASTINPUTINFO) As Boolean

    Structure LASTINPUTINFO
        Public cbSize As Integer 'TAMAÑO DE LA ESTRUCTURA EN BYTES ¿?
        Public dwTime As Integer 'MOMENTO (MILISEGUNDOS DESDE QUE SE INICIO LA SESION) EN QUE SE PULSA UNA TECLA O SE ACTIVA EL MOUSE
    End Structure

    Dim INPUT As New LASTINPUTINFO() 'PARA USAR LA ESTRUCTURA EN LA FUNCION GetLastInputInfo



    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        GetLastInputInfo(INPUT) 'COMPROBAMOS LA FUNCION CADA SEGUNDO

        Dim TOTAL As Integer = Environment.TickCount        'MILISEGUNDOS DESDE QUE SE INICIO LA SESION
        Dim ULTIMO As Integer = INPUT.dwTime 'MILISEGUNDOS DESDE LA ULTIMA ACTIVIDAD (TECLADO Y MOUSE)
        Dim INTERVALO As Integer = (TOTAL - ULTIMO) / 1000 'DIFERENCIA EN SEGUNDOS 

        If INTERVALO >= 10 Then 'SI LA INACTIVIDAD ES 10 SEGUNDOS O MÁS
            Timer1.Stop()
            'MsgBox("10 SEGUNDOS DE INACTIVIDAD")
            Dim frmind As New frmIndex
            frmind.Show()
            frmind.Activate()
            Me.Close()
        End If
    End Sub

    Private Sub frmCajero1_Load(sender As Object, e As EventArgs) Handles Me.Load
        INPUT.cbSize = Marshal.SizeOf(INPUT) '¿? PERO ES NECESARIO
        Timer1.Interval = 1000 'MONITORIZAREMOS GetLastInputInfo CADA SEGUNDO
        Timer1.Start()
        Me.ButtonMembresia.Select()
        Me.ButtonMembresia.Focus()


    End Sub
End Class