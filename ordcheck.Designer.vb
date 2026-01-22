<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ordcheck
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.orderDGV = New Zuby.ADGV.AdvancedDataGridView()
        Me.TypejDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProfitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdnumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BcDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderstblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MARKETDataSet = New Market.MARKETDataSet()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.label33 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.orgord = New Guna.UI2.WinForms.Guna2TextBox()
        Me.OrderstblTableAdapter = New Market.MARKETDataSetTableAdapters.orderstblTableAdapter()
        Me.Guna2Panel5 = New Guna.UI2.WinForms.Guna2Panel()
        Me.totl = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Guna2Panel6 = New Guna.UI2.WinForms.Guna2Panel()
        Me.totd = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.dr = New Guna.UI2.WinForms.Guna2TextBox()
        CType(Me.orderDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderstblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel5.SuspendLayout()
        Me.Guna2Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'orderDGV
        '
        Me.orderDGV.AllowUserToAddRows = False
        Me.orderDGV.AllowUserToDeleteRows = False
        Me.orderDGV.AllowUserToResizeColumns = False
        Me.orderDGV.AllowUserToResizeRows = False
        Me.orderDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.orderDGV.AutoGenerateColumns = False
        Me.orderDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.orderDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.orderDGV.BackgroundColor = System.Drawing.Color.White
        Me.orderDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.orderDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.orderDGV.ColumnHeadersHeight = 60
        Me.orderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.orderDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TypejDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.EmpDataGridViewTextBoxColumn, Me.ProfitDataGridViewTextBoxColumn, Me.CostdDataGridViewTextBoxColumn, Me.OrdnumDataGridViewTextBoxColumn, Me.TotlDataGridViewTextBoxColumn, Me.TotdDataGridViewTextBoxColumn, Me.QtyDataGridViewTextBoxColumn, Me.PlDataGridViewTextBoxColumn, Me.PdDataGridViewTextBoxColumn, Me.DrDataGridViewTextBoxColumn, Me.CategDataGridViewTextBoxColumn, Me.PnDataGridViewTextBoxColumn, Me.BcDataGridViewTextBoxColumn, Me.StockIDDataGridViewTextBoxColumn, Me.IdDataGridViewTextBoxColumn})
        Me.orderDGV.DataSource = Me.OrderstblBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.orderDGV.DefaultCellStyle = DataGridViewCellStyle2
        Me.orderDGV.EnableHeadersVisualStyles = False
        Me.orderDGV.FilterAndSortEnabled = True
        Me.orderDGV.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.orderDGV.Location = New System.Drawing.Point(12, 105)
        Me.orderDGV.MaxFilterButtonImageHeight = 23
        Me.orderDGV.Name = "orderDGV"
        Me.orderDGV.ReadOnly = True
        Me.orderDGV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.orderDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.orderDGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.orderDGV.RowHeadersVisible = False
        Me.orderDGV.RowHeadersWidth = 51
        Me.orderDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.orderDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.orderDGV.Size = New System.Drawing.Size(1081, 511)
        Me.orderDGV.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.orderDGV.TabIndex = 734
        '
        'TypejDataGridViewTextBoxColumn
        '
        Me.TypejDataGridViewTextBoxColumn.DataPropertyName = "typej"
        Me.TypejDataGridViewTextBoxColumn.HeaderText = "typej"
        Me.TypejDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.TypejDataGridViewTextBoxColumn.Name = "TypejDataGridViewTextBoxColumn"
        Me.TypejDataGridViewTextBoxColumn.ReadOnly = True
        Me.TypejDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.TypejDataGridViewTextBoxColumn.Visible = False
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "date"
        Me.DateDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DateDataGridViewTextBoxColumn.Visible = False
        '
        'EmpDataGridViewTextBoxColumn
        '
        Me.EmpDataGridViewTextBoxColumn.DataPropertyName = "emp"
        Me.EmpDataGridViewTextBoxColumn.HeaderText = "emp"
        Me.EmpDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.EmpDataGridViewTextBoxColumn.Name = "EmpDataGridViewTextBoxColumn"
        Me.EmpDataGridViewTextBoxColumn.ReadOnly = True
        Me.EmpDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.EmpDataGridViewTextBoxColumn.Visible = False
        '
        'ProfitDataGridViewTextBoxColumn
        '
        Me.ProfitDataGridViewTextBoxColumn.DataPropertyName = "profit"
        Me.ProfitDataGridViewTextBoxColumn.HeaderText = "profit"
        Me.ProfitDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.ProfitDataGridViewTextBoxColumn.Name = "ProfitDataGridViewTextBoxColumn"
        Me.ProfitDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProfitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ProfitDataGridViewTextBoxColumn.Visible = False
        '
        'CostdDataGridViewTextBoxColumn
        '
        Me.CostdDataGridViewTextBoxColumn.DataPropertyName = "costd"
        Me.CostdDataGridViewTextBoxColumn.HeaderText = "costd"
        Me.CostdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.CostdDataGridViewTextBoxColumn.Name = "CostdDataGridViewTextBoxColumn"
        Me.CostdDataGridViewTextBoxColumn.ReadOnly = True
        Me.CostdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.CostdDataGridViewTextBoxColumn.Visible = False
        '
        'OrdnumDataGridViewTextBoxColumn
        '
        Me.OrdnumDataGridViewTextBoxColumn.DataPropertyName = "ordnum"
        Me.OrdnumDataGridViewTextBoxColumn.HeaderText = "ordnum"
        Me.OrdnumDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.OrdnumDataGridViewTextBoxColumn.Name = "OrdnumDataGridViewTextBoxColumn"
        Me.OrdnumDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrdnumDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.OrdnumDataGridViewTextBoxColumn.Visible = False
        '
        'TotlDataGridViewTextBoxColumn
        '
        Me.TotlDataGridViewTextBoxColumn.DataPropertyName = "totl"
        Me.TotlDataGridViewTextBoxColumn.HeaderText = "مجموع/ل.ل"
        Me.TotlDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.TotlDataGridViewTextBoxColumn.Name = "TotlDataGridViewTextBoxColumn"
        Me.TotlDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotlDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotdDataGridViewTextBoxColumn
        '
        Me.TotdDataGridViewTextBoxColumn.DataPropertyName = "totd"
        Me.TotdDataGridViewTextBoxColumn.HeaderText = "$/مجموع"
        Me.TotdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.TotdDataGridViewTextBoxColumn.Name = "TotdDataGridViewTextBoxColumn"
        Me.TotdDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'QtyDataGridViewTextBoxColumn
        '
        Me.QtyDataGridViewTextBoxColumn.DataPropertyName = "qty"
        Me.QtyDataGridViewTextBoxColumn.HeaderText = "الكمية"
        Me.QtyDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.QtyDataGridViewTextBoxColumn.Name = "QtyDataGridViewTextBoxColumn"
        Me.QtyDataGridViewTextBoxColumn.ReadOnly = True
        Me.QtyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PlDataGridViewTextBoxColumn
        '
        Me.PlDataGridViewTextBoxColumn.DataPropertyName = "pl"
        Me.PlDataGridViewTextBoxColumn.HeaderText = "السعر/ل.ل"
        Me.PlDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PlDataGridViewTextBoxColumn.Name = "PlDataGridViewTextBoxColumn"
        Me.PlDataGridViewTextBoxColumn.ReadOnly = True
        Me.PlDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PdDataGridViewTextBoxColumn
        '
        Me.PdDataGridViewTextBoxColumn.DataPropertyName = "pd"
        Me.PdDataGridViewTextBoxColumn.HeaderText = "$/السعر"
        Me.PdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PdDataGridViewTextBoxColumn.Name = "PdDataGridViewTextBoxColumn"
        Me.PdDataGridViewTextBoxColumn.ReadOnly = True
        Me.PdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DrDataGridViewTextBoxColumn
        '
        Me.DrDataGridViewTextBoxColumn.DataPropertyName = "dr"
        Me.DrDataGridViewTextBoxColumn.HeaderText = "سعر الدولار"
        Me.DrDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.DrDataGridViewTextBoxColumn.Name = "DrDataGridViewTextBoxColumn"
        Me.DrDataGridViewTextBoxColumn.ReadOnly = True
        Me.DrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'CategDataGridViewTextBoxColumn
        '
        Me.CategDataGridViewTextBoxColumn.DataPropertyName = "categ"
        Me.CategDataGridViewTextBoxColumn.HeaderText = "الصنف"
        Me.CategDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.CategDataGridViewTextBoxColumn.Name = "CategDataGridViewTextBoxColumn"
        Me.CategDataGridViewTextBoxColumn.ReadOnly = True
        Me.CategDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PnDataGridViewTextBoxColumn
        '
        Me.PnDataGridViewTextBoxColumn.DataPropertyName = "pn"
        Me.PnDataGridViewTextBoxColumn.HeaderText = "اسم المنتج"
        Me.PnDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PnDataGridViewTextBoxColumn.Name = "PnDataGridViewTextBoxColumn"
        Me.PnDataGridViewTextBoxColumn.ReadOnly = True
        Me.PnDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'BcDataGridViewTextBoxColumn
        '
        Me.BcDataGridViewTextBoxColumn.DataPropertyName = "bc"
        Me.BcDataGridViewTextBoxColumn.HeaderText = "الباركود"
        Me.BcDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.BcDataGridViewTextBoxColumn.Name = "BcDataGridViewTextBoxColumn"
        Me.BcDataGridViewTextBoxColumn.ReadOnly = True
        Me.BcDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'StockIDDataGridViewTextBoxColumn
        '
        Me.StockIDDataGridViewTextBoxColumn.DataPropertyName = "stockID"
        Me.StockIDDataGridViewTextBoxColumn.HeaderText = "stockID"
        Me.StockIDDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.StockIDDataGridViewTextBoxColumn.Name = "StockIDDataGridViewTextBoxColumn"
        Me.StockIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.StockIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.StockIDDataGridViewTextBoxColumn.Visible = False
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'OrderstblBindingSource
        '
        Me.OrderstblBindingSource.DataMember = "orderstbl"
        Me.OrderstblBindingSource.DataSource = Me.MARKETDataSet
        '
        'MARKETDataSet
        '
        Me.MARKETDataSet.DataSetName = "MARKETDataSet"
        Me.MARKETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(804, 8)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(26, 23)
        Me.Label36.TabIndex = 869
        Me.Label36.Text = "O"
        '
        'Label35
        '
        Me.Label35.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(777, 8)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(23, 24)
        Me.Label35.TabIndex = 868
        Me.Label35.Text = ">"
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(752, 8)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(23, 24)
        Me.Label34.TabIndex = 867
        Me.Label34.Text = "<"
        '
        'label33
        '
        Me.label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label33.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.label33.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.label33.BackColor = System.Drawing.Color.WhiteSmoke
        Me.label33.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.label33.BorderRadius = 10
        Me.label33.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.label33.DefaultText = ""
        Me.label33.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.label33.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.label33.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.label33.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.label33.FillColor = System.Drawing.Color.WhiteSmoke
        Me.label33.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.label33.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label33.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.label33.Location = New System.Drawing.Point(852, 6)
        Me.label33.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.label33.Name = "label33"
        Me.label33.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.label33.PlaceholderForeColor = System.Drawing.Color.White
        Me.label33.PlaceholderText = ""
        Me.label33.ReadOnly = True
        Me.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label33.SelectedText = ""
        Me.label33.Size = New System.Drawing.Size(122, 23)
        Me.label33.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.label33.TabIndex = 871
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(981, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 22)
        Me.Label25.TabIndex = 870
        Me.Label25.Text = "رقم الطلب الحالي"
        '
        'orgord
        '
        Me.orgord.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.orgord.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.orgord.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.orgord.BackColor = System.Drawing.Color.WhiteSmoke
        Me.orgord.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.orgord.BorderRadius = 10
        Me.orgord.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.orgord.DefaultText = ""
        Me.orgord.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.orgord.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.orgord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.orgord.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.orgord.FillColor = System.Drawing.Color.WhiteSmoke
        Me.orgord.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.orgord.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.orgord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.orgord.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.orgord.Location = New System.Drawing.Point(554, 6)
        Me.orgord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.orgord.Name = "orgord"
        Me.orgord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.orgord.PlaceholderForeColor = System.Drawing.Color.White
        Me.orgord.PlaceholderText = ""
        Me.orgord.ReadOnly = True
        Me.orgord.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.orgord.SelectedText = ""
        Me.orgord.Size = New System.Drawing.Size(122, 23)
        Me.orgord.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.orgord.TabIndex = 872
        Me.orgord.Visible = False
        '
        'OrderstblTableAdapter
        '
        Me.OrderstblTableAdapter.ClearBeforeFill = True
        '
        'Guna2Panel5
        '
        Me.Guna2Panel5.BackColor = System.Drawing.Color.Chartreuse
        Me.Guna2Panel5.BorderColor = System.Drawing.Color.Aqua
        Me.Guna2Panel5.BorderRadius = 1
        Me.Guna2Panel5.BorderThickness = 2
        Me.Guna2Panel5.Controls.Add(Me.totl)
        Me.Guna2Panel5.Controls.Add(Me.Label29)
        Me.Guna2Panel5.Controls.Add(Me.Label30)
        Me.Guna2Panel5.CustomBorderColor = System.Drawing.Color.Red
        Me.Guna2Panel5.Location = New System.Drawing.Point(12, 55)
        Me.Guna2Panel5.Name = "Guna2Panel5"
        Me.Guna2Panel5.Size = New System.Drawing.Size(301, 37)
        Me.Guna2Panel5.TabIndex = 874
        '
        'totl
        '
        Me.totl.AutoSize = True
        Me.totl.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totl.ForeColor = System.Drawing.Color.Black
        Me.totl.Location = New System.Drawing.Point(31, 8)
        Me.totl.Name = "totl"
        Me.totl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.totl.Size = New System.Drawing.Size(20, 22)
        Me.totl.TabIndex = 628
        Me.totl.Text = "0"
        Me.totl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(3, 9)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(31, 19)
        Me.Label29.TabIndex = 487
        Me.Label29.Text = ".ل.ل"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Times New Roman", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(222, 5)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(76, 24)
        Me.Label30.TabIndex = 483
        Me.Label30.Text = ":المجموع"
        '
        'Guna2Panel6
        '
        Me.Guna2Panel6.BackColor = System.Drawing.Color.Chartreuse
        Me.Guna2Panel6.BorderColor = System.Drawing.Color.Aqua
        Me.Guna2Panel6.BorderRadius = 1
        Me.Guna2Panel6.BorderThickness = 2
        Me.Guna2Panel6.Controls.Add(Me.totd)
        Me.Guna2Panel6.Controls.Add(Me.Label31)
        Me.Guna2Panel6.Controls.Add(Me.Label32)
        Me.Guna2Panel6.CustomBorderColor = System.Drawing.Color.Red
        Me.Guna2Panel6.Location = New System.Drawing.Point(12, 12)
        Me.Guna2Panel6.Name = "Guna2Panel6"
        Me.Guna2Panel6.Size = New System.Drawing.Size(301, 37)
        Me.Guna2Panel6.TabIndex = 873
        '
        'totd
        '
        Me.totd.AutoSize = True
        Me.totd.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totd.ForeColor = System.Drawing.Color.Black
        Me.totd.Location = New System.Drawing.Point(31, 9)
        Me.totd.Name = "totd"
        Me.totd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.totd.Size = New System.Drawing.Size(20, 22)
        Me.totd.TabIndex = 628
        Me.totd.Text = "0"
        Me.totd.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(3, 6)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(21, 24)
        Me.Label31.TabIndex = 487
        Me.Label31.Text = "$"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Times New Roman", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(222, 6)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(76, 24)
        Me.Label32.TabIndex = 483
        Me.Label32.Text = ":المجموع"
        '
        'dr
        '
        Me.dr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.dr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.dr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dr.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dr.BorderRadius = 10
        Me.dr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dr.DefaultText = ""
        Me.dr.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.dr.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.dr.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dr.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dr.FillColor = System.Drawing.Color.WhiteSmoke
        Me.dr.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.dr.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dr.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dr.Location = New System.Drawing.Point(979, 45)
        Me.dr.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dr.Name = "dr"
        Me.dr.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dr.PlaceholderForeColor = System.Drawing.Color.White
        Me.dr.PlaceholderText = ""
        Me.dr.SelectedText = ""
        Me.dr.Size = New System.Drawing.Size(114, 23)
        Me.dr.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.dr.TabIndex = 875
        Me.dr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dr.Visible = False
        '
        'ordcheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1118, 640)
        Me.Controls.Add(Me.dr)
        Me.Controls.Add(Me.Guna2Panel5)
        Me.Controls.Add(Me.Guna2Panel6)
        Me.Controls.Add(Me.orgord)
        Me.Controls.Add(Me.label33)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.orderDGV)
        Me.Name = "ordcheck"
        Me.Text = "طلبات سابقة"
        CType(Me.orderDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderstblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel5.ResumeLayout(False)
        Me.Guna2Panel5.PerformLayout()
        Me.Guna2Panel6.ResumeLayout(False)
        Me.Guna2Panel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents orderDGV As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents label33 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents orgord As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents MARKETDataSet As MARKETDataSet
    Friend WithEvents OrderstblBindingSource As BindingSource
    Friend WithEvents OrderstblTableAdapter As MARKETDataSetTableAdapters.orderstblTableAdapter
    Friend WithEvents Guna2Panel5 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents totl As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Guna2Panel6 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents totd As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents TypejDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmpDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProfitDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CostdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OrdnumDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotlDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PlDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DrDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PnDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BcDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StockIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents dr As Guna.UI2.WinForms.Guna2TextBox
End Class
