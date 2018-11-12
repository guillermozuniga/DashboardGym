Public Class SeccionesEnt
    Private _Nivel_Descripcion As String
    Public Property Nivel_Descripcion() As String
        Get
            Return _Nivel_Descripcion
        End Get
        Set(ByVal value As String)
            _Nivel_Descripcion = value
        End Set
    End Property

    Private _Nivel_Clave As String
    Public Property Nivel_Clave() As String
        Get
            Return _Nivel_Clave
        End Get
        Set(ByVal value As String)
            _Nivel_Clave = value
        End Set
    End Property

    Private _Nivel_Grados As String
    Public Property Nivel_Grados() As String
        Get
            Return _Nivel_Grados
        End Get
        Set(ByVal value As String)
            _Nivel_Grados = value
        End Set
    End Property
    Private _Nivel_GradoInicial As String
    Public Property Nivel_GradoInicial() As String
        Get
            Return _Nivel_GradoInicial
        End Get
        Set(ByVal value As String)
            _Nivel_GradoInicial = value
        End Set
    End Property

    Private _Nivel_Periodos As String
    Public Property Nivel_Periodos() As String
        Get
            Return _Nivel_Periodos
        End Get
        Set(ByVal value As String)
            _Nivel_Periodos = value
        End Set
    End Property

    Private _Nivel_EvaluacionesPoPeriodo As String
    Public Property Nivel_EvaluacionesPorPeriodo() As String
        Get
            Return _Nivel_EvaluacionesPoPeriodo
        End Get
        Set(ByVal value As String)
            _Nivel_EvaluacionesPoPeriodo = value
        End Set
    End Property

    Private _Nivel_SistemaOficial As String
    Public Property Nivel_SistemaOficial() As String
        Get
            Return _Nivel_SistemaOficial
        End Get
        Set(ByVal value As String)
            _Nivel_SistemaOficial = value
        End Set
    End Property

    Private _Nivel_NombreComercial As String
    Public Property Nivel_NombreComercial() As String
        Get
            Return _Nivel_NombreComercial
        End Get
        Set(ByVal value As String)
            _Nivel_NombreComercial = value
        End Set
    End Property

    Public Property Nivel_RazonSocial() As String
    Public Property Nivel_Direccion_Calle() As String
    Public Property Nivel_Direccion_NoExterior() As String
    Public Property Nivel_Direccion_NoInterior() As String
    Public Property Nivel_Direccion_Colonia() As String
    Public Property Nivel_Direccion_localidad() As String
    Public Property Nivel_Direccion_Municipio() As String
    Public Property Nivel_Direccion_Estado() As String
    Public Property Nivel_Direccion_Cpostal() As String
    Public Property Nivel_RFC() As String
    Public Property Nivel_CURP() As String
    Public Property Nivel_Telefono1() As String
    Public Property Nivel_Telefono2() As String
    Public Property Nivel_Telefono3() As String
    Public Property Nivel_Movil() As String
    Public Property Nivel_eMail() As String
    Public Property Nivel_Dominio() As String
    Public Property Nivel_RepresentanteLegal() As String
    Public Property Nivel_RepresentanteLegal_RFC() As String
    Public Property Nivel_RepresentanteLegal_Curp() As String
    Public Property Nivel_BancoID() As Integer
    Public Property Nivel_ID() As Integer

End Class
