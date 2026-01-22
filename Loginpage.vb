Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Guna.UI2.WinForms

Public Class Loginpage
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    ' Change Sub to Async Function and return a Task
    Public Async Function FillProduct() As Task
        Await Task.Run(Sub()
                           con.Open()
                           Dim str As New SqlCommand("select DISTINCT Uname from UserTbl", con)
                           Dim reader As SqlDataReader = str.ExecuteReader()

                           Dim items As New List(Of String)
                           While reader.Read
                               items.Add(reader("Uname").ToString())
                           End While
                           con.Close()

                           ' Update UI on the main thread
                           Invoke(New Action(Sub()
                                                 Uname.Items.Clear()
                                                 Uname.Items.AddRange(items.ToArray())
                                                 If Uname.Items.Count > 0 Then
                                                     Uname.SelectedIndex = 0
                                                 End If
                                             End Sub))
                       End Sub)
    End Function

    ' Loginpage_Load should also be Async to allow awaiting FillProduct
    Private isFormLoading As Boolean = True

    Private Async Sub Loginpage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isFormLoading = True
        Me.SuspendLayout()


        Upass.Focus()

        Await FillProduct()

        Me.ResumeLayout()

    End Sub

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim response As Integer
        response = MessageBox.Show("هل أنت متأكد من الخروج؟", "الخروج من البرنامج", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If response = vbYes Then
            Application.ExitThread()
        End If
    End Sub

    Private Sub Uname_SelectedValueChanged(sender As Object, e As EventArgs) Handles Uname.SelectedValueChanged
        If Uname.Text = "" Then
            rtype.Text = ""
        Else
            FetchDataname()
        End If
        Upass.Focus()
    End Sub

    Private Sub FetchDataname()
        con.Open()
        Dim query = "select * from UserTbl where Uname=N'" & Uname.Text & "'"
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While reader.Read
            rtype.Text = reader(3).ToString()

        End While
        con.Close()
    End Sub
    Private Sub CheckStockLevels()
        Dim connString As String = My.Settings.MARKETDBConnectionString
        Dim query As String = "SELECT COUNT(*) FROM stock WHERE qtym >= qavailable"

        Try
            Using con As New SqlConnection(connString)
                con.Open()

                Using cmd As New SqlCommand(query, con)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If count > 0 Then
                        Dim toast As New ToastNotification("انتباه في المخزون", "⚠ تأكد من كميات المنتجات في المخزون")

                        ' When the toast closes → call CheckStockLevels1
                        AddHandler toast.Closed, Sub(sender, e)
                                                     CheckStockLevels1()
                                                 End Sub

                        toast.Show()
                    Else
                        ' If nothing to show → run the second check directly
                        CheckStockLevels1()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Dim toast As New ToastNotification("Error", "Error checking stock: " & ex.Message)
            toast.Show()
        End Try
    End Sub

    Private Sub CheckStockLevels1()
        Dim connString As String = My.Settings.MARKETDBConnectionString
        Dim query As String = "SELECT COUNT(*) FROM invoicedateTbl WHERE CAST(GETDATE() AS DATE) >= CAST(date2 AS DATE) and che=" & 0 & ""

        Try
            Using con As New SqlConnection(connString)
                con.Open()

                Using cmd As New SqlCommand(query, con)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If count > 0 Then
                        Dim toast As New ToastNotification("انتباه في الفواتير", "⚠ بعض المنتجات انتهت مدة صلاحيتها تأكد من الفواتير")
                        toast.Show()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Dim toast As New ToastNotification("Error", "Error checking stock: " & ex.Message)
            toast.Show()
        End Try
    End Sub


    Private Sub Upass_TextChanged(sender As Object, e As EventArgs) Handles Upass.TextChanged
        If isFormLoading Then
            ' Skip the event during form load
            Return
        End If
        If Upass.Text = "" Then
            ' MessageBox.Show("البيانات غير كاملة")
        Else
            Try
                con.Open()
                Dim stmt As String = "select * from UserTbl where Uname=N'" & Uname.Text & "' and Upass=N'" & Upass.Text & "' and rtype=N'" & rtype.Text & "'"
                Dim cmd As New SqlCommand(stmt, con)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Form1.Label7.Text = Uname.Text
                    Form1.Show()
                    Me.Hide()
                    CheckStockLevels()
                    ' CheckStockLevels1()
                Else

                End If
            Catch ex As Exception
                MessageBox.Show("خطأ في الاسم او كلمة السر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            con.Close()
        End If
        Upass.Focus()
        Form1.Labelt.Text = rtype.Text
        If rtype.Text = "ثانوي" Then
            Form1.Guna2Button1.Enabled = False
            Form1.Guna2Button2.Enabled = False

            Form1.Guna2Button6.Enabled = False
            Form1.Guna2Button5.Enabled = False
            Form1.Guna2Button9.Enabled = False
            Form1.Guna2Button10.Enabled = False
            Form1.Guna2Button11.Enabled = False
            Form1.Guna2Button12.Enabled = False
            Form1.Guna2Button7.Enabled = False
            Form1.Guna2Button14.Enabled = False
            Form1.Guna2Button15.Enabled = False
            Form1.Guna2Button16.Enabled = False
            Form1.Guna2Button17.Enabled = False
            Form1.Guna2Button18.Enabled = False

            Form1.Guna2Button16.Enabled = False

        End If
    End Sub


    Private Sub Upass_KeyDown(sender As Object, e As KeyEventArgs) Handles Upass.KeyDown
        If e.KeyCode = Keys.Home Then
            User.Show()
            Me.Close()
        End If
        If e.Control AndAlso e.KeyCode = Keys.S Then
            frmCheckDB.Show()
            Me.Close()
        End If

    End Sub
    Private Sub Form_LoadComplete(sender As Object, e As EventArgs) Handles MyBase.Load
        ' After form is loaded, re-enable the TextChanged event
        isFormLoading = False
    End Sub

End Class
