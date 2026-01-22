Imports System.Data.SqlClient
Imports Guna.UI2.WinForms
Imports System.Web.UI.WebControls
Imports System.Threading.Tasks
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Drawing.Drawing2D

Public Class Start

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Increment progress bar only if under 100
        If Guna2ProgressBar1.Value < 100 Then
            Guna2ProgressBar1.Increment(1)
        End If

        ' Check connection string at 20%
        If Guna2ProgressBar1.Value = 20 Then
            If String.IsNullOrWhiteSpace(My.Settings.MARKETDBConnectionString) Then
                Timer1.Stop() ' Stop progress
                MessageBox.Show("Database connection not set! Please configure it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                frmCheckDB.ShowDialog() ' Show DB settings form
                Exit Sub
            End If
        End If

        ' When progress reaches 100%, show login
        If Guna2ProgressBar1.Value = 100 Then
            Me.Hide()
            Loginpage.Show()
            Timer1.Stop()
        End If
    End Sub

    Private Sub Start_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Interval = 10 ' Adjust speed
        Timer1.Start()
        ' Begin caching in background

    End Sub

End Class
