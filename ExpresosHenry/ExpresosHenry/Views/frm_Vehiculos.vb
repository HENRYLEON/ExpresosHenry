Public Class frm_Vehiculos
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        Dim vl_oForm As Form = GetFormByName("frm_GesVehiculos")
        If (vl_oForm Is Nothing) Then
            vl_oForm = New frm_GesVehiculos
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

    Private Sub frm_Vehiculos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarDataGrid()
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        llenarDataGrid()
    End Sub
    Private Sub dtgVehiculos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgVehiculos.CellClick
        Dim vl_oFachada As New Fachada
        Dim vl_oVehiculo As CVehiculo
        Dim vl_oFormVehiculo As New frm_GesVehiculos
        Dim vl_sMensajeEx As String = Nothing
        Dim vl_sidVehiculo As String = dtgVehiculos.Item(0, e.RowIndex).Value
        Dim vl_oForm As Form = GetFormByName("frm_GesVehiculos")
        Try
            If (vl_oForm Is Nothing) Then
                'Editar
                If e.ColumnIndex = 7 Then
                    If vl_sidVehiculo <> "" Then
                        vl_oVehiculo = vl_oFachada.ReturnVehiculo(vl_sidVehiculo, vl_sMensajeEx)
                        vl_oFormVehiculo.txtId.Text = vl_oVehiculo.IdVehiculo
                        vl_oFormVehiculo.txtId.ReadOnly = True
                        vl_oFormVehiculo.txtPlaca.Text = vl_oVehiculo.PlacaVehiculo
                        vl_oFormVehiculo.txtColor.Text = vl_oVehiculo.ColorVehiculo
                        vl_oFormVehiculo.txtCantidadRuedas.Text = vl_oVehiculo.CantidadRuedas
                        vl_oFormVehiculo.txtCantPasajeros.Text = vl_oVehiculo.CantPasajerosVeh
                        vl_oFormVehiculo.txtModelo.Text = vl_oVehiculo.ModeloVeh
                        vl_oFormVehiculo.vg_iAccion = 2
                        vl_oFormVehiculo.Show()
                    End If
                End If
                'Eliminar
                If e.ColumnIndex = 8 Then
                    Dim result As Integer = MessageBox.Show("¿Estas seguro de eliminar el vehiculo?", "caption", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        MessageBox.Show("Vehiculo NO eliminado.")
                    ElseIf result = DialogResult.Yes Then
                        If vl_sidVehiculo <> "" Then
                            If (vl_oFachada.DeleteVehiculo(vl_sidVehiculo, vl_sMensajeEx)) Then
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
        Dim vl_sMensajeEx As String = ""
        Try
            With dtgVehiculos
                Dim vl_oFachada As New Fachada
                .DataSource = vl_oFachada.ReturnListVehiculos(vl_sMensajeEx).ToArray

                Dim vg_icontieneDTG As Integer = 9
                If dtgVehiculos.RowCount <> 0 Then
                    If dtgVehiculos.Columns.Count < vg_icontieneDTG Then

                        Dim btnEditar As New DataGridViewButtonColumn()
                        dtgVehiculos.Columns.Add(btnEditar)
                        btnEditar.HeaderText = "Acción"
                        btnEditar.Text = "Editar"
                        btnEditar.Name = "btnEditar"
                        btnEditar.UseColumnTextForButtonValue = True

                        Dim btnEliminar As New DataGridViewButtonColumn()
                        dtgVehiculos.Columns.Add(btnEliminar)
                        btnEliminar.HeaderText = "Acción"
                        btnEliminar.Text = "Eliminar"
                        btnEliminar.Name = "btnEliminar"
                        btnEliminar.UseColumnTextForButtonValue = True
                    End If
                End If
                .Refresh()
            End With
        Catch ex As Exception
            vl_sMensajeEx = "Error: " + ex.ToString
            MsgBox(vl_sMensajeEx, MsgBoxStyle.OkOnly, AcceptButton)
        End Try
    End Sub
End Class