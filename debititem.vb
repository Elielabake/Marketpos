Imports System.Data.SqlClient
Public Class debititem
    Private Sub debititem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.orderstbl' table. You can move, or remove it, as needed.
        'Me.OrderstblTableAdapter.Fill(Me.MARKETDataSet.orderstbl)
        LoadOrdersBySnum()
    End Sub
    Private Sub LoadOrdersBySnum()

        Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)

            Dim da As New SqlDataAdapter(
            "SELECT * FROM orderstbl WHERE ordnum = @ordnum", con)

            da.SelectCommand.Parameters.AddWithValue("@ordnum", snum.Text.Trim())

            Dim dt As New DataTable
            da.Fill(dt)

            debitDGV.DataSource = dt

        End Using

    End Sub

End Class