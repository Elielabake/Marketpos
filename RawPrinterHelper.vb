Imports System.Runtime.InteropServices

Public Class RawPrinterHelper
    <DllImport("winspool.drv", SetLastError:=True, CharSet:=CharSet.Ansi)>
    Public Shared Function OpenPrinter(ByVal szPrinter As String, ByRef hPrinter As IntPtr, ByVal pd As IntPtr) As Boolean
    End Function

    <DllImport("winspool.drv", SetLastError:=True)>
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.drv", SetLastError:=True, CharSet:=CharSet.Ansi)>
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Integer, ByRef pDocInfo As DOCINFOA) As Boolean
    End Function

    <DllImport("winspool.drv", SetLastError:=True)>
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.drv", SetLastError:=True)>
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.drv", SetLastError:=True)>
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.drv", SetLastError:=True)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Integer, ByRef dwWritten As Integer) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Public Structure DOCINFOA
        <MarshalAs(UnmanagedType.LPStr)>
        Public pDocName As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public pDataType As String
    End Structure

    Public Shared Function SendStringToPrinter(ByVal printerName As String, ByVal data As String) As Boolean
        Dim pBytes As IntPtr = Marshal.StringToCoTaskMemAnsi(data)
        Dim success As Boolean = False

        Try
            Dim hPrinter As IntPtr = IntPtr.Zero
            If OpenPrinter(printerName, hPrinter, IntPtr.Zero) Then
                Dim docInfo As New DOCINFOA With {
                    .pDocName = "Open Drawer",
                    .pDataType = "RAW"
                }
                If StartDocPrinter(hPrinter, 1, docInfo) Then
                    If StartPagePrinter(hPrinter) Then
                        Dim written As Integer
                        success = WritePrinter(hPrinter, pBytes, data.Length, written)
                        EndPagePrinter(hPrinter)
                    End If
                    EndDocPrinter(hPrinter)
                End If
                ClosePrinter(hPrinter)
            End If
        Finally
            Marshal.FreeCoTaskMem(pBytes)
        End Try

        Return success
    End Function
End Class
