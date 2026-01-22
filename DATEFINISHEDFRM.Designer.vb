<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DATEFINISHEDFRM
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
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Shapes2 = New Guna.UI2.WinForms.Guna2Shapes()
        Me.maindate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.DGV = New Zuby.ADGV.AdvancedDataGridView()
        Me.CheDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.QtymDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BcodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvnumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoicedateTblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MARKETDataSet1 = New Market.MARKETDataSet()
        Me.Guna2Button13 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Guna2Button2 = New Guna.UI2.WinForms.Guna2Button()
        Me.InvoicedateTblTableAdapter = New Market.MARKETDataSetTableAdapters.invoicedateTblTableAdapter()
        Me.TableAdapterManager1 = New Market.MARKETDataSetTableAdapters.TableAdapterManager()
        Me.Guna2Button3 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoicedateTblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MARKETDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
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
        Me.Guna2Panel1.Size = New System.Drawing.Size(1366, 27)
        Me.Guna2Panel1.TabIndex = 2
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
        Me.Label5.Size = New System.Drawing.Size(150, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "ELPOS-انتهاء الصلاحية"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1340, 2)
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
        Me.Guna2Shapes2.Location = New System.Drawing.Point(1318, 9)
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
        'maindate
        '
        Me.maindate.Checked = True
        Me.maindate.FillColor = System.Drawing.Color.Blue
        Me.maindate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.maindate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.maindate.Location = New System.Drawing.Point(1290, 29)
        Me.maindate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.maindate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.maindate.Name = "maindate"
        Me.maindate.Size = New System.Drawing.Size(75, 22)
        Me.maindate.TabIndex = 826
        Me.maindate.Value = New Date(2024, 2, 17, 19, 29, 32, 337)
        Me.maindate.Visible = False
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToResizeColumns = False
        Me.DGV.AllowUserToResizeRows = False
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV.AutoGenerateColumns = False
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGV.BackgroundColor = System.Drawing.Color.White
        Me.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV.ColumnHeadersHeight = 45
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CheDataGridViewCheckBoxColumn, Me.QtymDataGridViewTextBoxColumn, Me.Date2DataGridViewTextBoxColumn, Me.Date1DataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn1, Me.PlDataGridViewTextBoxColumn, Me.PdDataGridViewTextBoxColumn, Me.ClDataGridViewTextBoxColumn, Me.CdDataGridViewTextBoxColumn, Me.QtyDataGridViewTextBoxColumn, Me.DrDataGridViewTextBoxColumn, Me.CategDataGridViewTextBoxColumn, Me.PnameDataGridViewTextBoxColumn, Me.BcodeDataGridViewTextBoxColumn, Me.InvnumDataGridViewTextBoxColumn, Me.StockIDDataGridViewTextBoxColumn, Me.IdDataGridViewTextBoxColumn})
        Me.DGV.DataSource = Me.InvoicedateTblBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.FilterAndSortEnabled = True
        Me.DGV.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.DGV.Location = New System.Drawing.Point(12, 75)
        Me.DGV.MaxFilterButtonImageHeight = 23
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGV.RowHeadersVisible = False
        Me.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV.Size = New System.Drawing.Size(1342, 681)
        Me.DGV.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.DGV.TabIndex = 827
        '
        'CheDataGridViewCheckBoxColumn
        '
        Me.CheDataGridViewCheckBoxColumn.DataPropertyName = "che"
        Me.CheDataGridViewCheckBoxColumn.HeaderText = "تم"
        Me.CheDataGridViewCheckBoxColumn.MinimumWidth = 24
        Me.CheDataGridViewCheckBoxColumn.Name = "CheDataGridViewCheckBoxColumn"
        Me.CheDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'QtymDataGridViewTextBoxColumn
        '
        Me.QtymDataGridViewTextBoxColumn.DataPropertyName = "qtym"
        Me.QtymDataGridViewTextBoxColumn.HeaderText = "حدود الكمية"
        Me.QtymDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.QtymDataGridViewTextBoxColumn.Name = "QtymDataGridViewTextBoxColumn"
        Me.QtymDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Date2DataGridViewTextBoxColumn
        '
        Me.Date2DataGridViewTextBoxColumn.DataPropertyName = "date2"
        Me.Date2DataGridViewTextBoxColumn.HeaderText = "مهلة قبل انتهاء الصلاحية"
        Me.Date2DataGridViewTextBoxColumn.MinimumWidth = 24
        Me.Date2DataGridViewTextBoxColumn.Name = "Date2DataGridViewTextBoxColumn"
        Me.Date2DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Date1DataGridViewTextBoxColumn
        '
        Me.Date1DataGridViewTextBoxColumn.DataPropertyName = "date1"
        Me.Date1DataGridViewTextBoxColumn.HeaderText = "التاريخ"
        Me.Date1DataGridViewTextBoxColumn.MinimumWidth = 24
        Me.Date1DataGridViewTextBoxColumn.Name = "Date1DataGridViewTextBoxColumn"
        Me.Date1DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "date"
        Me.DataGridViewTextBoxColumn1.HeaderText = "تاريخ انتهاء الصلاحية"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 24
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PlDataGridViewTextBoxColumn
        '
        Me.PlDataGridViewTextBoxColumn.DataPropertyName = "pl"
        Me.PlDataGridViewTextBoxColumn.HeaderText = "السعر/ل.ل"
        Me.PlDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PlDataGridViewTextBoxColumn.Name = "PlDataGridViewTextBoxColumn"
        Me.PlDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PdDataGridViewTextBoxColumn
        '
        Me.PdDataGridViewTextBoxColumn.DataPropertyName = "pd"
        Me.PdDataGridViewTextBoxColumn.HeaderText = "$/السعر"
        Me.PdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PdDataGridViewTextBoxColumn.Name = "PdDataGridViewTextBoxColumn"
        Me.PdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'ClDataGridViewTextBoxColumn
        '
        Me.ClDataGridViewTextBoxColumn.DataPropertyName = "cl"
        Me.ClDataGridViewTextBoxColumn.HeaderText = "الكلفة/ل.ل"
        Me.ClDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.ClDataGridViewTextBoxColumn.Name = "ClDataGridViewTextBoxColumn"
        Me.ClDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'CdDataGridViewTextBoxColumn
        '
        Me.CdDataGridViewTextBoxColumn.DataPropertyName = "cd"
        Me.CdDataGridViewTextBoxColumn.HeaderText = "$/الكلفة"
        Me.CdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.CdDataGridViewTextBoxColumn.Name = "CdDataGridViewTextBoxColumn"
        Me.CdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'QtyDataGridViewTextBoxColumn
        '
        Me.QtyDataGridViewTextBoxColumn.DataPropertyName = "qty"
        Me.QtyDataGridViewTextBoxColumn.HeaderText = "الكمية"
        Me.QtyDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.QtyDataGridViewTextBoxColumn.Name = "QtyDataGridViewTextBoxColumn"
        Me.QtyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
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
        'PnameDataGridViewTextBoxColumn
        '
        Me.PnameDataGridViewTextBoxColumn.DataPropertyName = "pname"
        Me.PnameDataGridViewTextBoxColumn.HeaderText = "اسم المنتج"
        Me.PnameDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PnameDataGridViewTextBoxColumn.Name = "PnameDataGridViewTextBoxColumn"
        Me.PnameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'BcodeDataGridViewTextBoxColumn
        '
        Me.BcodeDataGridViewTextBoxColumn.DataPropertyName = "bcode"
        Me.BcodeDataGridViewTextBoxColumn.HeaderText = "الباركود"
        Me.BcodeDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.BcodeDataGridViewTextBoxColumn.Name = "BcodeDataGridViewTextBoxColumn"
        Me.BcodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'InvnumDataGridViewTextBoxColumn
        '
        Me.InvnumDataGridViewTextBoxColumn.DataPropertyName = "invnum"
        Me.InvnumDataGridViewTextBoxColumn.HeaderText = "رقم الفاتورة"
        Me.InvnumDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.InvnumDataGridViewTextBoxColumn.Name = "InvnumDataGridViewTextBoxColumn"
        Me.InvnumDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'StockIDDataGridViewTextBoxColumn
        '
        Me.StockIDDataGridViewTextBoxColumn.DataPropertyName = "stockID"
        Me.StockIDDataGridViewTextBoxColumn.HeaderText = "رقم المنتج التسلسلي بالمخزون"
        Me.StockIDDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.StockIDDataGridViewTextBoxColumn.Name = "StockIDDataGridViewTextBoxColumn"
        Me.StockIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "الرقم التسلسلي"
        Me.IdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'InvoicedateTblBindingSource
        '
        Me.InvoicedateTblBindingSource.DataMember = "invoicedateTbl"
        Me.InvoicedateTblBindingSource.DataSource = Me.MARKETDataSet1
        '
        'MARKETDataSet1
        '
        Me.MARKETDataSet1.DataSetName = "MARKETDataSet"
        Me.MARKETDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Guna2Button13
        '
        Me.Guna2Button13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Button13.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button13.BorderColor = System.Drawing.Color.White
        Me.Guna2Button13.FillColor = System.Drawing.Color.Green
        Me.Guna2Button13.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button13.ForeColor = System.Drawing.Color.White
        Me.Guna2Button13.Location = New System.Drawing.Point(809, 3)
        Me.Guna2Button13.Name = "Guna2Button13"
        Me.Guna2Button13.Size = New System.Drawing.Size(379, 39)
        Me.Guna2Button13.TabIndex = 828
        Me.Guna2Button13.Text = "المنتجات المنتهية الصلاحية تم التأكيد عليها و الانتهاء منها"
        '
        'Guna2Button1
        '
        Me.Guna2Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Button1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button1.BorderColor = System.Drawing.Color.White
        Me.Guna2Button1.FillColor = System.Drawing.Color.Maroon
        Me.Guna2Button1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.Location = New System.Drawing.Point(514, 3)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(289, 39)
        Me.Guna2Button1.TabIndex = 829
        Me.Guna2Button1.Text = "المنتجات المنتهية الصلاحية جاهزة للتأكيد"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Guna2Button3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Guna2Button2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Guna2Button1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Guna2Button13)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 27)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1366, 48)
        Me.FlowLayoutPanel1.TabIndex = 830
        '
        'Guna2Button2
        '
        Me.Guna2Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Button2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button2.BorderColor = System.Drawing.Color.White
        Me.Guna2Button2.FillColor = System.Drawing.Color.DimGray
        Me.Guna2Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button2.ForeColor = System.Drawing.Color.White
        Me.Guna2Button2.Location = New System.Drawing.Point(259, 3)
        Me.Guna2Button2.Name = "Guna2Button2"
        Me.Guna2Button2.Size = New System.Drawing.Size(249, 39)
        Me.Guna2Button2.TabIndex = 830
        Me.Guna2Button2.Text = "المنتجات التي تنتهي صلاحيتها قريبا"
        '
        'InvoicedateTblTableAdapter
        '
        Me.InvoicedateTblTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.cashiertblTableAdapter = Nothing
        Me.TableAdapterManager1.categTblTableAdapter = Nothing
        Me.TableAdapterManager1.clienttblTableAdapter = Nothing
        Me.TableAdapterManager1.dailypTableAdapter = Nothing
        Me.TableAdapterManager1.debitTblTableAdapter = Nothing
        Me.TableAdapterManager1.dollarrateTblTableAdapter = Nothing
        Me.TableAdapterManager1.equipmentTbl1TableAdapter = Nothing
        Me.TableAdapterManager1.expTblTableAdapter = Nothing
        Me.TableAdapterManager1.invoicedateTblTableAdapter = Me.InvoicedateTblTableAdapter
        Me.TableAdapterManager1.invoicereturnTblTableAdapter = Nothing
        Me.TableAdapterManager1.invoiceTblTableAdapter = Nothing
        Me.TableAdapterManager1.ndTblTableAdapter = Nothing
        Me.TableAdapterManager1.ordernew1TableAdapter = Nothing
        Me.TableAdapterManager1.ordernewTableAdapter = Nothing
        Me.TableAdapterManager1.orderstblTableAdapter = Nothing
        Me.TableAdapterManager1.ordertbl1TableAdapter = Nothing
        Me.TableAdapterManager1.orderTransactionsTableAdapter = Nothing
        Me.TableAdapterManager1.stockdetailstblTableAdapter = Nothing
        Me.TableAdapterManager1.stockTableAdapter = Nothing
        Me.TableAdapterManager1.suppdebitTblTableAdapter = Nothing
        Me.TableAdapterManager1.suppliersreturnTblTableAdapter = Nothing
        Me.TableAdapterManager1.suppliersTblTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = Market.MARKETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager1.UserloginTblTableAdapter = Nothing
        Me.TableAdapterManager1.UserTblTableAdapter = Nothing
        '
        'Guna2Button3
        '
        Me.Guna2Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Button3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button3.BorderColor = System.Drawing.Color.White
        Me.Guna2Button3.FillColor = System.Drawing.Color.Navy
        Me.Guna2Button3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button3.ForeColor = System.Drawing.Color.White
        Me.Guna2Button3.Location = New System.Drawing.Point(3, 3)
        Me.Guna2Button3.Name = "Guna2Button3"
        Me.Guna2Button3.Size = New System.Drawing.Size(250, 39)
        Me.Guna2Button3.TabIndex = 831
        Me.Guna2Button3.Text = "جميع تواريخ الصلاحية"
        '
        'DATEFINISHEDFRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.maindate)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DATEFINISHEDFRM"
        Me.Text = "DATEFINISHEDFRM"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoicedateTblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MARKETDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Shapes2 As Guna.UI2.WinForms.Guna2Shapes
    Friend WithEvents maindate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents DGV As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MARKETDataSet1 As MARKETDataSet
    Friend WithEvents InvoicedateTblBindingSource As BindingSource
    Friend WithEvents InvoicedateTblTableAdapter As MARKETDataSetTableAdapters.invoicedateTblTableAdapter
    Friend WithEvents TableAdapterManager1 As MARKETDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CheDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents QtymDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Date2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Date1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PlDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DrDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PnameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BcodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InvnumDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StockIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Guna2Button13 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Guna2Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button3 As Guna.UI2.WinForms.Guna2Button
End Class
