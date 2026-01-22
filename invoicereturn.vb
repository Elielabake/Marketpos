Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Reflection
Imports DocumentFormat.OpenXml.Drawing.Charts
'Imports PdfSharp.BigGustave
Public Class invoicereturn
    Public con As New SqlConnection(My.Settings.MARKETDBConnectionString)

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Shapes2_Click(sender As Object, e As EventArgs) Handles Guna2Shapes2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Public Sub fillsuppdeb()
        con.Open()
        Dim query1 = "select * from suppdebitTbl where sname=N'" & sname.Text & "' and invnum=N'" & invnum.Text & "'"
        Dim cmd1 As New SqlCommand(query1, con)
        Dim dt1 As New DataTable
        Dim reader1 As SqlDataReader
        reader1 = cmd1.ExecuteReader()
        While reader1.Read
            cred.Text = reader1(4).ToString

        End While
        con.Close()
    End Sub
    Public Sub fillfromId()



        con.Open()
        Dim query = "select * from suppliersTbl where Id=" & Idtxt.Text & ""
        Dim cmd As New SqlCommand(query, con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            Idtxt.Text = reader(0).ToString
            sname.Text = reader(1).ToString
            cn.Text = reader(2).ToString
            invnum.Text = reader(3).ToString
            '  totd.Text = reader(5).ToString

            pd.Text = reader(7).ToString
        End While
        con.Close()
        fillsuppdeb()
        pd.Text = Val(pd.Text) + Val(cred.Text)
        rest.Text = Val(totd.Text) - Val(pd.Text)
    End Sub
    Public Sub fillfrominvnum()

        Dim invnum1 As String = invnum.Text
        Me.InvoiceTblTableAdapter.FillByinv(Me.MARKETDataSet.invoiceTbl, invnum1)
    End Sub

    Private Sub invoicereturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Idtxt_TextChanged(sender As Object, e As EventArgs) Handles Idtxt.TextChanged
        If Idtxt.Text = "" Then
            sname.Text = ""
            cn.Text = ""
            invnum.Text = ""
            pd.Text = ""
            totd.Text = ""
            cred.Text = ""
            rest.Text = ""
        Else
            fillfromId()

        End If
    End Sub

    Private Sub invnum_TextChanged(sender As Object, e As EventArgs) Handles invnum.TextChanged

        fillfrominvnum()
        totinv()

    End Sub

    Private Sub supplierdgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles supplierdgv.CellEndEdit
        Me.Validate()
        Me.InvoiceTblBindingSource.EndEdit()
        Me.TableAdapterManager1.UpdateAll(Me.MARKETDataSet)
        totinv()
    End Sub
    Public Sub totinv()
        Dim total As Decimal = 0

        For Each row As DataGridViewRow In supplierdgv.Rows
            If Not row.IsNewRow Then
                Dim qty As Decimal = 0
                Dim cd As Decimal = 0

                If row.Cells(7).Value IsNot Nothing Then
                    Decimal.TryParse(row.Cells(7).Value.ToString(), qty)
                End If

                If row.Cells(8).Value IsNot Nothing Then
                    Decimal.TryParse(row.Cells(8).Value.ToString(), cd)
                End If

                total += qty * cd
            End If
        Next

        totd.Text = total.ToString()

    End Sub

    Private Sub supplierdgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles supplierdgv.CellValueChanged
        totinv()
    End Sub

    Private Sub supplierdgv_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles supplierdgv.RowsRemoved
        totinv()
    End Sub

    Private Sub totd_TextChanged(sender As Object, e As EventArgs) Handles totd.TextChanged
        rest.Text = Val(totd.Text) - Val(pd.Text)
    End Sub

    Private Sub pd_TextChanged(sender As Object, e As EventArgs) Handles pd.TextChanged
        rest.Text = Val(totd.Text) - Val(pd.Text)
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim newRow As DataRow = invreturndone.MARKETDataSet.suppliersreturnTbl.NewRow()

        newRow("sname") = sname.Text
        newRow("cname") = cn.Text
        newRow("invnum") = invnum.Text

        newRow("totpd") = totd.Text

        newRow("pd") = pd.Text

        newRow("date") = DateTime.Now
        ' Add the new row to the DataTable
        invreturndone.MARKETDataSet.suppliersreturnTbl.Rows.Add(newRow)

        ' Refresh the DataGridView to reflect the changes
        invreturndone.dgv.Refresh()
        invreturndone.Validate()
        invreturndone.SuppliersreturnTblBindingSource.EndEdit()
        invreturndone.TableAdapterManager1.UpdateAll(invreturndone.MARKETDataSet)
        InsertAvailableRowsToInvoiceReturn()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        invreturndone.Show()
    End Sub
    Private Sub InsertAvailableRowsToInvoiceReturn()
        Try
            ' Open a single connection for all stock updates
            Using con As New SqlConnection(My.Settings.MARKETDBConnectionString)
                con.Open()

                ' Loop through each row in the DataGridView
                For Each row As DataGridViewRow In supplierdgv.Rows
                    If Not row.IsNewRow Then
                        ' Add row to invoicereturnTbl in dataset
                        Dim newRow As DataRow = invreturndone.MARKETDataSet.invoicereturnTbl.NewRow()

                        newRow("stockID") = If(row.Cells(14).Value IsNot Nothing, row.Cells(14).Value, DBNull.Value)
                        newRow("invnum") = If(row.Cells(13).Value IsNot Nothing, row.Cells(13).Value, DBNull.Value)
                        newRow("bcode") = If(row.Cells(12).Value IsNot Nothing, row.Cells(12).Value, DBNull.Value)
                        newRow("pname") = If(row.Cells(11).Value IsNot Nothing, row.Cells(11).Value, DBNull.Value)
                        newRow("categ") = If(row.Cells(10).Value IsNot Nothing, row.Cells(10).Value, DBNull.Value)
                        newRow("dr") = If(row.Cells(9).Value IsNot Nothing, row.Cells(9).Value, DBNull.Value)
                        newRow("qty") = If(row.Cells(8).Value IsNot Nothing, row.Cells(8).Value, 0)
                        newRow("cd") = If(row.Cells(7).Value IsNot Nothing, row.Cells(7).Value, 0)
                        newRow("cl") = If(row.Cells(6).Value IsNot Nothing, row.Cells(6).Value, DBNull.Value)
                        newRow("pd") = If(row.Cells(5).Value IsNot Nothing, row.Cells(5).Value, 0)
                        newRow("pl") = If(row.Cells(4).Value IsNot Nothing, row.Cells(4).Value, DBNull.Value)
                        newRow("date") = DateTime.Now
                        newRow("date1") = DateTime.Now
                        newRow("date2") = DateTime.Now.Date
                        newRow("qtym") = If(row.Cells(0).Value IsNot Nothing, row.Cells(0).Value, 0)

                        ' Add the row to the DataTable
                        invreturndone.MARKETDataSet.invoicereturnTbl.Rows.Add(newRow)

                        ' Update qavailable in stock table
                        Using cmd As New SqlCommand("UPDATE stock SET qavailable = qavailable - @qty WHERE Id = @stockID", con)
                            cmd.Parameters.AddWithValue("@qty", Convert.ToDecimal(row.Cells(8).Value))
                            cmd.Parameters.AddWithValue("@stockID", Convert.ToInt32(row.Cells(14).Value))
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next

                ' Update the database for invoicereturnTbl
                invreturndone.InvoicereturnTblTableAdapter.Update(invreturndone.MARKETDataSet.invoicereturnTbl)
                '    MessageBox.Show("Rows inserted and stock updated successfully!")
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub


    Private Sub ShowPrintPreview()
        ' Set custom paper size
        Dim customSize As New PaperSize("Custom", 1200, 800)
        pdd.DefaultPageSettings.PaperSize = customSize
        pdd.DefaultPageSettings.Margins = New Margins(20, 20, 20, 20)

        ' Assign document and show preview
        ppd.Document = pdd
        ppd.Width = 800
        ppd.Height = 600
        ppd.StartPosition = FormStartPosition.CenterScreen
        ppd.AutoScroll = True
        ppd.AutoSize = True
        ppd.ShowDialog()
    End Sub
    Private currentPage As Integer = 1
    Private rowIndex As Integer = 0
    Private rowsPerPage As Integer
    Private pageHeight As Integer
    Private pageWidth As Integer
    Private Shadows margin As Integer = 50
    Private headerHeight As Integer = 80
    Private titleHeight As Integer = 40
    Private rowHeight As Integer = 40 ' Default row height

    Private Sub PDd_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pdd.PrintPage
        ' Set up fonts and pens
        Dim fontHeader As New Font("Times New Roman", 14, FontStyle.Bold)
        Dim fontTitle As New Font("Times New Roman", 30, FontStyle.Bold)
        Dim fontBody As New Font("Times New Roman", 16)
        Dim fontBodySmall As New Font("Times New Roman", 14)
        Dim borderPen As New Pen(Color.Black, 2) ' Pen for drawing borders
        Dim linePen As New Pen(Color.Black, 1) ' Pen for cell lines

        ' Set up page dimensions and margins
        pageHeight = e.PageBounds.Height
        pageWidth = e.PageBounds.Width
        rowsPerPage = CInt((pageHeight - 2 * margin - headerHeight - titleHeight) / rowHeight)

        ' Draw header and title
        Dim leftHeaderRect As New Rectangle(margin, margin, 250, headerHeight)
        Dim rightHeaderRect As New Rectangle(pageWidth - 250, margin, 200, headerHeight)
        Dim titleRect As New Rectangle(leftHeaderRect.Right + 10, margin, pageWidth - leftHeaderRect.Width - rightHeaderRect.Width - 30, titleHeight)
        Dim mainTableRect As New Rectangle(margin, margin + headerHeight + 20, pageWidth - 2 * margin, 1) ' Initial height is 1

        ' Draw header rectangles
        e.Graphics.DrawRectangle(borderPen, leftHeaderRect)
        e.Graphics.DrawString(cn.Text & " :اسم الشركة", fontHeader, Brushes.Black, New RectangleF(leftHeaderRect.X, leftHeaderRect.Y + 10, leftHeaderRect.Width - 10, headerHeight), New StringFormat With {.Alignment = StringAlignment.Far})
        ' e.Graphics.DrawString("رقم الهاتف: " & pnn.Text, fontHeader, Brushes.Black, New RectangleF(leftHeaderRect.X, leftHeaderRect.Y + 32, leftHeaderRect.Width - 10, headerHeight), New StringFormat With {.Alignment = StringAlignment.Far})
        e.Graphics.DrawString("رقم الفاتورة: " & invnum.Text, fontHeader, Brushes.Black, New RectangleF(leftHeaderRect.X, leftHeaderRect.Y + 58, leftHeaderRect.Width - 10, headerHeight), New StringFormat With {.Alignment = StringAlignment.Far})
        e.Graphics.DrawRectangle(borderPen, rightHeaderRect)
        Dim rightAlign As New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Near}
        e.Graphics.DrawString("التاريخ: " & DateTime.Now.ToString("yyyy-MM-dd"), fontHeader, Brushes.Black, New RectangleF(rightHeaderRect.X, rightHeaderRect.Y + 10, rightHeaderRect.Width - 10, headerHeight), rightAlign)
        e.Graphics.DrawString("العملة: الدولار", fontHeader, Brushes.Black, New RectangleF(rightHeaderRect.X, rightHeaderRect.Y + 35, rightHeaderRect.Width - 10, headerHeight), rightAlign)

        ' Draw title
        e.Graphics.DrawString("GODY'S MARKET", fontTitle, Brushes.Black, New RectangleF(titleRect.X - 55, titleRect.Y + 15, titleRect.Width, titleHeight), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

        ' Draw table header
        Dim columns As String() = {"المجموع", "السعر", "الكمية", "المنتج"}
        Dim totalWidth As Integer = pageWidth - 2 * margin
        Dim colWidths As Integer() = {
        CInt(totalWidth * 0.2), ' 20% for column 1
        CInt(totalWidth * 0.2), ' 20% for column 2
        CInt(totalWidth * 0.2), ' 20% for column 3
        CInt(totalWidth * 0.4)  ' 40% for column 4
    }

        Dim startX As Integer = mainTableRect.X
        Dim startY As Integer = mainTableRect.Y
        Dim currentX As Integer = startX
        ' Draw table header
        For i As Integer = 0 To columns.Length - 1
            Dim headerRect As New Rectangle(currentX, startY, colWidths(i), rowHeight)
            e.Graphics.FillRectangle(Brushes.LightGray, headerRect)
            e.Graphics.DrawRectangle(borderPen, headerRect) ' Draw border for header cell
            e.Graphics.DrawString(columns(i), fontHeader, Brushes.Black, headerRect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            currentX += colWidths(i)
        Next
        e.Graphics.DrawLine(linePen, startX, startY + rowHeight, startX + colWidths.Sum(), startY + rowHeight) ' Draw line under header

        ' Draw rows
        Dim rowY As Integer = startY + rowHeight
        Dim rowsDrawn As Integer = 0
        Dim rowsPerPageCurrent As Integer = 0

        ' Keep track of the starting Y position for the next page
        Dim startingYForNextPage As Integer = rowY

        For i As Integer = rowIndex To supplierdgv.Rows.Count - 1
            Dim row As DataGridViewRow = supplierdgv.Rows(i)
            If Not row.IsNewRow Then
                Dim cellX As Integer = startX

                ' Calculate the required row height based on the content of the cell in column 4
                Dim cellText As String = row.Cells(12).Value.ToString()
                Dim textSize As SizeF = e.Graphics.MeasureString(cellText, fontBodySmall, colWidths(3))
                Dim dynamicRowHeight As Integer = CInt(Math.Max(rowHeight, textSize.Height + 10)) ' Add padding

                ' Draw the row with dynamic height
                For j As Integer = 0 To columns.Length - 1
                    Dim cellRect As New Rectangle(cellX, rowY, colWidths(j), dynamicRowHeight)
                    e.Graphics.DrawRectangle(borderPen, cellRect) ' Draw border for each cell
                    Dim cellContent As String

                    If j = 0 Then
                        ' Column 0: use cell 7 * cell 8
                        Dim qty As Decimal = If(row.Cells(7).Value IsNot Nothing, Convert.ToDecimal(row.Cells(7).Value), 0D)
                        Dim price As Decimal = If(row.Cells(8).Value IsNot Nothing, Convert.ToDecimal(row.Cells(8).Value), 0D)
                        cellContent = Format(qty * price, "F2")
                    ElseIf j = 1 Then
                        cellContent = Format(If(row.Cells(7).Value IsNot Nothing, Convert.ToDecimal(row.Cells(7).Value), 0D), "F2")
                    ElseIf j = 2 Then
                        cellContent = Format(If(row.Cells(8).Value IsNot Nothing, Convert.ToDecimal(row.Cells(8).Value), 0D), "F2")
                    Else
                        cellContent = row.Cells(11).Value.ToString()
                    End If
                    e.Graphics.DrawString(cellContent, fontBodySmall, Brushes.Black, cellRect, New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    cellX += colWidths(j)
                Next

                e.Graphics.DrawLine(linePen, startX, rowY + dynamicRowHeight, startX + colWidths.Sum(), rowY + dynamicRowHeight) ' Draw line under each row
                rowY += dynamicRowHeight
                rowsDrawn += 1
                rowsPerPageCurrent += 1

                ' Check if the page height is exceeded
                If rowY + dynamicRowHeight + 60 > pageHeight - margin Then ' Adding extra 60 for margin and footer height
                    rowIndex = i + 1
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        Next

        ' Draw totals and other rectangles at the bottom of the last page
        Dim totalSum As Decimal = 0D

        For Each row As DataGridViewRow In supplierdgv.Rows
            If Not row.IsNewRow Then
                Dim qty As Decimal = 0D
                Dim price As Decimal = 0D

                If row.Cells(7).Value IsNot Nothing Then
                    Decimal.TryParse(row.Cells(7).Value.ToString(), qty)
                End If
                If row.Cells(8).Value IsNot Nothing Then
                    Decimal.TryParse(row.Cells(8).Value.ToString(), price)
                End If

                totalSum += qty * price
            End If
        Next

        totd.Text = totalSum.ToString("F2")


        Dim totalSumText As String = totalSum.ToString("F2")
        Dim netTotalText As String = totalSum.ToString("F2")

        Dim bottomY As Integer = rowY + 20 ' Adjust bottom offset
        Dim valueRect As New Rectangle(margin, bottomY, 250, 30)
        Dim netTotalRect As New Rectangle(margin, bottomY + 80, 250, 30)

        ' Check if the totals fit in the current page
        If bottomY + 120 > pageHeight - margin Then
            e.HasMorePages = True
            rowIndex = supplierdgv.Rows.Count ' go to end
            Exit Sub
        End If

        ' --- Draw total rectangle ---
        e.Graphics.DrawRectangle(borderPen, valueRect)
        e.Graphics.DrawString(":المجموع", fontBodySmall, Brushes.Black, valueRect,
            New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
        e.Graphics.DrawString(totalSumText & "$", fontBodySmall, Brushes.Black, valueRect,
            New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})


        ' Reset page number for next page
        currentPage += 1

        ' Handle multi-page printing
        If rowIndex >= supplierdgv.Rows.Count Then
            e.HasMorePages = False
            rowIndex = 0
            currentPage = 1
        End If

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            ' Create a new PrintDialog
            Using printDlg As New PrintDialog()
                printDlg.Document = pdd ' Assign your PrintDocument

                ' Show the dialog
                If printDlg.ShowDialog() = DialogResult.OK Then
                    ' User clicked OK, print using the selected printer
                    pdd.PrinterSettings = printDlg.PrinterSettings
                    pdd.Print()
                Else
                    ' User cancelled the print
                    MessageBox.Show("Printing cancelled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error during printing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class