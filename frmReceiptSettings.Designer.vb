<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceiptSettings
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
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStoreName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAddress = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPhone = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnBrowseLogo = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClearLogo = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
        Me.CheckBoxPrintTotal = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPrintPrice = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPrintProduct = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPrintQty = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RadioButtonLBP = New System.Windows.Forms.RadioButton()
        Me.RadioButtonUSD = New System.Windows.Forms.RadioButton()
        Me.TXTFOOT = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTSUBFOOT = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTNOTES = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RadioButtonout = New System.Windows.Forms.RadioButton()
        Me.RadioButtonin = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Guna2GroupBox1 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Guna2GroupBox2 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Guna2ToggleSwitch1 = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.strname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnSave1 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClearLogo1 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnBrowseLogo1 = New Guna.UI2.WinForms.Guna2Button()
        Me.picLogo1 = New System.Windows.Forms.PictureBox()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GroupBox1.SuspendLayout()
        Me.Guna2GroupBox2.SuspendLayout()
        CType(Me.picLogo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.Label5)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1340, 27)
        Me.Guna2Panel1.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "ELPOS-اعدادات الطبع"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1312, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "X"
        '
        'txtStoreName
        '
        Me.txtStoreName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtStoreName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtStoreName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtStoreName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtStoreName.BorderRadius = 10
        Me.txtStoreName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreName.DefaultText = ""
        Me.txtStoreName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtStoreName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtStoreName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtStoreName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtStoreName.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtStoreName.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtStoreName.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtStoreName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtStoreName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStoreName.Location = New System.Drawing.Point(239, 114)
        Me.txtStoreName.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtStoreName.Name = "txtStoreName"
        Me.txtStoreName.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtStoreName.PlaceholderText = ""
        Me.txtStoreName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStoreName.SelectedText = ""
        Me.txtStoreName.Size = New System.Drawing.Size(183, 26)
        Me.txtStoreName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtStoreName.TabIndex = 711
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(450, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 22)
        Me.Label8.TabIndex = 712
        Me.Label8.Text = "اسم العمل"
        '
        'txtAddress
        '
        Me.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAddress.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAddress.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtAddress.BorderRadius = 10
        Me.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAddress.DefaultText = ""
        Me.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtAddress.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtAddress.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAddress.Location = New System.Drawing.Point(239, 151)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtAddress.PlaceholderText = ""
        Me.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAddress.SelectedText = ""
        Me.txtAddress.Size = New System.Drawing.Size(183, 26)
        Me.txtAddress.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtAddress.TabIndex = 713
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(467, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 22)
        Me.Label2.TabIndex = 714
        Me.Label2.Text = "العنوان"
        '
        'txtPhone
        '
        Me.txtPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPhone.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPhone.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPhone.BorderRadius = 10
        Me.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPhone.DefaultText = ""
        Me.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtPhone.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtPhone.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtPhone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPhone.Location = New System.Drawing.Point(239, 188)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtPhone.PlaceholderText = ""
        Me.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPhone.SelectedText = ""
        Me.txtPhone.Size = New System.Drawing.Size(183, 26)
        Me.txtPhone.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtPhone.TabIndex = 715
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(444, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 22)
        Me.Label3.TabIndex = 716
        Me.Label3.Text = "رقم الهاتف"
        '
        'picLogo
        '
        Me.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLogo.Location = New System.Drawing.Point(30, 354)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(370, 370)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 717
        Me.picLogo.TabStop = False
        '
        'btnBrowseLogo
        '
        Me.btnBrowseLogo.AutoRoundedCorners = True
        Me.btnBrowseLogo.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowseLogo.BorderColor = System.Drawing.Color.White
        Me.btnBrowseLogo.BorderRadius = 14
        Me.btnBrowseLogo.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnBrowseLogo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnBrowseLogo.ForeColor = System.Drawing.Color.White
        Me.btnBrowseLogo.Location = New System.Drawing.Point(406, 354)
        Me.btnBrowseLogo.Name = "btnBrowseLogo"
        Me.btnBrowseLogo.Size = New System.Drawing.Size(111, 30)
        Me.btnBrowseLogo.TabIndex = 728
        Me.btnBrowseLogo.Text = "اختر صورة"
        '
        'btnClearLogo
        '
        Me.btnClearLogo.AutoRoundedCorners = True
        Me.btnClearLogo.BackColor = System.Drawing.Color.Transparent
        Me.btnClearLogo.BorderColor = System.Drawing.Color.White
        Me.btnClearLogo.BorderRadius = 14
        Me.btnClearLogo.FillColor = System.Drawing.Color.Maroon
        Me.btnClearLogo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearLogo.ForeColor = System.Drawing.Color.White
        Me.btnClearLogo.Location = New System.Drawing.Point(406, 390)
        Me.btnClearLogo.Name = "btnClearLogo"
        Me.btnClearLogo.Size = New System.Drawing.Size(111, 30)
        Me.btnClearLogo.TabIndex = 729
        Me.btnClearLogo.Text = "ازالة الصورة"
        '
        'btnSave
        '
        Me.btnSave.AutoRoundedCorners = True
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.BorderColor = System.Drawing.Color.White
        Me.btnSave.BorderRadius = 14
        Me.btnSave.FillColor = System.Drawing.Color.DarkGreen
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(406, 426)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(111, 30)
        Me.btnSave.TabIndex = 730
        Me.btnSave.Text = "حفظ"
        '
        'CheckBoxPrintTotal
        '
        Me.CheckBoxPrintTotal.AutoSize = True
        Me.CheckBoxPrintTotal.Location = New System.Drawing.Point(138, 142)
        Me.CheckBoxPrintTotal.Name = "CheckBoxPrintTotal"
        Me.CheckBoxPrintTotal.Size = New System.Drawing.Size(62, 17)
        Me.CheckBoxPrintTotal.TabIndex = 731
        Me.CheckBoxPrintTotal.Text = "المجموع"
        Me.CheckBoxPrintTotal.UseVisualStyleBackColor = True
        '
        'CheckBoxPrintPrice
        '
        Me.CheckBoxPrintPrice.AutoSize = True
        Me.CheckBoxPrintPrice.Location = New System.Drawing.Point(138, 165)
        Me.CheckBoxPrintPrice.Name = "CheckBoxPrintPrice"
        Me.CheckBoxPrintPrice.Size = New System.Drawing.Size(52, 17)
        Me.CheckBoxPrintPrice.TabIndex = 732
        Me.CheckBoxPrintPrice.Text = "السعر"
        Me.CheckBoxPrintPrice.UseVisualStyleBackColor = True
        '
        'CheckBoxPrintProduct
        '
        Me.CheckBoxPrintProduct.AutoSize = True
        Me.CheckBoxPrintProduct.Location = New System.Drawing.Point(138, 188)
        Me.CheckBoxPrintProduct.Name = "CheckBoxPrintProduct"
        Me.CheckBoxPrintProduct.Size = New System.Drawing.Size(73, 17)
        Me.CheckBoxPrintProduct.TabIndex = 733
        Me.CheckBoxPrintProduct.Text = "اسم المنتج"
        Me.CheckBoxPrintProduct.UseVisualStyleBackColor = True
        '
        'CheckBoxPrintQty
        '
        Me.CheckBoxPrintQty.AutoSize = True
        Me.CheckBoxPrintQty.Location = New System.Drawing.Point(138, 211)
        Me.CheckBoxPrintQty.Name = "CheckBoxPrintQty"
        Me.CheckBoxPrintQty.Size = New System.Drawing.Size(53, 17)
        Me.CheckBoxPrintQty.TabIndex = 734
        Me.CheckBoxPrintQty.Text = "الكمية"
        Me.CheckBoxPrintQty.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(108, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 22)
        Me.Label4.TabIndex = 735
        Me.Label4.Text = "ظاهر في الفاتورة"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(-1, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 22)
        Me.Label6.TabIndex = 736
        Me.Label6.Text = "العملة"
        '
        'RadioButtonLBP
        '
        Me.RadioButtonLBP.AutoSize = True
        Me.RadioButtonLBP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButtonLBP.Location = New System.Drawing.Point(3, 31)
        Me.RadioButtonLBP.Name = "RadioButtonLBP"
        Me.RadioButtonLBP.Size = New System.Drawing.Size(44, 19)
        Me.RadioButtonLBP.TabIndex = 737
        Me.RadioButtonLBP.TabStop = True
        Me.RadioButtonLBP.Text = "ل.ل"
        Me.RadioButtonLBP.UseVisualStyleBackColor = True
        '
        'RadioButtonUSD
        '
        Me.RadioButtonUSD.AutoSize = True
        Me.RadioButtonUSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButtonUSD.Location = New System.Drawing.Point(3, 56)
        Me.RadioButtonUSD.Name = "RadioButtonUSD"
        Me.RadioButtonUSD.Size = New System.Drawing.Size(31, 19)
        Me.RadioButtonUSD.TabIndex = 738
        Me.RadioButtonUSD.TabStop = True
        Me.RadioButtonUSD.Text = "$"
        Me.RadioButtonUSD.UseVisualStyleBackColor = True
        '
        'TXTFOOT
        '
        Me.TXTFOOT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TXTFOOT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TXTFOOT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TXTFOOT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TXTFOOT.BorderRadius = 10
        Me.TXTFOOT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTFOOT.DefaultText = ""
        Me.TXTFOOT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTFOOT.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTFOOT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTFOOT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTFOOT.FillColor = System.Drawing.Color.WhiteSmoke
        Me.TXTFOOT.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.TXTFOOT.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TXTFOOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TXTFOOT.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTFOOT.Location = New System.Drawing.Point(239, 261)
        Me.TXTFOOT.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TXTFOOT.Name = "TXTFOOT"
        Me.TXTFOOT.PlaceholderForeColor = System.Drawing.Color.White
        Me.TXTFOOT.PlaceholderText = ""
        Me.TXTFOOT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TXTFOOT.SelectedText = ""
        Me.TXTFOOT.Size = New System.Drawing.Size(183, 26)
        Me.TXTFOOT.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.TXTFOOT.TabIndex = 741
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(471, 265)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 22)
        Me.Label7.TabIndex = 742
        Me.Label7.Text = "النهاية"
        '
        'TXTSUBFOOT
        '
        Me.TXTSUBFOOT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TXTSUBFOOT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TXTSUBFOOT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TXTSUBFOOT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TXTSUBFOOT.BorderRadius = 10
        Me.TXTSUBFOOT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTSUBFOOT.DefaultText = ""
        Me.TXTSUBFOOT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTSUBFOOT.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTSUBFOOT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTSUBFOOT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTSUBFOOT.FillColor = System.Drawing.Color.WhiteSmoke
        Me.TXTSUBFOOT.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.TXTSUBFOOT.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TXTSUBFOOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TXTSUBFOOT.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTSUBFOOT.Location = New System.Drawing.Point(239, 224)
        Me.TXTSUBFOOT.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TXTSUBFOOT.Name = "TXTSUBFOOT"
        Me.TXTSUBFOOT.PlaceholderForeColor = System.Drawing.Color.White
        Me.TXTSUBFOOT.PlaceholderText = ""
        Me.TXTSUBFOOT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TXTSUBFOOT.SelectedText = ""
        Me.TXTSUBFOOT.Size = New System.Drawing.Size(183, 26)
        Me.TXTSUBFOOT.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.TXTSUBFOOT.TabIndex = 739
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(446, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 22)
        Me.Label9.TabIndex = 740
        Me.Label9.Text = "قبل النهاية"
        '
        'TXTNOTES
        '
        Me.TXTNOTES.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TXTNOTES.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TXTNOTES.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TXTNOTES.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TXTNOTES.BorderRadius = 10
        Me.TXTNOTES.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTNOTES.DefaultText = ""
        Me.TXTNOTES.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TXTNOTES.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TXTNOTES.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTNOTES.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TXTNOTES.FillColor = System.Drawing.Color.WhiteSmoke
        Me.TXTNOTES.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.TXTNOTES.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TXTNOTES.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TXTNOTES.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTNOTES.Location = New System.Drawing.Point(17, 294)
        Me.TXTNOTES.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TXTNOTES.Name = "TXTNOTES"
        Me.TXTNOTES.PlaceholderForeColor = System.Drawing.Color.White
        Me.TXTNOTES.PlaceholderText = ""
        Me.TXTNOTES.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TXTNOTES.SelectedText = ""
        Me.TXTNOTES.Size = New System.Drawing.Size(405, 26)
        Me.TXTNOTES.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.TXTNOTES.TabIndex = 743
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(464, 298)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 22)
        Me.Label10.TabIndex = 744
        Me.Label10.Text = "ملاحظة"
        '
        'RadioButtonout
        '
        Me.RadioButtonout.AutoSize = True
        Me.RadioButtonout.ForeColor = System.Drawing.Color.Black
        Me.RadioButtonout.Location = New System.Drawing.Point(25, 64)
        Me.RadioButtonout.Name = "RadioButtonout"
        Me.RadioButtonout.Size = New System.Drawing.Size(55, 19)
        Me.RadioButtonout.TabIndex = 747
        Me.RadioButtonout.TabStop = True
        Me.RadioButtonout.Text = "مخفي"
        Me.RadioButtonout.UseVisualStyleBackColor = True
        '
        'RadioButtonin
        '
        Me.RadioButtonin.AutoSize = True
        Me.RadioButtonin.ForeColor = System.Drawing.Color.Black
        Me.RadioButtonin.Location = New System.Drawing.Point(25, 39)
        Me.RadioButtonin.Name = "RadioButtonin"
        Me.RadioButtonin.Size = New System.Drawing.Size(51, 19)
        Me.RadioButtonin.TabIndex = 746
        Me.RadioButtonin.TabStop = True
        Me.RadioButtonin.Text = "ظاهر"
        Me.RadioButtonin.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(7, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 22)
        Me.Label11.TabIndex = 745
        Me.Label11.Text = "معلومات الزبون"
        '
        'Guna2GroupBox1
        '
        Me.Guna2GroupBox1.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2GroupBox1.Controls.Add(Me.RadioButtonLBP)
        Me.Guna2GroupBox1.Controls.Add(Me.Label6)
        Me.Guna2GroupBox1.Controls.Add(Me.RadioButtonUSD)
        Me.Guna2GroupBox1.CustomBorderColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2GroupBox1.FillColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2GroupBox1.Location = New System.Drawing.Point(30, 111)
        Me.Guna2GroupBox1.Name = "Guna2GroupBox1"
        Me.Guna2GroupBox1.Size = New System.Drawing.Size(64, 82)
        Me.Guna2GroupBox1.TabIndex = 748
        '
        'Guna2GroupBox2
        '
        Me.Guna2GroupBox2.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2GroupBox2.Controls.Add(Me.RadioButtonout)
        Me.Guna2GroupBox2.Controls.Add(Me.Label11)
        Me.Guna2GroupBox2.Controls.Add(Me.RadioButtonin)
        Me.Guna2GroupBox2.CustomBorderColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2GroupBox2.FillColor = System.Drawing.Color.WhiteSmoke
        Me.Guna2GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2GroupBox2.Location = New System.Drawing.Point(10, 196)
        Me.Guna2GroupBox2.Name = "Guna2GroupBox2"
        Me.Guna2GroupBox2.Size = New System.Drawing.Size(117, 91)
        Me.Guna2GroupBox2.TabIndex = 749
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(156, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(160, 36)
        Me.Label12.TabIndex = 750
        Me.Label12.Text = "فاتورة صغيرة"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(977, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 36)
        Me.Label13.TabIndex = 751
        Me.Label13.Text = "فاتورة كبيرة"
        '
        'Guna2ToggleSwitch1
        '
        Me.Guna2ToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2ToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2ToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.Location = New System.Drawing.Point(627, 46)
        Me.Guna2ToggleSwitch1.Name = "Guna2ToggleSwitch1"
        Me.Guna2ToggleSwitch1.Size = New System.Drawing.Size(35, 20)
        Me.Guna2ToggleSwitch1.TabIndex = 752
        Me.Guna2ToggleSwitch1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2ToggleSwitch1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2ToggleSwitch1.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(514, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 22)
        Me.Label14.TabIndex = 753
        Me.Label14.Text = "فاتورة صغيرة"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(681, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 22)
        Me.Label15.TabIndex = 754
        Me.Label15.Text = "فاتورة كبيرة"
        '
        'strname
        '
        Me.strname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.strname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.strname.BackColor = System.Drawing.Color.WhiteSmoke
        Me.strname.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.strname.BorderRadius = 10
        Me.strname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.strname.DefaultText = ""
        Me.strname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.strname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.strname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.strname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.strname.FillColor = System.Drawing.Color.WhiteSmoke
        Me.strname.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.strname.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.strname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.strname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.strname.Location = New System.Drawing.Point(1032, 114)
        Me.strname.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.strname.Name = "strname"
        Me.strname.PlaceholderForeColor = System.Drawing.Color.White
        Me.strname.PlaceholderText = ""
        Me.strname.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.strname.SelectedText = ""
        Me.strname.Size = New System.Drawing.Size(183, 26)
        Me.strname.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.strname.TabIndex = 755
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(1243, 118)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 22)
        Me.Label18.TabIndex = 756
        Me.Label18.Text = "اسم العمل"
        '
        'btnSave1
        '
        Me.btnSave1.AutoRoundedCorners = True
        Me.btnSave1.BackColor = System.Drawing.Color.Transparent
        Me.btnSave1.BorderColor = System.Drawing.Color.White
        Me.btnSave1.BorderRadius = 14
        Me.btnSave1.FillColor = System.Drawing.Color.DarkGreen
        Me.btnSave1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave1.ForeColor = System.Drawing.Color.White
        Me.btnSave1.Location = New System.Drawing.Point(1221, 426)
        Me.btnSave1.Name = "btnSave1"
        Me.btnSave1.Size = New System.Drawing.Size(111, 30)
        Me.btnSave1.TabIndex = 764
        Me.btnSave1.Text = "حفظ"
        '
        'btnClearLogo1
        '
        Me.btnClearLogo1.AutoRoundedCorners = True
        Me.btnClearLogo1.BackColor = System.Drawing.Color.Transparent
        Me.btnClearLogo1.BorderColor = System.Drawing.Color.White
        Me.btnClearLogo1.BorderRadius = 14
        Me.btnClearLogo1.FillColor = System.Drawing.Color.Maroon
        Me.btnClearLogo1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearLogo1.ForeColor = System.Drawing.Color.White
        Me.btnClearLogo1.Location = New System.Drawing.Point(1221, 390)
        Me.btnClearLogo1.Name = "btnClearLogo1"
        Me.btnClearLogo1.Size = New System.Drawing.Size(111, 30)
        Me.btnClearLogo1.TabIndex = 763
        Me.btnClearLogo1.Text = "ازالة الصورة"
        '
        'btnBrowseLogo1
        '
        Me.btnBrowseLogo1.AutoRoundedCorners = True
        Me.btnBrowseLogo1.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowseLogo1.BorderColor = System.Drawing.Color.White
        Me.btnBrowseLogo1.BorderRadius = 14
        Me.btnBrowseLogo1.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnBrowseLogo1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnBrowseLogo1.ForeColor = System.Drawing.Color.White
        Me.btnBrowseLogo1.Location = New System.Drawing.Point(1221, 354)
        Me.btnBrowseLogo1.Name = "btnBrowseLogo1"
        Me.btnBrowseLogo1.Size = New System.Drawing.Size(111, 30)
        Me.btnBrowseLogo1.TabIndex = 762
        Me.btnBrowseLogo1.Text = "اختر صورة"
        '
        'picLogo1
        '
        Me.picLogo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLogo1.Location = New System.Drawing.Point(845, 354)
        Me.picLogo1.Name = "picLogo1"
        Me.picLogo1.Size = New System.Drawing.Size(370, 370)
        Me.picLogo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo1.TabIndex = 761
        Me.picLogo1.TabStop = False
        '
        'frmReceiptSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1340, 771)
        Me.Controls.Add(Me.btnSave1)
        Me.Controls.Add(Me.btnClearLogo1)
        Me.Controls.Add(Me.btnBrowseLogo1)
        Me.Controls.Add(Me.picLogo1)
        Me.Controls.Add(Me.strname)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Guna2ToggleSwitch1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Guna2GroupBox2)
        Me.Controls.Add(Me.Guna2GroupBox1)
        Me.Controls.Add(Me.TXTNOTES)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TXTFOOT)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTSUBFOOT)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CheckBoxPrintQty)
        Me.Controls.Add(Me.CheckBoxPrintProduct)
        Me.Controls.Add(Me.CheckBoxPrintPrice)
        Me.Controls.Add(Me.CheckBoxPrintTotal)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClearLogo)
        Me.Controls.Add(Me.btnBrowseLogo)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStoreName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReceiptSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReceiptSettings"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GroupBox1.ResumeLayout(False)
        Me.Guna2GroupBox1.PerformLayout()
        Me.Guna2GroupBox2.ResumeLayout(False)
        Me.Guna2GroupBox2.PerformLayout()
        CType(Me.picLogo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStoreName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAddress As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPhone As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents btnBrowseLogo As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClearLogo As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents CheckBoxPrintTotal As CheckBox
    Friend WithEvents CheckBoxPrintPrice As CheckBox
    Friend WithEvents CheckBoxPrintProduct As CheckBox
    Friend WithEvents CheckBoxPrintQty As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents RadioButtonLBP As RadioButton
    Friend WithEvents RadioButtonUSD As RadioButton
    Friend WithEvents TXTFOOT As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTSUBFOOT As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TXTNOTES As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents RadioButtonout As RadioButton
    Friend WithEvents RadioButtonin As RadioButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Guna2GroupBox1 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Guna2GroupBox2 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Guna2ToggleSwitch1 As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents strname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents btnSave1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClearLogo1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnBrowseLogo1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents picLogo1 As PictureBox
End Class
