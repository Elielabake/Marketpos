<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckDB
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
        Me.lblDeviceName = New System.Windows.Forms.Label()
        Me.btnCheckInstance = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCheckDB = New Guna.UI2.WinForms.Guna2Button()
        Me.lblSavedConnection = New System.Windows.Forms.Label()
        Me.lstInstances = New System.Windows.Forms.ListBox()
        Me.cmbDBList = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnLoadDBs = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'lblDeviceName
        '
        Me.lblDeviceName.AutoSize = True
        Me.lblDeviceName.BackColor = System.Drawing.Color.Transparent
        Me.lblDeviceName.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblDeviceName.Location = New System.Drawing.Point(208, 9)
        Me.lblDeviceName.Name = "lblDeviceName"
        Me.lblDeviceName.Size = New System.Drawing.Size(0, 24)
        Me.lblDeviceName.TabIndex = 736
        '
        'btnCheckInstance
        '
        Me.btnCheckInstance.AutoRoundedCorners = True
        Me.btnCheckInstance.BackColor = System.Drawing.Color.Transparent
        Me.btnCheckInstance.BorderColor = System.Drawing.Color.White
        Me.btnCheckInstance.BorderRadius = 14
        Me.btnCheckInstance.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnCheckInstance.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheckInstance.ForeColor = System.Drawing.Color.White
        Me.btnCheckInstance.Location = New System.Drawing.Point(159, 36)
        Me.btnCheckInstance.Name = "btnCheckInstance"
        Me.btnCheckInstance.Size = New System.Drawing.Size(197, 30)
        Me.btnCheckInstance.TabIndex = 738
        Me.btnCheckInstance.Text = "Check SQL Instances"
        '
        'btnCheckDB
        '
        Me.btnCheckDB.AutoRoundedCorners = True
        Me.btnCheckDB.BackColor = System.Drawing.Color.Transparent
        Me.btnCheckDB.BorderColor = System.Drawing.Color.White
        Me.btnCheckDB.BorderRadius = 14
        Me.btnCheckDB.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnCheckDB.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheckDB.ForeColor = System.Drawing.Color.White
        Me.btnCheckDB.Location = New System.Drawing.Point(12, 141)
        Me.btnCheckDB.Name = "btnCheckDB"
        Me.btnCheckDB.Size = New System.Drawing.Size(186, 30)
        Me.btnCheckDB.TabIndex = 739
        Me.btnCheckDB.Text = "SAVE DATABASE"
        '
        'lblSavedConnection
        '
        Me.lblSavedConnection.AutoSize = True
        Me.lblSavedConnection.BackColor = System.Drawing.Color.Transparent
        Me.lblSavedConnection.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSavedConnection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblSavedConnection.Location = New System.Drawing.Point(26, 9)
        Me.lblSavedConnection.Name = "lblSavedConnection"
        Me.lblSavedConnection.Size = New System.Drawing.Size(0, 24)
        Me.lblSavedConnection.TabIndex = 740
        '
        'lstInstances
        '
        Me.lstInstances.FormattingEnabled = True
        Me.lstInstances.Location = New System.Drawing.Point(201, 72)
        Me.lstInstances.Name = "lstInstances"
        Me.lstInstances.Size = New System.Drawing.Size(155, 108)
        Me.lstInstances.TabIndex = 741
        '
        'cmbDBList
        '
        Me.cmbDBList.BackColor = System.Drawing.Color.Transparent
        Me.cmbDBList.BorderColor = System.Drawing.Color.Black
        Me.cmbDBList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDBList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDBList.FillColor = System.Drawing.Color.WhiteSmoke
        Me.cmbDBList.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDBList.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDBList.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbDBList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbDBList.IntegralHeight = False
        Me.cmbDBList.ItemHeight = 22
        Me.cmbDBList.Location = New System.Drawing.Point(12, 107)
        Me.cmbDBList.Name = "cmbDBList"
        Me.cmbDBList.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbDBList.Size = New System.Drawing.Size(183, 28)
        Me.cmbDBList.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.cmbDBList.TabIndex = 743
        Me.cmbDBList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnLoadDBs
        '
        Me.btnLoadDBs.AutoRoundedCorners = True
        Me.btnLoadDBs.BackColor = System.Drawing.Color.Transparent
        Me.btnLoadDBs.BorderColor = System.Drawing.Color.White
        Me.btnLoadDBs.BorderRadius = 14
        Me.btnLoadDBs.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnLoadDBs.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnLoadDBs.ForeColor = System.Drawing.Color.White
        Me.btnLoadDBs.Location = New System.Drawing.Point(12, 72)
        Me.btnLoadDBs.Name = "btnLoadDBs"
        Me.btnLoadDBs.Size = New System.Drawing.Size(183, 30)
        Me.btnLoadDBs.TabIndex = 744
        Me.btnLoadDBs.Text = "LOAD DATABASE"
        '
        'frmCheckDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 249)
        Me.Controls.Add(Me.btnLoadDBs)
        Me.Controls.Add(Me.cmbDBList)
        Me.Controls.Add(Me.lstInstances)
        Me.Controls.Add(Me.lblSavedConnection)
        Me.Controls.Add(Me.btnCheckDB)
        Me.Controls.Add(Me.btnCheckInstance)
        Me.Controls.Add(Me.lblDeviceName)
        Me.Name = "frmCheckDB"
        Me.Text = "frmCheckDB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDeviceName As Label
    Friend WithEvents btnCheckInstance As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCheckDB As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblSavedConnection As Label
    Friend WithEvents lstInstances As ListBox
    Friend WithEvents cmbDBList As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnLoadDBs As Guna.UI2.WinForms.Guna2Button
End Class
