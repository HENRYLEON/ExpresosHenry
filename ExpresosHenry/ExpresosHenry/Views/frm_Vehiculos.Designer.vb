<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Vehiculos
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
        Me.dtgVehiculos = New System.Windows.Forms.DataGridView()
        Me.IdVehiculoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlacaVehiculoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColorVehiculoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadRuedasDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantPasajerosVehDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModeloVehDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AñosVehiculoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CVehiculoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        CType(Me.dtgVehiculos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CVehiculoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgVehiculos
        '
        Me.dtgVehiculos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgVehiculos.AutoGenerateColumns = False
        Me.dtgVehiculos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgVehiculos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdVehiculoDataGridViewTextBoxColumn, Me.PlacaVehiculoDataGridViewTextBoxColumn, Me.ColorVehiculoDataGridViewTextBoxColumn, Me.CantidadRuedasDataGridViewTextBoxColumn, Me.CantPasajerosVehDataGridViewTextBoxColumn, Me.ModeloVehDataGridViewTextBoxColumn, Me.AñosVehiculoDataGridViewTextBoxColumn})
        Me.dtgVehiculos.DataSource = Me.CVehiculoBindingSource
        Me.dtgVehiculos.Location = New System.Drawing.Point(34, 54)
        Me.dtgVehiculos.Name = "dtgVehiculos"
        Me.dtgVehiculos.Size = New System.Drawing.Size(1044, 288)
        Me.dtgVehiculos.TabIndex = 0
        '
        'IdVehiculoDataGridViewTextBoxColumn
        '
        Me.IdVehiculoDataGridViewTextBoxColumn.DataPropertyName = "IdVehiculo"
        Me.IdVehiculoDataGridViewTextBoxColumn.HeaderText = "Id Vehiculo"
        Me.IdVehiculoDataGridViewTextBoxColumn.Name = "IdVehiculoDataGridViewTextBoxColumn"
        '
        'PlacaVehiculoDataGridViewTextBoxColumn
        '
        Me.PlacaVehiculoDataGridViewTextBoxColumn.DataPropertyName = "PlacaVehiculo"
        Me.PlacaVehiculoDataGridViewTextBoxColumn.HeaderText = "Placa"
        Me.PlacaVehiculoDataGridViewTextBoxColumn.Name = "PlacaVehiculoDataGridViewTextBoxColumn"
        '
        'ColorVehiculoDataGridViewTextBoxColumn
        '
        Me.ColorVehiculoDataGridViewTextBoxColumn.DataPropertyName = "ColorVehiculo"
        Me.ColorVehiculoDataGridViewTextBoxColumn.HeaderText = "Color"
        Me.ColorVehiculoDataGridViewTextBoxColumn.Name = "ColorVehiculoDataGridViewTextBoxColumn"
        '
        'CantidadRuedasDataGridViewTextBoxColumn
        '
        Me.CantidadRuedasDataGridViewTextBoxColumn.DataPropertyName = "CantidadRuedas"
        Me.CantidadRuedasDataGridViewTextBoxColumn.HeaderText = "Cantidad"
        Me.CantidadRuedasDataGridViewTextBoxColumn.Name = "CantidadRuedasDataGridViewTextBoxColumn"
        '
        'CantPasajerosVehDataGridViewTextBoxColumn
        '
        Me.CantPasajerosVehDataGridViewTextBoxColumn.DataPropertyName = "CantPasajerosVeh"
        Me.CantPasajerosVehDataGridViewTextBoxColumn.HeaderText = "# Pasajeros"
        Me.CantPasajerosVehDataGridViewTextBoxColumn.Name = "CantPasajerosVehDataGridViewTextBoxColumn"
        '
        'ModeloVehDataGridViewTextBoxColumn
        '
        Me.ModeloVehDataGridViewTextBoxColumn.DataPropertyName = "ModeloVeh"
        Me.ModeloVehDataGridViewTextBoxColumn.HeaderText = "Modelo"
        Me.ModeloVehDataGridViewTextBoxColumn.Name = "ModeloVehDataGridViewTextBoxColumn"
        '
        'AñosVehiculoDataGridViewTextBoxColumn
        '
        Me.AñosVehiculoDataGridViewTextBoxColumn.DataPropertyName = "AñosVehiculo"
        Me.AñosVehiculoDataGridViewTextBoxColumn.HeaderText = "Años"
        Me.AñosVehiculoDataGridViewTextBoxColumn.Name = "AñosVehiculoDataGridViewTextBoxColumn"
        Me.AñosVehiculoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CVehiculoBindingSource
        '
        Me.CVehiculoBindingSource.DataSource = GetType(ExpresosHenry.CVehiculo)
        '
        'btnRefrescar
        '
        Me.btnRefrescar.BackColor = System.Drawing.Color.PaleGreen
        Me.btnRefrescar.Location = New System.Drawing.Point(279, 360)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(203, 46)
        Me.btnRefrescar.TabIndex = 12
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.UseVisualStyleBackColor = False
        '
        'btnAdicionar
        '
        Me.btnAdicionar.BackColor = System.Drawing.Color.PaleGreen
        Me.btnAdicionar.Location = New System.Drawing.Point(34, 360)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(203, 46)
        Me.btnAdicionar.TabIndex = 11
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = False
        '
        'frm_Vehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.dtgVehiculos)
        Me.Name = "frm_Vehiculos"
        Me.ShowIcon = False
        CType(Me.dtgVehiculos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CVehiculoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgVehiculos As DataGridView
    Friend WithEvents CVehiculoBindingSource As BindingSource
    Friend WithEvents IdVehiculoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PlacaVehiculoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ColorVehiculoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CantidadRuedasDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CantPasajerosVehDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModeloVehDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AñosVehiculoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents btnRefrescar As Button
    Friend WithEvents btnAdicionar As Button
End Class
