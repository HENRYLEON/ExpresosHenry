Public Class CTicket
  Private vg_sIdTicket As String
  Private vg_dFechaVentaTic As DateTime
  Private vg_dFechaIniTic As DateTime
  Private vg_dFechaFinTic As DateTime
  Private vg_oCliente As CCliente
  Private vg_dTrayecto As Decimal
  Private vg_oLugarSalida As String
  Private vg_oLugarLlegada As String
  Private vg_oVehiculo As CVehiculo
  Private vg_oConductor As CUsuario
  Private vg_sEstadoTicket As String
  Private vg_dCostoTicket As Decimal
  Private vg_dCostoImpuesto As Decimal


  Public ReadOnly Property EstadoTicket() As String
    Get
      Return vg_sEstadoTicket
    End Get
  End Property

  Private Sub CalcularCostosTicket()
    Dim vl_dCostoUnidad As Decimal
    vl_dCostoUnidad = 1000
    vg_dCostoImpuesto = (vg_dTrayecto * vl_dCostoUnidad) / 100
    vg_dCostoTicket = (vg_dTrayecto * vl_dCostoUnidad) + vg_dCostoImpuesto
  End Sub

  Public ReadOnly Property Costo() As Decimal
    Get
      Return vg_dCostoTicket
    End Get
  End Property

  Public ReadOnly Property Impuesto() As Decimal
    Get
      Return vg_dCostoImpuesto
    End Get
  End Property

  Private Sub obtenerEstado()
    If vg_dFechaVentaTic < vg_dFechaIniTic Then
      vg_sEstadoTicket = "Abierto"
    ElseIf vg_dFechaIniTic >= vg_dFechaVentaTic Then
      vg_sEstadoTicket = "En Proceso"
    ElseIf vg_dFechaFinTic >= vg_dFechaIniTic Then
      vg_sEstadoTicket = "Cerrado"
    End If
  End Sub

  Public Sub CTicket()
  End Sub

  Public Sub CTicket(ByVal pi_IdTicket As String, ByVal pi_dFechaVentaTic As DateTime, ByVal pi_dFechaIniTic As DateTime, ByVal pi_dFechaFinTic As DateTime,
                     ByVal pi_oCliente As CCliente, pi_dTrayecto As Decimal, ByVal pi_LugarSalida As String, ByVal pi_oLugarLlegada As String, ByVal pi_oVehiculo As CVehiculo, ByVal pi_oConductor As CUsuario)
    vg_sIdTicket = pi_IdTicket
    vg_dFechaVentaTic = pi_dFechaVentaTic
    vg_dFechaIniTic = pi_dFechaIniTic
    vg_dFechaFinTic = pi_dFechaFinTic
    vg_oCliente = pi_oCliente
    vg_dTrayecto = pi_dTrayecto
    vg_oLugarSalida = pi_LugarSalida
    vg_oLugarLlegada = pi_oLugarLlegada
    vg_oVehiculo = pi_oVehiculo
    vg_oConductor = pi_oConductor
    CalcularCostosTicket()
    obtenerEstado()
  End Sub

  Public Sub CTicket(ByVal pi_IdTicket As String, ByVal pi_dFechaVentaTic As DateTime, ByVal pi_dFechaIniTic As DateTime, ByVal pi_oCliente As CCliente,
                     pi_dTrayecto As Decimal, ByVal pi_LugarSalida As String, ByVal pi_oLugarLlegada As String, ByVal pi_oVehiculo As CVehiculo, ByVal pi_oConductor As CUsuario)
    vg_sIdTicket = pi_IdTicket
    vg_dFechaVentaTic = pi_dFechaVentaTic
    vg_dFechaIniTic = pi_dFechaIniTic
    vg_oCliente = pi_oCliente
    vg_dTrayecto = pi_dTrayecto
    vg_oLugarSalida = pi_LugarSalida
    vg_oLugarLlegada = pi_oLugarLlegada
    vg_oVehiculo = pi_oVehiculo
    vg_oConductor = pi_oConductor
    CalcularCostosTicket()
  End Sub

  Public Sub CTicket(ByVal pi_IdTicket As String, ByVal pi_dFechaVentaTic As DateTime, ByVal pi_dFechaIniTic As DateTime, ByVal pi_oCliente As CCliente,
                     pi_dTrayecto As Decimal, ByVal pi_LugarSalida As String, ByVal pi_oLugarLlegada As String, ByVal pi_oVehiculo As CVehiculo)
    vg_sIdTicket = pi_IdTicket
    vg_dFechaVentaTic = pi_dFechaVentaTic
    vg_dFechaIniTic = pi_dFechaIniTic
    vg_oCliente = pi_oCliente
    vg_dTrayecto = pi_dTrayecto
    vg_oLugarSalida = pi_LugarSalida
    vg_oLugarLlegada = pi_oLugarLlegada
    vg_oVehiculo = pi_oVehiculo
    CalcularCostosTicket()
  End Sub


  Public Property Conductor() As CUsuario
    Get
      Return vg_oConductor
    End Get
    Set(value As CUsuario)
      vg_oConductor = value
    End Set
  End Property
  Public Property Vehiculo() As CVehiculo
    Get
      Return vg_oVehiculo
    End Get
    Set(value As CVehiculo)
      vg_oVehiculo = value
    End Set
  End Property

  Public Property LugarLlegada() As String
    Get
      Return vg_oLugarLlegada
    End Get
    Set(value As String)
      vg_oLugarLlegada = value
    End Set
  End Property
  Public Property LugarSalida() As String
    Get
      Return vg_oLugarSalida
    End Get
    Set(value As String)
      vg_oLugarSalida = value
    End Set
  End Property


  Public Property Trayecto() As Decimal
    Get
      Return vg_dTrayecto
    End Get
    Set(value As Decimal)
      vg_dTrayecto = value
    End Set
  End Property

  Public Property Cliente() As CCliente
    Get
      Return vg_oCliente
    End Get
    Set(value As CCliente)
      vg_oCliente = value
    End Set
  End Property


  Public Property FechaFinTic() As DateTime
    Get
      Return vg_dFechaFinTic
    End Get
    Set(value As DateTime)
      vg_dFechaFinTic = value
    End Set
  End Property

  Public Property FechaIniTic() As DateTime
    Get
      Return vg_dFechaIniTic
    End Get
    Set(value As DateTime)
      vg_dFechaIniTic = value
    End Set
  End Property

  Public Property IdTicket() As String
    Get
      Return vg_sIdTicket
    End Get
    Set(value As String)
      vg_sIdTicket = value
    End Set
  End Property

  Public ReadOnly Property FechaVenta() As DateTime
    Get
      Return vg_dFechaVentaTic
    End Get
  End Property
End Class
