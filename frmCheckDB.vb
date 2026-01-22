Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class frmCheckDB

    Private Sub frmCheckDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDeviceName.Text = Environment.MachineName

    End Sub

    '===========================
    ' CHECK SQL SERVER INSTANCE
    '===========================
    Private Sub btnCheckInstance_Click(sender As Object, e As EventArgs) Handles btnCheckInstance.Click
        Try
            Dim instances = SqlDataSourceEnumerator.Instance.GetDataSources()
            lstInstances.Items.Clear()

            For Each row As DataRow In instances.Rows
                Dim instName As String = row("ServerName").ToString()

                If row("InstanceName").ToString() <> "" Then
                    instName &= "\" & row("InstanceName").ToString()
                End If

                lstInstances.Items.Add(instName)
            Next

            If lstInstances.Items.Count = 0 Then
                MessageBox.Show("No SQL instance found.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking instance: " & ex.Message)
        End Try
    End Sub


    '===========================
    ' LOAD DATABASE LIST
    '===========================
    Private Sub btnLoadDBs_Click(sender As Object, e As EventArgs) Handles btnLoadDBs.Click

        If lstInstances.SelectedItem Is Nothing Then
            MessageBox.Show("Select a SQL instance first.")
            Return
        End If

        Dim inst As String = lstInstances.SelectedItem.ToString()
        Dim conStr As String =
            $"Data Source={inst};Initial Catalog=master;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"

        cmbDBList.Items.Clear()

        Using con As New SqlConnection(conStr)
            Try
                con.Open()

                Dim cmd As New SqlCommand("
                    SELECT name 
                    FROM sys.databases 
                    WHERE name NOT IN ('master','tempdb','model','msdb')
                    ORDER BY name
                ", con)

                Dim dr = cmd.ExecuteReader()

                While dr.Read()
                    cmbDBList.Items.Add(dr("name").ToString())
                End While

                If cmbDBList.Items.Count = 0 Then
                    MessageBox.Show("No databases found.")
                End If

            Catch ex As Exception
                MessageBox.Show("Error loading databases: " & ex.Message)
            End Try
        End Using

    End Sub


    '===========================
    ' SAVE SELECTED DATABASE
    '===========================
    Private Sub btnCheckDB_Click(sender As Object, e As EventArgs) Handles btnCheckDB.Click

        If lstInstances.SelectedItem Is Nothing Then
            MessageBox.Show("Select a SQL instance first.")
            Return
        End If

        If cmbDBList.SelectedItem Is Nothing Then
            MessageBox.Show("Select a database from the list.")
            Return
        End If

        Dim inst As String = lstInstances.SelectedItem.ToString()
        Dim dbName As String = cmbDBList.SelectedItem.ToString()

        Try
            ' Save Connection String
            My.Settings.MARKETDBConnectionString =
                $"Data Source={inst};Initial Catalog={dbName};Integrated Security=True;Encrypt=False;TrustServerCertificate=True"

            My.Settings.Save()
            lblSavedConnection.Text = "Saved ✓"
            MessageBox.Show("Database connection saved successfully ✔")

        Catch ex As Exception
            MessageBox.Show("Error saving DB: " & ex.Message)
        End Try

    End Sub

    Private Sub frmCheckDB_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Loginpage.Show()
    End Sub
End Class
