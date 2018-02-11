' NOTE: You can use the "Rename" command on the context menu to change the interface name "IService1" in both code and config file together.
<ServiceContract()>
Public Interface IWSRecInfo

    <OperationContract()>
    Function GuardarPago(ByVal folio As Integer, ByVal nombre As String, ByVal concepto As String, ByVal referencia As String, ByVal correo As String, ByVal resultado As Integer, ByVal fecha As Date, ByVal importe As Double, ByVal terminal As Integer)

    ' TODO: Add your service operations here

End Interface

' Use a data contract as illustrated in the sample below to add composite types to service operations.



<DataContract()>
Public Class CompositeType

    <DataMember()>
    Public Property BoolValue() As Boolean

    <DataMember()>
    Public Property StringValue() As String

End Class
