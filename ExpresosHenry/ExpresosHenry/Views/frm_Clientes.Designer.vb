<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Clientes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgClientes = New System.Windows.Forms.DataGridView()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.CClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdentificacionPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombrePersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApellidoPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EdadPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgClientes
        '
        Me.dtgClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgClientes.AutoGenerateColumns = False
        Me.dtgClientes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdPersonaDataGridViewTextBoxColumn, Me.IdentificacionPersonaDataGridViewTextBoxColumn, Me.TipoIdentifiPersonaDataGridViewTextBoxColumn, Me.NombrePersonaDataGridViewTextBoxColumn, Me.ApellidoPersonaDataGridViewTextBoxColumn, Me.EdadPersonaDataGridViewTextBoxColumn})
        Me.dtgClientes.DataSource = Me.CClienteBindingSource
        Me.dtgClientes.Location = New System.Drawing.Point(34, 54)
        Me.dtgClientes.Name = "dtgClientes"
        Me.dtgClientes.Size = New System.Drawing.Size(1044, 288)
        Me.dtgClientes.TabIndex = 0
        '
        'btnAdicionar
        '
        Me.btnAdicionar.BackColor = System.Drawing.Color.PaleGreen
        Me.btnAdicionar.Location = New System.Drawing.Point(34, 348)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(203, 46)
        Me.btnAdicionar.TabIndex = 1
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(34, 420)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(738, 77)
        Me.Panel1.TabIndex = 2
        '
        'btnRefrescar
        '
        Me.btnRefrescar.BackColor = System.Drawing.Color.PaleGreen
        Me.btnRefrescar.Location = New System.Drawing.Point(279, 348)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(203, 46)
        Me.btnRefrescar.TabIndex = 10
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.UseVisualStyleBackColor = False
        '
        'CClienteBindingSource
        '
        Me.CClienteBindingSource.DataSource = GetType(ExpresosHenry.CCliente)
        '
        'IdPersonaDataGridViewTextBoxColumn
        '
        Me.IdPersonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IdPersonaDataGridViewTextBoxColumn.DataPropertyName = "IdPersona"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IdPersonaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.IdPersonaDataGridViewTextBoxColumn.HeaderText = "Id Persona"
        Me.IdPersonaDataGridViewTextBoxColumn.Name = "IdPersonaDataGridViewTextBoxColumn"
        Me.IdPersonaDataGridViewTextBoxColumn.Width = 83
        '
        'IdentificacionPersonaDataGridViewTextBoxColumn
        '
        Me.IdentificacionPersonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IdentificacionPersonaDataGridViewTextBoxColumn.DataPropertyName = "IdentificacionPersona"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IdentificacionPersonaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.IdentificacionPersonaDataGridViewTextBoxColumn.HeaderText = "Identificación"
        Me.IdentificacionPersonaDataGridViewTextBoxColumn.Name = "IdentificacionPersonaDataGridViewTextBoxColumn"
        Me.IdentificacionPersonaDataGridViewTextBoxColumn.Width = 95
        '
        'TipoIdentifiPersonaDataGridViewTextBoxColumn
        '
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn.DataPropertyName = "TipoIdentifiPersona"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn.HeaderText = "Tipo Identificación"
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn.Name = "TipoIdentifiPersonaDataGridViewTextBoxColumn"
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn.Width = 109
        '
        'NombrePersonaDataGridViewTextBoxColumn
        '
        Me.NombrePersonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.NombrePersonaDataGridViewTextBoxColumn.DataPropertyName = "NombrePersona"
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NombrePersonaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.NombrePersonaDataGridViewTextBoxColumn.HeaderText = "Nombre"
        Me.NombrePersonaDataGridViewTextBoxColumn.Name = "NombrePersonaDataGridViewTextBoxColumn"
        Me.NombrePersonaDataGridViewTextBoxColumn.Width = 69
        '
        'ApellidoPersonaDataGridViewTextBoxColumn
        '
        Me.ApellidoPersonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ApellidoPersonaDataGridViewTextBoxColumn.DataPropertyName = "ApellidoPersona"
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ApellidoPersonaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ApellidoPersonaDataGridViewTextBoxColumn.HeaderText = "Apellido"
        Me.ApellidoPersonaDataGridViewTextBoxColumn.Name = "ApellidoPersonaDataGridViewTextBoxColumn"
        Me.ApellidoPersonaDataGridViewTextBoxColumn.Width = 69
        '
        'EdadPersonaDataGridViewTextBoxColumn
        '
        Me.EdadPersonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.EdadPersonaDataGridViewTextBoxColumn.DataPropertyName = "EdadPersona"
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EdadPersonaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.EdadPersonaDataGridViewTextBoxColumn.HeaderText = "Edad"
        Me.EdadPersonaDataGridViewTextBoxColumn.Name = "EdadPersonaDataGridViewTextBoxColumn"
        Me.EdadPersonaDataGridViewTextBoxColumn.ReadOnly = True
        Me.EdadPersonaDataGridViewTextBoxColumn.Width = 57
        '
        'frm_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1143, 521)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.dtgClientes)
        Me.Name = "frm_Clientes"
        Me.ShowIcon = False
        CType(Me.dtgClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgClientes As DataGridView
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CClienteBindingSource As BindingSource
    Friend WithEvents btnRefrescar As Button
    Friend WithEvents IdPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdentificacionPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TipoIdentifiPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombrePersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ApellidoPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EdadPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
