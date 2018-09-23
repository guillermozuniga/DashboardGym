Public Class PagoEnt
    Private _Abonos_ID As Integer
    Public Property Abonos_ID() As Integer
        Get
            Return _Abonos_ID
        End Get
        Set(ByVal value As Integer)
            _Abonos_ID = value
        End Set
    End Property

    Private _Abonos_CicloEscolar As String
    Public Property Abonos_CicloEscolar() As String
        Get
            Return _Abonos_CicloEscolar
        End Get
        Set(ByVal value As String)
            _Abonos_CicloEscolar = value
        End Set
    End Property

    Private _Abonos_Matricula As Integer
    Public Property Abonos_Matricula() As Integer
        Get
            Return _Abonos_Matricula
        End Get
        Set(ByVal value As Integer)
            _Abonos_Matricula = value
        End Set
    End Property
    Private _Abonos_Nivel As Integer
    Public Property Abonos_Nivel() As Integer
        Get
            Return _Abonos_Nivel
        End Get
        Set(ByVal value As Integer)
            _Abonos_Nivel = value
        End Set
    End Property

    Private _Abonos_Clave As String
    Public Property Abonos_Clave() As String
        Get
            Return _Abonos_Clave
        End Get
        Set(ByVal value As String)
            _Abonos_Clave = value
        End Set
    End Property

    Private _Abonos_FechaDePago As String
    Public Property Abonos_FechadePago() As String
        Get
            Return _Abonos_FechaDePago
        End Get
        Set(ByVal value As String)
            _Abonos_FechaDePago = value
        End Set
    End Property

    Private _Abonos_Importe As Decimal
    Public Property Abonos_Importe() As Decimal
        Get
            Return _Abonos_Importe
        End Get
        Set(ByVal value As Decimal)
            _Abonos_Importe = value
        End Set
    End Property

    Private _Abonos_Recargos As Decimal
    Public Property Abonos_Recargos() As Decimal
        Get
            Return _Abonos_Recargos
        End Get
        Set(ByVal value As Decimal)
            _Abonos_Recargos = value
        End Set
    End Property

    Private _Abonos_Descuentos As Decimal
    Public Property Abonos_Descuento() As Decimal
        Get
            Return _Abonos_Descuentos
        End Get
        Set(ByVal value As Decimal)
            _Abonos_Descuentos = value
        End Set
    End Property

    Private _Abonos_Devoluvion As Decimal
    Public Property Abonos_Devolucion() As Decimal
        Get
            Return _Abonos_Devoluvion
        End Get
        Set(ByVal value As Decimal)
            _Abonos_Devoluvion = value
        End Set
    End Property

    Private _Abonos_ComisionBancaria As Decimal
    Public Property Abonos_ComisionBancaria() As Decimal
        Get
            Return _Abonos_ComisionBancaria
        End Get
        Set(ByVal value As Decimal)
            _Abonos_ComisionBancaria = value
        End Set
    End Property

    Private _Abono_PagoExtra As Decimal
    Public Property Abono_pagoExtra() As Decimal
        Get
            Return _Abono_PagoExtra
        End Get
        Set(ByVal value As Decimal)
            _Abono_PagoExtra = value
        End Set
    End Property

    Private _Abonos_Secuencia As Integer
    Public Property Abonos_secuencia() As Integer
        Get
            Return _Abonos_Secuencia
        End Get
        Set(ByVal value As Integer)
            _Abonos_Secuencia = value
        End Set
    End Property

    Private _Abonos_Origen As Integer
    Public Property Abonos_Origen() As Integer
        Get
            Return _Abonos_Origen
        End Get
        Set(ByVal value As Integer)
            _Abonos_Origen = value
        End Set
    End Property

    Private _Abonos_TipoDePago As Integer
    Public Property Abonos_TipoDePago() As Integer
        Get
            Return _Abonos_TipoDePago
        End Get
        Set(ByVal value As Integer)
            _Abonos_TipoDePago = value
        End Set
    End Property

    Private _Abonos_Factura As String
    Public Property Abonos_Factura() As String
        Get
            Return _Abonos_Factura
        End Get
        Set(ByVal value As String)
            _Abonos_Factura = value
        End Set
    End Property

    Private _Abonos_Folio As String
    Public Property Abonos_Folio() As String
        Get
            Return _Abonos_Folio
        End Get
        Set(ByVal value As String)
            _Abonos_Folio = value
        End Set
    End Property

    Private _Abonos_BancoSecuencia As String
    Public Property Abonos_BancoSecuencia() As String
        Get
            Return _Abonos_BancoSecuencia
        End Get
        Set(ByVal value As String)
            _Abonos_BancoSecuencia = value
        End Set
    End Property

    Private _Abonos_Actualizado As Integer
    Public Property Abonos_Actualizado() As Integer
        Get
            Return _Abonos_Actualizado
        End Get
        Set(ByVal value As Integer)
            _Abonos_Actualizado = value
        End Set
    End Property

    Public Sub New(ByVal [Abonos_ID] As Integer, ByVal [Abonos_CicloEscolar] As String, ByVal [Abonos_Matricula] As Integer, ByVal [Abonos_Nivel] As Integer, ByVal [Abonos_Clave] As Integer, ByVal [Abonos_FechadePago] As Date, ByVal [Abonos_Importe] As Decimal, ByVal [Abonos_Recargos] As Decimal, ByVal [Abonos_Descuento] As Decimal,
    ByVal [Abonos_Devolucion] As Decimal, ByVal [Abonos_ComisionBancaria] As Decimal, ByVal [Abonos_PagoExtra] As Decimal, ByVal [Abonos_secuencia] As Integer, ByVal [Abonos_Origen] As Integer, ByVal [Abonos_TipoDePago] As Integer, ByVal [Abonos_Factura] As Integer, ByVal [Abonos_Folio] As Integer,
    ByVal [Abonos_BancoSecuencia] As Integer, ByVal [Abonos_Actualizado] As Integer)

        With Me
            .Abonos_ID = [Abonos_ID]
            .Abonos_CicloEscolar = [Abonos_CicloEscolar]
            .Abonos_Matricula = [Abonos_Matricula]
            .Abonos_Nivel = [Abonos_Nivel]
            .Abonos_Clave = [Abonos_Clave]
            .Abonos_FechadePago = [Abonos_FechadePago]
            .Abonos_Importe = [Abonos_Importe]
            .Abonos_Recargos = [Abonos_Recargos]
            .Abonos_Descuento = [Abonos_Descuento]
            .Abonos_Devolucion = [Abonos_Devolucion]
            .Abonos_ComisionBancaria = [Abonos_ComisionBancaria]
            .Abono_pagoExtra = [Abonos_PagoExtra]
            .Abonos_secuencia = [Abonos_secuencia]
            .Abonos_Origen = [Abonos_Origen]
            .Abonos_TipoDePago = [Abonos_TipoDePago]
            .Abonos_Factura = [Abonos_Factura]
            .Abonos_Folio = [Abonos_Folio]
            .Abonos_BancoSecuencia = [Abonos_BancoSecuencia]
            .Abonos_Actualizado = [Abonos_Actualizado]

        End With

    End Sub
End Class
