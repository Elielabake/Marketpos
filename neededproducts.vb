Imports System.Data.SqlClient
Imports Dnp.Data.Connection

Public Class neededproducts
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Close()
    End Sub
    Private Sub neededproducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fromdate.Value = Date.Now.AddDays(0)
        todate.Value = Date.Now.AddDays(0)
        LoadData1()
        Label2.Text = "1"
    End Sub
    Private Sub LoadData()
        Try
            Dim query As String = "SELECT pn AS pname,categ as cat, SUM(qty) AS total_qty, SUM(costd * qty) AS total_COST, SUM(profit) AS total_prof " &
                                  "FROM orderstbl " &
                                  "WHERE CAST([date] AS DATE) BETWEEN @fromDate AND @toDate " &
                                   "AND categ =N'الخضار' " &
                                      "GROUP BY pn,categ"

            Using cmd As New SqlCommand(query, con)
                ' Add parameters for date filtering
                cmd.Parameters.AddWithValue("@fromDate", fromdate.Value.Date)
                cmd.Parameters.AddWithValue("@toDate", todate.Value.Date)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()

                con.Open()
                adapter.Fill(table)
                con.Close()

                ' Bind the DataTable to the DataGridView
                npDGV.DataSource = table
                npDGV.Columns("pname").HeaderText = "اسم المنتج"
                npDGV.Columns("cat").HeaderText = "الصنف"
                npDGV.Columns("total_qty").HeaderText = "الكمية"
                npDGV.Columns("total_COST").HeaderText = "مجموع التكلغة"
                npDGV.Columns("total_prof").HeaderText = "مجموع الربح"
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub LoadData1()
        Try
            Dim query As String = "SELECT pn AS pname,categ as cat, SUM(qty) AS total_qty, SUM(costd * qty) AS total_COST, SUM(profit) AS total_prof " &
                                  "FROM orderstbl " &
                                  "WHERE CAST([date] AS DATE) BETWEEN @fromDate AND @toDate " &
                                  "AND categ <>N'الخضار' and categ <>N'فروج' " &
                                      "GROUP BY pn,categ"

            Using cmd As New SqlCommand(query, con)
                ' Add parameters for date filtering
                cmd.Parameters.AddWithValue("@fromDate", fromdate.Value.Date)
                cmd.Parameters.AddWithValue("@toDate", todate.Value.Date)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()

                con.Open()
                adapter.Fill(table)
                con.Close()

                ' Bind the DataTable to the DataGridView
                npDGV.DataSource = table
                npDGV.Columns("pname").HeaderText = "اسم المنتج"
                npDGV.Columns("cat").HeaderText = "الصنف"
                npDGV.Columns("total_qty").HeaderText = "الكمية"
                npDGV.Columns("total_COST").HeaderText = "مجموع التكلغة"
                npDGV.Columns("total_prof").HeaderText = "مجموع الربح"
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadData3()
        Try
            Dim query As String = "SELECT pn AS pname,categ as cat, SUM(qty) AS total_qty, SUM(costd * qty) AS total_COST, SUM(profit) AS total_prof " &
                                  "FROM orderstbl " &
                                  "WHERE CAST([date] AS DATE) BETWEEN @fromDate AND @toDate " &
                                "AND categ =N'فروج' " &
                                      "GROUP BY pn,categ"

            Using cmd As New SqlCommand(query, con)
                ' Add parameters for date filtering
                cmd.Parameters.AddWithValue("@fromDate", fromdate.Value.Date)
                cmd.Parameters.AddWithValue("@toDate", todate.Value.Date)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()

                con.Open()
                adapter.Fill(table)
                con.Close()

                ' Bind the DataTable to the DataGridView
                npDGV.DataSource = table
                npDGV.Columns("pname").HeaderText = "اسم المنتج"
                npDGV.Columns("cat").HeaderText = "الصنف"
                npDGV.Columns("total_qty").HeaderText = "الكمية"
                npDGV.Columns("total_COST").HeaderText = "مجموع التكلغة"
                npDGV.Columns("total_prof").HeaderText = "مجموع الربح"
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Label2.Text = "1"
        LoadData1()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Label2.Text = "2"
        LoadData()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Label2.Text = "3"
        LoadData3()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label2.Text = "1" Then
            LoadData1()
        ElseIf Label2.Text = "2" Then
            LoadData()
        ElseIf Label2.Text = "3" Then
            LoadData3()
        End If
    End Sub
End Class