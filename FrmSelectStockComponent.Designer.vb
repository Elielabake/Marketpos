<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectStockComponent
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
        Me.dgvStock = New Zuby.ADGV.AdvancedDataGridView()
        Me.txtQty = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnok = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvStock
        '
        Me.dgvStock.AllowUserToAddRows = False
        Me.dgvStock.AllowUserToDeleteRows = False
        Me.dgvStock.AllowUserToResizeColumns = False
        Me.dgvStock.AllowUserToResizeRows = False
        Me.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvStock.BackgroundColor = System.Drawing.Color.White
        Me.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStock.ColumnHeadersHeight = 65
        Me.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStock.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStock.EnableHeadersVisualStyles = False
        Me.dgvStock.FilterAndSortEnabled = True
        Me.dgvStock.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.dgvStock.Location = New System.Drawing.Point(12, 12)
        Me.dgvStock.MaxFilterButtonImageHeight = 23
        Me.dgvStock.Name = "dgvStock"
        Me.dgvStock.ReadOnly = True
        Me.dgvStock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvStock.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStock.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStock.RowHeadersVisible = False
        Me.dgvStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStock.Size = New System.Drawing.Size(308, 391)
        Me.dgvStock.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.dgvStock.TabIndex = 734
        '
        'txtQty
        '
        Me.txtQty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtQty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtQty.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtQty.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtQty.BorderRadius = 10
        Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQty.DefaultText = ""
        Me.txtQty.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtQty.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtQty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQty.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQty.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtQty.FocusedState.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.txtQty.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtQty.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQty.Location = New System.Drawing.Point(328, 21)
        Me.txtQty.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtQty.PlaceholderText = ""
        Me.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtQty.SelectedText = ""
        Me.txtQty.Size = New System.Drawing.Size(134, 26)
        Me.txtQty.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material
        Me.txtQty.TabIndex = 835
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(470, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 22)
        Me.Label4.TabIndex = 836
        Me.Label4.Text = "الكمية"
        '
        'btnok
        '
        Me.btnok.AutoRoundedCorners = True
        Me.btnok.BackColor = System.Drawing.Color.Transparent
        Me.btnok.BorderColor = System.Drawing.Color.White
        Me.btnok.BorderRadius = 14
        Me.btnok.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnok.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnok.ForeColor = System.Drawing.Color.White
        Me.btnok.Location = New System.Drawing.Point(421, 54)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(95, 30)
        Me.btnok.TabIndex = 838
        Me.btnok.Text = "اضافة "
        '
        'FrmSelectStockComponent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(535, 450)
        Me.Controls.Add(Me.btnok)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvStock)
        Me.Name = "FrmSelectStockComponent"
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvStock As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents txtQty As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnok As Guna.UI2.WinForms.Guna2Button
End Class
