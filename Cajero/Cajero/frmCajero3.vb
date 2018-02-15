Imports clsComun
Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class frmCajero3
#Region "Declaracion Variables"
    Dim funciones As New clsFunciones
    Dim dt As DataTable
    Dim ConDb As SqlConnection
    Dim ruta As String = My.Application.Info.DirectoryPath & Chr(92)
    Dim texto, cliente As String
    Dim longitud, IDGimnasio2 As String
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

        If INTERVALO >= 15 Then 'SI LA INACTIVIDAD ES 10 SEGUNDOS O MÁS
            Timer1.Stop()
            clsFunciones.LiberarMemoria()
            'MsgBox("10 SEGUNDOS DE INACTIVIDAD")
            Dim frmind As New frmIndex
            frmind.Show()
            frmind.Activate()
            Me.Close()
        End If
    End Sub
    Private Function SeleccionarClientes(ByVal _Sentencia As String) As Boolean
        dt = funciones.SeleccionarDatos(_Sentencia)

        If dt.Rows.Count > 0 Then
            Return True
        Else
            'Me.Label1.Visible = True
            'Me.Label1.Text = "Número de Socio no Encontrado !!!"
            'Me.TextBoxIDSocio.Text = String.Empty
            'Me.TextBoxIDSocio.SelectAll()
            'Me.TextBoxIDSocio.Focus()
            Return False

        End If

        dt.Clear()
        dt.Dispose()

        System.Windows.Forms.Cursor.Current = Cursors.Default
        LastControl.SELECTALL()
        LastControl.FOCUS()
    End Function
#End Region


    Private Sub ButtonRegresar_Click(sender As Object, e As EventArgs) Handles ButtonRegresar.Click
        Dim frm1 As New frmCajero1
        frm1.Show()
        frm1.Activate()
        Me.Close()
    End Sub


    Private Sub frmCajero3_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TextBoxIDSocio.Select()
        Me.TextBoxIDSocio.Focus()

        LastControl = Me.TextBoxIDSocio

        INPUT.cbSize = Marshal.SizeOf(INPUT) '¿? PERO ES NECESARIO
        Timer1.Interval = 1000 'MONITORIZAREMOS GetLastInputInfo CADA SEGUNDO
        Timer1.Start()
    End Sub

    Private Sub ButtonSiguiente_Click(sender As Object, e As EventArgs) Handles ButtonSiguiente.Click
        If Not String.IsNullOrEmpty(Me.TextBoxIDSocio.Text) Then
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If InStr(Trim(Me.TextBoxIDSocio.Text), "-") <= 0 Then
                If SeleccionarClientes("Select IDCliente, IDGimnasio from catClientes where IDCliente = " & CType(Me.TextBoxIDSocio.Text, Integer) & "") Then
                    Me.Timer1.Stop()
                    Dim frmK4 As New frmCajero4
                    With frmK4
                        '.Text = " .:: PUNTO DE VENTA ::."
                        ._Cliente = Me.TextBoxIDSocio.Text
                        ._Gimnasio = 0
                        .ShowDialog()
                        .ShowInTaskbar = False
                        .Activate()
                    End With

                    Me.Close()

                Else
                    Me.Label1.Visible = True
                    Me.Label1.Text = "Número de Socio no Encontrado !!!"
                    Me.TextBoxIDSocio.Text = String.Empty
                    Me.TextBoxIDSocio.SelectAll()
                    Me.TextBoxIDSocio.Focus()
                End If

            Else

                PosicionGuion = InStr(Trim(Me.TextBoxIDSocio.Text), "-")

                texto = Me.TextBoxIDSocio.Text

                longitud = texto.Length

                cliente = texto.Substring(InStr(Trim(Me.TextBoxIDSocio.Text), "-"), longitud - InStr(Trim(Me.TextBoxIDSocio.Text), "-"))

                IDGimnasio2 = texto.Substring(0, InStr(Trim(Me.TextBoxIDSocio.Text), "-") - 1)

                If funciones.EstadoRed() Then

                    ' Dim dtGimnasio As DataTable

                    'dtGimnasio = funciones.SeleccionarDatosWeb("Select * from catGimnasios where IDGimnasio = " & IDGimnasio2.ToString & "")

                    ' If dtGimnasio.Rows.Count > 0 Then
                    Me.Timer1.Stop()
                    Dim frmK4 As New frmCajero4
                    With frmK4
                        '.Text = " .:: PUNTO DE VENTA ::."
                        ._Cliente = Me.cliente
                        ._Gimnasio = Me.IDGimnasio2
                        .ShowDialog()
                        .ShowInTaskbar = False
                        .Activate()
                    End With

                    Me.Close()
                    ' Me.txtxGimnasio.Text = dtGimnasio.Rows(0).Item("NombreSucursal").ToString

                    'Else
                    '   MessageBox.Show("Verifica la Información, No Existe el Gimnasio !!!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'Me.btnXCancelar_Click(Nothing, Nothing)
                    '  Exit Sub

                    'End If
                Else

                    MessageBox.Show("Internet no disponible," & vbNewLine & "No se reflejara esta información hasta que sea reestablecido!!! ", My.Application.Info.Description, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If ' If de consulta de acceso a intenet

            End If
        Else

            Me.Label1.Text = "Debe ingresar un numero de socio"
            Me.Label1.Visible = True
            Me.TextBoxIDSocio.SelectAll()
            Me.TextBoxIDSocio.Focus()
        End If


        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub TextBoxIDSocio_GotFocus(sender As Object, e As EventArgs) Handles TextBoxIDSocio.GotFocus
        Me.LabelBakIDSocio.BackColor = Color.Red
    End Sub

    Private Sub TextBoxIDSocio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxIDSocio.KeyPress
        If (Not Char.IsNumber(e.KeyChar) And e.KeyChar <> Microsoft.VisualBasic.ChrW(8) And e.KeyChar <> Microsoft.VisualBasic.ChrW(32) And e.KeyChar <> Microsoft.VisualBasic.ChrW(45)) Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 13 Then
        End If
    End Sub

    Private Sub TextBoxIDSocio_Leave(sender As Object, e As EventArgs) Handles TextBoxIDSocio.Leave
        Me.LabelBakIDSocio.BackColor = Nothing

    End Sub

    Private Sub ButtonUno_Click(sender As Object, e As EventArgs) Handles ButtonUno.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "1")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonDos_Click(sender As Object, e As EventArgs) Handles ButtonDos.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "2")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonTres_Click(sender As Object, e As EventArgs) Handles ButtonTres.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "3")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonCuatro_Click(sender As Object, e As EventArgs) Handles ButtonCuatro.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "4")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonCinco_Click(sender As Object, e As EventArgs) Handles ButtonCinco.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "5")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonSeis_Click(sender As Object, e As EventArgs) Handles ButtonSeis.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "6")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonSiete_Click(sender As Object, e As EventArgs) Handles ButtonSiete.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "7")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonOcho_Click(sender As Object, e As EventArgs) Handles ButtonOcho.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "8")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonNueve_Click(sender As Object, e As EventArgs) Handles ButtonNueve.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "9")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonCero_Click(sender As Object, e As EventArgs) Handles ButtonCero.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "0")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonGuion_Click(sender As Object, e As EventArgs) Handles ButtonGuion.Click
        LastCharIndex = Len(LastControl.TEXT)
        LastControl.Text = LastControl.Text.Insert(LastCharIndex, "-")
        LastControl.focus()
        Me.Label1.Visible = False
    End Sub

    Private Sub ButtonAtras_Click(sender As Object, e As EventArgs) Handles ButtonAtras.Click

        If LastControl.TEXT.LENGTH > 0 Then

            Dim STR As String = LastControl.TEXT
            LastControl.Text = STR.Substring(0, STR.Length - 1)
            LastControl.focus()
            Me.Label1.Visible = False

        Else
            LastControl.SELECT()
            LastControl.FOCUS()

        End If
    End Sub

  
End Class