Public Class clientsfrm
    Private Sub ClienttblBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ClienttblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)

    End Sub

    Private Sub clientsfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.clienttbl' table. You can move, or remove it, as needed.
        'TODO: This line of code loads data into the 'MarketDataSet.clienttbl' table. You can move, or remove it, as needed.
        Me.ClienttblTableAdapter.Fill(Me.MarketDataSet.clienttbl)


    End Sub

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Validate()
        Me.ClienttblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)

        MessageBox.Show("تم الحفظ")
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean


        ' Check if the F1 key is pressed
        If keyData = Keys.F1 Then
            ' Trigger the click event of the "Save" button
            Button3.PerformClick()
            Return True ' Indicate that the key press has been handled
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


End Class