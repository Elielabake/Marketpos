Imports System.Data.SqlClient

Public Class ordcheck
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Public Property OrderNumber As Integer
    Public Property DrValue As String


    Private Sub ordcheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        label33.Text = OrderNumber.ToString()
        orgord.Text = OrderNumber.ToString()
        dr.Text = DrValue
    End Sub


    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click
        label33.Text = Val(label33.Text) - 1
        changedord()
        Dim v33 As Integer
        Dim vorg As Integer

        If Integer.TryParse(label33.Text, v33) AndAlso Integer.TryParse(orgord.Text, vorg) Then

            If v33 < vorg - 1 Then
                Label35.Enabled = True
            Else
                Label35.Enabled = False
            End If

        Else
            '  MessageBox.Show("Invalid numbers.")
        End If

    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click
        label33.Text = Val(label33.Text) + 1
        changedord()
        Dim v33 As Integer
        Dim vorg As Integer

        If Integer.TryParse(label33.Text, v33) AndAlso Integer.TryParse(orgord.Text, vorg) Then

            If v33 < vorg - 1 Then
                Label35.Enabled = True
            Else
                Label35.Enabled = False
            End If

        Else
            ' MessageBox.Show("Invalid numbers.")
        End If


    End Sub

    Private Sub changedord()
        Dim ordnumfill As Integer
        If Not Integer.TryParse(label33.Text, ordnumfill) Then
            MessageBox.Show("Invalid order number.")
            Exit Sub
        End If

        Dim query As String = "SELECT * FROM ordersTbl WHERE ordnum = @ord"

        Dim dt As New DataTable()

        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ord", ordnumfill)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        orderDGV.DataSource = dt
        tot2()
    End Sub
    Private Sub changedord1()
        Dim ordnumfill As Integer
        If Not Integer.TryParse(label33.Text, ordnumfill) Then
            MessageBox.Show("Invalid order number.")
            Exit Sub
        End If

        Dim query As String = "SELECT * FROM ordernew WHERE ordnum = @ord"

        Dim dt As New DataTable()

        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ord", ordnumfill)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        orderDGV.DataSource = dt

    End Sub
    Public Sub tot2()
        Try


            ' Validate ordnum
            Dim ordNum As Integer
            If Not Integer.TryParse(label33.Text, ordNum) Then
                totd.Text = "0"
                Exit Sub
            End If

            ' Query database safely
            Dim total As Decimal = 0
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                Using cmd As New SqlCommand("SELECT SUM(totd) from ordersTbl WHERE ordnum = @ordnum", con)
                    cmd.Parameters.AddWithValue("@ordnum", ordNum)
                    con.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        total = Convert.ToDecimal(result)
                    End If
                End Using
            End Using

            ' Subtract discount
            Dim finalTotal As Decimal = total

            ' ✅ Remove unnecessary trailing zeros (but keep real decimals)
            totd.Text = finalTotal.ToString("0.####################")

        Catch ex As Exception
            MessageBox.Show("Error calculating total: " & ex.Message)
            totd.Text = "0"
        End Try
    End Sub
    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click
        Dim v33 As Integer
        Dim vorg As Integer

        If Integer.TryParse(label33.Text, v33) AndAlso Integer.TryParse(orgord.Text, vorg) Then
            If v33 = vorg Then
                Exit Sub  ' <- exits immediately, nothing else runs
            End If
        End If
        label33.Text = orgord.Text
        changedord1()
        Dim ordnumfill As Integer
        If Not Integer.TryParse(label33.Text, ordnumfill) Then
            ordnumfill = 0
        End If
        'TODO: This line of code loads data into the 'MarketDataSet.Ordernew' table. You can move, or remove it, as needed.

    End Sub

    Private Sub label33_TextChanged(sender As Object, e As EventArgs) Handles label33.TextChanged
        Dim v33 As Integer
        Dim vorg As Integer

        If Integer.TryParse(label33.Text, v33) AndAlso Integer.TryParse(orgord.Text, vorg) Then

            If v33 < vorg - 1 Then
                Label35.Enabled = True
            Else
                Label35.Enabled = False
            End If

        Else
            '      MessageBox.Show("Invalid numbers.")
        End If
    End Sub

    Private Sub orgord_TextChanged(sender As Object, e As EventArgs) Handles orgord.TextChanged
        Dim v33 As Integer
        Dim vorg As Integer

        If Integer.TryParse(label33.Text, v33) AndAlso Integer.TryParse(orgord.Text, vorg) Then

            If v33 < vorg - 1 Then
                Label35.Enabled = True
            Else
                Label35.Enabled = False
            End If

        Else
            '     MessageBox.Show("Invalid numbers.")
        End If
    End Sub

    Private Sub totd_TextChanged(sender As Object, e As EventArgs) Handles totd.TextChanged
        totl.Text = Math.Round(Val(totd.Text) * Val(dr.Text))
    End Sub


End Class