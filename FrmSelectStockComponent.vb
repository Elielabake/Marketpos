Imports System.Data.SqlClient
Public Class FrmSelectStockComponent

    Public SelectedStockId As Integer
    Public QtyUsed As Decimal

    Private con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub FrmSelectStockComponent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStock()
        txtQty.Text = "1"
    End Sub

    Private Sub LoadStock()
        Dim dt As New DataTable
        Using cmd As New SqlCommand("SELECT * FROM stock", con)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        End Using

        dgvStock.DataSource = dt
        dgvStock.Columns("Id").Visible = False
        dgvStock.Columns("pname").HeaderText = "اسم المنتج"
        dgvStock.Columns("pcostd").Visible = False
        dgvStock.Columns("pcostl").Visible = False
        dgvStock.Columns("ppriced").Visible = False
        dgvStock.Columns("ppricel").Visible = False
        dgvStock.Columns("ppricedj").Visible = False
        dgvStock.Columns("ppricelj").Visible = False
        dgvStock.Columns("cat").Visible = False
        dgvStock.Columns("code").Visible = False
        dgvStock.Columns("dp").Visible = False
        dgvStock.Columns("codej").Visible = False
        dgvStock.Columns("qtyj").Visible = False
        dgvStock.Columns("qavailable").Visible = False
        dgvStock.Columns("qsold").Visible = False
        dgvStock.Columns("dtl").Visible = False
        dgvStock.Columns("qtym").Visible = False
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If dgvStock.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a component first")
            Exit Sub
        End If

        If Not Decimal.TryParse(txtQty.Text, QtyUsed) Then
            MessageBox.Show("Enter a valid quantity")
            Exit Sub
        End If

        SelectedStockId = CInt(dgvStock.SelectedRows(0).Cells("Id").Value)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) 
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


End Class
