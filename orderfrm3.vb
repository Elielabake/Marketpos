Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing.Printing
Imports System.IO
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DocumentFormat.OpenXml
'Imports DocumentFormat.OpenXml.Vml
Imports Guna.UI2.WinForms
Imports Microsoft.Identity.Client.ApiConfig

Public Class orderfrm3
    ' Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SAMITRONICDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Private WithEvents barcodeTimer As New Timer With {.Interval = 350}
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
        Dim query = "SELECT * FROM ordernew WHERE stockID = " & Val(idtxt.Text)
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
    Private _isFillingFromBarcode As Boolean = False

    Public Sub fillfrombc()
        If _isFillingFromBarcode Then Return
        _isFillingFromBarcode = True

        Try
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                con.Open()

                Dim query As String = "
            SELECT TOP 1 s.*
            FROM stock s
            LEFT JOIN stock_codes sc ON sc.StockId = s.Id
            WHERE s.code = @code
               OR s.codej = @code
               OR sc.AltCode = @code"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@code", bc.Text.Trim())

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            ClearFields()
                            Return
                        End If

                        ' 🔹 Common fields
                        idtxt.Text = reader("Id").ToString()
                        pn.Text = reader("pname").ToString()
                        categ.Text = reader("cat").ToString()

                        Dim scannedCode As String = bc.Text.Trim()
                        Dim mainCode As String = If(IsDBNull(reader("code")), "", reader("code").ToString())
                        Dim jomlaCode As String = If(IsDBNull(reader("codej")), "", reader("codej").ToString())

                        ' 🔹 CASE 1: جملة barcode
                        If scannedCode = jomlaCode Then
                            bc.Text = mainCode
                            pd.Text = reader("ppricedj").ToString()
                            pl.Text = reader("ppricelj").ToString()
                            qty.Text = If(IsDBNull(reader("qtyj")), "1", reader("qtyj").ToString())
                            typej.Text = "جملة"
                            Return
                        End If

                        ' 🔹 CASE 2: main OR alternative barcode
                        pd.Text = reader("ppriced").ToString()
                        cd.Text = reader("pcostd").ToString()
                        pl.Text = reader("ppricel").ToString()
                        qty.Text = "1"
                        typej.Text = "مفرق"

                        ' 🔹 Normalize barcode to parent
                        bc.Text = mainCode
                    End Using
                End Using
            End Using

        Finally
            _isFillingFromBarcode = False
        End Try
    End Sub

    Public Sub fillfrombc1()

        Try
            Dim scannedCode As String = bc.Text.Trim()
            Dim lookupCode As String = scannedCode

            ' 🔹 Weight barcode → extract PLU
            If scannedCode.Length = 13 AndAlso scannedCode.StartsWith("27") Then
                lookupCode = scannedCode.Substring(2, 5)
            End If

            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                con.Open()

                Dim query As String = "
            SELECT TOP 1 s.*
            FROM stock s
            LEFT JOIN stock_codes sc ON sc.StockId = s.Id
            WHERE s.code = @code
               OR s.codej = @code
               OR sc.AltCode = @code"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@code", lookupCode)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then Exit Sub

                        idtxt.Text = reader("Id").ToString()
                        pn.Text = reader("pname").ToString()
                        categ.Text = reader("cat").ToString()

                        pd.Text = reader("ppriced").ToString()
                        cd.Text = reader("pcostd").ToString()
                        pl.Text = reader("ppricel").ToString()
                        typej.Text = "مفرق"

                        ' normalize barcode
                        bc.Text = reader("code").ToString()
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
                fillfrombc1()
            Else

                ' Barcode doesn't meet the criteria
                MessageBox.Show("Barcode does not start with '27' or does not have 13 digits.")
            End If
        End If

    End Sub

    ' ===============================================
    ' TextChanged (barcode) — start/stop the timer
    Private _isProcessingBarcode As Boolean = False

    Private Sub bc_TextChanged(sender As Object, e As EventArgs) Handles bc.TextChanged
        If bc.Text = "" Then
            pn.Text = ""
            categ.Text = ""
            pd.Text = ""
            pl.Text = ""
            qty.Text = "1"
            cd.Text = ""

        ElseIf bc.Text.StartsWith("27") Then
            barcodeTimer.Stop()
            Dim code As String = bc.Text.Trim()


            'e.SuppressKeyPress = True   ' stop beep
            ProcessBarcode1(code)

        Else
            If _isProcessingBarcode Then Return
            barcodeTimer.Start()
        End If



    End Sub

    Private Sub barcodeTimer_Tick(sender As Object, e As EventArgs) Handles barcodeTimer.Tick
        barcodeTimer.Stop()
        If bc.Text.Trim() <> "" Then
            ProcessBarcode(bc.Text.Trim())
        End If
    End Sub
    Private Sub bc_KeyDown(sender As Object, e As KeyEventArgs) Handles bc.KeyDown
        If e.KeyCode <> Keys.Enter Then Exit Sub

        Dim code As String = bc.Text.Trim()

        If code.Length = 13 AndAlso code.StartsWith("27") Then
            e.SuppressKeyPress = True   ' stop beep
            ProcessBarcode(code)
        End If
    End Sub

    Private Sub ProcessBarcode(barcode As String)
        If _isProcessingBarcode Then Return
        _isProcessingBarcode = True

        Try

            ' ✅ Normal barcode
            fillfrombc()
            fillfromqty()
            fillqty()

        Finally
            _isProcessingBarcode = False
        End Try
    End Sub
    Private Sub ProcessBarcode1(barcode As String)

        ' 🔴 Weight barcode (27xxxxxxxxxxxxx)
        If barcode.StartsWith("27") Then
            ' sets qty
            fillfrombc1()
            If barcode.StartsWith("27") AndAlso barcode.Length = 13 Then
                RetrieveQty()
            End If ' get item
            fillfromqty()
            fillqty()
            Exit Sub           ' ⬅ VERY IMPORTANT
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
        Dim ordnumfill As Integer = If(Integer.TryParse(label33.Text, ordnumfill), ordnumfill, 0)

        Dim i As Decimal = Val(CDbl(qty.Text)) * Val(CDbl(pd.Text))
        Dim ii As Decimal = Val(CDbl(qty.Text)) * Val(CDbl(cd.Text))

        Try
            con.Open()

            ' Check if bc exists
            Dim cmdCheck As New SqlCommand("SELECT SUM(qty) FROM ordernew WHERE bc=N'" & bc.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'", con)
            Dim exists As Boolean = Not IsDBNull(cmdCheck.ExecuteScalar)

            If Not exists Then
                ' INSERT new reverse row
                Dim newRow As DataRow = MARKETDataSet.ordernew.NewRow()
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
                newRow("ordnum") = label33.Text
                newRow("costd") = -Val(cd.Text)
                newRow("profit") = -(i - ii)
                newRow("emp") = emp.Text
                newRow("typej") = typej.Text
                newRow("date") = maindate.Value

                MARKETDataSet.ordernew.Rows.Add(newRow)
                orderDGV.Refresh()
                Me.Validate()
                Me.OrdernewBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

                ' Log REVERSE INSERT using parameters
                Dim logCmd As New SqlCommand("
                INSERT INTO orderTransactions
                (actionType, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date])
                VALUES
                ('REVERSE_INSERT', @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp,@typej, @date)
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
                logCmd.Parameters.AddWithValue("@ordnum", label33.Text)
                logCmd.Parameters.AddWithValue("@costd", -Val(cd.Text))
                logCmd.Parameters.AddWithValue("@profit", -(i - ii))
                logCmd.Parameters.AddWithValue("@emp", emp.Text)
                logCmd.Parameters.AddWithValue("@typej", typej.Text)
                logCmd.Parameters.AddWithValue("@date", maindate.Value)
                logCmd.ExecuteNonQuery()

            Else
                ' UPDATE existing qty
                Dim oldQty As Integer = Convert.ToInt32(New SqlCommand("SELECT qty FROM ordernew WHERE bc=N'" & bc.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'", con).ExecuteScalar())
                Dim updateCmd As New SqlCommand("UPDATE ordernew SET qty=qty + " & qty.Text & " WHERE bc=N'" & bc.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'", con)
                updateCmd.ExecuteNonQuery()

                Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
                Me.Validate()
                Me.OrdernewBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

                ' Log REVERSE UPDATE using parameters
                Dim updatedRow As DataRow = MARKETDataSet.ordernew.Select("bc='" & bc.Text & "'")(0)
                Dim logCmd As New SqlCommand("
                INSERT INTO orderTransactions
                (actionType, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date])
                VALUES
                ('REVERSE_UPDATE', @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp,@typej, @date)
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
                logCmd.Parameters.AddWithValue("@typej", updatedRow("typej"))
                logCmd.Parameters.AddWithValue("@date", updatedRow("date"))
                logCmd.ExecuteNonQuery()

                Dim newQty As Integer = Convert.ToInt32(New SqlCommand("SELECT qty FROM ordernew WHERE bc=N'" & bc.Text & "' and ordnum=" & label33.Text & "", con).ExecuteScalar())
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


    ' ===============================================
    ' Button1_Click — only re-process barcode if product info is missing
    ' ===============================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(pn.Text) Then Exit Sub

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
        orderDGV.Refresh()



        Dim ordnumfill As Integer
        If Not Integer.TryParse(label33.Text, ordnumfill) Then
            ordnumfill = 0
        End If
        ' Force DataGridView to finish processing the added row


        'TODO: This line of code loads data into the 'MarketDataSet.Ordernew' table. You can move, or remove it, as needed.
        Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
        ScrollToLastRow()
    End Sub

    ' ===============================================
    ' Insert/Update order — respect manual PL or PD
    ' ===============================================
    Private Sub button1click()
        ' 🔒 Safety guard → no insert if essential fields are empty
        If String.IsNullOrWhiteSpace(bc.Text) OrElse String.IsNullOrWhiteSpace(pn.Text) OrElse String.IsNullOrWhiteSpace(idtxt.Text) Then
            Exit Sub
        End If

        ' Parse numeric values safely
        Dim drValue As Double = If(IsNumeric(dr.Text), Val(dr.Text), 0)
        Dim pdValue As Double = If(IsNumeric(pd.Text), Val(pd.Text), 0)
        Dim plValue As Integer = If(IsNumeric(pl.Text), Val(pl.Text), 0)
        Dim qtyValue As Double = If(IsNumeric(qty.Text), Val(qty.Text), 1)
        Dim costdValue As Double = If(IsNumeric(cd.Text), Val(cd.Text), 0)

        ' Determine final PD and PL values
        If pl.Modified AndAlso drValue <> 0 Then
            ' User typed PL → compute PD
            pdValue = plValue / drValue
        Else
            ' Otherwise compute PL from PD
            plValue = pdValue * drValue
        End If

        ' Compute totals
        Dim totdValue As Double = pdValue * qtyValue
        Dim totlValue As Integer = CInt(System.Math.Round(plValue, 0)) ' rounds to nearest integer
        Dim profitValue As Double = totdValue - (costdValue * qtyValue)


        ' Open SQL connection
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            ' Check if BC already exists
            Using cmdCheck As New SqlCommand("SELECT COUNT(*) FROM ordernew WHERE bc = @bc and ordnum=@ordnum and typej=@typej", con)
                cmdCheck.Parameters.AddWithValue("@bc", bc.Text.Trim())
                cmdCheck.Parameters.AddWithValue("@ordnum", label33.Text.Trim())
                cmdCheck.Parameters.AddWithValue("@typej", typej.Text.Trim())
                Dim exists As Boolean = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0

                If Not exists Then
                    ' INSERT new row
                    Dim newRow As DataRow = MARKETDataSet.ordernew.NewRow()
                    newRow("stockID") = idtxt.Text
                    newRow("bc") = bc.Text
                    newRow("pn") = pn.Text
                    newRow("categ") = categ.Text
                    newRow("dr") = drValue
                    newRow("pd") = pdValue
                    newRow("pl") = plValue
                    newRow("qty") = qtyValue
                    newRow("totd") = totdValue
                    newRow("totl") = totlValue
                    newRow("ordnum") = label33.Text
                    newRow("costd") = costdValue
                    newRow("profit") = profitValue
                    newRow("emp") = emp.Text
                    newRow("typej") = typej.Text
                    newRow("date") = maindate.Value

                    MARKETDataSet.ordernew.Rows.Add(newRow)
                    Me.Validate()
                    Me.OrdernewBindingSource.EndEdit()
                    For Each col As DataColumn In MARKETDataSet.ordernew.Columns
                        If IsDBNull(newRow(col.ColumnName)) Then
                            MessageBox.Show("⚠️ NULL detected in column: " & col.ColumnName)
                        End If
                    Next

                    Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

                    ' Log insertion
                    Using logCmd As New SqlCommand("
                    INSERT INTO orderTransactions 
                    (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date])
                    VALUES ('INSERT', @Id, @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp,@typej, @date)
                ", con)
                        logCmd.Parameters.AddWithValue("@Id", idtxt.Text)
                        logCmd.Parameters.AddWithValue("@stockID", idtxt.Text)
                        logCmd.Parameters.AddWithValue("@bc", bc.Text)
                        logCmd.Parameters.AddWithValue("@pn", pn.Text)
                        logCmd.Parameters.AddWithValue("@categ", categ.Text)
                        logCmd.Parameters.AddWithValue("@dr", drValue)
                        logCmd.Parameters.AddWithValue("@pd", pdValue)
                        logCmd.Parameters.AddWithValue("@pl", plValue)
                        logCmd.Parameters.AddWithValue("@qty", qtyValue)
                        logCmd.Parameters.AddWithValue("@totd", totdValue)
                        logCmd.Parameters.AddWithValue("@totl", totlValue)
                        logCmd.Parameters.AddWithValue("@ordnum", label33.Text)
                        logCmd.Parameters.AddWithValue("@costd", costdValue)
                        logCmd.Parameters.AddWithValue("@profit", profitValue)
                        logCmd.Parameters.AddWithValue("@emp", emp.Text)
                        logCmd.Parameters.AddWithValue("@typej", typej.Text)
                        logCmd.Parameters.AddWithValue("@date", maindate.Value)
                        logCmd.ExecuteNonQuery()
                    End Using

                Else
                    ' UPDATE existing row (increment quantity)
                    Using cmdUpdate As New SqlCommand("UPDATE ordernew SET qty = qty + @qty WHERE bc = @bc and ordnum=@ordnum and typej=@typej", con)
                        cmdUpdate.Parameters.AddWithValue("@qty", qtyValue)
                        cmdUpdate.Parameters.AddWithValue("@bc", bc.Text.Trim())
                        cmdUpdate.Parameters.AddWithValue("@ordnum", label33.Text.Trim())
                        cmdUpdate.Parameters.AddWithValue("@typej", typej.Text.Trim())
                        cmdUpdate.ExecuteNonQuery()
                    End Using
                    Dim ordnumfill As Integer
                    If Not Integer.TryParse(label33.Text, ordnumfill) Then
                        ordnumfill = 0
                    End If
                    'TODO: This line of code loads data into the 'MarketDataSet.Ordernew' table. You can move, or remove it, as needed.
                    Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)

                    ' Log update
                    Using logCmd As New SqlCommand("
                    INSERT INTO orderTransactions 
                    (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date])
                    SELECT 'UPDATE', Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date]
                    FROM ordernew WHERE bc = @bc and ordnum=@ordnum
                ", con)
                        logCmd.Parameters.AddWithValue("@bc", bc.Text.Trim())
                        logCmd.Parameters.AddWithValue("@ordnum", label33.Text.Trim())

                        logCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        End Using

        ' Reset fields and recalc totals
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








    Public Sub filltotcostd()

        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select Sum(profit) from Ordernew where ordnum=N'" & label33.Text & "'"
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
        Dim num As Integer = 1

        Try
            ' 1️⃣ Get MAX(ordnum) from database
            Using cmd As New SqlCommand("SELECT ISNULL(MAX(ordnum),0) FROM ordertbl1", con)
                If con.State = ConnectionState.Closed Then con.Open()
                num = Convert.ToInt32(cmd.ExecuteScalar()) + 1
                con.Close()
            End Using

            ' 2️⃣ Check all other opened tabs in orderfrm2
            If Application.OpenForms.OfType(Of orderfrm2)().Any() Then
                Dim frm2 As orderfrm2 = Application.OpenForms.OfType(Of orderfrm2)().First()

                ' Collect all label33 values from opened orderfrm3 in tabs
                Dim usedNumbers As New List(Of Integer)
                For Each tp As TabPage In frm2.Guna2TabControl1.TabPages
                    If tp.Controls.Count > 0 Then
                        Dim f As orderfrm3 = TryCast(tp.Controls(0), orderfrm3)
                        If f IsNot Nothing AndAlso Integer.TryParse(f.label33.Text, Nothing) Then
                            usedNumbers.Add(Convert.ToInt32(f.label33.Text))
                        End If
                    End If
                Next

                ' Increment until we find a free number
                While usedNumbers.Contains(num)
                    num += 1
                End While
            End If

            ' 3️⃣ Assign to label33
            label33.Text = num.ToString()


        Catch ex As Exception
            MessageBox.Show("Error generating ordnum: " & ex.Message)
        End Try
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





    Private Sub ClearFields()
        idtxt.Text = ""
        pn.Text = ""
        categ.Text = ""
        pd.Text = ""
        pl.Text = ""
        cd.Text = ""
        qty.Text = ""
        typej.Text = ""
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
            typej.Text = "مفرق"
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
                typej.Text = "مفرق"
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
            typej.Text = "جملة"
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
                typej.Text = "جملة"
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

    Private Sub UpdateFlowLayoutPanel(sender As Object, e As EventArgs)
        If flowLayoutPanelContainer Is Nothing Then Exit Sub

        Dim leftPos As Integer = orderDGV.Right + 5
        Dim topPos As Integer = categoriesComboBox.Bottom + 2
        Dim rightPos As Integer = Guna2ShadowPanel1.Right
        Dim bottomPos As Integer = Guna2Panel4.Top - 5

        If rightPos > leftPos AndAlso bottomPos > topPos Then
            flowLayoutPanelContainer.Location = New Point(leftPos, topPos)
            flowLayoutPanelContainer.Size = New Size(rightPos - leftPos, bottomPos - topPos)
        End If
    End Sub
    Public Sub orderfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ordnum1()   ' <-- this sets label33.Text correctly

        ' 2️⃣ Now we can safely parse it
        Dim ordnumfill As Integer
        If Not Integer.TryParse(label33.Text, ordnumfill) Then
            ordnumfill = 0
        End If
        'TODO: This line of code loads data into the 'MarketDataSet.Ordernew' table. You can move, or remove it, as needed.
        Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)

        ' Initialize the FlowLayoutPanel container
        flowLayoutPanelContainer = New FlowLayoutPanel() With {
    .Name = "flowLayoutPanelContainer",
    .AutoScroll = True,
    .BackColor = Color.White,
    .BorderStyle = BorderStyle.FixedSingle,
    .FlowDirection = FlowDirection.TopDown, ' Vertical stacking (change to LeftToRight if you want row-style)
    .WrapContents = False
}

        Me.Controls.Add(flowLayoutPanelContainer)
        flowLayoutPanelContainer.BringToFront()

        ' Attach resize/move handlers so the FlowLayoutPanel always follows other controls
        AddHandler Me.Resize, AddressOf UpdateFlowLayoutPanel
        AddHandler orderDGV.SizeChanged, AddressOf UpdateFlowLayoutPanel
        AddHandler orderDGV.LocationChanged, AddressOf UpdateFlowLayoutPanel
        AddHandler categoriesComboBox.SizeChanged, AddressOf UpdateFlowLayoutPanel
        AddHandler categoriesComboBox.LocationChanged, AddressOf UpdateFlowLayoutPanel
        AddHandler Guna2Panel4.SizeChanged, AddressOf UpdateFlowLayoutPanel
        AddHandler Guna2Panel4.LocationChanged, AddressOf UpdateFlowLayoutPanel
        AddHandler Guna2ShadowPanel1.SizeChanged, AddressOf UpdateFlowLayoutPanel
        AddHandler Guna2ShadowPanel1.LocationChanged, AddressOf UpdateFlowLayoutPanel

        ' Initial positioning
        UpdateFlowLayoutPanel(Nothing, EventArgs.Empty)


        ' Set its size and location based on the positions of other controls
        Dim guna2Panel2Bottom As Integer = Guna2Panel2.Bottom + 50 ' Get the bottom position of guna2Panel2
        Dim orderDGVRight As Integer = orderDGV.Right + 6 ' Get the right position of orderDGV
        Dim formWidth As Integer = Guna2Panel2.Width ' Get the width of the form (orderfrm1)
        Dim orderDGVHeight As Integer = orderDGV.Height ' Get the height of orderDGV

        ' Adjust the location to start after orderDGV and end at the right margin of the form
        flowLayoutPanelContainer.Location = New Point(orderDGVRight, guna2Panel2Bottom) ' Place it to the right of orderDGV and below guna2Panel2
        flowLayoutPanelContainer.Size = New Size(formWidth, orderDGVHeight - 48) ' Set the width to fill the space between orderDGV and the right edge of the form

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
            'TODO: This line of code loads data into the 'MarketDataSet.Ordernew' table. You can move, or remove it, as needed.
            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
            ' ordnum1()
            emp.Text = Form1.Label7.Text
            'TODO: This line of code loads data into the 'MarketDataSet.Ordernew' table. You can move, or remove it, as needed.
            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
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
            bc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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
            cn.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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
            discount.Text = "0"
            filltotcostd()
            fillfromqty()
            fillqty()
            AcceptButton = Button1
            bc.Focus()
            totl.Text = System.Math.Round(Val(totd.Text) * Val(dr.Text))

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
            'TODO: This line of code loads data into the 'MarketDataSet.Ordernew' table. You can move, or remove it, as needed.
            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
            ordnum1()
            emp.Text = Form1.Label7.Text
            'TODO: This line of code loads data into the 'MarketDataSet.Ordernew' table. You can move, or remove it, as needed.
            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
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
            bc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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
            cn.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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
            pn.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            con.Close()
            discount.Text = "0"
            filltotcostd()
            fillfromqty()
            fillqty()
            AcceptButton = Button1
            bc.Focus()
            totl.Text = System.Math.Round(Val(totd.Text) * Val(dr.Text))


        End If
        Dim savedValue1 As String = My.Settings.orderdisc
        percentd.Text = savedValue1

        If Loginpage.rtype.Text = "ثانوي" Then

            Guna2Button7.Enabled = False
            percentd.Enabled = False
            discount1.Enabled = False

        End If
        qty.Text = "1"
        orderDGV.Columns(13).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        ' Set the DataGridView to automatically resize rows based on cell content
        orderDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        FillCategories()
        wasil.Text = Val(totd.Text)
        credit.Text = Val(totd.Text)
        AcceptButton = Button1
        AddHandler orderDGV.RowsAdded, AddressOf UpdateRowCount
        AddHandler orderDGV.RowsRemoved, AddressOf UpdateRowCount
        AddHandler orderDGV.DataSourceChanged, AddressOf UpdateRowCount
        AddHandler orderDGV.CellValueChanged, AddressOf UpdateRowCount
        AddHandler orderDGV.UserDeletedRow, AddressOf UpdateRowCount
        AddHandler orderDGV.UserAddedRow, AddressOf UpdateRowCount
        ' After adding/updating rows and refreshing the DataGridView
        orderDGV.Refresh()
        tot1()
        ordnum1()
        itemMenu.Items.Add("مفرق")
        itemMenu.Items.Add("جملة")
        ' Hide first 6 columns
        For i As Integer = 0 To 5
            orderDGV.Columns(i).Visible = False
        Next

        ' Your intended percentages for 10 visible columns
        Dim columnPercent() As Double = {15, 15, 6, 12, 12, 5, 5, 12, 12, 2}

        ' Get all visible columns in order
        Dim visibleColumns = orderDGV.Columns.Cast(Of DataGridViewColumn)().Where(Function(c) c.Visible).ToList()

        ' Apply percentages safely
        For i As Integer = 0 To visibleColumns.Count - 1
            visibleColumns(i).FillWeight = columnPercent(i Mod columnPercent.Length)
        Next


    End Sub
    Public Sub orderfrm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ScrollToLastRow()
    End Sub
    Private Sub ScrollToLastRow()
        If orderDGV.Rows.Count = 0 Then Exit Sub

        Dim lastRow As Integer = orderDGV.Rows.Count - 1

        orderDGV.ClearSelection()
        orderDGV.CurrentCell = orderDGV.Rows(lastRow).Cells(10)

        orderDGV.FirstDisplayedScrollingRowIndex = lastRow
    End Sub
    Private Sub UpdateRowCount(sender As Object, e As EventArgs)
        Dim count As Integer = orderDGV.Rows.Count
        If orderDGV.AllowUserToAddRows Then count -= 1
        Guna2TextBox1.Text = count.ToString()
    End Sub


    Private Sub discount1_TextChanged(sender As Object, e As EventArgs) Handles discount1.TextChanged
        discount.Text = Val(discount1.Text) / Val(dr.Text)
    End Sub


    Private Sub dr_TextChanged(sender As Object, e As EventArgs) Handles dr.TextChanged
        pl.Text = Val(pd.Text) * Val(dr.Text)
        cash1.Text = Val(credit.Text) * Val(dr.Text)
        debit1.Text = Val(debit.Text) * Val(dr.Text)
    End Sub




    Public Sub UpdateStock(ordnum As Integer)
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim sql As String = "
        UPDATE s
        SET 
            s.qsold = s.qsold - o.qty,
            s.qavailable = s.qavailable + o.qty
        FROM stock s
        INNER JOIN ordernew o ON s.Id = o.stockID
        WHERE o.ordnum = @ordnum
        "

            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@ordnum", ordnum)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Sub UpdateStock1(ordnum As Integer)
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim sql As String = "
        UPDATE s
        SET 
            s.qsold = s.qsold + o.qty,
            s.qavailable = s.qavailable - o.qty
        FROM stock s
        INNER JOIN ordernew o ON s.Id = o.stockID
        WHERE o.ordnum = @ordnum
        "

            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@ordnum", ordnum)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub



    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click

        'CashDrawerHelper.OpenCashDrawer()
        DetectDefaultPrinter()
        cashdr()
        changelongpaper()
        If My.Settings.toggleset = "True" Then
            PDd2.Print()
        Else
            PDd1.Print()
        End If
        ' Direct Print
        ' PDd1.Print()
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

            ' Ensure that the connection is properly opened and closed

            If con.State = ConnectionState.Closed Then
                con.Open() ' Open the connection if it's not already open
            End If

            Try
                ' Create a command to calculate the sum of profit from the ordernew table
                Dim query As String = "SELECT ISNULL(SUM(profit), 0) FROM ordernew"
                Dim command As New SqlCommand(query, con)

                ' Execute the query and retrieve the sum of profits
                Dim totalProfit As Decimal = Convert.ToDecimal(command.ExecuteScalar())

                ' Now prepare to add a new row to ordertbl1
                Dim newRow1 As DataRow = allorders.MARKETDataSet.ordertbl1.NewRow()
                newRow1("ordnum") = label33.Text
                newRow1("emp") = emp.Text
                newRow1("dr") = Val(dr.Text)
                newRow1("totd") = totd.Text ' Ensure correct type conversion if needed
                newRow1("totl") = totl.Text
                newRow1("discount") = discount.Text

                ' Replace totcostd.Text with the sum of profits from ordernew
                newRow1("profit") = System.Math.Max(0, Val(totalProfit) - Val(discount.Text))

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
                allorders.OrderstblTableAdapter.InsertQuery1(ordnumfill)
                '  allorders.Ordertbl1TableAdapter.Fill(allorders.MarketDataSet.ordertbl1)



            Finally
                ' Ensure that the connection is closed when done
                If con.State = ConnectionState.Open Then
                    con.Close() ' Close the connection
                End If
            End Try
            ' Based on whether `bc` is empty, choose the appropriate query logic
            If print2.Checked = True Then
                UpdateStock(ordnumfill)
            Else
                UpdateStock1(ordnumfill)
            End If
            DeductComponentsForSale(ordnumfill)

            ' Clean up
            Me.OrdernewTableAdapter.DeleteQuery1(ordnumfill)
            ' Refresh the DataGridView
            totd.Text = "0"
            totl.Text = "0"
            totcostd.Text = "0"
            Me.OrdernewTableAdapter.DeleteQuery1(ordnumfill)
            Me.Validate()
            Me.OrdernewBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
            orderDGV.Refresh()
            tot1()
            filltotcostd()
            allorders.allorders_Load(e, e)

            cn.Text = ""
            discheck.Checked = False
            discount1.Text = "0"
            print2.Checked = False
            label33.Text = ""


            discd.Text = "0"
            bc.Focus()
            allorders.allordersDGV.Refresh()


            ordnum1()

        ElseIf debit.Text IsNot Nothing Then
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
                ' Create a command to calculate the sum of profit from the ordernew table
                Dim query As String = "SELECT ISNULL(SUM(profit), 0) FROM ordernew"
                Dim command As New SqlCommand(query, con)

                ' Execute the query and retrieve the sum of profits
                Dim totalProfit As Decimal = Convert.ToDecimal(command.ExecuteScalar())

                ' Now prepare to add a new row to ordertbl1
                Dim newRow1 As DataRow = allorders.MARKETDataSet.ordertbl1.NewRow()
                newRow1("ordnum") = label33.Text
                newRow1("emp") = emp.Text
                newRow1("dr") = Val(dr.Text)
                newRow1("totd") = totd.Text ' Ensure correct type conversion if needed
                newRow1("totl") = totl.Text
                newRow1("discount") = discount.Text

                ' Replace totcostd.Text with the sum of profits from ordernew
                newRow1("profit") = System.Math.Max(0, Val(totalProfit) - Val(discount.Text))

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
                allorders.OrderstblTableAdapter.InsertQuery1(ordnumfill)
                '  allorders.Ordertbl1TableAdapter.Fill(allorders.MarketDataSet.ordertbl1)



            Finally
                ' Ensure that the connection is closed when done
                If con.State = ConnectionState.Open Then
                    con.Close() ' Close the connection
                End If
            End Try

            ' Based on whether bc is empty, choose the appropriate query logic
            If print2.Checked = True Then
                UpdateStock(ordnumfill)
            Else
                UpdateStock1(ordnumfill)
            End If
            DeductComponentsForSale(ordnumfill)

            debitsfrm.DebitTblTableAdapter.Fill(debitsfrm.MARKETDataSet.debitTbl)
            Dim newRow3 As DataRow = debitsfrm.MARKETDataSet.debitTbl.NewRow()

            newRow3("sname") = cn.Text
            newRow3("snum") = label33.Text
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
            Me.OrdernewTableAdapter.DeleteQuery1(ordnumfill)
            ' Refresh the DataGridView
            totd.Text = "0"
            totl.Text = "0"
            totcostd.Text = "0"
            Me.OrdernewTableAdapter.DeleteQuery1(ordnumfill)
            Me.Validate()
            Me.OrdernewBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
            orderDGV.Refresh()
            tot1()
            filltotcostd()
            allorders.allorders_Load(e, e)
            cn.Text = ""
            discheck.Checked = False
            discount1.Text = "0"
            print2.Checked = False
            label33.Text = ""


            discd.Text = "0"
            bc.Focus()
            allorders.allordersDGV.Refresh()
            ordnum1()


        End If

        dailyprofits.order1()
        dailyprofits.cash1()
        dailyprofits.prof1()


        DetectDefaultPrinter()
        cashdr()
        newqty.Text = "0"
        netqty.Text = "0"
        oqty.Text = "0"
        ' After saving the order
        Dim frm2 As orderfrm2 = Application.OpenForms.OfType(Of orderfrm2)().FirstOrDefault()
        If frm2 IsNot Nothing Then
            ' Update the tab Tag for this order
            Dim currentTab As TabPage = frm2.Guna2TabControl1.SelectedTab
            If currentTab IsNot Nothing Then
                currentTab.Tag = CInt(label33.Text)
            End If

            ' Save open tabs to file
            frm2.SaveOpenTabsToFile()
        End If

    End Sub


    Public Sub DeductComponentsForSale(ordnum As Integer)

        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim sql As String = "
        UPDATE s
        SET 
            s.qavailable = s.qavailable - (o.qty * sc.QtyUsed),
            s.qsold = s.qsold + (o.qty * sc.QtyUsed)
        FROM stock s
        INNER JOIN stock_components sc ON s.Id = sc.ComponentStockId
        INNER JOIN ordernew o ON sc.ParentStockId = o.stockID
        WHERE o.ordnum = @ordnum
        "

            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@ordnum", ordnum)
                cmd.ExecuteNonQuery()
            End Using

        End Using

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

            ' Ensure that the connection is properly opened and closed

            If con.State = ConnectionState.Closed Then
                con.Open() ' Open the connection if it's not already open
            End If

            Try
                ' Create a command to calculate the sum of profit from the ordernew table
                Dim query As String = "SELECT ISNULL(SUM(profit), 0) FROM ordernew"
                Dim command As New SqlCommand(query, con)

                ' Execute the query and retrieve the sum of profits
                Dim totalProfit As Decimal = Convert.ToDecimal(command.ExecuteScalar())

                ' Now prepare to add a new row to ordertbl1
                Dim newRow1 As DataRow = allorders.MARKETDataSet.ordertbl1.NewRow()
                newRow1("ordnum") = label33.Text
                newRow1("emp") = emp.Text
                newRow1("dr") = Val(dr.Text)
                newRow1("totd") = totd.Text ' Ensure correct type conversion if needed
                newRow1("totl") = totl.Text
                newRow1("discount") = discount.Text

                ' Replace totcostd.Text with the sum of profits from ordernew
                newRow1("profit") = System.Math.Max(0, Val(totalProfit) - Val(discount.Text))

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
                allorders.OrderstblTableAdapter.InsertQuery1(ordnumfill)
                '  allorders.Ordertbl1TableAdapter.Fill(allorders.MarketDataSet.ordertbl1)



            Finally
                ' Ensure that the connection is closed when done
                If con.State = ConnectionState.Open Then
                    con.Close() ' Close the connection
                End If
            End Try
            ' Based on whether `bc` is empty, choose the appropriate query logic
            If print2.Checked = True Then
                UpdateStock(ordnumfill)
            Else
                UpdateStock1(ordnumfill)
            End If
            DeductComponentsForSale(ordnumfill)

            ' Clean up
            Me.OrdernewTableAdapter.DeleteQuery1(ordnumfill)
            ' Refresh the DataGridView
            totd.Text = "0"
            totl.Text = "0"
            totcostd.Text = "0"
            Me.OrdernewTableAdapter.DeleteQuery1(ordnumfill)
            Me.Validate()
            Me.OrdernewBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
            orderDGV.Refresh()
            tot1()
            filltotcostd()
            allorders.allorders_Load(e, e)

            cn.Text = ""
            discheck.Checked = False
            discount1.Text = "0"
            print2.Checked = False
            label33.Text = ""


            discd.Text = "0"
            bc.Focus()
            allorders.allordersDGV.Refresh()


            ordnum1()

        ElseIf debit.Text IsNot Nothing Then
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
                ' Create a command to calculate the sum of profit from the ordernew table
                Dim query As String = "SELECT ISNULL(SUM(profit), 0) FROM ordernew"
                Dim command As New SqlCommand(query, con)

                ' Execute the query and retrieve the sum of profits
                Dim totalProfit As Decimal = Convert.ToDecimal(command.ExecuteScalar())

                ' Now prepare to add a new row to ordertbl1
                Dim newRow1 As DataRow = allorders.MARKETDataSet.ordertbl1.NewRow()
                newRow1("ordnum") = label33.Text
                newRow1("emp") = emp.Text
                newRow1("dr") = Val(dr.Text)
                newRow1("totd") = totd.Text ' Ensure correct type conversion if needed
                newRow1("totl") = totl.Text
                newRow1("discount") = discount.Text

                ' Replace totcostd.Text with the sum of profits from ordernew
                newRow1("profit") = System.Math.Max(0, Val(totalProfit) - Val(discount.Text))

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
                allorders.OrderstblTableAdapter.InsertQuery1(ordnumfill)
                '  allorders.Ordertbl1TableAdapter.Fill(allorders.MarketDataSet.ordertbl1)



            Finally
                ' Ensure that the connection is closed when done
                If con.State = ConnectionState.Open Then
                    con.Close() ' Close the connection
                End If
            End Try

            ' Based on whether bc is empty, choose the appropriate query logic
            If print2.Checked = True Then
                UpdateStock(ordnumfill)
            Else
                UpdateStock1(ordnumfill)
            End If
            DeductComponentsForSale(ordnumfill)

            debitsfrm.DebitTblTableAdapter.Fill(debitsfrm.MARKETDataSet.debitTbl)
            Dim newRow3 As DataRow = debitsfrm.MARKETDataSet.debitTbl.NewRow()

            newRow3("sname") = cn.Text
            newRow3("snum") = label33.Text
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
            Me.OrdernewTableAdapter.DeleteQuery1(ordnumfill)
            ' Refresh the DataGridView
            totd.Text = "0"
            totl.Text = "0"
            totcostd.Text = "0"
            Me.OrdernewTableAdapter.DeleteQuery1(ordnumfill)
            Me.Validate()
            Me.OrdernewBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
            orderDGV.Refresh()
            tot1()
            filltotcostd()
            allorders.allorders_Load(e, e)
            cn.Text = ""
            discheck.Checked = False
            discount1.Text = "0"
            print2.Checked = False
            label33.Text = ""


            discd.Text = "0"
            bc.Focus()
            allorders.allordersDGV.Refresh()
            ordnum1()


        End If

        dailyprofits.order1()
        dailyprofits.cash1()
        dailyprofits.prof1()


        DetectDefaultPrinter()
        cashdr()
        newqty.Text = "0"
        netqty.Text = "0"
        oqty.Text = "0"
        ' After saving the order
        Dim frm2 As orderfrm2 = Application.OpenForms.OfType(Of orderfrm2)().FirstOrDefault()
        If frm2 IsNot Nothing Then
            ' Update the tab Tag for this order
            Dim currentTab As TabPage = frm2.Guna2TabControl1.SelectedTab
            If currentTab IsNot Nothing Then
                currentTab.Tag = CInt(label33.Text)
            End If

            ' Save open tabs to file
            frm2.SaveOpenTabsToFile()
        End If

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
        Dim connectionString As String = My.Settings.MARKETDBConnectionString

        Using connection As New SqlConnection(connectionString)
            ' 🔹 First calculate totd and totl normally
            Dim updateQuery As String = "UPDATE Ordernew SET totd = pd * qty, totl = pl * qty WHERE ordnum = " & label33.Text

            Using command As New SqlCommand(updateQuery, connection)
                connection.Open()
                command.ExecuteNonQuery()
            End Using

            ' 🔹 Then remove unnecessary trailing zeros from totd and totl (but keep decimal part)
            Dim cleanupQuery As String = "
            UPDATE Ordernew
            SET 
                totd = RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                    STR(pd * qty, 38, 10), '0E+00', ''), '.0000000000', ''), '.000000000', ''), '.00000000', ''), '.0000000', ''), '.000000', '')),
                totl = RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                    STR(pl * qty, 38, 10), '0E+00', ''), '.0000000000', ''), '.000000000', ''), '.00000000', ''), '.0000000', ''), '.000000', ''))
            WHERE ordnum = " & label33.Text

            Using cleanupCommand As New SqlCommand(cleanupQuery, connection)
                cleanupCommand.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdateTotdValues1()
        ' Dim connectionString As String = "Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SAMITRONICDB;Integrated Security=True"

        Dim connectionString As String = My.Settings.MARKETDBConnectionString


        Using connection As New SqlConnection(connectionString)
            Dim updateQuery As String = "UPDATE Ordernew SET profit = totd - (costd * qty) where ordnum=" & label33.Text & ""

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
            Dim updateQuery As String = "UPDATE Ordernew SET pl = ROUND(pd * dr, 0), totl = ROUND(pd * dr, 0) * qty where ordnum=" & label33.Text & ""

            Using command As New SqlCommand(updateQuery, connection)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub tot1()
        Try
            ' Validate discount
            Dim discountValue As Decimal = 0
            Decimal.TryParse(discount.Text, discountValue)

            ' Validate ordnum
            Dim ordNum As Integer
            If Not Integer.TryParse(label33.Text, ordNum) Then
                totd.Text = "0"
                Exit Sub
            End If

            ' Query database safely
            Dim total As Decimal = 0
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                Using cmd As New SqlCommand("SELECT SUM(totd) FROM Ordernew WHERE ordnum = @ordnum", con)
                    cmd.Parameters.AddWithValue("@ordnum", ordNum)
                    con.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        total = Convert.ToDecimal(result)
                    End If
                End Using
            End Using

            ' Subtract discount
            Dim finalTotal As Decimal = total - discountValue

            ' ✅ Remove unnecessary trailing zeros (but keep real decimals)
            totd.Text = finalTotal.ToString("0.####################")

        Catch ex As Exception
            MessageBox.Show("Error calculating total: " & ex.Message)
            totd.Text = "0"
        End Try
    End Sub



    Private Sub orderDGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles orderDGV.CellEndEdit
        ' Ensure the user is editing the qty column (adjust column index if needed)
        If e.ColumnIndex = 7 Then ' Assuming qty is at column index 7
            Dim newQty As Decimal

            ' Try to get the entered quantity
            If Not Decimal.TryParse(orderDGV.Rows(e.RowIndex).Cells(7).Value?.ToString(), newQty) Then
                MessageBox.Show("ادخل كمية صحيحة!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                orderDGV.Rows(e.RowIndex).Cells(7).Value = 1 ' Reset to 1 if invalid input
                Return
            End If

            ' Get the stockID for the selected row
            Dim stockID As Integer
            If Not Integer.TryParse(orderDGV.Rows(e.RowIndex).Cells(14).Value?.ToString(), stockID) Then
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
            Dim row As DataGridViewRow = orderDGV.Rows(e.RowIndex)

            Dim bcVal As String = row.Cells(14).Value?.ToString()
            Dim pnVal As String = row.Cells(13).Value?.ToString()
            Dim categVal As String = row.Cells(12).Value?.ToString()
            Dim drVal As Decimal = Convert.ToDecimal(row.Cells(11).Value)
            Dim pdVal As Decimal = Convert.ToDecimal(row.Cells(10).Value)
            Dim plVal As Integer = Convert.ToInt64(row.Cells(9).Value)
            Dim qtyVal As Decimal = Convert.ToDecimal(row.Cells(8).Value)
            Dim totdVal As Decimal = Convert.ToDecimal(row.Cells(7).Value)
            Dim totlVal As Integer = Convert.ToInt64(row.Cells(6).Value)
            Dim ordnumVal As String = row.Cells(5).Value?.ToString()
            Dim costdVal As Decimal = Convert.ToDecimal(row.Cells(4).Value)
            Dim profitVal As Decimal = Convert.ToDecimal(row.Cells(3).Value)
            Dim empVal As String = row.Cells(2).Value?.ToString()
            Dim typejVal As String = row.Cells(1).Value?.ToString()
            Dim dateVal As DateTime = Convert.ToDateTime(row.Cells(0).Value)

            orderDGV.Columns(9).DefaultCellStyle.Format = "N0"

            ' 🔹 Log the update action
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                con.Open()
                Dim logCmd As New SqlCommand("
                INSERT INTO orderTransactions
                (actionType, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date])
                VALUES ('UPDATE', @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp,@typej, @date)", con)

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
                logCmd.Parameters.AddWithValue("@typej", typejVal)
                logCmd.Parameters.AddWithValue("@date", dateVal)

                logCmd.ExecuteNonQuery()
            End Using
        End If

        ' 🔹 Save the update to database
        orderDGV.Refresh()
        Me.Validate()
        Me.OrdernewBindingSource.EndEdit()
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

        If orderDGV.Rows.Count = 0 Then
            MessageBox.Show("لا يوجد أسطر للحذف")
            Exit Sub
        End If

        Dim rowIndex As Integer = -1

        '-----------------------------------------
        ' 1️⃣ Check if a row is selected
        '-----------------------------------------
        If orderDGV.SelectedRows.Count > 0 Then
            ' A row is selected → delete it
            rowIndex = orderDGV.SelectedRows(0).Index
        Else
            ' No selection → delete last row
            rowIndex = orderDGV.Rows.Count - 1
        End If

        '-----------------------------------------
        ' 1️⃣ Get LAST ROW in DGV
        '-----------------------------------------
        Dim lastIndex As Integer = orderDGV.Rows.Count - 1
        Dim selectedRow As DataGridViewRow = orderDGV.Rows(lastIndex)

        '-----------------------------------------
        ' 2️⃣ Read values for logging
        '-----------------------------------------
        Dim stockID As String = selectedRow.Cells(15).Value.ToString()
        Dim bcVal As String = selectedRow.Cells(14).Value.ToString()
        Dim pnVal As String = selectedRow.Cells(13).Value.ToString()
        Dim categVal As String = selectedRow.Cells(12).Value.ToString()
        Dim drVal As Decimal = Convert.ToDecimal(selectedRow.Cells(11).Value)
        Dim pdVal As Decimal = Convert.ToDecimal(selectedRow.Cells(10).Value)
        Dim plVal As Decimal = Convert.ToDecimal(selectedRow.Cells(9).Value)
        Dim qtyVal As Integer = Convert.ToInt32(selectedRow.Cells(8).Value)
        Dim totdVal As Decimal = Convert.ToDecimal(selectedRow.Cells(7).Value)
        Dim totlVal As Decimal = Convert.ToDecimal(selectedRow.Cells(6).Value)
        Dim ordnumVal As String = selectedRow.Cells(5).Value.ToString()
        Dim costdVal As Decimal = Convert.ToDecimal(selectedRow.Cells(4).Value)
        Dim profitVal As Decimal = Convert.ToDecimal(selectedRow.Cells(3).Value)
        Dim empVal As String = selectedRow.Cells(2).Value.ToString()
        Dim typejVal As String = selectedRow.Cells(1).Value.ToString()
        Dim dateVal As DateTime = Convert.ToDateTime(selectedRow.Cells(0).Value)

        '-----------------------------------------
        ' 3️⃣ Log DELETE
        '-----------------------------------------
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions
            (actionType, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp, typej, [date])
            VALUES ('DELETE', @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp, @typej, @date)", con)

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
            logCmd.Parameters.AddWithValue("@typej", typejVal)
            logCmd.Parameters.AddWithValue("@date", dateVal)

            logCmd.ExecuteNonQuery()
        End Using

        '-----------------------------------------
        ' 2️⃣ Move BindingSource to that row
        '-----------------------------------------
        OrdernewBindingSource.Position = rowIndex

        '-----------------------------------------
        ' 3️⃣ Remove the row
        '-----------------------------------------
        OrdernewBindingSource.RemoveCurrent()

        '-----------------------------------------
        ' 4️⃣ Save changes
        '-----------------------------------------
        Me.Validate()
        Me.OrdernewBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

        '-----------------------------------------
        ' 5️⃣ Refresh
        '-----------------------------------------
        tot1()
        bc.Focus()
        orderDGV.Refresh()

        ' move focus to new last row
        If orderDGV.Rows.Count > 0 Then
            orderDGV.FirstDisplayedScrollingRowIndex = orderDGV.Rows.Count - 1
            orderDGV.Rows(orderDGV.Rows.Count - 1).Selected = True
        End If
    End Sub




    Private Sub discount_TextChanged(sender As Object, e As EventArgs) Handles discount.TextChanged

        tot1()
    End Sub

    Private Sub totd_TextChanged(sender As Object, e As EventArgs) Handles totd.TextChanged
        totl.Text = System.Math.Round(Val(totd.Text) * Val(dr.Text))
        credit.Text = Val(totd.Text)
        wasil.Text = Val(totd.Text)
        rad.Text = Val(wasil.Text) - Val(totd.Text)
    End Sub



    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Controls.Clear()
        InitializeComponent()
        orderfrm_Load(e, e)
    End Sub
    Private Sub newqty_TextChanged(sender As Object, e As EventArgs) Handles newqty.TextChanged
        netqty.Text = Val(oqty.Text) - Val(newqty.Text)
    End Sub

    Private Sub oqty_TextChanged(sender As Object, e As EventArgs) Handles oqty.TextChanged
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
        Dim query = "select * from ordertbl1 where ordnum=N'" & label33.Text & "' "
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable

        con.Close()

    End Sub
    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        label33.Text = ord.Text
        Dim fordr = label33.Text
        con.Open()
        Dim query As String = "INSERT INTO Ordernew (stockID,bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, date)
                       SELECT stockID,bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, date
                       FROM orderstbl
                       WHERE ordnum = @ordnum"

        Dim cmd As SqlCommand = New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@ordnum", label33.Text)
        cmd.ExecuteNonQuery()
        con.Close()
        fillord()
        Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, fordr)
        UpdateStock(fordr)
        con.Open()
        Dim query1 As String = "delete from orderstbl where ordnum= " & label33.Text & ""

        Dim cmd1 As SqlCommand = New SqlCommand(query1, con)

        cmd1.ExecuteNonQuery()
        con.Close()
        allorders.OrderstblTableAdapter.Fill(allorders.MARKETDataSet.orderstbl)

        con.Open()
        Dim query3 As String = "delete from ordertbl1 where ordnum= " & label33.Text & ""

        Dim cmd3 As SqlCommand = New SqlCommand(query3, con)
        cmd3.Parameters.AddWithValue("@ordnum", label33.Text)
        cmd3.ExecuteNonQuery()
        con.Close()
        allorders.Ordertbl1TableAdapter.Fill(allorders.MARKETDataSet.ordertbl1)
        UpdateplValues()
        UpdateTotdValues()
        UpdateTotdValues1()
        tot1()

        allorders.Ordertbl1TableAdapter.Fill(allorders.MARKETDataSet.ordertbl1)
        'TODO: This line of code loads data into the 'MarketDataSet.orderstbl' table. You can move, or remove it, as needed.
        allorders.OrderstblTableAdapter.Fill(allorders.MARKETDataSet.orderstbl)
        dailyprofits.order1()
        dailyprofits.cash1()
        dailyprofits.prof1()
        MessageBox.Show("تم ترجيع الطلب")
        ord.Text = ""
    End Sub

    Private Sub orderDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles orderDGV.CellClick
        On Error Resume Next
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = orderDGV.Rows(index)
        If selectedRow Is Nothing Then
        Else
            idtxt.Text = selectedRow.Cells(15).Value
            TextBox1.Text = selectedRow.Cells(13).Value
            TextBox4.Text = selectedRow.Cells(12).Value
        End If


        orderDGV.Refresh()
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
    Private Sub suggpl_MouseHover(sender As Object, e As EventArgs) Handles suggpl.MouseHover
        suggpl.ForeColor = Color.Black
    End Sub

    Private Sub suggpl_MouseLeave(sender As Object, e As EventArgs) Handles suggpl.MouseLeave
        suggpl.ForeColor = Color.WhiteSmoke
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
                                categoriesComboBox.SelectedIndex = -1
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
    ' Declare the menu once (for reuse)


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
        Dim ordnumfill As Integer = If(Integer.TryParse(label33.Text, ordnumfill), ordnumfill, 0)

        On Error Resume Next

        Dim i = Val(CDbl(qty.Text)) * Val(CDbl(pd.Text))
        Dim ii = Val(CDbl(qty.Text)) * Val(CDbl(cd.Text))
        Dim cmd02 As New SqlCommand
        cmd02.Connection = con
        con.Open()

        cmd02.CommandText = "select SUM(qty) From Ordernew where pn=N'" & pn.Text & "' and categ=N'" & categoriesComboBox.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'"
        Dim exists As Boolean = Not IsDBNull(cmd02.ExecuteScalar)

        If Not exists Then
            ' INSERT new reverse row
            Dim newRow As DataRow = MARKETDataSet.ordernew.NewRow()
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
            newRow("ordnum") = label33.Text
            newRow("costd") = -Val(CDbl(cd.Text))
            newRow("profit") = -(i - ii)
            newRow("emp") = emp.Text
            newRow("typej") = typej.Text
            newRow("date") = FormatDateTime(maindate.Value)

            Me.MARKETDataSet.ordernew.Rows.Add(newRow)
            orderDGV.Refresh()
            Me.Validate()
            Me.OrdernewBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' 🔹 Log REVERSE INSERT
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date])
            VALUES ('REVERSE_INSERT', @Id, @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp,@typej, @date)", con)

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
            logCmd.Parameters.AddWithValue("@ordnum", label33.Text)
            logCmd.Parameters.AddWithValue("@costd", -Val(cd.Text))
            logCmd.Parameters.AddWithValue("@profit", -(i - ii))
            logCmd.Parameters.AddWithValue("@emp", emp.Text)
            logCmd.Parameters.AddWithValue("@typej", typej.Text)
            logCmd.Parameters.AddWithValue("@date", FormatDateTime(maindate.Value))
            logCmd.ExecuteNonQuery()

        Else
            ' Get old qty
            Dim oldQty As Integer = 0
            Dim getOldQtyCmd As New SqlCommand("SELECT qty FROM ordernew WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'", con)
            Dim reader As SqlDataReader = getOldQtyCmd.ExecuteReader()
            If reader.Read() Then
                oldQty = Convert.ToInt32(reader("qty"))
            End If
            reader.Close()

            ' UPDATE qty
            Dim query As String = "update Ordernew set qty=qty + " & qty.Text & " where pn=N'" & pn.Text & "' and categ=N'" & categ.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'"
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()

            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
            Me.Validate()
            Me.OrdernewBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' 🔹 Log REVERSE UPDATE
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions 
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date])
            SELECT 'REVERSE_UPDATE', Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date]
            FROM ordernew WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "'", con)
            logCmd.ExecuteNonQuery()

            ' optional debug
            Dim newQtyCmd As New SqlCommand("SELECT qty FROM ordernew WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'", con)
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
        Dim ordnumfill As Integer = If(Integer.TryParse(label33.Text, ordnumfill), ordnumfill, 0)

        On Error Resume Next
        Dim i = Val(CDbl(qty.Text)) * Val(CDbl(pd.Text))
        Dim ii = Val(CDbl(qty.Text)) * Val(CDbl(cd.Text))
        Dim cmd02 As New SqlCommand
        cmd02.Connection = con
        con.Open()

        cmd02.CommandText = "select SUM(qty) From Ordernew where pn=N'" & pn.Text & "' and categ=N'" & categoriesComboBox.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'"
        Dim exists As Boolean = Not IsDBNull(cmd02.ExecuteScalar)

        If Not exists Then
            ' INSERT new row
            Dim newRow As DataRow = MARKETDataSet.ordernew.NewRow()
            newRow("stockID") = idtxt.Text
            newRow("bc") = bc.Text
            newRow("pn") = pn.Text
            newRow("categ") = categ.Text
            newRow("dr") = Val(dr.Text)
            newRow("pd") = Val(pd.Text)
            Dim plValue As Double = CDbl(pd.Text) * CDbl(dr.Text)
            newRow("pl") = CInt(System.Math.Round(plValue, 0, MidpointRounding.AwayFromZero))
            newRow("qty") = Val(qty.Text)
            newRow("totd") = Val(CDbl(qty.Text)) * Val(CDbl(pd.Text))
            newRow("totl") = Val(CInt(dr.Text)) * Val(CDbl(pd.Text))
            newRow("ordnum") = label33.Text
            newRow("costd") = Val(CDbl(cd.Text))
            newRow("profit") = i - ii
            newRow("emp") = emp.Text
            newRow("typej") = typej.Text
            newRow("date") = FormatDateTime(maindate.Value)

            Me.MARKETDataSet.ordernew.Rows.Add(newRow)
            orderDGV.Refresh()
            Me.Validate()
            Me.OrdernewBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' 🔹 Log INSERT
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions 
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date])
            VALUES ('INSERT', @Id, @stockID, @bc, @pn, @categ, @dr, @pd, @pl, @qty, @totd, @totl, @ordnum, @costd, @profit, @emp,@typej, @date)", con)

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
            logCmd.Parameters.AddWithValue("@ordnum", label33.Text)
            logCmd.Parameters.AddWithValue("@costd", Val(cd.Text))
            logCmd.Parameters.AddWithValue("@profit", i - ii)
            logCmd.Parameters.AddWithValue("@emp", emp.Text)
            logCmd.Parameters.AddWithValue("@typej", typej.Text)
            logCmd.Parameters.AddWithValue("@date", FormatDateTime(maindate.Value))
            logCmd.ExecuteNonQuery()

        Else
            ' Get old qty before update
            Dim oldQty As Integer = 0
            Dim getOldQtyCmd As New SqlCommand("SELECT qty FROM ordernew WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'", con)
            Dim reader As SqlDataReader = getOldQtyCmd.ExecuteReader()
            If reader.Read() Then
                oldQty = Convert.ToInt32(reader("qty"))
            End If
            reader.Close()

            ' UPDATE existing qty
            Dim query As String = "update Ordernew set qty=qty + " & qty.Text & " where pn=N'" & pn.Text & "' and categ=N'" & categ.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'"
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()

            Me.OrdernewTableAdapter.FillByord(Me.MARKETDataSet.ordernew, ordnumfill)
            Me.Validate()
            Me.OrdernewBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)

            ' 🔹 Log UPDATE (with old → new qty)
            Dim logCmd As New SqlCommand("
            INSERT INTO orderTransactions 
            (actionType, Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date])
            SELECT 'UPDATE', Id, stockID, bc, pn, categ, dr, pd, pl, qty, totd, totl, ordnum, costd, profit, emp,typej, [date]
            FROM ordernew WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "'", con)
            logCmd.ExecuteNonQuery()

            ' (Optional) also log old → new qty in Debug/MessageBox
            Dim newQtyCmd As New SqlCommand("SELECT qty FROM ordernew WHERE pn=N'" & pn.Text & "' AND categ=N'" & categ.Text & "' and ordnum=" & label33.Text & " and typej=N'" & typej.Text & "'", con)
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
        For Each row As DataGridViewRow In orderDGV.Rows
            ' Ensure the row is not empty
            If row.IsNewRow Then Continue For

            ' Get the item name or ID (depending on what identifies the item in your orderDGV)
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


    Private Sub orderDGV_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles orderDGV.DataBindingComplete
        HighlightRowsBasedOnCost()
        orderDGV.Columns(10).DefaultCellStyle.Format = "0.#####"
        orderDGV.Columns(7).DefaultCellStyle.Format = "0.#####"
        orderDGV.Columns(6).DefaultCellStyle.Format = "N0"
        orderDGV.Columns(9).DefaultCellStyle.Format = "N0"
    End Sub

    Private Sub categoriesComboBox_Click(sender As Object, e As EventArgs) Handles categoriesComboBox.Click
        FillCategories()
    End Sub





    Private Sub orderDGV_MouseDown(sender As Object, e As MouseEventArgs) Handles orderDGV.MouseDown
        ' Show context menu on right-click
        If e.Button = MouseButtons.Right Then
            Dim hitTest As DataGridView.HitTestInfo = orderDGV.HitTest(e.X, e.Y)
            If hitTest.RowIndex >= 0 Then
                orderDGV.ClearSelection()
                orderDGV.Rows(hitTest.RowIndex).Selected = True
                Guna2ContextMenuStrip2.Show(orderDGV, e.Location)
            End If
        End If
    End Sub
    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        searchform.Show()
        searchform.BringToFront()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        searchformCAT.Show()
        searchformCAT.BringToFront()
    End Sub
    ' Handler for the ToolStripMenuItem Click event
    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        If cn.Text = "" Then
            MessageBox.Show("ادخل اسم الزبون")
        Else
            prodstat.Show()
            Dim selectedRow As DataGridViewRow = orderDGV.CurrentRow
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
    ' PRINT OBJECTS
    ' =========================================
    Dim WithEvents PDd1 As New PrintDocument
    Dim PPD1 As New PrintPreviewDialog
    Dim longpaper As Integer

    ' =========================================
    ' CALCULATE PAPER HEIGHT
    ' =========================================
    Private Sub changelongpaper()

        Dim rowcount As Integer = orderDGV.Rows.Cast(Of DataGridViewRow)().
                              Where(Function(r) Not r.IsNewRow).Count()

        Dim rowHeight As Integer = 20
        Dim rowsHeight As Integer = rowcount * rowHeight

        Dim headerHeight As Integer = 120

        If IO.File.Exists(My.Settings.LogoPath) Then
            headerHeight += My.Settings.LogoHeight + 10
        End If

        longpaper = rowsHeight + headerHeight + 230
    End Sub

    ' =========================================
    ' BEGIN PRINT
    ' =========================================
    Private Sub PDd1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PDd1.BeginPrint
        changelongpaper()

        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, longpaper)
        PDd1.DefaultPageSettings = pagesetup
    End Sub

    ' =========================================
    ' PRINT PAGE
    ' =========================================
    Private Sub PDd_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PDd1.PrintPage

        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 14, FontStyle.Bold)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)

        Dim paperWidth As Integer = PDd1.DefaultPageSettings.PaperSize.Width
        Dim centermargin As Integer = paperWidth \ 2
        Dim rightmargin As Integer = paperWidth

        Dim rightAlign As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centerAlign As New StringFormat With {.Alignment = StringAlignment.Center}

        Dim rtlFormat As New StringFormat()
        With rtlFormat
            .Alignment = StringAlignment.Near
            .LineAlignment = StringAlignment.Near
            .FormatFlags = StringFormatFlags.DirectionRightToLeft
            .Trimming = StringTrimming.None
        End With

        Dim currentY As Integer = 5

        ' =========================================
        ' LOGO
        ' =========================================
        If IO.File.Exists(My.Settings.LogoPath) Then
            Using img As Image = Image.FromFile(My.Settings.LogoPath)
                Dim logoHeight As Integer = 80 ' default height, you can make it a setting
                e.Graphics.DrawImage(img, (paperWidth - 100) \ 2, currentY, 100, logoHeight)
                currentY += logoHeight + 5
            End Using
        End If

        ' =========================================
        ' STORE INFO
        ' =========================================
        e.Graphics.DrawString(My.Settings.StoreName, f10, Brushes.Black, centermargin, currentY, centerAlign)
        currentY += 18
        e.Graphics.DrawString(My.Settings.StoreAddress, f8, Brushes.Black, centermargin, currentY, centerAlign)
        currentY += 14
        e.Graphics.DrawString("تلفون: " & My.Settings.StorePhone, f8, Brushes.Black, centermargin, currentY, centerAlign)
        currentY += 22

        ' =========================================
        ' ORDER INFO
        ' =========================================
        e.Graphics.DrawString("رقم الفاتورة: " & label33.Text, f8, Brushes.Black, rightmargin, currentY, rightAlign)
        e.Graphics.DrawString(FormatDateTime(maindate.Value.Date), f8, Brushes.Black, 0, currentY)
        currentY += 12
        If My.Settings.customerin = "cni" Then
            e.Graphics.DrawString(cn.Text & ": اسم الزبون", f8, Brushes.Black, rightmargin, currentY, rightAlign)
            '  e.Graphics.DrawString(FormatDateTime(maindate.Value.Date), f8, Brushes.Black, 0, currentY)
            currentY += 12
            e.Graphics.DrawString("رقم الهاتف: " & pnn.Text, f8, Brushes.Black, rightmargin, currentY, rightAlign)
            'e.Graphics.DrawString(FormatDateTime(maindate.Value.Date), f8, Brushes.Black, 0, currentY)
            currentY += 12
        Else
        End If
        e.Graphics.DrawString("اسم الموظف: " & emp.Text, f8, Brushes.Black, 0, currentY)
        currentY += 15

        ' =========================================
        ' TABLE HEADER
        ' =========================================
        Dim colWidthTotal As Integer = 50 ' المجموع
        Dim colWidthPrice As Integer = If(My.Settings.PrintPrice, 60, 0)
        Dim colWidthQty As Integer = 50 ' الكمية

        ' Draw headers
        e.Graphics.DrawString("المجموع", f8, Brushes.Black, 0, currentY)
        If My.Settings.PrintPrice Then
            e.Graphics.DrawString("السعر", f8, Brushes.Black, 60, currentY)
        End If
        e.Graphics.DrawString("اسم المنتج", f8, Brushes.Black, paperWidth - 80, currentY)
        e.Graphics.DrawString("الكمية", f8, Brushes.Black, rightmargin, currentY, rightAlign)
        currentY += 8
        e.Graphics.DrawString(New String("*"c, 64), f8, Brushes.Black, 0, currentY)
        currentY += 6

        ' =========================================
        ' ITEMS
        ' =========================================
        For Each row As DataGridViewRow In orderDGV.Rows
            If row.IsNewRow Then Continue For

            Dim qty As String = row.Cells(8).Value.ToString()
            Dim price As Decimal
            If My.Settings.currencytype = "LBP" Then
                price = CDec(row.Cells(9).Value) ' LBP column
            Else
                price = CDec(row.Cells(10).Value) ' USD column
            End If
            Dim total As Decimal
            If My.Settings.currencytype = "LBP" Then
                total = CDec(row.Cells(6).Value) ' LBP column
            Else
                total = CDec(row.Cells(7).Value) ' USD column
            End If
            Dim itemText As String = row.Cells(13).Value.ToString()

            ' Calculate item rectangle
            Dim xLeft As Integer = colWidthTotal + If(My.Settings.PrintPrice, colWidthPrice, 0)
            Dim xRight As Integer = paperWidth - colWidthQty + 15
            Dim itemWidth As Integer = xRight - xLeft
            Dim itemRect As New RectangleF(xLeft, currentY, itemWidth, 300)

            ' Draw product name (RTL)
            e.Graphics.DrawString(itemText, f8, Brushes.Black, itemRect, rtlFormat)

            ' Measure height for wrapping
            Dim textSize As SizeF = e.Graphics.MeasureString(itemText, f8, itemRect.Size, rtlFormat)
            Dim rowHeight As Integer = System.Math.Max(15, CInt(System.Math.Ceiling(textSize.Height)))

            ' Draw numeric columns
            If My.Settings.currencytype = "LBP" Then
                e.Graphics.DrawString(total.ToString("##,##0"), f8, Brushes.Black, 0, currentY) ' المجموع always
            Else
                e.Graphics.DrawString(total.ToString("0.000"), f8, Brushes.Black, 0, currentY) ' المجموع always
            End If
            If My.Settings.PrintPrice Then
                If My.Settings.currencytype = "LBP" Then
                    e.Graphics.DrawString(price.ToString("##,##0"), f8, Brushes.Black, colWidthTotal, currentY)
                Else
                    e.Graphics.DrawString(price.ToString("0.000"), f8, Brushes.Black, colWidthTotal, currentY)
                End If

            End If
            Dim qtyInt As Integer = CInt(qty)
            e.Graphics.DrawString(qtyInt.ToString(), f8, Brushes.Black, paperWidth, currentY, rightAlign)
            '  e.Graphics.DrawString(qty, f8, Brushes.Black, paperWidth, currentY, rightAlign) ' الكمية always

            currentY += rowHeight + 4
        Next

        ' =========================================
        ' FOOTER
        ' =========================================
        e.Graphics.DrawString(New String("*"c, 64), f8, Brushes.Black, 0, currentY)
        currentY += 15
        e.Graphics.DrawString("عدد الأصناف: " & orderDGV.Rows.Cast(Of DataGridViewRow)().Where(Function(r) Not r.IsNewRow).Count(),
                          f10b, Brushes.Black, paperWidth, currentY, rightAlign)

        If My.Settings.currencytype = "LBP" Then
            currentY += 15
            e.Graphics.DrawString("المجموع ل.ل: " & FormatNumber(totl.Text, 0),
                        f10b, Brushes.Black, paperWidth, currentY, rightAlign)
        Else
            currentY += 15
            ' Convert totD.Text to Decimal first
            Dim totalAmount As Decimal = CDec(totd.Text)

            ' Draw with 3 decimals
            e.Graphics.DrawString("$ المجموع : " & totalAmount.ToString("0.000"),
                      f10b, Brushes.Black, paperWidth, currentY, rightAlign)

            currentY += 15
            e.Graphics.DrawString("المجموع ل.ل: " & FormatNumber(totl.Text, 0),
                        f10b, Brushes.Black, paperWidth, currentY, rightAlign)
        End If
        e.Graphics.DrawString("المجموع ل.ل: " & FormatNumber(totl.Text, 0),
                          f10b, Brushes.Black, paperWidth, currentY, rightAlign)
        currentY += 35
        e.Graphics.DrawString(My.Settings.INVSUBFOOT, f10, Brushes.Black, centermargin, currentY, centerAlign)
        currentY += 20
        e.Graphics.DrawString(My.Settings.INVFOOT, f10, Brushes.Black, centermargin, currentY, centerAlign)
        currentY += 20
        e.Graphics.DrawString(My.Settings.INVFOOT, f8, Brushes.Black, rightmargin, currentY, rightAlign)
        e.HasMorePages = False
    End Sub


    Private Sub AdvancedDataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles orderDGV.EditingControlShowing
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
    Private Sub AdvancedDataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles orderDGV.KeyDown
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


    '  Private isUpdating As Boolean = False

    ' ===============================================
    ' pd / pl change handlers — track manual edits and avoid recursion
    ' ===============================================
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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        suggpl.Text = Val(TextBox2.Text) * Val(dr.Text)
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        categoriesComboBox.SelectedItem = "الخضار"
    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        categoriesComboBox.SelectedItem = "فروج"
    End Sub
    ' 🔹 Get categories for مبيع الجملة
    Private Function GetCategoriesForMabieJomla() As List(Of String)
        Dim categories As New List(Of String)
        Dim query As String = "
        SELECT DISTINCT cat
        FROM stock
        WHERE (code IS NOT NULL AND code <> '')
          AND (codej IS NULL OR codej = '')
          AND ppricedj > 0
        ORDER BY cat
    "

        Try
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            categories.Add(reader("cat").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching categories: " & ex.Message)
        End Try

        Return categories
    End Function

    ' 🔹 Get items (pname) for a given category (مبيع الجملة)
    Private Function GetItemsForMabieJomla(category As String) As List(Of String)
        Dim items As New List(Of String)
        Dim query As String = "
        SELECT DISTINCT pname
        FROM stock
        WHERE cat = @cat
          AND (code IS NOT NULL AND code <> '')
          AND (codej IS NULL OR codej = '')
          AND ppricedj > 0
        ORDER BY pname
    "

        Try
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@cat", category)
                    con.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            items.Add(reader("pname").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching items: " & ex.Message)
        End Try

        Return items
    End Function

    ' 🔹 When "مبيع الجملة" button clicked
    Private Sub mbjomla_Click(sender As Object, e As EventArgs) Handles mbjomla.Click
        Try
            Dim categories As List(Of String) = GetCategoriesForMabieJomla()
            flowLayoutPanelContainer.Controls.Clear()

            If categories.Count = 0 Then
                MessageBox.Show("لا يوجد أي صنف.")
                Return
            End If

            Dim panelName As String = "Panel_MabieJomla"
            Dim panel As FlowLayoutPanel = Nothing

            If Not panelsDictionary.TryGetValue(panelName, panel) Then
                panel = New FlowLayoutPanel() With {
                .AutoScroll = True,
                .FlowDirection = FlowDirection.LeftToRight,
                .WrapContents = True,
                .BackColor = Color.White,
                .Size = flowLayoutPanelContainer.Size,
                .Location = New Point(0, 0)
            }
                panelsDictionary.Add(panelName, panel)
            Else
                panel.Controls.Clear()
            End If

            Dim counter As Integer = 0
            For Each catName As String In categories
                Dim btn As New Guna2Button() With {
                .Text = catName,
                .Width = 130,
                .Height = 42,
                .FillColor = Color.FromArgb(20, 110, 70), ' Green for wholesale
                .BorderRadius = 2,
                .Margin = New Padding(5)
            }

                ' 🔸 When category button clicked → load its items
                AddHandler btn.Click,
                Sub()
                    ShowMabieJomlaItems(catName)
                End Sub

                panel.Controls.Add(btn)
                counter += 1
                If counter Mod 4 = 0 Then panel.SetFlowBreak(btn, True)
            Next

            flowLayoutPanelContainer.Controls.Add(panel)
        Catch ex As Exception
            MessageBox.Show("An error occurred while showing مبيع الجملة: " & ex.Message)
        End Try
    End Sub

    ' 🔹 Show the items for a selected category (مبيع الجملة)
    Private Sub ShowMabieJomlaItems(category As String)
        Dim items As List(Of String) = GetItemsForMabieJomla(category)
        flowLayoutPanelContainer.Controls.Clear()

        If items.Count = 0 Then
            MessageBox.Show("لا يوجد منتج في هذا الصنف.")
            Return
        End If

        Dim panelName As String = "Panel_MabieJomla_" & category
        Dim itemPanel As FlowLayoutPanel = Nothing

        If Not panelsDictionary.TryGetValue(panelName, itemPanel) Then
            itemPanel = New FlowLayoutPanel() With {
            .AutoScroll = True,
            .FlowDirection = FlowDirection.LeftToRight,
            .WrapContents = True,
            .BackColor = Color.White,
            .Size = flowLayoutPanelContainer.Size,
            .Location = New Point(0, 0)
        }
            panelsDictionary.Add(panelName, itemPanel)
        Else
            itemPanel.Controls.Clear()
        End If

        Dim counter As Integer = 0
        For Each itemName As String In items
            Dim btnItem As New Guna2Button() With {
            .Text = itemName,
            .Width = 130,
            .Height = 42,
            .FillColor = Color.FromArgb(0, 120, 220),
            .BorderRadius = 2,
            .Margin = New Padding(5)
        }

            ' 🔸 When item button clicked
            AddHandler btnItem.Click,
            Sub()
                pn.Text = itemName
                categ.Text = category
                fillfrompnjmle()
            End Sub

            itemPanel.Controls.Add(btnItem)
            counter += 1
            If counter Mod 4 = 0 Then itemPanel.SetFlowBreak(btnItem, True)
        Next

        flowLayoutPanelContainer.Controls.Add(itemPanel)
    End Sub

    ' 🔹 Fill item info for مبيع الجملة
    Public Sub fillfrompnjmle()
        If _isProcessingBarcode Then Return ' prevent recursion
        _isProcessingBarcode = True  ' <<< added

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' First attempt: item with available stock
                Dim query As String = "SELECT TOP 1 * FROM stock WHERE pname=@pname AND cat=@cat AND qavailable > 0"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@pname", pn.Text)
                    cmd.Parameters.AddWithValue("@cat", categ.Text)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            FillStockDataWithCodeJ(reader)
                        Else
                            reader.Close()

                            ' Second attempt: ignore qavailable
                            cmd.CommandText = "SELECT TOP 1 * FROM stock WHERE pname=@pname AND cat=@cat"
                            Using reader2 As SqlDataReader = cmd.ExecuteReader()
                                If reader2.Read() Then
                                    FillStockDataWithCodeJ(reader2)
                                End If
                            End Using
                        End If
                    End Using
                End Using
            End Using
        Finally
            _isProcessingBarcode = False  ' <<< added
        End Try

        ' Recalculate total price
        If IsNumeric(pd.Text) AndAlso IsNumeric(dr.Text) Then
            pl.Text = (Val(pd.Text) * Val(dr.Text)).ToString()
        Else
            pl.Text = "0"
        End If
    End Sub

    Private Sub FillStockDataWithCodeJ(reader As SqlDataReader)
        _isFillingFromBarcode = True ' stop bc_TextChanged during updates
        Try
            ' Common fields
            idtxt.Text = reader("id").ToString()
            pn.Text = reader("pname").ToString()
            categ.Text = reader("cat").ToString()

            Dim mainCode As String = reader("code").ToString()
            Dim codeJ As String = If(IsDBNull(reader("codej")), "", reader("codej").ToString())

            ' Always use codeJ prices if codeJ exists
            bc.Text = mainCode          ' replace displayed code
            pd.Text = reader("ppricedj").ToString()
            pl.Text = reader("ppricelj").ToString()
            qty.Text = If(IsDBNull(reader("qtyj")), "", reader("qtyj").ToString())
            typej.Text = "جملة"
        Finally
            _isFillingFromBarcode = False
        End Try
    End Sub



    Private Sub FillStockData(reader As SqlDataReader)
        idtxt.Text = reader("id").ToString()
        bc.Text = reader("code").ToString()
        pd.Text = reader("ppricedj").ToString()
        cd.Text = reader("pcostd").ToString()
        qty.Text = reader("qavailable").ToString()
    End Sub


    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click

        Dim oc As ordcheck = Nothing   ' ✅ initialize

        ' Try to get already-open instance
        For Each f As Form In Application.OpenForms
            If TypeOf f Is ordcheck Then
                oc = DirectCast(f, ordcheck)
                Exit For
            End If
        Next

        ' If not open or disposed → create new
        If oc Is Nothing OrElse oc.IsDisposed Then
            oc = New ordcheck()
        End If

        ' Pass data BEFORE showing
        oc.OrderNumber = CInt(label33.Text)
        oc.DrValue = dr.Text
        oc.StartPosition = FormStartPosition.CenterScreen
        oc.TopMost = True

        oc.Show()
        oc.BringToFront()

    End Sub
    Private Sub SetupA4(doc As PrintDocument)
        With doc.DefaultPageSettings
            .PaperSize = New PaperSize("A4", 827, 1169)
            .Margins = New Margins(10, 10, 10, 10)
            .Landscape = False
        End With
        doc.OriginAtMargins = True
    End Sub


    Private Sub SetupReceipt(doc As PrintDocument)
        With doc.DefaultPageSettings
            .PaperSize = New PaperSize("Receipt", 315, 1000) ' 80mm
            .Margins = New Margins(10, 10, 10, 10)
            .Landscape = False
        End With
        doc.OriginAtMargins = True
    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        'CashDrawerHelper.OpenCashDrawer()
        If My.Settings.toggleset = "True" Then
            ' ===== A4 PREVIEW =====
            SetupA4(PDd2)
            PPD2.Document = PDd2
            PPD2.WindowState = FormWindowState.Maximized
            PPD2.PrintPreviewControl.Zoom = 1.0
            PPD2.ShowDialog()
        Else
            DetectDefaultPrinter()
            cashdr()
            changelongpaper()
            PPD1.Document = PDd1
            PPD1.ShowDialog()
        End If

    End Sub




    Public Sub ReloadData3()
        OrdernewBindingSource.DataSource = Nothing
        OrdernewTableAdapter.Fill(MARKETDataSet.ordernew)
        OrdernewBindingSource.DataSource = MARKETDataSet.ordernew
    End Sub


    Dim WithEvents PDd2 As New PrintDocument
    Dim PPD2 As New PrintPreviewDialog
    Private Sub SetupPrintPage()
        With PDd2.DefaultPageSettings
            .PaperSize = New PaperSize("A4", 827, 1169) ' A4 Portrait
            .Margins = New Margins(40, 40, 40, 40)
        End With

        PDd2.OriginAtMargins = True
    End Sub


    Private Sub ShowPrintPreview()
        SetupPrintPage()

        PPD2.Document = PDd2
        PPD2.WindowState = FormWindowState.Maximized
        PPD2.PrintPreviewControl.Zoom = 1.0

        PPD2.ShowDialog()
    End Sub


    Private currentPage As Integer = 1
    Private rowIndex As Integer = 0
    Private rowsPerPage As Integer
    Private pageHeight As Integer
    Private pageWidth As Integer
    Private Shadows margin As Integer = 50
    Private headerHeight As Integer = 80
    Private titleHeight As Integer = 40
    Private titleHeight1 As Integer = 50
    Private rowHeight As Integer = 40 ' Default row height

    Private Sub PDd2_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PDd2.PrintPage
        ' Set up fonts and pens
        Dim fontHeader As New Font("Times New Roman", 14, FontStyle.Bold)
        Dim fontTitle As New Font("Times New Roman", 25, FontStyle.Bold)
        Dim fontBody As New Font("Times New Roman", 16)
        Dim fontBodySmall As New Font("Times New Roman", 14)
        Dim borderPen As New Pen(Color.Black, 2) ' Pen for drawing borders
        Dim linePen As New Pen(Color.Black, 1) ' Pen for cell lines

        ' Set up page dimensions and margins
        pageHeight = e.PageBounds.Height
        pageWidth = e.PageBounds.Width
        rowsPerPage = CInt((pageHeight - 2 * margin - headerHeight - titleHeight) / rowHeight)

        ' Draw header and title
        Dim leftHeaderRect As New Rectangle(margin, margin, 250, headerHeight)
        Dim rightHeaderRect As New Rectangle(pageWidth - 250, margin, 200, headerHeight)
        Dim titleRect As New Rectangle(leftHeaderRect.Right + 10, margin, pageWidth - leftHeaderRect.Width - rightHeaderRect.Width - 30, titleHeight)
        Dim titleRect1 As New Rectangle(leftHeaderRect.Right + 120, margin, pageWidth - leftHeaderRect.Width - rightHeaderRect.Width - 150, titleHeight1)

        Dim mainTableRect As New Rectangle(margin, margin + headerHeight + 20, pageWidth - 2 * margin, 1) ' Initial height is 1

        ' Draw header rectangles
        e.Graphics.DrawRectangle(borderPen, leftHeaderRect)
        e.Graphics.DrawString(cn.Text & ":اسم الزبون", fontHeader, Brushes.Black, New RectangleF(leftHeaderRect.X, leftHeaderRect.Y + 10, leftHeaderRect.Width - 10, headerHeight), New StringFormat With {.Alignment = StringAlignment.Far})
        e.Graphics.DrawString("رقم الهاتف: " & pnn.Text, fontHeader, Brushes.Black, New RectangleF(leftHeaderRect.X, leftHeaderRect.Y + 32, leftHeaderRect.Width - 10, headerHeight), New StringFormat With {.Alignment = StringAlignment.Far})
        e.Graphics.DrawString("رقم الطلب: " & orderfrm2.ordnum.Text, fontHeader, Brushes.Black, New RectangleF(leftHeaderRect.X, leftHeaderRect.Y + 58, leftHeaderRect.Width - 10, headerHeight), New StringFormat With {.Alignment = StringAlignment.Far})
        e.Graphics.DrawRectangle(borderPen, rightHeaderRect)
        Dim rightAlign As New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Near}
        e.Graphics.DrawString("التاريخ: " & DateTime.Now.ToString("yyyy-MM-dd"), fontHeader, Brushes.Black, New RectangleF(rightHeaderRect.X, rightHeaderRect.Y + 10, rightHeaderRect.Width - 10, headerHeight), rightAlign)
        e.Graphics.DrawString("العملة: الدولار", fontHeader, Brushes.Black, New RectangleF(rightHeaderRect.X, rightHeaderRect.Y + 35, rightHeaderRect.Width - 10, headerHeight), rightAlign)
        Dim currentY As Integer = 5

        ' =========================================
        ' LOGO
        ' =========================================
        If IO.File.Exists(My.Settings.LogoPath1) Then
            Using img As Image = Image.FromFile(My.Settings.LogoPath1)
                Dim logoRect As New RectangleF(
            titleRect1.X - 100,
            titleRect1.Y,
            titleRect1.Width,
            titleHeight1
        )

                e.Graphics.DrawImage(img, logoRect)
            End Using

            e.Graphics.DrawString(My.Settings.storename1, fontTitle, Brushes.Black, New RectangleF(titleRect.X - 55, titleRect.Y + 55, titleRect.Width, titleHeight), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Else
            e.Graphics.DrawString(My.Settings.storename1, fontTitle, Brushes.Black, New RectangleF(titleRect.X - 55, titleRect.Y + 25, titleRect.Width, titleHeight), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

        End If


        ' =========================================
        ' STORE INFO
        ' =========================================

        ' Draw title
        'e.Graphics.DrawString(My.Settings.storename1, fontTitle, Brushes.Black, New RectangleF(titleRect.X - 55, titleRect.Y + 25, titleRect.Width, titleHeight), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

        ' Draw table header
        Dim columns As String() = {"المجموع", "السعر", "الكمية", "المنتج"}
        Dim totalWidth As Integer = pageWidth - 2 * margin
        Dim colWidths As Integer() = {
        CInt(totalWidth * 0.2), ' 20% for column 1
        CInt(totalWidth * 0.2), ' 20% for column 2
        CInt(totalWidth * 0.2), ' 20% for column 3
        CInt(totalWidth * 0.4)  ' 40% for column 4
    }

        Dim startX As Integer = mainTableRect.X
        Dim startY As Integer = mainTableRect.Y
        Dim currentX As Integer = startX
        ' Draw table header
        For i As Integer = 0 To columns.Length - 1
            Dim headerRect As New Rectangle(currentX, startY, colWidths(i), rowHeight)
            e.Graphics.FillRectangle(Brushes.LightGray, headerRect)
            e.Graphics.DrawRectangle(borderPen, headerRect) ' Draw border for header cell
            e.Graphics.DrawString(columns(i), fontHeader, Brushes.Black, headerRect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            currentX += colWidths(i)
        Next
        e.Graphics.DrawLine(linePen, startX, startY + rowHeight, startX + colWidths.Sum(), startY + rowHeight) ' Draw line under header

        ' Draw rows
        Dim rowY As Integer = startY + rowHeight
        Dim rowsDrawn As Integer = 0
        Dim rowsPerPageCurrent As Integer = 0

        ' Keep track of the starting Y position for the next page
        Dim startingYForNextPage As Integer = rowY

        For i As Integer = rowIndex To orderDGV.Rows.Count - 1
            Dim row As DataGridViewRow = orderDGV.Rows(i)
            If Not row.IsNewRow Then
                Dim cellX As Integer = startX

                ' Calculate the required row height based on the content of the cell in column 4
                Dim cellText As String = row.Cells(13).Value.ToString()
                Dim textSize As SizeF = e.Graphics.MeasureString(cellText, fontBodySmall, colWidths(3))
                Dim dynamicRowHeight As Integer = CInt(System.Math.Max(rowHeight, textSize.Height + 10)) ' Add padding

                ' Draw the row with dynamic height
                For j As Integer = 0 To columns.Length - 1
                    Dim cellRect As New Rectangle(cellX, rowY, colWidths(j), dynamicRowHeight)
                    e.Graphics.DrawRectangle(borderPen, cellRect) ' Draw border for each cell
                    Dim cellContent As String = If(j = 0, Format(CDec(row.Cells(7).Value), "F2"), If(j = 1, Format(CDec(row.Cells(10).Value), "F2"), If(j = 2, Format(CDec(row.Cells(8).Value), "F2"), row.Cells(13).Value.ToString())))
                    e.Graphics.DrawString(cellContent, fontBodySmall, Brushes.Black, cellRect, New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    cellX += colWidths(j)
                Next

                e.Graphics.DrawLine(linePen, startX, rowY + dynamicRowHeight, startX + colWidths.Sum(), rowY + dynamicRowHeight) ' Draw line under each row
                rowY += dynamicRowHeight
                rowsDrawn += 1
                rowsPerPageCurrent += 1

                ' Check if the page height is exceeded
                If rowY + dynamicRowHeight + 60 > pageHeight - margin Then ' Adding extra 60 for margin and footer height
                    rowIndex = i + 1
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        Next

        ' Draw totals and other rectangles at the bottom of the last page
        Dim totalSum As Decimal = 0
        For Each row As DataGridViewRow In orderDGV.Rows
            If Not row.IsNewRow Then
                totalSum += Convert.ToDecimal(row.Cells(7).Value)
            End If
        Next

        Dim totalSumText As String = Format(totalSum, "F2")
        Dim discountAmount As Decimal = Convert.ToDecimal(discount.Text)
        Dim netTotal As Decimal = totalSum - discountAmount
        Dim netTotalText As String = Format(netTotal, "F2")
        Dim cashAmount As Decimal = Convert.ToDecimal(credit.Text)
        Dim debitAmount As Decimal = Convert.ToDecimal(debit.Text)
        Dim bottomY As Integer = rowY + 20 ' Adjust bottom offset
        Dim valueRect As New Rectangle(margin, bottomY, 250, 30)
        Dim discountRect As New Rectangle(margin, bottomY + 40, 250, 30)
        Dim netTotalRect As New Rectangle(margin, bottomY + 80, 250, 30)
        Dim cashrect As New Rectangle(margin, bottomY + 120, 250, 30)
        Dim debtrect As New Rectangle(margin, bottomY + 160, 250, 30)
        ' Check if the netTotalRect will fit in the current page
        If bottomY + 120 > pageHeight - margin Then
            e.HasMorePages = True
            rowIndex = orderDGV.Rows.Count ' Set rowIndex to end to avoid looping over remaining rows
            Exit Sub
        End If

        ' Draw discount and net total rectangles with borders
        e.Graphics.DrawRectangle(borderPen, valueRect)
        e.Graphics.DrawString(":المجموع", fontBodySmall, Brushes.Black, valueRect, New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
        e.Graphics.DrawString(totalSumText, fontBodySmall, Brushes.Black, valueRect, New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})

        e.Graphics.DrawRectangle(borderPen, discountRect)
        e.Graphics.DrawString(":الحسم", fontBodySmall, Brushes.Black, discountRect, New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
        e.Graphics.DrawString(discountAmount.ToString("F2"), fontBodySmall, Brushes.Black, discountRect, New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})

        e.Graphics.DrawRectangle(borderPen, netTotalRect)
        e.Graphics.DrawString(":المجموع الصافي", fontBodySmall, Brushes.Black, netTotalRect, New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
        e.Graphics.DrawString(netTotalText, fontBodySmall, Brushes.Black, netTotalRect, New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})

        e.Graphics.DrawRectangle(borderPen, cashrect)
        e.Graphics.DrawString(":واصل", fontBodySmall, Brushes.Black, cashrect, New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
        e.Graphics.DrawString(cashAmount, fontBodySmall, Brushes.Black, cashrect, New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})

        e.Graphics.DrawRectangle(borderPen, debtrect)
        e.Graphics.DrawString(":باقي", fontBodySmall, Brushes.Black, debtrect, New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
        e.Graphics.DrawString(debitAmount, fontBodySmall, Brushes.Black, debtrect, New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})

        ' Reset page number for next page
        currentPage += 0

        ' Handle multi-page printing
        If rowIndex >= orderDGV.Rows.Count Then
            e.HasMorePages = False
            rowIndex = 0
            currentPage = 1
        End If
    End Sub
End Class


