Public Class frm_Clientes
    Private vg_oFachada As New Fachada
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        Dim vl_oForm As Form = GetFormByName("frm_GesClientes")
        If (vl_oForm Is Nothing) Then
            vl_oForm = New frm_GesClientes
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

    Private Sub frm_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarDataGrid()
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        llenarDataGrid()
    End Sub
    Private Sub dtgClientes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgClientes.CellClick
        Dim vl_oFachada As New Fachada
        Dim vl_oCliente As CCliente
        Dim vl_oFormClientes As New frm_GesClientes
        Dim vl_sMensajeEx As String = Nothing
        Dim vl_sidCliente As String = dtgClientes.Item(0, e.RowIndex).Value
        Dim vl_oForm As Form = GetFormByName("frm_GesClientes")
        Try
            If (vl_oForm Is Nothing) Then
                'Editar
                If e.ColumnIndex = 6 Then
                    If vl_sidCliente <> "" Then
                        vl_oCliente = vl_oFachada.ReturnCliente(vl_sidCliente, vl_sMensajeEx)
                        vl_oFormClientes.txtId.Text = vl_oCliente.IdPersona
                        vl_oFormClientes.txtId.ReadOnly = True
                        vl_oFormClientes.txtNombre.Text = vl_oCliente.NombrePersona
                        vl_oFormClientes.txtIdentificacion.Text = vl_oCliente.IdentificacionPersona
                        vl_oFormClientes.txtNacionalidad.Text = vl_oCliente.NacionalidadPersona
                        vl_oFormClientes.txtApellido.Text = vl_oCliente.ApellidoPersona
                        vl_oFormClientes.cmbSexo.Text = vl_oCliente.SexoPersona
                        vl_oFormClientes.dtpFecha.Text = vl_oCliente.FechaNaciPersona
                        vl_oFormClientes.txtEstatura.Text = vl_oCliente.EstaturaPersona
                        vl_oFormClientes.vg_iAccion = 2
                        vl_oFormClientes.Show()
                    End If
                End If
                'Eliminar
                If e.ColumnIndex = 7 Then
                    Dim result As Integer = MessageBox.Show("¿Estas seguro de eliminar el cliente?", "caption", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        MessageBox.Show("Cliente NO eliminado.")
                    ElseIf result = DialogResult.Yes Then
                        If vl_sidCliente <> "" Then
                            If (vl_oFachada.DeleteCliente(vl_sidCliente, vl_sMensajeEx)) Then
                                'vl_oFachada.DeleteCliente(rowToDelete, vl_sMensajeEx)
                                MessageBox.Show("Se elimino correctamente.")
                            Else
                                MessageBox.Show("Se elimino correctamente.")
                            End If
                        End If
                    End If
                End If
            Else
                vl_oForm.Select()
            End If

        Catch ex As Exception
            vl_sMensajeEx = "Error: " + ex.ToString
            MsgBox(vl_sMensajeEx, MsgBoxStyle.OkOnly, AcceptButton)
        End Try
    End Sub
    Private Sub llenarDataGrid()
        Dim vl_sMensaje As String = ""
        Try
            With dtgClientes
                Dim vl_oFachada As New Fachada
                .DataSource = vl_oFachada.ReturnListClientes(vl_sMensaje).ToArray
                Dim vg_icontieneDTG As Integer = 9
                If dtgClientes.RowCount <> 0 Then
                    If dtgClientes.Columns.Count < vg_icontieneDTG Then

                        Dim btnEditar As New DataGridViewButtonColumn()
                        dtgClientes.Columns.Add(btnEditar)
                        btnEditar.HeaderText = "Acción"
                        btnEditar.Text = "Editar"
                        btnEditar.Name = "btnEditar"
                        btnEditar.UseColumnTextForButtonValue = True

                        Dim btnEliminar As New DataGridViewButtonColumn()
                        dtgClientes.Columns.Add(btnEliminar)
                        btnEliminar.HeaderText = "Acción"
                        btnEliminar.Text = "Eliminar"
                        btnEliminar.Name = "btnEliminar"
                        btnEliminar.UseColumnTextForButtonValue = True

                        Dim btnDetalle As New DataGridViewButtonColumn()
                        dtgClientes.Columns.Add(btnDetalle)
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