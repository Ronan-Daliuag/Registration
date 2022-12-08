Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class EmployeeHome
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim dtA As New MySqlDataAdapter
    Dim query As String
    Dim Server As String = "server=localhost;user=root;password=admin;port=3310;database=registration"

    Public formnum As String
    Public appnum As String
    Private Sub loadTable()
        sqlConn.ConnectionString = Server
        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT applicant.APP_CODE as 'App #', concat(LAST_NAME,', ',FIRST_NAME) As Name, registrar.BRANCH_LOC AS Branch, DATE_ADD(DATE_REG, INTERVAL 10 year) AS DATE, 
	if (QUALIFICATION=1, 'Yes', 'No') as Qualification, form.FORM_NUM, PLATE_NUM FROM registration.applicant inner join registration.form inner join registrar inner join vehicle_info inner join emission
    where form.BRANCH_CODE=registrar.BRANCH_CODE and form.APP_CODE = applicant.APP_CODE and vehicle_info.EMM_CODE=emission.EMM_CODE AND emission.EMM_CODE=form.EMM_CODE;"

        sqlRd = sqlCmd.ExecuteReader
        sqlDt.Load(sqlRd)
        sqlRd.Close()
        sqlConn.Close()
        DataGridView1.DataSource = sqlDt
    End Sub

    Private Sub UserHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTable()
    End Sub

    Private Sub B1_Click(sender As Object, e As EventArgs) Handles B1.Click
        If RD1.Checked Then
            If String.IsNullOrEmpty(TB1.Text) = False Then
                sqlConn.ConnectionString = Server
                sqlConn.Open()

                query = "SELECT COUNT(1) as YN FROM applicant WHERE APP_CODE = " & TB1.Text & ";"
                sqlCmd = New MySqlCommand(query, sqlConn)
                sqlRd = sqlCmd.ExecuteReader
                sqlRd.Read()

                Dim exist As Int16
                exist = sqlRd("YN")
                sqlRd.Close()
                sqlConn.Close()
                If exist = 1 Then


                    appnum = TB1.Text
                    EmployeeAdd.Show()
                    Me.Close()
                Else
                    MessageBox.Show("No Record Found")
                End If

            Else
                MessageBox.Show("No Record Found")
            End If
        End If
    End Sub

    Private Sub B2_Click(sender As Object, e As EventArgs) Handles B2.Click
        If RD2.Checked Then
            If String.IsNullOrEmpty(TB2.Text) = False Then
                sqlConn.ConnectionString = Server
                sqlConn.Open()

                query = "SELECT COUNT(1) as YN FROM form WHERE FORM_NUM = " & TB2.Text & ";"

                sqlCmd = New MySqlCommand(query, sqlConn)

                sqlRd = sqlCmd.ExecuteReader
                sqlRd.Read()

                Dim exist As Int16

                exist = sqlRd("YN")

                sqlRd.Close()
                sqlConn.Close()

                If exist = 1 Then
                    formnum = TB2.Text
                    EmployeeEdit.Show()
                    Me.Close()
                Else
                    MessageBox.Show("No Record of such Exists")
                End If
            Else
                MessageBox.Show("No Form Selected")

            End If
        End If
    End Sub

    Private Sub B3_Click(sender As Object, e As EventArgs) Handles B3.Click
        If RD3.Checked Then
            If String.IsNullOrEmpty(TB2.Text) = False And String.IsNullOrEmpty(TB1.Text) = False Then
                sqlConn.ConnectionString = Server

                sqlConn.Open()

                query = "SELECT Count(*) as YN from form inner join applicant where applicant.APP_CODE =
                " & TB1.Text & " and form.APP_CODE = " & TB1.Text & ";"

                sqlCmd = New MySqlCommand(query, sqlConn)

                sqlRd = sqlCmd.ExecuteReader
                sqlRd.Read()

                Dim ctr As Int16

                ctr = sqlRd("YN")

                sqlRd.Close()
                sqlCmd.Dispose()

                If ctr <= 1 Then
                    MessageBox.Show("Action now Allowed")
                    TB1.Text = ""
                    TB2.Text = ""
                    RD2.Checked = False
                    RD1.Checked = False
                    RD3.Checked = False
                Else
                    query = "SELECT COUNT(1) as YN FROM form WHERE FORM_NUM = " & TB2.Text & ";"

                    Dim ecmd As New MySqlCommand(query, sqlConn)
                    sqlRd = ecmd.ExecuteReader
                    sqlRd.Read()

                    Dim exist As Int16

                    exist = sqlRd("YN")

                    sqlRd.Close()
                    sqlConn.Close()

                    If exist = 1 Then
                        For Each row As DataGridViewRow In DataGridView1.SelectedRows
                            DataGridView1.Rows.Remove(row)
                        Next

                        sqlConn.Open()
                        sqlCmd.Connection = sqlConn

                        With sqlCmd
                            .CommandText = "SET FOREIGN_KEY_CHECKS=0; DELETE vehicle_info from vehicle_info join car_model on vehicle_info.CM_CODE = car_model.CM_CODE 
                        join emission on emission.EMM_CODE = vehicle_info.EMM_CODE join form on FORM_NUM = @FORM_NUM AND form.EMM_CODE = emission.EMM_CODE;
                        DELETE form, emission from form join emission on FORM_NUM = @FORM_NUM AND form.EMM_CODE = emission.EMM_CODE;"

                            .CommandType = CommandType.Text
                            .Parameters.AddWithValue("@FORM_NUM", TB2.Text)

                        End With

                        sqlCmd.ExecuteNonQuery()
                        sqlCmd.Parameters.Clear()
                        sqlConn.Close()
                        loadTable()
                        DataGridView1.Refresh()

                        TB2.Text = ""
                        TB1.Text = ""
                        RD2.Checked = False
                        MessageBox.Show("Record Deleted")
                    Else
                        MessageBox.Show("No Record of such Exists")
                    End If
                End If
                sqlConn.Close()
            Else
                MessageBox.Show("Blank APP_CODE/FORM_NUM")
            End If
        End If

        loadTable()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class