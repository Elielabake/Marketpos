Imports System.Data.SqlClient

Public Class clientsstat
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Hide()
    End Sub
    Public Sub itemsstat()
        ' Assuming you have a connection to the database
        Dim conn As New SqlConnection(My.Settings.MARKETDBConnectionString)
        Dim cmd As New SqlCommand()
        Dim query As String

        ' SQL query to join orderstbl and ordertbl1 based on ordnum and filter by product and name
        query = "SELECT   sum(o.debit), sum(o.credit), sum(o.profit), sum(o.discount), sum(o.totd),o.pn , o.cn
         FROM ordertbl1 o
GROUP BY o.pn , o.cn
"

        cmd.CommandText = query
        cmd.Connection = conn

        ' Add parameters from textboxes

        ' Create a DataTable to store the result
        Dim dt As New DataTable()

        ' Open the connection, execute the query, and fill the DataGridView
        Try
            conn.Open()
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
            clientstatDGV.DataSource = dt

            ' Change column header names

            clientstatDGV.Columns(6).HeaderText = "اسم الزبون"
            clientstatDGV.Columns(5).HeaderText = "رقم الهاتف"
            clientstatDGV.Columns(0).HeaderText = "مجموع الديون"
            clientstatDGV.Columns(1).HeaderText = "مجموع الكاش"
            clientstatDGV.Columns(2).HeaderText = "مجموع الارباح"
            clientstatDGV.Columns(3).HeaderText = "مجموع الحسومات"
            clientstatDGV.Columns(4).HeaderText = "$/المجموع"


        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub clientsstat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        itemsstat()
    End Sub
    Public Function HighlightRowsBasedOnCost() As Boolean
        ' Define your SQL connection string
        Dim connectionString As String = My.Settings.MARKETDBConnectionString

        ' Loop through each row in the DataGridView
        For Each row As DataGridViewRow In clientstatDGV.Rows
            ' Ensure the row is not empty
            If row.IsNewRow Then Continue For

            ' Get the item name or ID (depending on what identifies the item in your orderDGV)
            Dim product As String = row.Cells(4).Value.ToString() ' Change "ItemIDColumn" to the actual column name/index for the item


            ' Compare price to costd, and if price is below cost, change row color to green
            If product < Val(name1.Text) Then
                row.DefaultCellStyle.BackColor = Color.Red
                row.DefaultCellStyle.SelectionBackColor = Color.IndianRed ' Keep the same color when the row is selected
            Else
                row.DefaultCellStyle.BackColor = Color.Green ' Reset color if necessary
                row.DefaultCellStyle.SelectionBackColor = Color.Green ' Reset selection color
            End If


        Next
        Return True
    End Function

    Private Sub name1_TextChanged(sender As Object, e As EventArgs) Handles name1.TextChanged
        HighlightRowsBasedOnCost()
    End Sub
End Class