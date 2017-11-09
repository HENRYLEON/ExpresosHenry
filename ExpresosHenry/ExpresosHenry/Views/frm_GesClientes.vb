Imports System.Globalization

Public Class frm_GesClientes
    Public vg_iAccion As Integer

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim vl_sMensage As String = String.Empty
        Dim vl_oFacGenMemoria As New Fachada
        Dim vl_sFecha As String
        Dim vl_dFecha As Date

        vl_sFecha = Format(dtpFecha.Value.Date, "yyyy/MM/dd").ToString()
        vl_dFecha = CDate(vl_sFecha)
        Try

            If (txtNombre.Text = String.Empty Or txtId.Text = String.Empty Or txtIdentificacion.Text = String.Empty Or
                txtApellido.Text = String.Empty Or txtNacionalidad.Text = String.Empty Or dtpFecha.Text = String.Empty) Then
                lblMesajeObligatorios.Text = "Los Campos (*) son Obligatorios."
            ElseIf Not IsNumeric(txtId.Text) Then
                Beep()
                txtId.Text = ""
                txtId.Focus()
                lblIdMensaje.Text = "Se debe ingresar solo números."
            ElseIf vl_oFacGenMemoria.ValidarCliente(txtId.Text, vl_sMensage) AndAlso vg_iAccion <> 2 Then
                Beep()
                lblIdMensaje.Text = "* El cliente ya existe"
            ElseIf (Not IsNumeric(txtEstatura.Text) And txtEstatura.Text <> String.Empty) Then
                Beep()
                txtEstatura.Text = ""
                txtEstatura.Focus()
                lblEstaturaMensaje.Text = "Se debe ingresar solo números."

            ElseIf vl_sFecha = "" Then
                Beep()
                dtpFecha.Focus()
                lblMensajeFechaN.Text = "Se debe ingresar una fecha."
            Else
                Dim vl_oCliente As New CCliente
                vl_dFecha = CDate(vl_sFecha)
                vl_oCliente.CCliente(txtId.Text, txtIdentificacion.Text, cmbTipoDocumento.Text, txtNombre.Text, txtApellido.Text, vl_dFecha, cmbSexo.Text, txtEstatura.Text,
                                 txtNacionalidad.Text)
                If vg_iAccion <> 2 Then
                    If vl_oFacGenMemoria.AddCliente(vl_oCliente, vl_sMensage) Then
                        MsgBox("Guardado Exitosamente.", MsgBoxStyle.OkOnly, AcceptButton)
                        Me.Close()
                    End If
                Else
                    If vl_oFacGenMemoria.UpDateCliente(txtId.Text, txtIdentificacion.Text, cmbTipoDocumento.Text, txtNombre.Text, txtApellido.Text, vl_dFecha, cmbSexo.Text, txtEstatura.Text,
                     txtNacionalidad.Text, vl_sMensage) Then
                        MsgBox("Guardado Exitosamente.", MsgBoxStyle.OkOnly, AcceptButton)
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            vl_sMensage = "Error: " + ex.ToString
            MsgBox(vl_sMensage, MsgBoxStyle.OkOnly, AcceptButton)
        End Try

    End Sub
End Class