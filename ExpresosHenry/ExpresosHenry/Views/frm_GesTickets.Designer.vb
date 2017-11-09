<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_GesTickets
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.lblCosto = New System.Windows.Forms.Label()
    Me.txtCosto = New System.Windows.Forms.TextBox()
    Me.lblTrayecto = New System.Windows.Forms.Label()
    Me.txtTrayecto = New System.Windows.Forms.TextBox()
    Me.txtDestino = New System.Windows.Forms.TextBox()
    Me.txtOrigen = New System.Windows.Forms.TextBox()
    Me.lblLugarLlegada = New System.Windows.Forms.Label()
    Me.lblLugarSalida = New System.Windows.Forms.Label()
    Me.dtpFechaLlegada = New System.Windows.Forms.DateTimePicker()
    Me.lblIdMensaje = New System.Windows.Forms.Label()
    Me.lblFechaLlegada = New System.Windows.Forms.Label()
    Me.lblFechaSalida = New System.Windows.Forms.Label()
    Me.dtpFechaSalida = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.cbxConductor = New System.Windows.Forms.ComboBox()
    Me.cbxVehiculo = New System.Windows.Forms.ComboBox()
    Me.lblNumTicket = New System.Windows.Forms.Label()
    Me.lblTickect = New System.Windows.Forms.Label()
    Me.cbxClientes = New System.Windows.Forms.ComboBox()
    Me.lblMensajeFechaN = New System.Windows.Forms.Label()
    Me.btnCancelar = New System.Windows.Forms.Button()
    Me.btnGuardar = New System.Windows.Forms.Button()
    Me.lblvehiculo = New System.Windows.Forms.Label()
    Me.lblId = New System.Windows.Forms.Label()
    Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
    Me.btnCalcular = New System.Windows.Forms.Button()
    Me.lblMenTrayecto = New System.Windows.Forms.Label()
    Me.Panel1.SuspendLayout()
    Me.Panel2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Panel2)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.cbxConductor)
    Me.Panel1.Controls.Add(Me.cbxVehiculo)
    Me.Panel1.Controls.Add(Me.lblNumTicket)
    Me.Panel1.Controls.Add(Me.lblTickect)
    Me.Panel1.Controls.Add(Me.cbxClientes)
    Me.Panel1.Controls.Add(Me.lblMensajeFechaN)
    Me.Panel1.Controls.Add(Me.btnCancelar)
    Me.Panel1.Controls.Add(Me.btnGuardar)
    Me.Panel1.Controls.Add(Me.lblvehiculo)
    Me.Panel1.Controls.Add(Me.lblId)
    Me.Panel1.Location = New System.Drawing.Point(38, 33)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(712, 417)
    Me.Panel1.TabIndex = 1
    '
    'Panel2
    '
    Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel2.Controls.Add(Me.lblMenTrayecto)
    Me.Panel2.Controls.Add(Me.btnCalcular)
    Me.Panel2.Controls.Add(Me.lblCosto)
    Me.Panel2.Controls.Add(Me.txtCosto)
    Me.Panel2.Controls.Add(Me.lblTrayecto)
    Me.Panel2.Controls.Add(Me.txtTrayecto)
    Me.Panel2.Controls.Add(Me.txtDestino)
    Me.Panel2.Controls.Add(Me.txtOrigen)
    Me.Panel2.Controls.Add(Me.lblLugarLlegada)
    Me.Panel2.Controls.Add(Me.lblLugarSalida)
    Me.Panel2.Controls.Add(Me.dtpFechaLlegada)
    Me.Panel2.Controls.Add(Me.lblIdMensaje)
    Me.Panel2.Controls.Add(Me.lblFechaLlegada)
    Me.Panel2.Controls.Add(Me.lblFechaSalida)
    Me.Panel2.Controls.Add(Me.dtpFechaSalida)
    Me.Panel2.Location = New System.Drawing.Point(6, 123)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(691, 180)
    Me.Panel2.TabIndex = 48
    '
    'lblCosto
    '
    Me.lblCosto.AutoSize = True
    Me.lblCosto.Location = New System.Drawing.Point(184, 89)
    Me.lblCosto.Name = "lblCosto"
    Me.lblCosto.Size = New System.Drawing.Size(41, 13)
    Me.lblCosto.TabIndex = 53
    Me.lblCosto.Text = "* Costo"
    '
    'txtCosto
    '
    Me.txtCosto.Location = New System.Drawing.Point(245, 86)
    Me.txtCosto.Name = "txtCosto"
    Me.txtCosto.Size = New System.Drawing.Size(128, 20)
    Me.txtCosto.TabIndex = 57
    '
    'lblTrayecto
    '
    Me.lblTrayecto.AutoSize = True
    Me.lblTrayecto.Location = New System.Drawing.Point(343, 11)
    Me.lblTrayecto.Name = "lblTrayecto"
    Me.lblTrayecto.Size = New System.Drawing.Size(92, 13)
    Me.lblTrayecto.TabIndex = 56
    Me.lblTrayecto.Text = "* Distancia en KM"
    '
    'txtTrayecto
    '
    Me.txtTrayecto.Location = New System.Drawing.Point(346, 38)
    Me.txtTrayecto.Name = "txtTrayecto"
    Me.txtTrayecto.Size = New System.Drawing.Size(137, 20)
    Me.txtTrayecto.TabIndex = 55
    '
    'txtDestino
    '
    Me.txtDestino.Location = New System.Drawing.Point(187, 38)
    Me.txtDestino.Name = "txtDestino"
    Me.txtDestino.Size = New System.Drawing.Size(137, 20)
    Me.txtDestino.TabIndex = 54
    '
    'txtOrigen
    '
    Me.txtOrigen.Location = New System.Drawing.Point(32, 38)
    Me.txtOrigen.Name = "txtOrigen"
    Me.txtOrigen.Size = New System.Drawing.Size(137, 20)
    Me.txtOrigen.TabIndex = 53
    '
    'lblLugarLlegada
    '
    Me.lblLugarLlegada.AutoSize = True
    Me.lblLugarLlegada.Location = New System.Drawing.Point(184, 11)
    Me.lblLugarLlegada.Name = "lblLugarLlegada"
    Me.lblLugarLlegada.Size = New System.Drawing.Size(50, 13)
    Me.lblLugarLlegada.TabIndex = 52
    Me.lblLugarLlegada.Text = "* Destino"
    '
    'lblLugarSalida
    '
    Me.lblLugarSalida.AutoSize = True
    Me.lblLugarSalida.Location = New System.Drawing.Point(29, 11)
    Me.lblLugarSalida.Name = "lblLugarSalida"
    Me.lblLugarSalida.Size = New System.Drawing.Size(45, 13)
    Me.lblLugarSalida.TabIndex = 51
    Me.lblLugarSalida.Text = "* Origen"
    '
    'dtpFechaLlegada
    '
    Me.dtpFechaLlegada.Location = New System.Drawing.Point(600, 38)
    Me.dtpFechaLlegada.Name = "dtpFechaLlegada"
    Me.dtpFechaLlegada.Size = New System.Drawing.Size(62, 20)
    Me.dtpFechaLlegada.TabIndex = 49
    Me.dtpFechaLlegada.Value = New Date(2016, 11, 21, 21, 52, 15, 0)
    '
    'lblIdMensaje
    '
    Me.lblIdMensaje.AutoSize = True
    Me.lblIdMensaje.ForeColor = System.Drawing.Color.Red
    Me.lblIdMensaje.Location = New System.Drawing.Point(343, 61)
    Me.lblIdMensaje.Name = "lblIdMensaje"
    Me.lblIdMensaje.Size = New System.Drawing.Size(0, 13)
    Me.lblIdMensaje.TabIndex = 37
    '
    'lblFechaLlegada
    '
    Me.lblFechaLlegada.AutoSize = True
    Me.lblFechaLlegada.Location = New System.Drawing.Point(597, 11)
    Me.lblFechaLlegada.Name = "lblFechaLlegada"
    Me.lblFechaLlegada.Size = New System.Drawing.Size(85, 13)
    Me.lblFechaLlegada.TabIndex = 50
    Me.lblFechaLlegada.Text = "* Fecha Llegada"
    '
    'lblFechaSalida
    '
    Me.lblFechaSalida.AutoSize = True
    Me.lblFechaSalida.Location = New System.Drawing.Point(496, 11)
    Me.lblFechaSalida.Name = "lblFechaSalida"
    Me.lblFechaSalida.Size = New System.Drawing.Size(76, 13)
    Me.lblFechaSalida.TabIndex = 50
    Me.lblFechaSalida.Text = "* Fecha Salida"
    '
    'dtpFechaSalida
    '
    Me.dtpFechaSalida.Location = New System.Drawing.Point(499, 38)
    Me.dtpFechaSalida.Name = "dtpFechaSalida"
    Me.dtpFechaSalida.Size = New System.Drawing.Size(62, 20)
    Me.dtpFechaSalida.TabIndex = 49
    Me.dtpFechaSalida.Value = New Date(2016, 11, 21, 21, 52, 15, 0)
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(3, 72)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(69, 13)
    Me.Label2.TabIndex = 47
    Me.Label2.Text = "* Conductor :"
    '
    'cbxConductor
    '
    Me.cbxConductor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbxConductor.FormattingEnabled = True
    Me.cbxConductor.Location = New System.Drawing.Point(86, 64)
    Me.cbxConductor.Name = "cbxConductor"
    Me.cbxConductor.Size = New System.Drawing.Size(182, 21)
    Me.cbxConductor.TabIndex = 46
    '
    'cbxVehiculo
    '
    Me.cbxVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbxVehiculo.FormattingEnabled = True
    Me.cbxVehiculo.Location = New System.Drawing.Point(86, 37)
    Me.cbxVehiculo.Name = "cbxVehiculo"
    Me.cbxVehiculo.Size = New System.Drawing.Size(182, 21)
    Me.cbxVehiculo.TabIndex = 45
    '
    'lblNumTicket
    '
    Me.lblNumTicket.AutoSize = True
    Me.lblNumTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblNumTicket.ForeColor = System.Drawing.Color.Black
    Me.lblNumTicket.Location = New System.Drawing.Point(601, 6)
    Me.lblNumTicket.Name = "lblNumTicket"
    Me.lblNumTicket.Size = New System.Drawing.Size(0, 31)
    Me.lblNumTicket.TabIndex = 43
    '
    'lblTickect
    '
    Me.lblTickect.AutoSize = True
    Me.lblTickect.Location = New System.Drawing.Point(546, 21)
    Me.lblTickect.Name = "lblTickect"
    Me.lblTickect.Size = New System.Drawing.Size(60, 13)
    Me.lblTickect.TabIndex = 42
    Me.lblTickect.Text = "* # Ticket :"
    '
    'cbxClientes
    '
    Me.cbxClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbxClientes.FormattingEnabled = True
    Me.cbxClientes.Location = New System.Drawing.Point(86, 8)
    Me.cbxClientes.Name = "cbxClientes"
    Me.cbxClientes.Size = New System.Drawing.Size(182, 21)
    Me.cbxClientes.TabIndex = 41
    '
    'lblMensajeFechaN
    '
    Me.lblMensajeFechaN.AutoSize = True
    Me.lblMensajeFechaN.ForeColor = System.Drawing.Color.Red
    Me.lblMensajeFechaN.Location = New System.Drawing.Point(449, 181)
    Me.lblMensajeFechaN.Name = "lblMensajeFechaN"
    Me.lblMensajeFechaN.Size = New System.Drawing.Size(0, 13)
    Me.lblMensajeFechaN.TabIndex = 40
    '
    'btnCancelar
    '
    Me.btnCancelar.BackColor = System.Drawing.Color.PaleGreen
    Me.btnCancelar.Location = New System.Drawing.Point(194, 333)
    Me.btnCancelar.Name = "btnCancelar"
    Me.btnCancelar.Size = New System.Drawing.Size(124, 34)
    Me.btnCancelar.TabIndex = 36
    Me.btnCancelar.Text = "Cancelar"
    Me.btnCancelar.UseVisualStyleBackColor = False
    '
    'btnGuardar
    '
    Me.btnGuardar.BackColor = System.Drawing.Color.PaleGreen
    Me.btnGuardar.Location = New System.Drawing.Point(39, 333)
    Me.btnGuardar.Name = "btnGuardar"
    Me.btnGuardar.Size = New System.Drawing.Size(124, 34)
    Me.btnGuardar.TabIndex = 34
    Me.btnGuardar.Text = "Guardar"
    Me.btnGuardar.UseVisualStyleBackColor = False
    '
    'lblvehiculo
    '
    Me.lblvehiculo.AutoSize = True
    Me.lblvehiculo.Location = New System.Drawing.Point(3, 45)
    Me.lblvehiculo.Name = "lblvehiculo"
    Me.lblvehiculo.Size = New System.Drawing.Size(61, 13)
    Me.lblvehiculo.TabIndex = 25
    Me.lblvehiculo.Text = "* Vehiculo :"
    '
    'lblId
    '
    Me.lblId.AutoSize = True
    Me.lblId.Location = New System.Drawing.Point(3, 11)
    Me.lblId.Name = "lblId"
    Me.lblId.Size = New System.Drawing.Size(52, 13)
    Me.lblId.TabIndex = 16
    Me.lblId.Text = "* Cliente :"
    '
    'btnCalcular
    '
    Me.btnCalcular.BackColor = System.Drawing.Color.PaleGreen
    Me.btnCalcular.Location = New System.Drawing.Point(115, 78)
    Me.btnCalcular.Name = "btnCalcular"
    Me.btnCalcular.Size = New System.Drawing.Size(124, 34)
    Me.btnCalcular.TabIndex = 58
    Me.btnCalcular.Text = "Calcular Costo"
    Me.btnCalcular.UseVisualStyleBackColor = False
    '
    'lblMenTrayecto
    '
    Me.lblMenTrayecto.AutoSize = True
    Me.lblMenTrayecto.ForeColor = System.Drawing.Color.Red
    Me.lblMenTrayecto.Location = New System.Drawing.Point(349, 61)
    Me.lblMenTrayecto.Name = "lblMenTrayecto"
    Me.lblMenTrayecto.Size = New System.Drawing.Size(0, 13)
    Me.lblMenTrayecto.TabIndex = 49
    '
    'frm_GesTickets
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(789, 483)
    Me.ControlBox = False
    Me.Controls.Add(Me.Panel1)
    Me.Name = "frm_GesTickets"
    Me.ShowIcon = False
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents Panel1 As Panel
  Friend WithEvents lblMensajeFechaN As Label
  Friend WithEvents lblIdMensaje As Label
  Friend WithEvents btnCancelar As Button
  Friend WithEvents btnGuardar As Button
  Friend WithEvents lblvehiculo As Label
  Friend WithEvents lblId As Label
  Friend WithEvents cbxClientes As System.Windows.Forms.ComboBox
  Friend WithEvents lblTickect As System.Windows.Forms.Label
  Friend WithEvents lblNumTicket As System.Windows.Forms.Label
  Friend WithEvents cbxVehiculo As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents cbxConductor As System.Windows.Forms.ComboBox
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents dtpFechaLlegada As System.Windows.Forms.DateTimePicker
  Friend WithEvents lblFechaLlegada As System.Windows.Forms.Label
  Friend WithEvents lblFechaSalida As System.Windows.Forms.Label
  Friend WithEvents dtpFechaSalida As System.Windows.Forms.DateTimePicker
  Friend WithEvents lblLugarLlegada As System.Windows.Forms.Label
  Friend WithEvents lblLugarSalida As System.Windows.Forms.Label
  Friend WithEvents txtDestino As System.Windows.Forms.TextBox
  Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
  Friend WithEvents txtTrayecto As System.Windows.Forms.TextBox
  Friend WithEvents lblTrayecto As System.Windows.Forms.Label
  Friend WithEvents txtCosto As System.Windows.Forms.TextBox
  Friend WithEvents lblCosto As System.Windows.Forms.Label
  Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
  Friend WithEvents btnCalcular As System.Windows.Forms.Button
  Friend WithEvents lblMenTrayecto As System.Windows.Forms.Label
End Class
