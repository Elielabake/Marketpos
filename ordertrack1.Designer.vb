<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ordertrack1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ordertrack1))
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Shapes2 = New Guna.UI2.WinForms.Guna2Shapes()
        Me.dgv = New Zuby.ADGV.AdvancedDataGridView()
        Me.OrderTransactionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MARKETDataSet = New Market.MARKETDataSet()
        Me.OrderTransactionsTableAdapter = New Market.MARKETDataSetTableAdapters.orderTransactionsTableAdapter()
        Me.TableAdapterManager1 = New Market.MARKETDataSetTableAdapters.TableAdapterManager()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Button3 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button6 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button4 = New Guna.UI2.WinForms.Guna2Button()
        Me.ActionDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typej = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.ActionTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderTransactionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
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
        Me.Label5.Size = New System.Drawing.Size(164, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "ELPOS-تحويلات الطلبات"
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
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoGenerateColumns = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeight = 60
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ActionDateDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.typej, Me.EmpDataGridViewTextBoxColumn, Me.ProfitDataGridViewTextBoxColumn, Me.CostdDataGridViewTextBoxColumn, Me.OrdnumDataGridViewTextBoxColumn, Me.TotlDataGridViewTextBoxColumn, Me.TotdDataGridViewTextBoxColumn, Me.QtyDataGridViewTextBoxColumn, Me.PlDataGridViewTextBoxColumn, Me.PdDataGridViewTextBoxColumn, Me.DrDataGridViewTextBoxColumn, Me.CategDataGridViewTextBoxColumn, Me.PnDataGridViewTextBoxColumn, Me.BcDataGridViewTextBoxColumn, Me.StockIDDataGridViewTextBoxColumn, Me.IdDataGridViewTextBoxColumn, Me.ActionTypeDataGridViewTextBoxColumn, Me.TransIdDataGridViewTextBoxColumn})
        Me.dgv.DataSource = Me.OrderTransactionsBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.FilterAndSortEnabled = True
        Me.dgv.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.dgv.Location = New System.Drawing.Point(12, 67)
        Me.dgv.MaxFilterButtonImageHeight = 23
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(1342, 689)
        Me.dgv.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.dgv.TabIndex = 733
        '
        'OrderTransactionsBindingSource
        '
        Me.OrderTransactionsBindingSource.DataMember = "orderTransactions"
        Me.OrderTransactionsBindingSource.DataSource = Me.MARKETDataSet
        '
        'MARKETDataSet
        '
        Me.MARKETDataSet.DataSetName = "MARKETDataSet"
        Me.MARKETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OrderTransactionsTableAdapter
        '
        Me.OrderTransactionsTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager1.invoicedateTblTableAdapter = Nothing
        Me.TableAdapterManager1.invoicereturnTblTableAdapter = Nothing
        Me.TableAdapterManager1.invoiceTblTableAdapter = Nothing
        Me.TableAdapterManager1.ndTblTableAdapter = Nothing
        Me.TableAdapterManager1.ordernew1TableAdapter = Nothing
        Me.TableAdapterManager1.ordernewTableAdapter = Nothing
        Me.TableAdapterManager1.orderstblTableAdapter = Nothing
        Me.TableAdapterManager1.ordertbl1TableAdapter = Nothing
        Me.TableAdapterManager1.orderTransactionsTableAdapter = Me.OrderTransactionsTableAdapter
        Me.TableAdapterManager1.stockdetailstblTableAdapter = Nothing
        Me.TableAdapterManager1.stockTableAdapter = Nothing
        Me.TableAdapterManager1.suppdebitTblTableAdapter = Nothing
        Me.TableAdapterManager1.suppliersreturnTblTableAdapter = Nothing
        Me.TableAdapterManager1.suppliersTblTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = Market.MARKETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager1.UserloginTblTableAdapter = Nothing
        Me.TableAdapterManager1.UserTblTableAdapter = Nothing
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BindingNavigator1.BindingSource = Me.OrderTransactionsBindingSource
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 27)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(1366, 25)
        Me.BindingNavigator1.TabIndex = 734
        Me.BindingNavigator1.Text = "BindingNavigator1"
        Me.BindingNavigator1.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.AutoRoundedCorners = True
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BorderColor = System.Drawing.Color.White
        Me.Button3.BorderRadius = 12
        Me.Button3.FillColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(1245, 35)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(109, 26)
        Me.Button3.TabIndex = 735
        Me.Button3.Text = " مسح السجل "
        '
        'Guna2Button6
        '
        Me.Guna2Button6.AutoRoundedCorners = True
        Me.Guna2Button6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button6.BorderColor = System.Drawing.Color.White
        Me.Guna2Button6.BorderRadius = 13
        Me.Guna2Button6.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Guna2Button6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button6.ForeColor = System.Drawing.Color.White
        Me.Guna2Button6.Location = New System.Drawing.Point(173, 33)
        Me.Guna2Button6.Name = "Guna2Button6"
        Me.Guna2Button6.Size = New System.Drawing.Size(113, 28)
        Me.Guna2Button6.TabIndex = 789
        Me.Guna2Button6.Text = "طلبات اليوم"
        '
        'Guna2Button4
        '
        Me.Guna2Button4.AutoRoundedCorners = True
        Me.Guna2Button4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button4.BorderColor = System.Drawing.Color.White
        Me.Guna2Button4.BorderRadius = 13
        Me.Guna2Button4.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Guna2Button4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button4.ForeColor = System.Drawing.Color.White
        Me.Guna2Button4.Location = New System.Drawing.Point(16, 33)
        Me.Guna2Button4.Name = "Guna2Button4"
        Me.Guna2Button4.Size = New System.Drawing.Size(151, 28)
        Me.Guna2Button4.TabIndex = 788
        Me.Guna2Button4.Text = "اظهار جميع الطلبات"
        '
        'ActionDateDataGridViewTextBoxColumn
        '
        Me.ActionDateDataGridViewTextBoxColumn.DataPropertyName = "actionDate"
        Me.ActionDateDataGridViewTextBoxColumn.HeaderText = "تاريخ العملية"
        Me.ActionDateDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.ActionDateDataGridViewTextBoxColumn.Name = "ActionDateDataGridViewTextBoxColumn"
        Me.ActionDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.ActionDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "التاريخ"
        Me.DateDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'typej
        '
        Me.typej.DataPropertyName = "typej"
        Me.typej.HeaderText = "جملة/مفرق"
        Me.typej.MinimumWidth = 24
        Me.typej.Name = "typej"
        Me.typej.ReadOnly = True
        Me.typej.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'EmpDataGridViewTextBoxColumn
        '
        Me.EmpDataGridViewTextBoxColumn.DataPropertyName = "emp"
        Me.EmpDataGridViewTextBoxColumn.HeaderText = "اسم الموظف"
        Me.EmpDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.EmpDataGridViewTextBoxColumn.Name = "EmpDataGridViewTextBoxColumn"
        Me.EmpDataGridViewTextBoxColumn.ReadOnly = True
        Me.EmpDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'ProfitDataGridViewTextBoxColumn
        '
        Me.ProfitDataGridViewTextBoxColumn.DataPropertyName = "profit"
        Me.ProfitDataGridViewTextBoxColumn.HeaderText = "الربح"
        Me.ProfitDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.ProfitDataGridViewTextBoxColumn.Name = "ProfitDataGridViewTextBoxColumn"
        Me.ProfitDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProfitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'CostdDataGridViewTextBoxColumn
        '
        Me.CostdDataGridViewTextBoxColumn.DataPropertyName = "costd"
        Me.CostdDataGridViewTextBoxColumn.HeaderText = "$/الكلفة"
        Me.CostdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.CostdDataGridViewTextBoxColumn.Name = "CostdDataGridViewTextBoxColumn"
        Me.CostdDataGridViewTextBoxColumn.ReadOnly = True
        Me.CostdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'OrdnumDataGridViewTextBoxColumn
        '
        Me.OrdnumDataGridViewTextBoxColumn.DataPropertyName = "ordnum"
        Me.OrdnumDataGridViewTextBoxColumn.HeaderText = "رقم الطلب"
        Me.OrdnumDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.OrdnumDataGridViewTextBoxColumn.Name = "OrdnumDataGridViewTextBoxColumn"
        Me.OrdnumDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrdnumDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotlDataGridViewTextBoxColumn
        '
        Me.TotlDataGridViewTextBoxColumn.DataPropertyName = "totl"
        Me.TotlDataGridViewTextBoxColumn.HeaderText = "المجموع/ا.ا"
        Me.TotlDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.TotlDataGridViewTextBoxColumn.Name = "TotlDataGridViewTextBoxColumn"
        Me.TotlDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotlDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TotdDataGridViewTextBoxColumn
        '
        Me.TotdDataGridViewTextBoxColumn.DataPropertyName = "totd"
        Me.TotdDataGridViewTextBoxColumn.HeaderText = "$/المجموع"
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
        Me.PlDataGridViewTextBoxColumn.HeaderText = "السعر المنتج/ل.ل"
        Me.PlDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.PlDataGridViewTextBoxColumn.Name = "PlDataGridViewTextBoxColumn"
        Me.PlDataGridViewTextBoxColumn.ReadOnly = True
        Me.PlDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'PdDataGridViewTextBoxColumn
        '
        Me.PdDataGridViewTextBoxColumn.DataPropertyName = "pd"
        Me.PdDataGridViewTextBoxColumn.HeaderText = "$/سعر المنتج"
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
        Me.StockIDDataGridViewTextBoxColumn.HeaderText = "المتسلسل المنتج بالمخزون"
        Me.StockIDDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.StockIDDataGridViewTextBoxColumn.Name = "StockIDDataGridViewTextBoxColumn"
        Me.StockIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.StockIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "المتسلسل"
        Me.IdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'ActionTypeDataGridViewTextBoxColumn
        '
        Me.ActionTypeDataGridViewTextBoxColumn.DataPropertyName = "actionType"
        Me.ActionTypeDataGridViewTextBoxColumn.HeaderText = "نوع العملية"
        Me.ActionTypeDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.ActionTypeDataGridViewTextBoxColumn.Name = "ActionTypeDataGridViewTextBoxColumn"
        Me.ActionTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ActionTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'TransIdDataGridViewTextBoxColumn
        '
        Me.TransIdDataGridViewTextBoxColumn.DataPropertyName = "transId"
        Me.TransIdDataGridViewTextBoxColumn.HeaderText = "متسلسل التحويلات"
        Me.TransIdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.TransIdDataGridViewTextBoxColumn.Name = "TransIdDataGridViewTextBoxColumn"
        Me.TransIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.TransIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'ordertrack1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Guna2Button6)
        Me.Controls.Add(Me.Guna2Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ordertrack1"
        Me.Text = "ordertrack1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderTransactionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Shapes2 As Guna.UI2.WinForms.Guna2Shapes
    Friend WithEvents dgv As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents MARKETDataSet As MARKETDataSet
    Friend WithEvents OrderTransactionsBindingSource As BindingSource
    Friend WithEvents OrderTransactionsTableAdapter As MARKETDataSetTableAdapters.orderTransactionsTableAdapter
    Friend WithEvents TableAdapterManager1 As MARKETDataSetTableAdapters.TableAdapterManager
    Friend WithEvents BindingNavigator1 As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents Button3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button6 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button4 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ActionDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents typej As DataGridViewTextBoxColumn
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
    Friend WithEvents ActionTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TransIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
