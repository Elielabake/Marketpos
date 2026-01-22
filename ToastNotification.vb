Imports Guna.UI2.WinForms
Imports System.Drawing
Imports System.Windows.Forms

Public Class ToastNotification
    Inherits Form

    Private messageLabel As New Label()
    Private closeTimer As New Timer()
    Private slideTimer As New Timer()
    Private targetY As Integer
    Private closeButton As New Button()

    Public Sub New(title As String, message As String)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White
        Me.StartPosition = FormStartPosition.Manual
        Me.Width = 300
        Me.Height = 80
        Me.TopMost = True

        ' Rounded edges
        Dim border As New Guna2Elipse()
        border.TargetControl = Me
        border.BorderRadius = 10

        ' Message label
        messageLabel.Text = title & vbCrLf & message
        messageLabel.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        messageLabel.ForeColor = Color.Black
        messageLabel.Dock = DockStyle.Fill
        messageLabel.Padding = New Padding(10, 10, 30, 10) ' leave space for X
        Me.Controls.Add(messageLabel)

        ' Close button (X)
        closeButton.Text = "✕"
        closeButton.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        closeButton.ForeColor = Color.Black
        closeButton.BackColor = Color.Transparent
        closeButton.FlatStyle = FlatStyle.Flat
        closeButton.FlatAppearance.BorderSize = 0
        closeButton.Size = New Size(25, 25)
        closeButton.Location = New Point(Me.Width - closeButton.Width - 5, 5)
        closeButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddHandler closeButton.Click, Sub() Me.Close()

        Me.Controls.Add(closeButton)
        closeButton.BringToFront()

        ' Timers
        AddHandler closeTimer.Tick, AddressOf CloseTimer_Tick
        closeTimer.Interval = 4000 ' Auto close after 4 sec

        AddHandler slideTimer.Tick, AddressOf SlideTimer_Tick
        slideTimer.Interval = 10
    End Sub

    Private Sub ToastNotification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim workArea As Rectangle = Screen.PrimaryScreen.WorkingArea
        Me.Left = workArea.Right - Me.Width - 10
        Me.Top = workArea.Bottom
        targetY = workArea.Bottom - Me.Height - 10
        slideTimer.Start()
    End Sub

    Private Sub SlideTimer_Tick(sender As Object, e As EventArgs)
        If Me.Top > targetY Then
            Me.Top -= 5
        Else
            slideTimer.Stop()
            closeTimer.Start()
        End If
    End Sub

    Private Sub CloseTimer_Tick(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class
