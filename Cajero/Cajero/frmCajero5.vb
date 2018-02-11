Imports clsComun
Imports System.IO
Imports System.Xml

Public Class frmCajero5

#Region "Declaraciones"
    Friend _Cadena As String = String.Empty
    Friend _Cliente As String = String.Empty
    Friend _monto As String = String.Empty
    Friend _Referencia As String = String.Empty
    Private Folio, Status, terminal, causa As String
#End Region


#Region "Funciones"

    Private Function ConcatenarCadena(ByVal cadena As String) As String

        Dim cadenaSHA1 As String = String.Empty
        cadenaSHA1 = clsFunciones.StringToHash(cadena)
        Return cadenaSHA1

    End Function

    Sub LeerXML2(ByVal XMLs As String)
        Dim doc As XmlDocument = New XmlDocument
        doc.LoadXml(XMLs)
        Dim xnList As XmlNodeList = doc.SelectNodes("/PVresultado")
        For Each xn As XmlNode In xnList
            Folio = xn("folio").InnerText
            Status = xn("status").InnerText
            terminal = xn("terminal").InnerText
            'Console.WriteLine("Name: {0} {1}", firstName, lastName)
            causa = xn("causaDenegada").InnerText
        Next

    End Sub

#End Region

    Private Sub frmCajero5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim id_solicitud As String = clsFunciones.PostTo("http://166.62.55.208/v2/nuevaventa.ashx", "&tipoplan=00" & "&terminal=32029" & "&importe=" & _monto & "&nombre=" & _Cliente & "&concepto=Pago Membresia Gym" & "&referencia=" & _Referencia & "&cadenaencriptada=" & _Cadena.ToLower)
        '"clave=ZUAB178981"
        Dim cadenaEncriptada As String = String.Empty
        cadenaEncriptada = ConcatenarCadena(id_solicitud & "ZUAB178981")
        Dim XML As String = "901"

        Do While XML = "901"
            'ESPERE 3 SEG
            clsFunciones.WaitSeconds(3.0)
            XML = clsFunciones.PostTo("http://166.62.55.208/v2/resultado.ashx", "&idsolicitud=" & id_solicitud & "&cadenaEncriptada=" & cadenaEncriptada)

        Loop

        ' MsgBox(XML)
        LeerXML2(XML)
        Select Case Status
            Case "1"
                'MessageBox.Show("La transaccion no fue completada", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                clsFunciones.WaitSeconds(5.0)

                Dim frmK7 As New frmCajero7
                With frmK7
                    '.Text = " .:: PUNTO DE VENTA ::."
                    ._Causa = causa
                    .ShowDialog()
                    .ShowInTaskbar = False
                    .Activate()
                End With
                clsFunciones.LiberarMemoria()
                Me.Close()

            Case "2"
                If Status = "2" Then
                    Dim frmK6 As New FrmCajero6
                    With frmK6
                        '.Text = " .:: PUNTO DE VENTA ::."              
                        .ShowInTaskbar = False
                        .ShowDialog()
                        .Activate()
                    End With
                    Me.Close()
                End If
            Case Else
                Me.Close()

        End Select

    End Sub
End Class