Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32
Public Class UserCarHome
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim dtA As New MySqlDataAdapter

    Dim query As String

    Dim Server As String = "server=localhost;user=root;password=admin;port=3310;database=registration"
    Dim str = Form1.nameuser
    Public pubVIN As String
    Private Sub loadTable()
        sqlConn.ConnectionString = Server
        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT applicant.APP_CODE, VIN, if (QUALIFICATION=1, 'Yes', 'No') as Qualification, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE, VEH_CLASS, VEH_COLOR, 
            PLATE_NUM from car_model inner join vehicle_info inner join applicant inner join form inner join emission where applicant.APP_CODE = " & str & "
            and vehicle_info.APP_CODE=applicant.APP_CODE and vehicle_info.EMM_CODE=emission.EMM_CODE and vehicle_info.CM_CODE = car_model.CM_CODE and form.EMM_CODE = emission.EMM_CODE;"

        sqlRd = sqlCmd.ExecuteReader
        sqlDt.Load(sqlRd)
        sqlRd.Close()
        sqlConn.Close()
        DataGridView1.DataSource = sqlDt
    End Sub
    Private Sub UserCarHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTable()
        TB1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlConn.ConnectionString = Server
        sqlConn.Open()

        query = "SELECT COUNT(1) as YN FROM vehicle_info WHERE VIN = '" & TB1.Text & "';"
        sqlCmd = New MySqlCommand(query, sqlConn)
        sqlRd = sqlCmd.ExecuteReader
        sqlRd.Read()

        Dim exist1 As Int16
        exist1 = sqlRd("YN")
        sqlRd.Close()
        sqlConn.Close()

        If exist1 = 1 Then
            pubVIN = TB1.Text
            UserCarUpdate.Show()
            Me.Close()
        Else
            MsgBox("No Existing Record Found")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UserHome.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If String.IsNullOrEmpty(TB1.Text) = False Then
            sqlConn.ConnectionString = Server

            sqlConn.Open()
            query = "Select COUNT(VIN) as num from vehicle_info inner join applicant where vehicle_info.APP_CODE=" & str & ";"

            sqlCmd = New MySqlCommand(query, sqlConn)
            'Dim ncmd As New MySqlCommand(query, sqlConn)
            'Dim myreader1 As MySqlDataReader

            sqlRd = sqlCmd.ExecuteReader
            sqlRd.Read()

            Dim ctr As Int16

            ctr = sqlRd("num")

            sqlRd.Close()
            sqlCmd.Dispose()

            If ctr <= 1 Then
                MessageBox.Show("Action now Allowed")
                TB1.Text = ""

            Else
                query = "SELECT COUNT(1) as YN FROM vehicle_info WHERE VIN = '" & TB1.Text & "';"

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
                        .CommandText = "DELETE form from form join emission on form.EMM_CODE = emission.EMM_CODE
                                join vehicle_info on emission.EMM_CODE = vehicle_info.EMM_CODE AND vehicle_info.VIN = @VIN;
                                DELETE vehicle_info, car_model, emission from vehicle_info join  car_model on car_model.CM_CODE = vehicle_info.CM_CODE 
                                AND vehicle_info.VIN = @VIN join emission on vehicle_info.EMM_CODE=emission.EMM_CODE;"

                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@VIN", TB1.Text)

                    End With

                    sqlCmd.ExecuteNonQuery()
                    sqlCmd.Parameters.Clear()
                    sqlConn.Close()
                    loadTable()
                    DataGridView1.Refresh()
                    TB1.Text = ""

                    MessageBox.Show("Vehicle Deleted")
                Else
                    MessageBox.Show("No Record of such Exists")
                End If
            End If
            sqlConn.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class