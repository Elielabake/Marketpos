<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Start
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
        Me.Guna2ProgressBar1 = New Guna.UI2.WinForms.Guna2ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2ProgressBar1
        '
        Me.Guna2ProgressBar1.FillColor = System.Drawing.Color.Transparent
        Me.Guna2ProgressBar1.Location = New System.Drawing.Point(-1, 339)
        Me.Guna2ProgressBar1.Name = "Guna2ProgressBar1"
        Me.Guna2ProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Guna2ProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Guna2ProgressBar1.Size = New System.Drawing.Size(664, 16)
        Me.Guna2ProgressBar1.TabIndex = 2
        Me.Guna2ProgressBar1.Text = "Guna2ProgressBar1"
        Me.Guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        '
        'Timer1
        '
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(301, 282)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Visible = False
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox1.Image = Global.Market.My.Resources.Resources.Blue_Background_JPG_Artboard_6_07
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(-1, -110)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(680, 512)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 0
        Me.Guna2PictureBox1.TabStop = False
        '
        'Start
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 356)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Guna2ProgressBar1)
        Me.Controls.Add(Me.Guna2PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Start"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Start"
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2ProgressBar1 As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox1 As TextBox
End Class
