Imports System.Data.SqlClient



Public Class FrmStockCodes

        Public Property StockId As Integer
        Public Property MainCode As String

        Private con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Private Sub FrmStockCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtStockId.Text = StockId.ToString()
        txtMainCode.Text = MainCode
        LoadCodes()
    End Sub
    Private Sub LoadCodes()
        Dim dt As New DataTable

        Using da As New SqlDataAdapter(
        "SELECT Id, AltCode FROM stock_codes WHERE StockId=@id", con)
            da.SelectCommand.Parameters.AddWithValue("@id", StockId)
            da.Fill(dt)
        End Using

        dgvCodes.DataSource = dt
        dgvCodes.Columns(0).Visible = False
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If txtAltCode.Text.Trim = "" Then Exit Sub

        Using cmd As New SqlCommand(
        "INSERT INTO stock_codes (StockId, AltCode) VALUES (@sid,@code)", con)

            cmd.Parameters.AddWithValue("@sid", StockId)
            cmd.Parameters.AddWithValue("@code", txtAltCode.Text.Trim)

            con.Open()
            Try
                cmd.ExecuteNonQuery()
                txtAltCode.Clear()
                LoadCodes()
            Catch ex As SqlException
                MessageBox.Show("الباركود موجود مسبقاً")
            Finally
                con.Close()
            End Try
        End Using

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If dgvCodes.SelectedRows.Count = 0 Then Exit Sub

        Dim id As Integer = CInt(dgvCodes.SelectedRows(0).Cells(0).Value)

        Using cmd As New SqlCommand(
        "DELETE FROM stock_codes WHERE Id=@id", con)

            cmd.Parameters.AddWithValue("@id", id)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using

        LoadCodes()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

        Me.Close()
    End Sub
End Class