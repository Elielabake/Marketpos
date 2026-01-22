Imports System.Data.SqlClient
'Imports PdfSharp.BigGustave

Public Class debitsfrm
    'Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=MARKET;Integrated Security=True")

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
    Private Sub debitsfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.debitTbl' table. You can move, or remove it, as needed.
        'TODO: This line of code loads data into the 'MarketDataSet.debitTbl' table. You can move, or remove it, as needed.
        Me.DebitTblTableAdapter.Fill(Me.MarketDataSet.debitTbl)
        fillsupp()
        AcceptButton = Button1
        filldr()
        con.Open()
        Dim cmd1 As New SqlCommand("SELECT sname FROM debitTbl", con)
        Dim ds1 As New DataSet
        Dim da1 As New SqlDataAdapter(cmd1)
        da1.Fill(ds1, "list")
        Dim col1 As New AutoCompleteStringCollection
        Dim i1 As Integer
        For i1 = 0 To ds1.Tables(0).Rows.Count - 1
            col1.Add(ds1.Tables(0).Rows(i1)("sname").ToString())
        Next
        ncust.AutoCompleteSource = AutoCompleteSource.CustomSource
        ncust.AutoCompleteCustomSource = col1
        ncust.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        con.Close()
        If debitDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            debitDGV.FirstDisplayedScrollingRowIndex = debitDGV.Rows.Count - 1
            ' Optionally select the last row
            debitDGV.Rows(debitDGV.Rows.Count - 1).Selected = True
        End If
        totdeb()
    End Sub
    Public Sub fillsupp()
        con.Open()
        Dim str As New SqlCommand("select distinct sname from debitTbl ", con)
        Dim reader As SqlDataReader = str.ExecuteReader
        sname.Items.Clear()
        While reader.Read
            sname.Items.Add(reader("sname"))
        End While
        con.Close()

    End Sub
    Private Sub sname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sname.SelectedIndexChanged
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select SUM(debits)-SUM(credits) from debitTbl where sname =N'" & sname.Text & "'"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newRow1 As DataRow = Me.MarketDataSet.debitTbl.NewRow()

        newRow1("sname") = sname.Text
        newRow1("snum") = ""
        newRow1("debits") = "0"
        newRow1("credits") = cashd.Text
        newRow1("date") = FormatDateTime(maindate.Value)
        ' Add the new row to the DataTable
        Me.MarketDataSet.debitTbl.Rows.Add(newRow1)

        ' Refresh the DataGridView to reflect the changes
        Me.debitDGV.Refresh()
        cashd.Text = ""
        If debitDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            debitDGV.FirstDisplayedScrollingRowIndex = debitDGV.Rows.Count - 1
            ' Optionally select the last row
            debitDGV.Rows(debitDGV.Rows.Count - 1).Selected = True
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Validate()
        Me.DebitTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)
        cashd.Text = ""
        MessageBox.Show("تم الحفظ")
        dailyprofits.filldeb()
        If debitDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            debitDGV.FirstDisplayedScrollingRowIndex = debitDGV.Rows.Count - 1
            ' Optionally select the last row
            debitDGV.Rows(debitDGV.Rows.Count - 1).Selected = True
        End If
        totdeb()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If debitDGV.SelectedRows.Count > 0 Then
            DebitTblBindingNavigator.DeleteItem.PerformClick()
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
            Dim rawData(debitDGV.Rows.Count, debitDGV.Columns.Count - 1) As Object
            For col = 0 To debitDGV.Columns.Count - 1
                rawData(0, col) = debitDGV.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To debitDGV.Columns.Count - 1
                For row = 0 To debitDGV.Rows.Count - 1
                    rawData(row + 1, col) = debitDGV.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(debitDGV.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, debitDGV.Rows.Count + 1)
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
        debitsfrm_Load(e, e)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        tqa.Text = ""

        cashd.Text = ""
    End Sub

    Private Sub tqa_TextChanged(sender As Object, e As EventArgs) Handles tqa.TextChanged
        If tqa.Text = "0" Then
            Label3.Text = "0"
        Else
            Label3.Text = Val(tqa.Text) * Val(dr.Text)
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

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim newRow1 As DataRow = Me.MarketDataSet.debitTbl.NewRow()

        newRow1("sname") = ncust.Text
        newRow1("snum") = ""
        newRow1("debits") = npay.Text
        newRow1("credits") = "0"
        newRow1("date") = FormatDateTime(maindate.Value)
        ' Add the new row to the DataTable
        Me.MarketDataSet.debitTbl.Rows.Add(newRow1)

        ' Refresh the DataGridView to reflect the changes
        Me.debitDGV.Refresh()
        ncust.Text = ""
        npay.Text = ""
        If debitDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            debitDGV.FirstDisplayedScrollingRowIndex = debitDGV.Rows.Count - 1
            ' Optionally select the last row
            debitDGV.Rows(debitDGV.Rows.Count - 1).Selected = True
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If debitDGV.SelectedRows.Count > 0 Then
            DebitTblBindingNavigator.DeleteItem.PerformClick()
        Else
            MessageBox.Show("اختر سطر للمسح")
        End If
        ncust.Text = ""
        npay.Text = ""
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Me.Validate()
        Me.DebitTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)
        fillsupp()
        ncust.Text = ""
        npay.Text = ""
        MessageBox.Show("تم الحفظ")
        If debitDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            debitDGV.FirstDisplayedScrollingRowIndex = debitDGV.Rows.Count - 1
            ' Optionally select the last row
            debitDGV.Rows(debitDGV.Rows.Count - 1).Selected = True
        End If
        totdeb()
    End Sub

    Private Sub sname_Click(sender As Object, e As EventArgs) Handles sname.Click
        fillsupp()
    End Sub

    Private Sub debitDGV_MouseDown(sender As Object, e As MouseEventArgs) _
    Handles debitDGV.MouseDown

        If e.Button = MouseButtons.Right Then

            Dim hit As DataGridView.HitTestInfo =
                debitDGV.HitTest(e.X, e.Y)

            If hit.RowIndex >= 0 Then
                debitDGV.ClearSelection()
                debitDGV.Rows(hit.RowIndex).Selected = True
                debitDGV.CurrentCell = debitDGV.Rows(hit.RowIndex).Cells(0)
            End If

        End If

    End Sub
    Private Sub تفاصيلالفاتورةToolStripMenuItem_Click(
    sender As Object, e As EventArgs) _
    Handles تفاصيلالفاتورةToolStripMenuItem.Click

        If debitDGV.SelectedRows.Count = 0 Then Exit Sub

        Dim row As DataGridViewRow = debitDGV.SelectedRows(0)

        ' تأكد أن عمود snum موجود
        If Not debitDGV.Columns.Contains("snum") Then
            MessageBox.Show("عمود snum غير موجود")
            Exit Sub
        End If

        Dim snumValue As String =
        If(row.Cells("snum").Value, "").ToString()

        If String.IsNullOrWhiteSpace(snumValue) Then
            MessageBox.Show("لا يوجد رقم سند في هذا الصف")
            Exit Sub
        End If

        ' فتح الفورم وتمرير snum
        Dim frm As New debititem
        frm.snum.Text = snumValue
        frm.ShowDialog()

    End Sub
    Public Sub totdeb()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select SUM(debits)-SUM(credits) from debitTbl "
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 0
            tqa1.Text = num
        Else
            num = cmd.ExecuteScalar
            tqa1.Text = num
        End If
        cmd.Dispose()
        con.Close()
    End Sub
    Private Sub tqa1_TextChanged(sender As Object, e As EventArgs) Handles tqa1.TextChanged
        If tqa1.Text = "0" Then
            tqa2.Text = "0"
        Else
            tqa2.Text = Val(tqa1.Text) * Val(dr.Text)
        End If
    End Sub
End Class