
Public Class BancosEnt

    Private _Bancos_BancoID As Integer
    Public Property Bancos_BancoID() As Integer
        Get
            Return _Bancos_BancoID
        End Get
        Set(ByVal value As Integer)
            _Bancos_BancoID = value
        End Set
    End Property

    Private _Banco_ClaveOficial As String
    Public Property Banco_ClaveOficial() As String
        Get
            Return _Banco_ClaveOficial
        End Get
        Set(ByVal value As String)
            _Banco_ClaveOficial = value
        End Set
    End Property

    Private _Banco_Nombre As String
    Public Property Banco_Nombre() As String
        Get
            Return _Banco_Nombre
        End Get
        Set(ByVal value As String)
            _Banco_Nombre = value
        End Set
    End Property
End Class
