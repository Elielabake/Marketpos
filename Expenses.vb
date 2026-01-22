Imports System.Data.SqlClient

Public Class Expenses
    ' Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)


    Private Sub Expenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.expTbl' table. You can move, or remove it, as needed.
        Me.ExpTblTableAdapter.Fill(Me.MARKETDataSet.expTbl)

        Me.ExpTblTableAdapter.Fill(Me.MARKETDataSet.expTbl)
        filldr()
        AcceptButton = Button1
        If expenseDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            expenseDGV.FirstDisplayedScrollingRowIndex = expenseDGV.Rows.Count - 1
            ' Optionally select the last row
            expenseDGV.Rows(expenseDGV.Rows.Count - 1).Selected = True
        End If
        con.Open()
        Dim cmd2 As New SqlCommand("SELECT exp FROM expTbl", con)
        Dim ds2 As New DataSet
        Dim da2 As New SqlDataAdapter(cmd2)
        da2.Fill(ds2, "list")
        Dim col2 As New AutoCompleteStringCollection
        Dim i2 As Integer
        For i2 = 0 To ds2.Tables(0).Rows.Count - 1
            col2.Add(ds2.Tables(0).Rows(i2)("exp").ToString())
        Next
        expbtn.AutoCompleteSource = AutoCompleteSource.CustomSource
        expbtn.AutoCompleteCustomSource = col2
        expbtn.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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


    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ExpTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        expbtn.Text = ""
        ad.Text = ""
        al.Text = ""
        MessageBox.Show("تم الحفظ")
        dailyprofits.exp1()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newRow1 As DataRow = Me.MarketDataSet.expTbl.NewRow()

        newRow1("exp") = expbtn.Text
        newRow1("dr") = dr.Text
        newRow1("amountd") = ad.Text
        newRow1("amountl") = al.Text
        newRow1("date") = FormatDateTime(maindate.Value)
        ' Add the new row to the DataTable
        Me.MarketDataSet.expTbl.Rows.Add(newRow1)
        '    Me.ExpTblTableAdapter.Fill(Me.MARKETDataSet.expTbl)
        ' Refresh the DataGridView to reflect the changes
        expenseDGV.Refresh()
        Me.Validate()
        Me.ExpTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        expbtn.Text = ""
        ad.Text = ""
        al.Text = ""
        ' MessageBox.Show("تم الحفظ")
        dailyprofits.exp1()
        If expenseDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            expenseDGV.FirstDisplayedScrollingRowIndex = expenseDGV.Rows.Count - 1
            ' Optionally select the last row
            expenseDGV.Rows(expenseDGV.Rows.Count - 1).Selected = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If expenseDGV.SelectedRows.Count > 0 Then
            ExpTblBindingNavigator.DeleteItem.PerformClick()
        Else
            MessageBox.Show("اختر سطر للمسح")
        End If
        Me.Validate()
        Me.ExpTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        expbtn.Text = ""
        ad.Text = ""
        al.Text = ""
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
            Dim rawData(expenseDGV.Rows.Count, expenseDGV.Columns.Count - 1) As Object
            For col = 0 To expenseDGV.Columns.Count - 1
                rawData(0, col) = expenseDGV.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To expenseDGV.Columns.Count - 1
                For row = 0 To expenseDGV.Rows.Count - 1
                    rawData(row + 1, col) = expenseDGV.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(expenseDGV.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, expenseDGV.Rows.Count + 1)
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
        Expenses_Load(e, e)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        expbtn.Text = ""
        ad.Text = ""
        al.Text = ""
    End Sub
    Private shouldstop As Boolean = False
    Private Sub dr_TextChanged(sender As Object, e As EventArgs) Handles dr.TextChanged
        ad.Text = Val(al.Text) / Val(dr.Text)
        al.Text = Val(ad.Text) * Val(dr.Text)
    End Sub

    Private Sub ad_TextChanged(sender As Object, e As EventArgs) Handles ad.TextChanged
        If ad.Focused Then
            shouldstop = False
            al.Text = Math.Round(Val(ad.Text) * Val(dr.Text), 0).ToString()
        Else
            shouldstop = True
        End If
    End Sub

    Private Sub al_TextChanged(sender As Object, e As EventArgs) Handles al.TextChanged
        Dim result As Decimal
        If Decimal.TryParse(al.Text, result) AndAlso Val(dr.Text) <> 0 Then
            RemoveHandler ad.TextChanged, AddressOf ad_TextChanged
            ad.Text = Math.Round(result / Val(dr.Text), 5)
            AddHandler ad.TextChanged, AddressOf ad_TextChanged
        End If
        If al.Text = "" Then
            ad.Text = "0"
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Delete Then
            ' Trigger the click event of the "Save" button
            Button2.PerformClick()
            Return True ' Indicate that the key press has been handled
        End If




        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub expenseDGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles expenseDGV.CellEndEdit
        Me.Validate()
        Me.ExpTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MARKETDataSet)
        expbtn.Text = ""
        ad.Text = ""
        al.Text = ""
    End Sub
End Class