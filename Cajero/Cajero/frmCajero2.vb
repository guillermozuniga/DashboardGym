Imports System.Runtime.InteropServices

Public Class frmCajero2
#Region "Declaracion Variables"

    Friend PosicionGuion As Integer
    Private LastCharIndex As Integer = 0
    'Guardamos ultimo control que perdio el foco.
    Private LastControl As Object
#End Region


#Region "Funciones"
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


    Private Function SeleccionarClientes(ByVal _Sentencia As String) As Boolean
        'dt = func.SeleccionarDatos(_Sentencia)

        'If dt.Rows.Count > 0 Then
        '    Return True
        'Else
        '    Me.Label1.Visible = True
        '    Me.Label1.Text = "Número de Socio no Encontrado"
        '    Me.TextBoxIDSocio.Text = String.Empty
        '    Me.TextBoxIDSocio.SelectAll()
        '    Me.TextBoxIDSocio.Focus()
        '    Return False

        'End If

        'dt.Clear()
        'dt.Dispose()

        'System.Windows.Forms.Cursor.Current = Cursors.Default
        'LastControl.SELECTALL()
        'LastControl.FOCUS()
    End Function
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm1 As New frmCajero1
        frm1.Show()
        frm1.Activate()
        Me.Close()
    End Sub

    Private Sub frmCajero2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TextBoxNombre.Select()
        Me.TextBoxNombre.Focus()
        LastControl = Me.TextBoxNombre
        INPUT.cbSize = Marshal.SizeOf(INPUT) '¿? PERO ES NECESARIO
        Timer1.Interval = 1000 'MONITORIZAREMOS GetLastInputInfo CADA SEGUNDO
        Timer1.Start()
    End Sub

    Private Sub TextBoxNombre_GotFocus(sender As Object, e As EventArgs) Handles TextBoxNombre.GotFocus
        Me.LabelBakNombre.BackColor = Color.Red
        LastControl = Me.TextBoxNombre
    End Sub

    Private Sub TextBoxNombre_Leave(sender As Object, e As EventArgs) Handles TextBoxNombre.Leave
        Me.LabelBakNombre.BackColor = Nothing
        Me.TextBoxNombre.Text = Me.TextBoxNombre.Text.ToUpper()
    End Sub

    Private Sub TextBoxEmail_GotFocus(sender As Object, e As EventArgs) Handles TextBoxEmail.GotFocus
        Me.LabelBackEmail.BackColor = Color.Red
        LastControl = Me.TextBoxEmail
    End Sub

    Private Sub TextBoxEmail_Leave(sender As Object, e As EventArgs) Handles TextBoxEmail.Leave
        Me.LabelBackEmail.BackColor = Nothing

    End Sub

    Private Sub TextBoxTelefono_GotFocus(sender As Object, e As EventArgs) Handles TextBoxTelefono.GotFocus
        Me.LabelBackTelefono.BackColor = Color.Red
        LastControl = Me.TextBoxTelefono
    End Sub

    Private Sub TextBoxTelefono_Leave(sender As Object, e As EventArgs) Handles TextBoxTelefono.Leave
        Me.LabelBackTelefono.BackColor = Nothing

    End Sub


    Private Sub ButtonUno_Click(sender As Object, e As EventArgs) Handles ButtonUno.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "1")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonDos_Click(sender As Object, e As EventArgs) Handles ButtonDos.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "2")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonTres_Click(sender As Object, e As EventArgs) Handles ButtonTres.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "3")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonCuatro_Click(sender As Object, e As EventArgs) Handles ButtonCuatro.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "4")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonCinco_Click(sender As Object, e As EventArgs) Handles ButtonCinco.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "5")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonSeis_Click(sender As Object, e As EventArgs) Handles ButtonSeis.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "6")
        LastControl.focus()
    End Sub

    Private Sub ButtonSiete_Click(sender As Object, e As EventArgs) Handles ButtonSiete.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "7")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonOcho_Click(sender As Object, e As EventArgs) Handles ButtonOcho.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "8")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonNueve_Click(sender As Object, e As EventArgs) Handles ButtonNueve.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "9")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonCero_Click(sender As Object, e As EventArgs) Handles ButtonCero.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "0")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonGuion_Click(sender As Object, e As EventArgs) Handles ButtonGuion.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "-")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonAtras_Click(sender As Object, e As EventArgs) Handles ButtonAtras.Click

        If LastControl.TEXT.LENGTH > 0 Then

            Dim STR As String = LastControl.TEXT
            LastControl.Text = STR.Substring(0, STR.Length - 1)
            LastControl.focus()
        Else
            LastControl.SELECT()
            LastControl.FOCUS()


        End If
    End Sub

    Private Sub ButtonQ_Click(sender As Object, e As EventArgs) Handles ButtonQ.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "Q")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonW_Click(sender As Object, e As EventArgs) Handles ButtonW.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "W")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonE_Click(sender As Object, e As EventArgs) Handles ButtonE.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "E")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonR_Click(sender As Object, e As EventArgs) Handles ButtonR.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "R")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonT_Click(sender As Object, e As EventArgs) Handles ButtonT.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "T")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonY_Click(sender As Object, e As EventArgs) Handles ButtonY.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "Y")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonU_Click(sender As Object, e As EventArgs) Handles ButtonU.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "U")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonI_Click(sender As Object, e As EventArgs) Handles ButtonI.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "I")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonO_Click(sender As Object, e As EventArgs) Handles ButtonO.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "O")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonP_Click(sender As Object, e As EventArgs) Handles ButtonP.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "P")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonA_Click(sender As Object, e As EventArgs) Handles ButtonA.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "A")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonS_Click(sender As Object, e As EventArgs) Handles ButtonS.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "S")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonD_Click(sender As Object, e As EventArgs) Handles ButtonD.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "D")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonF_Click(sender As Object, e As EventArgs) Handles ButtonF.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "F")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonG_Click(sender As Object, e As EventArgs) Handles ButtonG.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "G")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonH_Click(sender As Object, e As EventArgs) Handles ButtonH.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "H")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonJ_Click(sender As Object, e As EventArgs) Handles ButtonJ.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "J")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonK_Click(sender As Object, e As EventArgs) Handles ButtonK.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "K")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonL_Click(sender As Object, e As EventArgs) Handles ButtonL.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "L")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonZ_Click(sender As Object, e As EventArgs) Handles ButtonZ.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "L")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonX_Click(sender As Object, e As EventArgs) Handles ButtonX.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "X")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonC_Click(sender As Object, e As EventArgs) Handles ButtonC.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "C")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonV_Click(sender As Object, e As EventArgs) Handles ButtonV.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "V")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonSpace_Click(sender As Object, e As EventArgs) Handles ButtonSpace.Click
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonB_Click(sender As Object, e As EventArgs) Handles ButtonB.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "B")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonN_Click(sender As Object, e As EventArgs) Handles ButtonN.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "N")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonM_Click(sender As Object, e As EventArgs) Handles ButtonM.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "M")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonPunto_Click(sender As Object, e As EventArgs) Handles ButtonPunto.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, ".")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonArroba_Click(sender As Object, e As EventArgs) Handles ButtonArroba.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "@")
        LastControl.focus()
        Me.Label7.Visible = False
    End Sub

    Private Sub ButtonSiguiente_Click(sender As Object, e As EventArgs) Handles ButtonSiguiente.Click
        If Not String.IsNullOrEmpty(Me.TextBoxNombre.Text) And Not String.IsNullOrEmpty(Me.TextBoxEmail.Text) And Not String.IsNullOrEmpty(Me.TextBoxTelefono.Text) Then
        Else
            Me.Label7.Visible = True
            Me.Label7.Text = "Es necesario llenar todos los campos"
            If String.IsNullOrEmpty(Me.TextBoxNombre.Text) Then
                Me.TextBoxNombre.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(Me.TextBoxEmail.Text) Then
                Me.TextBoxEmail.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(Me.TextBoxTelefono.Text) Then
                Me.TextBoxTelefono.Focus()
                Exit Sub
            End If
        End If
    End Sub
End Class