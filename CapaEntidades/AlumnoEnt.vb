Public Class AlumnoEnt
    Private _Alumnos_ID As Integer

    Public Property Alumnos_ID() As Integer
        Get
            Return _Alumnos_ID
        End Get
        Set(ByVal value As Integer)
            _Alumnos_ID = value
        End Set
    End Property

    Private _Alumnos_Tutor As Integer
    Public Property Alumnos_Tutor() As Integer
        Get
            Return _Alumnos_Tutor
        End Get
        Set(ByVal value As Integer)
            _Alumnos_Tutor = value
        End Set
    End Property
    Private _Alumnos_Matricula As Integer
    Public Property Alumnos_Matricula() As Integer
        Get
            Return _Alumnos_Matricula
        End Get
        Set(ByVal value As Integer)
            _Alumnos_Matricula = value
        End Set
    End Property

    Private _Alumnos_Nivel As Integer
    Public Property Alumnos_Nivel() As Integer
        Get
            Return _Alumnos_Nivel
        End Get
        Set(ByVal value As Integer)
            _Alumnos_Nivel = value
        End Set
    End Property

    Private _Alumnos_Grado As Integer
    Public Property Alumnos_Grado() As Integer
        Get
            Return _Alumnos_Grado
        End Get
        Set(ByVal value As Integer)
            _Alumnos_Grado = value
        End Set
    End Property

    Private _Alumnos_Grupo As String
    Public Property Alumnos_Grupo() As String
        Get
            Return _Alumnos_Grupo
        End Get
        Set(ByVal value As String)
            _Alumnos_Grupo = value
        End Set
    End Property

    Private _Alumnos_NombreDePila As String
    Public Property Alumnos_NombreDePila() As String
        Get
            Return _Alumnos_NombreDePila
        End Get
        Set(ByVal value As String)
            _Alumnos_NombreDePila = value
        End Set
    End Property

    Private _Alumnos_NombreApPaterno As String
    Public Property Alumnos_NombreApPaterno() As String
        Get
            Return _Alumnos_NombreApPaterno
        End Get
        Set(ByVal value As String)
            _Alumnos_NombreApPaterno = value
        End Set
    End Property

    Private _Alumnos_NombreApMaterno As String
    Public Property Alumnos_NombreApMaterno() As String
        Get
            Return _Alumnos_NombreApMaterno
        End Get
        Set(ByVal value As String)
            _Alumnos_NombreApMaterno = value
        End Set
    End Property

    Private _Alumnos_Sexo As String
    Public Property Alumnos_Sexo() As String
        Get
            Return _Alumnos_Sexo
        End Get
        Set(ByVal value As String)
            _Alumnos_Sexo = value
        End Set
    End Property

    Private _Alumnos_FechaDeNacimiento As Date
    Public Property Alumnos_FechaDeNacimiento() As Date
        Get
            Return _Alumnos_FechaDeNacimiento
        End Get
        Set(ByVal value As Date)
            _Alumnos_FechaDeNacimiento = value
        End Set
    End Property

    Private _Alumnos_FechaDeAlta As Date
    Public Property Alumnos_FechaDeAlta() As Date
        Get
            Return _Alumnos_FechaDeAlta
        End Get
        Set(ByVal value As Date)
            _Alumnos_FechaDeAlta = value
        End Set
    End Property

    Private _Alumnos_FechaDeBaja As Date
    Public Property Alumnos_FechaDeBaja() As Date
        Get
            Return _Alumnos_FechaDeBaja
        End Get
        Set(ByVal value As Date)
            _Alumnos_FechaDeBaja = value
        End Set
    End Property
    Private _Alumnos_FechaDeReingreso As Date
    Public Property Alumnos_FechaDeReingreso() As Date
        Get
            Return _Alumnos_FechaDeReingreso
        End Get
        Set(ByVal value As Date)
            _Alumnos_FechaDeReingreso = value
        End Set
    End Property

    Private _Alumnos_CURP As String
    Public Property Alumnos_CURP() As String
        Get
            Return _Alumnos_CURP
        End Get
        Set(ByVal value As String)
            _Alumnos_CURP = value
        End Set
    End Property

    Private _Alumnos_LugarDeNacimiento As Date
    Public Property Alumnos_LugarDeNacimiento() As Date
        Get
            Return _Alumnos_LugarDeNacimiento
        End Get
        Set(ByVal value As Date)
            _Alumnos_LugarDeNacimiento = value
        End Set
    End Property

    Private _Alumnos_Nacionalidad As String
    Public Property Alumnos_Nacionalidad() As String
        Get
            Return _Alumnos_Nacionalidad
        End Get
        Set(ByVal value As String)
            _Alumnos_Nacionalidad = value
        End Set
    End Property
    Private _Alumnos_MatriculaOficial As String
    Public Property Alumnos_MatriculaOficial() As String
        Get
            Return _Alumnos_MatriculaOficial
        End Get
        Set(ByVal value As String)
            _Alumnos_MatriculaOficial = value
        End Set
    End Property

    Private _Alumnos_ClavePlanDePagos1 As Integer
    Public Property Alumnos_ClavePlanDePagos1() As Integer
        Get
            Return _Alumnos_ClavePlanDePagos1
        End Get
        Set(ByVal value As Integer)
            _Alumnos_ClavePlanDePagos1 = value
        End Set
    End Property

    Private _Alumnos_ClavePlanDePagos2 As Integer
    Public Property Alumnos_ClavePlanDePagos2() As Integer
        Get
            Return _Alumnos_ClavePlanDePagos2
        End Get
        Set(ByVal value As Integer)
            _Alumnos_ClavePlanDePagos2 = value
        End Set
    End Property

    Private _Alumnos_EsHijoDeEmpleado As Boolean
    Public Property Alumnos_EsHijoDeEmpleado() As Boolean
        Get
            Return _Alumnos_EsHijoDeEmpleado
        End Get
        Set(ByVal value As Boolean)
            _Alumnos_EsHijoDeEmpleado = value
        End Set
    End Property

    Private _Alumnos_BecaTotal As Integer
    Public Property Alumnos_BecaTotal() As Integer
        Get
            Return _Alumnos_BecaTotal
        End Get
        Set(ByVal value As Integer)
            _Alumnos_BecaTotal = value
        End Set
    End Property

    Private _Alumnos_UsuarioWEB As String
    Public Property Alumnos_UsuarioWEB() As String
        Get
            Return _Alumnos_UsuarioWEB
        End Get
        Set(ByVal value As String)
            _Alumnos_UsuarioWEB = value
        End Set
    End Property

    Private _Alumnos_PasswordWEB As String
    Public Property Alumnos_PasswordWEB() As String
        Get
            Return _Alumnos_PasswordWEB
        End Get
        Set(ByVal value As String)
            _Alumnos_PasswordWEB = value
        End Set
    End Property

    Private _Alumnos_EscuelaProcedencia As Integer
    Public Property Alumnos_EscuelaProcedencia() As Integer
        Get
            Return _Alumnos_EscuelaProcedencia
        End Get
        Set(ByVal value As Integer)
            _Alumnos_EscuelaProcedencia = value
        End Set
    End Property

    Private _Alumnos_Interface1 As String
    Public Property Alumnos_Interface1() As String
        Get
            Return _Alumnos_Interface1
        End Get
        Set(ByVal value As String)
            _Alumnos_Interface1 = value
        End Set
    End Property

    Private _Alumnos_Interface2 As String
    Public Property Alumnos_Interface2() As String
        Get
            Return _Alumnos_Interface2
        End Get
        Set(ByVal value As String)
            _Alumnos_Interface2 = value
        End Set
    End Property

    Private _Alumnos_Interface3 As String
    Public Property Alumnos_Interface3() As String
        Get
            Return _Alumnos_Interface3
        End Get
        Set(ByVal value As String)
            _Alumnos_Interface3 = value
        End Set
    End Property

    Private _Alumnos_TipoDeBeca As Integer
    Public Property Alumnos_TipoDeBeca() As Integer
        Get
            Return _Alumnos_TipoDeBeca
        End Get
        Set(ByVal value As Integer)
            _Alumnos_TipoDeBeca = value
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

    Private _Alumnos_GrupoGrado As String
    Public Property Alumnos_GrupoGrado() As String
        Get
            Return _Alumnos_GrupoGrado
        End Get
        Set(ByVal value As String)
            _Alumnos_GrupoGrado = value
        End Set
    End Property

    Private _Alumnos_NombreNivel As String
    Public Property Alumnos_NombreNivel() As String
        Get
            Return _Alumnos_NombreNivel
        End Get
        Set(ByVal value As String)
            _Alumnos_NombreNivel = value
        End Set
    End Property
End Class
