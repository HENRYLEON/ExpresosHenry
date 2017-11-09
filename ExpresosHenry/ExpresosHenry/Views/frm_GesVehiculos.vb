Public Class frm_GesVehiculos
    Public vg_iAccion As Integer

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim vl_sMensage As String = String.Empty
        Dim vl_oFacGenMemoria As New Fachada
        Dim vl_oVehiculo As New CVehiculo
        Try
            If (txtColor.Text = String.Empty Or txtId.Text = String.Empty Or txtModelo.Text = String.Empty Or
                txtPlaca.Text = String.Empty Or txtCantPasajeros.Text = String.Empty Or txtCantidadRuedas.Text = String.Empty) Then
                lblMesajeObligatorios.Text = "Los Campos (*) son Obligatorios."
            ElseIf Not IsNumeric(txtId.Text) Then
                Beep()
                txtId.Text = ""
                txtId.Focus()
                lblIdMensaje.Text = "Se debe ingresar solo números."
            ElseIf vl_oFacGenMemoria.ValidarVehiculo(txtId.Text, vl_sMensage) AndAlso vg_iAccion <> 2 Then
                Beep()
                lblIdMensaje.Text = "* El vehiculo ya existe"
            ElseIf (Not IsNumeric(txtCantidadRuedas.Text) And txtCantidadRuedas.Text <> String.Empty Or txtCantidadRuedas.Text <= 0) Then
                Beep()
                txtCantidadRuedas.Text = ""
                txtCantidadRuedas.Focus()
                lblcantRueMensaje.Text = "Se debe ingresar solo números mayores a cero (0)."
            ElseIf (Not IsNumeric(txtCantPasajeros.Text) AndAlso txtCantPasajeros.Text <> String.Empty Or txtCantPasajeros.Text <= 0) Then
                Beep()
                txtCantPasajeros.Text = ""
                txtCantPasajeros.Focus()
                lblCantPas.Text = "Se debe ingresar solo números mayores a cero (0)."
            ElseIf (Not IsNumeric(txtModelo.Text) And txtModelo.Text <> String.Empty Or txtModelo.Text <= 0) Then
                Beep()
                txtModelo.Text = ""
                txtModelo.Focus()
                lblCantMod.Text = "Se debe ingresar solo números mayores a cero (0)."
            Else
                vl_oVehiculo.CVehiculo(txtId.Text.Trim(), txtPlaca.Text.Trim(), txtColor.Text.Trim(), txtCantidadRuedas.Text.Trim(), txtCantPasajeros.Text.Trim(),
                                           txtModelo.Text.Trim())
                If vg_iAccion <> 2 Then
                    If vl_oFacGenMemoria.AddVehiculo(vl_oVehiculo, vl_sMensage) Then
                        If vl_sMensage = "" Then
                            MsgBox("Guardado Exitosamente.", MsgBoxStyle.OkOnly, AcceptButton)
                            Me.Close()
                        Else
                            MsgBox(vl_sMensage, MsgBoxStyle.OkOnly, AcceptButton)
                        End If
                    End If
                Else
                    If vl_oFacGenMemoria.UpDateVehiculo(vl_oVehiculo, vl_sMensage) Then
                        MsgBox("Guardado Exitosamente.", MsgBoxStyle.OkOnly, AcceptButton)
                        Me.Close()
                    End If
                End If
                If vl_sMensage <> "" Then
                    MsgBox(vl_sMensage, MsgBoxStyle.OkOnly, AcceptButton)
                End If
            End If
        Catch ex As Exception
            vl_sMensage = "Error: " + ex.ToString
            MsgBox(vl_sMensage, MsgBoxStyle.OkOnly, AcceptButton)
        End Try
    End Sub

  Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
    Me.Close()
  End Sub

  Private Sub frm_GesVehiculos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
End Class