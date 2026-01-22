Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class stock


    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Private Sub GetNextStockId()
        Try
            Dim query As String = "SELECT ISNULL(MAX(id), 0) + 1 FROM stock"
            Using cmd As New SqlCommand(query, con)
                con.Open()
                Dim nextId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Stockjemle.idj.Text = nextId.ToString()
                Stockjemle.bc.Text = ""
                Stockjemle.pd.Text = "0"
                Stockjemle.pl.Text = "0"
                Stockjemle.qtyj.Text = "0"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting next ID: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Private Sub stockDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles stockDGV.CellClick
        On Error Resume Next
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = stockDGV.Rows(index)
        If selectedRow Is Nothing Then
        Else

            Stockjemle.idj.Text = selectedRow.Cells(16).Value

            bc.Text = selectedRow.Cells(15).Value
            pn.Text = selectedRow.Cells(14).Value
            categ.Text = selectedRow.Cells(13).Value
            dr.Text = selectedRow.Cells(12).Value
            costd.Text = selectedRow.Cells(11).Value
            costl.Text = selectedRow.Cells(10).Value
            pd.Text = selectedRow.Cells(9).Value
            pl.Text = selectedRow.Cells(8).Value
            bcj.Text = selectedRow.Cells(7).Value
            pdj.Text = selectedRow.Cells(6).Value
            plj.Text = selectedRow.Cells(5).Value
            qtyj1.Text = selectedRow.Cells(4).Value
            qtya.Text = selectedRow.Cells(3).Value
            qtys.Text = selectedRow.Cells(2).Value
            RichTextBox1.Text = selectedRow.Cells(1).Value
            qtym1.Text = selectedRow.Cells(0).Value
        End If


        stockDGV.Refresh()
        Button5.Enabled = True
    End Sub


    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Public Sub fillcateg()
        con.Open()
        Dim str As New SqlCommand("select distinct categ from categTbl ", con)
        Dim reader As SqlDataReader = str.ExecuteReader
        categ.Items.Clear()
        While reader.Read
            categ.Items.Add(reader("categ"))
        End While
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
    Private Function FetchDataFromSource() As Object
        ' Implement data fetching logic here
        Return New Object() ' Return some example data
    End Function

    Public Sub stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.stock' table. You can move, or remove it, as needed.
        '  Me.StockTableAdapter.Fill(Me.MARKETDataSet.stock)
        ' Bind stock to DataGridView
        'stockDGV.DataSource = AppCache.Stock

        fillcateg()
        filldr()
        LoadCategories()
        ' Set properties
        Button5.Enabled = False
        qtys.Text = "0"
        capitalsstock()

        ' Set up autocomplete (if needed)
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
        bc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        con.Close()
        Dim savedValue1 As String = My.Settings.PERCENT
        PERCENTP.Text = savedValue1
        stockDGV.Columns(16).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        ' Set the DataGridView to automatically resize rows based on cell content
        stockDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        'TODO: This line of code loads data into the 'MarketDataSet.stock' table. You can move, or remove it, as needed.
        costd.Text = "0"
        bcj.Text = ""
        pdj.Text = "0"
        plj.Text = "0"
        qtyj1.Text = "0"
        If stockDGV.Rows.Count > 0 Then
            stockDGV.ClearSelection()

            ' Select the last row
            stockDGV.Rows(stockDGV.Rows.Count - 1).Selected = True

            ' Scroll vertically to the last row
            stockDGV.FirstDisplayedScrollingRowIndex = stockDGV.Rows.Count - 1

            ' Scroll horizontally to the first column
            stockDGV.FirstDisplayedScrollingColumnIndex = 16
        End If
        stockDGV.ContextMenuStrip = cmsRow


    End Sub

    Private Sub totd_TextChanged(sender As Object, e As EventArgs) Handles totd.TextChanged
        totl.Text = Val(totd.Text) * Val(dr.Text)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If bc.Text = "" And pn.Text = "" Then
            MessageBox.Show("الاباركود و الاسم فارغان", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        ' Check if barcode already exists in MARKETDataSet.stock
        If Not String.IsNullOrWhiteSpace(bc.Text) Then
            Dim existingRows = MARKETDataSet.stock.Select("code = '" & bc.Text & "'")

            If existingRows.Length > 0 Then
                MessageBox.Show("الباركود موجود من قبل", "تكرار الباركود", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If


        ' If not exists, continue to add new row
        Dim newRow As DataRow = MARKETDataSet.stock.NewRow()

        newRow("pname") = pn.Text
        newRow("cat") = categ.Text
        newRow("code") = bc.Text

        newRow("dp") = dr.Text
        newRow("pcostd") = costd.Text
        newRow("pcostl") = costl.Text

        newRow("ppriced") = pd.Text
        newRow("ppricel") = pl.Text
        newRow("codej") = bcj.Text
        newRow("ppricedj") = pdj.Text
        newRow("ppricelj") = plj.Text
        newRow("qtyj") = qtyj1.Text
        newRow("qavailable") = qtya.Text
        newRow("qsold") = qtys.Text
        newRow("dtl") = RichTextBox1.Text
        newRow("qtym") = qtym1.Text

        ' Add the new row to the DataTable
        Me.MARKETDataSet.stock.Rows.Add(newRow)

        ' Refresh the DataGridView to reflect the changes
        stockDGV.Refresh()
        Me.Validate()
        Me.StockBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

        ' Clear fields after save
        pn.Text = ""
        bc.Text = ""
        costd.Text = "0"
        costl.Text = "0"
        pd.Text = "0"
        pl.Text = "0"
        bcj.Text = ""
        pdj.Text = "0"
        plj.Text = "0"
        qtyj1.Text = "0"
        qtym1.Text = "0"
        qtya.Text = "0"
        qtys.Text = "0"
        RichTextBox1.Text = ""

        capitalsstock()
        If stockDGV.Rows.Count > 0 Then
            stockDGV.ClearSelection()

            ' Select the last row
            stockDGV.Rows(stockDGV.Rows.Count - 1).Selected = True

            ' Scroll vertically to the last row
            stockDGV.FirstDisplayedScrollingRowIndex = stockDGV.Rows.Count - 1

            ' Scroll horizontally to the first column
            stockDGV.FirstDisplayedScrollingColumnIndex = 16
        End If


    End Sub

    ' Function to retrieve categories and open Form2




    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        UpdateData()
        Me.Validate()
        Me.StockBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        capitalsstock()
        If stockDGV.Rows.Count > 0 Then
            stockDGV.ClearSelection()

            ' Select the last row
            stockDGV.Rows(stockDGV.Rows.Count - 1).Selected = True

            ' Scroll vertically to the last row
            stockDGV.FirstDisplayedScrollingRowIndex = stockDGV.Rows.Count - 1

            ' Scroll horizontally to the first column
            stockDGV.FirstDisplayedScrollingColumnIndex = 16
        End If

    End Sub
    Private Sub UpdateData()

        If stockDGV.SelectedRows.Count > 0 Then
            ' Get the ID of the selected row
            Dim selectedRowID As Integer = Convert.ToInt32(stockDGV.SelectedRows(0).Cells(16).Value)

            ' Find the DataRow in the DataSet with the matching ID
            Dim selectedRow As DataRow() = MARKETDataSet.stock.Select("Id = " & selectedRowID)

            ' Check if the DataRow was found
            If selectedRow.Length > 0 Then
                ' Update the DataRow with values from text boxes
                selectedRow(0)("pname") = pn.Text
                selectedRow(0)("cat") = categ.Text
                selectedRow(0)("code") = bc.Text
                selectedRow(0)("dp") = dr.Text
                selectedRow(0)("pcostd") = costd.Text
                selectedRow(0)("pcostl") = costl.Text
                selectedRow(0)("ppriced") = pd.Text
                selectedRow(0)("ppricel") = pl.Text
                selectedRow(0)("codej") = bcj.Text
                selectedRow(0)("ppricedj") = pdj.Text
                selectedRow(0)("ppricelj") = plj.Text
                selectedRow(0)("qtyj") = qtyj1.Text

                selectedRow(0)("qavailable") = qtya.Text
                selectedRow(0)("qsold") = qtys.Text
                selectedRow(0)("dtl") = RichTextBox1.Text
                selectedRow(0)("qtym") = qtym1.Text
                ' Call the Update method of the DataAdapter to commit changes to the database

                MessageBox.Show("تم التعديل")
            Else
                MessageBox.Show("الرجاء اختيار سطر")
            End If
        Else
            MessageBox.Show("الرجاء اختيار سطر")
        End If


        Button5.Enabled = False
        pn.Text = ""
        bc.Text = ""
        costd.Text = "0"
        costl.Text = "0"
        pd.Text = "0"
        pl.Text = "0"
        bcj.Text = ""
        pdj.Text = "0"
        plj.Text = "0"
        qtyj1.Text = "0"
        qtym1.Text = "0"
        qtya.Text = "0"
        qtys.Text = "0"
        RichTextBox1.Text = ""
    End Sub
    Private Sub DeleteStock(stockId As Integer)

        con.Open()
        Dim trans = con.BeginTransaction()

        Try
            ' DELETE CHILDREN FIRST
            Dim cmdC As New SqlCommand(
            "DELETE FROM stock_components WHERE ParentStockId = @id",
            con, trans)

            cmdC.Parameters.AddWithValue("@id", stockId)
            cmdC.ExecuteNonQuery()

            ' THEN DELETE PARENT
            Dim cmdS As New SqlCommand(
            "DELETE FROM stock WHERE Id = @id",
            con, trans)

            cmdS.Parameters.AddWithValue("@id", stockId)
            cmdS.ExecuteNonQuery()

            trans.Commit()
            MessageBox.Show("Item and its components deleted successfully")

        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If stockDGV.SelectedRows.Count = 0 Then
            MessageBox.Show("اختر سطر للمسح")
            Exit Sub
        End If

        If MessageBox.Show("هل تريد حذف الصنف وكل مكوناته؟",
                       "تأكيد الحذف",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning) = DialogResult.No Then Exit Sub

        ' ✅ SAFE: use column name
        Dim stockId As Integer =
        CInt(stockDGV.SelectedRows(0).Cells(16).Value)

        ' ✅ Deletes components + stock safely
        DeleteStock(stockId)

        ' 🔄 Refresh
        Me.StockTableAdapter.Fill(Me.MARKETDataSet.stock)

        ' UI reset
        capitalsstock()

        pn.Text = ""
        bc.Text = ""
        costd.Text = "0"
        costl.Text = "0"
        pd.Text = "0"
        pl.Text = "0"
        bcj.Text = ""
        pdj.Text = "0"
        plj.Text = "0"
        qtyj1.Text = "0"
        qtym1.Text = "0"
        qtya.Text = "0"
        qtys.Text = "0"
        RichTextBox1.Text = ""

        If stockDGV.Rows.Count > 0 Then
            stockDGV.ClearSelection()
            stockDGV.Rows(stockDGV.Rows.Count - 1).Selected = True
            stockDGV.FirstDisplayedScrollingRowIndex = stockDGV.Rows.Count - 1
        End If
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim sheetIndex As Integer
            Dim Ex As Object
            Dim Wb As Object
            Dim Ws As Object
            Ex = CreateObject("Excel.Application")
            Wb = Ex.workbooks.add
            Dim col, row As Integer
            Dim rawData(stockDGV.Rows.Count, stockDGV.Columns.Count - 1) As Object
            For col = 0 To stockDGV.Columns.Count - 1
                rawData(0, col) = stockDGV.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To stockDGV.Columns.Count - 1
                For row = 0 To stockDGV.Rows.Count - 1
                    rawData(row + 1, col) = stockDGV.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(stockDGV.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, stockDGV.Rows.Count + 1)
            Ws.Range(excelRange, Type.Missing).Value2 = rawData
            Ws = Nothing
            Wb.SaveAs(SaveFileDialog1.FileName, Type.Missing, Type.Missing,
         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
         Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
            Wb.Close(True, Type.Missing, Type.Missing)
            Wb = Nothing
            ' Release the Application object
            Ex.Quit()
            Ex = Nothing
            ' Collect the unreferenced objects
            GC.Collect()
            MsgBox("تم النقل", MsgBoxStyle.Information)
        End If
    End Sub
    Public Function ExcelColName(ByVal Col As Integer) As String
        If Col < 0 And Col > 256 Then
            MsgBox("Invalid Argument", MsgBoxStyle.Critical)
            Return Nothing
            Exit Function
        End If
        Dim i As Int16
        Dim r As Int16
        Dim S As String
        If Col <= 26 Then
            S = Chr(Col + 64)
        Else
            r = Col Mod 26
            i = System.Math.Floor(Col / 26)
            If r = 0 Then
                r = 26
                i = i - 1
            End If
            S = Chr(i + 64) & Chr(r + 64)
        End If
        ExcelColName = S
    End Function
    Private Sub dr_TextChanged(sender As Object, e As EventArgs) Handles dr.TextChanged
        costl.Text = Math.Round(Val(costd.Text) * Val(dr.Text), 0).ToString()
        pl.Text = Math.Round(Val(pd.Text) * Val(dr.Text), 0).ToString()

    End Sub
    Private shouldstop As Boolean = False

    Private Sub costd_TextChanged(sender As Object, e As EventArgs) Handles costd.TextChanged
        If costd.Focused Then
            shouldstop = False
            costl.Text = Math.Round(Val(costd.Text) * Val(dr.Text), 0).ToString()
        Else
            shouldstop = True
        End If

        If PERCENTP.Text <> "0" Then
            pd.Text = Math.Round(Val(costd.Text) + (Val(costd.Text) * Val(PERCENTP.Text) / 100), 0).ToString()
        End If


    End Sub
    Private Sub costl_TextChanged(sender As Object, e As EventArgs) Handles costl.TextChanged
        If costl.Focused Then
            shouldstop = False
            costd.Text = Val(costl.Text) / Val(dr.Text)
            If costl.Text = "" Then
                costd.Text = "0"
            End If
        Else
            shouldstop = True
        End If
    End Sub
    Private Sub pd_TextChanged(sender As Object, e As EventArgs) Handles pd.TextChanged
        If pd.Focused Then
            shouldstop = False
            pl.Text = Math.Round(Val(pd.Text) * Val(dr.Text), 0).ToString()
        Else
            shouldstop = True
        End If

    End Sub

    Private Sub pl_TextChanged(sender As Object, e As EventArgs) Handles pl.TextChanged
        If pl.Focused Then
            shouldstop = False
            pd.Text = Val(pl.Text) / Val(dr.Text)
            If pl.Text = "" Then
                pd.Text = "0"
            End If
        Else
            shouldstop = True
        End If

    End Sub


    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim generatedCode As String = GenerateRandomCode()

        If Not CodeExistsInTable(generatedCode) Then
            bc.Text = generatedCode
            ' Optionally, you can save the code to the table here
            ' SaveCodeToTable(generatedCode)
        Else
            ' Code already exists in the table, generate a new one
            Guna2Button2.PerformClick()
        End If
    End Sub
    Private Function GenerateRandomCode() As String
        Dim random As New Random()
        Dim codeBuilder As New System.Text.StringBuilder()

        ' Generate the first digit between 1 and 9
        Dim firstDigit As Integer = random.Next(1, 10)
        codeBuilder.Append(firstDigit)

        ' Generate the remaining digits
        For i As Integer = 1 To 11 ' 12 - 1 (since we've already generated one digit)
            codeBuilder.Append(random.Next(0, 10))
        Next

        Return codeBuilder.ToString()
    End Function


    Private Function CodeExistsInTable(code As String) As Boolean
        ' Using connection As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

        Using connection As New SqlConnection(My.Settings.MARKETDBConnectionString)
            Dim query As String = "SELECT COUNT(*) FROM stock WHERE code = @Code"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Code", code)
                connection.Open()
                Dim count As Integer = CInt(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function
    Public Sub capitalsstock()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select SUM(pcostd * qavailable) From stock"
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 0
            totd.Text = num
        Else
            num = cmd.ExecuteScalar
            totd.Text = num
        End If
        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub PERCENTP_TextChanged(sender As Object, e As EventArgs) Handles PERCENTP.TextChanged
        pd.Text = Val(costd.Text) + (Val(costd.Text) * Val(PERCENTP.Text) / 100)
        pl.Text = Math.Round(Val(pd.Text) * Val(dr.Text), 0).ToString()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim numericValue As Decimal ' Change to appropriate numeric data type if needed

        ' Parse the textbox text to the appropriate numeric data type
        If Decimal.TryParse(PERCENTP.Text, numericValue) Then
            ' Save the numeric value to settings
            My.Settings.PERCENT = numericValue
            My.Settings.Save()
        Else
            MessageBox.Show("Invalid numeric value entered.")
        End If

    End Sub


    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        stockDGV.CleanFilter()
        If stockDGV.Rows.Count > 0 Then
            stockDGV.ClearSelection()

            ' Select the last row
            stockDGV.Rows(stockDGV.Rows.Count - 1).Selected = True

            ' Scroll vertically to the last row
            stockDGV.FirstDisplayedScrollingRowIndex = stockDGV.Rows.Count - 1

            ' Scroll horizontally to the first column
            stockDGV.FirstDisplayedScrollingColumnIndex = 16
        End If

    End Sub
    Private Sub LoadCategories()
        On Error Resume Next
        con.Open()
        Dim str As New SqlCommand("select distinct cat from stock ", con)
        Dim reader As SqlDataReader = str.ExecuteReader

        cat.Items.Add("جميع الاصناف") ' Add the "Show All" option
        While reader.Read
            cat.Items.Add(reader("cat"))
        End While
        con.Close()
        cat.SelectedIndex = 1 ' Default to "Show All"
    End Sub
    Public Sub GetTotalRecords()


        If cat.SelectedItem = "جميع الاصناف" Then
            Me.StockTableAdapter.Fill(Me.MARKETDataSet.stock)
        Else
            Dim cat1 As String = cat.Text
            Me.StockTableAdapter.FillBycat(Me.MARKETDataSet.stock, cat1)
        End If

    End Sub

    Private Sub cat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cat.SelectedIndexChanged

        GetTotalRecords()
        If stockDGV.Rows.Count > 0 Then
            stockDGV.ClearSelection()

            ' Select the last row
            stockDGV.Rows(stockDGV.Rows.Count - 1).Selected = True

            ' Scroll vertically to the last row
            stockDGV.FirstDisplayedScrollingRowIndex = stockDGV.Rows.Count - 1

            ' Scroll horizontally to the first column
            stockDGV.FirstDisplayedScrollingColumnIndex = 16
        End If

    End Sub




    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs)
        DATEFINISHEDFRM.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        qtypage.Show()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        pn.Text = ""
        bc.Text = ""
        costd.Text = "0"
        costl.Text = "0"
        pd.Text = "0"
        pl.Text = "0"
        bcj.Text = ""
        pdj.Text = "0"
        plj.Text = "0"
        qtyj1.Text = "0"
        qtym1.Text = "0"
        qtya.Text = "0"
        qtys.Text = "0"
        RichTextBox1.Text = ""
    End Sub
    Private Sub CheckStockEntry()
        ' If any required field is empty, generate next ID
        If String.IsNullOrWhiteSpace(bc.Text) OrElse String.IsNullOrWhiteSpace(pn.Text) OrElse String.IsNullOrWhiteSpace(categ.Text) Then
            GetNextStockId()
            Return
        End If

        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            ' Check if a record with the same code, pn, and categ exists
            Dim query As String = "SELECT COUNT(*) FROM stock WHERE code = @code AND pname = @pn AND cat = @categ"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@code", bc.Text.Trim())
                cmd.Parameters.AddWithValue("@pn", pn.Text.Trim())
                cmd.Parameters.AddWithValue("@categ", categ.Text.Trim())

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count = 0 Then
                    ' No matching entry → generate next ID
                    GetNextStockId()
                End If
            End Using
        End Using
    End Sub

    Private Sub Guna2Button5_Click_1(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Stockjemle.Show()
        Stockjemle.BringToFront()
        CheckStockEntry()
        Stockjemle.bc.Text = bcj.Text
        Stockjemle.pd.Text = pdj.Text
        Stockjemle.pl.Text = plj.Text
        Stockjemle.qtyj.Text = qtyj1.Text
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        FrmStockComposite.Show()
    End Sub
    Private Sub stockDGV_MouseDown(sender As Object, e As MouseEventArgs) _
    Handles stockDGV.MouseDown

        If e.Button = MouseButtons.Right Then
            Dim hit = stockDGV.HitTest(e.X, e.Y)

            If hit.RowIndex >= 0 Then
                stockDGV.ClearSelection()
                stockDGV.Rows(hit.RowIndex).Selected = True
                stockDGV.CurrentCell = stockDGV.Rows(hit.RowIndex).Cells(0)
            End If
        End If
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click

        If stockDGV.SelectedRows.Count = 0 Then
            MessageBox.Show("اختر صنف أولاً")
            Exit Sub
        End If

        Dim frm As New FrmStockCodes
        frm.StockId = CInt(stockDGV.SelectedRows(0).Cells(16).Value)
        frm.MainCode = stockDGV.SelectedRows(0).Cells(15).Value.ToString()
        frm.ShowDialog()
        frm.BringToFront()

    End Sub

End Class


