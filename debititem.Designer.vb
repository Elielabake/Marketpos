<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class debititem
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.debitDGV = New Zuby.ADGV.AdvancedDataGridView()
        Me.snum = New Guna.UI2.WinForms.Guna2TextBox()
        Me.MARKETDataSet = New Market.MARKETDataSet()
        Me.OrderstblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrderstblTableAdapter = New Market.MARKETDataSetTableAdapters.orderstblTableAdapter()
        Me.TypejDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProfitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BcDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdnumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label26 = New System.Windows.Forms.Label()
        CType(Me.debitDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderstblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'debitDGV
        '
        Me.debitDGV.AllowUserToAddRows = False
        Me.debitDGV.AllowUserToDeleteRows = False
        Me.debitDGV.AllowUserToResizeColumns = False
        Me.debitDGV.AllowUserToResizeRows = False
        Me.debitDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.debitDGV.AutoGenerateColumns = False
        Me.debitDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.debitDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.debitDGV.BackgroundColor = System.Drawing.Color.White
        Me.debitDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.debitDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.debitDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.debitDGV.ColumnHeadersHeight = 45
        Me.debitDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.debitDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TypejDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.EmpDataGridViewTextBoxColumn, Me.ProfitDataGridViewTextBoxColumn, Me.CostdDataGridViewTextBoxColumn, Me.TotlDataGridViewTextBoxColumn, Me.TotdDataGridViewTextBoxColumn, Me.QtyDataGridViewTextBoxColumn, Me.PlDataGridViewTextBoxColumn, Me.PdDataGridViewTextBoxColumn, Me.DrDataGridViewTextBoxColumn, Me.CategDataGridViewTextBoxColumn, Me.PnDataGridViewTextBoxColumn, Me.BcDataGridViewTextBoxColumn, Me.OrdnumDataGridViewTextBoxColumn, Me.StockIDDataGridViewTextBoxColumn, Me.IdDataGridViewTextBoxColumn})
        Me.debitDGV.DataSource = Me.OrderstblBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.debitDGV.DefaultCellStyle = DataGridViewCellStyle5
        Me.debitDGV.EnableHeadersVisualStyles = False
        Me.debitDGV.FilterAndSortEnabled = True
        Me.debitDGV.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.debitDGV.Location = New System.Drawing.Point(12, 41)
        Me.debitDGV.MaxFilterButtonImageHeight = 23
        Me.debitDGV.Name = "debitDGV"
        Me.debitDGV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.debitDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.debitDGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.debitDGV.RowHeadersVisible = False
        Me.debitDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.debitDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.debitDGV.Size = New System.Drawing.Size(1087, 468)
        Me.debitDGV.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.debitDGV.TabIndex = 734
        '
        'snum
        '
        Me.snum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.snum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.snum.BackColor = System.Drawing.Color.Transparent
        Me.snum.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.snum.BorderRadius = 10
        Me.snum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.snum.DefaultText = ""
        Me.snum.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.snum.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.snum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.snum.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.snum.FillColor = System.Drawing.Color.WhiteSmoke
        Me.snum.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.snum.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.snum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.snum.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.snum.Location = New System.Drawing.Point(841, 8)
        Me.snum.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.snum.Name = "snum"
        Me.snum.PlaceholderForeColor = System.Drawing.Color.White
        Me.snum.PlaceholderText = ""
        Me.snum.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.snum.SelectedText = ""
        Me.snum.Size = New System.Drawing.Size(183, 26)
        Me.snum.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.snum.TabIndex = 736
        '
        'MARKETDataSet
        '
        Me.MARKETDataSet.DataSetName = "MARKETDataSet"
        Me.MARKETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OrderstblBindingSource
        '
        Me.OrderstblBindingSource.DataMember = "orderstbl"
        Me.OrderstblBindingSource.DataSource = Me.MARKETDataSet
        '
        'OrderstblTableAdapter
        '
        Me.OrderstblTableAdapter.ClearBeforeFill = True
        '
        'TypejDataGridViewTextBoxColumn
        '
        Me.TypejDataGridViewTextBoxColumn.DataPropertyName = "typej"
        Me.TypejDataGridViewTextBoxColumn.HeaderText = "typej"
        Me.TypejDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.TypejDataGridViewTextBoxColumn.Name = "TypejDataGridViewTextBoxColumn"
        Me.TypejDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.TypejDataGridViewTextBoxColumn.Visible = False
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "التاريخ"
        Me.DateDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'EmpDataGridViewTextBoxColumn
        '
        Me.EmpDataGridViewTextBoxColumn.DataPropertyName = "emp"
        Me.EmpDataGridViewTextBoxColumn.HeaderText = "emp"
        Me.EmpDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.EmpDataGridViewTextBoxColumn.Name = "EmpDataGridViewTextBoxColumn"
        Me.EmpDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.EmpDataGridViewTextBoxColumn.Visible = False
        '
        'ProfitDataGridViewTextBoxColumn
        '
        Me.ProfitDataGridViewTextBoxColumn.DataPropertyName = "profit"
        Me.ProfitDataGridViewTextBoxColumn.HeaderText = "profit"
        Me.ProfitDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.ProfitDataGridViewTextBoxColumn.Name = "ProfitDataGridViewTextBoxColumn"
        Me.ProfitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ProfitDataGridViewTextBoxColumn.Visible = False
        '
        'CostdDataGridViewTextBoxColumn
        '
        Me.CostdDataGridViewTextBoxColumn.DataPropertyName = "costd"
        Me.CostdDataGridViewTextBoxColumn.HeaderText = "costd"
        Me.CostdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.CostdDataGridViewTextBoxColumn.Name = "CostdDataGridViewTextBoxColumn"
        Me.CostdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.CostdDataGridViewTextBoxColumn.Visible = False
        '
        'TotlDataGridViewTextBoxColumn
        '
        Me.TotlDataGridViewTextBoxColumn.DataPropertyName = "totl"
        Me.TotlDataGridViewTextBoxColumn.HeaderText = "المجموع/ل.ل"
        Me.TotlDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.TotlDataGridViewTextBoxColumn.Name = "TotlDataGridViewTextBoxColumn"
        Me.TotlDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotdDataGridViewTextBoxColumn
        '
        Me.TotdDataGridViewTextBoxColumn.DataPropertyName = "totd"
        Me.TotdDataGridViewTextBoxColumn.HeaderText = "$/المجموع"
        Me.TotdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.TotdDataGridViewTextBoxColumn.Name = "TotdDataGridViewTextBoxColumn"
        Me.TotdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'QtyDataGridViewTextBoxColumn
        '
        Me.QtyDataGridViewTextBoxColumn.DataPropertyName = "qty"
        Me.QtyDataGridViewTextBoxColumn.HeaderText = "الكمية"
        Me.QtyDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.QtyDataGridViewTextBoxColumn.Name = "QtyDataGridViewTextBoxColumn"
        Me.QtyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PlDataGridViewTextBoxColumn
        '
        Me.PlDataGridViewTextBoxColumn.DataPropertyName = "pl"
        Me.PlDataGridViewTextBoxColumn.HeaderText = "سعر المنتج/ل.ل"
        Me.PlDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PlDataGridViewTextBoxColumn.Name = "PlDataGridViewTextBoxColumn"
        Me.PlDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PdDataGridViewTextBoxColumn
        '
        Me.PdDataGridViewTextBoxColumn.DataPropertyName = "pd"
        Me.PdDataGridViewTextBoxColumn.HeaderText = "$/سعر المنتج"
        Me.PdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PdDataGridViewTextBoxColumn.Name = "PdDataGridViewTextBoxColumn"
        Me.PdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DrDataGridViewTextBoxColumn
        '
        Me.DrDataGridViewTextBoxColumn.DataPropertyName = "dr"
        Me.DrDataGridViewTextBoxColumn.HeaderText = "سعر الدولار"
        Me.DrDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.DrDataGridViewTextBoxColumn.Name = "DrDataGridViewTextBoxColumn"
        Me.DrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'CategDataGridViewTextBoxColumn
        '
        Me.CategDataGridViewTextBoxColumn.DataPropertyName = "categ"
        Me.CategDataGridViewTextBoxColumn.HeaderText = "الصنف"
        Me.CategDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.CategDataGridViewTextBoxColumn.Name = "CategDataGridViewTextBoxColumn"
        Me.CategDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PnDataGridViewTextBoxColumn
        '
        Me.PnDataGridViewTextBoxColumn.DataPropertyName = "pn"
        Me.PnDataGridViewTextBoxColumn.HeaderText = "اسم المنتج"
        Me.PnDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PnDataGridViewTextBoxColumn.Name = "PnDataGridViewTextBoxColumn"
        Me.PnDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'BcDataGridViewTextBoxColumn
        '
        Me.BcDataGridViewTextBoxColumn.DataPropertyName = "bc"
        Me.BcDataGridViewTextBoxColumn.HeaderText = "الباركود"
        Me.BcDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.BcDataGridViewTextBoxColumn.Name = "BcDataGridViewTextBoxColumn"
        Me.BcDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'OrdnumDataGridViewTextBoxColumn
        '
        Me.OrdnumDataGridViewTextBoxColumn.DataPropertyName = "ordnum"
        Me.OrdnumDataGridViewTextBoxColumn.HeaderText = "رقم الطلب"
        Me.OrdnumDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.OrdnumDataGridViewTextBoxColumn.Name = "OrdnumDataGridViewTextBoxColumn"
        Me.OrdnumDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'StockIDDataGridViewTextBoxColumn
        '
        Me.StockIDDataGridViewTextBoxColumn.DataPropertyName = "stockID"
        Me.StockIDDataGridViewTextBoxColumn.HeaderText = "stockID"
        Me.StockIDDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.StockIDDataGridViewTextBoxColumn.Name = "StockIDDataGridViewTextBoxColumn"
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
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(1032, 13)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 22)
        Me.Label26.TabIndex = 822
        Me.Label26.Text = "رقم الطلب"
        '
        'debititem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1111, 521)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.snum)
        Me.Controls.Add(Me.debitDGV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "debititem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.debitDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderstblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents debitDGV As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents snum As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents MARKETDataSet As MARKETDataSet
    Friend WithEvents OrderstblBindingSource As BindingSource
    Friend WithEvents OrderstblTableAdapter As MARKETDataSetTableAdapters.orderstblTableAdapter
    Friend WithEvents TypejDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmpDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProfitDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CostdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotlDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PlDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DrDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PnDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BcDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OrdnumDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StockIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Label26 As Label
End Class
