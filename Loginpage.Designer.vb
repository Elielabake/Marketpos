<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Loginpage
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
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Shapes2 = New Guna.UI2.WinForms.Guna2Shapes()
        Me.Upass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Uname = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.rtype = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2GradientPanel2 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2PictureBox2 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2GradientPanel2.SuspendLayout()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.Label5)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Shapes2)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(711, 27)
        Me.Guna2Panel1.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "صفحة الدخول"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(685, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "X"
        '
        'Guna2Shapes2
        '
        Me.Guna2Shapes2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Shapes2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Shapes2.BorderColor = System.Drawing.Color.Transparent
        Me.Guna2Shapes2.BorderThickness = 1
        Me.Guna2Shapes2.FillColor = System.Drawing.Color.White
        Me.Guna2Shapes2.LineThickness = 3
        Me.Guna2Shapes2.Location = New System.Drawing.Point(663, 9)
        Me.Guna2Shapes2.Name = "Guna2Shapes2"
        Me.Guna2Shapes2.PolygonSkip = 1
        Me.Guna2Shapes2.Rotate = 0!
        Me.Guna2Shapes2.Shape = Guna.UI2.WinForms.Enums.ShapeType.Line
        Me.Guna2Shapes2.Size = New System.Drawing.Size(21, 20)
        Me.Guna2Shapes2.TabIndex = 2
        Me.Guna2Shapes2.Text = "Guna2Shapes2"
        Me.Guna2Shapes2.UseTransparentBackground = True
        Me.Guna2Shapes2.Zoom = 70
        '
        'Upass
        '
        Me.Upass.BackColor = System.Drawing.Color.Transparent
        Me.Upass.BorderColor = System.Drawing.Color.Black
        Me.Upass.BorderRadius = 50
        Me.Upass.BorderThickness = 3
        Me.Upass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Upass.DefaultText = ""
        Me.Upass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Upass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Upass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Upass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Upass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Upass.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Upass.ForeColor = System.Drawing.Color.Black
        Me.Upass.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Upass.Location = New System.Drawing.Point(64, 244)
        Me.Upass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Upass.Name = "Upass"
        Me.Upass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Upass.PlaceholderText = ""
        Me.Upass.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Upass.SelectedText = ""
        Me.Upass.Size = New System.Drawing.Size(172, 24)
        Me.Upass.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.Upass.TabIndex = 6
        '
        'Uname
        '
        Me.Uname.BackColor = System.Drawing.Color.Transparent
        Me.Uname.BorderColor = System.Drawing.Color.Black
        Me.Uname.BorderThickness = 3
        Me.Uname.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Uname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Uname.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Uname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Uname.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Uname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.Uname.IntegralHeight = False
        Me.Uname.ItemHeight = 22
        Me.Uname.Location = New System.Drawing.Point(64, 152)
        Me.Uname.Name = "Uname"
        Me.Uname.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Uname.Size = New System.Drawing.Size(172, 28)
        Me.Uname.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.Uname.TabIndex = 7
        Me.Uname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rtype
        '
        Me.rtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.rtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.rtype.BorderColor = System.Drawing.Color.Black
        Me.rtype.BorderRadius = 10
        Me.rtype.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rtype.DefaultText = ""
        Me.rtype.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.rtype.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.rtype.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.rtype.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.rtype.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.rtype.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtype.ForeColor = System.Drawing.Color.Black
        Me.rtype.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rtype.Location = New System.Drawing.Point(501, 355)
        Me.rtype.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rtype.MaxLength = 17
        Me.rtype.Name = "rtype"
        Me.rtype.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.rtype.PlaceholderForeColor = System.Drawing.Color.White
        Me.rtype.PlaceholderText = ""
        Me.rtype.SelectedText = ""
        Me.rtype.Size = New System.Drawing.Size(183, 26)
        Me.rtype.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.rtype.TabIndex = 593
        Me.rtype.Visible = False
        '
        'Guna2GradientPanel2
        '
        Me.Guna2GradientPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Guna2GradientPanel2.Controls.Add(Me.Label4)
        Me.Guna2GradientPanel2.Controls.Add(Me.Label2)
        Me.Guna2GradientPanel2.Controls.Add(Me.Guna2PictureBox2)
        Me.Guna2GradientPanel2.Controls.Add(Me.Uname)
        Me.Guna2GradientPanel2.Controls.Add(Me.Upass)
        Me.Guna2GradientPanel2.Location = New System.Drawing.Point(215, 68)
        Me.Guna2GradientPanel2.Name = "Guna2GradientPanel2"
        Me.Guna2GradientPanel2.Size = New System.Drawing.Size(279, 386)
        Me.Guna2GradientPanel2.TabIndex = 596
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(166, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 22)
        Me.Label4.TabIndex = 696
        Me.Label4.Text = "كلمة السر"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(141, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 22)
        Me.Label2.TabIndex = 697
        Me.Label2.Text = "اسم المستخدم"
        '
        'Guna2PictureBox2
        '
        Me.Guna2PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox2.Image = Global.Market.My.Resources.Resources.Black_Background_Log
        Me.Guna2PictureBox2.ImageRotate = 0!
        Me.Guna2PictureBox2.Location = New System.Drawing.Point(91, 3)
        Me.Guna2PictureBox2.Name = "Guna2PictureBox2"
        Me.Guna2PictureBox2.Size = New System.Drawing.Size(106, 91)
        Me.Guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox2.TabIndex = 3
        Me.Guna2PictureBox2.TabStop = False
        Me.Guna2PictureBox2.UseTransparentBackground = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Market.My.Resources.Resources.Picsart_24_09_09_17_32_33_635
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(711, 525)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 595
        Me.PictureBox1.TabStop = False
        '
        'Loginpage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 525)
        Me.Controls.Add(Me.Guna2GradientPanel2)
        Me.Controls.Add(Me.rtype)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Loginpage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loginpage"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.Guna2GradientPanel2.ResumeLayout(False)
        Me.Guna2GradientPanel2.PerformLayout()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Shapes2 As Guna.UI2.WinForms.Guna2Shapes
    Friend WithEvents Guna2PictureBox2 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Upass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Uname As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents rtype As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Guna2GradientPanel2 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
End Class
