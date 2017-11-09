<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Conductores
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
        Me.dtgConductores = New System.Windows.Forms.DataGridView()
        Me.IdPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdentificacionPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombrePersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApellidoPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SexoPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EdadPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUsuarioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        CType(Me.dtgConductores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUsuarioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgConductores
        '
        Me.dtgConductores.AutoGenerateColumns = False
        Me.dtgConductores.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgConductores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConductores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdPersonaDataGridViewTextBoxColumn, Me.TipoIdentifiPersonaDataGridViewTextBoxColumn, Me.IdentificacionPersonaDataGridViewTextBoxColumn, Me.NombrePersonaDataGridViewTextBoxColumn, Me.ApellidoPersonaDataGridViewTextBoxColumn, Me.SexoPersonaDataGridViewTextBoxColumn, Me.EdadPersonaDataGridViewTextBoxColumn})
        Me.dtgConductores.DataSource = Me.CUsuarioBindingSource
        Me.dtgConductores.Location = New System.Drawing.Point(34, 54)
        Me.dtgConductores.Name = "dtgConductores"
        Me.dtgConductores.Size = New System.Drawing.Size(1044, 288)
        Me.dtgConductores.TabIndex = 0
        '
        'IdPersonaDataGridViewTextBoxColumn
        '
        Me.IdPersonaDataGridViewTextBoxColumn.DataPropertyName = "IdPersona"
        Me.IdPersonaDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdPersonaDataGridViewTextBoxColumn.Name = "IdPersonaDataGridViewTextBoxColumn"
        '
        'TipoIdentifiPersonaDataGridViewTextBoxColumn
        '
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn.DataPropertyName = "TipoIdentifiPersona"
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn.HeaderText = "Tipo Identificación"
        Me.TipoIdentifiPersonaDataGridViewTextBoxColumn.Name = "TipoIdentifiPersonaDataGridViewTextBoxColumn"
        '
        'IdentificacionPersonaDataGridViewTextBoxColumn
        '
        Me.IdentificacionPersonaDataGridViewTextBoxColumn.DataPropertyName = "IdentificacionPersona"
        Me.IdentificacionPersonaDataGridViewTextBoxColumn.HeaderText = "Identificación"
        Me.IdentificacionPersonaDataGridViewTextBoxColumn.Name = "IdentificacionPersonaDataGridViewTextBoxColumn"
        '
        'NombrePersonaDataGridViewTextBoxColumn
        '
        Me.NombrePersonaDataGridViewTextBoxColumn.DataPropertyName = "NombrePersona"
        Me.NombrePersonaDataGridViewTextBoxColumn.HeaderText = "Nombre"
        Me.NombrePersonaDataGridViewTextBoxColumn.Name = "NombrePersonaDataGridViewTextBoxColumn"
        '
        'ApellidoPersonaDataGridViewTextBoxColumn
        '
        Me.ApellidoPersonaDataGridViewTextBoxColumn.DataPropertyName = "ApellidoPersona"
        Me.ApellidoPersonaDataGridViewTextBoxColumn.HeaderText = "Apellido"
        Me.ApellidoPersonaDataGridViewTextBoxColumn.Name = "ApellidoPersonaDataGridViewTextBoxColumn"
        '
        'SexoPersonaDataGridViewTextBoxColumn
        '
        Me.SexoPersonaDataGridViewTextBoxColumn.DataPropertyName = "SexoPersona"
        Me.SexoPersonaDataGridViewTextBoxColumn.HeaderText = "Sexo"
        Me.SexoPersonaDataGridViewTextBoxColumn.Name = "SexoPersonaDataGridViewTextBoxColumn"
        '
        'EdadPersonaDataGridViewTextBoxColumn
        '
        Me.EdadPersonaDataGridViewTextBoxColumn.DataPropertyName = "EdadPersona"
        Me.EdadPersonaDataGridViewTextBoxColumn.HeaderText = "Edad"
        Me.EdadPersonaDataGridViewTextBoxColumn.Name = "EdadPersonaDataGridViewTextBoxColumn"
        Me.EdadPersonaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CUsuarioBindingSource
        '
        Me.CUsuarioBindingSource.DataSource = GetType(ExpresosHenry.CUsuario)
        '
        'btnRefrescar
        '
        Me.btnRefrescar.BackColor = System.Drawing.Color.PaleGreen
        Me.btnRefrescar.Location = New System.Drawing.Point(279, 368)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(203, 46)
        Me.btnRefrescar.TabIndex = 12
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.UseVisualStyleBackColor = False
        '
        'btnAdicionar
        '
        Me.btnAdicionar.BackColor = System.Drawing.Color.PaleGreen
        Me.btnAdicionar.Location = New System.Drawing.Point(34, 368)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(203, 46)
        Me.btnAdicionar.TabIndex = 11
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = False
        '
        'frm_Conductores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.dtgConductores)
        Me.Name = "frm_Conductores"
        Me.ShowIcon = False
        CType(Me.dtgConductores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUsuarioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgConductores As DataGridView
    Friend WithEvents CUsuarioBindingSource As BindingSource
    Friend WithEvents btnRefrescar As Button
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents IdPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TipoIdentifiPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdentificacionPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombrePersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ApellidoPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SexoPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EdadPersonaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
