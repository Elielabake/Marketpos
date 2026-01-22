Imports System.Data.SqlClient

Public Class cashier
    'Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)


    Public Sub cashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.cashiertbl' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'MarketDataSet.cashiertbl' table. You can move, or remove it, as needed.
        Me.CashiertblTableAdapter.Fill(Me.MarketDataSet.cashiertbl)
        filldr()
        Dim savedValue1 As String = My.Settings.cash1value
        cash1.Text = savedValue1
        Dim savedValue2 As String = My.Settings.cash2value
        cash2.Text = savedValue2
        emp.Text = Form1.Label7.Text
        AcceptButton = Button1
        dailyprofits.dailyprofits_Load(e, e)
        cash3.Text = Val(dailyprofits.totnet.Text) + Val(cash1.Text)
        cash4.Text = Val(cash3.Text) * Val(dr.Text)
    End Sub
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub
    Private Sub CustomerDate_ValueChanged(sender As Object, e As EventArgs) Handles maindate.ValueChanged
        maindate.Value = Date.Now.AddDays(0)
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Hide()
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
    Private shouldstop As Boolean = False
    Private Sub cash1_TextChanged(sender As Object, e As EventArgs) Handles cash1.TextChanged

        cash2.Text = Val(cash1.Text) * Val(dr.Text)


    End Sub



    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        ' Your code to save the textbox value to settings

        Dim numericValue As Decimal ' Change to appropriate numeric data type if needed

        ' Parse the textbox text to the appropriate numeric data type
        If Decimal.TryParse(cash1.Text, numericValue) Then
            ' Save the numeric value to settings
            My.Settings.cash1value = numericValue
            My.Settings.Save()
        Else
            MessageBox.Show("Invalid numeric value entered.")
        End If

        Dim numericValue1 As Decimal ' Change to appropriate numeric data type if needed

        ' Parse the textbox text to the appropriate numeric data type
        If Decimal.TryParse(cash2.Text, numericValue1) Then
            ' Save the numeric value to settings
            My.Settings.cash2value = numericValue1
            My.Settings.Save()
        Else
            MessageBox.Show("Invalid numeric value entered.")
        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newRow1 As DataRow = Me.MarketDataSet.cashiertbl.NewRow()

        newRow1("cash1") = cash1.Text
        newRow1("cash2") = cash2.Text
        newRow1("cash3") = Val(cash3.Text)
        newRow1("cash4") = Val(cash4.Text)
        newRow1("emp") = emp.Text
        newRow1("date") = FormatDateTime(maindate.Value.Date)
        ' Add the new row to the DataTable
        Me.MarketDataSet.cashiertbl.Rows.Add(newRow1)

        ' Refresh the DataGridView to reflect the changes
        cashierDGV.Refresh()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Validate()
        Me.CashiertblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        cash1.Text = Val("0")
        cash2.Text = Val("0")

        Dim numericValue As Decimal ' Change to appropriate numeric data type if needed

        ' Parse the textbox text to the appropriate numeric data type
        If Decimal.TryParse(cash1.Text, numericValue) Then
            ' Save the numeric value to settings
            My.Settings.cash1value = numericValue
            My.Settings.Save()
        Else
            MessageBox.Show("Invalid numeric value entered.")
        End If

        Dim numericValue1 As Decimal ' Change to appropriate numeric data type if needed

        ' Parse the textbox text to the appropriate numeric data type
        If Decimal.TryParse(cash2.Text, numericValue1) Then
            ' Save the numeric value to settings
            My.Settings.cash2value = numericValue1
            My.Settings.Save()
        Else
            MessageBox.Show("Invalid numeric value entered.")
        End If
        cash3.Text = "0"
        cash4.Text = "0"
        Dim savedValue1 As String = My.Settings.cash1value
        cash1.Text = savedValue1
        Dim savedValue2 As String = My.Settings.cash2value
        cash2.Text = savedValue2
        MessageBox.Show("تم الحفظ")
        dailyprofits.Show()
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

    Private Sub cash3_TextChanged(sender As Object, e As EventArgs) Handles cash3.TextChanged
        cash4.Text = Val(cash3.Text) * Val(dr.Text)
    End Sub
    Private Sub dr_TextChanged(sender As Object, e As EventArgs) Handles dr.TextChanged
        cash4.Text = Val(cash3.Text) * Val(dr.Text)
        cash2.Text = Val(cash1.Text) * Val(dr.Text)
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.Controls.Clear()
        InitializeComponent()
        cashier_Load(e, e)
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
            Dim rawData(cashierDGV.Rows.Count, cashierDGV.Columns.Count - 1) As Object
            For col = 0 To cashierDGV.Columns.Count - 1
                rawData(0, col) = cashierDGV.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To cashierDGV.Columns.Count - 1
                For row = 0 To cashierDGV.Rows.Count - 1
                    rawData(row + 1, col) = cashierDGV.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(cashierDGV.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, cashierDGV.Rows.Count + 1)
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


End Class