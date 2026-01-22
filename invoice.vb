Imports System.Data.SqlClient
Imports System.Web.UI
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Vml

Public Class invoice

    'Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub CustomerDate1_ValueChanged(sender As Object, e As EventArgs) Handles maindate1.ValueChanged
        maindate1.Value = Date.Now.AddDays(0)
    End Sub
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub supplierdgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles supplierdgv.CellClick
        On Error Resume Next
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = supplierdgv.Rows(index)
        If selectedRow Is Nothing Then
        Else

            sname.Text = selectedRow.Cells(8).Value
            cn.Text = selectedRow.Cells(7).Value
            invnum.Text = selectedRow.Cells(6).Value
            dr.Text = selectedRow.Cells(5).Value
            totpd.Text = selectedRow.Cells(4).Value
            totpl.Text = selectedRow.Cells(3).Value
            pd.Text = selectedRow.Cells(2).Value
            pl.Text = selectedRow.Cells(1).Value
        End If


        supplierdgv.Refresh()
        Button5.Enabled = True
    End Sub
    Private Sub invoiceDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles invoiceDGV.CellClick
        On Error Resume Next
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = invoiceDGV.Rows(index)
        If selectedRow Is Nothing Then
        Else

            idtxt.Text = selectedRow.Cells(18).Value
            invnum.Text = selectedRow.Cells(17).Value
            bc.Text = selectedRow.Cells(16).Value
            pn.Text = selectedRow.Cells(15).Value
            categ.SelectedValue = selectedRow.Cells(14).Value
            qty.Text = selectedRow.Cells(12).Value
            qty1.Text = selectedRow.Cells(12).Value
            cd.Text = selectedRow.Cells(11).Value
            cl.Text = selectedRow.Cells(10).Value
            pdd.Text = selectedRow.Cells(9).Value
            pll.Text = selectedRow.Cells(8).Value
            bcj.Text = selectedRow.Cells(7).Value
            pdj.Text = selectedRow.Cells(6).Value
            plj.Text = selectedRow.Cells(5).Value
            qtyj1.Text = selectedRow.Cells(4).Value
            maindate.Value = selectedRow.Cells(3).Value
            finishdate.Value = selectedRow.Cells(2).Value
            qtym1.Text = selectedRow.Cells(1).Value
        End If

        '  fillorgqty()
        invoiceDGV.Refresh()

        Guna2Button6.Enabled = True
    End Sub
    Private Sub invoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.SuppliersTblTableAdapter.FillBydate(Me.MARKETDataSet.suppliersTbl)
        'TODO: This line of code loads data into the 'MarketDataSet.invoiceTbl' table. You can move, or remove it, as needed.
        Me.InvoiceTblTableAdapter.FillBydate(Me.MARKETDataSet.invoiceTbl)

        'TODO: This line of code loads data into the 'MarketDataSet.suppliersTbl' table. You can move, or remove it, as needed.
        'Me.SuppliersTblTableAdapter.Fill(Me.MarketDataSet.suppliersTbl)
        '  stock.StockTableAdapter.Fill(stock.MarketDataSet.stock)
        suppliersdebit.SuppdebitTblTableAdapter.Fill(suppliersdebit.MARKETDataSet.suppdebitTbl)
        fillcateg()
        filldr()
        con.Open()
        Dim cmd5 As New SqlCommand("SELECT sname FROM suppliersTbl", con)
        Dim ds5 As New DataSet
        Dim da5 As New SqlDataAdapter(cmd5)
        da5.Fill(ds5, "list")
        Dim col5 As New AutoCompleteStringCollection
        Dim i5 As Integer
        For i5 = 0 To ds5.Tables(0).Rows.Count - 1
            col5.Add(ds5.Tables(0).Rows(i5)("sname").ToString())
        Next
        sname.AutoCompleteSource = AutoCompleteSource.CustomSource
        sname.AutoCompleteCustomSource = col5
        sname.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        con.Close()
        con.Open()
        Dim cmd As New SqlCommand("SELECT invnum FROM suppliersTbl", con)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(ds, "list")
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            col.Add(ds.Tables(0).Rows(i)("invnum").ToString())
        Next
        invnum.AutoCompleteSource = AutoCompleteSource.CustomSource
        invnum.AutoCompleteCustomSource = col
        invnum.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        con.Close()
        con.Open()
        Dim cmd1 As New SqlCommand("SELECT code FROM stock", con)
        Dim ds1 As New DataSet
        Dim da1 As New SqlDataAdapter(cmd1)
        da1.Fill(ds1, "list")
        Dim col1 As New AutoCompleteStringCollection
        Dim i1 As Integer
        For i1 = 0 To ds1.Tables(0).Rows.Count - 1
            col1.Add(ds1.Tables(0).Rows(i1)("code").ToString())
        Next
        bc.AutoCompleteSource = AutoCompleteSource.CustomSource
        bc.AutoCompleteCustomSource = col1
        bc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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
        pn.AutoCompleteCustomSource = col2
        pn.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        con.Close()
        Button5.Enabled = False
        Guna2Button6.Enabled = False
        Dim savedValue1 As String = My.Settings.invpercent
        PERCENTP.Text = savedValue1
        invoiceDGV.Columns(15).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        ' Set the DataGridView to automatically resize rows based on cell content
        invoiceDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        capitalsstock()
        idtxt.Text = "0"

        totpd.Text = "0"
        totpl.Text = "0"
        pd.Text = "0"
        pl.Text = "0"
        rd.Text = "0"
        rl.Text = "0"
        maindate.Value = Date.Now.AddDays(0)
        finishdate.Value = Date.Now.AddDays(0)
        If invoiceDGV.Columns.Count > 0 Then
            ' Scroll to the last column (horizontal scroll right)
            invoiceDGV.FirstDisplayedScrollingColumnIndex = invoiceDGV.Columns.Count - 1
        End If
        bcj.Text = ""
        pdj.Text = "0"
        plj.Text = "0"
        qtyj1.Text = "0"
        If supplierdgv.Rows.Count > 0 Then
            ' Scroll to the last row
            supplierdgv.FirstDisplayedScrollingRowIndex = supplierdgv.Rows.Count - 1
            ' Optionally select the last row
            supplierdgv.Rows(supplierdgv.Rows.Count - 1).Selected = True
        End If
        If invoiceDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            invoiceDGV.FirstDisplayedScrollingRowIndex = invoiceDGV.Rows.Count - 1
            ' Optionally select the last row
            invoiceDGV.Rows(invoiceDGV.Rows.Count - 1).Selected = True
        End If
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
    Public Sub fillorgqty()


        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select qa FROM stockTbl where Id=" & idtxt.Text & ""
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 0
            oqty.Text = num
        Else
            num = cmd.ExecuteScalar
            oqty.Text = num
        End If
        cmd.Dispose()
        con.Close()
    End Sub
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        If rd.Text = 0 Then
            Dim newRow As DataRow = MARKETDataSet.suppliersTbl.NewRow()

            newRow("sname") = sname.Text
            newRow("cname") = cn.Text
            newRow("invnum") = invnum.Text
            newRow("dr") = dr.Text
            newRow("totpd") = totpd.Text
            newRow("totpl") = totpl.Text
            newRow("pd") = pd.Text
            newRow("pl") = pl.Text
            newRow("date") = FormatDateTime(maindate1.Value)
            ' Add the new row to the DataTable
            Me.MARKETDataSet.suppliersTbl.Rows.Add(newRow)

            ' Refresh the DataGridView to reflect the changes
            supplierdgv.Refresh()
        Else
            Dim newRow As DataRow = MARKETDataSet.suppliersTbl.NewRow()

            newRow("sname") = sname.Text
            newRow("cname") = cn.Text
            newRow("invnum") = invnum.Text
            newRow("dr") = dr.Text
            newRow("totpd") = totpd.Text
            newRow("totpl") = totpl.Text
            newRow("pd") = pd.Text
            newRow("pl") = pl.Text
            newRow("date") = FormatDateTime(maindate1.Value)
            ' Add the new row to the DataTable
            Me.MARKETDataSet.suppliersTbl.Rows.Add(newRow)

            ' Refresh the DataGridView to reflect the changes
            supplierdgv.Refresh()

            Dim newRow1 As DataRow = suppliersdebit.MARKETDataSet.suppdebitTbl.NewRow()

            newRow1("sname") = sname.Text
            newRow1("invnum") = invnum.Text
            newRow1("debits") = rd.Text
            newRow1("credits") = "0"
            newRow1("date") = FormatDateTime(maindate1.Value)
            ' Add the new row to the DataTable
            suppliersdebit.MARKETDataSet.suppdebitTbl.Rows.Add(newRow1)

            ' Refresh the DataGridView to reflect the changes
            suppliersdebit.supplierdebitDGV.Refresh()
        End If
        Me.Validate()
        Me.SuppliersTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        suppliersdebit.Validate()
        suppliersdebit.SuppdebitTblBindingSource.EndEdit()
        suppliersdebit.TableAdapterManager.UpdateAll(suppliersdebit.MARKETDataSet)
        sname.Text = ""
        pn.Text = ""
        cn.Text = ""
        totpd.Text = "0"
        totpl.Text = "0"
        pd.Text = "0"
        pl.Text = "0"
        rd.Text = "0"
        rl.Text = "0"
        suppliersdebit.SuppdebitTblTableAdapter.Fill(suppliersdebit.MARKETDataSet.suppdebitTbl)
        dailyprofits.fillinv()
        If supplierdgv.Rows.Count > 0 Then
            ' Scroll to the last row
            supplierdgv.FirstDisplayedScrollingRowIndex = supplierdgv.Rows.Count - 1
            ' Optionally select the last row
            supplierdgv.Rows(supplierdgv.Rows.Count - 1).Selected = True
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        UpdateData()
        Me.Validate()
        Me.SuppliersTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        suppliersdebit.Validate()
        suppliersdebit.SuppdebitTblBindingSource.EndEdit()
        suppliersdebit.TableAdapterManager.UpdateAll(suppliersdebit.MARKETDataSet)

        pn.Text = ""
        cn.Text = ""
        totpd.Text = "0"
        totpl.Text = "0"
        pd.Text = "0"
        pl.Text = "0"
        rd.Text = "0"
        rl.Text = "0"
        suppliersdebit.SuppdebitTblTableAdapter.Fill(suppliersdebit.MARKETDataSet.suppdebitTbl)
        dailyprofits.fillinv()


    End Sub
    Private Sub UpdateData()
        Try
            If supplierdgv.SelectedRows.Count > 0 Then
                ' Get the index of the selected row
                Dim selectedRowIndex As Integer = supplierdgv.SelectedRows(0).Index

                ' Update the DataRow in the DataSet with values from text boxes
                Dim selectedRow As DataRow = MARKETDataSet.suppliersTbl.Rows(selectedRowIndex)

                selectedRow("sname") = sname.Text
                selectedRow("cname") = cn.Text
                selectedRow("invnum") = invnum.Text
                selectedRow("dr") = dr.Text
                selectedRow("totpd") = totpd.Text
                selectedRow("totpl") = totpl.Text
                selectedRow("pd") = pd.Text
                selectedRow("pl") = pl.Text
                selectedRow("date") = FormatDateTime(maindate1.Value) ' Update Column2 with value from TextBox2


                ' Call the Update method of the DataAdapter to commit changes to the database

                MessageBox.Show("تم التعديل")
            Else
                MessageBox.Show("الرجاء اختيار سطر")
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في التعديل: " & ex.Message)
        End Try
        Button5.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If supplierdgv.SelectedRows.Count > 0 Then
            SuppliersTblBindingNavigator.DeleteItem.PerformClick()
        Else
            MessageBox.Show("اختر سطر للمسح")
        End If
        Me.Validate()
        Me.SuppliersTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        suppliersdebit.Validate()
        suppliersdebit.SuppdebitTblBindingSource.EndEdit()
        suppliersdebit.TableAdapterManager.UpdateAll(suppliersdebit.MARKETDataSet)

        pn.Text = ""
        cn.Text = ""
        totpd.Text = "0"
        totpl.Text = "0"
        pd.Text = "0"
        pl.Text = "0"
        rd.Text = "0"
        rl.Text = "0"
        suppliersdebit.SuppdebitTblTableAdapter.Fill(suppliersdebit.MARKETDataSet.suppdebitTbl)
        dailyprofits.fillinv()


    End Sub


    Private shouldstop As Boolean = False
    Private isUpdating As Boolean = False

    Private Sub totpd_TextChanged(sender As Object, e As EventArgs) Handles totpd.TextChanged
        If isUpdating Then Exit Sub

        Dim totpdVal As Decimal
        If Not Decimal.TryParse(totpd.Text, totpdVal) Then Exit Sub

        Dim drVal As Decimal
        If Not Decimal.TryParse(dr.Text, drVal) Then Exit Sub

        Dim pdVal As Decimal
        Decimal.TryParse(pd.Text, pdVal)

        Dim plVal As Decimal
        Decimal.TryParse(pl.Text, plVal)

        isUpdating = True

        ' ✅ totpl WITHOUT decimals
        Dim totplValue As Decimal = Math.Round(drVal * totpdVal, 0)

        totpl.Text = totplValue.ToString("0")
        rd.Text = Math.Round(totpdVal - pdVal, 4).ToString()
        rl.Text = Math.Round(totplValue - plVal, 0).ToString("0")

        isUpdating = False
    End Sub

    Private Sub totpl_TextChanged(sender As Object, e As EventArgs) Handles totpl.TextChanged
        If isUpdating Then Exit Sub

        Dim totplVal As Decimal
        If Not Decimal.TryParse(totpl.Text, totplVal) Then Exit Sub

        Dim drVal As Decimal
        If Not Decimal.TryParse(dr.Text, drVal) OrElse drVal = 0 Then Exit Sub

        isUpdating = True
        totpd.Text = Math.Round(totplVal / drVal, 0).ToString()
        isUpdating = False
    End Sub
    Private Sub totpl_Leave(sender As Object, e As EventArgs) Handles totpl.Leave
        Dim v As Decimal
        If Decimal.TryParse(totpl.Text, v) Then
            totpl.Text = Math.Round(v, 0).ToString("0")
        End If
    End Sub

    Private Sub dr_TextChanged(sender As Object, e As EventArgs) Handles dr.TextChanged
        If isUpdating Then Exit Sub

        Dim drVal, totpdVal, pdVal, rdVal, cdVal, pddVal, pdjVal As Decimal

        If Not Decimal.TryParse(dr.Text, drVal) Then Exit Sub

        Decimal.TryParse(totpd.Text, totpdVal)
        Decimal.TryParse(pd.Text, pdVal)
        Decimal.TryParse(rd.Text, rdVal)
        Decimal.TryParse(cd.Text, cdVal)
        Decimal.TryParse(pdd.Text, pddVal)
        Decimal.TryParse(pdj.Text, pdjVal)

        isUpdating = True

        totpl.Text = Math.Round(drVal * totpdVal, 0).ToString("0")
        pl.Text = Math.Round(drVal * pdVal, 0).ToString("0")
        rl.Text = Math.Round(drVal * rdVal, 0).ToString("0")
        cl.Text = Math.Round(drVal * cdVal, 0).ToString("0")
        pll.Text = Math.Round(drVal * pddVal, 0).ToString("0")
        plj.Text = Math.Round(drVal * pdjVal, 0).ToString("0")

        isUpdating = False
    End Sub
    Private Sub pd_TextChanged(sender As Object, e As EventArgs) Handles pd.TextChanged
        If isUpdating OrElse Not pd.Focused Then Exit Sub

        Dim pdVal, drVal, totpdVal As Decimal

        If Not Decimal.TryParse(pd.Text, pdVal) Then Exit Sub
        Decimal.TryParse(dr.Text, drVal)
        Decimal.TryParse(totpd.Text, totpdVal)

        isUpdating = True

        pl.Text = Math.Round(drVal * pdVal, 0).ToString("0")
        rd.Text = Math.Round(totpdVal - pdVal, 4).ToString()
        Dim totplValue As Decimal = Math.Round(drVal * totpdVal, 0)
        Dim plVal As Decimal
        Decimal.TryParse(pl.Text, plVal)
        rl.Text = Math.Round(totplValue - plVal, 0).ToString("0")
        isUpdating = False
    End Sub
    Private Sub pl_TextChanged(sender As Object, e As EventArgs) Handles pl.TextChanged
        If isUpdating OrElse Not pl.Focused Then Exit Sub

        Dim plVal, drVal, totplVal As Decimal

        If Not Decimal.TryParse(pl.Text, plVal) Then Exit Sub
        If Not Decimal.TryParse(dr.Text, drVal) OrElse drVal = 0 Then Exit Sub
        Decimal.TryParse(totpl.Text, totplVal)

        isUpdating = True

        pd.Text = Math.Round(plVal / drVal, 4).ToString()
        rl.Text = Math.Round(totplVal - plVal, 0).ToString("0")

        isUpdating = False
    End Sub
    Private Sub rd_TextChanged(sender As Object, e As EventArgs) Handles rd.TextChanged
        If isUpdating OrElse Not rd.Focused Then Exit Sub

        Dim rdVal, drVal As Decimal

        If Not Decimal.TryParse(rd.Text, rdVal) Then Exit Sub
        Decimal.TryParse(dr.Text, drVal)

        isUpdating = True
        rl.Text = Math.Round(rdVal * drVal, 0).ToString("0")
        isUpdating = False
    End Sub
    Private Sub rl_TextChanged(sender As Object, e As EventArgs) Handles rl.TextChanged
        If isUpdating OrElse Not rl.Focused Then Exit Sub

        Dim rlVal, drVal As Decimal

        If Not Decimal.TryParse(rl.Text, rlVal) Then Exit Sub
        If Not Decimal.TryParse(dr.Text, drVal) OrElse drVal = 0 Then Exit Sub

        isUpdating = True
        rd.Text = Math.Round(rlVal / drVal, 4).ToString()
        isUpdating = False
    End Sub


    'invoice part
    Public Sub fillfrombc()
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim query As String = "SELECT * FROM stock WHERE code = @code"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@code", bc.Text.Trim())

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        idtxt.Text = reader(0).ToString()
                        pn.Text = reader(1).ToString()
                        categ.Text = reader(2).ToString()
                        cd.Text = reader(5).ToString()
                        cl.Text = reader(6).ToString()
                        pdd.Text = reader(7).ToString()
                        pll.Text = reader(8).ToString()
                        bcj.Text = reader(9).ToString()
                        pdj.Text = If(IsDBNull(reader(10)) OrElse String.IsNullOrWhiteSpace(reader(10).ToString()), "0", reader(10).ToString())
                        plj.Text = If(IsDBNull(reader(11)) OrElse String.IsNullOrWhiteSpace(reader(11).ToString()), "0", reader(11).ToString())
                        qtyj1.Text = If(IsDBNull(reader(12)) OrElse String.IsNullOrWhiteSpace(reader(12).ToString()), "0", reader(12).ToString())
                        Label33.Text = If(IsDBNull(reader(13)) OrElse String.IsNullOrWhiteSpace(reader(13).ToString()), "0", reader(13).ToString())
                        qtym1.Text = reader(16).ToString()
                    Else
                        ' Clear fields when no item found
                        idtxt.Text = ""
                        pn.Text = ""
                        categ.Text = ""
                        cd.Text = ""
                        cl.Text = ""
                        pdd.Text = ""
                        pll.Text = ""
                        bcj.Text = ""
                        pdj.Text = "0"
                        plj.Text = "0"
                        qtyj1.Text = "0"
                        qtym1.Text = ""
                        Label33.Text = "0"
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub bc_TextChanged(sender As Object, e As EventArgs) Handles bc.TextChanged
        If bc.Text = "" Then
            pn.Text = ""
            categ.Text = ""
            qty.Text = "1"
            cd.Text = "0"
            cl.Text = "0"
            pdd.Text = "0"
            pll.Text = "0"
            qtym1.Text = "0"
            bcj.Text = ""
            pdj.Text = "0"
            plj.Text = "0"
            qtyj1.Text = "0"
            Label33.Text = "0"
        Else
            fillfrombc()

        End If
    End Sub
    Public Sub fillfrompn()

        con.Open()
        Dim query = "select * from stock where  pname=N'" & pn.Text & "' and cat=N'" & categ.Text & "' "
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read

            idtxt.Text = reader(0).ToString()
            categ.Text = reader(2).ToString()
            bc.Text = reader(3).ToString()
            cd.Text = reader(5).ToString
            cl.Text = reader(6).ToString
            pdd.Text = reader(7).ToString
            pll.Text = reader(8).ToString
            qtym1.Text = reader(16).ToString
            pdj.Text = If(IsDBNull(reader(10)) OrElse String.IsNullOrWhiteSpace(reader(10).ToString()), "0", reader(10).ToString())
            plj.Text = If(IsDBNull(reader(11)) OrElse String.IsNullOrWhiteSpace(reader(11).ToString()), "0", reader(11).ToString())
            qtyj1.Text = If(IsDBNull(reader(12)) OrElse String.IsNullOrWhiteSpace(reader(12).ToString()), "0", reader(12).ToString())
            Label33.Text = If(IsDBNull(reader(13)) OrElse String.IsNullOrWhiteSpace(reader(13).ToString()), "0", reader(13).ToString())
        End While
        con.Close()
    End Sub
    Private Sub pn_TextChanged(sender As Object, e As EventArgs) Handles categ.SelectedIndexChanged
        If bc.Text = "" Then


            If pn.Text = "" Then
                qty.Text = "1"
                cd.Text = "0"
                cl.Text = "0"
                pdd.Text = "0"
                pll.Text = "0"
                bcj.Text = ""
                pdj.Text = "0"
                plj.Text = "0"
                qtyj1.Text = "0"
                qtym1.Text = "0"
                Label33.Text = "0"
            Else
                fillfrompn()

            End If
        End If
    End Sub
    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        Dim availableNumbers As New List(Of Integer)(Enumerable.Range(1, 100000))

        ' SQL Connection (modify connection string accordingly)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If

        Try
            con.Open()
            Dim query As String = "SELECT invnum FROM invoiceTbl"
            Using cmd As New SqlCommand(query, con)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    ' Remove existing numbers from available list
                    While reader.Read()
                        Dim invNumber As Integer
                        If Integer.TryParse(reader("invnum").ToString(), invNumber) Then
                            availableNumbers.Remove(invNumber)
                        End If
                    End While
                End Using
            End Using

            ' Assign the first available number
            If availableNumbers.Count > 0 Then
                Dim newInvNum As String = availableNumbers(0).ToString("D6") ' Format as 6-digit number
                invnum.Text = newInvNum
            Else
                MessageBox.Show("All numbers from 1 to 10 are already taken.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub fillstockid()
        Try
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                con.Open()

                ' Check if item exists in stock by pname and cat
                Using cmdCheck As New SqlCommand("SELECT TOP 1 Id, ISNULL(qavailable,0) AS qavailable FROM stock WHERE pname=@pname AND cat=@cat", con)
                    cmdCheck.Parameters.AddWithValue("@pname", pn.Text)
                    cmdCheck.Parameters.AddWithValue("@cat", categ.Text)

                    Using reader As SqlDataReader = cmdCheck.ExecuteReader()
                        If reader.Read() Then
                            ' Item exists → set Id and quantity
                            idtxt.Text = reader("Id").ToString()
                            Return
                        End If
                    End Using
                End Using

                ' If not found → get MAX(Id)+1
                Using cmd1 As New SqlCommand("SELECT ISNULL(MAX(Id), 0) + 1 FROM stock", con)
                    Dim result = cmd1.ExecuteScalar()
                    If result IsNot Nothing Then
                        idtxt.Text = result.ToString()
                    Else
                        idtxt.Text = "1"
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try


    End Sub
    Public Sub fillstockidbc()
        Try
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                con.Open()

                ' Check if item exists in stock by code
                Using cmdCheck As New SqlCommand("SELECT TOP 1 Id FROM stock WHERE code=@code", con)
                    cmdCheck.Parameters.AddWithValue("@code", bc.Text)

                    Dim resultId = cmdCheck.ExecuteScalar()

                    If resultId IsNot Nothing AndAlso Not IsDBNull(resultId) Then
                        ' Item exists → show its Id
                        idtxt.Text = resultId.ToString()
                    Else
                        ' Item does not exist → assign next available Id
                        Using cmd1 As New SqlCommand("SELECT ISNULL(MAX(Id), 0) + 1 FROM stock", con)
                            Dim result = cmd1.ExecuteScalar()
                            If result IsNot Nothing Then
                                idtxt.Text = result.ToString()
                            Else
                                idtxt.Text = "1"
                            End If
                        End Using
                    End If
                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If bc.Text = "" Then


            fillstockid()
            ' Add new row to invoiceTbl
            Dim i = Val(qty.Text)
            Dim newRow As DataRow = MARKETDataSet.invoiceTbl.NewRow()
            newRow("stockID") = idtxt.Text
            newRow("invnum") = invnum.Text
            newRow("bcode") = bc.Text
            newRow("pname") = pn.Text
            newRow("categ") = categ.Text
            newRow("dr") = Val(dr.Text)
            newRow("qty") = qty.Text
            newRow("cd") = cd.Text
            newRow("cl") = Val(cl.Text)
            newRow("pd") = pdd.Text
            newRow("pl") = Val(pll.Text)
            newRow("codej") = bcj.Text
            newRow("ppricedj") = pdj.Text
            newRow("ppricelj") = plj.Text
            newRow("qtyj") = qtyj1.Text
            newRow("date1") = FormatDateTime(maindate1.Value)
            If discheck.Checked Then
                newRow("date") = FormatDateTime(maindate.Value)
                newRow("date2") = FormatDateTime(finishdate.Value)
            Else
                newRow("date") = DBNull.Value   ' Empty in database
                newRow("date2") = DBNull.Value  ' Empty in database
            End If
            newRow("qtym") = qtym1.Text
            MARKETDataSet.invoiceTbl.Rows.Add(newRow)
            invoiceDGV.Refresh()

            ' Update or insert into stock
            Dim cmd02 As New SqlCommand
            cmd02.Connection = con
            con.Open()
            cmd02.CommandText = "SELECT SUM(qavailable) FROM stock WHERE pname=N'" & pn.Text & "' AND cat=N'" & categ.Text & "' "

            If IsDBNull(cmd02.ExecuteScalar) Then
                ' Add new stock row
                Dim newRow1 As DataRow = stock.MARKETDataSet.stock.NewRow()
                newRow1("pname") = pn.Text
                newRow1("cat") = categ.Text
                newRow1("code") = bc.Text
                newRow1("dp") = Val(dr.Text)
                newRow1("pcostd") = cd.Text
                newRow1("pcostl") = Val(cl.Text)
                newRow1("ppriced") = pdd.Text
                newRow1("ppricel") = Val(pll.Text)
                newRow1("codej") = bcj.Text
                newRow1("ppricedj") = pdj.Text
                newRow1("ppricelj") = plj.Text
                newRow1("qtyj") = qtyj1.Text
                newRow1("qavailable") = Val(qty.Text)
                newRow1("qsold") = "0"
                newRow1("dtl") = ""

                newRow1("qtym") = qtym1.Text
                stock.MARKETDataSet.stock.Rows.Add(newRow1)
                stock.stockDGV.Refresh()
            Else
                ' Update existing stock row
                Dim query As String = "UPDATE stock SET qavailable = qavailable + " & i & ", pcostd=" & cd.Text & ", pcostl=" & cl.Text & ", dp=" & dr.Text & ", ppriced=" & pdd.Text & ", ppricel=" & pll.Text & ",codej=N'" & bcj.Text & "', ppricedj=" & pdj.Text & ", ppricelj=" & plj.Text & ",qtyj=" & qtyj1.Text & " WHERE pname=N'" & pn.Text & "' AND cat=N'" & categ.Text & "' "
                Dim cmd As New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
            End If

            cmd02.Dispose()
            con.Close()

            ' Save changes
            Me.Validate()
            Me.InvoiceTblBindingSource.EndEdit()
            Me.TableAdapterManager1.UpdateAll(Me.MARKETDataSet)
            stock.Validate()
            stock.StockBindingSource.EndEdit()
            stock.TableAdapterManager.UpdateAll(stock.MARKETDataSet)

            ' Reset input fields
            bc.Text = ""
            pn.Text = ""
            categ.Text = ""
            qty.Text = "1"
            cd.Text = "0"
            cl.Text = "0"
            pdd.Text = "0"
            pll.Text = "0"
            bcj.Text = ""
            pdj.Text = "0"
            plj.Text = "0"
            qtyj1.Text = "0"

        Else
            Try
                ' Check if item exists in invoiceTbl by barcode AND date

                fillstockidbc()
                ' Add new row to invoiceTbl
                Dim i = Val(qty.Text)
                Dim newRow As DataRow = MARKETDataSet.invoiceTbl.NewRow()
                newRow("stockID") = idtxt.Text
                newRow("invnum") = invnum.Text
                newRow("bcode") = bc.Text
                newRow("pname") = pn.Text
                newRow("categ") = categ.Text
                newRow("dr") = dr.Text
                newRow("qty") = qty.Text
                newRow("cd") = cd.Text
                newRow("cl") = Val(cl.Text)
                newRow("pd") = pdd.Text
                newRow("pl") = Val(pll.Text)
                newRow("codej") = bcj.Text
                newRow("ppricedj") = pdj.Text
                newRow("ppricelj") = plj.Text
                newRow("qtyj") = qtyj1.Text
                newRow("date1") = FormatDateTime(maindate1.Value)
                If discheck.Checked Then
                    newRow("date") = FormatDateTime(maindate.Value)
                    newRow("date2") = FormatDateTime(finishdate.Value)
                Else
                    newRow("date") = DBNull.Value   ' Empty in database
                    newRow("date2") = DBNull.Value  ' Empty in database
                End If
                newRow("qtym") = qtym1.Text
                MARKETDataSet.invoiceTbl.Rows.Add(newRow)
                invoiceDGV.Refresh()

                ' Update or insert into stock
                Dim cmd02 As New SqlCommand
                cmd02.Connection = con
                con.Open()
                cmd02.CommandText = "SELECT SUM(qavailable) FROM stock WHERE code=N'" & bc.Text & "' "

                If IsDBNull(cmd02.ExecuteScalar) Then
                    ' Add new stock row
                    Dim newRow1 As DataRow = stock.MARKETDataSet.stock.NewRow()
                    newRow1("pname") = pn.Text
                    newRow1("cat") = categ.Text
                    newRow1("code") = bc.Text
                    newRow1("dp") = dr.Text
                    newRow1("pcostd") = cd.Text
                    newRow1("pcostl") = cl.Text
                    newRow1("ppriced") = pdd.Text
                    newRow1("ppricel") = pll.Text
                    newRow1("codej") = bcj.Text
                    newRow1("ppricedj") = pdj.Text
                    newRow1("ppricelj") = plj.Text
                    newRow1("qtyj") = qtyj1.Text
                    newRow1("qavailable") = qty.Text
                    newRow1("qsold") = "0"
                    newRow1("dtl") = ""

                    newRow1("qtym") = qtym1.Text
                    stock.MARKETDataSet.stock.Rows.Add(newRow1)
                    stock.stockDGV.Refresh()
                Else
                    ' Update existing stock row
                    Dim query As String = "UPDATE stock SET qavailable = qavailable + " & i & ", pcostd=" & cd.Text & ", pcostl=" & cl.Text & ", dp=" & dr.Text & ", ppriced=" & pdd.Text & ", ppricel=" & pll.Text & ",codej=N'" & bcj.Text & "', ppricedj=" & pdj.Text & ", ppricelj=" & plj.Text & ",qtyj=" & qtyj1.Text & " WHERE code=N'" & bc.Text & "' "
                    Dim cmd As New SqlCommand(query, con)
                    cmd.ExecuteNonQuery()
                End If

                cmd02.Dispose()
                con.Close()

                ' Save changes
                Me.Validate()
                Me.InvoiceTblBindingSource.EndEdit()
                Me.TableAdapterManager1.UpdateAll(Me.MARKETDataSet)
                stock.Validate()
                stock.StockBindingSource.EndEdit()
                stock.TableAdapterManager.UpdateAll(stock.MARKETDataSet)


                Dim newRow2 As DataRow = DATEFINISHEDFRM.MARKETDataSet1.invoicedateTbl.NewRow()
                newRow2("stockID") = idtxt.Text
                newRow2("invnum") = invnum.Text
                newRow2("bcode") = bc.Text
                newRow2("pname") = pn.Text
                newRow2("categ") = categ.Text
                newRow2("dr") = Val(dr.Text)
                newRow2("qty") = qty.Text
                newRow2("cd") = cd.Text
                newRow2("cl") = Val(cl.Text)
                newRow2("pd") = pdd.Text
                newRow2("pl") = Val(pll.Text)

                newRow2("date1") = FormatDateTime(maindate1.Value)
                If discheck.Checked Then
                    newRow2("date") = FormatDateTime(maindate.Value)
                    newRow2("date2") = FormatDateTime(finishdate.Value)
                Else
                    newRow2("date") = DBNull.Value   ' Empty in database
                    newRow2("date2") = DBNull.Value  ' Empty in database
                End If

                newRow2("qtym") = qtym1.Text
                newRow2("che") = 0
                DATEFINISHEDFRM.MARKETDataSet1.invoicedateTbl.Rows.Add(newRow2)
                DATEFINISHEDFRM.DGV.Refresh()
                DATEFINISHEDFRM.Validate()
                DATEFINISHEDFRM.InvoicedateTblBindingSource.EndEdit()
                DATEFINISHEDFRM.TableAdapterManager1.UpdateAll(DATEFINISHEDFRM.MARKETDataSet1)

                ' Reset input fields
                idtxt.Text = "0"
                bc.Text = ""
                pn.Text = ""
                categ.Text = ""
                qty.Text = "1"
                cd.Text = "0"
                cl.Text = "0"
                pdd.Text = "0"
                pll.Text = "0"
                bcj.Text = ""
                pdj.Text = "0"
                plj.Text = "0"
                qtyj1.Text = "0"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        '' stock.StockTableAdapter.Fill(stock.MarketDataSet.stock)
        maindate.Value = Date.Now
        capitalsstock()
        finishdate.Value = Date.Now.AddDays(0)
        If invoiceDGV.Columns.Count > 0 Then
            ' Scroll to the last column (horizontal scroll right)
            invoiceDGV.FirstDisplayedScrollingColumnIndex = invoiceDGV.Columns.Count - 1
        End If

    End Sub
    Private Sub pdj_Leave(sender As Object, e As EventArgs) Handles pdj.Leave
        If String.IsNullOrWhiteSpace(pdj.Text) Then pdj.Text = "0"
    End Sub

    Private Sub plj_Leave(sender As Object, e As EventArgs) Handles plj.Leave
        If String.IsNullOrWhiteSpace(plj.Text) Then plj.Text = "0"
    End Sub

    Private Sub qtyj1_Leave(sender As Object, e As EventArgs) Handles qtyj1.Leave
        If String.IsNullOrWhiteSpace(qtyj1.Text) Then qtyj1.Text = "0"
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If invoiceDGV.SelectedRows.Count > 0 Then
            InvoiceTblBindingNavigator.DeleteItem.PerformClick()
        Else
            MessageBox.Show("اختر سطر للمسح")
        End If
        Me.Validate()
        Me.InvoiceTblBindingSource.EndEdit()
        Me.TableAdapterManager1.UpdateAll(Me.MARKETDataSet)
        stock.Validate()
        stock.StockBindingSource.EndEdit()
        stock.TableAdapterManager.UpdateAll(stock.MARKETDataSet)
        idtxt.Text = "0"
        bc.Text = ""
        pn.Text = ""
        categ.Text = ""
        qty.Text = "1"
        cd.Text = "0"
        cl.Text = "0"
        pdd.Text = "0"
        pll.Text = "0"
        bcj.Text = ""
        pdj.Text = "0"
        plj.Text = "0"
        qtyj1.Text = "0"
        finishdate.Value = Date.Now.AddDays(0)

        maindate.Value = Date.Now.AddDays(0)
        capitalsstock()
        '   stock.StockTableAdapter.Fill(stock.MarketDataSet.stock)
        If invoiceDGV.Columns.Count > 0 Then
            ' Scroll to the last column (horizontal scroll right)
            invoiceDGV.FirstDisplayedScrollingColumnIndex = invoiceDGV.Columns.Count - 1
        End If
    End Sub

    Private Sub cd_TextChanged(sender As Object, e As EventArgs) Handles cd.TextChanged
        If cd.Focused Then
            shouldstop = False
            cl.Text = Math.Round(Val(cd.Text) * Val(dr.Text), 0).ToString()
            totc.Text = Math.Round(Val(qty.Text) * Val(cd.Text), 0).ToString()
        Else
            shouldstop = True
        End If

        If PERCENTP.Text <> "0" Then
            pdd.Text = Math.Round(Val(cd.Text) + (Val(cd.Text) * Val(PERCENTP.Text) / 100), 0).ToString()
        End If
    End Sub

    Private Sub cl_TextChanged(sender As Object, e As EventArgs) Handles cl.TextChanged
        If cl.Focused Then
            shouldstop = False
            cd.Text = (Val(cl.Text) / Val(dr.Text)).ToString() ' 🔹 No rounding
            If cl.Text = "" Then
                cd.Text = "0"
            End If
        Else
            shouldstop = True
        End If
    End Sub



    Private Sub pdd_TextChanged(sender As Object, e As EventArgs) Handles pdd.TextChanged
        If pdd.Focused Then
            shouldstop = False
            pll.Text = Math.Round(Val(pdd.Text) * Val(dr.Text), 0).ToString()
        Else
            shouldstop = True
        End If

    End Sub
    Private Sub pll_TextChanged(sender As Object, e As EventArgs) Handles pll.TextChanged
        If pll.Focused Then
            shouldstop = False
            pdd.Text = (Val(pll.Text) / Val(dr.Text)).ToString() ' 🔹 No rounding
            If pll.Text = "" Then
                pdd.Text = "0"
            End If
        Else
            shouldstop = True
        End If
    End Sub
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Dim generatedCode As String = GenerateRandomCode()

        If Not CodeExistsInTable(generatedCode) Then
            bc.Text = generatedCode
            ' Optionally, you can save the code to the table here
            ' SaveCodeToTable(generatedCode)
        Else
            ' Code already exists in the table, generate a new one
            Guna2Button7.PerformClick()
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
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.Controls.Clear()
        InitializeComponent()
        invoice_Load(e, e)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        pn.Text = ""
        cn.Text = ""
        totpd.Text = "0"
        totpl.Text = "0"
        pd.Text = "0"
        pl.Text = "0"

        rd.Text = "0"
        rl.Text = "0"
        Button5.Enabled = False
        Guna2Button6.Enabled = False
    End Sub

    Private Sub ClearInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearInvoiceToolStripMenuItem.Click
        idtxt.Text = "0"
        bc.Text = ""
        pn.Text = ""
        categ.Text = ""
        qty.Text = "1"
        cd.Text = "0"
        cl.Text = "0"
        pdd.Text = "0"
        pll.Text = "0"
        bcj.Text = ""
        pdj.Text = "0"
        plj.Text = "0"
        qtyj1.Text = "0"

        Button5.Enabled = False
        Guna2Button6.Enabled = False
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim sheetIndex As Integer
            Dim Ex As Object
            Dim Wb As Object
            Dim Ws As Object
            Ex = CreateObject("Excel.Application")
            Wb = Ex.workbooks.add
            Dim col, row As Integer
            Dim rawData(supplierdgv.Rows.Count, supplierdgv.Columns.Count - 1) As Object
            For col = 0 To supplierdgv.Columns.Count - 1
                rawData(0, col) = supplierdgv.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To supplierdgv.Columns.Count - 1
                For row = 0 To supplierdgv.Rows.Count - 1
                    rawData(row + 1, col) = supplierdgv.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(supplierdgv.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, supplierdgv.Rows.Count + 1)
            Ws.Range(excelRange).Value2 = rawData
            Ws = Nothing
            Wb.SaveAs(SaveFileDialog1.FileName)
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

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim sheetIndex As Integer
            Dim Ex As Object
            Dim Wb As Object
            Dim Ws As Object
            Ex = CreateObject("Excel.Application")
            Wb = Ex.workbooks.add
            Dim col, row As Integer
            Dim rawData(invoiceDGV.Rows.Count, invoiceDGV.Columns.Count - 1) As Object
            For col = 0 To invoiceDGV.Columns.Count - 1
                rawData(0, col) = invoiceDGV.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To invoiceDGV.Columns.Count - 1
                For row = 0 To invoiceDGV.Rows.Count - 1
                    rawData(row + 1, col) = invoiceDGV.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(invoiceDGV.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, invoiceDGV.Rows.Count + 1)
            Ws.Range(excelRange).Value2 = rawData
            Ws = Nothing
            Wb.SaveAs(SaveFileDialog1.FileName)
            Wb = Nothing
            ' Release the Application object
            Ex.Quit()
            Ex = Nothing
            ' Collect the unreferenced objects
            GC.Collect()
            MsgBox("تم النقل", MsgBoxStyle.Information)
        End If
    End Sub
    Public Sub capitalsstock()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select SUM(qty * cd) From invoiceTbl where invnum=N'" & invnum.Text & "'"
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
        pdd.Text = Val(cd.Text) + (Val(cd.Text) * Val(PERCENTP.Text) / 100)

    End Sub
    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        Dim numericValue As Decimal ' Change to appropriate numeric data type if needed

        ' Parse the textbox text to the appropriate numeric data type
        If Decimal.TryParse(PERCENTP.Text, numericValue) Then
            ' Save the numeric value to settings
            My.Settings.invpercent = numericValue
            My.Settings.Save()
        Else
            MessageBox.Show("Invalid numeric value entered.")
        End If

    End Sub

    Private Sub invnum_TextChanged(sender As Object, e As EventArgs) Handles invnum.TextChanged
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        If invnum.Text = "" Then
            totd.Text = "0"
        Else
            capitalsstock()
        End If

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        'TODO: This line of code loads data into the 'MarketDataSet.invoiceTbl' table. You can move, or remove it, as needed.
        Me.InvoiceTblTableAdapter.Fill(Me.MARKETDataSet.invoiceTbl)

    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        'TODO: This line of code loads data into the 'MarketDataSet.suppliersTbl' table. You can move, or remove it, as needed.
        Me.SuppliersTblTableAdapter.Fill(Me.MARKETDataSet.suppliersTbl)


    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click

        'TODO: This line of code loads data into the 'MarketDataSet.suppliersTbl' table. You can move, or remove it, as needed.
        Me.SuppliersTblTableAdapter.FillBydate(Me.MARKETDataSet.suppliersTbl)


    End Sub

    Private Sub Guna2Button12_Click(sender As Object, e As EventArgs) Handles Guna2Button12.Click

        'TODO: This line of code loads data into the 'MarketDataSet.invoiceTbl' table. You can move, or remove it, as needed.
        Me.InvoiceTblTableAdapter.FillBydate(Me.MARKETDataSet.invoiceTbl)

    End Sub
    Private Sub qty_TextChanged(sender As Object, e As EventArgs) Handles qty.TextChanged
        totc.Text = Val(qty.Text) * Val(cd.Text)
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Dim i As Integer = Val(qty.Text)
        Dim ii As Integer = Val(Label33.Text)
        Dim iii As Integer = Val(qty1.Text)
        Dim invDate As Date = FormatDateTime(maindate1.Value)
        '    stock.StockTableAdapter.Fill(stock.MarketDataSet.stock)

        Try
            If invoiceDGV.SelectedRows.Count > 0 Then
                ' Get the index of the selected row
                Dim selectedRowIndex As Integer = invoiceDGV.SelectedRows(0).Index

                ' Update the DataRow in the DataSet with values from text boxes
                Dim selectedRow As DataRow = MARKETDataSet.invoiceTbl.Rows(selectedRowIndex)
                selectedRow("invnum") = invnum.Text
                selectedRow("bcode") = bc.Text
                selectedRow("pname") = pn.Text
                selectedRow("categ") = categ.Text
                selectedRow("dr") = dr.Text
                selectedRow("qty") = qty.Text
                selectedRow("cd") = cd.Text
                selectedRow("cl") = cl.Text
                selectedRow("pd") = pdd.Text
                selectedRow("pl") = pll.Text
                selectedRow("codej") = bcj.Text
                selectedRow("ppricedj") = pdj.Text
                selectedRow("ppricelj") = plj.Text
                selectedRow("qtyj") = qtyj1.Text
                selectedRow("date") = invDate
                selectedRow("date1") = FormatDateTime(maindate1.Value)
                selectedRow("date2") = FormatDateTime(finishdate.Value)
                selectedRow("qtym") = qtym1.Text
                MessageBox.Show("تم التعديل")
            Else
                MessageBox.Show("الرجاء اختيار سطر")
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في التعديل: " & ex.Message)
        Finally
            con.Open()
            Dim query1 As String
            query1 = "update stock set qavailable=" & ii & " - " & iii & " where Id=" & idtxt.Text & ""
            Dim cmd1 As SqlCommand
            cmd1 = New SqlCommand(query1, con)
            cmd1.ExecuteNonQuery()
            con.Close()
            con.Open()
            Dim query As String

            query = "update stock set qavailable=qavailable + " & i & ",pcostd=" & cd.Text & ",pcostl=" & cl.Text & ", dp =" & dr.Text & " ,ppriced=" & pdd.Text & ",ppricel=" & pll.Text & ",ppricedj=" & pdj.Text & ",ppricelj=" & plj.Text & ",qtyj=" & qtyj1.Text & " where Id=" & idtxt.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            ' First, subtract the old quantity from stock based on stockid and date


            ' Save changes to the database
            Me.Validate()
            Me.InvoiceTblBindingSource.EndEdit()
            Me.TableAdapterManager1.UpdateAll(Me.MARKETDataSet)
            stock.Validate()
            stock.StockBindingSource.EndEdit()
            stock.TableAdapterManager.UpdateAll(stock.MARKETDataSet)


            ' Clear input fields
            idtxt.Text = "0"
            bc.Text = ""
            pn.Text = ""
            categ.Text = ""
            qty.Text = "1"
            cd.Text = "0"
            cl.Text = "0"
            pdd.Text = "0"
            pll.Text = "0"
            bcj.Text = ""
            pdj.Text = "0"
            plj.Text = "0"
            qtyj1.Text = "0"
            maindate.Value = Date.Now
            Guna2Button6.Enabled = False
            finishdate.Value = Date.Now.AddDays(0)

            ' Refresh stock data
            '     stock.StockTableAdapter.Fill(stock.MarketDataSet.stock)
        End Try
        capitalsstock()
    End Sub

    Private Sub Guna2Button13_Click(sender As Object, e As EventArgs) Handles Guna2Button13.Click
        DATEFINISHEDFRM.Show()
    End Sub
    Private Sub GetNextStockId()
        Try
            Dim query As String = "SELECT ISNULL(MAX(id), 0) + 1 FROM stock"
            Using cmd As New SqlCommand(query, con)
                con.Open()
                Dim nextId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                invoicejemle.idj.Text = nextId.ToString()
                invoicejemle.bc.Text = ""
                invoicejemle.pd.Text = "0"
                invoicejemle.pl.Text = "0"
                invoicejemle.qtyj.Text = "0"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting next ID: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Private Sub CheckStockId()
        If String.IsNullOrWhiteSpace(idtxt.Text) Then
            ' If idtxt is empty, just get next ID
            GetNextStockId()
            Return
        End If

        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim query As String = "SELECT COUNT(*) FROM stock WHERE id = @id"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@id", idtxt.Text.Trim())

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count = 0 Then
                    ' idtxt.Text does not exist → generate next ID
                    GetNextStockId()
                End If
            End Using
        End Using
    End Sub

    Private Sub Guna2Button14_Click(sender As Object, e As EventArgs) Handles Guna2Button14.Click
        invoicejemle.Show()
        invoicejemle.BringToFront()
        CheckStockId()
        invoicejemle.bc.Text = bcj.Text
        invoicejemle.pd.Text = pdj.Text
        invoicejemle.pl.Text = plj.Text
        invoicejemle.qtyj.Text = qtyj1.Text
    End Sub

    Private Sub Guna2Button15_Click(sender As Object, e As EventArgs) Handles Guna2Button15.Click
        invnum.Text = ""
    End Sub
End Class