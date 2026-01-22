Imports System.Data.SqlClient
Imports System.Data

Public Class prodstat
    Public Sub itemsstat()
        ' Assuming you have a connection to the database
        Dim conn As New SqlConnection(My.Settings.MARKETDBConnectionString)
        Dim cmd As New SqlCommand()
        Dim query As String

        ' SQL query to join orderstbl and ordertbl1 based on ordnum and filter by product and name
        query = "SELECT o.date, o.emp, o.ordnum, o.totl, o.totd, o.qty, o.pl, o.pd, o.dr, o.categ, o.pn, o.bc, o.Id
         FROM orderstbl o 
         INNER JOIN ordertbl1 o1 ON o.ordnum = o1.ordnum 
         WHERE o.pn = @ProductName AND o1.cn = @ClientName"

        cmd.CommandText = query
        cmd.Connection = conn

        ' Add parameters from textboxes
        cmd.Parameters.AddWithValue("@ProductName", product.Text)
        cmd.Parameters.AddWithValue("@ClientName", name1.Text)

        ' Create a DataTable to store the result
        Dim dt As New DataTable()

        ' Open the connection, execute the query, and fill the DataGridView
        Try
            conn.Open()
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
            prodDGV.DataSource = dt

            ' Change column header names
            prodDGV.Columns("date").HeaderText = "التاريخ"
            prodDGV.Columns("emp").HeaderText = "اسم الموظف"
            prodDGV.Columns("ordnum").HeaderText = "رقم الطلب"
            prodDGV.Columns("totl").HeaderText = "المجموع/ل.ل"
            prodDGV.Columns("totd").HeaderText = "$/المجموع"
            prodDGV.Columns("qty").HeaderText = "الكمية"
            prodDGV.Columns("pl").HeaderText = "السعر/ل.ل"
            prodDGV.Columns("pd").HeaderText = "$/السعر"
            prodDGV.Columns("dr").HeaderText = "سعر الدولار"
            prodDGV.Columns("categ").HeaderText = "الصنف"
            prodDGV.Columns("pn").HeaderText = "اسم المنتج"
            prodDGV.Columns("bc").HeaderText = "الباركود"
            prodDGV.Columns("Id").HeaderText = "العدد"

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        Me.Close()
    End Sub

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


End Class