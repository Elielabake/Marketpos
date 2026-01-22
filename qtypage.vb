Imports Zuby
Imports System.Data.SqlClient
Public Class qtypage
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        stock.Show()
        Me.Close()
    End Sub
    Private Sub LoadData1()
        Try

            Dim query As String = "SELECT pname AS pn,cat as cat ,SUM(qavailable) AS total_qty " &
                                      "FROM stock " &
                                      "WHERE qtym >= qavailable AND qavailable >= 0" &
                                        " GROUP BY pname,cat"

            Using cmd As New SqlCommand(query, con)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()

                con.Open()
                adapter.Fill(table)
                con.Close()

                ' Bind the DataTable to the DataGridView
                DGV.DataSource = table
                DGV.Columns("pn").HeaderText = "اسم المنتج"
                DGV.Columns("cat").HeaderText = "الصنف"
                DGV.Columns("total_qty").HeaderText = "الكمية"
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub LoadData2()
        Try

            Dim query As String = "SELECT pname AS pn,cat as cat ,SUM(qavailable) AS total_qty " &
                                      "FROM stock " &
                                      "WHERE qtym >= qavailable AND qavailable < 0" &
                                        " GROUP BY pname,cat"

            Using cmd As New SqlCommand(query, con)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()

                con.Open()
                adapter.Fill(table)
                con.Close()

                ' Bind the DataTable to the DataGridView
                DGV.DataSource = table
                DGV.Columns("pn").HeaderText = "اسم المنتج"
                DGV.Columns("cat").HeaderText = "الصنف"
                DGV.Columns("total_qty").HeaderText = "الكمية"
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub qtypage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData1()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        LoadData1()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        LoadData2()
    End Sub
End Class