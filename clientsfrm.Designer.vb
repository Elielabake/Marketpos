<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class clientsfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(clientsfrm))
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Shapes2 = New Guna.UI2.WinForms.Guna2Shapes()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.Button3 = New Guna.UI2.WinForms.Guna2Button()
        Me.stockDGV = New Zuby.ADGV.AdvancedDataGridView()
        Me.ClienttblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MARKETDataSet = New Market.MARKETDataSet()
        Me.ClienttblTableAdapter = New Market.MARKETDataSetTableAdapters.clienttblTableAdapter()
        Me.TableAdapterManager = New Market.MARKETDataSetTableAdapters.TableAdapterManager()
        Me.ClienttblBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.ClienttblBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.stockDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClienttblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClienttblBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ClienttblBindingNavigator.SuspendLayout()
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
        Me.Guna2Panel1.TabIndex = 4
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
        Me.Label5.Size = New System.Drawing.Size(138, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "ELPOS-اسماء الزبائن"
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
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2ShadowPanel1.Controls.Add(Me.Button3)
        Me.Guna2ShadowPanel1.Controls.Add(Me.stockDGV)
        Me.Guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(0, 27)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(1366, 741)
        Me.Guna2ShadowPanel1.TabIndex = 734
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.AutoRoundedCorners = True
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BorderColor = System.Drawing.Color.White
        Me.Button3.BorderRadius = 14
        Me.Button3.FillColor = System.Drawing.Color.Green
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(1252, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 30)
        Me.Button3.TabIndex = 734
        Me.Button3.Text = " [F1]حفظ"
        '
        'stockDGV
        '
        Me.stockDGV.AllowUserToAddRows = False
        Me.stockDGV.AllowUserToResizeColumns = False
        Me.stockDGV.AllowUserToResizeRows = False
        Me.stockDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stockDGV.AutoGenerateColumns = False
        Me.stockDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.stockDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.stockDGV.BackgroundColor = System.Drawing.Color.White
        Me.stockDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.stockDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.stockDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.stockDGV.ColumnHeadersHeight = 45
        Me.stockDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.stockDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn1})
        Me.stockDGV.DataSource = Me.ClienttblBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.stockDGV.DefaultCellStyle = DataGridViewCellStyle2
        Me.stockDGV.EnableHeadersVisualStyles = False
        Me.stockDGV.FilterAndSortEnabled = True
        Me.stockDGV.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.stockDGV.Location = New System.Drawing.Point(16, 34)
        Me.stockDGV.MaxFilterButtonImageHeight = 23
        Me.stockDGV.Name = "stockDGV"
        Me.stockDGV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.stockDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.stockDGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.stockDGV.RowHeadersVisible = False
        Me.stockDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.stockDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.stockDGV.Size = New System.Drawing.Size(1331, 674)
        Me.stockDGV.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.stockDGV.TabIndex = 733
        '
        'ClienttblBindingSource
        '
        Me.ClienttblBindingSource.DataMember = "clienttbl"
        Me.ClienttblBindingSource.DataSource = Me.MARKETDataSet
        '
        'MARKETDataSet
        '
        Me.MARKETDataSet.DataSetName = "MARKETDataSet"
        Me.MARKETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClienttblTableAdapter
        '
        Me.ClienttblTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.cashiertblTableAdapter = Nothing
        Me.TableAdapterManager.categTblTableAdapter = Nothing
        Me.TableAdapterManager.clienttblTableAdapter = Me.ClienttblTableAdapter
        Me.TableAdapterManager.dailypTableAdapter = Nothing
        Me.TableAdapterManager.debitTblTableAdapter = Nothing
        Me.TableAdapterManager.dollarrateTblTableAdapter = Nothing
        Me.TableAdapterManager.equipmentTbl1TableAdapter = Nothing
        Me.TableAdapterManager.expTblTableAdapter = Nothing
        Me.TableAdapterManager.invoicedateTblTableAdapter = Nothing
        Me.TableAdapterManager.invoicereturnTblTableAdapter = Nothing
        Me.TableAdapterManager.invoiceTblTableAdapter = Nothing
        Me.TableAdapterManager.ndTblTableAdapter = Nothing
        Me.TableAdapterManager.ordernew1TableAdapter = Nothing
        Me.TableAdapterManager.ordernewTableAdapter = Nothing
        Me.TableAdapterManager.orderstblTableAdapter = Nothing
        Me.TableAdapterManager.ordertbl1TableAdapter = Nothing
        Me.TableAdapterManager.orderTransactionsTableAdapter = Nothing
        Me.TableAdapterManager.stockdetailstblTableAdapter = Nothing
        Me.TableAdapterManager.stockTableAdapter = Nothing
        Me.TableAdapterManager.suppdebitTblTableAdapter = Nothing
        Me.TableAdapterManager.suppliersreturnTblTableAdapter = Nothing
        Me.TableAdapterManager.suppliersTblTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Market.MARKETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UserloginTblTableAdapter = Nothing
        Me.TableAdapterManager.UserTblTableAdapter = Nothing
        '
        'ClienttblBindingNavigator
        '
        Me.ClienttblBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ClienttblBindingNavigator.BindingSource = Me.ClienttblBindingSource
        Me.ClienttblBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ClienttblBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ClienttblBindingNavigator.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ClienttblBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ClienttblBindingNavigatorSaveItem})
        Me.ClienttblBindingNavigator.Location = New System.Drawing.Point(0, 27)
        Me.ClienttblBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ClienttblBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ClienttblBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ClienttblBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ClienttblBindingNavigator.Name = "ClienttblBindingNavigator"
        Me.ClienttblBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ClienttblBindingNavigator.Size = New System.Drawing.Size(1366, 31)
        Me.ClienttblBindingNavigator.TabIndex = 737
        Me.ClienttblBindingNavigator.Text = "BindingNavigator1"
        Me.ClienttblBindingNavigator.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(28, 28)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 28)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(28, 28)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(28, 28)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(28, 28)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 31)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(28, 28)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(28, 28)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'ClienttblBindingNavigatorSaveItem
        '
        Me.ClienttblBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClienttblBindingNavigatorSaveItem.Image = CType(resources.GetObject("ClienttblBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ClienttblBindingNavigatorSaveItem.Name = "ClienttblBindingNavigatorSaveItem"
        Me.ClienttblBindingNavigatorSaveItem.Size = New System.Drawing.Size(28, 28)
        Me.ClienttblBindingNavigatorSaveItem.Text = "Save Data"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "date"
        Me.DataGridViewTextBoxColumn4.HeaderText = "التاريخ"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 24
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "pn"
        Me.DataGridViewTextBoxColumn3.HeaderText = "رقم الهاتف"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 24
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "cn"
        Me.DataGridViewTextBoxColumn2.HeaderText = "اسم الزبون"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 24
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "#"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 24
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'clientsfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.ClienttblBindingNavigator)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "clientsfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "clientsfrm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        CType(Me.stockDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClienttblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClienttblBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ClienttblBindingNavigator.ResumeLayout(False)
        Me.ClienttblBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Shapes2 As Guna.UI2.WinForms.Guna2Shapes
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents stockDGV As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents Button3 As Guna.UI2.WinForms.Guna2Button
    '  Friend WithEvents ClienttblTableAdapter As marketDataSetTableAdapters.clienttblTableAdapter
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PnDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CnDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MARKETDataSet As MARKETDataSet
    Friend WithEvents ClienttblBindingSource As BindingSource
    Friend WithEvents ClienttblTableAdapter As MARKETDataSetTableAdapters.clienttblTableAdapter
    Friend WithEvents TableAdapterManager As MARKETDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ClienttblBindingNavigator As BindingNavigator
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
    Friend WithEvents ClienttblBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
End Class
