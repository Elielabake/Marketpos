Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing.Printing
Imports System.IO
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Guna.UI2.WinForms
Imports Microsoft.Identity.Client.ApiConfig
Public Class orderfrm1
    ' Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SAMITRONICDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Private WithEvents barcodeTimer As New Timer With {.Interval = 150}
    Private isUpdating As Boolean = False
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        maindate.Value = DateTime.Now.AddDays(0)
    End Sub
    Private Sub CustomerDate_ValueChanged(sender As Object, e As EventArgs) Handles maindate.ValueChanged
        Timer1.Start()
    End Sub
    Public Sub fillfromqty()

        con.Open()
        Dim query = "select * from stock where Id=" & Val(idtxt.Text) & " "
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read


            oqty.Text = reader(13).ToString
        End While
        con.Close()

    End Sub
    Public Sub fillqty()
        con.Open()
        Dim query = "SELECT * FROM Ordernew1 WHERE stockID = " & Val(idtxt.Text)
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            While reader.Read()
                newqty.Text = reader(8).ToString() ' Assuming qty is the first column
            End While
        Else
            newqty.Text = 0 ' If no rows exist, set newqty to 0
        End If

        reader.Close()
        con.Close()


    End Sub
    Public Sub filltotcostd()

        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select Sum(profit) from Ordernew1 where ordnum=N'" & label33.Text & "'"
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 0
            totcostd.Text = num
        Else
            num = cmd.ExecuteScalar
            totcostd.Text = num + Val(plus.Text)
        End If
        cmd.Dispose()
        con.Close()
    End Sub
    Public Sub ordnum1()

        Dim num As Integer
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select MAX(ordnum) From ordertbl1"
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 1
            orderfrm2.ordnum.Text = num
        Else
            num = cmd.ExecuteScalar + 1
            orderfrm2.ordnum.Text = num
        End If
        cmd.Dispose()
        con.Close()
    End Sub
    Public Sub filldr()

        con.Open()
        Dim query = "select * from dollarrateTbl "
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            dr.Text = reader(1).ToString
        End While
        con.Close()
    End Sub
    ' ===============================================
    ' Fill product info from stock (respect user edits)
    ' ===============================================
    Private _isFillingFromBarcode As Boolean = False

    Public Sub fillfrombc()
        If _isFillingFromBarcode Then Return ' prevent recursion
        _isFillingFromBarcode = True

        Try
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                con.Open()

                Dim query As String = "SELECT TOP 1 * FROM stock WHERE code = @code OR codej = @code"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@code", bc.Text.Trim())

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            ClearFields()
                            Return
                        End If

                        ' Common fields
                        idtxt.Text = reader(0).ToString()
                        pn.Text = reader(1).ToString()
                        categ.Text = reader(2).ToString()

                        Dim scannedCode As String = bc.Text.Trim()
                        Dim dbCode As String = If(Not IsDBNull(reader("code")), reader("code").ToString(), "")
                        Dim dbCodeJ As String = If(Not IsDBNull(reader("codej")), reader("codej").ToString(), "")

                        ' --- PART 1: codej scanned ---
                        If scannedCode = dbCodeJ Then
                            ' Overwrite with main code
                            bc.Text = dbCode

                            ' Fill fields from codej prices
                            pd.Text = reader("ppricedj").ToString()
                            pl.Text = reader("ppricelj").ToString()
                            qty.Text = If(IsDBNull(reader("qtyj")), "", reader("qtyj").ToString())

                            ' Exit → Part 2 will never run
                            Return
                        End If

                        ' --- PART 2: normal code scanned ---
                        If scannedCode = dbCode Then
                            pd.Text = reader(7).ToString()
                            cd.Text = reader(5).ToString()
                            pl.Text = reader(8).ToString()
                            qty.Text = 1
                        Else
                            ' Neither code matched → clear fields
                            ClearFields()
                        End If
                    End Using
                End Using
            End Using
        Finally
            _isFillingFromBarcode = False
        End Try
    End Sub




    Private Sub ClearFields()
        idtxt.Text = ""
        pn.Text = ""
        categ.Text = ""
        pd.Text = ""
        pl.Text = ""
        cd.Text = ""
        qty.Text = ""
    End Sub


    Public Sub fillfrombcj()

        con.Open()
        Dim query = "select * from stock where code=N'" & bc.Text & "' "
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            idtxt.Text = reader(0).ToString
            pn.Text = reader(1).ToString
            categ.Text = reader(2).ToString
            pd.Text = reader(9).ToString
            cd.Text = reader(5).ToString
        End While
        con.Close()

    End Sub
    Public Sub fillfrompn()
        con.Open()

        ' First attempt: Try to get the most recent item with stock available
        Dim query = "SELECT TOP 1 * FROM stock WHERE pname=N'" & pn.Text & "' AND cat=N'" & categoriesComboBox.Text & "' AND qavailable > 0 "
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            ' Data found with stock > 0
            idtxt.Text = reader(0).ToString
            categ.Text = reader(2).ToString
            pd.Text = reader(7).ToString
            cd.Text = reader(5).ToString
            qty.Text = 1
        Else
            ' No stock available, retry without the qavailable filter
            reader.Close()
            query = "SELECT TOP 1 * FROM stock WHERE pname=N'" & pn.Text & "' AND cat=N'" & categoriesComboBox.Text & "' "
            cmd = New SqlCommand(query, con)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Display data anyway, but warn user
                idtxt.Text = reader(0).ToString
                categ.Text = reader(2).ToString
                pd.Text = reader(7).ToString
                cd.Text = reader(5).ToString
                qty.Text = 1
                '  MessageBox.Show("هذا المنتج غير متوفر حالياً في المخزون (الكمية = 0).", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                ' Still no data found — inform user
                ' MessageBox.Show("لم يتم العثور على المنتج المطلوب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        reader.Close()
        con.Close()

        ' ✅ Recalculate the price if possible
        If IsNumeric(pd.Text) AndAlso IsNumeric(dr.Text) Then
            pl.Text = (Val(pd.Text) * Val(dr.Text)).ToString()
        Else
            pl.Text = ""
        End If
    End Sub

    Public Sub fillfrompnj()
        con.Open()

        ' First attempt: Try to get the most recent item with stock available
        Dim query = "SELECT TOP 1 * FROM stock WHERE pname=N'" & pn.Text & "' AND cat=N'" & categoriesComboBox.Text & "' AND qavailable > 0 "
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            ' Data found with stock > 0
            idtxt.Text = reader(0).ToString
            categ.Text = reader(2).ToString
            pd.Text = reader(10).ToString
            cd.Text = reader(5).ToString
            qty.Text = reader(12).ToString
        Else
            ' No stock available, retry without the qavailable filter
            reader.Close()
            query = "SELECT TOP 1 * FROM stock WHERE pname=N'" & pn.Text & "' AND cat=N'" & categoriesComboBox.Text & "' "
            cmd = New SqlCommand(query, con)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Display data anyway, but warn user
                idtxt.Text = reader(0).ToString
                categ.Text = reader(2).ToString
                pd.Text = reader(10).ToString
                cd.Text = reader(5).ToString
                qty.Text = reader(12).ToString
                '  MessageBox.Show("هذا المنتج غير متوفر حالياً في المخزون (الكمية = 0).", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                ' Still no data found — inform user
                ' MessageBox.Show("لم يتم العثور على المنتج المطلوب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        reader.Close()
        con.Close()

        ' ✅ Recalculate the price if possible
        If IsNumeric(pd.Text) AndAlso IsNumeric(dr.Text) Then
            pl.Text = (Val(pd.Text) * Val(dr.Text)).ToString()
        Else
            pl.Text = ""
        End If
    End Sub

    Public Sub fillcn()

        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select pn from clienttbl where cn=N'" & cn.Text & "'"
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 0
            pnn.Text = num
        Else
            num = cmd.ExecuteScalar
            pnn.Text = num
        End If
        cmd.Dispose()
        con.Close()

    End Sub
    Private Sub SetToolTipsForGunaButtons(container As System.Windows.Forms.Control, toolTip As Guna2HtmlToolTip)
        For Each ctrl As System.Windows.Forms.Control In container.Controls
            ' Check if the control is a container.
            If TypeOf ctrl Is System.Windows.Forms.Control Then
                ' If it's a container, call the method recursively.
                SetToolTipsForGunaButtons(ctrl, toolTip)
            End If

            ' Check if the control is a Guna2Button.
            If TypeOf ctrl Is Guna2Button Then
                ' Set tooltip for the Guna2Button.
                toolTip.SetToolTip(ctrl, CType(ctrl, Guna2Button).Text)
            End If
        Next
    End Sub
    Private Function FetchDataFromSource() As Object
        ' Implement data fetching logic here
        Return New Object() ' Return some example data
    End Function
    Private WithEvents itemMenu As New ContextMenuStrip()

    Public Sub orderfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.ordernew1' table. You can move, or remove it, as needed.
        Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)


        'TODO: This line of code loads data into the 'MarketDataSet.Ordernew1' table. You can move, or remove it, as needed.
        Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)

        ' Initialize the FlowLayoutPanel container
        flowLayoutPanelContainer = New Panel() With {
    .Name = "flowLayoutPanelContainer",
      .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right, ' Anchors to all sides
    .AutoScroll = False,
    .BackColor = Color.White,
    .BorderStyle = BorderStyle.FixedSingle
}

        ' Set its size and location based on the positions of other controls
        Dim guna2Panel2Bottom As Integer = Guna2Panel2.Bottom + 50 ' Get the bottom position of guna2Panel2
        Dim orderDGV1Right As Integer = orderDGV1.Right + 6 ' Get the right position of orderDGV1
        Dim formWidth As Integer = Guna2Panel2.Width ' Get the width of the form (orderfrm1)
        Dim orderDGV1Height As Integer = orderDGV1.Height ' Get the height of orderDGV1

        ' Adjust the location to start after orderDGV1 and end at the right margin of the form
        flowLayoutPanelContainer.Location = New Point(orderDGV1Right, guna2Panel2Bottom) ' Place it to the right of orderDGV1 and below guna2Panel2
        flowLayoutPanelContainer.Size = New Size(formWidth, orderDGV1Height - 48) ' Set the width to fill the space between orderDGV1 and the right edge of the form

        ' Add the flowLayoutPanelContainer to the form and bring it to the front
        Me.Controls.Add(flowLayoutPanelContainer)
        flowLayoutPanelContainer.BringToFront()



        FillCategories()
        AssignContextMenuToExistingButtons()
        Dim cachedData = Class1.GetDataFromCache("Class1")

        If cachedData IsNot Nothing Then
            ' Use cached data
            ' For example, display it in a DataGridView or populate controls


            Dim toolTip1 As New Guna2HtmlToolTip()

            ' Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000
            toolTip1.InitialDelay = 1000
            toolTip1.ReshowDelay = 500

            ' Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = True

            ' Set tooltips for all Guna2Button controls.
            SetToolTipsForGunaButtons(Me, toolTip1)
            bc.Focus()
            'TODO: This line of code loads data into the 'MarketDataSet.Ordernew1' table. You can move, or remove it, as needed.
            Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
            ordnum1()
            emp.Text = Form1.Label7.Text
            'TODO: This line of code loads data into the 'MarketDataSet.Ordernew1' table. You can move, or remove it, as needed.
            Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
            '    allorders.Ordertbl1TableAdapter.Fill(allorders.MarketDataSet.ordertbl1)

            filldr()
            UpdateplValues()
            UpdateTotdValues()
            UpdateTotdValues1()
            tot1()
            allorders.allorders_Load(e, e)
            con.Open()
            Dim cmd As New SqlCommand("SELECT code FROM stock", con)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("code").ToString())
            Next
            bc.AutoCompleteSource = AutoCompleteSource.CustomSource
            bc.AutoCompleteCustomSource = col
            bc.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
            con.Open()
            Dim cmd1 As New SqlCommand("SELECT cn FROM clienttbl", con)
            Dim ds1 As New DataSet
            Dim da1 As New SqlDataAdapter(cmd1)
            da1.Fill(ds1, "list")
            Dim col1 As New AutoCompleteStringCollection
            Dim i1 As Integer
            For i1 = 0 To ds1.Tables(0).Rows.Count - 1
                col1.Add(ds1.Tables(0).Rows(i1)("cn").ToString())
            Next
            cn.AutoCompleteSource = AutoCompleteSource.CustomSource
            cn.AutoCompleteCustomSource = col1
            cn.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
            con.Open()
            Dim cmd2 As New SqlCommand("SELECT pname FROM stock", con)
            Dim ds2 As New DataSet
            Dim da2 As New SqlDataAdapter(cmd2)
            da2.Fill(ds2, "list")
            Dim col2 As New AutoCompleteStringCollection
            Dim i2 As Integer
            For i2 = 0 To ds2.Tables(0).Rows.Count - 1
                col2.Add(ds2.Tables(0).Rows(i2)("pname").ToString())
            Next
            pn.AutoCompleteSource = AutoCompleteSource.CustomSource
            pn.AutoCompleteCustomSource = col
            pn.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
            discount.Text = "0"
            filltotcostd()
            fillfromqty()
            fillqty()
            AcceptButton = Button1
            bc.Focus()
            totl.Text = Math.Round(Val(totd.Text) * Val(dr.Text))

        Else
            ' Fetch data from source
            Dim data = FetchDataFromSource()

            ' Add data to cache
            Class1.AddDataToCache("Class1", data, TimeSpan.FromMinutes(10))

            ' Use fetched data
            ' For example, display it in a DataGridView or populate controls

            Dim toolTip1 As New Guna2HtmlToolTip()

            ' Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000
            toolTip1.InitialDelay = 1000
            toolTip1.ReshowDelay = 500

            ' Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = True

            ' Set tooltips for all Guna2Button controls.
            SetToolTipsForGunaButtons(Me, toolTip1)
            bc.Focus()
            'TODO: This line of code loads data into the 'MarketDataSet.Ordernew1' table. You can move, or remove it, as needed.
            Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
            ordnum1()
            emp.Text = Form1.Label7.Text
            'TODO: This line of code loads data into the 'MarketDataSet.Ordernew1' table. You can move, or remove it, as needed.
            Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
            ' allorders.Ordertbl1TableAdapter.Fill(allorders.MarketDataSet.ordertbl1)

            filldr()
            UpdateplValues()
            UpdateTotdValues()
            UpdateTotdValues1()
            tot1()
            allorders.allorders_Load(e, e)
            con.Open()
            Dim cmd As New SqlCommand("SELECT code FROM stock", con)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("code").ToString())
            Next
            bc.AutoCompleteSource = AutoCompleteSource.CustomSource
            bc.AutoCompleteCustomSource = col
            bc.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
            con.Open()
            Dim cmd1 As New SqlCommand("SELECT cn FROM clienttbl", con)
            Dim ds1 As New DataSet
            Dim da1 As New SqlDataAdapter(cmd1)
            da1.Fill(ds1, "list")
            Dim col1 As New AutoCompleteStringCollection
            Dim i1 As Integer
            For i1 = 0 To ds1.Tables(0).Rows.Count - 1
                col1.Add(ds1.Tables(0).Rows(i1)("cn").ToString())
            Next
            cn.AutoCompleteSource = AutoCompleteSource.CustomSource
            cn.AutoCompleteCustomSource = col1
            cn.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
            con.Open()
            Dim cmd2 As New SqlCommand("SELECT pname FROM stock", con)
            Dim ds2 As New DataSet
            Dim da2 As New SqlDataAdapter(cmd2)
            da2.Fill(ds2, "list")
            Dim col2 As New AutoCompleteStringCollection
            Dim i2 As Integer
            For i2 = 0 To ds2.Tables(0).Rows.Count - 1
                col2.Add(ds2.Tables(0).Rows(i2)("pname").ToString())
            Next
            pn.AutoCompleteSource = AutoCompleteSource.CustomSource
            pn.AutoCompleteCustomSource = col
            pn.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
            discount.Text = "0"
            filltotcostd()
            fillfromqty()
            fillqty()
            AcceptButton = Button1
            bc.Focus()
            totl.Text = Math.Round(Val(totd.Text) * Val(dr.Text))


        End If
        Dim savedValue1 As String = My.Settings.orderdisc
        percentd.Text = savedValue1

        If Loginpage.rtype.Text = "ثانوي" Then

            Guna2Button7.Enabled = False
            percentd.Enabled = False
            discount1.Enabled = False

        End If
        qty.Text = "1"
        orderDGV1.Columns(12).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        ' Set the DataGridView to automatically resize rows based on cell content
        orderDGV1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        FillCategories()
        wasil.Text = Val(totd.Text)
        credit.Text = Val(totd.Text)
        ' CheckIfDataGridViewIsEmpty()
        AddHandler orderDGV1.RowsAdded, AddressOf UpdateRowCount
        AddHandler orderDGV1.RowsRemoved, AddressOf UpdateRowCount
        AddHandler orderDGV1.DataSourceChanged, AddressOf UpdateRowCount
        AddHandler orderDGV1.CellValueChanged, AddressOf UpdateRowCount
        AddHandler orderDGV1.UserDeletedRow, AddressOf UpdateRowCount
        AddHandler orderDGV1.UserAddedRow, AddressOf UpdateRowCount
        orderDGV1.Refresh()

        If orderDGV1.Rows.Count > 0 Then
            ' Scroll to the last row
            orderDGV1.FirstDisplayedScrollingRowIndex = orderDGV1.Rows.Count - 1
            ' Optionally select the last row
            orderDGV1.Rows(orderDGV1.Rows.Count - 1).Selected = True
        End If
        itemMenu.Items.Add("مفرق")
        itemMenu.Items.Add("جملة")
    End Sub
    Private Sub UpdateRowCount(sender As Object, e As EventArgs)
        Dim count As Integer = orderDGV1.Rows.Count
        If orderDGV1.AllowUserToAddRows Then count -= 1
        Guna2TextBox1.Text = count.ToString()
    End Sub


    Private Sub discount1_TextChanged(sender As Object, e As EventArgs) Handles discount1.TextChanged
        discount.Text = Val(discount1.Text) / Val(dr.Text)
    End Sub

    ' ===============================================
    ' TextChanged (barcode) — start/stop the timer
    ' ===============================================
    Private _isProcessingBarcode As Boolean = False

    Private Sub bc_TextChanged(sender As Object, e As EventArgs) Handles bc.TextChanged
        If _isProcessingBarcode Then Return ' ignore programmatic changes

        barcodeTimer.Stop()

        If bc.Text.Trim() = "" Then
            ' Reset fields
            pn.Text = ""
            categ.Text = ""
            pd.Text = ""
            pl.Text = ""
            qty.Text = "1"
            cd.Text = ""
        Else
            barcodeTimer.Start()
        End If
    End Sub

    Private Sub barcodeTimer_Tick(sender As Object, e As EventArgs) Handles barcodeTimer.Tick
        barcodeTimer.Stop()
        If bc.Text.Trim() <> "" Then
            ProcessBarcode(bc.Text.Trim())
        End If
    End Sub

    Private Sub ProcessBarcode(barcode As String)
        If _isProcessingBarcode Then Return
        _isProcessingBarcode = True
        Try
            If barcode.Length = 13 AndAlso barcode.StartsWith("27") Then
                RetrieveQty()
            End If

            ' fillfrombc() will not overwrite manually edited fields (because of .Modified checks)
            fillfrombc()
            fillfromqty()
            fillqty()
        Finally
            _isProcessingBarcode = False
        End Try
    End Sub

    Private Sub RetrieveQty()
        Dim barcode As String = bc.Text.Trim()
        ' Check if the barcode has been fully scanned (length = 13)
        If barcode.Length = 13 Then
            ' Regular expression pattern to match a barcode starting with "27" and having exactly 13 digits
            Dim pattern As String = "^27\d{11}$"

            ' Check if the barcode matches the pattern
            If Regex.IsMatch(barcode, pattern) Then
                ' Extract the digits excluding the last one
                Dim digits As String = barcode.Substring(7, 5)

                ' Convert the digits to a decimal value
                Dim qtyDecimal As Decimal = Decimal.Parse(digits)

                ' Shift the decimal point three positions to the left
                qtyDecimal /= 1000

                ' Display the decimal value in qtyTextBox
                qty.Text = qtyDecimal.ToString("0.000")
                fillfrombc()
            Else
                ' Barcode doesn't meet the criteria
                MessageBox.Show("Barcode does not start with '27' or does not have 13 digits.")
            End If
        End If

    End Sub

    Private Sub pn_TextChanged(sender As Object, e As EventArgs) Handles pn.TextChanged

        If bc.Text = "" Then




            If pn.Text = "" Then

                categ.Text = ""
                pd.Text = ""
                pl.Text = ""
                qty.Text = "1"
                cd.Text = ""

            Else
                fillfrompn()
                fillfromqty()
                fillqty()

            End If
        Else
        End If

    End Sub

    Private Sub cn_TextChanged(sender As Object, e As EventArgs) Handles cn.TextChanged
        On Error Resume Next
        If cn.Text = "" Then
            pnn.Text = ""
            '  Guna2Button3.Enabled = False

        Else
            fillcn()
            ' Guna2Button3.Enabled = True

        End If
    End Sub
    Public Sub button1clickreverse()
        '    On Error Resume Next

        Dim i As Decimal = Val(CDbl(qty.Text)) * Val(CDbl(pd.Text))
        Dim ii As Decimal = Val(CDbl(qty.Text)) * Val(CDbl(cd.Text))

        Try
            con.Open()

            ' Check if bc exists
            Dim cmdCheck As New SqlCommand("SELECT SUM(qty) FROM ordernew1 WHERE bc=N'" & bc.Text & "'", con)
            Dim exists As Boolean = Not IsDBNull(cmdCheck.ExecuteScalar)

            If Not exists Then
                ' INSERT new reverse row
                Dim newRow As DataRow = MARKETDataSet.ordernew1.NewRow()
                newRow("stockID") = idtxt.Text
                newRow("bc") = bc.Text
                newRow("pn") = pn.Text
                newRow("categ") = categ.Text
                newRow("dr") = Val(dr.Text)
                newRow("pd") = -Val(pd.Text)
                newRow("pl") = -Val(pl.Text)
                newRow("qty") = Val(qty.Text)
                newRow("totd") = -(Val(qty.Text) * Val(pd.Text))
                newRow("totl") = -(Val(dr.Text) * Val(pd.Text))
                newRow("ordnum") = orderfrm2.ordnum.Text
                newRow("costd") = -Val(cd.Text)
                newRow("profit") = -(i - ii)
                newRow("emp") = emp.Text
                newRow("date") = maindate.Value

                MARKETDataSet.ordernew1.Rows.Add(newRow)
                orderDGV1.Refresh()
                Me.Validate()
                Me.Ordernew1BindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

                ' Log REVERSE INSERT using parameters
                Dim logCmd As New SqlCommand("
                INSERT INTO orderTransactions
                (actionType, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
                VALUES
                ('REVERSE_INSERT', @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp, @date)
            ", con)

                logCmd.Parameters.AddWithValue("@stockID", idtxt.Text)
                logCmd.Parameters.AddWithValue("@bc", bc.Text)
                logCmd.Parameters.AddWithValue("@pn", pn.Text)
                logCmd.Parameters.AddWithValue("@categ", categ.Text)
                logCmd.Parameters.AddWithValue("@dr", Val(dr.Text))
                logCmd.Parameters.AddWithValue("@pd", -Val(pd.Text))
                logCmd.Parameters.AddWithValue("@pl", -Val(pl.Text))
                logCmd.Parameters.AddWithValue("@qty", Val(qty.Text))
                logCmd.Parameters.AddWithValue("@totd", -(Val(qty.Text) * Val(pd.Text)))
                logCmd.Parameters.AddWithValue("@totl", -(Val(dr.Text) * Val(pd.Text)))
                logCmd.Parameters.AddWithValue("@ordnum", orderfrm2.ordnum.Text)
                logCmd.Parameters.AddWithValue("@costd", -Val(cd.Text))
                logCmd.Parameters.AddWithValue("@profit", -(i - ii))
                logCmd.Parameters.AddWithValue("@emp", emp.Text)
                logCmd.Parameters.AddWithValue("@date", maindate.Value)
                logCmd.ExecuteNonQuery()

            Else
                ' UPDATE existing qty
                Dim oldQty As Integer = Convert.ToInt32(New SqlCommand("SELECT qty FROM ordernew1 WHERE bc=N'" & bc.Text & "'", con).ExecuteScalar())
                Dim updateCmd As New SqlCommand("UPDATE ordernew1 SET qty=qty + " & qty.Text & " WHERE bc=N'" & bc.Text & "'", con)
                updateCmd.ExecuteNonQuery()

                Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
                Me.Validate()
                Me.Ordernew1BindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

                ' Log REVERSE UPDATE using parameters
                Dim updatedRow As DataRow = MARKETDataSet.ordernew1.Select("bc='" & bc.Text & "'")(0)
                Dim logCmd As New SqlCommand("
                INSERT INTO orderTransactions
                (actionType, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
                VALUES
                ('REVERSE_UPDATE', @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp, @date)
            ", con)

                logCmd.Parameters.AddWithValue("@stockID", updatedRow("stockID"))
                logCmd.Parameters.AddWithValue("@bc", updatedRow("bc"))
                logCmd.Parameters.AddWithValue("@pn", updatedRow("pn"))
                logCmd.Parameters.AddWithValue("@categ", updatedRow("categ"))
                logCmd.Parameters.AddWithValue("@dr", updatedRow("dr"))
                logCmd.Parameters.AddWithValue("@pd", updatedRow("pd"))
                logCmd.Parameters.AddWithValue("@pl", updatedRow("pl"))
                logCmd.Parameters.AddWithValue("@qty", updatedRow("qty"))
                logCmd.Parameters.AddWithValue("@totd", updatedRow("totd"))
                logCmd.Parameters.AddWithValue("@totl", updatedRow("totl"))
                logCmd.Parameters.AddWithValue("@ordnum", updatedRow("ordnum"))
                logCmd.Parameters.AddWithValue("@costd", updatedRow("costd"))
                logCmd.Parameters.AddWithValue("@profit", updatedRow("profit"))
                logCmd.Parameters.AddWithValue("@emp", updatedRow("emp"))
                logCmd.Parameters.AddWithValue("@date", updatedRow("date"))
                logCmd.ExecuteNonQuery()

                Dim newQty As Integer = Convert.ToInt32(New SqlCommand("SELECT qty FROM ordernew1 WHERE bc=N'" & bc.Text & "'", con).ExecuteScalar())
                Console.WriteLine("REVERSE Qty changed from " & oldQty & " → " & newQty)
            End If

        Catch ex As Exception
            MessageBox.Show("Error in button1clickreverse: " & ex.Message)
        Finally
            con.Close()
            bc.Text = ""
            tot1()
            UpdateplValues()
            UpdateTotdValues()
            UpdateTotdValues1()
            tot1()
            filltotcostd()
            fillfromqty()
            fillqty()
            bc.Focus()
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(bc.Text) Then
            ' No barcode → normal button2 logic
            If print2.Checked Then
                button2clickreverse()
            Else
                button2click()
            End If
        Else
            ' IMPORTANT: do NOT re-run ProcessBarcode if we already have product info or if user edited fields.
            ' Only refresh if product info is missing.
            If String.IsNullOrWhiteSpace(pn.Text) OrElse String.IsNullOrWhiteSpace(idtxt.Text) Then
                ProcessBarcode(bc.Text.Trim())
            End If

            ' Prevent adding empty row
            If String.IsNullOrWhiteSpace(pn.Text) OrElse String.IsNullOrWhiteSpace(idtxt.Text) Then
                MessageBox.Show("⚠️ الباركود غير متوفر في المخزون.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bc.Text = ""
                pn.Text = ""
                Exit Sub
            End If

            ' Add product row
            If print2.Checked Then
                button1clickreverse()
            Else
                button1click()
            End If
        End If

        bc.Focus()
        pn.Text = ""
        ' After adding/updating rows and refreshing the DataGridView
        orderDGV1.Refresh()

        If orderDGV1.Rows.Count > 0 Then
            ' Scroll to the last row
            orderDGV1.FirstDisplayedScrollingRowIndex = orderDGV1.Rows.Count - 1
            ' Optionally select the last row
            orderDGV1.Rows(orderDGV1.Rows.Count - 1).Selected = True
        End If

    End Sub

    ' ===============================================
    ' Insert/Update order — respect manual PL or PD
    ' ===============================================
    Public Sub button1click()
        ' 🔒 Safety guard → no insert if empty
        If String.IsNullOrWhiteSpace(bc.Text) OrElse String.IsNullOrWhiteSpace(pn.Text) OrElse String.IsNullOrWhiteSpace(idtxt.Text) Then
            Exit Sub
        End If

        ' First determine final PD and PL values based on user edits (Modified flags)
        Dim pdValue As Double = 0
        Dim plValue As Double = 0
        Dim drValue As Double = If(IsNumeric(dr.Text), Val(dr.Text), 0)

        If pl.Modified AndAlso IsNumeric(pl.Text) AndAlso drValue <> 0 Then
            ' User typed PL -> compute PD from PL/DR
            plValue = Val(pl.Text)
            pdValue = plValue / drValue
        ElseIf pd.Modified AndAlso IsNumeric(pd.Text) Then
            ' User typed PD -> compute PL from PD*DR
            pdValue = Val(pd.Text)
            plValue = pdValue * drValue
        Else
            ' Default fallback -> use what's in PD textbox (likely from stock)
            pdValue = If(IsNumeric(pd.Text), Val(pd.Text), 0)
            plValue = pdValue * drValue
        End If

        ' Now compute totals using pdValue
        Dim qtyValue As Double = If(IsNumeric(qty.Text), Val(qty.Text), 1)
        Dim costdValue As Double = If(IsNumeric(cd.Text), Val(cd.Text), 0)

        Dim i As Double = qtyValue * pdValue            ' totd
        Dim ii As Double = qtyValue * costdValue        ' for profit calc

        Dim cmd02 As New SqlCommand
        cmd02.Connection = con
        con.Open()

        cmd02.CommandText = "SELECT SUM(qty) FROM Ordernew1 WHERE bc=N'" & bc.Text & "'"
        Dim exists As Boolean = Not IsDBNull(cmd02.ExecuteScalar)

        If Not exists Then
            ' INSERT new row
            Dim newRow As DataRow = MARKETDataSet.ordernew1.NewRow()
            newRow("stockID") = idtxt.Text
            newRow("bc") = bc.Text
            newRow("pn") = pn.Text
            newRow("categ") = categ.Text
            newRow("dr") = drValue
            newRow("pd") = pdValue
            newRow("pl") = CInt(Math.Round(plValue, 0, MidpointRounding.AwayFromZero))
            newRow("qty") = qtyValue
            newRow("totd") = i
            newRow("totl") = drValue * pdValue
            newRow("ordnum") = orderfrm2.ordnum.Text
            newRow("costd") = costdValue
            newRow("profit") = i - ii
            newRow("emp") = emp.Text
            newRow("date") = FormatDateTime(maindate.Value)

            Me.MARKETDataSet.ordernew1.Rows.Add(newRow)
            orderDGV1.Refresh()
            Me.Validate()
            Me.Ordernew1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' Log INSERT with correct pd/pl values
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions 
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
            VALUES ('INSERT', @Id, @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp, @date)", con)

            logCmd.Parameters.AddWithValue("@Id", newRow("stockID"))
            logCmd.Parameters.AddWithValue("@stockID", newRow("stockID"))
            logCmd.Parameters.AddWithValue("@bc", bc.Text)
            logCmd.Parameters.AddWithValue("@pn", pn.Text)
            logCmd.Parameters.AddWithValue("@categ", categ.Text)
            logCmd.Parameters.AddWithValue("@dr", drValue)
            logCmd.Parameters.AddWithValue("@pd", pdValue)
            logCmd.Parameters.AddWithValue("@pl", plValue)
            logCmd.Parameters.AddWithValue("@qty", qtyValue)
            logCmd.Parameters.AddWithValue("@totd", i)
            logCmd.Parameters.AddWithValue("@totl", drValue * pdValue)
            logCmd.Parameters.AddWithValue("@ordnum", orderfrm2.ordnum.Text)
            logCmd.Parameters.AddWithValue("@costd", costdValue)
            logCmd.Parameters.AddWithValue("@profit", i - ii)
            logCmd.Parameters.AddWithValue("@emp", emp.Text)
            logCmd.Parameters.AddWithValue("@date", FormatDateTime(maindate.Value))
            logCmd.ExecuteNonQuery()

        Else
            ' UPDATE existing qty
            Dim query As String = "UPDATE Ordernew1 SET qty = qty + " & qtyValue & " WHERE bc=N'" & bc.Text & "'"
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()

            Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
            Me.Validate()
            Me.Ordernew1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' Log UPDATE (copy the current row)
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions 
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
            SELECT 'UPDATE', Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date]
            FROM ordernew WHERE bc=N'" & bc.Text & "'", con)
            logCmd.ExecuteNonQuery()
        End If

        con.Close()

        ' Reset after insert/update
        bc.Text = ""
        tot1()
        UpdateplValues()
        UpdateTotdValues()
        UpdateTotdValues1()
        tot1()
        filltotcostd()
        fillfromqty()
        fillqty()
        bc.Focus()
    End Sub
    Private Sub dr_TextChanged(sender As Object, e As EventArgs) Handles dr.TextChanged
        pl.Text = Val(pd.Text) * Val(dr.Text)
        cash1.Text = Val(credit.Text) * Val(dr.Text)
        debit1.Text = Val(debit.Text) * Val(dr.Text)
    End Sub




    Public Sub UpdateStock()
        Dim con As New SqlConnection(My.Settings.MARKETDBConnectionString)

        Try
            ' Open the connection
            con.Open()

            ' Update stock except when cat is "الخضار"
            Dim updateByCodeQuery As String = "
    UPDATE stock
    SET 
        qsold = qsold - o.qty,
        qavailable = qavailable + o.qty
    FROM [SALIMDB].[dbo].[stock] stock
    INNER JOIN [SALIMDB].[dbo].[ordernew1] o
        ON stock.Id = o.stockID
    WHERE o.stockID <> '' 
    "

            Dim updateByCodeCmd As New SqlCommand(updateByCodeQuery, con)
            updateByCodeCmd.ExecuteNonQuery()
            updateByCodeCmd.Dispose()

        Catch ex As Exception
            ' Handle exceptions here
            MessageBox.Show("An error occurred: " & ex.Message)

        Finally
            ' Ensure that the connection is always closed
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try

    End Sub

    Sub UpdateStock1()
        Dim con As New SqlConnection(My.Settings.MARKETDBConnectionString)

        Try
            ' Open the connection
            con.Open()

            ' Update stock except when cat is "الخضار"
            Dim updateByCodeQuery As String = "
    UPDATE stock
    SET 
        qsold = qsold + o.qty,
        qavailable = qavailable - o.qty
    FROM [SALIMDB].[dbo].[stock] stock
    INNER JOIN [SALIMDB].[dbo].[ordernew1] o
        ON stock.Id = o.stockID
    WHERE o.stockID <> ''
    "

            Dim updateByCodeCmd As New SqlCommand(updateByCodeQuery, con)
            updateByCodeCmd.ExecuteNonQuery()
            updateByCodeCmd.Dispose()

        Catch ex As Exception
            ' Handle exceptions here
            MessageBox.Show("An error occurred: " & ex.Message)

        Finally
            ' Ensure that the connection is always closed
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try

    End Sub



    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click

        'CashDrawerHelper.OpenCashDrawer()
        DetectDefaultPrinter()
        cashdr()
        changelongpaper()
        'PPD1.Document = PDd1
        'PPD1.ShowDialog()
        ' Direct Print
        PDd1.Print()

    End Sub
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click

        Dim ordnumfill As Integer = If(Integer.TryParse(label33.Text, ordnumfill), ordnumfill, 0)

        If debit.Text = "0" Or debit.Text = "" Then
            ' Check if `cn` exists in `clienttbl`
            con.Open()

            Dim checkQuery As String = "SELECT COUNT(*) FROM clienttbl WHERE cn = @cn"
            Using checkCmd As New SqlCommand(checkQuery, con)
                checkCmd.Parameters.AddWithValue("@cn", cn.Text)
                Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If count = 0 Then
                    Dim newRow2 As DataRow = clientsfrm.MARKETDataSet.clienttbl.NewRow()
                    newRow2("cn") = cn.Text
                    newRow2("pn") = pnn.Text

                    ' Add the new row to the DataTable
                    clientsfrm.MARKETDataSet.clienttbl.Rows.Add(newRow2)

                    ' Save changes to the database
                    clientsfrm.Validate()
                    clientsfrm.ClienttblBindingSource.EndEdit()
                    clientsfrm.TableAdapterManager.UpdateAll(clientsfrm.MARKETDataSet)
                    clientsfrm.ClienttblTableAdapter.Fill(clientsfrm.MARKETDataSet.clienttbl)
                End If
                con.Close()
            End Using
            If con.State = ConnectionState.Closed Then
                con.Open() ' Open the connection if it's not already open
            End If

            Try
                ' Create a command to calculate the sum of profit from the Ordernew1 table
                Dim query As String = "SELECT ISNULL(SUM(profit), 0) FROM Ordernew1"
                Dim command As New SqlCommand(query, con)

                ' Execute the query and retrieve the sum of profits
                Dim totalProfit As Decimal = Convert.ToDecimal(command.ExecuteScalar())

                ' Now prepare to add a new row to ordertbl1
                Dim newRow1 As DataRow = allorders.MARKETDataSet.ordertbl1.NewRow()
                newRow1("ordnum") = orderfrm2.ordnum.Text
                newRow1("emp") = emp.Text
                newRow1("dr") = Val(dr.Text)
                newRow1("totd") = totd.Text ' Ensure correct type conversion if needed
                newRow1("totl") = totl.Text
                newRow1("discount") = discount.Text

                ' Replace totcostd.Text with the sum of profits from Ordernew1
                newRow1("profit") = Math.Max(0, Val(totalProfit) - Val(discount.Text))

                newRow1("credit") = credit.Text
                newRow1("debit") = debit.Text
                newRow1("cn") = cn.Text
                newRow1("pn") = pnn.Text

                newRow1("date") = FormatDateTime(maindate.Value)

                ' Add the new row to the DataTable
                allorders.MARKETDataSet.ordertbl1.Rows.Add(newRow1)

                ' Save the changes to the database if necessary
                allorders.Validate()
                allorders.Ordertbl1BindingSource.EndEdit()
                allorders.TableAdapterManager1.UpdateAll(allorders.MARKETDataSet)
                allorders.OrderstblTableAdapter.InsertQuery2(ordnumfill)
                '  allorders.Ordertbl1TableAdapter.Fill(allorders.MarketDataSet.ordertbl1)



            Finally
                ' Ensure that the connection is closed when done
                If con.State = ConnectionState.Open Then
                    con.Close() ' Close the connection
                End If
            End Try
            ' Based on whether `bc` is empty, choose the appropriate query logic
            If print2.Checked = True Then
                UpdateStock()
            Else
                UpdateStock1()
            End If

            ' Clean up
            Me.Ordernew1TableAdapter.DeleteQuery1()
            ' Refresh the DataGridView
            totd.Text = "0"
            totl.Text = "0"
            totcostd.Text = "0"
            Me.Ordernew1TableAdapter.DeleteQuery1()
            Me.Validate()
            Me.Ordernew1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
            Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
            orderDGV1.Refresh()
            tot1()
            filltotcostd()
            allorders.allorders_Load(e, e)

            cn.Text = ""
            discheck.Checked = False
            discount1.Text = "0"
            print2.Checked = False
            ord.Text = ""
            stock.StockTableAdapter.Fill(stock.MARKETDataSet.stock)

            discd.Text = "0"
            bc.Focus()
            allorders.allordersDGV.Refresh()
            allorders.ordnum1()
        ElseIf debit.Text IsNot Nothing Then
            ' Check if `cn` exists in `clienttbl`
            con.Open()

            Dim checkQuery As String = "SELECT COUNT(*) FROM clienttbl WHERE cn = @cn"
            Using checkCmd As New SqlCommand(checkQuery, con)
                checkCmd.Parameters.AddWithValue("@cn", cn.Text)
                Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If count = 0 Then
                    Dim newRow2 As DataRow = clientsfrm.MARKETDataSet.clienttbl.NewRow()
                    newRow2("cn") = cn.Text
                    newRow2("pn") = pnn.Text

                    ' Add the new row to the DataTable
                    clientsfrm.MARKETDataSet.clienttbl.Rows.Add(newRow2)

                    ' Save changes to the database
                    clientsfrm.Validate()
                    clientsfrm.ClienttblBindingSource.EndEdit()
                    clientsfrm.TableAdapterManager.UpdateAll(clientsfrm.MARKETDataSet)
                    clientsfrm.ClienttblTableAdapter.Fill(clientsfrm.MARKETDataSet.clienttbl)
                End If
                con.Close()
            End Using
            ' Ensure that the connection is properly opened and closed
            If con.State = ConnectionState.Closed Then
                con.Open() ' Open the connection if it's not already open
            End If

            Try
                ' Create a command to calculate the sum of profit from the Ordernew1 table
                Dim query As String = "SELECT ISNULL(SUM(profit), 0) FROM Ordernew1"
                Dim command As New SqlCommand(query, con)

                ' Execute the query and retrieve the sum of profits
                Dim totalProfit As Decimal = Convert.ToDecimal(command.ExecuteScalar())

                ' Now prepare to add a new row to ordertbl1
                Dim newRow1 As DataRow = allorders.MARKETDataSet.ordertbl1.NewRow()
                newRow1("ordnum") = orderfrm2.ordnum.Text
                newRow1("emp") = emp.Text
                newRow1("dr") = Val(dr.Text)
                newRow1("totd") = totd.Text ' Ensure correct type conversion if needed
                newRow1("totl") = totl.Text
                newRow1("discount") = discount.Text

                ' Replace totcostd.Text with the sum of profits from Ordernew1
                newRow1("profit") = Math.Max(0, Val(totalProfit) - Val(discount.Text))

                newRow1("credit") = credit.Text
                newRow1("debit") = debit.Text
                newRow1("cn") = cn.Text
                newRow1("pn") = pnn.Text

                newRow1("date") = FormatDateTime(maindate.Value)

                ' Add the new row to the DataTable
                allorders.MARKETDataSet.ordertbl1.Rows.Add(newRow1)

                ' Save the changes to the database if necessary
                allorders.Validate()
                allorders.Ordertbl1BindingSource.EndEdit()
                allorders.TableAdapterManager1.UpdateAll(allorders.MARKETDataSet)
                allorders.OrderstblTableAdapter.InsertQuery2(ordnumfill)
                '  allorders.Ordertbl1TableAdapter.Fill(allorders.MarketDataSet.ordertbl1)



            Finally
                ' Ensure that the connection is closed when done
                If con.State = ConnectionState.Open Then
                    con.Close() ' Close the connection
                End If
            End Try

            ' Based on whether bc is empty, choose the appropriate query logic
            If print2.Checked = True Then
                UpdateStock()
            Else
                UpdateStock1()
            End If

            debitsfrm.DebitTblTableAdapter.Fill(debitsfrm.MARKETDataSet.debitTbl)
            Dim newRow3 As DataRow = debitsfrm.MARKETDataSet.debitTbl.NewRow()

            newRow3("sname") = cn.Text
            newRow3("debits") = debit.Text
            newRow3("credits") = "0"
            newRow3("date") = FormatDateTime(maindate.Value)
            ' Add the new row to the DataTable
            debitsfrm.MARKETDataSet.debitTbl.Rows.Add(newRow3)

            ' Refresh the DataGridView to reflect the changes
            debitsfrm.debitDGV.Refresh()
            debitsfrm.Validate()
            debitsfrm.DebitTblBindingSource.EndEdit()
            debitsfrm.TableAdapterManager.UpdateAll(debitsfrm.MARKETDataSet)
            Me.Ordernew1TableAdapter.DeleteQuery1()
            ' Refresh the DataGridView
            totd.Text = "0"
            totl.Text = "0"
            totcostd.Text = "0"
            Me.Ordernew1TableAdapter.DeleteQuery1()
            Me.Validate()
            Me.Ordernew1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
            Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
            orderDGV1.Refresh()
            tot1()
            filltotcostd()
            allorders.allorders_Load(e, e)
            cn.Text = ""
            discheck.Checked = False
            discount1.Text = "0"
            print2.Checked = False
            ord.Text = ""
            stock.StockTableAdapter.Fill(stock.MARKETDataSet.stock)

            discd.Text = "0"
            bc.Focus()
            allorders.allordersDGV.Refresh()
            allorders.ordnum1()
        End If

        dailyprofits.order1()
        dailyprofits.cash1()
        dailyprofits.prof1()

        newqty.Text = "0"
        netqty.Text = "0"
        oqty.Text = "0"
        DetectDefaultPrinter()
        cashdr()
        updtordnum()
    End Sub
    Public Sub ShowAutoCloseMessage()
        Dim toolTip As New System.Windows.Forms.ToolTip()

        ' Set properties for the ToolTip
        toolTip.IsBalloon = True           ' Optional: makes it look like a balloon
        toolTip.ToolTipTitle = "ملاحظة"    ' Title for the ToolTip (Optional)

        ' Display the ToolTip above Guna2Button3 for 1000 milliseconds (1 second)
        ' Calculate the position: place it above the button
        Dim buttonTop As Integer = Guna2Button3.Top
        Dim buttonCenterX As Integer = Guna2Button3.Left + (Guna2Button3.Width / 2)
        Dim toolTipY As Integer = buttonTop - toolTip.GetToolTip(Guna2Button3).Length ' Adjust the Y position if needed

        toolTip.Show("تم الحفظ", Guna2Button3, buttonCenterX, buttonTop - 30, 2000) ' Adjust -30 to position above the button
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Delete Then
            ' Trigger the click event of the "Save" button
            Guna2Button1.PerformClick()
            Return True ' Indicate that the key press has been handled
        End If


        ' Check if the F1 key is pressed
        If keyData = Keys.F1 Then
            ' Trigger the click event of the "Save" button
            Guna2Button3.PerformClick()
            Return True ' Indicate that the key press has been handled
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Sub UpdateTotdValues()
        'Dim connectionString As String = "Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SAMITRONICDB;Integrated Security=True"

        Dim connectionString As String = My.Settings.MARKETDBConnectionString


        Using connection As New SqlConnection(connectionString)
            Dim updateQuery As String = "UPDATE Ordernew1 SET totd = pd * qty,totl = pl * qty"

            Using command As New SqlCommand(updateQuery, connection)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Sub UpdateTotdValues1()
        ' Dim connectionString As String = "Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SAMITRONICDB;Integrated Security=True"

        Dim connectionString As String = My.Settings.MARKETDBConnectionString


        Using connection As New SqlConnection(connectionString)
            Dim updateQuery As String = "UPDATE Ordernew1 SET profit = totd - (costd * qty)"

            Using command As New SqlCommand(updateQuery, connection)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Sub UpdateplValues()
        'Dim connectionString As String = "Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SAMITRONICDB;Integrated Security=True"

        Dim connectionString As String = My.Settings.MARKETDBConnectionString


        Using connection As New SqlConnection(connectionString)
            Dim updateQuery As String = "UPDATE Ordernew1 SET pl = ROUND(pd * dr, 0), totl = ROUND(pd * dr, 0) * qty"

            Using command As New SqlCommand(updateQuery, connection)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Sub tot1()
        Dim i = Val(discount.Text)
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select SUM(totd) From Ordernew1"
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 0
            totd.Text = num
        Else
            num = cmd.ExecuteScalar
            totd.Text = num - i
        End If
        cmd.Dispose()
        con.Close()

    End Sub
    Private Sub orderDGV1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles orderDGV1.CellEndEdit
        ' Ensure the user is editing the qty column (adjust column index if needed)
        If e.ColumnIndex = 7 Then ' Assuming qty is at column index 7
            Dim newQty As Decimal

            ' Try to get the entered quantity
            If Not Decimal.TryParse(orderDGV1.Rows(e.RowIndex).Cells(7).Value?.ToString(), newQty) Then
                MessageBox.Show("ادخل كمية صحيحة!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                orderDGV1.Rows(e.RowIndex).Cells(7).Value = 1 ' Reset to 1 if invalid input
                Return
            End If

            ' Get the stockID for the selected row
            Dim stockID As Integer
            If Not Integer.TryParse(orderDGV1.Rows(e.RowIndex).Cells(14).Value?.ToString(), stockID) Then
                MessageBox.Show("خطأ في استرجاع رقم المخزون!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' (Optional) Check available stock
            'Dim availableQty As Decimal = GetAvailableQty(stockID)
            'If newQty > availableQty Then
            '    MessageBox.Show("المنتج غير متوفر! سيتم تعيين الكمية إلى 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    orderDGV.Rows(e.RowIndex).Cells(7).Value = 1
            'End If

            ' 🔹 Capture full row values for logging
            Dim row As DataGridViewRow = orderDGV1.Rows(e.RowIndex)

            Dim bcVal As String = row.Cells(13).Value?.ToString()
            Dim pnVal As String = row.Cells(12).Value?.ToString()
            Dim categVal As String = row.Cells(11).Value?.ToString()
            Dim drVal As Decimal = Convert.ToDecimal(row.Cells(10).Value)
            Dim pdVal As Decimal = Convert.ToDecimal(row.Cells(9).Value)
            Dim plVal As Decimal = Convert.ToDecimal(row.Cells(8).Value)
            Dim qtyVal As Decimal = Convert.ToDecimal(row.Cells(7).Value)
            Dim totdVal As Decimal = Convert.ToDecimal(row.Cells(6).Value)
            Dim totlVal As Decimal = Convert.ToDecimal(row.Cells(5).Value)
            Dim ordnumVal As String = row.Cells(4).Value?.ToString()
            Dim costdVal As Decimal = Convert.ToDecimal(row.Cells(3).Value)
            Dim profitVal As Decimal = Convert.ToDecimal(row.Cells(2).Value)
            Dim empVal As String = row.Cells(1).Value?.ToString()
            Dim dateVal As DateTime = Convert.ToDateTime(row.Cells(0).Value)


            ' 🔹 Log the update action
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                con.Open()
                Dim logCmd As New SqlCommand("
                INSERT INTO orderTransactions
                (actionType, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
                VALUES ('UPDATE', @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp, @date)", con)

                logCmd.Parameters.AddWithValue("@stockID", stockID)
                logCmd.Parameters.AddWithValue("@bc", bcVal)
                logCmd.Parameters.AddWithValue("@pn", pnVal)
                logCmd.Parameters.AddWithValue("@categ", categVal)
                logCmd.Parameters.AddWithValue("@dr", drVal)
                logCmd.Parameters.AddWithValue("@pd", pdVal)
                logCmd.Parameters.AddWithValue("@pl", plVal)
                logCmd.Parameters.AddWithValue("@qty", qtyVal)
                logCmd.Parameters.AddWithValue("@totd", totdVal)
                logCmd.Parameters.AddWithValue("@totl", totlVal)
                logCmd.Parameters.AddWithValue("@ordnum", ordnumVal)
                logCmd.Parameters.AddWithValue("@costd", costdVal)
                logCmd.Parameters.AddWithValue("@profit", profitVal)
                logCmd.Parameters.AddWithValue("@emp", empVal)
                logCmd.Parameters.AddWithValue("@date", dateVal)

                logCmd.ExecuteNonQuery()
            End Using
        End If

        ' 🔹 Save the update to database
        orderDGV1.Refresh()
        Me.Validate()
        Me.Ordernew1BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

        UpdateTotdValues()
        UpdateTotdValues1()
        tot1()
        bc.Focus()
        fillfromqty()
        fillqty()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        On Error Resume Next
        If orderDGV1.SelectedRows.Count > 0 Then
            ' Get selected row before deleting
            Dim selectedRow As DataGridViewRow = orderDGV1.SelectedRows(0)

            Dim stockID As String = selectedRow.Cells(14).Value.ToString()
            Dim bcVal As String = selectedRow.Cells(13).Value.ToString()
            Dim pnVal As String = selectedRow.Cells(12).Value.ToString()
            Dim categVal As String = selectedRow.Cells(11).Value.ToString()
            Dim drVal As Decimal = Convert.ToDecimal(selectedRow.Cells(10).Value)
            Dim pdVal As Decimal = Convert.ToDecimal(selectedRow.Cells(9).Value)
            Dim plVal As Decimal = Convert.ToDecimal(selectedRow.Cells(8).Value)
            Dim qtyVal As Integer = Convert.ToInt32(selectedRow.Cells(7).Value)
            Dim totdVal As Decimal = Convert.ToDecimal(selectedRow.Cells(6).Value)
            Dim totlVal As Decimal = Convert.ToDecimal(selectedRow.Cells(5).Value)
            Dim ordnumVal As String = selectedRow.Cells(4).Value.ToString()
            Dim costdVal As Decimal = Convert.ToDecimal(selectedRow.Cells(3).Value)
            Dim profitVal As Decimal = Convert.ToDecimal(selectedRow.Cells(2).Value)
            Dim empVal As String = selectedRow.Cells(1).Value.ToString()
            Dim dateVal As DateTime = Convert.ToDateTime(selectedRow.Cells(0).Value)

            ' 🔹 Log DELETE action before row is removed
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                con.Open()
                Dim logCmd As New SqlCommand("
                INSERT INTO orderTransactions
                (actionType, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
                VALUES ('DELETE', @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp, @date)", con)

                logCmd.Parameters.AddWithValue("@stockID", stockID)
                logCmd.Parameters.AddWithValue("@bc", bcVal)
                logCmd.Parameters.AddWithValue("@pn", pnVal)
                logCmd.Parameters.AddWithValue("@categ", categVal)
                logCmd.Parameters.AddWithValue("@dr", drVal)
                logCmd.Parameters.AddWithValue("@pd", pdVal)
                logCmd.Parameters.AddWithValue("@pl", plVal)
                logCmd.Parameters.AddWithValue("@qty", qtyVal)
                logCmd.Parameters.AddWithValue("@totd", totdVal)
                logCmd.Parameters.AddWithValue("@totl", totlVal)
                logCmd.Parameters.AddWithValue("@ordnum", ordnumVal)
                logCmd.Parameters.AddWithValue("@costd", costdVal)
                logCmd.Parameters.AddWithValue("@profit", profitVal)
                logCmd.Parameters.AddWithValue("@emp", empVal)
                logCmd.Parameters.AddWithValue("@date", dateVal)

                logCmd.ExecuteNonQuery()
            End Using

            ' Now actually delete the row
            Ordernew1BindingNavigator.DeleteItem.PerformClick()

            Me.Validate()
            Me.Ordernew1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
            tot1()
            bc.Focus()
        Else
            MessageBox.Show("اختر سطر للمسح")
        End If
        orderDGV1.Refresh()

        If orderDGV1.Rows.Count > 0 Then
            ' Scroll to the last row
            orderDGV1.FirstDisplayedScrollingRowIndex = orderDGV1.Rows.Count - 1
            ' Optionally select the last row
            orderDGV1.Rows(orderDGV1.Rows.Count - 1).Selected = True
        End If
    End Sub



    Private Sub discount_TextChanged(sender As Object, e As EventArgs) Handles discount.TextChanged

        tot1()
    End Sub

    Private Sub totd_TextChanged(sender As Object, e As EventArgs) Handles totd.TextChanged
        totl.Text = Math.Round(Val(totd.Text) * Val(dr.Text))
        credit.Text = Val(totd.Text)
        wasil.Text = Val(totd.Text)
        rad.Text = Val(wasil.Text) - Val(totd.Text)
    End Sub



    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Controls.Clear()
        InitializeComponent()
        orderfrm_Load(e, e)
    End Sub
    Private Sub newqty_TextChanged(sender As Object, e As EventArgs)
        netqty.Text = Val(oqty.Text) - Val(newqty.Text)
    End Sub

    Private Sub oqty_TextChanged(sender As Object, e As EventArgs)
        netqty.Text = Val(oqty.Text) - Val(newqty.Text)
    End Sub




    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles discheck.CheckedChanged
        Dim i As Integer
        i = Val(totl.Text) - (Val(totl.Text) * (Val(percentd.Text) / 100))
        If discheck.Checked = True Then
            disc3.Text = Val(totl.Text) - i
        ElseIf discheck.Checked = False Then
            disc3.Text = ""

        End If
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Dim numericValue As Decimal ' Change to appropriate numeric data type if needed

        ' Parse the textbox text to the appropriate numeric data type
        If Decimal.TryParse(percentd.Text, numericValue) Then
            ' Save the numeric value to settings
            My.Settings.orderdisc = numericValue
            My.Settings.Save()
        Else
            MessageBox.Show("Invalid numeric value entered.")
        End If
    End Sub

    Private Sub disc3_TextChanged(sender As Object, e As EventArgs) Handles disc3.TextChanged
        discount1.Text = Val(disc3.Text)
    End Sub

    Private Sub credit_TextChanged(sender As Object, e As EventArgs) Handles credit.TextChanged
        If credit.Text = "" Or credit.Text = "0" Then
            debit.Text = "0"

        Else

            debit.Text = Val(totd.Text) - Val(credit.Text)
        End If
        cash1.Text = Val(credit.Text) * Val(dr.Text)

    End Sub
    Private Sub debit_TextChanged(sender As Object, e As EventArgs) Handles debit.TextChanged
        debit1.Text = Val(debit.Text) * Val(dr.Text)
    End Sub
    Public Sub fillord()

        con.Open()
        Dim query = "select * from ordertbl1 where ordnum=N'" & ord.Text & "' "
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable

        con.Close()

    End Sub
    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        orderfrm2.ordnum.Text = ord.Text
        con.Open()
        Dim query As String = "INSERT INTO Ordernew1 (stockID,bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
                       SELECT stockID,bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date]
                       FROM orderstbl
                       WHERE ordnum = @ordnum"

        Dim cmd As SqlCommand = New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@ordnum", ord.Text)
        cmd.ExecuteNonQuery()
        con.Close()
        fillord()
        Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
        UpdateStock()
        con.Open()
        Dim query1 As String = "delete from orderstbl where ordnum= " & ord.Text & ""

        Dim cmd1 As SqlCommand = New SqlCommand(query1, con)

        cmd1.ExecuteNonQuery()
        con.Close()
        allorders.OrderstblTableAdapter.Fill(allorders.MARKETDataSet.orderstbl)

        con.Open()
        Dim query3 As String = "delete from ordertbl1 where ordnum= " & ord.Text & ""

        Dim cmd3 As SqlCommand = New SqlCommand(query3, con)
        cmd3.Parameters.AddWithValue("@ordnum", ord.Text)
        cmd3.ExecuteNonQuery()
        con.Close()
        allorders.Ordertbl1TableAdapter.Fill(allorders.MARKETDataSet.ordertbl1)
        UpdateplValues()
        UpdateTotdValues()
        UpdateTotdValues1()
        tot1()
        stock.StockTableAdapter.Fill(stock.MARKETDataSet.stock)
        allorders.Ordertbl1TableAdapter.Fill(allorders.MARKETDataSet.ordertbl1)
        'TODO: This line of code loads data into the 'MarketDataSet.orderstbl' table. You can move, or remove it, as needed.
        allorders.OrderstblTableAdapter.Fill(allorders.MARKETDataSet.orderstbl)
        dailyprofits.order1()
        dailyprofits.cash1()
        dailyprofits.prof1()
        MessageBox.Show("تم ترجيع الطلب")
    End Sub

    Private Sub orderDGV1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles orderDGV1.CellClick
        On Error Resume Next
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = orderDGV1.Rows(index)
        If selectedRow Is Nothing Then
        Else
            idtxt.Text = selectedRow.Cells(14).Value
            TextBox1.Text = selectedRow.Cells(12).Value
            TextBox4.Text = selectedRow.Cells(11).Value
        End If


        orderDGV1.Refresh()
        fillfromqty()
        fillqty()
        fillcd()

    End Sub
    Public Sub fillcd()

        con.Open()
        Dim query = "select * from stock where pname=N'" & TextBox1.Text & "' and cat=N'" & TextBox4.Text & "' "
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read

            TextBox2.Text = reader(5).ToString

        End While
        con.Close()

    End Sub



    Private Sub TextBox2_MouseHover(sender As Object, e As EventArgs) Handles TextBox2.MouseHover
        TextBox2.ForeColor = Color.Black
    End Sub

    Private Sub TextBox2_MouseLeave(sender As Object, e As EventArgs) Handles TextBox2.MouseLeave
        TextBox2.ForeColor = Color.WhiteSmoke
    End Sub






    ' Connection string to your database
    Private connectionString As String = My.Settings.MARKETDBConnectionString



    Private panelsDictionary As New Dictionary(Of String, FlowLayoutPanel)

    ' Declare the panel container for FlowLayoutPanels
    Public WithEvents flowLayoutPanelContainer As Panel
    Public WithEvents buttonContextMenu As New ContextMenuStrip()

    Private Sub AssignContextMenuToExistingButtons()
        ' Iterate over all panels and assign the context menu to existing buttons
        For Each panel As FlowLayoutPanel In flowLayoutPanelContainer.Controls.OfType(Of FlowLayoutPanel)()
            For Each ctrl As Control In panel.Controls
                If TypeOf ctrl Is Guna2Button Then
                    Dim button As Guna2Button = CType(ctrl, Guna2Button)
                    button.ContextMenuStrip = buttonContextMenu
                End If
            Next
        Next
    End Sub



    Public Sub FillCategories()
        ' stock.StockTableAdapter.Fill(stock.MarketDataSet.stock)
        ' Clear existing items
        categoriesComboBox.Items.Clear()

        ' Define your SQL connection string
        Dim connectionString As String = My.Settings.MARKETDBConnectionString

        ' SQL query to get the list of categories
        Dim query As String = "SELECT DISTINCT cat FROM stock"

        ' Establish a connection to the SQL database
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()

                    ' Execute the query and read the results
                    Using reader As SqlDataReader = command.ExecuteReader()
                        ' Check if the reader has rows (categories)
                        If reader.HasRows Then
                            ' Loop through the result and read each category
                            While reader.Read()
                                Dim category As String = reader("cat").ToString()

                                ' Check if the category has any items
                                Dim itemNames As List(Of String) = GetItemsForCategory(category)
                                If itemNames.Count > 0 Then
                                    ' Add category to ComboBox only if it has items
                                    categoriesComboBox.Items.Add(category)
                                End If
                            End While

                            ' Set the first item as selected if items were added
                            If categoriesComboBox.Items.Count > 0 Then
                                categoriesComboBox.SelectedIndex = 0
                            End If
                        Else
                            categoriesComboBox.Text = "" ' Clear the ComboBox if no categories
                        End If
                    End Using

                Catch ex As Exception
                    ' Handle any errors that may occur
                    MessageBox.Show("An error occurred while loading categories: " & ex.Message)
                End Try
            End Using
        End Using

    End Sub
    Dim panel As FlowLayoutPanel

    Private Sub categoriesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles categoriesComboBox.SelectedIndexChanged
        numcat()

        Try
            ' Ensure a category is selected
            If categoriesComboBox.SelectedItem Is Nothing Then
                MessageBox.Show("اختار صنف")
                Return
            End If

            Dim selectedCategory As String = categoriesComboBox.SelectedItem.ToString()

            ' Retrieve the list of item names for the selected category
            Dim itemNames As List(Of String) = GetItemsForCategory(selectedCategory)

            ' If there are no items in the category, skip creating the panel
            If itemNames.Count = 0 Then
                MessageBox.Show("لا يوجد منتج لهذا الصنف")
                categoriesComboBox.Items.Remove(selectedCategory)
                Return
            End If

            ' Retrieve or create the panel for the selected category
            If Not panelsDictionary.TryGetValue(selectedCategory, panel) Then
                ' Create the panel if it does not exist
                CreateFlowLayoutPanelForCategory(selectedCategory)
                panel = panelsDictionary(selectedCategory)
            End If

            ' Clear existing buttons from the panel
            panel.Controls.Clear()

            ' Add buttons for each item
            Dim counter As Integer = 0
            For Each itemName As String In itemNames
                Dim btn As New Guna2Button()
                btn.Text = itemName ' Set the button's text to the item name
                btn.Width = 130
                btn.Height = 42
                btn.FillColor = Color.FromArgb(24, 85, 119)
                btn.BorderRadius = 2
                btn.Margin = New Padding(5) ' spacing around buttons
                AddHandler btn.Click, AddressOf ItemButton_Click
                panel.Controls.Add(btn)

                counter += 1
                If counter Mod 4 = 0 Then
                    panel.SetFlowBreak(btn, True) ' Force new row after every 4 buttons
                End If
            Next

            ' Display the panel
            flowLayoutPanelContainer.Controls.Clear()
            flowLayoutPanelContainer.Controls.Add(panel)

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    ' This function queries the database and returns a list of item names for the given category
    Private Function GetItemsForCategory(category As String) As List(Of String)
        Dim itemNames As New List(Of String)
        Dim connectionString As String = My.Settings.MARKETDBConnectionString

        Dim query As String =
"
WITH RankedItems AS (
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY pname ORDER BY 
               CASE WHEN qavailable > 0 THEN 0 ELSE 1 END
           ) AS rn
    FROM stock
    WHERE cat = @cat AND (code = '' OR code IS NULL)
)
SELECT pname
FROM RankedItems
WHERE rn = 1
ORDER BY pname
"


        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@cat", category)

                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            itemNames.Add(reader("pname").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("An error occurred while retrieving items: " & ex.Message)
                End Try
            End Using
        End Using

        Return itemNames
    End Function




    Private Sub CreateFlowLayoutPanelForCategory(category As String)
        ' Check if panel already exists
        If panelsDictionary.ContainsKey(category) Then
            Return
        End If

        ' Create a new FlowLayoutPanel
        Dim newPanel As New FlowLayoutPanel()
        newPanel.Name = "Panel_" & category
        newPanel.AutoScroll = True
        newPanel.FlowDirection = FlowDirection.LeftToRight
        newPanel.WrapContents = True
        newPanel.Tag = category
        newPanel.Size = flowLayoutPanelContainer.Size ' Set the same size as flowLayoutPanelContainer
        newPanel.Location = New Point(0, 0) ' Set the same location as flowLayoutPanelContainer
        newPanel.BackColor = Color.White ' Set a background color for visibility

        ' Add the panel to the dictionary and container
        panelsDictionary.Add(category, newPanel)
        flowLayoutPanelContainer.Controls.Add(newPanel)



    End Sub




    Private Sub numcat()
        Dim selectedCategory As String = categoriesComboBox.SelectedItem.ToString()

        Using con As New SqlConnection(connectionString)
            Try
                con.Open()
                Dim query As String = "SELECT COUNT(*) FROM stock WHERE cat = @cat"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@cat", selectedCategory)
                    TextBox3.Text = cmd.ExecuteScalar().ToString()
                End Using
            Catch ex As SqlException
                MessageBox.Show("An error occurred while accessing the database: " & ex.Message)
            Catch ex As Exception
                MessageBox.Show("An unexpected error occurred: " & ex.Message)
            End Try
        End Using
    End Sub






    'this part is for adding item from flowlayoutpanel to dgv


    ' Optional: Handle button click events
    Private Sub ItemButton_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        Dim clickedButton As Guna2Button = CType(sender, Guna2Button)

        ' Store the button text in pn.Text (so both options use it)
        pn.Text = clickedButton.Text

        ' Show the menu under the clicked button
        itemMenu.Show(clickedButton, 0, clickedButton.Height)
    End Sub

    ' Handle menu item clicks
    Private Sub itemMenu_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles itemMenu.ItemClicked
        Select Case e.ClickedItem.Text
            Case "مفرق"
                fillfrompn()
            Case "جملة"
                fillfrompnj()
        End Select
    End Sub

    Public Sub button2clickreverse()

        On Error Resume Next

        Dim i = Val(CDbl(qty.Text)) * Val(CDbl(pd.Text))
        Dim ii = Val(CDbl(qty.Text)) * Val(CDbl(cd.Text))
        Dim cmd02 As New SqlCommand
        cmd02.Connection = con
        con.Open()

        cmd02.CommandText = "select SUM(qty) From Ordernew1 where pn=N'" & pn.Text & "' and categ=N'" & categoriesComboBox.Text & "'"
        Dim exists As Boolean = Not IsDBNull(cmd02.ExecuteScalar)

        If Not exists Then
            ' INSERT new reverse row
            Dim newRow As DataRow = MARKETDataSet.ordernew1.NewRow()
            newRow("stockID") = idtxt.Text
            newRow("bc") = bc.Text
            newRow("pn") = pn.Text
            newRow("categ") = categ.Text
            newRow("dr") = Val(dr.Text)
            newRow("pd") = -Val(pd.Text)
            newRow("pl") = -Val(pl.Text)
            newRow("qty") = Val(qty.Text)
            newRow("totd") = (Val(CDbl(qty.Text)) * Val(CDbl(pd.Text)))
            newRow("totl") = (Val(CInt(dr.Text)) * Val(CDbl(pd.Text)))
            newRow("ordnum") = orderfrm2.ordnum.Text
            newRow("costd") = -Val(CDbl(cd.Text))
            newRow("profit") = -(i - ii)
            newRow("emp") = emp.Text
            newRow("date") = FormatDateTime(maindate.Value)

            Me.MARKETDataSet.ordernew1.Rows.Add(newRow)
            orderDGV1.Refresh()
            Me.Validate()
            Me.Ordernew1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' 🔹 Log REVERSE INSERT
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
            VALUES ('REVERSE_INSERT', @Id, @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp, @date)", con)

            logCmd.Parameters.AddWithValue("@Id", newRow("stockID"))
            logCmd.Parameters.AddWithValue("@stockID", newRow("stockID"))
            logCmd.Parameters.AddWithValue("@bc", bc.Text)
            logCmd.Parameters.AddWithValue("@pn", pn.Text)
            logCmd.Parameters.AddWithValue("@categ", categ.Text)
            logCmd.Parameters.AddWithValue("@dr", Val(dr.Text))
            logCmd.Parameters.AddWithValue("@pd", -Val(pd.Text))
            logCmd.Parameters.AddWithValue("@pl", -Val(pl.Text))
            logCmd.Parameters.AddWithValue("@qty", Val(qty.Text))
            logCmd.Parameters.AddWithValue("@totd", (Val(CDbl(qty.Text)) * Val(CDbl(pd.Text))))
            logCmd.Parameters.AddWithValue("@totl", (Val(CInt(dr.Text)) * Val(CDbl(pd.Text))))
            logCmd.Parameters.AddWithValue("@ordnum", orderfrm2.ordnum.Text)
            logCmd.Parameters.AddWithValue("@costd", -Val(cd.Text))
            logCmd.Parameters.AddWithValue("@profit", -(i - ii))
            logCmd.Parameters.AddWithValue("@emp", emp.Text)
            logCmd.Parameters.AddWithValue("@date", FormatDateTime(maindate.Value))
            logCmd.ExecuteNonQuery()

        Else
            ' Get old qty
            Dim oldQty As Integer = 0
            Dim getOldQtyCmd As New SqlCommand("SELECT qty FROM ordernew1 WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "'", con)
            Dim reader As SqlDataReader = getOldQtyCmd.ExecuteReader()
            If reader.Read() Then
                oldQty = Convert.ToInt32(reader("qty"))
            End If
            reader.Close()

            ' UPDATE qty
            Dim query As String = "update Ordernew1 set qty=qty + " & qty.Text & " where pn=N'" & pn.Text & "' and categ=N'" & categ.Text & "'"
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()

            Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
            Me.Validate()
            Me.Ordernew1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' 🔹 Log REVERSE UPDATE
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions 
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
            SELECT 'REVERSE_UPDATE', Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date]
            FROM ordernew1 WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "'", con)
            logCmd.ExecuteNonQuery()

            ' optional debug
            Dim newQtyCmd As New SqlCommand("SELECT qty FROM ordernew1 WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "'", con)
            Dim newQty As Integer = Convert.ToInt32(newQtyCmd.ExecuteScalar())
            Console.WriteLine("REVERSE Qty changed from " & oldQty & " → " & newQty)
        End If

        con.Close()
        bc.Text = ""
        tot1()
        UpdateplValues()
        UpdateTotdValues()
        UpdateTotdValues1()
        tot1()
        filltotcostd()
        fillfromqty()
        fillqty()
        bc.Focus()

    End Sub


    Public Sub button2click()

        On Error Resume Next
        Dim i = Val(CDbl(qty.Text)) * Val(CDbl(pd.Text))
        Dim ii = Val(CDbl(qty.Text)) * Val(CDbl(cd.Text))
        Dim cmd02 As New SqlCommand
        cmd02.Connection = con
        con.Open()

        cmd02.CommandText = "select SUM(qty) From Ordernew1 where pn=N'" & pn.Text & "' and categ=N'" & categoriesComboBox.Text & "'"
        Dim exists As Boolean = Not IsDBNull(cmd02.ExecuteScalar)

        If Not exists Then
            ' INSERT new row
            Dim newRow As DataRow = MARKETDataSet.ordernew1.NewRow()
            newRow("stockID") = idtxt.Text
            newRow("bc") = bc.Text
            newRow("pn") = pn.Text
            newRow("categ") = categ.Text
            newRow("dr") = Val(dr.Text)
            newRow("pd") = Val(pd.Text)
            Dim plValue As Double = CDbl(pd.Text) * CDbl(dr.Text)
            newRow("pl") = CInt(Math.Round(plValue, 0, MidpointRounding.AwayFromZero))
            newRow("qty") = Val(qty.Text)
            newRow("totd") = Val(CDbl(qty.Text)) * Val(CDbl(pd.Text))
            newRow("totl") = Val(CInt(dr.Text)) * Val(CDbl(pd.Text))
            newRow("ordnum") = orderfrm2.ordnum.Text
            newRow("costd") = Val(CDbl(cd.Text))
            newRow("profit") = i - ii
            newRow("emp") = emp.Text
            newRow("date") = FormatDateTime(maindate.Value)

            Me.MARKETDataSet.ordernew1.Rows.Add(newRow)
            orderDGV1.Refresh()
            Me.Validate()
            Me.Ordernew1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' 🔹 Log INSERT
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions 
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
            VALUES ('INSERT', @Id, @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp, @date)", con)

            logCmd.Parameters.AddWithValue("@Id", newRow("stockID"))
            logCmd.Parameters.AddWithValue("@stockID", newRow("stockID"))
            logCmd.Parameters.AddWithValue("@bc", bc.Text)
            logCmd.Parameters.AddWithValue("@pn", pn.Text)
            logCmd.Parameters.AddWithValue("@categ", categ.Text)
            logCmd.Parameters.AddWithValue("@dr", Val(dr.Text))
            logCmd.Parameters.AddWithValue("@pd", Val(pd.Text))
            logCmd.Parameters.AddWithValue("@pl", plValue)
            logCmd.Parameters.AddWithValue("@qty", Val(qty.Text))
            logCmd.Parameters.AddWithValue("@totd", i)
            logCmd.Parameters.AddWithValue("@totl", Val(dr.Text) * Val(pd.Text))
            logCmd.Parameters.AddWithValue("@ordnum", orderfrm2.ordnum.Text)
            logCmd.Parameters.AddWithValue("@costd", Val(cd.Text))
            logCmd.Parameters.AddWithValue("@profit", i - ii)
            logCmd.Parameters.AddWithValue("@emp", emp.Text)
            logCmd.Parameters.AddWithValue("@date", FormatDateTime(maindate.Value))
            logCmd.ExecuteNonQuery()

        Else
            ' Get old qty before update
            Dim oldQty As Integer = 0
            Dim getOldQtyCmd As New SqlCommand("SELECT qty FROM ordernew1 WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "'", con)
            Dim reader As SqlDataReader = getOldQtyCmd.ExecuteReader()
            If reader.Read() Then
                oldQty = Convert.ToInt32(reader("qty"))
            End If
            reader.Close()

            ' UPDATE existing qty
            Dim query As String = "update Ordernew1 set qty=qty + " & qty.Text & " where pn=N'" & pn.Text & "' and categ=N'" & categ.Text & "'"
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()

            Me.Ordernew1TableAdapter.Fill(Me.MARKETDataSet.ordernew1)
            Me.Validate()
            Me.Ordernew1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' 🔹 Log UPDATE (with old → new qty)
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions 
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date])
            SELECT 'UPDATE', Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, [date]
            FROM ordernew1 WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "'", con)
            logCmd.ExecuteNonQuery()

            ' (Optional) also log old → new qty in Debug/MessageBox
            Dim newQtyCmd As New SqlCommand("SELECT qty FROM ordernew1 WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "'", con)
            Dim newQty As Integer = Convert.ToInt32(newQtyCmd.ExecuteScalar())
            Console.WriteLine("Qty changed from " & oldQty & " → " & newQty)
        End If

        con.Close()
        bc.Text = ""
        tot1()
        UpdateplValues()
        UpdateTotdValues()
        UpdateTotdValues1()
        tot1()
        filltotcostd()
        fillfromqty()
        fillqty()
        bc.Focus()

    End Sub





    Public Function HighlightRowsBasedOnCost() As Boolean
        ' Define your SQL connection string
        Dim connectionString As String = My.Settings.MARKETDBConnectionString

        ' Loop through each row in the DataGridView
        For Each row As DataGridViewRow In orderDGV1.Rows
            ' Ensure the row is not empty
            If row.IsNewRow Then Continue For

            ' Get the item name or ID (depending on what identifies the item in your orderDGV1)
            Dim productname As String = row.Cells(12).Value.ToString() ' Change "ItemIDColumn" to the actual column name/index for the item
            Dim productcat As String = row.Cells(11).Value.ToString()
            ' Retrieve the cost from the stock table for the corresponding item
            Dim query As String = "SELECT pcostd FROM stock WHERE pname = @pname and cat=@cat"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@pname", productname)
                    command.Parameters.AddWithValue("@cat", productcat)
                    Try
                        connection.Open()
                        Dim pcostd As Decimal = Convert.ToDecimal(command.ExecuteScalar())

                        ' Get the price from cell(9) in the DataGridView
                        Dim price As Decimal = Convert.ToDecimal(row.Cells(9).Value)

                        ' Compare price to costd, and if price is below cost, change row color to green
                        If price <= pcostd Then
                            row.DefaultCellStyle.BackColor = Color.Red
                            row.DefaultCellStyle.SelectionBackColor = Color.IndianRed ' Keep the same color when the row is selected
                        Else
                            row.DefaultCellStyle.BackColor = Color.White ' Reset color if necessary
                            row.DefaultCellStyle.SelectionBackColor = Color.LightGray ' Reset selection color
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Error retrieving cost: " & ex.Message)
                    End Try
                End Using
            End Using
        Next
        Return True
    End Function

    Private Sub orderDGV1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles orderDGV1.DataBindingComplete
        HighlightRowsBasedOnCost()
        'CheckIfDataGridViewIsEmpty()

    End Sub

    Private Sub categoriesComboBox_Click(sender As Object, e As EventArgs) Handles categoriesComboBox.Click
        FillCategories()
    End Sub





    Private Sub orderDGV1_MouseDown(sender As Object, e As MouseEventArgs) Handles orderDGV1.MouseDown
        ' Show context menu on right-click
        If e.Button = MouseButtons.Right Then
            Dim hitTest As DataGridView.HitTestInfo = orderDGV1.HitTest(e.X, e.Y)
            If hitTest.RowIndex >= 0 Then
                orderDGV1.ClearSelection()
                orderDGV1.Rows(hitTest.RowIndex).Selected = True
                Guna2ContextMenuStrip2.Show(orderDGV1, e.Location)
            End If
        End If
    End Sub
    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        searchform1.Show()
        searchform1.BringToFront()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        searchformCAT1.Show()
        searchformCAT1.BringToFront()
    End Sub
    ' Handler for the ToolStripMenuItem Click event
    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        If cn.Text = "" Then
            MessageBox.Show("ادخل اسم الزبون")
        Else
            prodstat.Show()
            Dim selectedRow As DataGridViewRow = orderDGV1.CurrentRow
            If selectedRow IsNot Nothing Then
                Dim dtlData As String = selectedRow.Cells(12).Value.ToString()
                prodstat.product.Text = dtlData
                prodstat.name1.Text = cn.Text
            End If
            prodstat.itemsstat()
        End If

    End Sub
    Private Sub DetectDefaultPrinter()
        Try
            ' Get the default printer
            Dim defaultPrinter As String = New PrinterSettings().PrinterName

            ' Display the default printer in a message box or assign it as needed
            ' MessageBox.Show("Default Printer: " & defaultPrinter)

            ' You can now use defaultPrinter as your selected printer
            Dim printerName As String = defaultPrinter ' Assign the detected default printer
        Catch ex As Exception
            MessageBox.Show("Error detecting the default printer: " & ex.Message)
        End Try
    End Sub
    Public Sub cashdr()
        Try
            ' Automatically detect the default printer
            Dim printerName As String = New PrinterSettings().PrinterName

            ' Send the cash drawer open command
            Dim drawerCommand As String = Chr(27) & "p" & Chr(0) & Chr(25) & Chr(250) ' ESC/POS command to open drawer
            If RawPrinterHelper.SendStringToPrinter(printerName, drawerCommand) Then

            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        '   CashDrawerHelper.OpenCashDrawer()
        DetectDefaultPrinter()
        cashdr()

    End Sub
    Private Sub plus_TextChanged(sender As Object, e As EventArgs) Handles plus.TextChanged
        filltotcostd()
        tot1()
    End Sub

    Private Sub discd_TextChanged(sender As Object, e As EventArgs) Handles discd.TextChanged
        discount.Text = Val(discd.Text)
    End Sub

    Private Sub wasil_TextChanged(sender As Object, e As EventArgs) Handles wasil.TextChanged
        wasil1.Text = Val(wasil.Text) * Val(dr.Text)
        rad.Text = Val(wasil.Text) - Val(totd.Text)
    End Sub


    Private Sub rad_TextChanged(sender As Object, e As EventArgs) Handles rad.TextChanged
        rad1.Text = Val(rad.Text) * Val(dr.Text)
    End Sub
    'print
    Dim WithEvents PDd1 As New PrintDocument
    Dim PPD1 As New PrintPreviewDialog
    Dim longpaper As Integer

    ' Adjust the paper size based on the number of rows
    Sub changelongpaper()
        ' Calculate the number of rows in the DataGridView
        Dim rowcount As Integer = orderDGV1.Rows.Count

        ' Calculate height based on the number of rows (adjust row height if needed)
        Dim rowHeight As Integer = 20 ' Height for each row, can adjust if needed
        Dim rowsHeight As Integer = rowcount * rowHeight

        ' Calculate space needed for header and footer
        Dim headerFooterHeight As Integer = 350 ' Space for header and footer (adjust as needed)

        ' Total paper height = height of all rows + header/footer height
        longpaper = rowsHeight + headerFooterHeight
    End Sub

    Private Sub PDd1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PDd1.BeginPrint
        ' Calculate longpaper size dynamically based on the number of rows
        changelongpaper()

        ' Set custom page size for continuous printing on POS paper size (e.g., 80mm wide, adjust height)
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, longpaper) ' Adjust 250 to match your paper width
        PDd1.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PdD1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PDd1.PrintPage
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 14, FontStyle.Bold)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)

        Dim leftmargin As Integer = PDd1.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PDd1.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PDd1.DefaultPageSettings.PaperSize.Width

        ' Set alignments
        Dim right As New StringFormat
        Dim center As New StringFormat
        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        ' Draw logo
        ' Dim logoImage As Image = My.Resources.ResourceManager.GetObject("IMG_20240518_WA0021")
        ' e.Graphics.DrawImage(logoImage, CInt((e.PageBounds.Width - 100) / 2), 5, 100, 60)

        ' Store info
        e.Graphics.DrawString("GODY'S MARKET", f10, Brushes.Black, centermargin, 5, center)
        ' e.Graphics.DrawString("منتوجات مطاحن النجار الحديثة", f10, Brushes.Black, centermargin, 25, center)
        e.Graphics.DrawString("العنوان: رعيت - جنب كنيسة مار الياس", f8, Brushes.Black, centermargin, 25, center)
        e.Graphics.DrawString("تلفون:03/102468", f8, Brushes.Black, centermargin, 37, center)

        ' Order info
        e.Graphics.DrawString(orderfrm2.ordnum.Text & "#:رقم الفاتورة", f8, Brushes.Black, rightmargin, 65, right)
        'e.Graphics.DrawString(": #", f8, Brushes.Black, 70, 55)
        ' e.Graphics.DrawString(orderfrm2.ordnum.Text, f8, Brushes.Black, 80, 55)


        ' Date and employee
        e.Graphics.DrawString(FormatDateTime(maindate.Value.Date), f8, Brushes.Black, 0, 65)
        e.Graphics.DrawString("اسم الموظف", f8, Brushes.Black, 0, 75)
        e.Graphics.DrawString(emp.Text, f8, Brushes.Black, 0, 85)

        ' Table header
        e.Graphics.DrawString("المجموع", f8, Brushes.Black, 0, 95)
        e.Graphics.DrawString("السعر", f8, Brushes.Black, 60, 95)
        e.Graphics.DrawString("اسم المنتج", f8, Brushes.Black, 200, 95, right)
        e.Graphics.DrawString("الكمية", f8, Brushes.Black, rightmargin, 95, right)
        e.Graphics.DrawString("****************************************************************", f8, Brushes.Black, 0, 105)

        ' Print rows from DataGridView



        Dim height As Integer = 105
        For row As Integer = 0 To orderDGV1.RowCount - 1
            height += 15
            e.Graphics.DrawString(orderDGV1.Rows(row).Cells(7).Value.ToString, f8, Brushes.Black, rightmargin, height, right)

            ' Wrap text for Item column with manual right-to-left alignment
            Dim itemText As String = orderDGV1.Rows(row).Cells(12).Value.ToString()
            Dim itemRect As New RectangleF(115, height, 90, 30)
            Dim itemFormat As New StringFormat()
            itemFormat.Alignment = StringAlignment.Far ' Align text to the far (right) side
            itemFormat.LineAlignment = StringAlignment.Near

            ' Draw the Item text with the adjusted right-to-left alignment
            e.Graphics.DrawString(itemText, f8, Brushes.Black, itemRect, itemFormat)

            ' Adjust height for wrapped text if necessary
            Dim itemSize As SizeF = e.Graphics.MeasureString(itemText, f8, itemRect.Size, itemFormat)
            Dim itemHeight As Integer = CInt(Math.Ceiling(itemSize.Height))
            height += itemHeight - 15

            ' Print item price and total
            Dim itemPrice As Decimal = orderDGV1.Rows(row).Cells(8).Value
            e.Graphics.DrawString(Format(itemPrice, "##,##0"), f8, Brushes.Black, 60, height)
            Dim totalprice As Decimal = Val(orderDGV1.Rows(row).Cells(5).Value)
            e.Graphics.DrawString(totalprice.ToString("##,##0"), f8, Brushes.Black, 0, height)
        Next


        ' Footer and summary
        Dim footerHeight As Integer = height + 15
        e.Graphics.DrawString("****************************************************************", f8, Brushes.Black, 0, footerHeight)
        ' e.Graphics.DrawString(totd.Text & ":$ المجموع", f10b, Brushes.Black, rightmargin, footerHeight + 20, right)
        ' e.Graphics.DrawString(totd.Text, f10b, Brushes.Black, 60, footerHeight + 20)
        ' Calculate sum of column 7
        Dim itemCount As Integer = 0

        For Each row As DataGridViewRow In orderDGV1.Rows
            If row.Cells(7).Value IsNot Nothing AndAlso row.Cells(7).Value.ToString().Trim() <> "" Then
                itemCount += 1
            End If
        Next

        ' Draw the count in the footer
        e.Graphics.DrawString(itemCount.ToString() & ":عدد الأصناف", f10b, Brushes.Black, rightmargin, footerHeight + 20, right)

        e.Graphics.DrawString(FormatNumber(totl.Text, 0) & ":المجموع ل.ل", f10b, Brushes.Black, rightmargin, footerHeight + 40, right)
        '  e.Graphics.DrawString(, f10b, Brushes.Black, 75, footerHeight + 40)

        ' Thank you message
        e.Graphics.DrawString("~ شكرا لزيارتكم ~", f10, Brushes.Black, centermargin, footerHeight + 70, center)
        e.Graphics.DrawString("~ EL-POS برنامج المحاسبة ~", f10, Brushes.Black, centermargin, footerHeight + 90, center)
        '    e.Graphics.DrawString(billnote.Text, f8, Brushes.Black, centermargin, footerHeight + 90, center)

        ' Ensure continuous printing without splitting or pagination
        e.HasMorePages = False
    End Sub


    Private Sub AdvancedDataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles orderDGV1.EditingControlShowing
        Dim txt As System.Windows.Forms.TextBox = TryCast(e.Control, System.Windows.Forms.TextBox)
        If txt IsNot Nothing Then
            ' Remove previous handler to avoid duplicates
            RemoveHandler txt.KeyDown, AddressOf EditingControl_KeyDown
            ' Add new handler
            AddHandler txt.KeyDown, AddressOf EditingControl_KeyDown
        End If
    End Sub

    ' Handles Enter key inside the editing control
    Private Sub EditingControl_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Prevents Enter from moving down
        End If
    End Sub

    ' Prevents Enter from moving to the next row in non-editing mode
    Private Sub AdvancedDataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles orderDGV1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Stops default Enter behavior
        End If
    End Sub

    Private Function GetAvailableQty(stockID As Integer) As Decimal
        Dim availableQty As Decimal = 0

        Try
            con.Open()
            Dim query As String = "SELECT qavailable FROM stock WHERE Id = @stockID"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@stockID", stockID)

            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                availableQty = Convert.ToDecimal(result)
            End If

        Catch ex As Exception
            MessageBox.Show("Error retrieving stock quantity: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

        Return availableQty
    End Function
    Public Sub updtordnum()
        con.Open()
        Dim query As String = "UPDATE ordernew SET ordnum = @ordnum"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)


        ' Add the parameter to avoid SQL injection
        cmd.Parameters.AddWithValue("@ordnum", orderfrm2.ordnum.Text)

        ' Open the connection
        cmd.ExecuteNonQuery()

        con.Close()
        ' MessageBox.Show("Order number updated successfully.")
    End Sub

    Private Sub pd_TextChanged(sender As Object, e As EventArgs) Handles pd.TextChanged
        If isUpdating Then Return

        ' If the user is editing PD, mark it as modified
        If pd.Focused Then
            pd.Modified = True
        End If

        ' When PD changes (by user or code) recalc PL only if this change comes from PD (not while updating)
        If IsNumeric(pd.Text) AndAlso IsNumeric(dr.Text) Then
            isUpdating = True
            pl.Text = (Val(pd.Text) * Val(dr.Text)).ToString()
            ' This assignment is programmatic, so keep PL.Modified = False (we didn't type it)
            pl.Modified = False
            isUpdating = False
        End If
    End Sub

    Private Sub pl_TextChanged(sender As Object, e As EventArgs) Handles pl.TextChanged
        If isUpdating Then Return

        ' Only treat as a manual edit if the control is focused (so programmatic changes won't mark it)
        If pl.Focused Then
            pl.Modified = True

            If IsNumeric(pl.Text) AndAlso IsNumeric(dr.Text) AndAlso Val(dr.Text) <> 0 Then
                isUpdating = True
                Dim newPd As Double = Val(pl.Text) / Val(dr.Text)
                pd.Text = newPd.ToString()
                ' Programmatic assignment => mark pd as NOT modified
                pd.Modified = False
                isUpdating = False
            End If
        End If
    End Sub

    Private Sub suggpl_MouseHover(sender As Object, e As EventArgs) Handles suggpl.MouseHover
        suggpl.ForeColor = Color.Black
    End Sub

    Private Sub suggpl_MouseLeave(sender As Object, e As EventArgs) Handles suggpl.MouseLeave
        suggpl.ForeColor = Color.WhiteSmoke
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        suggpl.Text = Val(TextBox2.Text) * Val(dr.Text)
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        categoriesComboBox.SelectedItem = "الخضار"

    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        categoriesComboBox.SelectedItem = "فروج"
    End Sub
End Class


