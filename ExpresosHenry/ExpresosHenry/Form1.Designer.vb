<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.pnlFomrs = New System.Windows.Forms.Panel()
        Me.lblSaludo = New System.Windows.Forms.Label()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.btnVehiculos = New System.Windows.Forms.Button()
        Me.btnCondutores = New System.Windows.Forms.Button()
        Me.btnTickets = New System.Windows.Forms.Button()
        Me.pnlDescripcion = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.InicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlDesMenu = New System.Windows.Forms.Panel()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.pnlFomrs.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.pnlDesMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFomrs
        '
        Me.pnlFomrs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFomrs.AutoSize = True
        Me.pnlFomrs.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlFomrs.Controls.Add(Me.lblSaludo)
        Me.pnlFomrs.Location = New System.Drawing.Point(227, 84)
        Me.pnlFomrs.Name = "pnlFomrs"
        Me.pnlFomrs.Size = New System.Drawing.Size(592, 363)
        Me.pnlFomrs.TabIndex = 0
        '
        'lblSaludo
        '
        Me.lblSaludo.AutoSize = True
        Me.lblSaludo.BackColor = System.Drawing.Color.Transparent
        Me.lblSaludo.Font = New System.Drawing.Font("Script MT Bold", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaludo.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblSaludo.Location = New System.Drawing.Point(47, 131)
        Me.lblSaludo.Name = "lblSaludo"
        Me.lblSaludo.Size = New System.Drawing.Size(464, 115)
        Me.lblSaludo.TabIndex = 0
        Me.lblSaludo.Text = "Bienvenido"
        '
        'pnlMenu
        '
        Me.pnlMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlMenu.Controls.Add(Me.btnClientes)
        Me.pnlMenu.Controls.Add(Me.btnVehiculos)
        Me.pnlMenu.Controls.Add(Me.btnCondutores)
        Me.pnlMenu.Controls.Add(Me.btnTickets)
        Me.pnlMenu.Location = New System.Drawing.Point(12, 84)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(209, 363)
        Me.pnlMenu.TabIndex = 1
        '
        'btnClientes
        '
        Me.btnClientes.BackColor = System.Drawing.Color.PaleGreen
        Me.btnClientes.Location = New System.Drawing.Point(3, 55)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(203, 46)
        Me.btnClientes.TabIndex = 3
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.UseVisualStyleBackColor = False
        '
        'btnVehiculos
        '
        Me.btnVehiculos.BackColor = System.Drawing.Color.PaleGreen
        Me.btnVehiculos.Location = New System.Drawing.Point(3, 107)
        Me.btnVehiculos.Name = "btnVehiculos"
        Me.btnVehiculos.Size = New System.Drawing.Size(203, 46)
        Me.btnVehiculos.TabIndex = 2
        Me.btnVehiculos.Text = "Vehiculos"
        Me.btnVehiculos.UseVisualStyleBackColor = False
        '
        'btnCondutores
        '
        Me.btnCondutores.BackColor = System.Drawing.Color.PaleGreen
        Me.btnCondutores.Location = New System.Drawing.Point(3, 158)
        Me.btnCondutores.Name = "btnCondutores"
        Me.btnCondutores.Size = New System.Drawing.Size(203, 46)
        Me.btnCondutores.TabIndex = 1
        Me.btnCondutores.Text = "Conductores"
        Me.btnCondutores.UseVisualStyleBackColor = False
        '
        'btnTickets
        '
        Me.btnTickets.BackColor = System.Drawing.Color.PaleGreen
        Me.btnTickets.Location = New System.Drawing.Point(3, 3)
        Me.btnTickets.Name = "btnTickets"
        Me.btnTickets.Size = New System.Drawing.Size(203, 46)
        Me.btnTickets.TabIndex = 0
        Me.btnTickets.Text = "Tickets"
        Me.btnTickets.UseVisualStyleBackColor = False
        '
        'pnlDescripcion
        '
        Me.pnlDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDescripcion.AutoSize = True
        Me.pnlDescripcion.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlDescripcion.Location = New System.Drawing.Point(227, 34)
        Me.pnlDescripcion.Name = "pnlDescripcion"
        Me.pnlDescripcion.Size = New System.Drawing.Size(592, 44)
        Me.pnlDescripcion.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InicioToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(831, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'InicioToolStripMenuItem
        '
        Me.InicioToolStripMenuItem.Name = "InicioToolStripMenuItem"
        Me.InicioToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.InicioToolStripMenuItem.Text = "Inicio"
        '
        'pnlDesMenu
        '
        Me.pnlDesMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlDesMenu.Controls.Add(Me.lblMenu)
        Me.pnlDesMenu.Location = New System.Drawing.Point(12, 34)
        Me.pnlDesMenu.Name = "pnlDesMenu"
        Me.pnlDesMenu.Size = New System.Drawing.Size(209, 44)
        Me.pnlDesMenu.TabIndex = 0
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = True
        Me.lblMenu.BackColor = System.Drawing.Color.Transparent
        Me.lblMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenu.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblMenu.Location = New System.Drawing.Point(52, 15)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Size = New System.Drawing.Size(77, 29)
        Me.lblMenu.TabIndex = 0
        Me.lblMenu.Text = "Menú"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(831, 459)
        Me.Controls.Add(Me.pnlDesMenu)
        Me.Controls.Add(Me.pnlDescripcion)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlFomrs)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "Expresos Henry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlFomrs.ResumeLayout(False)
        Me.pnlFomrs.PerformLayout()
        Me.pnlMenu.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pnlDesMenu.ResumeLayout(False)
        Me.pnlDesMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlFomrs As Panel
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents pnlDescripcion As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents pnlDesMenu As Panel
    Friend WithEvents btnClientes As Button
    Friend WithEvents btnVehiculos As Button
    Friend WithEvents btnCondutores As Button
    Friend WithEvents btnTickets As Button
    Friend WithEvents InicioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblSaludo As Label
    Friend WithEvents lblMenu As Label
End Class
