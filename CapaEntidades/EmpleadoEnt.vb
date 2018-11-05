Public Class EmpleadoEnt
    Private _Empleados_ID As Integer
    Public Property Empleados_ID() As Integer
        Get
            Return _Empleados_ID
        End Get
        Set(ByVal value As Integer)
            _Empleados_ID = value
        End Set
    End Property


    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property
    Private _Empleados_Numero As Integer
    Public Property Empleados_Numero() As Integer
        Get
            Return _Empleados_Numero
        End Get
        Set(ByVal value As Integer)
            _Empleados_Numero = value
        End Set
    End Property

    Private _Empleados_NombreDePila As String
    Public Property Empleados_NombreDePila() As String
        Get
            Return _Empleados_NombreDePila
        End Get
        Set(ByVal value As String)
            _Empleados_NombreDePila = value
        End Set
    End Property

    Private _Empleados_NombreApPaterno As String
    Public Property Empleados_NombreApPaterno() As String
        Get
            Return _Empleados_NombreApPaterno
        End Get
        Set(ByVal value As String)
            _Empleados_NombreApPaterno = value
        End Set
    End Property

    Private _Empleados_NombreApMaterno As String
    Public Property Empleados_NombreApMaterno() As String
        Get
            Return _Empleados_NombreApMaterno
        End Get
        Set(ByVal value As String)
            _Empleados_NombreApMaterno = value
        End Set
    End Property

    Private _Empleados_Sexo As String
    Public Property Empleados_Sexo() As String
        Get
            Return _Empleados_Sexo
        End Get
        Set(ByVal value As String)
            _Empleados_Sexo = value
        End Set
    End Property


    Private _Empleados_Direccion_Calle As String
    Public Property Empleados_Direccion_Calle() As String
        Get
            Return _Empleados_Direccion_Calle
        End Get
        Set(ByVal value As String)
            _Empleados_Direccion_Calle = value
        End Set
    End Property

    Private _Empleados_Direccion_Numero As String
    Public Property Empleados_Direccion_Numero() As String
        Get
            Return _Empleados_Direccion_Numero
        End Get
        Set(ByVal value As String)
            _Empleados_Direccion_Numero = value
        End Set
    End Property

    Private _Empleados_Direccion_Colonia As String
    Public Property Empleados_Direccion_Colonia() As String
        Get
            Return _Empleados_Direccion_Colonia
        End Get
        Set(ByVal value As String)
            _Empleados_Direccion_Colonia = value
        End Set
    End Property

    Private _Empleados_Direccion_Localidad As String
    Public Property Empleados_Direccion_Localidad() As String
        Get
            Return _Empleados_Direccion_Localidad
        End Get
        Set(ByVal value As String)
            _Empleados_Direccion_Localidad = value
        End Set
    End Property

    Private _Empleados_Direccion_Municipio As String
    Public Property Empleados_Direccion_Municipio() As String
        Get
            Return _Empleados_Direccion_Municipio
        End Get
        Set(ByVal value As String)
            _Empleados_Direccion_Municipio = value
        End Set
    End Property

    Private _Empleados_Direccion_Estado As String
    Public Property Empleados_Direccion_Estado() As String
        Get
            Return _Empleados_Direccion_Estado
        End Get
        Set(ByVal value As String)
            _Empleados_Direccion_Estado = value
        End Set
    End Property


    Private _Empleados_DIreccion_CPostal As String
    Public Property Empleados_DIreccion_CPostal() As String
        Get
            Return _Empleados_DIreccion_CPostal
        End Get
        Set(ByVal value As String)
            _Empleados_DIreccion_CPostal = value
        End Set
    End Property

    Private _Empleados_eMail As String
    Public Property Empleados_eMail() As String
        Get
            Return _Empleados_eMail
        End Get
        Set(ByVal value As String)
            _Empleados_eMail = value
        End Set
    End Property

    Private _Empleados_Telefono As String
    Public Property Empleados_Telefono() As String
        Get
            Return _Empleados_Telefono
        End Get
        Set(ByVal value As String)
            _Empleados_Telefono = value
        End Set
    End Property

    Private _Empleados_Movil As String
    Public Property Empleados_Movil() As String
        Get
            Return _Empleados_Movil
        End Get
        Set(ByVal value As String)
            _Empleados_Movil = value
        End Set
    End Property

    Private _Empleados_RFC As String
    Public Property Empleados_RFC() As String
        Get
            Return _Empleados_RFC
        End Get
        Set(ByVal value As String)
            _Empleados_RFC = value
        End Set
    End Property

    Private _Empleados_CURP As String
    Public Property Empleados_CURP() As String
        Get
            Return _Empleados_CURP
        End Get
        Set(ByVal value As String)
            _Empleados_CURP = value
        End Set
    End Property

    Private _Empleados_IMSS As String
    Public Property Empleados_IMSS() As String
        Get
            Return _Empleados_IMSS
        End Get
        Set(ByVal value As String)
            _Empleados_IMSS = value
        End Set
    End Property

    Private _Empleados_FechaDeNacimiento As Date
    Public Property Empleados_FechaDeNacimiento() As Date
        Get
            Return _Empleados_FechaDeNacimiento
        End Get
        Set(ByVal value As Date)
            _Empleados_FechaDeNacimiento = value
        End Set
    End Property

    Private _Empleados_EstadoCivil As Integer
    Public Property Empleados_EstadoCivil() As Integer
        Get
            Return _Empleados_EstadoCivil
        End Get
        Set(ByVal value As Integer)
            _Empleados_EstadoCivil = value
        End Set
    End Property

    Private _Empleados_Nacionalidad As String
    Public Property Empleados_Nacionalidad() As String
        Get
            Return _Empleados_Nacionalidad
        End Get
        Set(ByVal value As String)
            _Empleados_Nacionalidad = value
        End Set
    End Property

    Private _Empleados_FechaDeAlta As Date
    Public Property Empleados_FechaDeAlta() As Date
        Get
            Return _Empleados_FechaDeAlta
        End Get
        Set(ByVal value As Date)
            _Empleados_FechaDeAlta = value
        End Set
    End Property

    Private _Empleados_Profesion As Integer
    Public Property Empleados_Profesion() As Integer
        Get
            Return _Empleados_Profesion
        End Get
        Set(ByVal value As Integer)
            _Empleados_Profesion = value
        End Set
    End Property

    Private _Empleados_Puesto As Integer
    Public Property Empleados_Puesto() As Integer
        Get
            Return _Empleados_Puesto
        End Get
        Set(ByVal value As Integer)
            _Empleados_Puesto = value
        End Set
    End Property

    Private _Empleados_Departamento As Integer
    Public Property Empleados_Departamento() As Integer
        Get
            Return _Empleados_Departamento
        End Get
        Set(ByVal value As Integer)
            _Empleados_Departamento = value
        End Set
    End Property


    Private _Empleados_AreaLaboral As String
    Public Property Empleados_AreaLaboral() As String
        Get
            Return _Empleados_AreaLaboral
        End Get
        Set(ByVal value As String)
            _Empleados_AreaLaboral = value
        End Set
    End Property

    Private _Empleados_NombrePadre As String
    Public Property Empleados_NombrePadre() As String
        Get
            Return _Empleados_NombrePadre
        End Get
        Set(ByVal value As String)
            _Empleados_NombrePadre = value
        End Set
    End Property

    Private _Empleados_NombreMadre As String
    Public Property Empleados_NombreMadre() As String
        Get
            Return _Empleados_NombreMadre
        End Get
        Set(ByVal value As String)
            _Empleados_NombreMadre = value
        End Set
    End Property

    Private _Empleados_EstatusActivo As Integer
    Public Property Empleados_EstatusActivo() As Integer
        Get
            Return _Empleados_EstatusActivo
        End Get
        Set(ByVal value As Integer)
            _Empleados_EstatusActivo = value
        End Set
    End Property


End Class
