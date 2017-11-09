Friend Class Fachada
  Private vg_oGenMe As GeneralMemoria
  Private vg_oGenXML As GenralXml
  Private vg_oGenSQL As GeneralSQL

  Public Sub New()
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vg_oGenMe = GeneralMemoria.getIntancia()
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vg_oGenMe = GeneralMemoria.getIntancia()
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vg_oGenSQL = GeneralSQL.getIntancia()
    End If
  End Sub

#Region "Tickets"
  Public Function ValidarTicket(ByVal pi_sIdTicket As String, ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.ValidarTicket(pi_sIdTicket, po_sMensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenMe.ValidarTicket(pi_sIdTicket, po_sMensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenMe.ValidarTicket(pi_sIdTicket, po_sMensaje)
    End If
    Return vl_bRespuesta
  End Function

  Public Function AddTicket(ByVal pi_oTicket As CTicket, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_sRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_sRespuesta = vl_sRespuesta = vg_oGenMe.AddTicket(pi_oTicket, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_sRespuesta = vg_oGenXML.AddTicket(pi_oTicket, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_sRespuesta = vg_oGenSQL.AddTicket(pi_oTicket, po_sMensajeEx)
    End If
    Return vl_sRespuesta
  End Function

  Public Function ReturnListTickets(ByRef po_sMensaje As String) As LinkedList(Of CTicket)
    Dim vl_oListTickets As LinkedList(Of CTicket)
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_oListTickets = vg_oGenMe.ReturnListTickets()
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_oListTickets = vg_oGenXML.ReturnListTickets(po_sMensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_oListTickets = vg_oGenSQL.ReturnListTickets(po_sMensaje)
    End If
    Return vl_oListTickets
  End Function

  Public Function ReturnTicket(ByVal pi_sIdTicket As String, ByRef po_sMensajeEx As String) As CTicket
    Dim vl_oTicket As CTicket = Nothing
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_oTicket = vg_oGenMe.ReturnTicket(pi_sIdTicket, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_oTicket = vg_oGenXML.ReturnTicket(pi_sIdTicket, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_oTicket = vg_oGenSQL.ReturnTicket(pi_sIdTicket, po_sMensajeEx)
    End If
    Return vl_oTicket
  End Function
  Public Function UpDateTicket(pi_oTicket As CTicket, ByRef po_sMensaje As String) As Boolean
    Dim vl_sRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_sRespuesta = vg_oGenMe.UpDateTicket(pi_oTicket, po_sMensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      'vl_sRespuesta = vg_oGenXML.UpDateTicket(pi_oTicket, po_sMensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_sRespuesta = vg_oGenSQL.UpDateTicket(pi_oTicket, po_sMensaje)
    End If
    Return vl_sRespuesta
  End Function
  Public Function DeleteTicket(ByVal pi_sIdTicket As String, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_sRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_sRespuesta = vg_oGenMe.DeleteTicket(pi_sIdTicket, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_sRespuesta = vg_oGenXML.DeleteTicket(pi_sIdTicket, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
    End If
    Return vl_sRespuesta
  End Function

  Public Function GetNextId(ByRef po_sMensaje As String) As Integer
    Dim vl_iNextId As Integer
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_iNextId = vg_oGenMe.GetNextId(po_sMensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_iNextId = vg_oGenXML.GetNextId(po_sMensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_iNextId = vg_oGenSQL.GetNextId(po_sMensaje)
    End If
    Return vl_iNextId
  End Function
#End Region

#Region "Clientes"
  Public Function ValidarCliente(ByVal pi_sIdCliente As String, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.ValidarCliente(pi_sIdCliente, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.ValidarCliente(pi_sIdCliente, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.ValidarIdExiste(pi_sIdCliente, "cliente", "cliCodigo", po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function

  Public Function AddCliente(ByVal pi_oCliente As CCliente, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.AddCliente(pi_oCliente, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.AddCliente(pi_oCliente, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.AddCliente(pi_oCliente, po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function

  Public Function ReturnListClientes(ByVal po_Mensaje As String) As LinkedList(Of CCliente)
    Dim vl_oListClientes As LinkedList(Of CCliente)
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_oListClientes = vg_oGenMe.ReturnListClientes()
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_oListClientes = vg_oGenXML.ReturnListClientes(po_Mensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_oListClientes = vg_oGenSQL.ReturnListClientes(po_Mensaje)
    End If
    Return vl_oListClientes
  End Function

  Public Function ReturnCliente(ByVal pi_sIdCliente As String, ByRef po_sMensajeEx As String) As CCliente
    Dim vl_oCliente As CCliente = Nothing
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_oCliente = vg_oGenMe.ReturnCliente(pi_sIdCliente, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_oCliente = vg_oGenXML.ReturnCliente(pi_sIdCliente, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_oCliente = vg_oGenSQL.ReturnCliente(pi_sIdCliente, po_sMensajeEx)
    End If
    Return vl_oCliente
  End Function
  Public Function UpDateCliente(pi_sIdCliente As String, ByVal pi_sIdentificacion As String, pi_sTipoIdentificacion As String, ByVal pi_sNombre As String,
                            ByVal pi_sApellido As String, ByVal pi_dFechaNacimiento As Date, ByVal pi_sSexo As String, ByVal pi_sEstatura As String,
                            ByVal pi_sNacionalidad As String, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.UpDateCliente(pi_sIdCliente, pi_sIdentificacion, pi_sTipoIdentificacion, pi_sNombre, pi_sApellido, pi_dFechaNacimiento, pi_sSexo, pi_sEstatura,
                          pi_sNacionalidad, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.UpDateCliente(pi_sIdCliente, pi_sIdentificacion, pi_sTipoIdentificacion, pi_sNombre, pi_sApellido, pi_dFechaNacimiento, pi_sSexo, pi_sEstatura,
                          pi_sNacionalidad, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.UpDateCliente(pi_sIdCliente, pi_sIdentificacion, pi_sTipoIdentificacion, pi_sNombre, pi_sApellido, pi_dFechaNacimiento, pi_sSexo, pi_sEstatura,
                          pi_sNacionalidad, po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function
  Public Function DeleteCliente(ByVal pi_sIdCliente As String, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.DeleteCliente(pi_sIdCliente, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.DeleteCliente(pi_sIdCliente, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.DeleteIdExiste(pi_sIdCliente, "cliente", "cliCodigo", po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function
#End Region

#Region "Usuarios"

  Public Function ValidarUsuario(ByVal pi_sIdUsuario As String, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.ValidarUsuario(pi_sIdUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.ValidarUsuario(pi_sIdUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.ValidarIdExiste(pi_sIdUsuario, "usuario", "usuCodigo", po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function

  Public Function AddUsuario(ByVal pi_oUsuario As CUsuario, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.AddUsuario(pi_oUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.AddUsuario(pi_oUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.AddUsuario(pi_oUsuario, po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function

  Public Function ReturnListUsuarios(ByVal po_Mensaje As String) As LinkedList(Of CUsuario)
    Dim vl_oListUsuarios As LinkedList(Of CUsuario)
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_oListUsuarios = vg_oGenMe.ReturnListUsuarios()
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_oListUsuarios = vg_oGenXML.ReturnListUsuarios(po_Mensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_oListUsuarios = vg_oGenSQL.ReturnListUsuarios(po_Mensaje)
    End If
    Return vl_oListUsuarios
  End Function

  Public Function ReturnUsuario(ByVal pi_sIdUsuario As String, ByRef po_sMensajeEx As String) As CUsuario
    Dim vl_oUsuario As CUsuario = Nothing
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_oUsuario = vg_oGenMe.ReturnUsuario(pi_sIdUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_oUsuario = vg_oGenXML.ReturnUsuario(pi_sIdUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_oUsuario = vg_oGenSQL.ReturnUsuario(pi_sIdUsuario, po_sMensajeEx)
    End If
    Return vl_oUsuario
  End Function
  Public Function UpDateUsuario(ByVal pi_oUsuario As CUsuario, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.UpdateUsuario(pi_oUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.UpDateUsuario(pi_oUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.UpDateUsuario(pi_oUsuario, po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function
  Public Function DeleteUsuario(ByVal pi_sIdUsuario As String, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.DeleteUsuario(pi_sIdUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.DeleteUsuario(pi_sIdUsuario, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.DeleteIdExiste(pi_sIdUsuario, "usuario", "usuCodigo", po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function
#End Region

#Region "vehiculos"

  Public Function ReturnVehiculo(ByVal pi_sIdVehiculo As String, ByRef po_sMensajeEx As String) As CVehiculo
    Dim vl_oVehiculo As CVehiculo = Nothing
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_oVehiculo = vg_oGenMe.ReturnVehiculo(pi_sIdVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_oVehiculo = vg_oGenXML.ReturnVehiculo(pi_sIdVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_oVehiculo = vg_oGenSQL.ReturnVehiculo(pi_sIdVehiculo, po_sMensajeEx)
    End If
    Return vl_oVehiculo
  End Function

  Public Function ReturnListVehiculos(ByRef po_sMensaje As String) As LinkedList(Of CVehiculo)
    Dim vl_oListVehiculos As LinkedList(Of CVehiculo)
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_oListVehiculos = vg_oGenMe.ReturnListVehiculos()
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_oListVehiculos = vg_oGenXML.ReturnListVehiculos(po_sMensaje)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_oListVehiculos = vg_oGenSQL.ReturnListVehiculos(po_sMensaje)
    End If
    Return vl_oListVehiculos
  End Function

  Public Function ValidarVehiculo(ByVal pi_sIdVehiculo As String, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.ValidarVehiculo(pi_sIdVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.ValidarVehiculo(pi_sIdVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.ValidarIdExiste(pi_sIdVehiculo, "vehiculo", "vehCodigo", po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function

  Public Function AddVehiculo(ByVal pi_oVehiculo As CVehiculo, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.AddVehiculo(pi_oVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.AddVehiculo(pi_oVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.AddVehiculo(pi_oVehiculo, po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function

  Public Function UpDateVehiculo(pi_oVehiculo As CVehiculo, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.UpDateVehiculo(pi_oVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.UpDateVehiculo(pi_oVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.UpDateVehiculo(pi_oVehiculo, po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function

  Public Function DeleteVehiculo(ByVal pi_sIdVehiculo As String, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_bRespuesta As Boolean
    If mod_General.vg_sOpcionAlmacenamiento = 1 Then
      vl_bRespuesta = vg_oGenMe.DeleteVehiculo(pi_sIdVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 2 Then
      vl_bRespuesta = vg_oGenXML.DeleteVehiculo(pi_sIdVehiculo, po_sMensajeEx)
    ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
      vl_bRespuesta = vg_oGenSQL.DeleteIdExiste(pi_sIdVehiculo, "vehiculo", "vehCodigo", po_sMensajeEx)
    End If
    Return vl_bRespuesta
  End Function


#End Region
End Class
