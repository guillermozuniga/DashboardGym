Public Class EmpresaEnt
    Private _Empresa_ID As Integer
    Public Property Empresa_ID() As Integer
        Get
            Return _Empresa_ID
        End Get
        Set(ByVal value As Integer)
            _Empresa_ID = value
        End Set
    End Property

    Private _Empresa_RazonSocial As String
    Public Property Empresa_RazonSocial() As String
        Get
            Return _Empresa_RazonSocial
        End Get
        Set(ByVal value As String)
            _Empresa_RazonSocial = value
        End Set
    End Property

    Private _Empresa_NombreComercial As String
    Public Property Empresa_NombreComercial() As String
        Get
            Return _Empresa_NombreComercial
        End Get
        Set(ByVal value As String)
            _Empresa_NombreComercial = value
        End Set
    End Property

    Private _Empresa_NombreCorto As String
    Public Property Empresa_NombreCorto() As String
        Get
            Return _Empresa_NombreCorto
        End Get
        Set(ByVal value As String)
            _Empresa_NombreCorto = value
        End Set
    End Property

    Private _Empresa_Direccion_Calle As String
    Public Property Empresa_Direccion_Calle() As String
        Get
            Return _Empresa_Direccion_Calle
        End Get
        Set(ByVal value As String)
            _Empresa_Direccion_Calle = value
        End Set
    End Property

    Private _Empresa_Direccion_NoExterior As String
    Public Property Empresa_Direccion_NoExterior() As String
        Get
            Return _Empresa_Direccion_NoExterior
        End Get
        Set(ByVal value As String)
            _Empresa_Direccion_NoExterior = value
        End Set
    End Property

    Private _Empresa_Direccion_NoInterior As String
    Public Property Empresa_Direccion_NoInterior() As String
        Get
            Return _Empresa_Direccion_NoInterior
        End Get
        Set(ByVal value As String)
            _Empresa_Direccion_NoInterior = value
        End Set
    End Property

    Private _Empresa_Direccion_Colonia As String
    Public Property Empresa_Direccion_Colonia() As String
        Get
            Return _Empresa_Direccion_Colonia
        End Get
        Set(ByVal value As String)
            _Empresa_Direccion_Colonia = value
        End Set
    End Property

    Private _Empresa_Direccion_Localidad As String
    Public Property Empresa_Direccion_Localidad() As String
        Get
            Return _Empresa_Direccion_Localidad
        End Get
        Set(ByVal value As String)
            _Empresa_Direccion_Localidad = value
        End Set
    End Property

    Private _Empresa_Direccion_Municipio As String
    Public Property Empresa_Direccion_Municipio() As String
        Get
            Return _Empresa_Direccion_Municipio
        End Get
        Set(ByVal value As String)
            _Empresa_Direccion_Municipio = value
        End Set
    End Property

    Private _Empresa_Direccion_Estado As String
    Public Property Empresa_Direccion_Estado() As String
        Get
            Return _Empresa_Direccion_Estado
        End Get
        Set(ByVal value As String)
            _Empresa_Direccion_Estado = value
        End Set
    End Property

    Private _Empresa_Direccion_CPostal As String
    Public Property Empresa_Direccion_CPostal() As String
        Get
            Return _Empresa_Direccion_CPostal
        End Get
        Set(ByVal value As String)
            _Empresa_Direccion_CPostal = value
        End Set
    End Property

    Private _Empresa_RFC As String
    Public Property Empresa_RFC() As String
        Get
            Return _Empresa_RFC
        End Get
        Set(ByVal value As String)
            _Empresa_RFC = value
        End Set
    End Property

    Private _Empresa_CURP As String
    Public Property Empresa_CURP() As String
        Get
            Return _Empresa_CURP
        End Get
        Set(ByVal value As String)
            _Empresa_CURP = value
        End Set
    End Property

    Private _Empresa_Telefono1 As String
    Public Property Empresa_Telefono1() As String
        Get
            Return _Empresa_Telefono1
        End Get
        Set(ByVal value As String)
            _Empresa_Telefono1 = value
        End Set
    End Property

    Private _Empresa_Telefono2 As String
    Public Property Empresa_Telefono2() As String
        Get
            Return _Empresa_Telefono2
        End Get
        Set(ByVal value As String)
            _Empresa_Telefono2 = value
        End Set
    End Property

    Private _Empresa_Telefono3 As String
    Public Property Empresa_Telefono3() As String
        Get
            Return _Empresa_Telefono3
        End Get
        Set(ByVal value As String)
            _Empresa_Telefono3 = value
        End Set
    End Property

    Private _Empresa_Movil As String
    Public Property Empresa_Movil() As String
        Get
            Return _Empresa_Movil
        End Get
        Set(ByVal value As String)
            _Empresa_Movil = value
        End Set
    End Property

    Private _Empresa_eMail As String
    Public Property Empresa_eMail() As String
        Get
            Return _Empresa_eMail
        End Get
        Set(ByVal value As String)
            _Empresa_eMail = value
        End Set
    End Property

    Private _Empresa_Dominio As String
    Public Property Empresa_Dominio() As String
        Get
            Return _Empresa_Dominio
        End Get
        Set(ByVal value As String)
            _Empresa_Dominio = value
        End Set
    End Property
    Private _Empresa_RepresentanteLegal As String
    Public Property Empresa_RepresentanteLegal() As String
        Get
            Return _Empresa_RepresentanteLegal
        End Get
        Set(ByVal value As String)
            _Empresa_RepresentanteLegal = value
        End Set
    End Property

    Private _Empresa_Representante_Legal As String
    Public Property Empresa_Representante_Legal() As String
        Get
            Return _Empresa_Representante_Legal
        End Get
        Set(ByVal value As String)
            _Empresa_Representante_Legal = value
        End Set
    End Property

    Private _Empresa_RepresentanteLegal_RFC As String
    Public Property Empresa_RepresentanteLegal_RFC() As String
        Get
            Return _Empresa_RepresentanteLegal_RFC
        End Get
        Set(ByVal value As String)
            _Empresa_RepresentanteLegal_RFC = value
        End Set
    End Property

    Private _Empresa_RepresentanteLegal_CURP As String
    Public Property Empresa_RepresentanteLegal_CURP() As String
        Get
            Return _Empresa_RepresentanteLegal_CURP
        End Get
        Set(ByVal value As String)
            _Empresa_RepresentanteLegal_CURP = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(ByVal [Empresa_ID] As Integer, ByVal [Empresa_RazonSocial] As String, ByVal [Empresa_NombreComercial] As String, ByVal [Empresa_Direccion_Calle] As String, ByVal [Empresa_Direccion_NoExterior] As String,
        ByVal [Empresa_Direccion_NoInterior] As String, ByVal [Empresa_Direccion_Colonia] As String, ByVal [Empresa_Direccion_Localidad] As String,
        ByVal [Empresa_Direccion_Municipio] As String, ByVal [Empresa_Direccion_Estado] As String, ByVal [Empresa_Direccion_CPostal] As String, ByVal [Empresa_RFC] As String,
        ByVal [Empresa_CURP] As String, ByVal [Empresa_Telefono1] As String, ByVal [Empresa_Telefono2] As String, ByVal [Empresa_Telefono3] As String, ByVal [Empresa_Movil] As String, ByVal [Empresa_eMail] As String,
        ByVal [Empresa_Dominio] As String, ByVal [Empresa_RepresentanteLegal] As String, ByVal [Empresa_RepresentanteLegal_RFC] As String, ByVal [Empresa_RepresentanteLegal_CURP] As String)


        With Me
            .Empresa_ID = [Empresa_ID]
            .Empresa_RazonSocial = [Empresa_RazonSocial]
            .Empresa_NombreComercial = [Empresa_NombreComercial]
            .Empresa_Direccion_Calle = [Empresa_Direccion_Calle]
            .Empresa_Direccion_NoExterior = [Empresa_Direccion_NoExterior]
            .Empresa_Direccion_NoInterior = [Empresa_Direccion_NoInterior]
            .Empresa_Direccion_Colonia = [Empresa_Direccion_Colonia]
            .Empresa_Direccion_Localidad = [Empresa_Direccion_Localidad]
            .Empresa_Direccion_Municipio = [Empresa_Direccion_Municipio]
            .Empresa_Direccion_Estado = [Empresa_Direccion_Estado]
            .Empresa_Direccion_CPostal = [Empresa_Direccion_CPostal]
            .Empresa_RFC = [Empresa_RFC]
            .Empresa_CURP = [Empresa_CURP]
            .Empresa_Telefono1 = [Empresa_Telefono1]
            .Empresa_Telefono2 = [Empresa_Telefono2]
            .Empresa_Telefono3 = [Empresa_Telefono3]
            .Empresa_Movil = [Empresa_Movil]
            .Empresa_eMail = [Empresa_eMail]
            .Empresa_Dominio = [Empresa_Dominio]
            .Empresa_RepresentanteLegal = [Empresa_RepresentanteLegal]
            .Empresa_RepresentanteLegal_RFC = [Empresa_RepresentanteLegal_RFC]
            .Empresa_RepresentanteLegal_CURP = [Empresa_RepresentanteLegal_CURP]
        End With
    End Sub

End Class
