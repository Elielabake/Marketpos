Public Class invreturndone
    Private Sub invreturndone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.invoicereturnTbl' table. You can move, or remove it, as needed.
        Me.InvoicereturnTblTableAdapter.Fill(Me.MARKETDataSet.invoicereturnTbl)
        'TODO: This line of code loads data into the 'MARKETDataSet.suppliersreturnTbl' table. You can move, or remove it, as needed.
        Me.SuppliersreturnTblTableAdapter.Fill(Me.MARKETDataSet.suppliersreturnTbl)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class