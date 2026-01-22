Imports System.Data.SqlClient

Public Class FrmStockComposite

    Private con As New SqlConnection(My.Settings.MARKETDBConnectionString)
    Public Sub fillcateg()
        con.Open()
        Dim str As New SqlCommand("select distinct categ from categTbl ", con)
        Dim reader As SqlDataReader = str.ExecuteReader
        cmbCat.Items.Clear()
        While reader.Read
            cmbCat.Items.Add(reader("categ"))
        End While
        con.Close()
    End Sub
    '========================
    ' FORM LOAD
    '========================
    Private Sub FrmStockComposite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillcateg()
        SetupGrid()
        txtDP.Text = GetDollarRate()
        con.Open()
        Dim cmd As New SqlCommand("SELECT code FROM stock", con)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(ds, "list")
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            col.Add(ds.Tables(0).Rows(i)("code").ToString())
        Next
        txtCode.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCode.AutoCompleteCustomSource = col
        txtCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        con.Close()
        txtQtyAvailable.Text = "0"
        txtQtyJ.Text = 1
    End Sub

    '========================
    ' GRID SETUP
    '========================
    Private Sub SetupGrid()
        dgvComponents.Columns.Clear()

        dgvComponents.Columns.Add("ComponentId", "ID")
        dgvComponents.Columns("ComponentId").Visible = False

        dgvComponents.Columns.Add("ComponentName", "اسم المنتج")
        dgvComponents.Columns.Add("UnitCostD", "$/كلفة المنتج")
        dgvComponents.Columns.Add("UnitCostL", "كلفة المنتج/ل.ل")
        dgvComponents.Columns.Add("UnitPriceD", "$/سعر المنتج مفرق")
        dgvComponents.Columns.Add("UnitPriceL", "سعر المنتج مفرق/ل.ل")
        dgvComponents.Columns.Add("QtyUsed", "الكمية")
        dgvComponents.Columns.Add("UnitPriceDj", "$/سعر المنتج جملة")
        dgvComponents.Columns.Add("UnitPriceLj", "سعر المنتج جملة/ل.ل")

        dgvComponents.Columns.Add("TotalCostD", "Total cost $")
        dgvComponents.Columns.Add("TotalCostL", "Total cost LBP")
        dgvComponents.Columns.Add("TotalPriceD", "Total price $")
        dgvComponents.Columns.Add("TotalPriceL", "Total price LBP")
        dgvComponents.Columns.Add("TotalPriceDj", "Total price $")
        dgvComponents.Columns.Add("TotalPriceLj", "Total price LBP")
        dgvComponents.Columns("UnitCostD").ReadOnly = True
        dgvComponents.Columns("UnitCostL").ReadOnly = True
        dgvComponents.Columns("TotalCostD").Visible = False
        dgvComponents.Columns("TotalCostL").Visible = False
        dgvComponents.Columns("TotalPriceD").Visible = False
        dgvComponents.Columns("TotalPriceL").Visible = False
        dgvComponents.Columns("TotalPriceDj").Visible = False
        dgvComponents.Columns("TotalPriceLj").Visible = False
        dgvComponents.AllowUserToAddRows = False
    End Sub

    '========================
    ' GET DOLLAR RATE
    '========================
    Private Function GetDollarRate() As String
        Using cmd As New SqlCommand("SELECT TOP 1 dp FROM stock WHERE dp IS NOT NULL", con)
            con.Open()
            Dim r = cmd.ExecuteScalar()
            con.Close()
            If r Is Nothing Then Return "0"
            Return r.ToString()
        End Using
    End Function

    '========================
    ' ADD COMPONENT
    '========================
    Private Sub btnAddComponent_Click(sender As Object, e As EventArgs) Handles btnAddComponent.Click

        Dim frm As New FrmSelectStockComponent
        If frm.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim stockId As Integer = frm.SelectedStockId
        Dim qtyUsed As Decimal = frm.QtyUsed

        Using cmd As New SqlCommand("
            SELECT pname, pcostd, pcostl,ppriced, ppricel ,ppricedj, ppricelj
            FROM stock WHERE Id=@id", con)

            cmd.Parameters.AddWithValue("@id", stockId)

            con.Open()
            Using r = cmd.ExecuteReader()
                If r.Read() Then
                    Dim unitCostD = CDec(r("pcostd"))
                    Dim unitCostL = CLng(r("pcostl"))
                    Dim unitpriceD = CDec(r("ppriced"))
                    Dim unitpricel = CLng(r("ppricel"))
                    Dim unitpriceDj = CDec(r("ppricedj"))
                    Dim unitpricelj = CLng(r("ppricelj"))

                    dgvComponents.Rows.Add(
                        stockId,
                        r("pname").ToString(),
                        unitCostD,
                        unitCostL,
                        unitpriceD,
                        unitpricel,
                        qtyUsed,
                                                 unitpriceDj,
                        unitpricelj,
                                               unitCostD * qtyUsed,
                        unitCostL * qtyUsed,
                        unitpriceD * qtyUsed,
                        unitpricel * qtyUsed,
                        unitpriceDj * qtyUsed,
                        unitpricelj * qtyUsed
                        )
                End If
            End Using
            con.Close()
        End Using

        RecalculateTotals()
    End Sub

    '========================
    ' REMOVE COMPONENT
    '========================
    Private Sub btnRemoveComponent_Click(sender As Object, e As EventArgs) Handles btnRemoveComponent.Click
        If dgvComponents.SelectedRows.Count = 0 Then Exit Sub
        dgvComponents.Rows.Remove(dgvComponents.SelectedRows(0))
        RecalculateTotals()
    End Sub

    '========================
    ' RECALCULATE TOTALS
    '========================
    Private Sub RecalculateTotals()

        Dim totalD As Decimal = 0
        Dim totalL As Decimal = 0
        Dim totalpD As Decimal = 0
        Dim totalpL As Decimal = 0
        Dim totalpDj As Decimal = 0
        Dim totalpLj As Decimal = 0

        For Each row As DataGridViewRow In dgvComponents.Rows
            totalD += CDec(row.Cells("TotalCostD").Value)
            totalL += CLng(row.Cells("TotalCostL").Value)
            totalpD += CDec(row.Cells("TotalPriceD").Value)
            totalpL += CLng(row.Cells("TotalPriceL").Value)
            totalpDj += CDec(row.Cells("TotalPriceDj").Value)
            totalpLj += CLng(row.Cells("TotalPriceLj").Value)

        Next

        txtCostD.Text = totalD
        txtCostl.Text = totalL
        txtPriceD.Text = totalpD
        txtPricel.Text = totalpL
        txtPriceJD.Text = totalpDj
        txtPriceJL.Text = totalpLj

    End Sub

    '========================
    ' SAVE COMPOSITE ITEM
    '========================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If dgvComponents.Rows.Count = 0 Then
            MessageBox.Show("اضف اول مركب")
            Exit Sub
        End If

        con.Open()
        Dim trans = con.BeginTransaction()

        Try
            ' Insert stock item
            Dim cmd As New SqlCommand("
                INSERT INTO stock
                (pname, cat, code, dp, pcostd, pcostl, ppriced, ppricel,
                 codej, ppricedj, ppricelj, qtyj, qavailable, qsold, qtym)
                VALUES
                (@pname,@cat,@code,@dp,@pcostd,@pcostl,@ppriced,@ppricel,
                 @codej,@ppricedj,@ppricelj,@qtyj,@qavailable,0,0);
                SELECT SCOPE_IDENTITY()", con, trans)

            cmd.Parameters.AddWithValue("@pname", txtPName.Text)
            cmd.Parameters.AddWithValue("@cat", cmbCat.Text)
            cmd.Parameters.AddWithValue("@code", txtCode.Text)
            cmd.Parameters.AddWithValue("@dp", txtDP.Text)
            cmd.Parameters.AddWithValue("@pcostd", txtCostD.Text)
            cmd.Parameters.AddWithValue("@pcostl", txtCostl.Text)
            cmd.Parameters.AddWithValue("@ppriced", txtPriceD.Text)
            cmd.Parameters.AddWithValue("@ppricel", txtPricel.Text)
            cmd.Parameters.AddWithValue("@codej", txtCodeJ.Text)
            cmd.Parameters.AddWithValue("@ppricedj", txtPriceJD.Text)
            cmd.Parameters.AddWithValue("@ppricelj", txtPriceJL.Text)
            cmd.Parameters.AddWithValue("@qtyj", txtQtyJ.Text)
            cmd.Parameters.AddWithValue("@qavailable", txtQtyAvailable.Text)

            Dim parentId As Integer = CInt(cmd.ExecuteScalar())

            ' Save components
            For Each row As DataGridViewRow In dgvComponents.Rows
                Dim cmdC As New SqlCommand("
                    INSERT INTO stock_components
                    (ParentStockId, ComponentStockId, QtyUsed, CostD, CostL,priced,pricel,pricedj,pricelj)
                    VALUES (@p,@c,@q,@d,@l,@pd,@pl,@pdj,@plj)", con, trans)

                cmdC.Parameters.AddWithValue("@p", parentId)
                cmdC.Parameters.AddWithValue("@c", row.Cells("ComponentId").Value)
                cmdC.Parameters.AddWithValue("@q", row.Cells("QtyUsed").Value)
                cmdC.Parameters.AddWithValue("@d", row.Cells("TotalCostD").Value)
                cmdC.Parameters.AddWithValue("@l", row.Cells("TotalCostL").Value)
                cmdC.Parameters.AddWithValue("@pd", row.Cells("TotalpriceD").Value)
                cmdC.Parameters.AddWithValue("@pl", row.Cells("TotalpriceL").Value)
                cmdC.Parameters.AddWithValue("@pdj", row.Cells("TotalpriceDj").Value)
                cmdC.Parameters.AddWithValue("@plj", row.Cells("TotalpriceLj").Value)
                cmdC.ExecuteNonQuery()
            Next

            trans.Commit()
            MessageBox.Show("تم الحفظ")

            Me.Close()

        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub
    Private Sub LoadItemByCode(code As String)

        Using cmd As New SqlCommand("
        SELECT Id, pname, cat 
        FROM stock 
        WHERE code = @code", con)

            cmd.Parameters.AddWithValue("@code", code)

            con.Open()
            Dim r = cmd.ExecuteReader()

            If r.Read() Then
                txtPName.Text = r("pname").ToString()
                cmbCat.Text = r("cat").ToString()
                Dim stockId As Integer = CInt(r("Id"))
                con.Close()

                LoadComponents(stockId)
            Else
                con.Close()
            End If
        End Using

    End Sub
    Private Sub LoadItemByName(pname As String)

        Using cmd As New SqlCommand("
        SELECT Id, code, cat 
        FROM stock 
        WHERE pname = @pname", con)

            cmd.Parameters.AddWithValue("@pname", pname)

            con.Open()
            Dim r = cmd.ExecuteReader()

            If r.Read() Then
                txtCode.Text = r("code").ToString()
                cmbCat.Text = r("cat").ToString()
                Dim stockId As Integer = CInt(r("Id"))
                con.Close()

                LoadComponents(stockId)
            Else
                con.Close()
            End If
        End Using

    End Sub
    Private Sub LoadComponents(parentStockId As Integer)

        dgvComponents.Rows.Clear()

        Using cmd As New SqlCommand("
        SELECT sc.ComponentStockId,
               s.pname,
               s.pcostd,
               s.pcostl,
               s.ppriced,
               s.ppricel,
               sc.QtyUsed,
                s.ppricedj,
                s.ppricelj
        FROM stock_components sc
        INNER JOIN stock s ON sc.ComponentStockId = s.Id
        WHERE sc.ParentStockId = @id", con)

            cmd.Parameters.AddWithValue("@id", parentStockId)

            con.Open()
            Dim r = cmd.ExecuteReader()

            While r.Read()
                Dim qty = CDec(r("QtyUsed"))
                Dim costD = CDec(r("pcostd"))
                Dim costL = CLng(r("pcostl"))
                Dim priceD = CDec(r("ppriced"))
                Dim priceL = CLng(r("ppricel"))
                Dim priceDj = CDec(r("ppricedj"))
                Dim priceLj = CLng(r("ppricelj"))

                dgvComponents.Rows.Add(
      r("ComponentStockId"),
      r("pname").ToString(),
      costD,                 ' UnitCostD
      costL,                 ' UnitCostL
      priceD,                ' UnitPriceD
      priceL,                ' UnitPriceL
      qty,                   ' QtyUsed
      priceDj,               ' UnitPriceDj
      priceLj,               ' UnitPriceLj
      costD * qty,           ' TotalCostD
      costL * qty,           ' TotalCostL
      priceD * qty,          ' TotalPriceD
      priceL * qty,          ' TotalPriceL
      priceDj * qty,         ' TotalPriceDj
      priceLj * qty          ' TotalPriceLj
  )

            End While

            con.Close()
        End Using

        RecalculateTotals()

    End Sub
    Private Sub txtCode_Leave(sender As Object, e As EventArgs) Handles txtCode.Leave
        If txtCode.Text.Trim <> "" Then
            LoadItemByCode(txtCode.Text.Trim)
        End If
    End Sub
    Private Sub txtPName_Leave(sender As Object, e As EventArgs) Handles txtPName.Leave
        If txtCode.Text.Trim = "" AndAlso txtPName.Text.Trim <> "" Then
            LoadItemByName(txtPName.Text.Trim)
        End If
    End Sub





End Class
