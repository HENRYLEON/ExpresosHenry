Public Class frm_Options


  Private Sub btnCanelar_Click(sender As Object, e As EventArgs) Handles btnCanelar.Click
    Dim resultado As String
    resultado = MsgBox("Esta seguro qeu desa salir", vbOKCancel, "CONFIRMACION")
    If resultado = vbOK Then
      Application.Exit()
    End If
  End Sub

  Private Sub btnXml_Click(sender As Object, e As EventArgs) Handles btnXml.Click
    Dim vl_sMensaje As String = ""
    CargarConfig(1, vl_sMensaje)
    Me.Close()
  End Sub

  Private Sub btnMemoria_Click(sender As Object, e As EventArgs) Handles btnMemoria.Click
    Dim vl_sMensaje As String = ""
    CargarConfig(1, vl_sMensaje)
    Me.Close()
  End Sub

  Private Sub btnSql_Click(sender As Object, e As EventArgs) Handles btnSql.Click
    Dim vl_sMensaje As String = ""
    CargarConfig(3, vl_sMensaje)
    Me.Close()
  End Sub

  Private Sub CargarConfig(ByVal pi_iOpcionAlm As Integer, ByRef po_sMensaje As String)
    Dim vl_oConfig As New CConfiguracion
    Try
      vl_oConfig.CConfiguracion(pi_iOpcionAlm, po_sMensaje)
      mod_General.vg_sOpcionAlmacenamiento = pi_iOpcionAlm
    Catch ex As Exception
      po_sMensaje = "Error: " + ex.ToString
    End Try

  End Sub

End Class