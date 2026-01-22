Imports System.Data.SqlClient

Public Class suppliersdebit
    'Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)


    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub CustomerDate_ValueChanged(sender As Object, e As EventArgs) Handles maindate.ValueChanged
        maindate.Value = Date.Now.AddDays(0)
    End Sub

    Private Sub suppliersdebit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.suppdebitTbl' table. You can move, or remove it, as needed.
        Me.SuppdebitTblTableAdapter.Fill(Me.MARKETDataSet.suppdebitTbl)
        'TODO: This line of code loads data into the 'MarketDataSet.suppdebitTbl' table. You can move, or remove it, as needed.
        Me.SuppdebitTblTableAdapter.Fill(Me.MarketDataSet.suppdebitTbl)
        fillsupp()
        AcceptButton = Button1
        filldr()
    End Sub
    Public Sub fillsupp()
        con.Open()
        Dim str As New SqlCommand("select distinct sname from suppdebitTbl ", con)
        Dim reader As SqlDataReader = str.ExecuteReader
        sname.Items.Clear()
        While reader.Read
            sname.Items.Add(reader("sname"))
        End While
        con.Close()
    End Sub

    Private Sub sname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sname.SelectedIndexChanged
        con.Open()
        Dim str As New SqlCommand("select distinct invnum from suppdebitTbl ", con)
        Dim reader As SqlDataReader = str.ExecuteReader
        invnum.Items.Clear()
        While reader.Read
            invnum.Items.Add(reader("invnum"))
        End While
        con.Close()

        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select SUM(debits)-SUM(credits) from suppdebitTbl where sname =N'" & sname.Text & "'"
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 0
            tqa.Text = num
        Else
            num = cmd.ExecuteScalar
            tqa.Text = num
        End If
        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub invnum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles invnum.SelectedIndexChanged

        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select SUM(debits)-SUM(credits) from suppdebitTbl where sname =N'" & sname.Text & "' and invnum=N'" & invnum.Text & "'"
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 0
            tqi.Text = num
        Else
            num = cmd.ExecuteScalar
            tqi.Text = num
        End If
        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newRow1 As DataRow = Me.MarketDataSet.suppdebitTbl.NewRow()

        newRow1("sname") = sname.Text
        newRow1("invnum") = invnum.Text
        newRow1("debits") = "0"
        newRow1("credits") = cashd.Text
        newRow1("date") = FormatDateTime(maindate.Value)
        ' Add the new row to the DataTable
        Me.MarketDataSet.suppdebitTbl.Rows.Add(newRow1)

        ' Refresh the DataGridView to reflect the changes
        Me.supplierdebitDGV.Refresh()
        cashd.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Validate()
        Me.SuppdebitTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)
        cashd.Text = ""
        MessageBox.Show("تم الحفظ")
        dailyprofits.fillsupp()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If supplierdebitDGV.SelectedRows.Count > 0 Then
            SuppdebitTblBindingNavigator.DeleteItem.PerformClick()
        Else
            MessageBox.Show("اختر سطر للمسح")
        End If
        cashd.Text = ""
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Delete Then
            ' Trigger the click event of the "Save" button
            Button2.PerformClick()
            Return True ' Indicate that the key press has been handled
        End If


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
            Dim rawData(supplierdebitDGV.Rows.Count, supplierdebitDGV.Columns.Count - 1) As Object
            For col = 0 To supplierdebitDGV.Columns.Count - 1
                rawData(0, col) = supplierdebitDGV.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To supplierdebitDGV.Columns.Count - 1
                For row = 0 To supplierdebitDGV.Rows.Count - 1
                    rawData(row + 1, col) = supplierdebitDGV.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(supplierdebitDGV.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, supplierdebitDGV.Rows.Count + 1)
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
        suppliersdebit_Load(e, e)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        tqa.Text = ""
        tqi.Text = ""
        cashd.Text = ""
    End Sub
    Private Sub tqa_TextChanged(sender As Object, e As EventArgs) Handles tqa.TextChanged
        If tqa.Text = "0" Then
            Label4.Text = "0"
        Else
            Label4.Text = Val(tqa.Text) * Val(dr.Text)
        End If
    End Sub

    Private Sub tqi_TextChanged(sender As Object, e As EventArgs) Handles tqi.TextChanged
        If tqi.Text = "0" Then
            Label7.Text = "0"
        Else
            Label7.Text = Val(tqi.Text) * Val(dr.Text)
        End If
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

    Private Sub sname_Click(sender As Object, e As EventArgs) Handles sname.Click
        fillsupp()
    End Sub
End Class