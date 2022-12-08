Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices


Public Class EmployeeAdd
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim dtA As New MySqlDataAdapter
    Dim str = EmployeeHome.appnum
    Dim query As String
    Dim f1, f2, f3, f4, f5, f6, f7 As String

    Dim Server As String = "server=localhost;user=root;password=admin;port=3310;database=registration"

    Private Sub EmployeeAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        APP_CODE.Text = str
        cecN.Checked = True
        ogiN.Checked = True
        certiN.Checked = True
        pcN.Checked = True
        certsN.Checked = True
        prN.Checked = True

        sqlConn.ConnectionString = Server
        sqlConn.Open()
        query = "SELECT TIN_NUM from form inner join applicant where applicant.APP_CODE= " & str & " and applicant.APP_CODE=form.APP_CODE;"

        sqlCmd = New MySqlCommand(query, sqlConn)

        sqlRd = sqlCmd.ExecuteReader()

        sqlRd.Read()

        TIN_NUM.Text = sqlRd("TIN_NUM")
        sqlConn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EmployeeHome.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlConn.ConnectionString = Server
        sqlConn.Open()
        sqlCmd.Connection = sqlConn

        If String.IsNullOrEmpty(BRANCH_CODE.Text) Or
           String.IsNullOrEmpty(CM_CODE.Text) Or
           String.IsNullOrEmpty(VIN.Text) Or
           String.IsNullOrEmpty(VEH_CLASS.Text) Or
           String.IsNullOrEmpty(VEH_COLOR.Text) Then
            MsgBox("There is Field/s Left Empty")
        Else
            query = "SELECT COUNT(1) as YN FROM vehicle_info WHERE VIN = '" & VIN.Text & "';"
            sqlCmd = New MySqlCommand(query, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlRd.Read()

            Dim exist1 As Int16
            exist1 = sqlRd("YN")
            sqlRd.Close()
            sqlConn.Close()

            If exist1 = 0 Then
                sqlConn.ConnectionString = Server
                sqlConn.Open()
                sqlCmd.Connection = sqlConn

                'CERT_EMM_COMPLIANCE
                If cecY.Checked = "True" Then
                    f1 = "1"
                ElseIf cecN.Checked = "true" Then
                    f1 = "0"
                End If

                'OG_SALES_INV
                If ogiY.Checked = "True" Then
                    f2 = "1"
                ElseIf ogiN.Checked = "true" Then
                    f2 = "0"
                End If

                'CERT_COVER
                If certiY.Checked = "True" Then
                    f3 = "1"
                ElseIf certiN.Checked = "true" Then
                    f3 = "0"
                End If

                'POLICE_CLEARANCE
                If pcY.Checked = "True" Then
                    f4 = "1"
                ElseIf pcN.Checked = "true" Then
                    f4 = "0"
                End If

                'CERT_STOCK
                If certsY.Checked = "True" Then
                    f5 = "1"
                ElseIf certsN.Checked = "true" Then
                    f5 = "0"
                End If

                'PAYMENT_REF_NUM
                If prY.Checked = "True" Then
                    f6 = "1"
                ElseIf prN.Checked = "true" Then
                    f6 = "0"
                End If

                Try

                    query &= "INSERT INTO registration.emission (CERT_EMM_COMPLIANCE, OG_SALES_INV) 
                    VALUES (" & f1 & "," & f2 & " ); 
            
                    INSERT INTO registration.vehicle_info (APP_CODE, CM_CODE, EMM_CODE, VIN, PLATE_NUM, VEH_CLASS, VEH_COLOR) 
                        VALUES ('" & str & "' , '" & CM_CODE.Text & "' , (SELECT Distinct LAST_INSERT_ID() from emission) , '" & VIN.Text &
                        "' , '" & PLATE_NUM.Text & "' , '" & VEH_CLASS.Text & "' , '" & VEH_COLOR.Text & "' ); 
            
                    INSERT INTO registration.form (APP_CODE, EMM_CODE, CERT_COVER, POLICE_CLEARANCE, CERT_STOCK, PAYMENT_REF_NUM, DATE_REG,BRANCH_CODE,TIN_NUM) 
                        VALUES ('" & str & "' , (SELECT Distinct LAST_INSERT_ID() from emission), " & f3 & "," & f4 & "," & f5 & "," & f6 &
                        ", CURRENT_DATE()," & BRANCH_CODE.Text & "," & TIN_NUM.Text & "); 

                    UPDATE form, emission, applicant Set Qualification = CASE WHEN CERT_COVER=1 and POLICE_CLEARANCE=1 and CERT_STOCK=1 and PAYMENT_REF_NUM = 1 
                        and emission.CERT_EMM_COMPLIANCE = 1 and emission.OG_SALES_INV = 1 
                        then '1' else '0' end where emission.EMM_CODE=form.EMM_CODE and applicant.APP_CODE=" & APP_CODE.Text & ";

                    UPDATE vehicle_info, applicant, registrar, emission, form
                    set PLATE_NUM = 
	                    CASE registrar.REGION_CODE
		                    WHEN 'Region 1' THEN  concat('AAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 2' THEN  concat('BAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 3' THEN  concat('CAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'CALABARZON' THEN  concat('DAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'MIMAROPA' THEN  concat('EAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 5' THEN  concat('FAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 6' THEN  concat('GAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 7' THEN  concat('HAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 8' THEN  concat('IAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 9' THEN  concat('JAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 10' THEN  concat('KAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 11' THEN  concat('LAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 12' THEN  concat('MAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'Region 13' THEN  concat('NAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'NCR' THEN  concat('OAA ','0',vehicle_info.EMM_CODE)
                            WHEN 'CAR' THEN  concat('PAA ','0',vehicle_info.EMM_CODE)
	                    END
                    WHERE vehicle_info.APP_CODE=applicant.APP_CODE and vehicle_info.EMM_CODE=emission.EMM_CODE 
                    and form.EMM_CODE=emission.EMM_CODE and form.BRANCH_CODE=registrar.BRANCH_CODE;   "


                    sqlCmd = New MySqlCommand(query, sqlConn)
                    sqlRd = sqlCmd.ExecuteReader
                    sqlRd.Close()
                    MsgBox("Vehicle Added")

                    EmployeeHome.Show()
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "MySQL Connector", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MsgBox("Vehicle Not Added")
                Finally
                    sqlConn.Close()
                    sqlConn.Dispose()

                End Try
            Else
                MsgBox("Car already in the System")
            End If
        End If
        sqlConn.Close()
    End Sub
End Class