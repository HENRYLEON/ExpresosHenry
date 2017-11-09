Public Class frm_GesTickets
  Public vg_iAccion As Integer

  Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
    Me.Close()
  End Sub

  Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
    Dim vl_sMensaje As String = String.Empty
    Dim vl_oFachada As New Fachada
    Dim vl_oTicket As New CTicket
    Try
      If (cbxClientes.Text = String.Empty Or cbxConductor.Text = String.Empty Or cbxVehiculo.Text = String.Empty Or txtDestino.Text = String.Empty Or
         txtOrigen.Text = String.Empty) Then
      ElseIf Not IsNumeric(txtTrayecto.Text) Then
        Beep()
        txtTrayecto.Text = ""
        txtTrayecto.Focus()
        lblIdMensaje.Text = "* Se debe ingresar solo números."
      Else
        vl_oTicket.CTicket(lblNumTicket.Text.Trim(), DateTime.Now, dtpFechaSalida.Text, dtpFechaLlegada.Text, vl_oFachada.ReturnCliente(cbxClientes.SelectedValue, vl_sMensaje),
                 txtTrayecto.Text, txtOrigen.Text, txtDestino.Text, vl_oFachada.ReturnVehiculo(cbxVehiculo.SelectedValue, vl_sMensaje), vl_oFachada.ReturnUsuario(cbxConductor.SelectedValue, vl_sMensaje))
        If vg_iAccion <> 2 Then
          If vl_oFachada.AddTicket(vl_oTicket, vl_sMensaje) Then
            MsgBox("Guardado Exitosamente.", MsgBoxStyle.OkOnly, AcceptButton)
            Me.Close()
          End If
        Else
          If vl_oFachada.UpDateTicket(vl_oTicket, vl_sMensaje) Then
            MsgBox("Guardado Exitosamente.", MsgBoxStyle.OkOnly, AcceptButton)
            Me.Close()
          End If
        End If
      End If
    Catch ex As Exception
      vl_sMensaje = "Error: " + ex.ToString
      MsgBox(vl_sMensaje, MsgBoxStyle.OkOnly, AcceptButton)
    End Try
  End Sub

  Private Sub frm_GesTickets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim vl_lLisClientes As New LinkedList(Of CCliente)
    Dim vl_lLisVehiculo As New LinkedList(Of CVehiculo)
    Dim vl_lLisConductores As New LinkedList(Of CUsuario)
    Dim vl_oFachada As New Fachada
    Dim vl_oDiccionariocli As New Dictionary(Of String, String)
    Dim vl_oDiccionarioVeh As New Dictionary(Of String, String)
    Dim vl_oDiccionarioCon As New Dictionary(Of String, String)
    Dim vl_oCliente As CCliente
    Dim vl_oVehiculo As CVehiculo
    Dim vl_oConductor As CUsuario
    Dim vl_sMensajeEx As String = Nothing
    Dim vl_sMensaje As String = Nothing
    Dim vl_bNoEntrar As Boolean = False
    Dim vl_oTicket As CTicket = Nothing
    Try

      If vg_iAccion = 2 Then
        vl_oTicket = vl_oFachada.ReturnTicket(lblNumTicket.Text, vl_sMensajeEx)
      Else
        lblNumTicket.Text = vl_oFachada.GetNextId(vl_sMensajeEx)
      End If


      'Adiciona los clientes al combobox de clientes
      vl_lLisClientes = vl_oFachada.ReturnListClientes(vl_sMensajeEx)
      If vg_iAccion = 2 Then
        vl_oDiccionariocli.Add(vl_oTicket.Cliente.IdPersona, vl_oTicket.Cliente.NombrePersona & " " & vl_oTicket.Cliente.ApellidoPersona)
      Else
        vl_oDiccionariocli.Add("0", "Seleccione")
      End If

      For Each vl_oCliente In vl_lLisClientes
        If Not vl_oDiccionariocli.ContainsKey(vl_oCliente.IdPersona) Then
          vl_oDiccionariocli.Add(vl_oCliente.IdPersona, vl_oCliente.NombrePersona & " " & vl_oCliente.ApellidoPersona)
        End If
      Next
      cbxClientes.DataSource = New BindingSource(vl_oDiccionariocli, Nothing)
      cbxClientes.DisplayMember = "Value"
      cbxClientes.ValueMember = "Key"

      'Adiciona los vehiculos al combobox de Vehiculos
      vl_lLisVehiculo = vl_oFachada.ReturnListVehiculos(vl_sMensajeEx)
      If vg_iAccion = 2 Then
        vl_oDiccionarioVeh.Add(vl_oTicket.Vehiculo.IdVehiculo, vl_oTicket.Vehiculo.PlacaVehiculo)
      Else
        vl_oDiccionarioVeh.Add("0", "Seleccione")
      End If
      For Each vl_oVehiculo In vl_lLisVehiculo
        If Not vl_oDiccionarioVeh.ContainsKey(vl_oVehiculo.IdVehiculo) Then
          vl_oDiccionarioVeh.Add(vl_oVehiculo.IdVehiculo, vl_oVehiculo.PlacaVehiculo)
        End If
      Next
      cbxVehiculo.DataSource = New BindingSource(vl_oDiccionarioVeh, Nothing)
      cbxVehiculo.DisplayMember = "Value"
      cbxVehiculo.ValueMember = "Key"

      'Adiciona los conductores al combobox de Conductores
      vl_lLisConductores = vl_oFachada.ReturnListUsuarios(vl_sMensajeEx)
      If vg_iAccion = 2 Then
        vl_oDiccionarioCon.Add(vl_oTicket.Conductor.IdPersona, vl_oTicket.Conductor.NombrePersona & " " & vl_oTicket.Conductor.ApellidoPersona)
      Else
        vl_oDiccionarioCon.Add("0", "Seleccione")
      End If
      For Each vl_oConductor In vl_lLisConductores
        If Not vl_oDiccionarioCon.ContainsKey(vl_oConductor.IdPersona) Then
          vl_oDiccionarioCon.Add(vl_oConductor.IdPersona, vl_oConductor.NombrePersona & " " & vl_oConductor.ApellidoPersona)
        End If
      Next
      cbxConductor.DataSource = New BindingSource(vl_oDiccionarioCon, Nothing)
      cbxConductor.DisplayMember = "Value"
      cbxConductor.ValueMember = "Key"
      If vg_iAccion <> 2 Then
        If vl_oDiccionariocli.Count = 1 Then
          vl_bNoEntrar = True
        End If
        If vl_oDiccionarioCon.Count = 1 Then
          vl_bNoEntrar = True
        End If
        If vl_oDiccionarioVeh.Count = 1 Then
          vl_bNoEntrar = True
        End If
      End If
      If vl_bNoEntrar Then
        vl_sMensaje = "Para Generar tickes Debe tener Clientes, Conductores y Vehiculos Creados posteriormente."
        MsgBox(vl_sMensaje, MsgBoxStyle.OkOnly, AcceptButton)
        Me.Close()
      End If
    Catch ex As Exception
      vl_sMensajeEx = "Error: " + ex.ToString
      MsgBox(vl_sMensajeEx, MsgBoxStyle.OkOnly, AcceptButton)
    End Try
  End Sub

  Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
    Dim vl_sMensajeEx As String = Nothing
    Try
      If txtTrayecto.Text = String.Empty Or Not IsNumeric(txtTrayecto.Text) Then
        lblMenTrayecto.Text = "el valor debe ser Númerico."
      Else
        txtCosto.Text = txtTrayecto.Text * 1000
        lblMenTrayecto.Text = ""
      End If
    Catch ex As Exception
      vl_sMensajeEx = "Error: " + ex.ToString
      MsgBox(vl_sMensajeEx, MsgBoxStyle.OkOnly, AcceptButton)
    End Try
  End Sub
End Class