Public Class frm_Conductores
    Private vg_oFachada As New Fachada
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        Dim vl_oForm As Form = GetFormByName("frm_GesUsuarios")
        If (vl_oForm Is Nothing) Then
            vl_oForm = New frm_GesUsuario
            vl_oForm.Show()
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

    Private Sub frm_Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarDataGrid()
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        llenarDataGrid()
    End Sub
    Private Sub dtgUsuarios_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConductores.CellClick
        Dim vl_oFachada As New Fachada
        Dim vl_oUsuario As CUsuario
        Dim vl_oFormUsuarios As New frm_GesUsuario
        Dim vl_sMensajeEx As String = Nothing
        Dim vl_sidUsuario As String = dtgConductores.Item(0, e.RowIndex).Value
        Dim vl_oForm As Form = GetFormByName("frm_GesUsuarios")
        Try
            If (vl_oForm Is Nothing) Then
                'Editar
                If e.ColumnIndex = 7 Then
                    If vl_sidUsuario <> "" Then
                        vl_oUsuario = vl_oFachada.ReturnUsuario(vl_sidUsuario, vl_sMensajeEx)
                        vl_oFormUsuarios.txtId.Text = vl_oUsuario.IdPersona
                        vl_oFormUsuarios.txtId.ReadOnly = True
                        vl_oFormUsuarios.txtNombre.Text = vl_oUsuario.NombrePersona
                        vl_oFormUsuarios.txtIdentificacion.Text = vl_oUsuario.IdentificacionPersona
                        vl_oFormUsuarios.txtNacionalidad.Text = vl_oUsuario.NacionalidadPersona
                        vl_oFormUsuarios.txtApellido.Text = vl_oUsuario.ApellidoPersona
                        vl_oFormUsuarios.cmbSexo.Text = vl_oUsuario.SexoPersona
                        vl_oFormUsuarios.dtpFecha.Text = vl_oUsuario.FechaNaciPersona
                        vl_oFormUsuarios.txtEstatura.Text = vl_oUsuario.EstaturaPersona
                        vl_oFormUsuarios.vg_iAccion = 2
                        vl_oFormUsuarios.Show()
                    End If
                End If
                'Eliminar
                If e.ColumnIndex = 8 Then
                    Dim result As Integer = MessageBox.Show("¿Estas seguro de eliminar el Usuario?", "caption", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        MessageBox.Show("Usuario NO eliminado.")
                    ElseIf result = DialogResult.Yes Then
                        If vl_sidUsuario <> "" Then
                            If (vl_oFachada.DeleteUsuario(vl_sidUsuario, vl_sMensajeEx)) Then
                                'vl_oFachada.DeleteUsuario(rowToDelete, vl_sMensajeEx)
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
            With dtgConductores
                Dim vl_oFachada As New Fachada
                .DataSource = vl_oFachada.ReturnListUsuarios(vl_sMensaje).ToArray

                Dim vg_icontieneDTG As Integer = 9
                If dtgConductores.RowCount <> 0 Then
                    If dtgConductores.Columns.Count < vg_icontieneDTG Then

                        Dim btnEditar As New DataGridViewButtonColumn()
                        dtgConductores.Columns.Add(btnEditar)
                        btnEditar.HeaderText = "Acción"
                        btnEditar.Text = "Editar"
                        btnEditar.Name = "btnEditar"
                        btnEditar.UseColumnTextForButtonValue = True

                        Dim btnEliminar As New DataGridViewButtonColumn()
                        dtgConductores.Columns.Add(btnEliminar)
                        btnEliminar.HeaderText = "Acción"
                        btnEliminar.Text = "Eliminar"
                        btnEliminar.Name = "btnEliminar"
                        btnEliminar.UseColumnTextForButtonValue = True

                        Dim btnDetalle As New DataGridViewButtonColumn()
                        dtgConductores.Columns.Add(btnDetalle)
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