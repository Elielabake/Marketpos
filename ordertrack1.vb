Imports System.Data.SqlClient
Imports DocumentFormat.OpenXml.Drawing.Charts
Public Class ordertrack1
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub ordertrack1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.orderTransactions' table. You can move, or remove it, as needed.
        Me.OrderTransactionsTableAdapter.FillBy(Me.MARKETDataSet.orderTransactions)


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con.Open()
        Dim query As String
        query = "delete from orderTransactions "
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("تم المسح")


        con.Close()
        Me.OrderTransactionsTableAdapter.Fill(Me.MARKETDataSet.orderTransactions)

    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Me.OrderTransactionsTableAdapter.FillBy(Me.MARKETDataSet.orderTransactions)

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Me.OrderTransactionsTableAdapter.Fill(Me.MARKETDataSet.orderTransactions)

    End Sub
End Class