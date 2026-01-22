Imports System.Data.SqlClient

Public Class equipments
    'Public con As New SqlConnection("Data Source=ELPOS\SQLEXPRESS;Initial Catalog=SALIMDB;Integrated Security=True")

    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub equipments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MARKETDataSet.equipmentTbl1' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'MarketDataSet.equipmentTbl1' table. You can move, or remove it, as needed.
        Me.EquipmentTbl1TableAdapter.Fill(Me.MarketDataSet.equipmentTbl1)
        totequip()
        AcceptButton = Button1
        If equipmentDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            equipmentDGV.FirstDisplayedScrollingRowIndex = equipmentDGV.Rows.Count - 1
            ' Optionally select the last row
            equipmentDGV.Rows(equipmentDGV.Rows.Count - 1).Selected = True
        End If
    End Sub

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub
    Private Sub CustomerDate_ValueChanged(sender As Object, e As EventArgs) Handles maindate.ValueChanged
        maindate.Value = Date.Now.AddDays(0)
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Validate()
        Me.EquipmentTbl1BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MarketDataSet)
        equip.Text = ""
        ad.Text = ""
        MessageBox.Show("تم الحفظ")
        totequip()
        dailyprofits.fillequip()
        If equipmentDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            equipmentDGV.FirstDisplayedScrollingRowIndex = equipmentDGV.Rows.Count - 1
            ' Optionally select the last row
            equipmentDGV.Rows(equipmentDGV.Rows.Count - 1).Selected = True
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Delete Then
            ' Trigger the click event of the "Save" button
            Button2.PerformClick()
            Return True ' Indicate that the key press has been handled
        End If


        ' Check if the F1 key is pressed
        If keyData = Keys.F1 Then
            ' Trigger the click event of the "Save" button
            Button3.PerformClick()
            Return True ' Indicate that the key press has been handled
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newRow1 As DataRow = Me.MarketDataSet.equipmentTbl1.NewRow()

        newRow1("equip") = equip.Text
        newRow1("amountd") = ad.Text
        newRow1("date") = FormatDateTime(maindate.Value)
        ' Add the new row to the DataTable
        Me.MarketDataSet.equipmentTbl1.Rows.Add(newRow1)

        ' Refresh the DataGridView to reflect the changes
        equipmentDGV.Refresh()
        equip.Text = ""
        ad.Text = ""
        If equipmentDGV.Rows.Count > 0 Then
            ' Scroll to the last row
            equipmentDGV.FirstDisplayedScrollingRowIndex = equipmentDGV.Rows.Count - 1
            ' Optionally select the last row
            equipmentDGV.Rows(equipmentDGV.Rows.Count - 1).Selected = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If equipmentDGV.SelectedRows.Count > 0 Then
            EquipmentTbl1BindingNavigator.DeleteItem.PerformClick()
        Else
            MessageBox.Show("اختر سطر للمسح")
        End If
        equip.Text = ""
        ad.Text = ""

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim sheetIndex As Integer
            Dim Ex As Object
            Dim Wb As Object
            Dim Ws As Object
            Ex = CreateObject("Excel.Application")
            Wb = Ex.workbooks.add
            Dim col, row As Integer
            Dim rawData(equipmentDGV.Rows.Count, equipmentDGV.Columns.Count - 1) As Object
            For col = 0 To equipmentDGV.Columns.Count - 1
                rawData(0, col) = equipmentDGV.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To equipmentDGV.Columns.Count - 1
                For row = 0 To equipmentDGV.Rows.Count - 1
                    rawData(row + 1, col) = equipmentDGV.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(equipmentDGV.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, equipmentDGV.Rows.Count + 1)
            Ws.Range(excelRange, Type.Missing).Value2 = rawData
            Ws = Nothing
            Wb.SaveAs(SaveFileDialog1.FileName, Type.Missing, Type.Missing,
         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
         Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
            Wb.Close(True, Type.Missing, Type.Missing)
            Wb = Nothing
            ' Release the Application object
            Ex.Quit()
            Ex = Nothing
            ' Collect the unreferenced objects
            GC.Collect()
            MsgBox("تم النقل", MsgBoxStyle.Information)
        End If
    End Sub
    Public Function ExcelColName(ByVal Col As Integer) As String
        If Col < 0 And Col > 256 Then
            MsgBox("Invalid Argument", MsgBoxStyle.Critical)
            Return Nothing
            Exit Function
        End If
        Dim i As Int16
        Dim r As Int16
        Dim S As String
        If Col <= 26 Then
            S = Chr(Col + 64)
        Else
            r = Col Mod 26
            i = System.Math.Floor(Col / 26)
            If r = 0 Then
                r = 26
                i = i - 1
            End If
            S = Chr(i + 64) & Chr(r + 64)
        End If
        ExcelColName = S
    End Function
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.Controls.Clear()
        InitializeComponent()
        equipments_Load(e, e)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        equip.Text = ""
        ad.Text = ""

    End Sub
    Public Sub totequip()
        Dim num As Decimal
        Dim cmd As New SqlCommand
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select SUM(amountd) from equipmentTbl1"
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 0
            tqa.Text = num
        Else
            num = cmd.ExecuteScalar
            tqa.Text = num
        End If
        cmd.Dispose()
        con.Close()
    End Sub


End Class