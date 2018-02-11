<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajero4
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelVencimiento = New System.Windows.Forms.Label()
        Me.TextBoxCorreoElectronico = New System.Windows.Forms.TextBox()
        Me.TextBoxDireccion = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxIDSocio = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ButtonSiguiente = New System.Windows.Forms.Button()
        Me.ButtonRegresar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxTelefono = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBoxFoto = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBoxFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1094, 70)
        Me.Panel2.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 39.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(340, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(423, 64)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "LOGO O ESLOGAN"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(242, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 25)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "ID Socio:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(634, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(202, 25)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Fecha Vencimiento:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(261, 339)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 25)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "E-Mail:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(232, 287)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 25)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Dirección:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(247, 234)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 25)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Nombre:"
        '
        'LabelVencimiento
        '
        Me.LabelVencimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVencimiento.Location = New System.Drawing.Point(634, 179)
        Me.LabelVencimiento.Name = "LabelVencimiento"
        Me.LabelVencimiento.Size = New System.Drawing.Size(201, 42)
        Me.LabelVencimiento.TabIndex = 24
        Me.LabelVencimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxCorreoElectronico
        '
        Me.TextBoxCorreoElectronico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCorreoElectronico.BackColor = System.Drawing.Color.White
        Me.TextBoxCorreoElectronico.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCorreoElectronico.Enabled = False
        Me.TextBoxCorreoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCorreoElectronico.Location = New System.Drawing.Point(379, 339)
        Me.TextBoxCorreoElectronico.Name = "TextBoxCorreoElectronico"
        Me.TextBoxCorreoElectronico.ReadOnly = True
        Me.TextBoxCorreoElectronico.Size = New System.Drawing.Size(595, 33)
        Me.TextBoxCorreoElectronico.TabIndex = 23
        '
        'TextBoxDireccion
        '
        Me.TextBoxDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TextBoxDireccion.BackColor = System.Drawing.Color.White
        Me.TextBoxDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxDireccion.Enabled = False
        Me.TextBoxDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDireccion.Location = New System.Drawing.Point(379, 287)
        Me.TextBoxDireccion.Name = "TextBoxDireccion"
        Me.TextBoxDireccion.ReadOnly = True
        Me.TextBoxDireccion.Size = New System.Drawing.Size(595, 33)
        Me.TextBoxDireccion.TabIndex = 22
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TextBoxNombre.BackColor = System.Drawing.Color.White
        Me.TextBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxNombre.Enabled = False
        Me.TextBoxNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNombre.Location = New System.Drawing.Point(379, 234)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.ReadOnly = True
        Me.TextBoxNombre.Size = New System.Drawing.Size(595, 33)
        Me.TextBoxNombre.TabIndex = 21
        '
        'TextBoxIDSocio
        '
        Me.TextBoxIDSocio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TextBoxIDSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIDSocio.Enabled = False
        Me.TextBoxIDSocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIDSocio.Location = New System.Drawing.Point(378, 154)
        Me.TextBoxIDSocio.Name = "TextBoxIDSocio"
        Me.TextBoxIDSocio.Size = New System.Drawing.Size(250, 44)
        Me.TextBoxIDSocio.TabIndex = 19
        Me.TextBoxIDSocio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxIDSocio.WordWrap = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.ButtonSiguiente)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 456)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1094, 100)
        Me.Panel1.TabIndex = 30
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(331, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(432, 13)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Todos los derechos reservados, Diseño y Desarrollo propiedad de eImagen, (686) 21" & _
    "6-9883"
        '
        'ButtonSiguiente
        '
        Me.ButtonSiguiente.BackColor = System.Drawing.Color.DarkBlue
        Me.ButtonSiguiente.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonSiguiente.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSiguiente.ForeColor = System.Drawing.Color.White
        Me.ButtonSiguiente.Location = New System.Drawing.Point(844, 0)
        Me.ButtonSiguiente.Name = "ButtonSiguiente"
        Me.ButtonSiguiente.Size = New System.Drawing.Size(250, 100)
        Me.ButtonSiguiente.TabIndex = 1
        Me.ButtonSiguiente.Text = "SIGUIENTE"
        Me.ButtonSiguiente.UseVisualStyleBackColor = False
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.BackColor = System.Drawing.Color.DarkBlue
        Me.ButtonRegresar.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonRegresar.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRegresar.ForeColor = System.Drawing.Color.White
        Me.ButtonRegresar.Location = New System.Drawing.Point(0, 0)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(250, 100)
        Me.ButtonRegresar.TabIndex = 0
        Me.ButtonRegresar.Text = "REGRESAR"
        Me.ButtonRegresar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(238, 389)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 25)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Teléfono:"
        '
        'TextBoxTelefono
        '
        Me.TextBoxTelefono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TextBoxTelefono.BackColor = System.Drawing.Color.White
        Me.TextBoxTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxTelefono.Enabled = False
        Me.TextBoxTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTelefono.Location = New System.Drawing.Point(378, 389)
        Me.TextBoxTelefono.Name = "TextBoxTelefono"
        Me.TextBoxTelefono.ReadOnly = True
        Me.TextBoxTelefono.Size = New System.Drawing.Size(595, 33)
        Me.TextBoxTelefono.TabIndex = 31
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkBlue
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 70)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1094, 70)
        Me.Panel3.TabIndex = 33
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 39.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(139, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(787, 64)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "VERIFIQUE LOS SIGUIENTES DATOS"
        '
        'PictureBoxFoto
        '
        Me.PictureBoxFoto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBoxFoto.Location = New System.Drawing.Point(7, 160)
        Me.PictureBoxFoto.Name = "PictureBoxFoto"
        Me.PictureBoxFoto.Size = New System.Drawing.Size(213, 218)
        Me.PictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxFoto.TabIndex = 20
        Me.PictureBoxFoto.TabStop = False
        Me.PictureBoxFoto.WaitOnLoad = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 556)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1094, 35)
        Me.Panel4.TabIndex = 34
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkGray
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 35)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Version 1.0.0"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCajero4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1094, 591)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBoxTelefono)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelVencimiento)
        Me.Controls.Add(Me.TextBoxCorreoElectronico)
        Me.Controls.Add(Me.TextBoxDireccion)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.PictureBoxFoto)
        Me.Controls.Add(Me.TextBoxIDSocio)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCajero4"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCajero4"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBoxFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelVencimiento As System.Windows.Forms.Label
    Friend WithEvents TextBoxCorreoElectronico As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents PictureBoxFoto As System.Windows.Forms.PictureBox
    Friend WithEvents TextBoxIDSocio As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ButtonSiguiente As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
