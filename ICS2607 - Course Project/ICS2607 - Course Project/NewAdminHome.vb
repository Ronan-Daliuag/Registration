Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32
Public Class NewAdminHome
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
        sqlCmd.CommandText = "Select applicant.APP_CODE AS 'App #',concat(LAST_NAME,', ',FIRST_NAME, ', ' , MID_NAME) As Name, 
                        CONT_NUM AS 'Phone Number', USERNAME as 'Username', applicant.DL_NUM as 'DL #', Count(FORM_NUM) as '# of Cars', 
                        applicant.BRANCH_CODE from applicant inner join 
                        form  where applicant.APP_CODE = form.APP_CODE group by applicant.APP_CODE;"

        sqlRd = sqlCmd.ExecuteReader
        sqlDt.Load(sqlRd)
        sqlRd.Close()
        sqlConn.Close()
        DataGridView1.DataSource = sqlDt
    End Sub
    Private Sub NewAdminHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTable()
    End Sub

    Private Sub B3_Click(sender As Object, e As EventArgs) Handles B3.Click
        Try
            If RD1.Checked Then
                If String.IsNullOrEmpty(TB1.Text) = False Then
                    sqlConn.ConnectionString = Server
                    sqlConn.Open()

                    query = "SELECT COUNT(1) as YN FROM applicant WHERE APP_CODE = " & TB1.Text & ";"

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
                            .CommandText = "SET FOREIGN_KEY_CHECKS=0; DELETE applicant, account, form, emission, vehicle_info, driver_license 
                                    from applicant inner join account inner join form inner join emission inner join vehicle_info inner join 
                                    driver_license where driver_license.DL_NUM=applicant.DL_NUM and applicant.APP_CODE=vehicle_info.APP_CODE 
                                    AND form.APP_CODE=applicant.APP_CODE and vehicle_info.EMM_CODE=emission.EMM_CODE
	                                AND emission.EMM_CODE=form.EMM_CODE AND applicant.APP_CODE=@APP_CODE and applicant.USERNAME=account.USERNAME;"

                            .CommandType = CommandType.Text
                            .Parameters.AddWithValue("@APP_CODE", TB1.Text)

                        End With

                        sqlCmd.ExecuteNonQuery()
                        sqlCmd.Parameters.Clear()
                        sqlConn.Close()

                        DataGridView1.Refresh()
                        loadTable()

                        TB1.Text = ""
                        RD1.Checked = False
                        MessageBox.Show("Record Deleted")
                    Else
                        MessageBox.Show("No Record of such Exists")
                    End If
                Else
                    MessageBox.Show("No Applicant to be Deleted")
                End If
                sqlConn.Close()
            Else
                MessageBox.Show("Select the button to Delete")
                TB1.Text = ""
                RD1.Checked = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub B2_Click(sender As Object, e As EventArgs) Handles B2.Click
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
                    NewAdminUpdate.Show()
                    Me.Close()
                Else
                    MessageBox.Show("No Record of such Exists")
                End If
            Else
                MessageBox.Show("No Applicant Selected")
            End If
        Else
            MessageBox.Show("Select the button to Update")
        End If
    End Sub

    Private Sub B1_Click(sender As Object, e As EventArgs) Handles B1.Click
        NewAdminAdd.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class