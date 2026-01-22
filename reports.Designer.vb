<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reports
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ordertbl1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceTblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Shapes2 = New Guna.UI2.WinForms.Guna2Shapes()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.rtype = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.fromdate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.todate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.maindate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Guna2PictureBox2 = New Guna.UI2.WinForms.Guna2PictureBox()
        CType(Me.ordertbl1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceTblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ordertbl1BindingSource
        '
        Me.ordertbl1BindingSource.DataMember = "ordertbl1"
        '
        'MarketDataSet
        '
        '
        'InvoiceTblBindingSource
        '
        Me.InvoiceTblBindingSource.DataMember = "invoiceTbl"
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
        Me.Guna2Panel1.Size = New System.Drawing.Size(1366, 37)
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
        Me.Label5.Size = New System.Drawing.Size(103, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "ELPOS-التقارير"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1340, 12)
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
        Me.Guna2Shapes2.Size = New System.Drawing.Size(21, 30)
        Me.Guna2Shapes2.TabIndex = 2
        Me.Guna2Shapes2.Text = "Guna2Shapes2"
        Me.Guna2Shapes2.UseTransparentBackground = True
        Me.Guna2Shapes2.Zoom = 70
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2PictureBox2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.rtype)
        Me.Guna2ShadowPanel1.Controls.Add(Me.fromdate)
        Me.Guna2ShadowPanel1.Controls.Add(Me.todate)
        Me.Guna2ShadowPanel1.Controls.Add(Me.maindate)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label10)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Button1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label7)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(3, 32)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(1363, 97)
        Me.Guna2ShadowPanel1.TabIndex = 735
        '
        'rtype
        '
        Me.rtype.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtype.BackColor = System.Drawing.Color.Transparent
        Me.rtype.BorderColor = System.Drawing.Color.Black
        Me.rtype.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.rtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.rtype.FillColor = System.Drawing.Color.WhiteSmoke
        Me.rtype.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rtype.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rtype.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.rtype.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.rtype.IntegralHeight = False
        Me.rtype.ItemHeight = 22
        Me.rtype.Items.AddRange(New Object() {"الفواتير", "الموردين", "فواتير الطلبات", "الطلبات", "المخزون", "المصاريف"})
        Me.rtype.Location = New System.Drawing.Point(914, 11)
        Me.rtype.Name = "rtype"
        Me.rtype.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rtype.Size = New System.Drawing.Size(141, 28)
        Me.rtype.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.rtype.TabIndex = 776
        Me.rtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fromdate
        '
        Me.fromdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fromdate.Checked = True
        Me.fromdate.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fromdate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.fromdate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.fromdate.Location = New System.Drawing.Point(1075, 9)
        Me.fromdate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.fromdate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.fromdate.Name = "fromdate"
        Me.fromdate.Size = New System.Drawing.Size(200, 36)
        Me.fromdate.TabIndex = 775
        Me.fromdate.Value = New Date(2024, 2, 17, 19, 29, 32, 337)
        '
        'todate
        '
        Me.todate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.todate.Checked = True
        Me.todate.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.todate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.todate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.todate.Location = New System.Drawing.Point(1075, 51)
        Me.todate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.todate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.todate.Name = "todate"
        Me.todate.Size = New System.Drawing.Size(200, 36)
        Me.todate.TabIndex = 774
        Me.todate.Value = New Date(2024, 2, 17, 19, 29, 32, 337)
        '
        'maindate
        '
        Me.maindate.Checked = True
        Me.maindate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.maindate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.maindate.Location = New System.Drawing.Point(408, 35)
        Me.maindate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.maindate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.maindate.Name = "maindate"
        Me.maindate.Size = New System.Drawing.Size(97, 36)
        Me.maindate.TabIndex = 773
        Me.maindate.Value = New Date(2024, 2, 17, 19, 29, 32, 337)
        Me.maindate.Visible = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1293, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 22)
        Me.Label10.TabIndex = 741
        Me.Label10.Text = "الى تاريخ"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.AutoRoundedCorners = True
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BorderColor = System.Drawing.Color.White
        Me.Button1.BorderRadius = 14
        Me.Button1.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(935, 51)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 30)
        Me.Button1.TabIndex = 727
        Me.Button1.Text = "اظهار البيانات"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1293, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 22)
        Me.Label7.TabIndex = 711
        Me.Label7.Text = "من تاريخ"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.AutoScroll = True
        ReportDataSource1.Name = "DataSetorders"
        ReportDataSource1.Value = Me.ordertbl1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Market.Reportorders.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(4, 125)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.ServerReport.ReportServerUrl = New System.Uri("", System.UriKind.Relative)
        Me.ReportViewer1.Size = New System.Drawing.Size(1360, 728)
        Me.ReportViewer1.TabIndex = 736
        Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
        '
        'InvoiceTblTableAdapter
        '
        '
        'Guna2PictureBox2
        '
        Me.Guna2PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox2.Image = Global.Market.My.Resources.Resources.Blue_Background_PNG_Artboard_6_07_1
        Me.Guna2PictureBox2.ImageRotate = 0!
        Me.Guna2PictureBox2.Location = New System.Drawing.Point(12, 9)
        Me.Guna2PictureBox2.Name = "Guna2PictureBox2"
        Me.Guna2PictureBox2.Size = New System.Drawing.Size(225, 78)
        Me.Guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox2.TabIndex = 777
        Me.Guna2PictureBox2.TabStop = False
        Me.Guna2PictureBox2.UseTransparentBackground = True
        '
        'reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "reports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "reports"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ordertbl1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceTblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Shapes2 As Guna.UI2.WinForms.Guna2Shapes
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents maindate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label7 As Label
    Friend WithEvents fromdate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents todate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents rtype As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents InvoiceTblBindingSource As BindingSource
    Friend WithEvents Guna2PictureBox2 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents ordertbl1BindingSource As BindingSource
End Class
