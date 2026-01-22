Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class reports

    '  Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Hide()
    End Sub
    Private Sub reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.ReportViewer1.RefreshReport()
        fromdate.Format = DateTimePickerFormat.Short
        fromdate.Value = DateTime.Today
        todate.Format = DateTimePickerFormat.Short
        todate.Value = DateTime.Today
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If rtype.Text = "" Then
            MsgBox("اختر تقرير")
        End If

        If rtype.Text = "الفواتير" Then
            Dim dt As New DataTable
            con.Open()
            Dim dtdate1 As DateTime = DateTime.Parse(fromdate.Text)
            Dim dtdate2 As DateTime = DateTime.Parse(todate.Text)
            Using cmd As New SqlCommand("select * from invoiceTbl where date between '" & fromdate.Value & "' and '" & todate.Value & "' order By date ASC", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\EL-POS POS MARKET\reports\Reportinv.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetinv", dt))
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
                ReportViewer1.ZoomMode = ZoomMode.Percent
                ReportViewer1.ZoomPercent = 100
            End With
            Me.ReportViewer1.RefreshReport()
            con.Close()
        ElseIf rtype.Text = "الموردين" Then
            Dim dt As New DataTable
            con.Open()
            Dim dtdate1 As DateTime = DateTime.Parse(fromdate.Text)
            Dim dtdate2 As DateTime = DateTime.Parse(todate.Text)
            Using cmd As New SqlCommand("select * from suppliersTbl where date between '" & fromdate.Value & "' and '" & todate.Value & "' order By date ASC", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\EL-POS POS MARKET\reports\Reportsupplier.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetsupp", dt))
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
                ReportViewer1.ZoomMode = ZoomMode.Percent
                ReportViewer1.ZoomPercent = 100
            End With
            Me.ReportViewer1.RefreshReport()
            con.Close()
        ElseIf rtype.Text = "المخزون" Then
            Dim dt As New DataTable
            con.Open()
            Dim dtdate1 As DateTime = DateTime.Parse(fromdate.Text)
            Dim dtdate2 As DateTime = DateTime.Parse(todate.Text)
            Using cmd As New SqlCommand("select * from stock ", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\EL-POS POS MARKET\reports\Reportstock.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetstock", dt))
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
                ReportViewer1.ZoomMode = ZoomMode.Percent
                ReportViewer1.ZoomPercent = 100
            End With
            Me.ReportViewer1.RefreshReport()
            con.Close()
        ElseIf rtype.Text = "فواتير الطلبات" Then
            Dim dt As New DataTable
            con.Open()
            Dim dtdate1 As DateTime = DateTime.Parse(fromdate.Text)
            Dim dtdate2 As DateTime = DateTime.Parse(todate.Text)
            Using cmd As New SqlCommand("select * from orderstbl where date between '" & fromdate.Value & "' and '" & todate.Value & "' order By date ASC", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\EL-POS POS MARKET\reports\Reportallorders.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetallorders", dt))
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
                ReportViewer1.ZoomMode = ZoomMode.Percent
                ReportViewer1.ZoomPercent = 100
            End With
            Me.ReportViewer1.RefreshReport()
            con.Close()
        ElseIf rtype.Text = "المصاريف" Then
            Dim dt As New DataTable
            con.Open()
            Dim dtdate1 As DateTime = DateTime.Parse(fromdate.Text)
            Dim dtdate2 As DateTime = DateTime.Parse(todate.Text)
            Using cmd As New SqlCommand("select * from expTbl where date between '" & fromdate.Value & "' and '" & todate.Value & "' order By date ASC", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\EL-POS POS MARKET\reports\Reportexp.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetexp", dt))
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
                ReportViewer1.ZoomMode = ZoomMode.Percent
                ReportViewer1.ZoomPercent = 100
            End With
            Me.ReportViewer1.RefreshReport()
            con.Close()

        ElseIf rtype.Text = "الطلبات" Then
            Dim dt As New DataTable
            con.Open()
            Dim dtdate1 As DateTime = DateTime.Parse(fromdate.Text)
            Dim dtdate2 As DateTime = DateTime.Parse(todate.Text)
            Using cmd As New SqlCommand("select * from ordertbl1 where date between '" & fromdate.Value & "' and '" & todate.Value & "' order By date ASC", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\EL-POS POS MARKET\reports\Reportorders.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetorders", dt))
                ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
                ReportViewer1.ZoomMode = ZoomMode.Percent
                ReportViewer1.ZoomPercent = 100
            End With
            Me.ReportViewer1.RefreshReport()
            con.Close()

        End If
    End Sub
End Class