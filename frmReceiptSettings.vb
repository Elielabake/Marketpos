Public Class frmReceiptSettings

    Private Sub frmReceiptSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtStoreName.Text = My.Settings.StoreName
        txtAddress.Text = My.Settings.StoreAddress
        txtPhone.Text = My.Settings.StorePhone

        If IO.File.Exists(My.Settings.LogoPath) Then
            picLogo.Image = Image.FromFile(My.Settings.LogoPath)
        End If
        ' Load checkboxes
        CheckBoxPrintTotal.Checked = My.Settings.PrintTotal
        CheckBoxPrintPrice.Checked = My.Settings.PrintPrice
        CheckBoxPrintProduct.Checked = My.Settings.PrintProduct
        CheckBoxPrintQty.Checked = My.Settings.PrintQty
        Select Case My.Settings.currencytype
            Case "$"
                RadioButtonUSD.Checked = True
            Case "LBP"
                RadioButtonLBP.Checked = True
            Case Else
                RadioButtonLBP.Checked = True ' default
        End Select
        TXTSUBFOOT.Text = My.Settings.INVSUBFOOT
        TXTFOOT.Text = My.Settings.INVFOOT
        TXTNOTES.Text = My.Settings.INVNOTES
        Select Case My.Settings.customerin
            Case "cni"
                RadioButtonin.Checked = True
            Case "cno"
                RadioButtonout.Checked = True
            Case Else
                RadioButtonout.Checked = True ' default
        End Select

        If IO.File.Exists(My.Settings.LogoPath1) Then
            picLogo1.Image = Image.FromFile(My.Settings.LogoPath1)
        End If
        strname.Text = My.Settings.storename1
        Guna2ToggleSwitch1.Checked = My.Settings.toggleset
    End Sub

    Private Sub btnBrowseLogo_Click(sender As Object, e As EventArgs) Handles btnBrowseLogo.Click
        Using ofd As New OpenFileDialog
            ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg"

            If ofd.ShowDialog = DialogResult.OK Then
                picLogo.Image = Image.FromFile(ofd.FileName)
                My.Settings.LogoPath = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub btnClearLogo_Click(sender As Object, e As EventArgs) Handles btnClearLogo.Click
        picLogo.Image = Nothing
        My.Settings.LogoPath = ""
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.StoreName = txtStoreName.Text
        My.Settings.StoreAddress = txtAddress.Text
        My.Settings.StorePhone = txtPhone.Text

        ' Save checkboxes
        My.Settings.PrintTotal = CheckBoxPrintTotal.Checked
        My.Settings.PrintPrice = CheckBoxPrintPrice.Checked
        My.Settings.PrintProduct = CheckBoxPrintProduct.Checked
        My.Settings.PrintQty = CheckBoxPrintQty.Checked
        If RadioButtonUSD.Checked Then
            My.Settings.currencytype = "$"
        Else
            My.Settings.currencytype = "LBP"
        End If
        My.Settings.INVSUBFOOT = TXTSUBFOOT.Text
        My.Settings.INVFOOT = TXTFOOT.Text
        My.Settings.INVNOTES = TXTNOTES.Text
        My.Settings.Save()
        If RadioButtonin.Checked Then
            My.Settings.customerin = "cni"
        Else
            My.Settings.customerin = "cno"
        End If
        MessageBox.Show("تم حفظ الاعدادات ✅")
        Me.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub

    Private Sub btnBrowseLogo1_Click(sender As Object, e As EventArgs) Handles btnBrowseLogo1.Click
        Using ofd As New OpenFileDialog
            ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg"

            If ofd.ShowDialog = DialogResult.OK Then
                picLogo1.Image = Image.FromFile(ofd.FileName)
                My.Settings.LogoPath1 = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub btnClearLogo1_Click(sender As Object, e As EventArgs) Handles btnClearLogo1.Click
        picLogo1.Image = Nothing
        My.Settings.LogoPath1 = ""
    End Sub
    Private Sub btnSave1_Click(sender As Object, e As EventArgs) Handles btnSave1.Click
        My.Settings.storename1 = strname.Text

        MessageBox.Show("تم حفظ الاعدادات ✅")
        Me.Close()

    End Sub

    Private Sub Guna2ToggleSwitch1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ToggleSwitch1.CheckedChanged
        If Guna2ToggleSwitch1.Checked Then
            My.Settings.toggleset = "True"
        Else
            My.Settings.toggleset = "False"
        End If
    End Sub
End Class
