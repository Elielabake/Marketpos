Imports System.Data.SqlClient

Public Class dailyprofits
    'Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Public Sub retrievedate()
        Dim connectionString As String = My.Settings.MARKETDBConnectionString
        Dim query As String = "SELECT TOP 1 date FROM dailyp ORDER BY date DESC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)

        Try
            conn.Open()
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot DBNull.Value Then
                lastdate.Value = Convert.ToDateTime(result)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub
    Public Sub dailyprofits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.dailyp' table. You can move, or remove it, as needed.
        Me.DailypTableAdapter.Fill(Me.MARKETDataSet.dailyp)
        ' Set the interval (1000 ms = 1 second)
        dateTimer.Interval = 1000
        dateTimer.Start()
        retrievedate()

        Me.DailypTableAdapter.Fill(Me.MARKETDataSet.dailyp)
        'TODO: This line of code loads data into the 'MarketDataSet.dailyp' table. You can move, or remove it, as needed.
        retrievedate()
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
        AcceptButton = Button1
        UpdateCashierPlus()
    End Sub
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub


    ' Declare the timer
    Private WithEvents dateTimer As New Timer()



    ' Update the DateTimePicker every second
    Private Sub dateTimer_Tick(sender As Object, e As EventArgs) Handles dateTimer.Tick
        maindate.Value = DateTime.Now
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
        Form1.Show()

    End Sub
    Public Sub exp1()
        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(amountd) FROM expTbl WHERE [date] > @LastDate", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            exp.Text = num & "$"
        End Using
    End Sub

    Public Sub order1()
        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(totd) FROM ordertbl1 WHERE [date] > @LastDate", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            ord.Text = num & "$"
        End Using
    End Sub
    Public Sub fruits()

        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(totd) From orderstbl WHERE [date] > @LastDate and categ=N'الخضار'", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            fr.Text = num & "$"
        End Using
    End Sub
    Public Sub chicken()

        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(totd) From orderstbl WHERE [date] > @LastDate and categ=N'فروج'", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            chic.Text = num & "$"
        End Using
    End Sub
    Public Sub cash1()
        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(credit) FROM ordertbl1 WHERE [date] > @LastDate", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            credittxt.Text = num & "$"
        End Using
    End Sub

    Public Sub prof1()
        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(profit) FROM ordertbl1 WHERE [date] > @LastDate", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            prof.Text = num & "$"
        End Using
    End Sub

    Public Sub filldeb()
        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(credits) FROM debitTbl WHERE [date] > @LastDate", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            deb.Text = num & "$"
        End Using
    End Sub

    Public Sub fillinv()
        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(pd) FROM suppliersTbl WHERE [date] > @LastDate", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            inv.Text = num & "$"
        End Using
    End Sub

    Public Sub fillsupp()
        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(credits) FROM suppdebitTbl WHERE [date] > @LastDate", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            supp.Text = num & "$"
        End Using
    End Sub

    Public Sub fillequip()
        Dim num As Decimal
        Using cmd As New SqlCommand("SELECT SUM(amountd) FROM equipmentTbl1 WHERE [date] > @LastDate", con)
            cmd.Parameters.AddWithValue("@LastDate", lastdate.Value)

            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            If result Is DBNull.Value OrElse result Is Nothing Then
                num = 0
            Else
                num = Convert.ToDecimal(result)
            End If

            equip.Text = num & "$"
        End Using
    End Sub





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newRow1 As DataRow = Me.MARKETDataSet.dailyp.NewRow()

        newRow1("ord") = Val(ord.Text)
        newRow1("prof") = Val(prof.Text)
        newRow1("debit") = Val(deb.Text)
        newRow1("sr") = Val(sr.Text)
        newRow1("fr") = Val(fr.Text)
        newRow1("chice") = Val(chic.Text)
        newRow1("inv") = Val(inv.Text)
        newRow1("exp") = Val(exp.Text)
        newRow1("suppdebit") = Val(supp.Text)
        newRow1("equip") = Val(equip.Text)
        newRow1("totasset") = Val(totaset.Text)
        newRow1("totliab") = Val(totliab.Text)
        newRow1("totalnet") = Val(totnet.Text)
        newRow1("totprof") = Val(Label20.Text)
        newRow1("date") = FormatDateTime(maindate.Value)
        ' Add the new row to the DataTable
        Me.MARKETDataSet.dailyp.Rows.Add(newRow1)

        ' Refresh the DataGridView to reflect the changes
        dailypDGV.Refresh()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Validate()
        Me.DailypBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        retrievedate()
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
        MessageBox.Show("تم الحفظ")

    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean



        ' Check if the F1 key is pressed
        If keyData = Keys.F1 Then
            ' Trigger the click event of the "Save" button
            Button3.PerformClick()
            Return True ' Indicate that the key press has been handled
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim sheetIndex As Integer
            Dim Ex As Object
            Dim Wb As Object
            Dim Ws As Object
            Ex = CreateObject("Excel.Application")
            Wb = Ex.workbooks.add
            Dim col, row As Integer
            Dim rawData(dailypDGV.Rows.Count, dailypDGV.Columns.Count - 1) As Object
            For col = 0 To dailypDGV.Columns.Count - 1
                rawData(0, col) = dailypDGV.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To dailypDGV.Columns.Count - 1
                For row = 0 To dailypDGV.Rows.Count - 1
                    rawData(row + 1, col) = dailypDGV.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(dailypDGV.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, dailypDGV.Rows.Count + 1)
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
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.Controls.Clear()
        InitializeComponent()
        dailyprofits_Load(e, e)
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

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        profitssummation.Show()
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
    Private Sub UpdateCashierPlus()
        ' Replace with your actual connection string
        Dim conString As String = My.Settings.MARKETDBConnectionString

        Using con As New SqlConnection(conString)
            Try
                con.Open()

                Dim sql As String = "
                SELECT SUM(value) AS TotalBalance
                FROM
                (
                    -- Positive amounts
                    SELECT ISNULL(credit,0) AS value FROM ordertbl1
                    UNION ALL
                    SELECT ISNULL(credits,0) FROM debitTbl

                    -- Negative amounts
                    UNION ALL
                    SELECT -ISNULL(amountd,0) FROM expTbl
                    UNION ALL
                    SELECT -ISNULL(pd,0) FROM suppliersTbl
                    UNION ALL
                    SELECT -ISNULL(credits,0) FROM suppdebitTbl
                    UNION ALL
                    SELECT -ISNULL(amountd,0) FROM equipmentTbl1
                ) AS combined
                "

                Using cmd As New SqlCommand(sql, con)
                    ' Execute the query and get the result
                    Dim result As Object = cmd.ExecuteScalar()

                    ' Display rounded whole number in CashierPlus.Text
                    If result IsNot Nothing Then
                        cashierplus.Text = Val(result) & "$"
                    Else
                        cashierplus.Text = "0" & "$"
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("Error calculating CashierPlus: " & ex.Message)
            End Try
        End Using
    End Sub
End Class