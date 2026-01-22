Imports System.Data.SqlClient
Imports Guna.UI2.WinForms
Imports System.IO

Public Class orderfrm2

    ' Database connection
    Private con As SqlConnection = Nothing

    ' Track hovered close button
    Private hoveredTabIndex As Integer = -1

    ' Track used order numbers (prevents duplicates)
    Private usedOrderNumbers As New List(Of Integer)

    ' File to save open tabs
    Private ReadOnly openTabsFile As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SALIMApp", "open_tabs.txt")

    ' -----------------------------
    ' Form Load
    ' -----------------------------
    Private Sub orderfrm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Build connection string

        con = New SqlConnection(My.Settings.MARKETDBConnectionString)

        ' Setup tab control
        Guna2TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
        Guna2TabControl1.Dock = DockStyle.Fill

        ' Restore saved tabs
        Dim restored As List(Of Integer) = LoadOpenTabsFromFile()
        Dim firstTab As TabPage = Nothing

        If restored.Count > 0 Then
            ' Add tabs without loading their forms
            For i As Integer = 0 To restored.Count - 1
                Dim ordnum As Integer = restored(i)
                Dim loadNow As Boolean = (i = 0) ' Only load the first tab fully
                AddOrderTab(ordnum, loadNow)
                If loadNow Then firstTab = Guna2TabControl1.TabPages(0)
            Next
        Else
            ' No saved tabs → add first tab
            AddOrderTab(0, True)
            firstTab = Guna2TabControl1.TabPages(0)
        End If

        ' Add "+" tab at the end
        AddPlusTab()
        RenumberTabs()

        ' Select first tab
        If firstTab IsNot Nothing Then
            Guna2TabControl1.SelectedTab = firstTab
        End If
    End Sub


    ' -----------------------------
    ' Get next available order number
    ' -----------------------------
    Private Function GetNextOrderNum() As Integer
        Dim nextNum As Integer = 1

        Try
            ' 1️⃣ Always start from the database maximum
            Using cmd As New SqlCommand("SELECT ISNULL(MAX(ordnum), 0) FROM ordertbl1", con)
                If con.State = ConnectionState.Closed Then con.Open()
                nextNum = Convert.ToInt32(cmd.ExecuteScalar()) + 1
                con.Close()
            End Using

            ' 2️⃣ Check all open tabs for any currently used ordnum (label33)
            Dim usedNumbers As New List(Of Integer)
            For Each tab As TabPage In Guna2TabControl1.TabPages
                Dim frm = tab.Controls.OfType(Of orderfrm3).FirstOrDefault()
                If frm IsNot Nothing Then
                    Dim currentNum As Integer
                    If Integer.TryParse(frm.label33.Text, currentNum) Then
                        usedNumbers.Add(currentNum)
                    End If
                End If
            Next

            ' 3️⃣ If number already used in open tabs, skip ahead until unique
            While usedNumbers.Contains(nextNum)
                nextNum += 1
            End While

        Catch ex As Exception
            MessageBox.Show("Error while determining next order number: " & ex.Message)
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        Return nextNum
    End Function


    ' -----------------------------
    ' Add an order tab
    ' -----------------------------
    Private Sub AddOrderTab(Optional orderNum As Integer = 0, Optional loadImmediately As Boolean = True)
        If orderNum = 0 Then
            orderNum = GetNextOrderNum() ' brand new tab
        Else
            ' existing tab → keep its number
            If Not usedOrderNumbers.Contains(orderNum) Then usedOrderNumbers.Add(orderNum)
        End If

        If Not usedOrderNumbers.Contains(orderNum) Then usedOrderNumbers.Add(orderNum)

        ' Create new tab before "+" or at the end
        Dim newTab As New TabPage()
        newTab.Tag = orderNum  ' Store actual ordnum

        Dim plusTab As TabPage = Guna2TabControl1.TabPages.Cast(Of TabPage).FirstOrDefault(Function(t) t.Text = "+")
        Dim tabIndex As Integer

        If plusTab IsNot Nothing Then
            tabIndex = Guna2TabControl1.TabPages.IndexOf(plusTab)
            Guna2TabControl1.TabPages.Insert(tabIndex, newTab)
        Else
            tabIndex = Guna2TabControl1.TabPages.Count
            Guna2TabControl1.TabPages.Add(newTab)
        End If

        ' Assign temporary display name
        newTab.Text = "Order " & (tabIndex + 1).ToString()

        ' Lazy load form if requested
        If loadImmediately Then
            LoadOrderFormIntoTab(newTab)
            Guna2TabControl1.SelectedTab = newTab
        End If

        ' Ensure "+" tab exists at the end
        AddPlusTab()
        RenumberTabs()
        SaveOpenTabsToFile()
    End Sub

    ' -----------------------------
    ' Load orderfrm3 into a tab
    ' -----------------------------
    Private Sub LoadOrderFormIntoTab(targetTab As TabPage)
        targetTab.Controls.Clear()

        ' ✅ Use the ordnum from the tab Tag if it exists (saved one)
        Dim ordnum As Integer
        If targetTab.Tag IsNot Nothing AndAlso Integer.TryParse(targetTab.Tag.ToString(), ordnum) Then
            ' Use the saved ordnum from file
        Else
            ' Only assign new number if this is a brand-new tab
            ordnum = GetNextOrderNum()
            targetTab.Tag = ordnum
        End If

        ' Create form and load it into the tab
        Dim newOrderFrm3 As New orderfrm3 With {
        .TopLevel = False,
        .FormBorderStyle = FormBorderStyle.None,
        .Dock = DockStyle.Fill,
        .Visible = True
    }

        targetTab.Controls.Add(newOrderFrm3)
        newOrderFrm3.Show()

        ' Apply the order number
        newOrderFrm3.label33.Text = ordnum.ToString()
        ordcheck.label33.Text = ordnum.ToString()
        ordcheck.orgord.Text = ordcheck.label33.Text
        ' Fill dataset safely
        Try
            newOrderFrm3.OrdernewTableAdapter.FillByord(newOrderFrm3.MARKETDataSet.ordernew, ordnum)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading data: " & ex.Message)
        End Try

        newOrderFrm3.tot1()
    End Sub




    ' -----------------------------
    ' Handle tab switching
    ' -----------------------------
    Private Sub Guna2TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2TabControl1.SelectedIndexChanged
        Dim selectedTab As TabPage = Guna2TabControl1.SelectedTab
        If selectedTab Is Nothing Then Return

        ' "+" tab click
        If selectedTab.Text = "+" Then
            AddOrderTab()

            Return
        End If

        ' Lazy load
        If selectedTab.Controls.Count = 0 AndAlso selectedTab.Tag IsNot Nothing Then
            LoadOrderFormIntoTab(selectedTab)

        End If

        AddPlusTab()
        RenumberTabs()
    End Sub

    ' -----------------------------
    ' Draw tab close button
    ' -----------------------------
    Private Sub Guna2TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles Guna2TabControl1.DrawItem
        Dim tabPage = Guna2TabControl1.TabPages(e.Index)
        Dim tabRect = Guna2TabControl1.GetTabRect(e.Index)
        TextRenderer.DrawText(e.Graphics, tabPage.Text, Guna2TabControl1.Font, tabRect, Color.Black)

        If tabPage.Text <> "+" AndAlso e.Index <> 0 Then
            Dim closeRect As New Rectangle(tabRect.Right - 24, tabRect.Top + 2, 20, 20)
            Dim brush As Brush = If(e.Index = hoveredTabIndex, Brushes.Red, Brushes.DarkRed)
            e.Graphics.DrawString("x", New Font("Arial", 10, FontStyle.Bold), brush, closeRect)
        End If
    End Sub

    Private Sub Guna2TabControl1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2TabControl1.MouseMove
        hoveredTabIndex = -1
        For i As Integer = 0 To Guna2TabControl1.TabPages.Count - 1
            Dim tabRect = Guna2TabControl1.GetTabRect(i)
            Dim closeRect As New Rectangle(tabRect.Right - 24, tabRect.Top + 2, 20, 20)
            If closeRect.Contains(e.Location) AndAlso Guna2TabControl1.TabPages(i).Text <> "+" AndAlso i <> 0 Then
                hoveredTabIndex = i
                Exit For
            End If
        Next
        Guna2TabControl1.Invalidate()
    End Sub

    Private Sub Guna2TabControl1_MouseLeave(sender As Object, e As EventArgs) Handles Guna2TabControl1.MouseLeave
        hoveredTabIndex = -1
        Guna2TabControl1.Invalidate()
    End Sub

    ' -----------------------------
    ' Close tab on "x" click
    ' -----------------------------
    Private Sub Guna2TabControl1_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2TabControl1.MouseDown
        For i As Integer = 0 To Guna2TabControl1.TabPages.Count - 1
            Dim tabRect = Guna2TabControl1.GetTabRect(i)
            Dim closeRect As New Rectangle(tabRect.Right - 24, tabRect.Top + 2, 20, 20)

            ' Skip the "+" tab
            If closeRect.Contains(e.Location) AndAlso Guna2TabControl1.TabPages(i).Text <> "+" Then

                ' Prevent deleting the last tab
                Dim nonPlusTabs = Guna2TabControl1.TabPages.Cast(Of TabPage)().Where(Function(t) t.Text <> "+").ToList()
                If nonPlusTabs.Count <= 1 Then
                    MessageBox.Show("لا يمكنك حذف آخر طلب.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit For
                End If

                Dim tabPage = Guna2TabControl1.TabPages(i)
                Dim ordnum As Integer = If(tabPage.Tag IsNot Nothing, CInt(tabPage.Tag), 0)

                ' Check if tab has saved rows
                Dim hasRows As Boolean = False
                Try
                    Using cmd As New SqlCommand("SELECT COUNT(*) FROM ordernew WHERE ordnum=@ordnum", con)
                        cmd.Parameters.AddWithValue("@ordnum", ordnum)
                        If con.State = ConnectionState.Closed Then con.Open()
                        hasRows = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                        con.Close()
                    End Using
                Catch ex As Exception
                    If con.State = ConnectionState.Open Then con.Close()
                End Try

                If hasRows Then
                    MessageBox.Show("لا يمكنك غلق هذا الطلب لأنه يحتوي على عناصر محفوظة في الفاتورة.", "إغلاق غير مسموح", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit For
                End If

                ' Ask confirmation
                Dim result As DialogResult = MessageBox.Show("هل انت متأكد من غلق الطلب؟", "تأكيد الغلق", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    usedOrderNumbers.Remove(ordnum)
                    Guna2TabControl1.TabPages.RemoveAt(i)

                    ' Renumber tabs automatically after removal
                    RenumberTabs()
                    SaveOpenTabsToFile()
                End If
                Exit For
            End If
        Next
    End Sub


    ' -----------------------------
    ' Save / Load open tabs
    ' -----------------------------
    Public Sub SaveOpenTabsToFile()
        Try
            Dim dir = Path.GetDirectoryName(openTabsFile)
            If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)

            Dim openOrders As New List(Of String)
            For Each tp As TabPage In Guna2TabControl1.TabPages
                If tp.Text <> "+" AndAlso tp.Tag IsNot Nothing Then
                    openOrders.Add(tp.Tag.ToString())
                End If
            Next
            File.WriteAllText(openTabsFile, String.Join(",", openOrders))
        Catch ex As Exception
        End Try
    End Sub

    Private Function LoadOpenTabsFromFile() As List(Of Integer)
        Dim result As New List(Of Integer)
        Try
            If Not File.Exists(openTabsFile) Then Return result
            Dim content = File.ReadAllText(openTabsFile).Trim()
            If String.IsNullOrEmpty(content) Then Return result
            For Each p In content.Split(","c)
                Dim v As Integer
                If Integer.TryParse(p.Trim(), v) Then result.Add(v)
            Next
        Catch ex As Exception
        End Try
        Return result
    End Function

    ' -----------------------------
    ' Form Closing
    ' -----------------------------
    Private Sub orderfrm2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveOpenTabsToFile()
    End Sub

    ' -----------------------------
    ' Add "+" tab helper
    ' -----------------------------
    Private Sub AddPlusTab()
        ' Remove existing + tabs
        For i As Integer = Guna2TabControl1.TabPages.Count - 1 To 0 Step -1
            If Guna2TabControl1.TabPages(i).Text = "+" Then
                Guna2TabControl1.TabPages.RemoveAt(i)
            End If
        Next

        ' Add + tab at the end
        Guna2TabControl1.TabPages.Add(New TabPage("+"))
    End Sub

    ' -----------------------------
    ' Renumber tabs display
    ' -----------------------------
    Private Sub RenumberTabs()
        Dim displayIndex As Integer = 1
        For Each tp As TabPage In Guna2TabControl1.TabPages
            If tp.Text <> "+" Then
                tp.Text = "الحساب " & displayIndex & "       X"
                displayIndex += 1
            End If
        Next
    End Sub
    ' ✅ Updates a specific tab's ordnum in open_tabs.txt


    ' -----------------------------
    ' Minimize / Back
    ' -----------------------------
    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Hide()
    End Sub

End Class
