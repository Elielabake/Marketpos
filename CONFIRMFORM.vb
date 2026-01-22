Imports System.Data.SqlClient

Public Class CONFIRMFORM
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Public Async Function FillProduct() As Task
        ' Use the connection and commands on the main thread
        con.Open()
        Try
            ' Use parameterized query to avoid SQL injection
            Dim query As String = "SELECT DISTINCT Uname FROM UserTbl WHERE rtype = @rtype"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@rtype", "رئيسي")

            Dim reader As SqlDataReader = Await cmd.ExecuteReaderAsync()

            Dim items As New List(Of String)
            While Await reader.ReadAsync()
                items.Add(reader("Uname").ToString())
            End While
            reader.Close() ' Ensure to close the reader

            ' Update UI on the main thread
            Invoke(New Action(Sub()
                                  Uname.Items.Clear()
                                  Uname.Items.AddRange(items.ToArray())
                                  If Uname.Items.Count > 0 Then
                                      Uname.SelectedIndex = 0
                                  End If
                              End Sub))
        Finally
            con.Close() ' Ensure the connection is closed even in case of an error
        End Try
    End Function

    ' Mark the load event as Async to use Await
    Private Async Sub CONFIRMFORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        AcceptButton = Button2
        Upass.Focus()

        ' Await the FillProduct call here
        Await FillProduct()

        Me.ResumeLayout()
    End Sub
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub
    Public ReadSuccess As Boolean = False ' This will store the result of reader.Read()

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Uname.Text = "" Or Upass.Text = "" Then
            MessageBox.Show("البيانات غير كاملة")
        Else
            Try
                con.Open()
                Dim stmt As String = "select * from UserTbl where Uname=N'" & Uname.Text & "' and Upass=N'" & Upass.Text & "'"
                Dim cmd As New SqlCommand(stmt, con)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then

                    ReadSuccess = True
                    Me.Hide()
                Else
                    MessageBox.Show("خطأ في الاسم او كلمة السر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Uname.Text = ""
                    Upass.Text = ""
                    ReadSuccess = False
                End If
            Catch ex As Exception
                MessageBox.Show("خطأ في الاسم او كلمة السر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            con.Close()
        End If
        Upass.Focus()
    End Sub
End Class