<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmStockCodes
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtStockId = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtMainCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtAltCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dgvCodes = New Zuby.ADGV.AdvancedDataGridView()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtStockId
        '
        Me.txtStockId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStockId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtStockId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtStockId.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtStockId.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtStockId.BorderRadius = 10
        Me.txtStockId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStockId.DefaultText = ""
        Me.txtStockId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtStockId.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtStockId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtStockId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtStockId.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtStockId.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtStockId.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtStockId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtStockId.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStockId.Location = New System.Drawing.Point(1180, 240)
        Me.txtStockId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtStockId.Name = "txtStockId"
        Me.txtStockId.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtStockId.PlaceholderText = ""
        Me.txtStockId.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStockId.SelectedText = ""
        Me.txtStockId.Size = New System.Drawing.Size(183, 26)
        Me.txtStockId.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtStockId.TabIndex = 1
        Me.txtStockId.Visible = False
        '
        'txtMainCode
        '
        Me.txtMainCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMainCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtMainCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtMainCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtMainCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtMainCode.BorderRadius = 10
        Me.txtMainCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMainCode.DefaultText = ""
        Me.txtMainCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtMainCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtMainCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMainCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMainCode.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtMainCode.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtMainCode.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtMainCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtMainCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMainCode.Location = New System.Drawing.Point(1037, 42)
        Me.txtMainCode.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtMainCode.Name = "txtMainCode"
        Me.txtMainCode.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtMainCode.PlaceholderText = ""
        Me.txtMainCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMainCode.SelectedText = ""
        Me.txtMainCode.Size = New System.Drawing.Size(183, 26)
        Me.txtMainCode.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtMainCode.TabIndex = 2
        '
        'txtAltCode
        '
        Me.txtAltCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAltCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAltCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAltCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAltCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtAltCode.BorderRadius = 10
        Me.txtAltCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAltCode.DefaultText = ""
        Me.txtAltCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAltCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAltCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAltCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAltCode.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtAltCode.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtAltCode.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtAltCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtAltCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAltCode.Location = New System.Drawing.Point(1037, 86)
        Me.txtAltCode.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtAltCode.Name = "txtAltCode"
        Me.txtAltCode.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtAltCode.PlaceholderText = ""
        Me.txtAltCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAltCode.SelectedText = ""
        Me.txtAltCode.Size = New System.Drawing.Size(183, 26)
        Me.txtAltCode.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtAltCode.TabIndex = 3
        '
        'dgvCodes
        '
        Me.dgvCodes.AllowUserToAddRows = False
        Me.dgvCodes.AllowUserToDeleteRows = False
        Me.dgvCodes.AllowUserToResizeColumns = False
        Me.dgvCodes.AllowUserToResizeRows = False
        Me.dgvCodes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCodes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCodes.BackgroundColor = System.Drawing.Color.White
        Me.dgvCodes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCodes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCodes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvCodes.ColumnHeadersHeight = 45
        Me.dgvCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCodes.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvCodes.EnableHeadersVisualStyles = False
        Me.dgvCodes.FilterAndSortEnabled = True
        Me.dgvCodes.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.dgvCodes.Location = New System.Drawing.Point(12, 42)
        Me.dgvCodes.MaxFilterButtonImageHeight = 23
        Me.dgvCodes.Name = "dgvCodes"
        Me.dgvCodes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvCodes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCodes.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvCodes.RowHeadersVisible = False
        Me.dgvCodes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCodes.Size = New System.Drawing.Size(967, 714)
        Me.dgvCodes.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.dgvCodes.TabIndex = 734
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.AutoRoundedCorners = True
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.BorderColor = System.Drawing.Color.White
        Me.btnDelete.BorderRadius = 14
        Me.btnDelete.FillColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(1126, 139)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnDelete.TabIndex = 736
        Me.btnDelete.Text = " [Del]مسح "
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.AutoRoundedCorners = True
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.BorderColor = System.Drawing.Color.White
        Me.btnAdd.BorderRadius = 14
        Me.btnAdd.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(1232, 139)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 30)
        Me.btnAdd.TabIndex = 735
        Me.btnAdd.Text = " [Enter]اضافة "
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(1237, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(115, 22)
        Me.Label12.TabIndex = 737
        Me.Label12.Text = "الباركود الاساسي"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1246, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(106, 22)
        Me.Label1.TabIndex = 738
        Me.Label1.Text = "الباركود الثانوي"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.Label5)
        Me.Guna2Panel1.Controls.Add(Me.Label2)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1366, 27)
        Me.Guna2Panel1.TabIndex = 739
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
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "ELPOS-باركودات مشتركة"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1340, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "X"
        '
        'FrmStockCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvCodes)
        Me.Controls.Add(Me.txtAltCode)
        Me.Controls.Add(Me.txtMainCode)
        Me.Controls.Add(Me.txtStockId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmStockCodes"
        Me.Text = "FrmStockCodes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtStockId As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtMainCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtAltCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvCodes As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
End Class
