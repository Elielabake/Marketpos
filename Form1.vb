Imports System.Data.SqlClient
Imports System.Drawing.Bitmap
Imports System.IO
Imports Market.MARKETDataSetTableAdapters
Public Class Form1
    Private con As SqlConnection
    Private appScreen As Screen

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        ' Capture the screen where the main form is shown
        appScreen = Screen.FromControl(Me)

        ' Initialize the SQL connection using the Start form's TextBox value
        con = New SqlConnection(My.Settings.MARKETDBConnectionString)


    End Sub

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub CustomerDate_ValueChanged(sender As Object, e As EventArgs) Handles maindate.ValueChanged
        maindate.Value = DateTime.Now
    End Sub

    Private Sub AutoID()
        Try
            Dim cmd As New SqlCommand("SELECT MAX(Id) FROM UserloginTbl", con)
            con.Open()
            Dim maxId As Object = cmd.ExecuteScalar()
            id.Text = If(IsDBNull(maxId), 1, maxId.ToString())
        Catch ex As Exception
            MessageBox.Show($"Error generating AutoID: {ex.Message}")
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim response As DialogResult = MessageBox.Show("هل أنت متأكد من الخروج؟", "الخروج من البرنامج", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If response = DialogResult.Yes Then
            AutoID()

            Application.ExitThread()
        End If
    End Sub


    Private Sub HandleButtonClick(formToShow As Form)
        MoveToAppScreen(formToShow)
        formToShow.Show()

        Me.Hide()
    End Sub

    ' Method to move a form to the application's screen
    Private Sub MoveToAppScreen(form As Form)
        form.StartPosition = FormStartPosition.Manual
        form.Location = appScreen.Bounds.Location
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        HandleButtonClick(invoice)
    End Sub

    Private Sub Guna2Button12_Click(sender As Object, e As EventArgs) Handles Guna2Button12.Click
        HandleButtonClick(categfrm)
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        HandleButtonClick(stock)

    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        HandleButtonClick(suppliersdebit)
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        HandleButtonClick(Expenses)
    End Sub




    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        HandleButtonClick(allorders)
        orderfrm3.emp.Text = Label7.Text
    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        HandleButtonClick(clientsfrm)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        HandleButtonClick(equipments)
    End Sub

    Private Sub Guna2Button18_Click(sender As Object, e As EventArgs) Handles Guna2Button18.Click
        HandleButtonClick(dailyprofits)
    End Sub

    Private Sub Guna2Button17_Click(sender As Object, e As EventArgs) Handles Guna2Button17.Click
        HandleButtonClick(cashier)
    End Sub

    Private Sub Guna2Button16_Click(sender As Object, e As EventArgs) Handles Guna2Button16.Click
        HandleButtonClick(reports)
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        HandleButtonClick(neededproducts)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        AutoID()

        Loginpage.Show()
        Loginpage.Upass.Clear()
        Loginpage.Upass.Focus()
        Me.Close()
    End Sub





    Private Sub Guna2Button7_Click_1(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        HandleButtonClick(debitsfrm)
    End Sub

    Private Sub Guna2Button15_Click_1(sender As Object, e As EventArgs) Handles Guna2Button15.Click
        HandleButtonClick(clientsstat)
    End Sub

    Private Sub Guna2Button19_Click(sender As Object, e As EventArgs) Handles Guna2Button19.Click
        HandleButtonClick(ordertrack1)
    End Sub

    Private Sub Guna2Button20_Click(sender As Object, e As EventArgs) Handles Guna2Button20.Click
        HandleButtonClick(invoicereturn)
    End Sub

    Private Sub Guna2Button21_Click(sender As Object, e As EventArgs) Handles Guna2Button21.Click
        HandleButtonClick(itemreport)
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        HandleButtonClick(orderfrm2)
    End Sub


    Private Sub BackupDatabaseOnStartup()

        Dim saveDlg As New SaveFileDialog()
        saveDlg.Title = "Save SQL Backup"
        saveDlg.Filter = "SQL Backup (*.bak)|*.bak"
        saveDlg.FileName = "MARKETDB_" & DateTime.Now.ToString("dd-MM-yyyy") & ".bak"

        If saveDlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim userDestination As String = saveDlg.FileName
        Dim tempFolder As String = "C:\SQLTempBackup"

        If Not Directory.Exists(tempFolder) Then
            Directory.CreateDirectory(tempFolder)
        End If

        ' ✅ UNIQUE temp file every time
        Dim tempFile As String =
        Path.Combine(tempFolder, "tempbackup_" & Guid.NewGuid().ToString() & ".bak")

        Try
            Using con As New SqlConnection(
            "Data Source=localhost\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True")

                con.Open()

                Dim sql As String =
                "BACKUP DATABASE MARKETDB " &
                "TO DISK = @path " &
                "WITH INIT, FORMAT"

                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.Add("@path", SqlDbType.NVarChar).Value = tempFile
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            File.Copy(tempFile, userDestination, True)

            MessageBox.Show("Backup saved successfully:" & vbCrLf & userDestination)

        Catch ex As Exception
            MessageBox.Show("Backup FAILED:" & vbCrLf & ex.Message)
        End Try

    End Sub



    Private Sub Guna2Button22_Click(sender As Object, e As EventArgs) Handles Guna2Button22.Click
        Me.BeginInvoke(New Action(AddressOf BackupDatabaseOnStartup))
    End Sub

    Private Sub Guna2Button23_Click(sender As Object, e As EventArgs) Handles Guna2Button23.Click
        frmReceiptSettings.Show()
    End Sub
End Class
