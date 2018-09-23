
Public Class MateriaEnt
    Private _Materias_ID As Integer
    Public Property Materias_ID() As Integer
        Get
            Return _Materias_ID
        End Get
        Set(ByVal value As Integer)
            _Materias_ID = value
        End Set
    End Property

    Private _Materias_PlanEscolar As Integer
    Public Property Materias_PlanEscolar() As Integer
        Get
            Return _Materias_PlanEscolar
        End Get
        Set(ByVal value As Integer)
            _Materias_PlanEscolar = value
        End Set
    End Property

    Private _Materias_CicloEscolar As Integer
    Public Property Materias_CicloEscolar() As Integer
        Get
            Return _Materias_CicloEscolar
        End Get
        Set(ByVal value As Integer)
            _Materias_CicloEscolar = value
        End Set
    End Property

    Private _Materias_Nivel As Integer
    Public Property Materias_Nivel() As Integer
        Get
            Return _Materias_Nivel
        End Get
        Set(ByVal value As Integer)
            _Materias_Nivel = value
        End Set
    End Property

    Private _Materias_Materia As Integer
    Public Property Materias_Materia() As Integer
        Get
            Return _Materias_Materia
        End Get
        Set(ByVal value As Integer)
            _Materias_Materia = value
        End Set
    End Property


    Private _Materias_Nombre As String
    Public Property Materias_Nombre() As String
        Get
            Return _Materias_Nombre
        End Get
        Set(ByVal value As String)
            _Materias_Nombre = value
        End Set
    End Property

    Private _Materias_NombreCorto As String
    Public Property Materias_NombreCorto() As String
        Get
            Return _Materias_NombreCorto
        End Get
        Set(ByVal value As String)
            _Materias_NombreCorto = value
        End Set
    End Property

    Private _Materias_ClaveOficial As String
    Public Property Materias_ClaveOficial() As String
        Get
            Return _Materias_ClaveOficial
        End Get
        Set(ByVal value As String)
            _Materias_ClaveOficial = value
        End Set
    End Property

    Private _Materias_HorasTotales As String
    Public Property Materias_HorasTotales() As String
        Get
            Return _Materias_HorasTotales
        End Get
        Set(ByVal value As String)
            _Materias_HorasTotales = value
        End Set
    End Property

    Private _Materias_HorasSemana As String
    Public Property Materias_HorasSemana() As String
        Get
            Return _Materias_HorasSemana
        End Get
        Set(ByVal value As String)
            _Materias_HorasSemana = value
        End Set
    End Property

    Private _Materias_FaltasPermitidas As String
    Public Property Materias_FaltasPermitidas() As String
        Get
            Return _Materias_FaltasPermitidas
        End Get
        Set(ByVal value As String)
            _Materias_FaltasPermitidas = value
        End Set
    End Property

    Private _Materias_Creditos As String
    Public Property Materias_Creditos() As String
        Get
            Return _Materias_Creditos
        End Get
        Set(ByVal value As String)
            _Materias_Creditos = value
        End Set
    End Property

End Class
