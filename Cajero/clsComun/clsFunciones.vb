Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient


Public Class clsFunciones
    Inherits clsConexion

    Dim cmd As SqlCommand

    Public Function SeleccionarDatos(ByVal Sentencia As String) As DataTable
        Try

            If conectadoBase() Then

                cmd = New SqlCommand(Sentencia)
                cmd.CommandType = CommandType.Text
                cmd.Connection = cnnBase
                cmd.CommandTimeout = 0

                If cmd.ExecuteNonQuery Then

                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)

                    da.Fill(dt)
                    Return dt
                Else
                    Return Nothing
                End If
            Else
                MsgBox("Ocurrio un error de Conexion", MsgBoxStyle.OkOnly, "Advertencia")
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        Finally
            DesconectadoBase()

        End Try
    End Function

    Public Shared Function convertirtextoafecha(ByVal Fecha As String) As String

        Dim cFecha As String = ""

        cFecha = Mid(Fecha, 7, 2) & "/" & Mid(Fecha, 5, 2) & "/" & Mid(Fecha, 1, 4)

        'cFecha = Mid(Fecha, 7, 4) + Mid(Fecha, 4, 2) + Mid(Fecha, 1, 2)
        Return cFecha

    End Function


    Public Shared Function StringToHash(ByVal str As String) As String
        Dim strToHash As String
        strToHash = str

        Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return (strResult)
    End Function



    Public Shared Function PostTo(ByVal url As String, ByVal postData As String) As String
        ' Create a request using a URL that can receive a post.   
        Dim request As Net.WebRequest = Net.WebRequest.Create(url)
        ' Set the Method property of the request to POST.  
        request.Method = "POST"
        ' Create POST data and convert it to a byte array.  
        ' Dim postData As String = "This is a test that posts this string to a Web server."
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        ' Set the ContentType property of the WebRequest.  
        request.ContentType = "application/x-www-form-urlencoded"
        ' Set the ContentLength property of the WebRequest.  
        request.ContentLength = byteArray.Length
        ' Get the request stream.  
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.  
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.  
        dataStream.Close()
        ' Get the response.  
        Dim response As Net.WebResponse = request.GetResponse()
        ' Display the status.  
        Console.WriteLine(DirectCast(response, Net.HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.  
        dataStream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.  
        Dim reader As New StreamReader(dataStream)
        ' Read the content.  
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.  
        'Return responseFromServer
        ' Console.WriteLine(responseFromServer)
        ' Clean up the streams.  
        reader.Close()
        dataStream.Close()
        response.Close()
        Return responseFromServer
    End Function

    Public Shared Function PostToTest(ByVal url As String, ByVal postData As String) As String
        ' Create a request for the URL. 
        Dim request As Net.WebRequest = Net.WebRequest.Create(url)
        ' If required by the server, set the credentials.
        'request.Credentials = Net.CredentialCache.DefaultCredentials
        ' Get the response.
        Dim response As Net.WebResponse = request.GetResponse()
        ' Display the status.
        Console.WriteLine(CType(response, Net.HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        Dim dataStream As Stream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        Console.WriteLine(responseFromServer)
        ' Clean up the streams and the response.
        reader.Close()
        response.Close()
        Return responseFromServer
    End Function


    Public Shared Sub WaitSeconds(ByVal nSecs As Double)
        ' Esperar los segundos indicados

        ' Crear la cadena para convertir en TimeSpan
        Dim s As String = "0.00:00:" & nSecs.ToString.Replace(",", ".")
        Dim ts As TimeSpan = TimeSpan.Parse(s)

        ' Añadirle la diferencia a la hora actual
        Dim t1 As DateTime = DateTime.Now.Add(ts)

        ' Esta asignación solo es necesaria 
        ' si la comprobación se hace al principio del bucle
        Dim t2 As DateTime = DateTime.Now

        ' Mientras no haya pasado el tiempo indicado
        Do While t2 < t1
            ' Un respiro para el sitema
            System.Windows.Forms.Application.DoEvents()
            ' Asignar la hora actual
            t2 = DateTime.Now
        Loop
    End Sub

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Shared Sub LiberarMemoria()

        Try

            Dim memoria As Process
            memoria = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(memoria.Handle, -1, -1)

        Catch ex As Exception

        End Try

    End Sub
End Class
