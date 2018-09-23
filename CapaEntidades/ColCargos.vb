Public Class ColCargos

    Private _Cargos_ID As Integer
    Public Property Cargos_ID() As Integer
        Get
            Return _Cargos_ID
        End Get
        Set(ByVal value As Integer)
            _Cargos_ID = value
        End Set
    End Property

    Private _Cargos_CicloEscolar As String
    Public Property Cargos_Cicloescolar() As String
        Get
            Return _Cargos_CicloEscolar
        End Get
        Set(ByVal value As String)
            _Cargos_CicloEscolar = value
        End Set
    End Property

    Private _Cargos_Nivel As Integer
    Public Property Cargos_Nivel() As Integer
        Get
            Return _Cargos_Nivel
        End Get
        Set(ByVal value As Integer)
            _Cargos_Nivel = value
        End Set
    End Property

    Private _Cargos_Clave As Integer
    Public Property Cargos_Clave() As Integer
        Get
            Return _Cargos_Clave
        End Get
        Set(ByVal value As Integer)
            _Cargos_Clave = value
        End Set
    End Property

    Private _Cargos_Matricula As Integer
    Public Property Cargos_Matricula() As Integer
        Get
            Return _Cargos_Matricula
        End Get
        Set(ByVal value As Integer)
            _Cargos_Matricula = value
        End Set
    End Property

    Private _Cargos_Grado As Integer
    Public Property Cargos_Grado() As Integer
        Get
            Return _Cargos_Grado
        End Get
        Set(ByVal value As Integer)
            _Cargos_Grado = value
        End Set
    End Property

    Private _Cargos_Grupo As Integer
    Public Property Cargos_Grupo() As Integer
        Get
            Return _Cargos_Grupo
        End Get
        Set(ByVal value As Integer)
            _Cargos_Grupo = value
        End Set
    End Property


    Private _Cargos_FechaVencimiento As Date
    Public Property Cargos_FechaVencimiento() As Date
        Get
            Return _Cargos_FechaVencimiento
        End Get
        Set(ByVal value As Date)
            _Cargos_FechaVencimiento = value
        End Set
    End Property

    Private _Cargos_FechaPago As Date
    Public Property Cargos_FechaPago() As Date
        Get
            Return _Cargos_FechaPago
        End Get
        Set(ByVal value As Date)
            _Cargos_FechaPago = value
        End Set
    End Property

    Private _Cargos_Importe As Decimal
    Public Property Cargos_Importe() As Decimal
        Get
            Return _Cargos_Importe
        End Get
        Set(ByVal value As Decimal)
            _Cargos_Importe = value
        End Set
    End Property

    Private _Cargos_Saldo As Decimal
    Public Property Cargos_Saldo() As Decimal
        Get
            Return _Cargos_Saldo
        End Get
        Set(ByVal value As Decimal)
            _Cargos_Saldo = value
        End Set
    End Property

    Private _Cargos_Recargos As Decimal
    Public Property Cargos_Recargos() As Decimal
        Get
            Return _Cargos_Recargos
        End Get
        Set(ByVal value As Decimal)
            _Cargos_Recargos = value
        End Set
    End Property

    Private _Cargos_Descuento As Decimal
    Public Property Cargos_Descuento() As Decimal
        Get
            Return _Cargos_Descuento
        End Get
        Set(ByVal value As Decimal)
            _Cargos_Descuento = value
        End Set
    End Property

    Private _Cargos_ComisionBancaria As Decimal
    Public Property Cargos_ComisionBancaria() As Decimal
        Get
            Return _Cargos_ComisionBancaria
        End Get
        Set(ByVal value As Decimal)
            _Cargos_ComisionBancaria = value
        End Set
    End Property

    Private _Cargos_PagoExtra As Decimal
    Public Property Cargos_PagoExtra() As Decimal
        Get
            Return _Cargos_PagoExtra
        End Get
        Set(ByVal value As Decimal)
            _Cargos_PagoExtra = value
        End Set
    End Property

    Private _Cargos_Devolucion As Decimal
    Public Property Cargos_Devolucion() As Decimal
        Get
            Return _Cargos_Devolucion
        End Get
        Set(ByVal value As Decimal)
            _Cargos_Devolucion = value
        End Set
    End Property

    Private _Cargos_Fijo As Boolean
    Public Property Cargos_Fijo() As Boolean
        Get
            Return _Cargos_Fijo
        End Get
        Set(ByVal value As Boolean)
            _Cargos_Fijo = value
        End Set
    End Property


    Private _Cargos_Facturado As Boolean
    Public Property Cargos_Facturado() As Boolean
        Get
            Return _Cargos_Facturado
        End Get
        Set(ByVal value As Boolean)
            _Cargos_Facturado = value
        End Set
    End Property

    Private _Cargos_Actualizado As Boolean
    Public Property Cargos_Actualizado() As Boolean
        Get
            Return _Cargos_Actualizado
        End Get
        Set(ByVal value As Boolean)
            _Cargos_Actualizado = value
        End Set
    End Property

    Private _Cargos_Control As Boolean
    Public Property Cargos_Control() As Boolean
        Get
            Return _Cargos_Control
        End Get
        Set(ByVal value As Boolean)
            _Cargos_Control = value
        End Set
    End Property


    Public Sub New()
    End Sub


    Public Sub New(ByVal Cargos_ID As Integer, ByVal Cargos_CicloEscolar As String, ByVal Cargos_Nivel As Integer,
                   ByVal Cargos_Clave As Integer, ByVal [Cargos_Matricula] As Integer, ByVal [Cargos_Grado] As Integer, ByVal [Cargos_Grupo] As String, ByVal [Cargos_FechaDeVencimiento] As Date,
                   ByVal [Cargos_FechaDePago] As Date, ByVal [Cargos_Importe] As Decimal, ByVal [Cargos_Saldo] As Decimal, ByVal [Cargos_Recargos] As Decimal, ByVal [Cargos_Descuento] As Decimal,
                   ByVal [Cargos_ComisionBancaria] As Decimal, ByVal [Cargos_PagoExtra] As Decimal, ByVal [Cargos_Devolucion] As Decimal, ByVal [Cargos_Fijo] As Integer, ByVal [Cargos_Facturado] As Integer, ByVal [Cargos_Actualizado] As Integer, ByVal [Cargos_Control] As Integer)

        Me.Cargos_ID = Cargos_ID
        Me.Cargos_Cicloescolar = Cargos_CicloEscolar
        Me.Cargos_Nivel = Cargos_Nivel
        Me.Cargos_Clave = Cargos_Clave
        Me.Cargos_Matricula = Cargos_Matricula
        Me.Cargos_Grado = Cargos_Grado
        Me.Cargos_Grupo = Cargos_Grupo
        Me.Cargos_FechaVencimiento = Cargos_FechaVencimiento
        Me.Cargos_FechaPago = Cargos_FechaPago
        Me.Cargos_Importe = Cargos_Importe
        Me.Cargos_Saldo = Cargos_Saldo
        Me.Cargos_Recargos = Cargos_Recargos
        Me.Cargos_Descuento = Cargos_Descuento
        Me.Cargos_Devolucion = Cargos_Devolucion
        Me.Cargos_ComisionBancaria = Cargos_ComisionBancaria
        Me.Cargos_PagoExtra = Cargos_PagoExtra
        Me.Cargos_Fijo = Cargos_Fijo
        Me.Cargos_Actualizado = Cargos_Actualizado
        Me.Cargos_Control = Cargos_Control
        Me.Cargos_Facturado = Cargos_Facturado

    End Sub

End Class
