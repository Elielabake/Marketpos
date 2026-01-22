<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStockComposite
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtQtyJ = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCodeJ = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtCostD = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cmbCat = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtDP = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPriceJL = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtPriceJD = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtPricel = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtPriceD = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtCostl = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtPName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtQtyAvailable = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvComponents = New Zuby.ADGV.AdvancedDataGridView()
        Me.ComponentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComponentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyUsed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalCostD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalCostL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalPriceD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalPriceL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalPriceDj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalPriceLj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRemoveComponent = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddComponent = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.dgvComponents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtQtyJ
        '
        Me.txtQtyJ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQtyJ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtQtyJ.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtQtyJ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtQtyJ.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtQtyJ.BorderRadius = 10
        Me.txtQtyJ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQtyJ.DefaultText = ""
        Me.txtQtyJ.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtQtyJ.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtQtyJ.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQtyJ.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQtyJ.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtQtyJ.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtQtyJ.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtQtyJ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtQtyJ.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQtyJ.Location = New System.Drawing.Point(983, 327)
        Me.txtQtyJ.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtQtyJ.Name = "txtQtyJ"
        Me.txtQtyJ.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtQtyJ.PlaceholderText = ""
        Me.txtQtyJ.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtQtyJ.SelectedText = ""
        Me.txtQtyJ.Size = New System.Drawing.Size(226, 26)
        Me.txtQtyJ.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtQtyJ.TabIndex = 817
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(1258, 331)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 22)
        Me.Label18.TabIndex = 829
        Me.Label18.Text = "الكمية جملة"
        '
        'txtCodeJ
        '
        Me.txtCodeJ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodeJ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCodeJ.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCodeJ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCodeJ.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtCodeJ.BorderRadius = 10
        Me.txtCodeJ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodeJ.DefaultText = ""
        Me.txtCodeJ.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCodeJ.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCodeJ.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCodeJ.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCodeJ.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtCodeJ.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtCodeJ.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtCodeJ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtCodeJ.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCodeJ.Location = New System.Drawing.Point(981, 236)
        Me.txtCodeJ.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCodeJ.Name = "txtCodeJ"
        Me.txtCodeJ.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtCodeJ.PlaceholderText = ""
        Me.txtCodeJ.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCodeJ.SelectedText = ""
        Me.txtCodeJ.Size = New System.Drawing.Size(226, 26)
        Me.txtCodeJ.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtCodeJ.TabIndex = 814
        '
        'txtCostD
        '
        Me.txtCostD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCostD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCostD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCostD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCostD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtCostD.BorderRadius = 10
        Me.txtCostD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCostD.DefaultText = ""
        Me.txtCostD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCostD.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCostD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCostD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCostD.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtCostD.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtCostD.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtCostD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtCostD.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCostD.Location = New System.Drawing.Point(981, 131)
        Me.txtCostD.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCostD.Name = "txtCostD"
        Me.txtCostD.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtCostD.PlaceholderText = ""
        Me.txtCostD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCostD.SelectedText = ""
        Me.txtCostD.Size = New System.Drawing.Size(226, 26)
        Me.txtCostD.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtCostD.TabIndex = 810
        '
        'cmbCat
        '
        Me.cmbCat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCat.BackColor = System.Drawing.Color.Transparent
        Me.cmbCat.BorderColor = System.Drawing.Color.Black
        Me.cmbCat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCat.DropDownHeight = 300
        Me.cmbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCat.FillColor = System.Drawing.Color.WhiteSmoke
        Me.cmbCat.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbCat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbCat.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbCat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbCat.IntegralHeight = False
        Me.cmbCat.ItemHeight = 22
        Me.cmbCat.Location = New System.Drawing.Point(981, 78)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCat.Size = New System.Drawing.Size(226, 28)
        Me.cmbCat.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.cmbCat.TabIndex = 808
        Me.cmbCat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDP
        '
        Me.txtDP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtDP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDP.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtDP.BorderRadius = 10
        Me.txtDP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDP.DefaultText = ""
        Me.txtDP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDP.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDP.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtDP.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtDP.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtDP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtDP.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDP.Location = New System.Drawing.Point(981, 105)
        Me.txtDP.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtDP.Name = "txtDP"
        Me.txtDP.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtDP.PlaceholderText = ""
        Me.txtDP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDP.SelectedText = ""
        Me.txtDP.Size = New System.Drawing.Size(226, 26)
        Me.txtDP.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtDP.TabIndex = 809
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(1256, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 22)
        Me.Label10.TabIndex = 827
        Me.Label10.Text = "سعر الدولار"
        '
        'txtPriceJL
        '
        Me.txtPriceJL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPriceJL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPriceJL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPriceJL.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPriceJL.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPriceJL.BorderRadius = 10
        Me.txtPriceJL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPriceJL.DefaultText = ""
        Me.txtPriceJL.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPriceJL.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPriceJL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPriceJL.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPriceJL.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtPriceJL.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtPriceJL.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtPriceJL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPriceJL.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPriceJL.Location = New System.Drawing.Point(981, 297)
        Me.txtPriceJL.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPriceJL.Name = "txtPriceJL"
        Me.txtPriceJL.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtPriceJL.PlaceholderText = ""
        Me.txtPriceJL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPriceJL.SelectedText = ""
        Me.txtPriceJL.Size = New System.Drawing.Size(226, 26)
        Me.txtPriceJL.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtPriceJL.TabIndex = 816
        '
        'txtPriceJD
        '
        Me.txtPriceJD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPriceJD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPriceJD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPriceJD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPriceJD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPriceJD.BorderRadius = 10
        Me.txtPriceJD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPriceJD.DefaultText = ""
        Me.txtPriceJD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPriceJD.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPriceJD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPriceJD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPriceJD.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtPriceJD.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtPriceJD.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtPriceJD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPriceJD.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPriceJD.Location = New System.Drawing.Point(981, 266)
        Me.txtPriceJD.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPriceJD.Name = "txtPriceJD"
        Me.txtPriceJD.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtPriceJD.PlaceholderText = ""
        Me.txtPriceJD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPriceJD.SelectedText = ""
        Me.txtPriceJD.Size = New System.Drawing.Size(226, 26)
        Me.txtPriceJD.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtPriceJD.TabIndex = 815
        '
        'txtPricel
        '
        Me.txtPricel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPricel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPricel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPricel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPricel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPricel.BorderRadius = 10
        Me.txtPricel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPricel.DefaultText = ""
        Me.txtPricel.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPricel.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPricel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPricel.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPricel.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtPricel.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtPricel.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtPricel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPricel.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPricel.Location = New System.Drawing.Point(981, 208)
        Me.txtPricel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPricel.Name = "txtPricel"
        Me.txtPricel.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtPricel.PlaceholderText = ""
        Me.txtPricel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPricel.SelectedText = ""
        Me.txtPricel.Size = New System.Drawing.Size(226, 26)
        Me.txtPricel.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtPricel.TabIndex = 813
        '
        'txtPriceD
        '
        Me.txtPriceD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPriceD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPriceD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPriceD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPriceD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPriceD.BorderRadius = 10
        Me.txtPriceD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPriceD.DefaultText = ""
        Me.txtPriceD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPriceD.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPriceD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPriceD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPriceD.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtPriceD.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtPriceD.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtPriceD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPriceD.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPriceD.Location = New System.Drawing.Point(981, 182)
        Me.txtPriceD.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPriceD.Name = "txtPriceD"
        Me.txtPriceD.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtPriceD.PlaceholderText = ""
        Me.txtPriceD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPriceD.SelectedText = ""
        Me.txtPriceD.Size = New System.Drawing.Size(226, 26)
        Me.txtPriceD.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtPriceD.TabIndex = 812
        '
        'txtCostl
        '
        Me.txtCostl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCostl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCostl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCostl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCostl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtCostl.BorderRadius = 10
        Me.txtCostl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCostl.DefaultText = ""
        Me.txtCostl.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCostl.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCostl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCostl.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCostl.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtCostl.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtCostl.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtCostl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtCostl.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCostl.Location = New System.Drawing.Point(981, 156)
        Me.txtCostl.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCostl.Name = "txtCostl"
        Me.txtCostl.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtCostl.PlaceholderText = ""
        Me.txtCostl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCostl.SelectedText = ""
        Me.txtCostl.Size = New System.Drawing.Size(226, 26)
        Me.txtCostl.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtCostl.TabIndex = 811
        '
        'txtCode
        '
        Me.txtCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtCode.BorderRadius = 10
        Me.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCode.DefaultText = ""
        Me.txtCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCode.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtCode.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtCode.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCode.Location = New System.Drawing.Point(981, 23)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtCode.PlaceholderText = ""
        Me.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCode.SelectedText = ""
        Me.txtCode.Size = New System.Drawing.Size(226, 26)
        Me.txtCode.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtCode.TabIndex = 806
        '
        'txtPName
        '
        Me.txtPName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPName.BorderRadius = 10
        Me.txtPName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPName.DefaultText = ""
        Me.txtPName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPName.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtPName.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtPName.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtPName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPName.Location = New System.Drawing.Point(981, 51)
        Me.txtPName.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPName.Name = "txtPName"
        Me.txtPName.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtPName.PlaceholderText = ""
        Me.txtPName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPName.SelectedText = ""
        Me.txtPName.Size = New System.Drawing.Size(226, 26)
        Me.txtPName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtPName.TabIndex = 807
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(1240, 186)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(99, 22)
        Me.Label14.TabIndex = 823
        Me.Label14.Text = "$/سعر المنتج "
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(1247, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(92, 22)
        Me.Label9.TabIndex = 821
        Me.Label9.Text = "$/كلفة المنتج"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(1264, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 22)
        Me.Label8.TabIndex = 818
        Me.Label8.Text = "اسم المنتج"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(1229, 160)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 22)
        Me.Label15.TabIndex = 824
        Me.Label15.Text = "كلفة المنتج /ل.ل"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(1281, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 22)
        Me.Label7.TabIndex = 819
        Me.Label7.Text = "الباركود"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(1222, 212)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 22)
        Me.Label16.TabIndex = 825
        Me.Label16.Text = "سعر المنتج  /ل.ل"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(1287, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 22)
        Me.Label6.TabIndex = 820
        Me.Label6.Text = "الصنف"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1281, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 22)
        Me.Label1.TabIndex = 830
        Me.Label1.Text = "الباركود"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1240, 270)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(99, 22)
        Me.Label2.TabIndex = 831
        Me.Label2.Text = "$/سعر المنتج "
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1222, 297)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 22)
        Me.Label3.TabIndex = 832
        Me.Label3.Text = "سعر المنتج  /ل.ل"
        '
        'txtQtyAvailable
        '
        Me.txtQtyAvailable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQtyAvailable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtQtyAvailable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtQtyAvailable.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtQtyAvailable.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtQtyAvailable.BorderRadius = 10
        Me.txtQtyAvailable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQtyAvailable.DefaultText = ""
        Me.txtQtyAvailable.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtQtyAvailable.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtQtyAvailable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQtyAvailable.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQtyAvailable.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtQtyAvailable.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtQtyAvailable.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtQtyAvailable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtQtyAvailable.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQtyAvailable.Location = New System.Drawing.Point(983, 364)
        Me.txtQtyAvailable.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtQtyAvailable.Name = "txtQtyAvailable"
        Me.txtQtyAvailable.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtQtyAvailable.PlaceholderText = ""
        Me.txtQtyAvailable.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtQtyAvailable.SelectedText = ""
        Me.txtQtyAvailable.Size = New System.Drawing.Size(226, 26)
        Me.txtQtyAvailable.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtQtyAvailable.TabIndex = 833
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(1255, 368)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 22)
        Me.Label4.TabIndex = 834
        Me.Label4.Text = "حدود الكمية"
        '
        'dgvComponents
        '
        Me.dgvComponents.AllowUserToAddRows = False
        Me.dgvComponents.AllowUserToResizeColumns = False
        Me.dgvComponents.AllowUserToResizeRows = False
        Me.dgvComponents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvComponents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvComponents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvComponents.BackgroundColor = System.Drawing.Color.White
        Me.dgvComponents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvComponents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComponents.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvComponents.ColumnHeadersHeight = 65
        Me.dgvComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvComponents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ComponentId, Me.ComponentName, Me.CostD, Me.CostL, Me.PriceD, Me.PriceL, Me.QtyUsed, Me.TotalCostD, Me.TotalCostL, Me.TotalPriceD, Me.TotalPriceL, Me.TotalPriceDj, Me.TotalPriceLj})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvComponents.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvComponents.EnableHeadersVisualStyles = False
        Me.dgvComponents.FilterAndSortEnabled = True
        Me.dgvComponents.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.dgvComponents.Location = New System.Drawing.Point(12, 12)
        Me.dgvComponents.MaxFilterButtonImageHeight = 23
        Me.dgvComponents.Name = "dgvComponents"
        Me.dgvComponents.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvComponents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComponents.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvComponents.RowHeadersVisible = False
        Me.dgvComponents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComponents.Size = New System.Drawing.Size(941, 705)
        Me.dgvComponents.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.dgvComponents.TabIndex = 835
        '
        'ComponentId
        '
        Me.ComponentId.HeaderText = "ComponentId"
        Me.ComponentId.MinimumWidth = 24
        Me.ComponentId.Name = "ComponentId"
        Me.ComponentId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ComponentId.Visible = False
        '
        'ComponentName
        '
        Me.ComponentName.HeaderText = "اسم المنتج"
        Me.ComponentName.MinimumWidth = 24
        Me.ComponentName.Name = "ComponentName"
        Me.ComponentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'CostD
        '
        Me.CostD.HeaderText = "$/تكلفة المنتج"
        Me.CostD.MinimumWidth = 24
        Me.CostD.Name = "CostD"
        Me.CostD.ReadOnly = True
        Me.CostD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'CostL
        '
        Me.CostL.HeaderText = "تكلفة المنتج/ل.ل"
        Me.CostL.MinimumWidth = 24
        Me.CostL.Name = "CostL"
        Me.CostL.ReadOnly = True
        Me.CostL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PriceD
        '
        Me.PriceD.HeaderText = "$/سعر المنتج مفرق"
        Me.PriceD.MinimumWidth = 24
        Me.PriceD.Name = "PriceD"
        Me.PriceD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PriceL
        '
        Me.PriceL.HeaderText = "سعر المنتج مفرق/ل.ل"
        Me.PriceL.MinimumWidth = 24
        Me.PriceL.Name = "PriceL"
        Me.PriceL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'QtyUsed
        '
        Me.QtyUsed.HeaderText = "الكمية"
        Me.QtyUsed.MinimumWidth = 24
        Me.QtyUsed.Name = "QtyUsed"
        Me.QtyUsed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotalCostD
        '
        Me.TotalCostD.HeaderText = "TotalCostD"
        Me.TotalCostD.MinimumWidth = 24
        Me.TotalCostD.Name = "TotalCostD"
        Me.TotalCostD.ReadOnly = True
        Me.TotalCostD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotalCostL
        '
        Me.TotalCostL.HeaderText = "TotalCostL"
        Me.TotalCostL.MinimumWidth = 24
        Me.TotalCostL.Name = "TotalCostL"
        Me.TotalCostL.ReadOnly = True
        Me.TotalCostL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotalPriceD
        '
        Me.TotalPriceD.HeaderText = "TotalPriceD"
        Me.TotalPriceD.MinimumWidth = 24
        Me.TotalPriceD.Name = "TotalPriceD"
        Me.TotalPriceD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotalPriceL
        '
        Me.TotalPriceL.HeaderText = "TotalPriceL"
        Me.TotalPriceL.MinimumWidth = 24
        Me.TotalPriceL.Name = "TotalPriceL"
        Me.TotalPriceL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotalPriceDj
        '
        Me.TotalPriceDj.HeaderText = "TotalPriceDj"
        Me.TotalPriceDj.MinimumWidth = 24
        Me.TotalPriceDj.Name = "TotalPriceDj"
        Me.TotalPriceDj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotalPriceLj
        '
        Me.TotalPriceLj.HeaderText = "TotalPriceLj"
        Me.TotalPriceLj.MinimumWidth = 24
        Me.TotalPriceLj.Name = "TotalPriceLj"
        Me.TotalPriceLj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'btnRemoveComponent
        '
        Me.btnRemoveComponent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveComponent.AutoRoundedCorners = True
        Me.btnRemoveComponent.BackColor = System.Drawing.Color.Transparent
        Me.btnRemoveComponent.BorderColor = System.Drawing.Color.White
        Me.btnRemoveComponent.BorderRadius = 14
        Me.btnRemoveComponent.FillColor = System.Drawing.Color.Goldenrod
        Me.btnRemoveComponent.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnRemoveComponent.ForeColor = System.Drawing.Color.White
        Me.btnRemoveComponent.Location = New System.Drawing.Point(1229, 452)
        Me.btnRemoveComponent.Name = "btnRemoveComponent"
        Me.btnRemoveComponent.Size = New System.Drawing.Size(109, 30)
        Me.btnRemoveComponent.TabIndex = 837
        Me.btnRemoveComponent.Text = "تعديل"
        Me.btnRemoveComponent.Visible = False
        '
        'btnAddComponent
        '
        Me.btnAddComponent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddComponent.AutoRoundedCorners = True
        Me.btnAddComponent.BackColor = System.Drawing.Color.Transparent
        Me.btnAddComponent.BorderColor = System.Drawing.Color.White
        Me.btnAddComponent.BorderRadius = 14
        Me.btnAddComponent.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnAddComponent.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddComponent.ForeColor = System.Drawing.Color.White
        Me.btnAddComponent.Location = New System.Drawing.Point(1244, 407)
        Me.btnAddComponent.Name = "btnAddComponent"
        Me.btnAddComponent.Size = New System.Drawing.Size(95, 30)
        Me.btnAddComponent.TabIndex = 836
        Me.btnAddComponent.Text = "اضافة "
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.AutoRoundedCorners = True
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.BorderColor = System.Drawing.Color.White
        Me.btnSave.BorderRadius = 14
        Me.btnSave.FillColor = System.Drawing.Color.Green
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(1143, 407)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 30)
        Me.btnSave.TabIndex = 838
        Me.btnSave.Text = "حفظ"
        '
        'FrmStockComposite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnRemoveComponent)
        Me.Controls.Add(Me.btnAddComponent)
        Me.Controls.Add(Me.dgvComponents)
        Me.Controls.Add(Me.txtQtyAvailable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtQtyJ)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtCodeJ)
        Me.Controls.Add(Me.txtCostD)
        Me.Controls.Add(Me.cmbCat)
        Me.Controls.Add(Me.txtDP)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPriceJL)
        Me.Controls.Add(Me.txtPriceJD)
        Me.Controls.Add(Me.txtPricel)
        Me.Controls.Add(Me.txtPriceD)
        Me.Controls.Add(Me.txtCostl)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.txtPName)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label6)
        Me.Name = "FrmStockComposite"
        Me.Text = "المنتجات المركبة"
        CType(Me.dgvComponents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtQtyJ As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCodeJ As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtCostD As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cmbCat As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtDP As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPriceJL As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtPriceJD As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtPricel As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtPriceD As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtCostl As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtPName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtQtyAvailable As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvComponents As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents btnRemoveComponent As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddComponent As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ComponentId As DataGridViewTextBoxColumn
    Friend WithEvents ComponentName As DataGridViewTextBoxColumn
    Friend WithEvents CostD As DataGridViewTextBoxColumn
    Friend WithEvents CostL As DataGridViewTextBoxColumn
    Friend WithEvents PriceD As DataGridViewTextBoxColumn
    Friend WithEvents PriceL As DataGridViewTextBoxColumn
    Friend WithEvents QtyUsed As DataGridViewTextBoxColumn
    Friend WithEvents TotalCostD As DataGridViewTextBoxColumn
    Friend WithEvents TotalCostL As DataGridViewTextBoxColumn
    Friend WithEvents TotalPriceD As DataGridViewTextBoxColumn
    Friend WithEvents TotalPriceL As DataGridViewTextBoxColumn
    Friend WithEvents TotalPriceDj As DataGridViewTextBoxColumn
    Friend WithEvents TotalPriceLj As DataGridViewTextBoxColumn
End Class
