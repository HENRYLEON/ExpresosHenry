Public Class Form1
  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim frmAbout As New frm_Options()
    Dim vl_sMensaje As String = Nothing
    Try
      frmAbout.ShowDialog()
            If mod_General.vg_sOpcionAlmacenamiento = 2 Then
                mod_General.InicializarConfiguracionXML(vl_sMensaje)
            ElseIf mod_General.vg_sOpcionAlmacenamiento = 3 Then
                mod_General.InicializarConfiguracionSQL(vl_sMensaje)
            End If
    Catch ex As Exception
      vl_sMensaje = "Error: " + ex.ToString
      MsgBox(vl_sMensaje, MsgBoxStyle.OkOnly, AcceptButton)
    End Try
  End Sub

  'metodo para pintar la forma
  Public Sub PintarFomrs(ByVal pi_oFrom As Form)

    AddHandler pi_oFrom.LocationChanged, AddressOf Me.Form2_LocationChanged
    Me.Form2_SizeChanged(pi_oFrom)
    pi_oFrom.TopLevel = False
    pi_oFrom.Size = New System.Drawing.Size(pnlFomrs.Size.Width, pnlFomrs.Size.Height)
    pi_oFrom.ShowIcon = False
    pi_oFrom.ControlBox = False
    pi_oFrom.Text = Nothing
    pnlFomrs.Controls.Add(pi_oFrom)
    pi_oFrom.Show()
  End Sub
  'posiciona la forma
  Private Sub Form2_LocationChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim f As Form = sender
    pnlFomrs.SetAutoScrollMargin(f.Location.X, f.Location.Y)
  End Sub

  'ajusta la forma
  Private Sub Form2_SizeChanged(ByVal pi_oFrom As Form)
    If pi_oFrom.Size.Width > pnlFomrs.Size.Width Or pi_oFrom.Size.Height > pnlFomrs.Size.Height Then
      pi_oFrom.Size = New System.Drawing.Size(pnlFomrs.Size.Width, pnlFomrs.Size.Height)
    End If
  End Sub

  Private Sub btnTickets_Click(sender As Object, e As EventArgs) Handles btnTickets.Click
    Dim vl_oForm As Form = GetFormByName("frm_Tickets")
    If (vl_oForm Is Nothing) Then
      vl_oForm = New frm_Tickets()
      Me.lblSaludo.Text = ""
      Me.PintarFomrs(vl_oForm)
    Else
      vl_oForm.Select()
    End If
  End Sub

  Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click

    Dim vl_oForm As Form = GetFormByName("frm_Clientes")
    If (vl_oForm Is Nothing) Then
      vl_oForm = New frm_Clientes()
      Me.lblSaludo.Text = ""
      Me.PintarFomrs(vl_oForm)
    Else
      vl_oForm.Select()
    End If
  End Sub

  Public Function GetFormByName(formName As String) As Form
    If (formName = String.Empty) Then Return Nothing
    Dim frm1 As String = "Form1"
    For Each frm As Form In Application.OpenForms
      If (frm.Name.ToUpperInvariant() = formName.ToUpperInvariant()) Then
        Return frm
      ElseIf (frm.Name.ToUpperInvariant() <> frm1.ToUpperInvariant()) Then
        frm.Close()
        Return Nothing
      End If
    Next
    Return Nothing
  End Function

  Private Sub btnVehiculos_Click(sender As Object, e As EventArgs) Handles btnVehiculos.Click
    Dim vl_oForm As Form = GetFormByName("frm_Vehiculos")
    If (vl_oForm Is Nothing) Then
      vl_oForm = New frm_Vehiculos()
      Me.lblSaludo.Text = ""
      Me.PintarFomrs(vl_oForm)
    Else
      vl_oForm.Select()
    End If
  End Sub

  Private Sub btnCondutores_Click(sender As Object, e As EventArgs) Handles btnCondutores.Click
    Dim vl_oForm As Form = GetFormByName("frm_Conductores")
    If (vl_oForm Is Nothing) Then
      vl_oForm = New frm_Conductores()
      Me.lblSaludo.Text = ""
      Me.PintarFomrs(vl_oForm)
    Else
      vl_oForm.Select()
    End If
  End Sub
End Class