
Imports System.Data.SqlClient

Public Class categfrm
    'Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub barcodesfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'MARKETDataSet.categTbl' table. You can move, or remove it, as needed.
        Me.CategTblTableAdapter.Fill(Me.MARKETDataSet.categTbl)
        'TODO: This line of code loads data into the 'MARKETDataSet.dollarrateTbl' table. You can move, or remove it, as needed.
        Me.DollarrateTblTableAdapter.Fill(Me.MARKETDataSet.dollarrateTbl)

        AcceptButton = Button2
        drdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dol()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Validate()
        Me.CategTblBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)
        stock.fillcateg()
        invoice.fillcateg()

    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim newRow As DataRow = MARKETDataSet.categTbl.NewRow()

        newRow("categ") = categtxt.Text


        ' Add the new row to the DataTable
        Me.MarketDataSet.categTbl.Rows.Add(newRow)

        ' Refresh the DataGridView to reflect the changes
        categdgv.Refresh()
        categtxt.Text = ""
    End Sub


    Public Sub dol()

        Dim cmd02 As New SqlCommand
        cmd02.Connection = con
        con.Open()
        cmd02.CommandText = "select SUM(dr) From dollarrateTbl"
        If IsDBNull(cmd02.ExecuteScalar) Then
            Guna2Button1.Text = "اضافة"
        Else
            Guna2Button1.Text = "تعديل"

        End If
        con.Close()
        cmd02.Dispose()

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            Dim cmd02 As New SqlCommand
            cmd02.Connection = con
            con.Open()
            cmd02.CommandText = "select SUM(dr) From dollarrateTbl where Id='1'"
            If IsDBNull(cmd02.ExecuteScalar) Then
                Dim newRow As DataRow = MARKETDataSet.dollarrateTbl.NewRow()

                newRow("dr") = drtxt.Text


                ' Add the new row to the DataTable
                Me.MarketDataSet.dollarrateTbl.Rows.Add(newRow)

                ' Refresh the DataGridView to reflect the changes
                drdgv.Refresh()
                Me.Validate()
                Me.DollarrateTblBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)
            Else

                Dim query As String
                query = "update dollarrateTbl set dr=" & drtxt.Text & "  where Id='1'"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("تم تغيير سعر الدولار")

            End If
            con.Close()
            cmd02.Dispose()

            dol()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        barcodesfrm_Load(e, e)
        stock.filldr()
        invoice.filldr()
        orderfrm3.filldr()
        orderfrm1.filldr()
        Expenses.filldr()
        debitsfrm.filldr()
        suppliersdebit.filldr()
        cashier.filldr()
    End Sub

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.Controls.Clear()
        InitializeComponent()
        barcodesfrm_Load(e, e)
    End Sub


End Class