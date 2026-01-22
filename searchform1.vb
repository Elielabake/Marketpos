Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox

Public Class searchform1
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub searchform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        Dim cmd2 As New SqlCommand("SELECT pname FROM stock", con)
        Dim ds2 As New DataSet
        Dim da2 As New SqlDataAdapter(cmd2)
        da2.Fill(ds2, "list")
        Dim col2 As New AutoCompleteStringCollection
        Dim i2 As Integer
        For i2 = 0 To ds2.Tables(0).Rows.Count - 1
            col2.Add(ds2.Tables(0).Rows(i2)("pname").ToString())
        Next
        pn.AutoCompleteSource = AutoCompleteSource.CustomSource
        pn.AutoCompleteCustomSource = col2
        pn.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        con.Close()
    End Sub
    Public Sub fillfrombcj()

        con.Open()
        Dim query = "select * from stock where pname=N'" & pn.Text & "' "
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            bc.Text = reader(3).ToString

        End While
        con.Close()

    End Sub

    Private Sub pn_TextChanged(sender As Object, e As EventArgs) Handles pn.TextChanged
        If pn.Text = "" Then
            bc.Text = ""
        Else
            fillfrombcj()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        orderfrm1.bc.Text = bc.Text
        pn.Text = ""
        pn.Focus()
    End Sub
End Class