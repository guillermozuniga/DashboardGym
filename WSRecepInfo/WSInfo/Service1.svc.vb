' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.vb at the Solution Explorer and start debugging.
Imports WSInfo

Public Class WSRecInfo
    Implements IWSRecInfo

    Public Sub New()
    End Sub

    Public Function GuardarPago(folio As Integer, nombre As String, concepto As String, referencia As String, correo As String, resultado As Integer, fecha As Date, importe As Double, terminal As Integer) As Object Implements IWSRecInfo.GuardarPago
        Throw New NotImplementedException()
    End Function
End Class
