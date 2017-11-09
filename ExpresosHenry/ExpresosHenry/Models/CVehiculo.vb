Public Class CVehiculo
    Private vg_sIdVehiculo As String
    Private vg_sPlacaVehiculo As String
    Private vg_sColorVehiculo As String
    Private vg_iCantidadRuedas As Integer
    Private vg_iCantPasajerosVeh As Integer
    Private vg_iModeloVeh As Integer

    Public Sub CVehiculo()
    End Sub

    Public Sub CVehiculo(ByVal pi_sIdVehiculot As String, ByVal pi_sPlacaVehiculo As String, ByVal pi_sColorVehiculo As String, ByVal pi_iCantidadRuedas As Integer,
                ByVal pi_iCantPasajerosVeh As Integer, ByVal pi_iModeloVeh As Integer)
        vg_sIdVehiculo = pi_sIdVehiculot
        vg_sPlacaVehiculo = pi_sPlacaVehiculo
        vg_sColorVehiculo = pi_sColorVehiculo
        vg_iCantidadRuedas = pi_iCantidadRuedas
        vg_iCantPasajerosVeh = pi_iCantPasajerosVeh
        vg_iModeloVeh = pi_iModeloVeh
    End Sub
    Public Property IdVehiculo() As String
        Get
            Return vg_sIdVehiculo
        End Get
        Set(value As String)
            vg_sIdVehiculo = value
        End Set
    End Property
    Public Property PlacaVehiculo() As String
        Get
            Return vg_sPlacaVehiculo
        End Get
        Set(value As String)
            vg_sPlacaVehiculo = value
        End Set
    End Property
    Public Property ColorVehiculo() As String
        Get
            Return vg_sColorVehiculo
        End Get
        Set(value As String)
            vg_sColorVehiculo = value
        End Set
    End Property
    Public Property CantidadRuedas() As Integer
        Get
            Return vg_iCantidadRuedas
        End Get
        Set(value As Integer)
            vg_iCantidadRuedas = value
        End Set
    End Property
    Public Property CantPasajerosVeh() As Integer
        Get
            Return vg_iCantPasajerosVeh
        End Get
        Set(value As Integer)
            vg_iCantPasajerosVeh = value
        End Set
    End Property
    Public Property ModeloVeh() As Integer
        Get
            Return vg_iModeloVeh
        End Get
        Set(value As Integer)
            vg_iModeloVeh = value
        End Set
    End Property

    Public ReadOnly Property AñosVehiculo() As Integer
        Get
            Dim vl_dNewDate As Date = Now
            Dim vl_iDiferencia As Integer = (Year(vl_dNewDate) - vg_iModeloVeh)
            Return vl_iDiferencia
        End Get
    End Property

End Class
