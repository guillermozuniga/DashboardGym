Imports clsComun
Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class frmCajero4

#Region "Declaracion Variables"
    Dim funciones As New clsFunciones
    Dim dt As DataTable
    Dim ConDb As SqlConnection
    Dim ruta As String = My.Application.Info.DirectoryPath & Chr(92)
    Dim texto, cliente As String
    Friend PosicionGuion As Integer
    Private LastCharIndex As Integer = 0
    'Guardamos ultimo control que perdio el foco.
    Private LastControl As Object
    Dim FechaActual As String
    Friend _Cliente, _Gimnasio As Integer
    Private Declare Function GetLastInputInfo Lib "user32" (ByRef plii As LASTINPUTINFO) As Boolean

    Structure LASTINPUTINFO
        Public cbSize As Integer 'TAMAÑO DE LA ESTRUCTURA EN BYTES ¿?
        Public dwTime As Integer 'MOMENTO (MILISEGUNDOS DESDE QUE SE INICIO LA SESION) EN QUE SE PULSA UNA TECLA O SE ACTIVA EL MOUSE
    End Structure

    Dim INPUT As New LASTINPUTINFO() 'PARA USAR LA ESTRUCTURA EN LA FUNCION GetLastInputInfo
#End Region

#Region "Funciones"


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
    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function
    Private Function SeleccionarClientes(ByVal _Sentencia As String) As Boolean
        dt = funciones.SeleccionarDatos(_Sentencia)
        If dt.Rows.Count > 0 Then
            Me.TextBoxNombre.Text = dt.Rows(0).Item("Nombre").ToString
            Me.TextBoxCorreoElectronico.Text = dt.Rows(0).Item("eMail").ToString
            Me.TextBoxDireccion.Text = (dt.Rows(0).Item("Direccion").ToString)
            Me.TextBoxTelefono.Text = dt.Rows(0).Item("Telefono").ToString
            If Not IsDBNull(dt.Rows(0).Item("FechaVencimiento")) Then
                FechaActual = Format(Date.Now, "yyyyMMdd").ToString

                ''***************************************************************************************************
                ''se modifico el quitando el signo de igual a la linea (10/08/2013)
                '' If dt.Rows(0).Item("FechaVencimiento").ToString <= FActual Then
                ''***************************************************************************************************
                If dt.Rows(0).Item("FechaVencimiento").ToString < FechaActual Then

                    Me.LabelVencimiento.ForeColor = Color.Red
                    Me.LabelVencimiento.Text = clsComun.clsFunciones.convertirtextoafecha(dt.Rows(0).Item("FechaVencimiento").ToString)
                    Me.LabelVencimiento.BackColor = Color.Black


                ElseIf ((dt.Rows(0).Item("FechaVencimiento")) - (FechaActual)) <= 2 Then
                    Me.LabelVencimiento.BackColor = Color.Black
                    Me.LabelVencimiento.ForeColor = Color.Yellow

                    Me.LabelVencimiento.Text = clsComun.clsFunciones.convertirtextoafecha(dt.Rows(0).Item("FechaVencimiento").ToString)

                Else

                    Me.LabelVencimiento.Text = clsComun.clsFunciones.convertirtextoafecha(dt.Rows(0).Item("FechaVencimiento").ToString)

                End If
            End If
            PictureBoxFoto.ImageLocation = Nothing

            PictureBoxFoto.Image = Nothing

            If Not IsDBNull(dt.Rows(0).Item("Imagen")) Then

                PictureBoxFoto.Image = ByteArrayToImage(DirectCast(dt.Rows(0).Item("Imagen"), Byte()))

            Else

                PictureBoxFoto.ImageLocation = ruta & "TempFotos\noborrar.jpg"

            End If
            Return True
        Else


        End If

        dt.Clear()
        dt.Dispose()

        System.Windows.Forms.Cursor.Current = Cursors.Default

    End Function
#End Region

    Private Sub ButtonRegresar_Click(sender As Object, e As EventArgs) Handles ButtonRegresar.Click
        Dim frm3 As New frmCajero3
        frm3.Show()
        frm3.Activate()
        Me.Close()
    End Sub

    Private Sub frmCajero4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TextBoxIDSocio.Text = _Cliente
        If SeleccionarClientes("Select IDCliente, Nombre, IDGimnasio, Email, FechaVencimiento, Imagen, Telefono , Direccion from catClientes where IDCliente = " & CType(_Cliente, Integer) & "") Then

        End If

        INPUT.cbSize = Marshal.SizeOf(INPUT) '¿? PERO ES NECESARIO
        Timer1.Interval = 1000 'MONITORIZAREMOS GetLastInputInfo CADA SEGUNDO
        Timer1.Start()
    End Sub

    Private Sub ButtonSiguiente_Click(sender As Object, e As EventArgs) Handles ButtonSiguiente.Click
        If Not String.IsNullOrEmpty(Me.TextBoxIDSocio.Text) Then
            Me.Timer1.Stop()

            Dim frmK41 As New frmCajero41
            With frmK41
                '.Text = " .:: PUNTO DE VENTA ::."
                ._Cliente = Me.TextBoxIDSocio.Text
                ._NombreCliente = Me.TextBoxNombre.Text
                .ShowDialog()
                .ShowInTaskbar = False
                .Activate()
            End With
            Me.Close()
        Else
            Me.TextBoxIDSocio.SelectAll()
            Me.TextBoxIDSocio.Focus()
        End If
    End Sub
End Class