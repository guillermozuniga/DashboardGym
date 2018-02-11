Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Data.SqlClient
Imports clsComun
Imports System.Runtime.InteropServices

Public Class frmCajero41
#Region "Declaraciones"
    Dim func As New clsFunciones
    Friend _Cliente, _Gimnasio As Integer
    Friend _NombreCliente As String = String.Empty
    Dim _Referencia As String

    Private Declare Function GetLastInputInfo Lib "user32" (ByRef plii As LASTINPUTINFO) As Boolean

    Structure LASTINPUTINFO
        Public cbSize As Integer 'TAMAÑO DE LA ESTRUCTURA EN BYTES ¿?
        Public dwTime As Integer 'MOMENTO (MILISEGUNDOS DESDE QUE SE INICIO LA SESION) EN QUE SE PULSA UNA TECLA O SE ACTIVA EL MOUSE
    End Structure

    Dim INPUT As New LASTINPUTINFO() 'PARA USAR LA ESTRUCTURA EN LA FUNCION GetLastInputInfo
#End Region


#Region "Rutinas"

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        GetLastInputInfo(INPUT) 'COMPROBAMOS LA FUNCION CADA SEGUNDO

        Dim TOTAL As Integer = Environment.TickCount        'MILISEGUNDOS DESDE QUE SE INICIO LA SESION
        Dim ULTIMO As Integer = INPUT.dwTime 'MILISEGUNDOS DESDE LA ULTIMA ACTIVIDAD (TECLADO Y MOUSE)
        Dim INTERVALO As Integer = (TOTAL - ULTIMO) / 1000 'DIFERENCIA EN SEGUNDOS 

        If INTERVALO >= 15 Then 'SI LA INACTIVIDAD ES 10 SEGUNDOS O MÁS
            Me.Timer1.Stop()
            clsFunciones.LiberarMemoria()
            'MsgBox("10 SEGUNDOS DE INACTIVIDAD")
            Dim frmind As New frmIndex
            frmind.Show()
            frmind.Activate()
            Me.Close()
        End If
    End Sub
    Private Function ConcatenarCadena(ByVal cadena As String) As String

        Dim cadenaSHA1 As String = String.Empty
        cadenaSHA1 = clsFunciones.StringToHash(cadena)
        Return cadenaSHA1

    End Function
    Private Sub VScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar1.ValueChanged
        If (VScrollBar1.Value < Me.ListViewProductos.Items.Count) Then
            ListViewProductos.Items(VScrollBar1.Value).Selected = True
            ListViewProductos.EnsureVisible(VScrollBar1.Value)
            ListViewProductos.Select()



        End If

        If (VScrollBar1.Value = VScrollBar1.Maximum) Then
            ListViewProductos.Items(VScrollBar1.Value - 1).Selected = True
            ListViewProductos.EnsureVisible(VScrollBar1.Value - 1)
            ListViewProductos.Select()

        End If

        If (VScrollBar1.Value = VScrollBar1.Minimum) Then
            ListViewProductos.Items(0).Selected = True
            ListViewProductos.EnsureVisible(0)

        End If
    End Sub

    Private Sub ResizeLastColumn(ByVal listViewWidth As Integer)
        Dim totalColumnWidth As Integer = 0
        For i As Integer = 0 To ListViewProductos.Columns.Count - 2
            totalColumnWidth += ListViewProductos.Columns(i).Width
        Next

        ListViewProductos.Columns(ListViewProductos.Columns.Count - 1).Width = Math.Max(listViewWidth - totalColumnWidth, 10)
    End Sub
    <DllImport("user32.dll")> _
    Public Shared Function ShowScrollBar(ByVal hWnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function GetScrollInfo(ByVal hwnd As IntPtr, ByVal fnBar As Integer, ByRef lpsi As SCROLLINFO) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Enum ScrollBarDirection
        SB_HORZ = 0
        SB_VERT = 1
        SB_CTL = 2
        SB_BOTH = 3
    End Enum

    <Serializable(), StructLayout(LayoutKind.Sequential)> _
    Public Structure SCROLLINFO
        Public cbSize As UInteger
        Public fMask As UInteger
        Public nMin As Integer
        Public nMax As Integer
        Public nPage As UInteger
        Public nPos As Integer
        Public nTrackPos As Integer
    End Structure

    Public Enum ScrollInfoMask As UInteger
        SIF_RANGE = &H1
        SIF_PAGE = &H2
        SIF_POS = &H4
        SIF_DISABLENOSCROLL = &H8
        SIF_TRACKPOS = &H10
        SIF_ALL = (SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS)
    End Enum

    Public Shared Function GetScrollInfo(ByVal ctrl As Control, ByRef si As SCROLLINFO, ByVal scrollBarDirection As ScrollBarDirection) As Boolean
        If ctrl IsNot Nothing Then
            si.cbSize = CUInt(Marshal.SizeOf(si))
            si.fMask = CInt(ScrollInfoMask.SIF_ALL)
            If GetScrollInfo(ctrl.Handle, CInt(scrollBarDirection), si) Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Sub colorearListView(ByRef list As ListView)

        Dim i As Integer
        For i = 0 To list.Items.Count - 1
            If i = Int(i / 2) * 2 Then
                list.Items.Item(i).BackColor = Color.White
                list.Items.Item(i).BackColor = Color.FromArgb(194, 217, 247)
            Else
                list.Items.Item(i).BackColor = Color.FromArgb(238, 250, 250)
                SetBackColorSubItems(i, Color.FromArgb(238, 250, 250), list)

            End If
        Next
        list.FullRowSelect = True
    End Sub
    Private Sub SetBackColorSubItems(ByVal numeroFila As Integer, ByVal backColor As Color, ByRef listv As ListView)
        Try
            ' Referenciamos el objeto ListViewItem correspondiente
            ' a la fila indicada.
            '
            Dim item As ListViewItem = listv.Items(numeroFila)
            ' Indicamos que los subelementos no van a utilizar los valores de fuente,
            ' color de primer plano y color de fondo del elemento.
            '
            item.UseItemStyleForSubItems = False
            ' Mientras recorremos la colección de subelementos,
            ' establecemos su color de fondo.
            '
            For n As Integer = 0 To item.SubItems.Count - 1
                item.SubItems(n).BackColor = backColor
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub LlenarListViewProductos(ByVal _Sentencia As String)
        ListViewProductos.Items.Clear()
        Dim dtProductos As DataTable = func.SeleccionarDatos(_Sentencia)
        If dtProductos.Rows.Count > 0 Then

            Me.ListViewProductos.BeginUpdate()


            For I = 0 To dtProductos.Rows.Count - 1

                Dim MyItem As ListViewItem
                MyItem = New ListViewItem("")
                With MyItem
                    .SubItems.Add(dtProductos.Rows(I).Item("IDProducto").ToString)
                    .SubItems.Add(dtProductos.Rows(I).Item("Descripcion").ToString)
                    .SubItems.Add(dtProductos.Rows(I).Item("Precio").ToString)
                End With

                Me.ListViewProductos.Items.Add(MyItem)

            Next

            Me.ListViewProductos.EndUpdate()

        End If
        'colorearListView(ListViewProductos)

    End Sub
#End Region

    Private Sub frmCajero41_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewProductos.View = View.Details
        ListViewProductos.CheckBoxes = True

        ListViewProductos.Columns.Add("", 65, HorizontalAlignment.Center)          'Add column 1
        ListViewProductos.Columns.Add(" ", 2, HorizontalAlignment.Left) 'Add column 2
        ListViewProductos.Columns.Add("Descripción Membresia", 500, HorizontalAlignment.Left) 'Add column 3
        ListViewProductos.Columns.Add(" Precio ", 300, HorizontalAlignment.Right) 'Add column 4

        'Use this to set the first column to be displayed as the last column
        'listViewProductos.Columns(0).DisplayIndex = ListViewProductos.Columns.Count - 1

        LlenarListViewProductos("SELECT catProductos.IDProducto, tblProductoPrecio.Precio,tblProductoPrecio.Precio2, tblProductoPrecio.IDGimnasio, catProductos.Dias, catProductos.IDTipo, catProductos.Estatus, catProductos.Descripcion, catProductos.FactorIva, catProductos.TipoCuota FROM catProductos INNER JOIN tblProductoPrecio ON catProductos.IDProducto = tblProductoPrecio.IDProducto WHERE (catProductos.IDTipo = 1 AND catProductos.Estatus = 0)order by catProductos.Descripcion")


        Me.VScrollBar1.Maximum = ListViewProductos.Items.Count()
        Me.VScrollBar1.LargeChange = 2
        ListViewProductos.Items(0).Selected = True
        ListViewProductos.Select()
        Me.Label1.Text = "ID SOCIO:  " & _Cliente & "  NOMBRE:   " & _NombreCliente


        INPUT.cbSize = Marshal.SizeOf(INPUT) '¿? PERO ES NECESARIO
        Timer1.Interval = 1000 'MONITORIZAREMOS GetLastInputInfo CADA SEGUNDO
        Timer1.Start()
    End Sub

    Private Sub ButtonRegresar_Click(sender As Object, e As EventArgs) Handles ButtonRegresar.Click
        Dim frm3 As New frmCajero3
        frm3.Show()
        frm3.Activate()
        Me.Close()
    End Sub

    Private Sub ButtonSiguiente_Click(sender As Object, e As EventArgs) Handles ButtonSiguiente.Click
        If Not String.IsNullOrEmpty(Me.TextBox1.Text) And CType(Me.TextBox1.Text, Integer) > 0 Then
            _Referencia = Date.Today & Date.Now.Millisecond
            Dim cadenaEncriptada As String = ConcatenarCadena("00" & "32029" & Me.TextBox1.Text.ToString & _Cliente & "Pago Membresia Gym" & _Referencia & "ZUAB178981")
            Dim frm5 As New frmCajero5
            With frm5
                '.Text = " .:: PUNTO DE VENTA ::."   
                ._Cadena = cadenaEncriptada
                ._Cliente = _Cliente
                ._monto = Me.TextBox1.Text
                ._Referencia = _Referencia
                .ShowInTaskbar = False
                .ShowDialog()
                .Activate()
            End With
            Me.Close()

        End If
    End Sub

    Private Sub ListViewProductos_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListViewProductos.ItemCheck
        If ListViewProductos.CheckedItems.Count = 1 AndAlso e.CurrentValue = CheckState.Unchecked Then
            e.NewValue = CheckState.Unchecked
            MessageBox.Show("Solo 1 puede ser seleccionado.")
        End If
    End Sub

    Private Sub ListViewProductos_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListViewProductos.ItemChecked
        Dim price As Double = 0.0
        Dim checkedItems As ListView.CheckedListViewItemCollection = ListViewProductos.CheckedItems
        If checkedItems.Count > 0 Then
            For Each item As ListViewItem In Me.ListViewProductos.CheckedItems
                price = Double.Parse(Me.ListViewProductos.Items(e.Item.Index).SubItems(3).Text)
                TextBox1.Text = CType(price, String)
                Me.LabelNombreMembresia.Text = Me.ListViewProductos.Items(e.Item.Index).SubItems(2).Text
            Next
        Else
            TextBox1.Text = 0
        End If
    End Sub

End Class