<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajero41
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ButtonSiguiente = New System.Windows.Forms.Button()
        Me.ButtonRegresar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelNombreMembresia = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.ListViewProductos = New System.Windows.Forms.ListView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkBlue
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
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(-5, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1106, 64)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "SELECCIONA LA MEMBRESIA DE TU PREFERENCIA"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.ButtonSiguiente)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 564)
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
        Me.ButtonSiguiente.Text = "LIQUIDAR"
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
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label1.Location = New System.Drawing.Point(0, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1094, 64)
        Me.Label1.TabIndex = 31
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelNombreMembresia
        '
        Me.LabelNombreMembresia.AutoSize = True
        Me.LabelNombreMembresia.Location = New System.Drawing.Point(123, 516)
        Me.LabelNombreMembresia.Name = "LabelNombreMembresia"
        Me.LabelNombreMembresia.Size = New System.Drawing.Size(39, 13)
        Me.LabelNombreMembresia.TabIndex = 35
        Me.LabelNombreMembresia.Text = "Label3"
        Me.LabelNombreMembresia.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(608, 492)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 45)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Importe:"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TextBox1.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(769, 478)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(259, 66)
        Me.TextBox1.TabIndex = 32
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.VScrollBar1)
        Me.Panel3.Controls.Add(Me.ListViewProductos)
        Me.Panel3.Location = New System.Drawing.Point(49, 137)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(979, 326)
        Me.Panel3.TabIndex = 34
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.VScrollBar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.VScrollBar1.Location = New System.Drawing.Point(907, 0)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(72, 326)
        Me.VScrollBar1.TabIndex = 9
        '
        'ListViewProductos
        '
        Me.ListViewProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewProductos.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewProductos.FullRowSelect = True
        Me.ListViewProductos.GridLines = True
        Me.ListViewProductos.HideSelection = False
        Me.ListViewProductos.Location = New System.Drawing.Point(0, 0)
        Me.ListViewProductos.MultiSelect = False
        Me.ListViewProductos.Name = "ListViewProductos"
        Me.ListViewProductos.Size = New System.Drawing.Size(979, 326)
        Me.ListViewProductos.TabIndex = 8
        Me.ListViewProductos.UseCompatibleStateImageBehavior = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 664)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1094, 35)
        Me.Panel4.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGray
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 35)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Version 1.0.0"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCajero41
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1094, 699)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelNombreMembresia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCajero41"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCajero41"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ButtonSiguiente As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelNombreMembresia As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents ListViewProductos As System.Windows.Forms.ListView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
