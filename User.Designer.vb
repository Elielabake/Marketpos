<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class User
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(User))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Shapes2 = New Guna.UI2.WinForms.Guna2Shapes()
        Me.RType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Upass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Uname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Button2 = New Guna.UI2.WinForms.Guna2Button()
        Me.Button3 = New Guna.UI2.WinForms.Guna2Button()
        Me.button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.UserTblBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.UserTblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MARKETDataSet = New Market.MARKETDataSet()
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
        Me.UserTblBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.Userdgv = New Zuby.ADGV.AdvancedDataGridView()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.UserTblTableAdapter = New Market.MARKETDataSetTableAdapters.UserTblTableAdapter()
        Me.TableAdapterManager = New Market.MARKETDataSetTableAdapters.TableAdapterManager()
        Me.RtypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.UserTblBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UserTblBindingNavigator.SuspendLayout()
        CType(Me.UserTblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Userdgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel1.SuspendLayout()
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
        Me.Guna2Panel1.TabIndex = 1
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
        Me.Label5.Size = New System.Drawing.Size(86, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "المستخدمين"
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
        Me.Guna2Shapes2.Location = New System.Drawing.Point(1318, 8)
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
        'RType
        '
        Me.RType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RType.AutoRoundedCorners = True
        Me.RType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.RType.BorderRadius = 12
        Me.RType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.RType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RType.FillColor = System.Drawing.Color.WhiteSmoke
        Me.RType.FocusedColor = System.Drawing.Color.LightSeaGreen
        Me.RType.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.RType.FocusedState.FillColor = System.Drawing.Color.Transparent
        Me.RType.FocusedState.ForeColor = System.Drawing.Color.Transparent
        Me.RType.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.RType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.RType.ItemHeight = 21
        Me.RType.Items.AddRange(New Object() {"رئيسي", "ثانوي"})
        Me.RType.ItemsAppearance.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RType.ItemsAppearance.ForeColor = System.Drawing.Color.Black
        Me.RType.Location = New System.Drawing.Point(1035, 111)
        Me.RType.Name = "RType"
        Me.RType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RType.Size = New System.Drawing.Size(183, 27)
        Me.RType.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.RType.TabIndex = 697
        Me.RType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1243, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 22)
        Me.Label3.TabIndex = 696
        Me.Label3.Text = "نوع الحساب"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1243, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 22)
        Me.Label2.TabIndex = 695
        Me.Label2.Text = "اسم المستخدم"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(1243, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 22)
        Me.Label4.TabIndex = 694
        Me.Label4.Text = "كلمة السر"
        '
        'Upass
        '
        Me.Upass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Upass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Upass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Upass.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Upass.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Upass.BorderRadius = 10
        Me.Upass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Upass.DefaultText = ""
        Me.Upass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Upass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Upass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Upass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Upass.FillColor = System.Drawing.Color.WhiteSmoke
        Me.Upass.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.Upass.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Upass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Upass.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Upass.Location = New System.Drawing.Point(1035, 77)
        Me.Upass.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Upass.Name = "Upass"
        Me.Upass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Upass.PlaceholderForeColor = System.Drawing.Color.White
        Me.Upass.PlaceholderText = ""
        Me.Upass.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Upass.SelectedText = ""
        Me.Upass.Size = New System.Drawing.Size(183, 26)
        Me.Upass.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.Upass.TabIndex = 688
        '
        'Uname
        '
        Me.Uname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Uname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Uname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Uname.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Uname.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Uname.BorderRadius = 10
        Me.Uname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Uname.DefaultText = ""
        Me.Uname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Uname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Uname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Uname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Uname.FillColor = System.Drawing.Color.WhiteSmoke
        Me.Uname.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.Uname.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Uname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Uname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Uname.Location = New System.Drawing.Point(1035, 43)
        Me.Uname.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Uname.Name = "Uname"
        Me.Uname.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Uname.PlaceholderForeColor = System.Drawing.Color.White
        Me.Uname.PlaceholderText = ""
        Me.Uname.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Uname.SelectedText = ""
        Me.Uname.Size = New System.Drawing.Size(183, 26)
        Me.Uname.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.Uname.TabIndex = 687
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.AutoRoundedCorners = True
        Me.Button2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button2.BorderColor = System.Drawing.Color.White
        Me.Button2.BorderRadius = 14
        Me.Button2.FillColor = System.Drawing.Color.Green
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(985, 165)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(109, 30)
        Me.Button2.TabIndex = 700
        Me.Button2.Text = " [F1] حفظ"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.AutoRoundedCorners = True
        Me.Button3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button3.BorderColor = System.Drawing.Color.White
        Me.Button3.BorderRadius = 14
        Me.Button3.FillColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(1106, 165)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 30)
        Me.Button3.TabIndex = 699
        Me.Button3.Text = " [Del] مسح "
        '
        'button1
        '
        Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button1.AutoRoundedCorners = True
        Me.button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.button1.BorderColor = System.Drawing.Color.White
        Me.button1.BorderRadius = 14
        Me.button1.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.button1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.button1.ForeColor = System.Drawing.Color.White
        Me.button1.Location = New System.Drawing.Point(1218, 165)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(117, 30)
        Me.button1.TabIndex = 698
        Me.button1.Text = "[Enter] اضافة "
        '
        'UserTblBindingNavigator
        '
        Me.UserTblBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.UserTblBindingNavigator.BindingSource = Me.UserTblBindingSource
        Me.UserTblBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.UserTblBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.UserTblBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.UserTblBindingNavigatorSaveItem})
        Me.UserTblBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.UserTblBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.UserTblBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.UserTblBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.UserTblBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.UserTblBindingNavigator.Name = "UserTblBindingNavigator"
        Me.UserTblBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.UserTblBindingNavigator.Size = New System.Drawing.Size(1366, 25)
        Me.UserTblBindingNavigator.TabIndex = 701
        Me.UserTblBindingNavigator.Text = "BindingNavigator1"
        Me.UserTblBindingNavigator.Visible = False
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
        'UserTblBindingSource
        '
        Me.UserTblBindingSource.DataMember = "UserTbl"
        Me.UserTblBindingSource.DataSource = Me.MARKETDataSet
        '
        'MARKETDataSet
        '
        Me.MARKETDataSet.DataSetName = "MARKETDataSet"
        Me.MARKETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'UserTblBindingNavigatorSaveItem
        '
        Me.UserTblBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UserTblBindingNavigatorSaveItem.Image = CType(resources.GetObject("UserTblBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.UserTblBindingNavigatorSaveItem.Name = "UserTblBindingNavigatorSaveItem"
        Me.UserTblBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.UserTblBindingNavigatorSaveItem.Text = "Save Data"
        '
        'Userdgv
        '
        Me.Userdgv.AllowUserToAddRows = False
        Me.Userdgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Userdgv.AutoGenerateColumns = False
        Me.Userdgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Userdgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Userdgv.BackgroundColor = System.Drawing.Color.White
        Me.Userdgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Userdgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Userdgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Userdgv.ColumnHeadersHeight = 26
        Me.Userdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Userdgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RtypeDataGridViewTextBoxColumn, Me.UpassDataGridViewTextBoxColumn, Me.UnameDataGridViewTextBoxColumn, Me.IdDataGridViewTextBoxColumn})
        Me.Userdgv.DataSource = Me.UserTblBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Userdgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.Userdgv.EnableHeadersVisualStyles = False
        Me.Userdgv.FilterAndSortEnabled = True
        Me.Userdgv.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.Userdgv.Location = New System.Drawing.Point(29, 32)
        Me.Userdgv.MaxFilterButtonImageHeight = 23
        Me.Userdgv.Name = "Userdgv"
        Me.Userdgv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Userdgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Userdgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Userdgv.RowHeadersVisible = False
        Me.Userdgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Userdgv.Size = New System.Drawing.Size(950, 704)
        Me.Userdgv.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.Userdgv.TabIndex = 702
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.Button2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Userdgv)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Button3)
        Me.Guna2ShadowPanel1.Controls.Add(Me.button1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Uname)
        Me.Guna2ShadowPanel1.Controls.Add(Me.RType)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Upass)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label3)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label4)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label2)
        Me.Guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(1366, 768)
        Me.Guna2ShadowPanel1.TabIndex = 703
        '
        'UserTblTableAdapter
        '
        Me.UserTblTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.cashiertblTableAdapter = Nothing
        Me.TableAdapterManager.categTblTableAdapter = Nothing
        Me.TableAdapterManager.clienttblTableAdapter = Nothing
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
        Me.TableAdapterManager.UserTblTableAdapter = Me.UserTblTableAdapter
        '
        'RtypeDataGridViewTextBoxColumn
        '
        Me.RtypeDataGridViewTextBoxColumn.DataPropertyName = "rtype"
        Me.RtypeDataGridViewTextBoxColumn.HeaderText = "نوع الحساب"
        Me.RtypeDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.RtypeDataGridViewTextBoxColumn.Name = "RtypeDataGridViewTextBoxColumn"
        Me.RtypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'UpassDataGridViewTextBoxColumn
        '
        Me.UpassDataGridViewTextBoxColumn.DataPropertyName = "Upass"
        Me.UpassDataGridViewTextBoxColumn.HeaderText = "كلمة السر"
        Me.UpassDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.UpassDataGridViewTextBoxColumn.Name = "UpassDataGridViewTextBoxColumn"
        Me.UpassDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'UnameDataGridViewTextBoxColumn
        '
        Me.UnameDataGridViewTextBoxColumn.DataPropertyName = "Uname"
        Me.UnameDataGridViewTextBoxColumn.HeaderText = "اسم المستخدم"
        Me.UnameDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.UnameDataGridViewTextBoxColumn.Name = "UnameDataGridViewTextBoxColumn"
        Me.UnameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "#"
        Me.IdDataGridViewTextBoxColumn.MinimumWidth = 24
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.UserTblBindingNavigator)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "User"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.UserTblBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UserTblBindingNavigator.ResumeLayout(False)
        Me.UserTblBindingNavigator.PerformLayout()
        CType(Me.UserTblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MARKETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Userdgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Shapes2 As Guna.UI2.WinForms.Guna2Shapes
    Friend WithEvents RType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Upass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Uname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Button3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents UserTblBindingNavigator As BindingNavigator
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
    Friend WithEvents UserTblBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents Userdgv As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents RtypeDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents UpassDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents UnameDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents MARKETDataSet As MARKETDataSet
    Friend WithEvents UserTblBindingSource As BindingSource
    Friend WithEvents UserTblTableAdapter As MARKETDataSetTableAdapters.UserTblTableAdapter
    Friend WithEvents TableAdapterManager As MARKETDataSetTableAdapters.TableAdapterManager
    Friend WithEvents RtypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UpassDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UnameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
