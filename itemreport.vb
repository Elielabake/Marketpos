Imports System.Data.SqlClient

Public Class itemreport
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub LoadSupplierData(searchValue As String)
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            Dim query As String = "
                SELECT s.invnum, s.sname, s.cname
                FROM suppliersTbl s
                INNER JOIN invoiceTbl i ON s.invnum = i.invnum
                WHERE i.bcode = @search OR i.pname = @search
            "

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@search", searchValue)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                dgv.DataSource = dt
                If dgv.Columns.Count > 0 Then
                    dgv.Columns("invnum").HeaderText = "رقم الفاتورة"
                    dgv.Columns("sname").HeaderText = "اسم المورد"
                    dgv.Columns("cname").HeaderText = "اسم الشركة"
                End If
            End Using
        End Using
    End Sub

    Private Sub bc_TextChanged(sender As Object, e As EventArgs) Handles bc.TextChanged
        fillfrombc()

        LoadSupplierData(bc.Text.Trim())
    End Sub

    Private Sub itemreport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        Dim cmd1 As New SqlCommand("SELECT bcode FROM invoiceTbl", con)
        Dim ds1 As New DataSet
        Dim da1 As New SqlDataAdapter(cmd1)
        da1.Fill(ds1, "list")
        Dim col1 As New AutoCompleteStringCollection
        Dim i1 As Integer
        For i1 = 0 To ds1.Tables(0).Rows.Count - 1
            col1.Add(ds1.Tables(0).Rows(i1)("bcode").ToString())
        Next
        bc.AutoCompleteSource = AutoCompleteSource.CustomSource
        bc.AutoCompleteCustomSource = col1
        bc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        con.Close()
        con.Open()
        Dim cmd2 As New SqlCommand("SELECT pname FROM invoiceTbl", con)
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
        dgv.Columns("invnum").HeaderText = "رقم الفاتورة"
        dgv.Columns("sname").HeaderText = "اسم المورد"
        dgv.Columns("cname").HeaderText = "اسم الشركة"

    End Sub
    Public Sub fillfrombc()
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim query As String = "SELECT * FROM invoiceTbl WHERE bcode = @bcode"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@bcode", bc.Text.Trim())

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then

                        pn.Text = reader(4).ToString()

                    Else
                        ' Clear fields when no item found

                        pn.Text = ""

                    End If
                    con.Close()

                End Using
            End Using
        End Using
    End Sub

    Private Sub pn_TextChanged(sender As Object, e As EventArgs) Handles pn.TextChanged
        If bc.Text = "" Then
            LoadSupplierData(pn.Text.Trim())
        Else
            LoadSupplierData(bc.Text.Trim())
        End If
    End Sub

    Public Sub LoadLessSold()
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim query As String = "
            SELECT pn AS [pn], SUM(qty) AS [qty]
            FROM orderstbl
            WHERE date BETWEEN @fromDate AND @toDate
            GROUP BY pn
            ORDER BY SUM(qty) ASC"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@fromDate", fromDatePicker.Value.Date)
                cmd.Parameters.AddWithValue("@toDate", toDatePicker.Value.Date)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                lesssolddgv.DataSource = dt

                If lesssolddgv.Columns.Count > 0 Then
                    lesssolddgv.Columns("pn").HeaderText = "اسم المنتج"
                    lesssolddgv.Columns("qty").HeaderText = "الكمية المباعة"
                End If
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadLessSold()

    End Sub
    Public Sub LoadmoreSold()
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim query As String = "
            SELECT pn AS [pn], SUM(qty) AS [qty]
            FROM orderstbl
            WHERE date BETWEEN @fromDate AND @toDate
            GROUP BY pn
            ORDER BY SUM(qty) DESC"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@fromDate", fromDatePicker.Value.Date)
                cmd.Parameters.AddWithValue("@toDate", toDatePicker.Value.Date)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                MoreSoldDGV.DataSource = dt

                If MoreSoldDGV.Columns.Count > 0 Then
                    MoreSoldDGV.Columns("pn").HeaderText = "اسم المنتج"
                    MoreSoldDGV.Columns("qty").HeaderText = "الكمية المباعة"
                End If
            End Using
        End Using
    End Sub


    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        LoadmoreSold()
    End Sub

    Public Sub Loadmoreprof()
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim query As String = "
            SELECT pn AS [pn], SUM(profit) AS [profit]
            FROM orderstbl
            WHERE date BETWEEN @fromDate AND @toDate
            GROUP BY pn
            ORDER BY SUM(profit) DESC"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@fromDate", fpdate.Value.Date)
                cmd.Parameters.AddWithValue("@toDate", topdate.Value.Date)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                mprofdgv.DataSource = dt

                If mprofdgv.Columns.Count > 0 Then
                    mprofdgv.Columns("pn").HeaderText = "اسم المنتج"
                    mprofdgv.Columns("profit").HeaderText = "الارباح"
                End If
            End Using
        End Using
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Loadmoreprof()
    End Sub
    Public Sub Loadlessprof()
        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
            con.Open()

            Dim query As String = "
            SELECT pn AS [pn], SUM(profit) AS [profit]
            FROM orderstbl
            WHERE date BETWEEN @fromDate AND @toDate
            GROUP BY pn
            ORDER BY SUM(profit) ASC"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@fromDate", flpdate.Value.Date)
                cmd.Parameters.AddWithValue("@toDate", tolpdate.Value.Date)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                lprofdgv.DataSource = dt

                If lprofdgv.Columns.Count > 0 Then
                    lprofdgv.Columns("pn").HeaderText = "اسم المنتج"
                    lprofdgv.Columns("profit").HeaderText = "الارباح"
                End If
            End Using
        End Using
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Loadlessprof()
    End Sub





    Public Sub exp1()
        Dim num As Decimal
        Using cmd As New SqlCommand()
            cmd.Connection = con

            ' Get values from the DateTimePickers
            Dim mainDateFormatted As DateTime = dfromdate.Value.Date
            Dim lastDateFormatted As DateTime = dtodate.Value.Date

            ' Open connection
            con.Open()

            ' Correct SQL query to sum values between two dates
            cmd.CommandText = "SELECT SUM(amountd) FROM expTbl WHERE [date] BETWEEN @MainDate AND @LastDate"

            ' Add parameters properly
            cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
            cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

            ' Execute the query
            Dim result = cmd.ExecuteScalar()
            If IsDBNull(result) Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            ' Show result
            exp.Text = num.ToString() & "$"

            ' Cleanup
            con.Close()
        End Using
    End Sub

    Public Sub order1()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con

        ' Use DateTime directly without converting to string
        Dim mainDateFormatted As DateTime = dfromdate.Value
        Dim lastDateFormatted As DateTime = dtodate.Value

        ' Open connection
        con.Open()

        ' Correct SQL query to sum the 'totd' values where 'date' is greater than 'lastdate'
        cmd.CommandText = "SELECT SUM(totd) FROM ordertbl1 WHERE [date] BETWEEN @MainDate AND @LastDate"

        ' Add parameters to avoid SQL injection and pass the DateTime values correctly
        cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
        cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

        ' Execute the query and handle the result
        If IsDBNull(cmd.ExecuteScalar()) Then
            num = 0
            ord.Text = num & "$"
        Else
            num = cmd.ExecuteScalar()
            ord.Text = num & "$"
        End If

        ' Cleanup
        cmd.Dispose()
        con.Close()
    End Sub



    Public Sub cash1()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con

        ' Use DateTime directly without converting to string
        Dim mainDateFormatted As DateTime = dfromdate.Value
        Dim lastDateFormatted As DateTime = dtodate.Value

        ' Open connection
        con.Open()

        ' Correct SQL query to sum the 'totd' values where 'date' is greater than 'lastdate'
        cmd.CommandText = "SELECT SUM(credit) From ordertbl1 WHERE [date] BETWEEN @MainDate AND @LastDate"

        ' Add parameters to avoid SQL injection and pass the DateTime values correctly
        cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
        cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

        ' Execute the query and handle the result
        If IsDBNull(cmd.ExecuteScalar()) Then
            num = 0
            credittxt.Text = num & "$"
        Else
            num = cmd.ExecuteScalar()
            credittxt.Text = num & "$"
        End If

        ' Cleanup
        cmd.Dispose()
        con.Close()

    End Sub
    Public Sub fruits()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con

        ' Use DateTime directly without converting to string
        Dim mainDateFormatted As DateTime = dfromdate.Value
        Dim lastDateFormatted As DateTime = dtodate.Value

        ' Open connection
        con.Open()

        ' Correct SQL query to sum the 'totd' values where 'date' is greater than 'lastdate'
        cmd.CommandText = "SELECT SUM(totd) From orderstbl WHERE [date] BETWEEN @MainDate AND @LastDate and categ=N'الخضار'"

        ' Add parameters to avoid SQL injection and pass the DateTime values correctly
        cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
        cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

        ' Execute the query and handle the result
        If IsDBNull(cmd.ExecuteScalar()) Then
            num = 0
            fr.Text = num & "$"
        Else
            num = cmd.ExecuteScalar()
            fr.Text = num & "$"
        End If

        ' Cleanup
        cmd.Dispose()
        con.Close()

    End Sub
    Public Sub chicken()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con

        ' Use DateTime directly without converting to string
        Dim mainDateFormatted As DateTime = dfromdate.Value
        Dim lastDateFormatted As DateTime = dtodate.Value

        ' Open connection
        con.Open()

        ' Correct SQL query to sum the 'totd' values where 'date' is greater than 'lastdate'
        cmd.CommandText = "SELECT SUM(totd) From orderstbl WHERE [date] BETWEEN @MainDate AND @LastDate and categ=N'فروج'"

        ' Add parameters to avoid SQL injection and pass the DateTime values correctly
        cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
        cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

        ' Execute the query and handle the result
        If IsDBNull(cmd.ExecuteScalar()) Then
            num = 0
            chic.Text = num & "$"
        Else
            num = cmd.ExecuteScalar()
            chic.Text = num & "$"
        End If

        ' Cleanup
        cmd.Dispose()
        con.Close()

    End Sub
    Public Sub prof1()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con

        ' Use DateTime directly without converting to string
        Dim mainDateFormatted As DateTime = dfromdate.Value
        Dim lastDateFormatted As DateTime = dtodate.Value

        ' Open connection
        con.Open()

        ' Correct SQL query to sum the 'totd' values where 'date' is greater than 'lastdate'
        cmd.CommandText = "SELECT SUM(profit) From ordertbl1 WHERE [date] BETWEEN @MainDate AND @LastDate"

        ' Add parameters to avoid SQL injection and pass the DateTime values correctly
        cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
        cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

        ' Execute the query and handle the result
        If IsDBNull(cmd.ExecuteScalar()) Then
            num = 0
            prof.Text = num & "$"
        Else
            num = cmd.ExecuteScalar()
            prof.Text = num & "$"
        End If

        ' Cleanup
        cmd.Dispose()
        con.Close()

    End Sub
    Public Sub filldeb()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con

        ' Use DateTime directly without converting to string
        Dim mainDateFormatted As DateTime = dfromdate.Value
        Dim lastDateFormatted As DateTime = dtodate.Value

        ' Open connection
        con.Open()

        ' Correct SQL query to sum the 'totd' values where 'date' is greater than 'lastdate'
        cmd.CommandText = "SELECT SUM(credits) From debitTbl WHERE [date] BETWEEN @MainDate AND @LastDate"

        ' Add parameters to avoid SQL injection and pass the DateTime values correctly
        cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
        cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

        ' Execute the query and handle the result
        If IsDBNull(cmd.ExecuteScalar()) Then
            num = 0
            deb.Text = num & "$"
        Else
            num = cmd.ExecuteScalar()
            deb.Text = num & "$"
        End If

        ' Cleanup
        cmd.Dispose()
        con.Close()

    End Sub
    Public Sub fillinv()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con

        ' Use DateTime directly without converting to string
        Dim mainDateFormatted As DateTime = dfromdate.Value
        Dim lastDateFormatted As DateTime = dtodate.Value

        ' Open connection
        con.Open()

        ' Correct SQL query to sum the 'totd' values where 'date' is greater than 'lastdate'
        cmd.CommandText = "SELECT SUM(pd) From suppliersTbl WHERE [date] BETWEEN @MainDate AND @LastDate"

        ' Add parameters to avoid SQL injection and pass the DateTime values correctly
        cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
        cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

        ' Execute the query and handle the result
        If IsDBNull(cmd.ExecuteScalar()) Then
            num = 0
            inv.Text = num & "$"
        Else
            num = cmd.ExecuteScalar()
            inv.Text = num & "$"
        End If

        ' Cleanup
        cmd.Dispose()
        con.Close()

    End Sub
    Public Sub fillsupp()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con

        ' Use DateTime directly without converting to string
        Dim mainDateFormatted As DateTime = dfromdate.Value
        Dim lastDateFormatted As DateTime = dtodate.Value

        ' Open connection
        con.Open()

        ' Correct SQL query to sum the 'totd' values where 'date' is greater than 'lastdate'
        cmd.CommandText = "SELECT SUM(credits) From suppdebitTbl WHERE [date] BETWEEN @MainDate AND @LastDate"

        ' Add parameters to avoid SQL injection and pass the DateTime values correctly
        cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
        cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

        ' Execute the query and handle the result
        If IsDBNull(cmd.ExecuteScalar()) Then
            num = 0
            supp.Text = num & "$"
        Else
            num = cmd.ExecuteScalar()
            supp.Text = num & "$"
        End If

        ' Cleanup
        cmd.Dispose()
        con.Close()

    End Sub
    Public Sub fillequip()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con

        ' Use DateTime directly without converting to string
        Dim mainDateFormatted As DateTime = dfromdate.Value
        Dim lastDateFormatted As DateTime = dtodate.Value


        ' Open connection
        con.Open()

        ' Correct SQL query to sum the 'totd' values where 'date' is greater than 'lastdate'
        cmd.CommandText = "SELECT SUM(amountd) From equipmentTbl1 WHERE [date] BETWEEN @MainDate AND @LastDate"

        ' Add parameters to avoid SQL injection and pass the DateTime values correctly
        cmd.Parameters.AddWithValue("@MainDate", mainDateFormatted)
        cmd.Parameters.AddWithValue("@LastDate", lastDateFormatted)

        ' Execute the query and handle the result
        If IsDBNull(cmd.ExecuteScalar()) Then
            num = 0
            equip.Text = num & "$"
        Else
            num = cmd.ExecuteScalar()
            equip.Text = num & "$"
        End If

        ' Cleanup
        cmd.Dispose()
        con.Close()

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        exp1()
        order1()
        prof1()
        filldeb()
        cash1()
        fruits()
        chicken()
        profpercent.Text = (Val(prof.Text) * 100) / Val(ord.Text)
        Dim decimalvalue As Decimal = Val(profpercent.Text)
        profpercent.Text = $"{decimalvalue:N2}" & "%"

        totaset.Text = Val(credittxt.Text) + Val(deb.Text)
        totaset.Text = Val(totaset.Text) & "$"
        fillinv()
        fillsupp()
        fillequip()
        totliab.Text = Val(inv.Text) + Val(exp.Text) + Val(supp.Text) + Val(equip.Text)
        totliab.Text = Val(totliab.Text) & "$"

        totnet.Text = Val(totaset.Text) - Val(totliab.Text)
        totnet.Text = Val(totnet.Text) & "$"
    End Sub
    Private Sub inv_TextChanged(sender As Object, e As EventArgs) Handles inv.TextChanged
        totliab.Text = Val(inv.Text) + Val(exp.Text) + Val(supp.Text) + Val(equip.Text)
        totliab.Text = Val(totliab.Text) & "$"

    End Sub

    Private Sub exp_TextChanged(sender As Object, e As EventArgs) Handles exp.TextChanged
        totliab.Text = Val(inv.Text) + Val(exp.Text) + Val(supp.Text) + Val(equip.Text)
        totliab.Text = Val(totliab.Text) & "$"

    End Sub

    Private Sub supp_TextChanged(sender As Object, e As EventArgs) Handles supp.TextChanged
        totliab.Text = Val(inv.Text) + Val(exp.Text) + Val(supp.Text) + Val(equip.Text)
        totliab.Text = Val(totliab.Text) & "$"

    End Sub

    Private Sub equip_TextChanged(sender As Object, e As EventArgs) Handles equip.TextChanged
        totliab.Text = Val(inv.Text) + Val(exp.Text) + Val(supp.Text) + Val(equip.Text)
        totliab.Text = Val(totliab.Text) & "$"

    End Sub

    Private Sub credittxt_TextChanged(sender As Object, e As EventArgs) Handles credittxt.TextChanged
        totaset.Text = Val(credittxt.Text) + Val(deb.Text)
        totaset.Text = Val(totaset.Text) & "$"
    End Sub

    Private Sub deb_TextChanged(sender As Object, e As EventArgs) Handles deb.TextChanged
        totaset.Text = Val(credittxt.Text) + Val(deb.Text)
        totaset.Text = Val(totaset.Text) & "$"
    End Sub

    Private Sub totaset_TextChanged(sender As Object, e As EventArgs) Handles totaset.TextChanged
        totnet.Text = Val(totaset.Text) - Val(totliab.Text)
        totnet.Text = Val(totnet.Text) & "$"
    End Sub

    Private Sub totliab_TextChanged(sender As Object, e As EventArgs) Handles totliab.TextChanged
        totnet.Text = Val(totaset.Text) - Val(totliab.Text)
        totnet.Text = Val(totnet.Text) & "$"
        Label20.Text = Val(prof.Text) - Val(totliab.Text)
        Label20.Text = Val(Label20.Text) & "$"
    End Sub

    Private Sub totnet_TextChanged(sender As Object, e As EventArgs) Handles totnet.TextChanged
        cashier.cash3.Text = Val(totnet.Text) + Val(cashier.cash1.Text)
        cashier.cash4.Text = Val(cashier.cash3.Text) * Val(cashier.dr.Text)
    End Sub

    Private Sub prof_TextChanged(sender As Object, e As EventArgs) Handles prof.TextChanged
        Label20.Text = Val(prof.Text) - Val(totliab.Text)
        Label20.Text = Val(Label20.Text) & "$"
    End Sub



    Private Sub ord_TextChanged(sender As Object, e As EventArgs) Handles ord.TextChanged
        sr.Text = Val(ord.Text) - Val(fr.Text)
    End Sub

    Private Sub chic_TextChanged(sender As Object, e As EventArgs) Handles chic.TextChanged
        sr.Text = Val(ord.Text) - Val(fr.Text) - Val(chic.Text)
    End Sub
    Private Sub fr_TextChanged(sender As Object, e As EventArgs) Handles fr.TextChanged
        sr.Text = Val(ord.Text) - Val(fr.Text) - Val(chic.Text)
    End Sub





End Class