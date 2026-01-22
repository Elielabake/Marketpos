<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class profitssummation
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
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Button2 = New Guna.UI2.WinForms.Guna2Button()
        Me.tots = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.FromDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.Label5)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(800, 27)
        Me.Guna2Panel1.TabIndex = 776
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
        Me.Label5.Size = New System.Drawing.Size(46, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "الارباح"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(774, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "X"
        '
        'Guna2Button2
        '
        Me.Guna2Button2.AutoRoundedCorners = True
        Me.Guna2Button2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button2.BorderColor = System.Drawing.Color.White
        Me.Guna2Button2.BorderRadius = 14
        Me.Guna2Button2.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.Guna2Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button2.ForeColor = System.Drawing.Color.White
        Me.Guna2Button2.Location = New System.Drawing.Point(480, 164)
        Me.Guna2Button2.Name = "Guna2Button2"
        Me.Guna2Button2.Size = New System.Drawing.Size(121, 30)
        Me.Guna2Button2.TabIndex = 783
        Me.Guna2Button2.Text = "اظهر المجموع"
        '
        'tots
        '
        Me.tots.AutoSize = True
        Me.tots.BackColor = System.Drawing.Color.Gainsboro
        Me.tots.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tots.ForeColor = System.Drawing.Color.Red
        Me.tots.Location = New System.Drawing.Point(141, 90)
        Me.tots.Name = "tots"
        Me.tots.Size = New System.Drawing.Size(20, 22)
        Me.tots.TabIndex = 782
        Me.tots.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(105, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 22)
        Me.Label4.TabIndex = 781
        Me.Label4.Text = "مجموع الأرباح"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(698, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 22)
        Me.Label3.TabIndex = 780
        Me.Label3.Text = "الى تاريخ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(698, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 22)
        Me.Label2.TabIndex = 779
        Me.Label2.Text = "من تاريخ"
        '
        'ToDate
        '
        Me.ToDate.Animated = True
        Me.ToDate.AutoRoundedCorners = True
        Me.ToDate.BackColor = System.Drawing.Color.Transparent
        Me.ToDate.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToDate.BorderRadius = 17
        Me.ToDate.Checked = True
        Me.ToDate.FillColor = System.Drawing.Color.PaleTurquoise
        Me.ToDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDate.ForeColor = System.Drawing.Color.Black
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToDate.Location = New System.Drawing.Point(424, 107)
        Me.ToDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ToDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(221, 36)
        Me.ToDate.TabIndex = 778
        Me.ToDate.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.ToDate.Value = New Date(2023, 8, 31, 0, 0, 0, 0)
        '
        'FromDate
        '
        Me.FromDate.Animated = True
        Me.FromDate.AutoRoundedCorners = True
        Me.FromDate.BackColor = System.Drawing.Color.Transparent
        Me.FromDate.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.FromDate.BorderRadius = 17
        Me.FromDate.Checked = True
        Me.FromDate.FillColor = System.Drawing.Color.PaleTurquoise
        Me.FromDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromDate.ForeColor = System.Drawing.Color.Black
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FromDate.Location = New System.Drawing.Point(424, 36)
        Me.FromDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.FromDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(221, 36)
        Me.FromDate.TabIndex = 777
        Me.FromDate.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.FromDate.Value = New Date(2023, 8, 31, 0, 0, 0, 0)
        '
        'profitssummation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(800, 197)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Guna2Button2)
        Me.Controls.Add(Me.tots)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.FromDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "profitssummation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "profitssummation"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tots As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ToDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents FromDate As Guna.UI2.WinForms.Guna2DateTimePicker
End Class
