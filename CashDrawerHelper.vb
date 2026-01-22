Imports System.Drawing.Printing
Imports System.Text

Public Class CashDrawerHelper
    Public Shared Sub OpenCashDrawer()
        Dim printDoc As New PrintDocument()

        ' Set up the event handler for the print document
        AddHandler printDoc.PrintPage, AddressOf SendCashDrawerCommand

        ' Start the print job (this will trigger the PrintPage event)
        printDoc.PrintController = New StandardPrintController() ' Avoid showing print dialog
        printDoc.Print()
    End Sub

    Private Shared Sub SendCashDrawerCommand(sender As Object, e As PrintPageEventArgs)
        ' Epson command to open cash drawer: ESC p 0 25 250
        Dim escCommand As Byte() = New Byte() {&H1B, &H70, 0, 25, 250}

        ' Send the raw command to the printer
        e.Graphics.DrawString(Encoding.ASCII.GetString(escCommand), New Font("Arial", 1), Brushes.Black, 0, 0)

        ' Indicate that there are no more pages
        e.HasMorePages = False
    End Sub
End Class
