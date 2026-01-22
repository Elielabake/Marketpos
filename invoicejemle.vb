Imports System.Data.SqlClient

Public Class invoicejemle
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)


    Private Sub invoicejemle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private shouldstop As Boolean = False

    Private Sub pd_TextChanged(sender As Object, e As EventArgs) Handles pd.TextChanged
        If pd.Focused Then
            shouldstop = False
            pl.Text = Math.Round(Val(pd.Text) * Val(invoice.dr.Text), 0).ToString()
        Else
            shouldstop = True
        End If

    End Sub

    Private Sub pl_TextChanged(sender As Object, e As EventArgs) Handles pl.TextChanged
        If pl.Focused Then
            shouldstop = False
            pd.Text = Val(pl.Text) / Val(invoice.dr.Text)
            If pl.Text = "" Then
                pd.Text = "0"
            End If
        Else
            shouldstop = True
        End If

    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        invoice.bcj.Text = bc.Text
        invoice.pdj.Text = pd.Text
        invoice.plj.Text = pl.Text
        invoice.qtyj1.Text = qtyj.Text
    End Sub
End Class