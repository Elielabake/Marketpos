Imports System.Data.SqlClient

Public Class profitssummation
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub profitssummation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub tsshow()
        Dim num As Decimal = 0
        Dim cmd As New SqlCommand()
        cmd.Connection = con
        con.Open()

        ' Use parameterized query to prevent SQL injection
        cmd.CommandText = "SELECT SUM(prof) FROM dailyp WHERE date BETWEEN @FromDate AND @ToDate"
        cmd.Parameters.AddWithValue("@FromDate", FromDate.Value)
        cmd.Parameters.AddWithValue("@ToDate", ToDate.Value)

        Dim result As Object = cmd.ExecuteScalar()

        If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
            num = Convert.ToDecimal(result)
        End If

        tots.Text = num.ToString()

        cmd.Dispose()
        con.Close()

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        tsshow()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub

    Private isDragging As Boolean = False
    Private startPoint As Point

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseMove
        If isDragging Then
            Dim currentPoint As Point = PointToScreen(e.Location)
            Location = New Point(currentPoint.X - startPoint.X, currentPoint.Y - startPoint.Y)
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub


End Class