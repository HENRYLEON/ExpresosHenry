
Public Class CPersona
  Private vg_sIdPersona As String
  Private vg_sIdentificacionPersona As String
  Private vg_sTipoIdentifiPersona As String
  Private vg_sNombrePersona As String
  Private vg_sApellidoPersona As String
  Private vg_dFechaNaciPersona As Date
  Private vg_sSexoPersona As String
  Private vg_sEstaturaPersona As String
    Private vg_sNacionalidadPersona As String

    Public Property IdPersona() As String
    Get
      Return vg_sIdPersona
    End Get
    Set(value As String)
      vg_sIdPersona = value
    End Set
  End Property
  Public Property TipoIdentifiPersona() As String
    Get
      Return vg_sTipoIdentifiPersona
    End Get
    Set(value As String)
      vg_sTipoIdentifiPersona = value
    End Set
  End Property
  Public Property IdentificacionPersona() As String
    Get
      Return vg_sIdentificacionPersona
    End Get
    Set(value As String)
      vg_sIdentificacionPersona = value
    End Set
  End Property
  Public Property NombrePersona() As String
    Get
      Return vg_sNombrePersona
    End Get
    Set(value As String)
      vg_sNombrePersona = value
    End Set
  End Property
  Public Property ApellidoPersona() As String
    Get
      Return vg_sApellidoPersona
    End Get
    Set(value As String)
      vg_sApellidoPersona = value
    End Set
  End Property

  Public Property FechaNaciPersona() As DateTime
    Get
      Return vg_dFechaNaciPersona
    End Get
    Set(value As DateTime)
      vg_dFechaNaciPersona = value
    End Set
  End Property

  Public Property SexoPersona() As String
    Get
      Return vg_sSexoPersona
    End Get
    Set(value As String)
      vg_sSexoPersona = value
    End Set
  End Property

  Public Property EstaturaPersona() As String
    Get
      Return vg_sEstaturaPersona
    End Get
    Set(value As String)
      vg_sEstaturaPersona = value
    End Set
  End Property

  Public Property NacionalidadPersona() As String
    Get
      Return vg_sNacionalidadPersona
    End Get
    Set(value As String)
      vg_sNacionalidadPersona = value
    End Set
  End Property


  Public ReadOnly Property EdadPersona() As Integer
    Get
      Dim vl_dNewDate As Date = Now
      Dim vl_iDiferencia As Long = DateDiff(DateInterval.Year, vg_dFechaNaciPersona, vl_dNewDate)
      Return vl_iDiferencia
    End Get
  End Property

    Public ReadOnly Property FechaRegistro() As String
        Get
            Dim vl_sNewDate As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            Return vl_sNewDate
        End Get
    End Property
    'vacio
    Public Sub CPersona()
  End Sub

  Public Sub CPersona(ByVal pi_sIdPersona As String, ByVal pi_sIdentificacionPersona As String, ByVal pi_sTipoIdentifiPersona As String,
                      ByVal pi_sNombrePersona As String, ByVal pi_sApellidoPersona As String, ByVal pi_dFechaNaciPersona As Date, ByVal pi_sSexoPersona As String,
                      ByVal pi_sEstaturaPersona As String, ByVal pi_sNacionalidadPersona As String)
    vg_sIdPersona = pi_sIdPersona
    vg_sIdentificacionPersona = pi_sIdentificacionPersona
    vg_sTipoIdentifiPersona = pi_sTipoIdentifiPersona
    vg_sNombrePersona = pi_sNombrePersona
    vg_sApellidoPersona = pi_sApellidoPersona
    vg_dFechaNaciPersona = pi_dFechaNaciPersona
    vg_sSexoPersona = pi_sSexoPersona
    vg_sEstaturaPersona = pi_sEstaturaPersona
    vg_sNacionalidadPersona = pi_sNacionalidadPersona
  End Sub

  Public Sub CPersona(ByVal pi_sIdPersona As String, ByVal pi_sIdentificacionPersona As String,
                      ByVal pi_sNombrePersona As String, ByVal pi_sApellidoPersona As String)
    vg_sIdPersona = pi_sIdPersona
    vg_sIdentificacionPersona = pi_sIdentificacionPersona
    vg_sNombrePersona = pi_sNombrePersona
    vg_sApellidoPersona = pi_sApellidoPersona
  End Sub

End Class
