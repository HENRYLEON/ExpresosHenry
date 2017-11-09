<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Tickets
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgTickets = New System.Windows.Forms.DataGridView()
        Me.IdTicketDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClienteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VehiculoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LugarSalidaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LugarLlegadaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaIniTicDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaFinTicDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTicketBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CVehiculoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        CType(Me.dtgTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CTicketBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CVehiculoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgTickets
        '
        Me.dtgTickets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgTickets.AutoGenerateColumns = False
        Me.dtgTickets.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgTickets.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTicketDataGridViewTextBoxColumn, Me.ClienteDataGridViewTextBoxColumn, Me.VehiculoDataGridViewTextBoxColumn, Me.LugarSalidaDataGridViewTextBoxColumn, Me.LugarLlegadaDataGridViewTextBoxColumn, Me.FechaIniTicDataGridViewTextBoxColumn, Me.FechaFinTicDataGridViewTextBoxColumn})
        Me.dtgTickets.DataSource = Me.CTicketBindingSource
        Me.dtgTickets.Location = New System.Drawing.Point(34, 54)
        Me.dtgTickets.Name = "dtgTickets"
        Me.dtgTickets.Size = New System.Drawing.Size(1044, 288)
        Me.dtgTickets.TabIndex = 0
        '
        'IdTicketDataGridViewTextBoxColumn
        '
        Me.IdTicketDataGridViewTextBoxColumn.DataPropertyName = "IdTicket"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IdTicketDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.IdTicketDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdTicketDataGridViewTextBoxColumn.Name = "IdTicketDataGridViewTextBoxColumn"
        '
        'ClienteDataGridViewTextBoxColumn
        '
        Me.ClienteDataGridViewTextBoxColumn.DataPropertyName = "Cliente"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ClienteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ClienteDataGridViewTextBoxColumn.HeaderText = "Cliente"
        Me.ClienteDataGridViewTextBoxColumn.Name = "ClienteDataGridViewTextBoxColumn"
        '
        'VehiculoDataGridViewTextBoxColumn
        '
        Me.VehiculoDataGridViewTextBoxColumn.DataPropertyName = "Vehiculo"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.VehiculoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.VehiculoDataGridViewTextBoxColumn.HeaderText = "Vehiculo"
        Me.VehiculoDataGridViewTextBoxColumn.Name = "VehiculoDataGridViewTextBoxColumn"
        '
        'LugarSalidaDataGridViewTextBoxColumn
        '
        Me.LugarSalidaDataGridViewTextBoxColumn.DataPropertyName = "LugarSalida"
        Me.LugarSalidaDataGridViewTextBoxColumn.HeaderText = "Lugar Salida"
        Me.LugarSalidaDataGridViewTextBoxColumn.Name = "LugarSalidaDataGridViewTextBoxColumn"
        '
        'LugarLlegadaDataGridViewTextBoxColumn
        '
        Me.LugarLlegadaDataGridViewTextBoxColumn.DataPropertyName = "LugarLlegada"
        Me.LugarLlegadaDataGridViewTextBoxColumn.HeaderText = "Lugar Llegada"
        Me.LugarLlegadaDataGridViewTextBoxColumn.Name = "LugarLlegadaDataGridViewTextBoxColumn"
        '
        'FechaIniTicDataGridViewTextBoxColumn
        '
        Me.FechaIniTicDataGridViewTextBoxColumn.DataPropertyName = "FechaIniTic"
        Me.FechaIniTicDataGridViewTextBoxColumn.HeaderText = "Fecha Salida"
        Me.FechaIniTicDataGridViewTextBoxColumn.Name = "FechaIniTicDataGridViewTextBoxColumn"
        '
        'FechaFinTicDataGridViewTextBoxColumn
        '
        Me.FechaFinTicDataGridViewTextBoxColumn.DataPropertyName = "FechaFinTic"
        Me.FechaFinTicDataGridViewTextBoxColumn.HeaderText = "Fecha Llegada"
        Me.FechaFinTicDataGridViewTextBoxColumn.Name = "FechaFinTicDataGridViewTextBoxColumn"
        '
        'CTicketBindingSource
        '
        Me.CTicketBindingSource.DataSource = GetType(ExpresosHenry.CTicket)
        '
        'CVehiculoBindingSource
        '
        Me.CVehiculoBindingSource.DataSource = GetType(ExpresosHenry.CVehiculo)
        '
        'btnRefrescar
        '
        Me.btnRefrescar.BackColor = System.Drawing.Color.PaleGreen
        Me.btnRefrescar.Location = New System.Drawing.Point(279, 371)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(203, 46)
        Me.btnRefrescar.TabIndex = 12
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.UseVisualStyleBackColor = False
        '
        'btnAdicionar
        '
        Me.btnAdicionar.BackColor = System.Drawing.Color.PaleGreen
        Me.btnAdicionar.Location = New System.Drawing.Point(34, 371)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(203, 46)
        Me.btnAdicionar.TabIndex = 11
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = False
        '
        'frm_Tickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 521)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.dtgTickets)
        Me.Name = "frm_Tickets"
        Me.ShowIcon = False
        CType(Me.dtgTickets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CTicketBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CVehiculoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgTickets As DataGridView
    Friend WithEvents CTicketBindingSource As BindingSource
    Friend WithEvents CVehiculoBindingSource As BindingSource
    Friend WithEvents IdTicketDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClienteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VehiculoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LugarSalidaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LugarLlegadaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FechaIniTicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FechaFinTicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents btnRefrescar As Button
    Friend WithEvents btnAdicionar As Button
End Class
