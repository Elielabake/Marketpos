Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class allorders
    ' Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Public Sub ordnum1()

        Dim num As Integer
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select MAX(ordnum) From ordertbl1"
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 1
            ordnum.Text = num
        Else
            num = cmd.ExecuteScalar + 1
            ordnum.Text = num
        End If
        cmd.Dispose()
        con.Close()
    End Sub
    Private Function FetchDataFromSource() As Object
        ' Implement data fetching logic here
        Return New Object() ' Return some example data
    End Function
    Public Sub allorders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.ordertbl1' table. You can move, or remove it, as needed.



        Me.OrderstblTableAdapter.FillBy2(Me.MarketDataSet.orderstbl)
        Me.Ordertbl1TableAdapter.FillBy3(Me.MarketDataSet.ordertbl1)
        ordnum1()


    End Sub
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Close()
    End Sub



    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.Controls.Clear()
        InitializeComponent()
        allorders_Load(e, e)
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
            Dim rawData(allordersDGV.Rows.Count, allordersDGV.Columns.Count - 1) As Object
            For col = 0 To allordersDGV.Columns.Count - 1
                rawData(0, col) = allordersDGV.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To allordersDGV.Columns.Count - 1
                For row = 0 To allordersDGV.Rows.Count - 1
                    rawData(row + 1, col) = allordersDGV.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(allordersDGV.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, allordersDGV.Rows.Count + 1)
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

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim sheetIndex As Integer
            Dim Ex As Object
            Dim Wb As Object
            Dim Ws As Object
            Ex = CreateObject("Excel.Application")
            Wb = Ex.workbooks.add
            Dim col, row As Integer
            Dim rawData(order1dgv.Rows.Count, order1dgv.Columns.Count - 1) As Object
            For col = 0 To order1dgv.Columns.Count - 1
                rawData(0, col) = order1dgv.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To order1dgv.Columns.Count - 1
                For row = 0 To order1dgv.Rows.Count - 1
                    rawData(row + 1, col) = order1dgv.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(order1dgv.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, order1dgv.Rows.Count + 1)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        con.Open()
        Dim query As String
        query = "delete from orderstbl "
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("تم المسح")


        con.Close()

        'TODO: This line of code loads data into the 'MarketDataSet.orderstbl' table. You can move, or remove it, as needed.
        Me.OrderstblTableAdapter.Fill(Me.MarketDataSet.orderstbl)
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        con.Open()
        Dim query As String
        query = "delete from ordertbl1 "
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("تم المسح")


        con.Close()
        'TODO: This line of code loads data into the 'MarketDataSet.ordertbl1' table. You can move, or remove it, as needed.
        Me.Ordertbl1TableAdapter.Fill(Me.MarketDataSet.ordertbl1)
        ordnum1()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click

        'TODO: This line of code loads data into the 'MarketDataSet.orderstbl' table. You can move, or remove it, as needed.
        Me.OrderstblTableAdapter.Fill(Me.MarketDataSet.orderstbl)

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Me.Ordertbl1TableAdapter.Fill(Me.MarketDataSet.ordertbl1)

    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Me.OrderstblTableAdapter.FillBy2(Me.MarketDataSet.orderstbl)

    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Me.Ordertbl1TableAdapter.FillBy3(Me.MarketDataSet.ordertbl1)
    End Sub
End Class