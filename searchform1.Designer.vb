<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class searchform1
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
        Me.bc = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pn = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'bc
        '
        Me.bc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.bc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.bc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.bc.BorderRadius = 10
        Me.bc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.bc.DefaultText = ""
        Me.bc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.bc.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.bc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.bc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.bc.FillColor = System.Drawing.Color.WhiteSmoke
        Me.bc.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.bc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.bc.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bc.Location = New System.Drawing.Point(114, 58)
        Me.bc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bc.Name = "bc"
        Me.bc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.bc.PlaceholderForeColor = System.Drawing.Color.White
        Me.bc.PlaceholderText = ""
        Me.bc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.bc.SelectedText = ""
        Me.bc.Size = New System.Drawing.Size(178, 23)
        Me.bc.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.bc.TabIndex = 1
        '
        'pn
        '
        Me.pn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.pn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.pn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.pn.BorderRadius = 10
        Me.pn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pn.DefaultText = ""
        Me.pn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.pn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.pn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pn.FillColor = System.Drawing.Color.WhiteSmoke
        Me.pn.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.pn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.pn.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pn.Location = New System.Drawing.Point(114, 25)
        Me.pn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pn.Name = "pn"
        Me.pn.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.pn.PlaceholderForeColor = System.Drawing.Color.White
        Me.pn.PlaceholderText = ""
        Me.pn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pn.SelectedText = ""
        Me.pn.Size = New System.Drawing.Size(178, 23)
        Me.pn.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.pn.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(299, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 22)
        Me.Label3.TabIndex = 778
        Me.Label3.Text = "اسم المنتج"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(316, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 22)
        Me.Label4.TabIndex = 779
        Me.Label4.Text = "الباركود"
        '
        'Button1
        '
        Me.Button1.AutoRoundedCorners = True
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BorderColor = System.Drawing.Color.White
        Me.Button1.BorderRadius = 14
        Me.Button1.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(184, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 30)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "تم"
        '
        'searchform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(489, 167)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bc)
        Me.Controls.Add(Me.pn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Name = "searchform"
        Me.Text = "searchform"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bc As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pn As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Guna.UI2.WinForms.Guna2Button
End Class
