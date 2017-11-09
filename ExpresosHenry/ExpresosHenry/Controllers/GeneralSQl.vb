Imports System.Data.SqlClient

Public Class GeneralSQL

#Region "Patron Singleton"
  Private Shared _intanciaCSingleton As GeneralSQL = Nothing

  Public Shared Function getIntancia() As GeneralSQL
    If _intanciaCSingleton Is Nothing Then
      _intanciaCSingleton = New GeneralSQL
    End If
    Return _intanciaCSingleton
  End Function

#End Region

#Region " ATRIBUTOS "
  Private vgl_oSqlConection As GeneralSQL   'Objeto que hace referencia a la base de datos
  Private vgl_sCadenaConexion As String
  Private vgl_oConexion As New SqlClient.SqlConnection
#End Region

#Region " Constructor "
  Private Sub New()
    vgl_sCadenaConexion = mod_General.vg_sCadenaConexionSQL
    vgl_oConexion.ConnectionString = vgl_sCadenaConexion
  End Sub
#End Region

#Region "Clientes"
  Public Function AddCliente(ByVal pi_oCliente As CCliente, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Dim vl_sFecha As DateTime
    Try
      If Not pi_oCliente Is Nothing Then
        vl_sFecha = pi_oCliente.FechaRegistro
        vl_sFecha.ToString("yyyy-MM-dd HH:mm:ss")
        vl_oConeccion.ConnectionString = mod_General.vg_sCadenaConexionSQL
        vl_oConeccion.Open()
        vl_oCommnad.Connection = vl_oConeccion
        vl_sQuery = "Insert into cliente values('" & pi_oCliente.IdPersona & "','" & pi_oCliente.IdentificacionPersona &
            "','" & pi_oCliente.TipoIdentifiPersona & "','" & pi_oCliente.NombrePersona & "','" & pi_oCliente.ApellidoPersona &
            "','" & pi_oCliente.FechaNaciPersona & "','" & pi_oCliente.SexoPersona & "','" & pi_oCliente.EstaturaPersona &
            "','" & pi_oCliente.NacionalidadPersona & "','" & pi_oCliente.FechaRegistro & "')"
        vl_oCommnad.CommandText = vl_sQuery
        vl_oCommnad.ExecuteNonQuery()
        vl_bRespuesta = True
      Else
        vl_bRespuesta = False
      End If
    Catch ex As System.Exception
      po_sMensajeEx = "Error: " + ex.ToString
      vl_bRespuesta = False
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_bRespuesta
  End Function

  Public Function ReturnListClientes(ByRef po_sMensajeEx As String) As LinkedList(Of CCliente)
    Dim vl_oListaClientes As New LinkedList(Of CCliente)
    Dim vl_oCliente As CCliente = Nothing
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Dim vl_dFecha As Date
    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Select * from Cliente"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()

      While vl_oReader.Read
        vl_dFecha = CDate(vl_oReader.GetValue(5))
        vl_oCliente = New CCliente
        vl_oCliente.CCliente(vl_oReader.GetValue(0), vl_oReader.GetValue(1), vl_oReader.GetValue(2), vl_oReader.GetValue(3), vl_oReader.GetValue(4),
                             vl_dFecha, vl_oReader.GetValue(6), vl_oReader.GetValue(7), vl_oReader.GetValue(8))
        vl_oListaClientes.AddLast(vl_oCliente)
        vl_oCliente = Nothing
      End While

    Catch ex As Exception
      po_sMensajeEx = "Error: " + ex.ToString
      Return Nothing
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_oListaClientes
  End Function

  Public Function ReturnCliente(ByVal pi_sIdCliente As String, ByRef po_sMensajeEx As String) As CCliente
    Dim vl_oCliente As New CCliente
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String
    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Select * from Cliente where cliCodigo = '" & pi_sIdCliente & "'"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()

      While vl_oReader.Read

        vl_oCliente.CCliente(vl_oReader.GetValue(0), vl_oReader.GetValue(1), vl_oReader.GetValue(2), vl_oReader.GetValue(3), vl_oReader.GetValue(4),
                             vl_oReader.GetValue(5), vl_oReader.GetValue(6), vl_oReader.GetValue(7), vl_oReader.GetValue(8))
      End While

    Catch ex As Exception
      po_sMensajeEx = "Error: " + ex.ToString
      Return Nothing
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_oCliente
  End Function

  Public Function UpDateCliente(pi_sIdCliente As String, ByVal pi_sIdentificacion As String, pi_sTipoIdentificacion As String, ByVal pi_sNombre As String,
                            ByVal pi_sApellido As String, ByVal pi_dFechaNacimiento As Date, ByVal pi_sSexo As String, ByVal pi_sEstatura As String,
                            ByVal pi_sNacionalidad As String, ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Dim vl_sFecha As DateTime

    Try
      vl_sFecha.ToString("yyyy-MM-dd HH:mm:ss")
      vl_oConeccion.ConnectionString = mod_General.vg_sCadenaConexionSQL
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Update Cliente set cliIdentificacion = '" & pi_sIdentificacion & "',cliTipoIdentificacion ='" & pi_sTipoIdentificacion & "',cliNombres='" & pi_sNombre &
          "',cliApellido ='" & pi_sApellido & "',cliFechaNaci ='" & pi_dFechaNacimiento & "',cliSexo='" & pi_sSexo & "',cliEstatura ='" & pi_sEstatura & "',cliNacionalidad = '" & pi_sNacionalidad & "'" &
          "where cliCodigo = '" & pi_sIdCliente & "'"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oCommnad.ExecuteNonQuery()
      vl_bRespuesta = True
    Catch ex As Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function

#End Region

#Region "Vehiculo"
  Public Function AddVehiculo(ByVal pi_oVehiculo As CVehiculo, ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_sQuery As String = ""
    Dim vl_sDatos As String = ""
    Try
      If Not pi_oVehiculo Is Nothing Then
        vl_sDatos = "'" & pi_oVehiculo.IdVehiculo & "','" & pi_oVehiculo.PlacaVehiculo &
            "','" & pi_oVehiculo.ColorVehiculo & "','" & pi_oVehiculo.CantidadRuedas & "','" & pi_oVehiculo.CantPasajerosVeh &
            "','" & pi_oVehiculo.ModeloVeh & "','" & pi_oVehiculo.AñosVehiculo & "'"
        vl_bRespuesta = RealizarInsertUpdateDB("Vehiculo", vl_sDatos, po_sMensaje)
      Else
        vl_bRespuesta = False
      End If
    Catch ex As System.Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function

  Public Function ReturnListVehiculos(ByRef po_sMensajeEx As String) As LinkedList(Of CVehiculo)
    Dim vl_oListaVehiculos As New LinkedList(Of CVehiculo)
    Dim vl_oVehiculo As CVehiculo = Nothing
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Select * from Vehiculo"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()

      While vl_oReader.Read
        vl_oVehiculo = New CVehiculo
        vl_oVehiculo.CVehiculo(vl_oReader.GetValue(0), vl_oReader.GetValue(1), vl_oReader.GetValue(2), vl_oReader.GetValue(3), vl_oReader.GetValue(4),
                              vl_oReader.GetValue(6))
        vl_oListaVehiculos.AddLast(vl_oVehiculo)
        vl_oVehiculo = Nothing
      End While

    Catch ex As Exception
      po_sMensajeEx = "Error: " + ex.ToString
      Return Nothing
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_oListaVehiculos
  End Function

  Public Function UpDateVehiculo(pi_oVehiculo As CVehiculo, ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_sSqlCampos As String = ""
    Dim vl_sSqlDatos As String = ""
    Dim vl_sWhere As String = ""

    Try
      vl_sSqlCampos = "vehPlaca,vehColor,vehCantRuedas,vehCantPasajeros,vehModelo,vehAnios"
      vl_sSqlDatos = "'" & pi_oVehiculo.PlacaVehiculo & "','" & pi_oVehiculo.ColorVehiculo & "'," & pi_oVehiculo.CantidadRuedas & "," &
                pi_oVehiculo.CantPasajerosVeh & "," & pi_oVehiculo.ModeloVeh & "," & pi_oVehiculo.AñosVehiculo & ""
      vl_sWhere = "Where vehCodigo = '" & pi_oVehiculo.IdVehiculo & "'"

      vl_bRespuesta = RealizarInsertUpdateDB("vehiculo", vl_sSqlDatos, po_sMensaje, True, vl_sWhere, vl_sSqlCampos)

    Catch ex As Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function

  Public Function ReturnVehiculo(ByVal pi_sIdVehiculo As String, ByRef po_sMensaje As String) As CVehiculo
    Dim vl_oVehiculo As New CVehiculo
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String
    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Select * from Vehiculo where vehCodigo = '" & pi_sIdVehiculo & "'"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()

      While vl_oReader.Read
        vl_oVehiculo.CVehiculo(vl_oReader.GetValue(0), vl_oReader.GetValue(1), vl_oReader.GetValue(2), vl_oReader.GetValue(3), vl_oReader.GetValue(4),
                             vl_oReader.GetValue(5))
      End While

    Catch ex As Exception
      po_sMensaje = "Error: " + ex.ToString
      Return Nothing
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_oVehiculo
  End Function
#End Region

#Region "Usuarios"
  Public Function AddUsuario(ByVal pi_oUsuario As CUsuario, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Dim vl_sFecha As DateTime
    Try
      If Not pi_oUsuario Is Nothing Then
        vl_sFecha = pi_oUsuario.FechaRegistro
        vl_sFecha.ToString("yyyy-MM-dd HH:mm:ss")
        vl_oConeccion.ConnectionString = mod_General.vg_sCadenaConexionSQL
        vl_oConeccion.Open()
        vl_oCommnad.Connection = vl_oConeccion
        vl_sQuery = "Insert into Usuario values('" & pi_oUsuario.IdPersona & "','" & pi_oUsuario.IdentificacionPersona &
            "','" & pi_oUsuario.TipoIdentifiPersona & "','" & pi_oUsuario.NombrePersona & "','" & pi_oUsuario.ApellidoPersona &
            "','" & pi_oUsuario.FechaNaciPersona & "','" & pi_oUsuario.SexoPersona & "','" & pi_oUsuario.EstaturaPersona &
            "','" & pi_oUsuario.NacionalidadPersona & "','" & pi_oUsuario.FechaRegistro & "')"
        vl_oCommnad.CommandText = vl_sQuery
        vl_oCommnad.ExecuteNonQuery()
        vl_bRespuesta = True
      Else
        vl_bRespuesta = False
      End If
    Catch ex As System.Exception
      po_sMensajeEx = "Error: " + ex.ToString
      vl_bRespuesta = False
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_bRespuesta
  End Function

  Public Function ReturnListUsuarios(ByRef po_sMensajeEx As String) As LinkedList(Of CUsuario)
    Dim vl_oListaUsuarios As New LinkedList(Of CUsuario)
    Dim vl_oUsuario As CUsuario = Nothing
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Dim vl_dFecha As Date
    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Select * from Usuario"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()

      While vl_oReader.Read
        vl_dFecha = CDate(vl_oReader.GetValue(5))
        vl_oUsuario = New CUsuario
        vl_oUsuario.CUsuario(vl_oReader.GetValue(0), vl_oReader.GetValue(1), vl_oReader.GetValue(2), vl_oReader.GetValue(3), vl_oReader.GetValue(4),
                             vl_dFecha, vl_oReader.GetValue(6), vl_oReader.GetValue(7), vl_oReader.GetValue(8))
        vl_oListaUsuarios.AddLast(vl_oUsuario)
        vl_oUsuario = Nothing
      End While

    Catch ex As Exception
      po_sMensajeEx = "Error: " + ex.ToString
      Return Nothing
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_oListaUsuarios
  End Function

  Public Function ReturnUsuario(ByVal pi_sIdUsuario As String, ByRef po_sMensajeEx As String) As CUsuario
    Dim vl_oUsuario As New CUsuario
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String
    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Select * from Usuario where usuCodigo = '" & pi_sIdUsuario & "'"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()

      While vl_oReader.Read

        vl_oUsuario.CUsuario(vl_oReader.GetValue(0), vl_oReader.GetValue(1), vl_oReader.GetValue(2), vl_oReader.GetValue(3), vl_oReader.GetValue(4),
                             vl_oReader.GetValue(5), vl_oReader.GetValue(6), vl_oReader.GetValue(7), vl_oReader.GetValue(8))
      End While

    Catch ex As Exception
      po_sMensajeEx = "Error: " + ex.ToString
      Return Nothing
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_oUsuario
  End Function

  Public Function UpDateUsuario(pi_oUsuario As CUsuario, ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Dim vl_sFecha As DateTime

    Try
      vl_sFecha.ToString("yyyy-MM-dd HH:mm:ss")
      vl_oConeccion.ConnectionString = mod_General.vg_sCadenaConexionSQL
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Update Usuario set usuIdentificacion = '" & pi_oUsuario.IdentificacionPersona & "',usuTipoIdentificacion ='" & pi_oUsuario.TipoIdentifiPersona & "',usuNombres='" & pi_oUsuario.NombrePersona &
          "',usuApellido ='" & pi_oUsuario.ApellidoPersona & "',usuFechaNaci ='" & pi_oUsuario.FechaNaciPersona & "',usuSexo='" & pi_oUsuario.SexoPersona & "',usuEstatura ='" & pi_oUsuario.EstaturaPersona & "',usuNacionalidad = '" & pi_oUsuario.NacionalidadPersona & "'" &
          "where usuCodigo = '" & pi_oUsuario.IdPersona & "'"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oCommnad.ExecuteNonQuery()
      vl_bRespuesta = True
    Catch ex As Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function

#End Region

#Region "Tickets"
  Public Function AddTicket(ByVal pi_oTicket As CTicket, ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Dim vl_sFecha As DateTime
    Try
      If Not pi_oTicket Is Nothing Then
        vl_sFecha = pi_oTicket.FechaVenta
        vl_sFecha.ToString("yyyy-MM-dd HH:mm:ss")
        vl_oConeccion.ConnectionString = mod_General.vg_sCadenaConexionSQL
        vl_oConeccion.Open()
        vl_oCommnad.Connection = vl_oConeccion
        vl_sQuery = "Insert into ticket values('" & pi_oTicket.IdTicket & "','" & (pi_oTicket.FechaVenta).ToString("yyyy-MM-dd HH:mm:ss") &
            "','" & (pi_oTicket.FechaIniTic).ToString("yyyy-MM-dd HH:mm:ss") & "','" & (pi_oTicket.FechaFinTic).ToString("yyyy-MM-dd HH:mm:ss") & "','" &
            pi_oTicket.Cliente.IdPersona & "','" & pi_oTicket.Trayecto & "','" & pi_oTicket.LugarSalida & "','" & pi_oTicket.LugarLlegada &
            "','" & pi_oTicket.Vehiculo.IdVehiculo & "','" & pi_oTicket.Conductor.IdPersona & "','" & pi_oTicket.EstadoTicket & "','" & pi_oTicket.Costo & "','" & pi_oTicket.Impuesto & "')"
        vl_oCommnad.CommandText = vl_sQuery
        vl_oCommnad.ExecuteNonQuery()
        vl_bRespuesta = True
      Else
        vl_bRespuesta = False
      End If
    Catch ex As System.Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_bRespuesta
  End Function

  Public Function ReturnListTickets(ByRef po_sMensaje As String) As LinkedList(Of CTicket)
    Dim vl_oListaClientes As New LinkedList(Of CTicket)
    Dim vl_oTicket As CTicket = Nothing
    Dim vl_oCliente As CCliente = Nothing
    Dim vl_oUsuario As CUsuario = Nothing
    Dim vl_oVehiculo As CVehiculo = Nothing
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""

    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Select * from ticket"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()

      While vl_oReader.Read
        vl_oCliente = ReturnCliente(vl_oReader.GetValue(4), po_sMensaje)
        vl_oVehiculo = ReturnVehiculo(vl_oReader.GetValue(8), po_sMensaje)
        vl_oUsuario = ReturnUsuario(vl_oReader.GetValue(9), po_sMensaje)
        vl_oTicket = New CTicket
        vl_oTicket.CTicket(vl_oReader.GetValue(0), CDate(vl_oReader.GetValue(1)), CDate(vl_oReader.GetValue(2)), CDate(vl_oReader.GetValue(3)), vl_oCliente,
                             vl_oReader.GetValue(5), vl_oReader.GetValue(6), vl_oReader.GetValue(7), vl_oVehiculo, vl_oUsuario)
        vl_oListaClientes.AddLast(vl_oTicket)
        vl_oCliente = Nothing
        vl_oUsuario = Nothing
        vl_oVehiculo = Nothing
        vl_oTicket = Nothing
      End While

    Catch ex As Exception
      po_sMensaje = "Error: " + ex.ToString
      Return Nothing
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_oListaClientes
  End Function

  Public Function ReturnTicket(ByVal pi_sIdTicket As String, ByRef po_sMensaje As String) As CTicket
    Dim vl_oTicket As New CTicket
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String
    Dim vl_oCliente As CCliente = Nothing
    Dim vl_oUsuario As CUsuario = Nothing
    Dim vl_oVehiculo As CVehiculo = Nothing
    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Select * from ticket where ticCodigo = '" & pi_sIdTicket & "'"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()

      While vl_oReader.Read

        vl_oCliente = ReturnCliente(vl_oReader.GetValue(4), po_sMensaje)
        vl_oVehiculo = ReturnVehiculo(vl_oReader.GetValue(8), po_sMensaje)
        vl_oUsuario = ReturnUsuario(vl_oReader.GetValue(9), po_sMensaje)
        vl_oTicket = New CTicket
        vl_oTicket.CTicket(vl_oReader.GetValue(0), CDate(vl_oReader.GetValue(1)), CDate(vl_oReader.GetValue(2)), CDate(vl_oReader.GetValue(3)), vl_oCliente,
                             vl_oReader.GetValue(5), vl_oReader.GetValue(6), vl_oReader.GetValue(7), vl_oVehiculo, vl_oUsuario)
      End While

    Catch ex As Exception
      po_sMensaje = "Error: " + ex.ToString
      Return Nothing
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_oTicket
  End Function

  Public Function UpDateTicket(pi_oTicket As CTicket, ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_sSqlCampos As String = ""
    Dim vl_sSqlDatos As String = ""
    Dim vl_sWhere As String = ""
    Try
      vl_sSqlCampos = "ticFechaIni,ticFechaFin,ticTrayect,ticLugarSalida,ticLugarLlegada,vehCodigo,ticEstado,ticCosto,ticImpuesto"
      vl_sSqlDatos = "'" & pi_oTicket.FechaIniTic & "','" & pi_oTicket.FechaFinTic & "','" & pi_oTicket.Trayecto & "','" &
                pi_oTicket.LugarSalida & "','" & pi_oTicket.LugarLlegada & "','" & pi_oTicket.Vehiculo.IdVehiculo & "','" &
                pi_oTicket.EstadoTicket & "','" & pi_oTicket.Costo & "','" & pi_oTicket.Impuesto & "'"
      vl_sWhere = "Where ticCodigo = '" & pi_oTicket.IdTicket & "'"

      vl_bRespuesta = RealizarInsertUpdateDB("ticket", vl_sSqlDatos, po_sMensaje, True, vl_sWhere, vl_sSqlCampos)
    Catch ex As Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function


  Public Function GetNextId(ByRef po_sMensaje As String) As Integer
    Dim vl_iNextId As Integer
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String
    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "select top 1 ticCodigo from ticket order by ticCodigo desc"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()

      While vl_oReader.Read
        vl_iNextId = vl_oReader.GetValue(0) + 1
      End While

    Catch ex As Exception
      po_sMensaje = "Error: " + ex.ToString
      Return Nothing
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_iNextId
  End Function

#End Region

#Region "Funciones Generales"
  Public Function ValidarIdExiste(ByVal pi_sDatoId As String, ByVal pi_sTabla As String, ByVal pi_sCampo As String, ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Try
      vl_oConeccion.ConnectionString = vgl_sCadenaConexion
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      vl_sQuery = "Select * from " & pi_sTabla & "  where " & pi_sCampo & "= '" & pi_sDatoId & "'"
      vl_oCommnad.CommandText = vl_sQuery
      vl_oReader = vl_oCommnad.ExecuteReader()
      If vl_oReader.HasRows Then
        vl_bRespuesta = True
      Else
        vl_bRespuesta = False
      End If
    Catch ex As System.Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function


  Public Function DeleteIdExiste(ByVal pi_sDatoId As String, ByVal pi_sTabla As String, ByVal pi_sCampo As String, ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_iCount As Integer
    Try
      If Not pi_sDatoId Is Nothing Then
        vl_oConeccion.ConnectionString = vgl_sCadenaConexion
        vl_oConeccion.Open()
        vl_oCommnad.Connection = vl_oConeccion
        vl_oCommnad.CommandText = "Delete from " & pi_sTabla & " where " & pi_sCampo & " = '" & pi_sDatoId & "'"
        vl_iCount = vl_oCommnad.ExecuteNonQuery()
        If vl_iCount < 1 Then
          vl_bRespuesta = False
        Else
          vl_bRespuesta = True
        End If
      Else
        vl_bRespuesta = False
      End If
    Catch ex As System.Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_bRespuesta
  End Function


  Public Function RealizarInsertUpdateDB(ByVal pi_sTabla As String, ByVal pi_sDatos As String, ByRef po_sMensaje As String,
                                   Optional ByVal pi_bUpDate As Boolean = False, Optional ByVal pi_sWhere As String = "",
                                   Optional ByVal pi_sCampos As String = "") As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_oConeccion As New SqlClient.SqlConnection
    Dim vl_oCommnad As New SqlClient.SqlCommand
    Dim vl_oReader As SqlClient.SqlDataReader = Nothing
    Dim vl_sQuery As String = ""
    Dim vl_iRespuesta As Integer
    Try
      vl_oConeccion.ConnectionString = mod_General.vg_sCadenaConexionSQL
      vl_oConeccion.Open()
      vl_oCommnad.Connection = vl_oConeccion
      If Not pi_bUpDate Then
        vl_oCommnad.CommandText = "SPInsert"
      Else
        vl_oCommnad.CommandText = "SPUpDate"
      End If
      vl_oCommnad.CommandType = CommandType.StoredProcedure
      vl_oCommnad.Parameters.Add(New SqlParameter("@pisTabla", pi_sTabla))
      vl_oCommnad.Parameters.Add(New SqlParameter("@pisDatos", pi_sDatos))
      If pi_bUpDate Then
        vl_oCommnad.Parameters.Add(New SqlParameter("@pisCampos", pi_sCampos))
        vl_oCommnad.Parameters.Add(New SqlParameter("@pisWhere", pi_sWhere))
      End If
      vl_oCommnad.Parameters.Add(New SqlParameter("@posRespuesta", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output
      vl_oCommnad.Parameters.Add(New SqlParameter("@pobRespuesta", 0)).Direction = ParameterDirection.Output

      vl_oCommnad.ExecuteNonQuery()
      If Not IsDBNull(vl_oCommnad.Parameters("@posRespuesta").Value) Then
        po_sMensaje = vl_oCommnad.Parameters("@posRespuesta").Value
      End If

      vl_iRespuesta = vl_oCommnad.Parameters("@pobRespuesta").Value

      If vl_iRespuesta = 1 Then
        vl_bRespuesta = True
      Else
        vl_bRespuesta = False
      End If

    Catch ex As System.Exception
      po_sMensaje = "Error: " + ex.ToString
      po_sMensaje = po_sMensaje + pi_sTabla + "---" + pi_sCampos + "----" + pi_sDatos + "---" + pi_sWhere
      vl_bRespuesta = False
    Finally
      If Not vl_oReader Is Nothing AndAlso Not vl_oReader.IsClosed Then vl_oReader.Close()
      If Not vl_oConeccion Is Nothing AndAlso vl_oConeccion.State = ConnectionState.Open Then vl_oConeccion.Close()
    End Try
    Return vl_bRespuesta
  End Function
#End Region

End Class
