Imports System.Data.SqlClient
Public Class DATEFINISHEDFRM
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        Me.Close()
    End Sub
    Private Sub CustomerDate1_ValueChanged(sender As Object, e As EventArgs) Handles maindate.ValueChanged
        maindate.Value = Date.Now.AddDays(0)
    End Sub



    Private Sub DATEFINISHEDFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet1.invoicedateTbl' table. You can move, or remove it, as needed.
        ' Me.InvoicedateTblTableAdapter.Fill(Me.MARKETDataSet1.invoicedateTbl)
        Me.InvoicedateTblTableAdapter.Fill(Me.MARKETDataSet1.invoicedateTbl)
    End Sub

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Me.Validate()
        Me.InvoicedateTblBindingSource.EndEdit()
        Me.TableAdapterManager1.UpdateAll(Me.MARKETDataSet1)

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.InvoicedateTblTableAdapter.FillByPROCHDATE(Me.MARKETDataSet1.invoicedateTbl)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.InvoicedateTblTableAdapter.FillByFINISHDATE(Me.MARKETDataSet1.invoicedateTbl)
    End Sub

    Private Sub Guna2Button13_Click(sender As Object, e As EventArgs) Handles Guna2Button13.Click
        Me.InvoicedateTblTableAdapter.FillByDONE(Me.MARKETDataSet1.invoicedateTbl)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Me.InvoicedateTblTableAdapter.Fill(Me.MARKETDataSet1.invoicedateTbl)
    End Sub
End Class