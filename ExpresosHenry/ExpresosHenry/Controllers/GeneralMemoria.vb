Imports System.Linq

Public Class GeneralMemoria
#Region "Patron Singleton"
    Private Shared _intanciaCSingleton As GeneralMemoria = Nothing

    Public Shared Function getIntancia() As GeneralMemoria
        If _intanciaCSingleton Is Nothing Then
            _intanciaCSingleton = New GeneralMemoria
        End If
        Return _intanciaCSingleton
    End Function

#End Region

#Region "Constructor"
    Private Sub New()

    End Sub
#End Region

#Region "Clientes"
    Private vg_oListaClientes As New LinkedList(Of CCliente)

    Public Function AddCliente(ByVal pi_oCliente As CCliente, ByRef pi_sMensajeEx As String) As Boolean
        Dim vl_bRespuesta As Boolean = False
        Try
            vg_oListaClientes.AddLast(pi_oCliente)
            vl_bRespuesta = True
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function ReturnListClientes() As LinkedList(Of CCliente)
        Return vg_oListaClientes
    End Function

    Public Function ReturnCliente(ByVal pi_sIdCliente As String, ByRef pi_sMensajeEx As String) As CCliente
        Dim Cliente As CCliente
        Try
            Cliente = (From cli As CCliente In vg_oListaClientes Where cli.IdPersona = pi_sIdCliente).FirstOrDefault
            If Not IsNothing(Cliente) Then
                Return Cliente
            Else
                Return Nothing
            End If
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ValidarCliente(ByVal pi_sIdCliente As String, ByRef pi_sMensajeEx As String) As Boolean
        Dim Cliente As CCliente
        Dim vl_bRespuesta As Boolean = False
        Try
            Cliente = (From cli As CCliente In vg_oListaClientes Where cli.IdPersona = pi_sIdCliente).FirstOrDefault
            If Not IsNothing(Cliente) Then
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function DeleteCliente(ByVal pi_sIdCliente As String, ByRef pi_sMensajeEx As String) As Boolean
        Dim Cliente As CCliente
        Dim vl_bRespuesta As Boolean = False
        Try
            Cliente = (From cli As CCliente In vg_oListaClientes Where cli.IdPersona = pi_sIdCliente).FirstOrDefault
            If Not IsNothing(Cliente) Then
                vg_oListaClientes.Remove(Cliente)
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function UpDateCliente(pi_sIdCliente As String, ByVal pi_sIdentificacion As String, pi_sTipoIdentificacion As String, ByVal pi_sNombre As String,
                                ByVal pi_sApellido As String, ByVal pi_dFechaNacimiento As Date, ByVal pi_sSexo As String, ByVal pi_sEstatura As String,
                                ByVal pi_sNacionalidad As String, ByRef pi_sMensajeEx As String) As Boolean
        Dim Cliente As CCliente
        Dim vl_bRespuesta As Boolean = False
        Try
            Cliente = (From cli As CCliente In vg_oListaClientes Where cli.IdPersona = pi_sIdCliente).FirstOrDefault
            If Not IsNothing(Cliente) Then
                Cliente.IdentificacionPersona = pi_sIdentificacion
                Cliente.TipoIdentifiPersona = pi_sTipoIdentificacion
                Cliente.NombrePersona = pi_sNombre
                Cliente.ApellidoPersona = pi_sApellido
                Cliente.FechaNaciPersona = pi_dFechaNacimiento
                Cliente.SexoPersona = pi_sSexo
                Cliente.EstaturaPersona = pi_sEstatura
                Cliente.NacionalidadPersona = pi_sNacionalidad
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function
#End Region

#Region "Usuarios"
    Private vg_oListaUsuarios As New LinkedList(Of CUsuario)

    Public Function AddUsuario(ByVal pi_oUsuario As CUsuario, ByRef pi_sMensajeEx As String) As Boolean
        Dim vl_bRespuesta As Boolean = False
        Try
            vg_oListaUsuarios.AddLast(pi_oUsuario)
            vl_bRespuesta = True
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function ReturnListUsuarios() As LinkedList(Of CUsuario)
        Return vg_oListaUsuarios
    End Function

    Public Function ReturnUsuario(ByVal pi_sIdUsuario As String, ByRef pi_sMensajeEx As String) As CUsuario
        Dim Usuario As CUsuario
        Try
            Usuario = (From usu As CUsuario In vg_oListaUsuarios Where usu.IdPersona = pi_sIdUsuario).FirstOrDefault
            If Not IsNothing(Usuario) Then
                Return Usuario
            Else
                Return Nothing
            End If
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ValidarUsuario(ByVal pi_sIdUsuario As String, ByRef pi_sMensajeEx As String) As Boolean
        Dim Usuario As CUsuario
        Dim vl_bRespuesta As Boolean = False
        Try
            Usuario = (From usu As CUsuario In vg_oListaUsuarios Where usu.IdPersona = pi_sIdUsuario).FirstOrDefault
            If Not IsNothing(Usuario) Then
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function DeleteUsuario(ByVal pi_sIdUsuario As String, ByRef pi_sMensajeEx As String) As Boolean
        Dim Usuario As CUsuario
        Dim vl_bRespuesta As Boolean = False
        Try
            Usuario = (From usu As CUsuario In vg_oListaUsuarios Where usu.IdPersona = pi_sIdUsuario).FirstOrDefault
            If Not IsNothing(Usuario) Then
                vg_oListaUsuarios.Remove(Usuario)
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

  Public Function UpdateUsuario(pi_oUsuario As CUsuario, ByRef pi_sMensajeEx As String) As Boolean
    Dim Usuario As CUsuario
    Dim vl_bRespuesta As Boolean = False
    Try
      Usuario = (From usu As CUsuario In vg_oListaUsuarios Where usu.IdPersona = pi_oUsuario.IdPersona).FirstOrDefault
      If Not IsNothing(Usuario) Then
        Usuario.IdentificacionPersona = pi_oUsuario.IdentificacionPersona
        Usuario.TipoIdentifiPersona = pi_oUsuario.TipoIdentifiPersona
        Usuario.NombrePersona = pi_oUsuario.NombrePersona
        Usuario.ApellidoPersona = pi_oUsuario.ApellidoPersona
        Usuario.FechaNaciPersona = pi_oUsuario.FechaNaciPersona
        Usuario.SexoPersona = pi_oUsuario.SexoPersona
        Usuario.EstaturaPersona = pi_oUsuario.EstaturaPersona
        Usuario.NacionalidadPersona = pi_oUsuario.NacionalidadPersona
        vl_bRespuesta = True
      Else
        vl_bRespuesta = False
      End If
    Catch ex As Exception
      pi_sMensajeEx = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function
#End Region

#Region "Vehiculos"
  Private vg_oListaVehiculos As New LinkedList(Of CVehiculo)

    Public Function AddVehiculo(ByRef pi_oVehiculo As CVehiculo, ByRef pi_sMensajeEx As String) As Boolean
        Dim vl_bRespuesta As Boolean = False
        Try
            vg_oListaVehiculos.AddLast(pi_oVehiculo)
            vl_bRespuesta = True
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function ReturnListVehiculos() As LinkedList(Of CVehiculo)
        Return vg_oListaVehiculos
    End Function

    Public Function ReturnVehiculo(ByVal pi_sIdVehiculo As String, ByRef pi_sMensajeEx As String) As CVehiculo
        Dim Vehiculo As CVehiculo
        Try
            Vehiculo = (From veh As CVehiculo In vg_oListaVehiculos Where veh.IdVehiculo = pi_sIdVehiculo).FirstOrDefault
            If Not IsNothing(Vehiculo) Then
                Return Vehiculo
            Else
                Return Nothing
            End If
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ValidarVehiculo(ByVal pi_sIdVehiculo As String, ByRef pi_sMensajeEx As String) As Boolean
        Dim Vehiculo As CVehiculo
        Dim vl_bRespuesta As Boolean = False
        Try
            Vehiculo = (From veh As CVehiculo In vg_oListaVehiculos Where veh.IdVehiculo = pi_sIdVehiculo).FirstOrDefault
            If Not IsNothing(Vehiculo) Then
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function DeleteVehiculo(ByVal pi_sIdVehiculo As String, ByRef pi_sMensajeEx As String) As Boolean
        Dim Vehiculo As CVehiculo
        Dim vl_bRespuesta As Boolean = False
        Try
            Vehiculo = (From veh As CVehiculo In vg_oListaVehiculos Where veh.IdVehiculo = pi_sIdVehiculo).FirstOrDefault
            If Not IsNothing(Vehiculo) Then
                vg_oListaVehiculos.Remove(Vehiculo)
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function UpDateVehiculo(pi_oVehiculo As CVehiculo, ByRef po_sMensajeEx As String) As Boolean
        Dim Vehiculo As CVehiculo
        Dim vl_bRespuesta As Boolean = False
        Try
            Vehiculo = (From veh As CVehiculo In vg_oListaVehiculos Where veh.IdVehiculo = pi_oVehiculo.IdVehiculo).FirstOrDefault
            If Not IsNothing(Vehiculo) Then
                Vehiculo.PlacaVehiculo = pi_oVehiculo.PlacaVehiculo
                Vehiculo.ColorVehiculo = pi_oVehiculo.ColorVehiculo
                Vehiculo.CantidadRuedas = pi_oVehiculo.CantidadRuedas
                Vehiculo.CantPasajerosVeh = pi_oVehiculo.CantPasajerosVeh
                Vehiculo.ModeloVeh = pi_oVehiculo.ModeloVeh
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            po_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function
#End Region

#Region "Tickets"
    Private vg_oListaTickets As New LinkedList(Of CTicket)
    Public Function GetNextId(ByRef pi_sMensajeEx As String) As Integer
        Dim vl_iCount As Integer = 0
        Try
            If vg_oListaTickets.Count = 0 Then
                vl_iCount = 1
            Else
                For Each ticket As CTicket In vg_oListaTickets
                    vl_iCount = vl_iCount + 1
                Next
            End If
        Catch ex As Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
        Return vl_iCount
    End Function

    Public Function AddTicket(ByRef pi_oTicket As CTicket, ByRef pi_sMensajeEx As String) As Boolean
        Dim vl_bRespuesta As Boolean = False
        Try
            vg_oListaTickets.AddLast(pi_oTicket)
            vl_bRespuesta = True
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function ReturnListTickets() As LinkedList(Of CTicket)
        Return vg_oListaTickets
    End Function

    Public Function ReturnTicket(ByVal pi_sIdTicket As String, ByRef pi_sMensajeEx As String) As CTicket
        Dim Ticket As CTicket
        Try
            Ticket = (From Tick As CTicket In vg_oListaTickets Where Tick.IdTicket = pi_sIdTicket).FirstOrDefault
            If Not IsNothing(Ticket) Then
                Return Ticket
            Else
                Return Nothing
            End If
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ValidarTicket(ByVal pi_sIdTicket As String, ByRef pi_sMensajeEx As String) As Boolean
        Dim Ticket As CTicket
        Dim vl_bRespuesta As Boolean = False
        Try
            Ticket = (From Tick As CTicket In vg_oListaTickets Where Tick.IdTicket = pi_sIdTicket).FirstOrDefault
            If Not IsNothing(Ticket) Then
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As System.Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function DeleteTicket(ByVal pi_sIdTicket As String, ByRef pi_sMensajeEx As String) As Boolean
        Dim Ticket As CTicket
        Dim vl_bRespuesta As Boolean = False
        Try
            Ticket = (From Tick As CTicket In vg_oListaTickets Where Tick.IdTicket = pi_sIdTicket).FirstOrDefault
            If Not IsNothing(Ticket) Then
                vg_oListaTickets.Remove(Ticket)
                vl_bRespuesta = True
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

  Public Function UpDateTicket(ByVal pi_oTicket As CTicket, ByRef pi_sMensaje As String) As Boolean
    Dim Ticket As CTicket
    Dim vl_bRespuesta As Boolean = False
    Try
      Ticket = (From Tick As CTicket In vg_oListaTickets Where Tick.IdTicket = pi_oTicket.IdTicket).FirstOrDefault
      If Not IsNothing(Ticket) Then
        Ticket.FechaIniTic = pi_oTicket.FechaIniTic
        Ticket.FechaFinTic = pi_oTicket.FechaFinTic
        Ticket.Trayecto = pi_oTicket.Trayecto
        Ticket.LugarSalida = pi_oTicket.LugarSalida
        Ticket.LugarLlegada = pi_oTicket.LugarLlegada
        Ticket.Vehiculo = pi_oTicket.Vehiculo
        Ticket.Conductor = pi_oTicket.Conductor
        vl_bRespuesta = True
      Else
        vl_bRespuesta = False
      End If
    Catch ex As Exception
      pi_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function
#End Region

End Class
