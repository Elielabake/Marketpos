Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports Guna.UI2.WinForms

Public Class User
    ' Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub userDGV_SortStringChanged(sender As Object, e As Zuby.ADGV.AdvancedDataGridView.SortEventArgs) Handles Userdgv.SortStringChanged
        Me.UserTblBindingSource.Sort = Me.Userdgv.SortString
    End Sub

    Private Sub AdvancedDataGridView1_FilterStringChanged(sender As Object, e As Zuby.ADGV.AdvancedDataGridView.FilterEventArgs) Handles Userdgv.FilterStringChanged
        Me.UserTblBindingSource.Filter = Me.Userdgv.FilterString
    End Sub
    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.UserTbl' table. You can move, or remove it, as needed.
        Me.UserTblTableAdapter.Fill(Me.MARKETDataSet.UserTbl)
        'TODO: This line of code loads data into the 'MarketDataSet.UserTbl' table. You can move, or remove it, as needed.
        Me.UserTblTableAdapter.Fill(Me.MarketDataSet.UserTbl)


        Me.WindowState = FormWindowState.Maximized
        Me.AcceptButton = button1
        Me.CancelButton = Button3
    End Sub
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Check if there are unsaved changes in the DataTable
        If MARKETDataSet.UserTbl.GetChanges() IsNot Nothing Then
            ' Display a Yes/No message box
            Dim result As DialogResult = MessageBox.Show("هل تريد حفظ التغيرات؟", "التأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' Check the user's choice
            If result = vbNo Then
                Me.Close()
                ' Cancel the form closing event
                Loginpage.Show()
            Else
                Me.Validate()
                Me.UserTblBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)
                MessageBox.Show("تم الحفظ")
                Me.Close()
                Loginpage.Show()
            End If
        Else
            Me.Close()
            Loginpage.Show()
        End If

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Validate()
        Me.UserTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)
        Uname.Text = ""
        Upass.Text = ""

    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Check if the F1 key is pressed
        If keyData = Keys.F1 Then
            ' Trigger the click event of the "Save" button
            Button2.PerformClick()
            Return True ' Indicate that the key press has been handled
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim newRow As DataRow = MARKETDataSet.UserTbl.NewRow()

        newRow("Uname") = Uname.Text
        newRow("Upass") = Upass.Text
        newRow("rtype") = RType.Text

        ' Add the new row to the DataTable
        Me.MarketDataSet.UserTbl.Rows.Add(newRow)

        ' Refresh the DataGridView to reflect the changes
        Userdgv.Refresh()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Userdgv.SelectedRows.Count > 0 Then
            UserTblBindingNavigator.DeleteItem.PerformClick()
        Else
            MessageBox.Show("اختر سطر للمسح")
        End If
    End Sub


End Class