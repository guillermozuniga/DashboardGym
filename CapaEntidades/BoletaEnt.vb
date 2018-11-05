Public Class BoletaEnt
    Private _Boleta_Matricula As String
    Public Property Boleta_Matricula() As String
        Get
            Return _Boleta_Matricula
        End Get
        Set(ByVal value As String)
            _Boleta_Matricula = value
        End Set
    End Property
    Public Property Boleta_Evaluacion1() As String
    Public Property Boleta_Renglon() As Integer
    Public Property Boleta_Faltas1() As Integer
    Public Property Boleta_Parcial1Numero() As String
    Public Property Boleta_NombreMateria() As String

    Public Sub New()
    End Sub

End Class
