<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Options
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
    Me.btnXml = New System.Windows.Forms.Button()
    Me.btnMemoria = New System.Windows.Forms.Button()
    Me.btnSql = New System.Windows.Forms.Button()
    Me.lblDescripcion = New System.Windows.Forms.Label()
    Me.lblMensaje = New System.Windows.Forms.Label()
    Me.btnCanelar = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'btnXml
    '
    Me.btnXml.BackColor = System.Drawing.Color.PaleGreen
    Me.btnXml.Location = New System.Drawing.Point(60, 132)
    Me.btnXml.Name = "btnXml"
    Me.btnXml.Size = New System.Drawing.Size(203, 46)
    Me.btnXml.TabIndex = 1
    Me.btnXml.Text = "XML"
    Me.btnXml.UseVisualStyleBackColor = False
    '
    'btnMemoria
    '
    Me.btnMemoria.BackColor = System.Drawing.Color.PaleGreen
    Me.btnMemoria.Location = New System.Drawing.Point(294, 132)
    Me.btnMemoria.Name = "btnMemoria"
    Me.btnMemoria.Size = New System.Drawing.Size(203, 46)
    Me.btnMemoria.TabIndex = 2
    Me.btnMemoria.Text = "MEMORIA"
    Me.btnMemoria.UseVisualStyleBackColor = False
    '
    'btnSql
    '
    Me.btnSql.BackColor = System.Drawing.Color.PaleGreen
    Me.btnSql.Location = New System.Drawing.Point(520, 132)
    Me.btnSql.Name = "btnSql"
    Me.btnSql.Size = New System.Drawing.Size(203, 46)
    Me.btnSql.TabIndex = 3
    Me.btnSql.Text = "SQL"
    Me.btnSql.UseVisualStyleBackColor = False
    '
    'lblDescripcion
    '
    Me.lblDescripcion.AutoSize = True
    Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblDescripcion.Location = New System.Drawing.Point(162, 66)
    Me.lblDescripcion.Name = "lblDescripcion"
    Me.lblDescripcion.Size = New System.Drawing.Size(468, 24)
    Me.lblDescripcion.TabIndex = 4
    Me.lblDescripcion.Text = "Antes de Continuar debe seleccionar una opción"
    '
    'lblMensaje
    '
    Me.lblMensaje.AutoSize = True
    Me.lblMensaje.ForeColor = System.Drawing.Color.Red
    Me.lblMensaje.Location = New System.Drawing.Point(215, 256)
    Me.lblMensaje.Name = "lblMensaje"
    Me.lblMensaje.Size = New System.Drawing.Size(0, 13)
    Me.lblMensaje.TabIndex = 5
    '
    'btnCanelar
    '
    Me.btnCanelar.BackColor = System.Drawing.Color.PaleGreen
    Me.btnCanelar.Location = New System.Drawing.Point(700, 1)
    Me.btnCanelar.Name = "btnCanelar"
    Me.btnCanelar.Size = New System.Drawing.Size(82, 26)
    Me.btnCanelar.TabIndex = 6
    Me.btnCanelar.Text = "Cancelar"
    Me.btnCanelar.UseVisualStyleBackColor = False
    '
    'frm_Options
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(782, 339)
    Me.ControlBox = False
    Me.Controls.Add(Me.btnCanelar)
    Me.Controls.Add(Me.lblMensaje)
    Me.Controls.Add(Me.lblDescripcion)
    Me.Controls.Add(Me.btnSql)
    Me.Controls.Add(Me.btnMemoria)
    Me.Controls.Add(Me.btnXml)
    Me.Name = "frm_Options"
    Me.ShowIcon = False
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btnXml As System.Windows.Forms.Button
  Friend WithEvents btnMemoria As System.Windows.Forms.Button
  Friend WithEvents btnSql As System.Windows.Forms.Button
  Friend WithEvents lblDescripcion As System.Windows.Forms.Label
  Friend WithEvents lblMensaje As System.Windows.Forms.Label
  Friend WithEvents btnCanelar As System.Windows.Forms.Button
End Class
