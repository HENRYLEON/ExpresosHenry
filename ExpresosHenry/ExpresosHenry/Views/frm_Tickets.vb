Public Class frm_Tickets
  Private vg_oFachada As New Fachada
  Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
    Dim vl_oForm As Form = GetFormByName("frm_GesTickets")

    If (vl_oForm Is Nothing) Then
      vl_oForm = New frm_GesTickets
      vl_oForm.ShowDialog()
    Else
      vl_oForm.Select()
    End If
  End Sub
  Public Function GetFormByName(formName As String) As Form
    If (formName = String.Empty) Then Return Nothing
    For Each frm As Form In Application.OpenForms
      If (frm.Name.ToUpperInvariant() = formName.ToUpperInvariant()) Then
        Return frm
      End If
    Next
    Return Nothing
  End Function

  Private Sub frm_Tickets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    llenarDataGrid()
  End Sub

  Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
    llenarDataGrid()
  End Sub

  Private Sub dtgTickets_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTickets.CellClick
    Dim vl_oFachada As New Fachada
    Dim vl_oTicket As CTicket
    Dim vl_oFormTickets As New frm_GesTickets
    Dim vl_sMensaje As String = Nothing
    Dim vl_sIdTicket As String = dtgTickets.Item(0, e.RowIndex).Value
    Dim vl_oForm As Form = GetFormByName("frm_GesTickets")
    Try
      If (vl_oForm Is Nothing) Then
        'Editar
        If e.ColumnIndex = 7 Then
          If vl_sIdTicket <> "" Then
            vl_oTicket = vl_oFachada.ReturnTicket(vl_sIdTicket, vl_sMensaje)
            vl_oFormTickets.lblNumTicket.Text = vl_sIdTicket
            vl_oFormTickets.txtTrayecto.Text = vl_oTicket.Trayecto
            vl_oFormTickets.txtDestino.Text = vl_oTicket.LugarLlegada
            vl_oFormTickets.txtOrigen.Text = vl_oTicket.LugarSalida
            vl_oFormTickets.vg_iAccion = 2
            vl_oFormTickets.Show()
          End If
        ElseIf e.ColumnIndex = 8 Then
          Dim result As Integer = MessageBox.Show("¿Estas seguro de eliminar el Ticket?", "caption", MessageBoxButtons.YesNo)
          If result = DialogResult.No Then
            MessageBox.Show("Ticket NO eliminado.")
          ElseIf result = DialogResult.Yes Then
            If vl_sIdTicket <> "" Then
              If (vl_oFachada.DeleteTicket(vl_sIdTicket, vl_sMensaje)) Then
                'vl_oFachada.DeleteTicket(rowToDelete, vl_sMensajeEx)
                MessageBox.Show("Se elimino correctamente.")
              Else
                MessageBox.Show("Se elimino correctamente.")
              End If
            End If
          End If
        ElseIf e.ColumnIndex = 9 Then
          vl_oTicket = vl_oFachada.ReturnTicket(vl_sIdTicket, vl_sMensaje)
        End If
      Else
        vl_oForm.Select()
      End If

    Catch ex As Exception
      vl_sMensaje = "Error: " + ex.ToString
      MsgBox(vl_sMensaje, MsgBoxStyle.OkOnly, AcceptButton)
    End Try
  End Sub
  Private Sub llenarDataGrid()
    Dim vl_sMensaje As String = ""
    Try
      With dtgTickets
        Dim vl_oFachada As New Fachada
        .DataSource = vl_oFachada.ReturnListTickets(vl_sMensaje).ToArray

        Dim vg_icontieneDTG As Integer = 9
        If dtgTickets.RowCount <> 0 Then
          If dtgTickets.Columns.Count < vg_icontieneDTG Then

            Dim btnEditar As New DataGridViewButtonColumn()
            dtgTickets.Columns.Add(btnEditar)
            btnEditar.HeaderText = "Acción"
            btnEditar.Text = "Editar"
            btnEditar.Name = "btnEditar"
            btnEditar.UseColumnTextForButtonValue = True

            Dim btnEliminar As New DataGridViewButtonColumn()
            dtgTickets.Columns.Add(btnEliminar)
            btnEliminar.HeaderText = "Acción"
            btnEliminar.Text = "Eliminar"
            btnEliminar.Name = "btnEliminar"
            btnEliminar.UseColumnTextForButtonValue = True

            Dim btnDetalle As New DataGridViewButtonColumn()
            dtgTickets.Columns.Add(btnDetalle)
            btnDetalle.HeaderText = "Acción"
            btnDetalle.Text = "Detalle"
            btnDetalle.Name = "btnDetalle"
            btnDetalle.UseColumnTextForButtonValue = True

          End If
        End If
        .Refresh()
      End With
    Catch ex As Exception
      vl_sMensaje = "Error: " + ex.ToString
      MsgBox(vl_sMensaje, MsgBoxStyle.OkOnly, AcceptButton)
    End Try
  End Sub
End Class